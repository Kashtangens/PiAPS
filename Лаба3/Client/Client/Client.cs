using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    /// <summary>
    /// Состояние подключения
    /// </summary>
    public enum ConnectStatus
    {
        Disconnected = 0,
        Connected = 1,
        Error = 2
    }

    public class Client
    {
        #region Properties

        protected Thread receiverThread;

        protected Socket socket;

        protected Mutex receiverMutex;

        protected Mutex socketMutex;

        protected bool isCloseReceiverThread;

        public bool isConnected 
        {
            get
            {
                if (socket != null)
                {
                    return socket.Connected;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion


        #region Delegates
        /// <summary>
        /// Делегат получения сообщения
        /// </summary>
        /// <param name="message">Полученное сообщение</param>
        public delegate void ReceivedMessage(string message);
        public ReceivedMessage receivedMessage;

        /// <summary>
        /// Делегат получения результата подключения
        /// </summary>
        /// <param name="connectStatus">Статус подключения</param>
        public delegate void ConnectEnding(ConnectStatus connectStatus);
        public ConnectEnding connectEnding;

        #endregion

        #region Controll functions
        public Client()
        {
            receiverMutex = new Mutex();
            socketMutex = new Mutex();
        }


        /// <summary>
        /// Функция подключения к серверу
        /// </summary>
        /// <param name="address">IP адресс сервера</param>
        /// <param name="port">Порт сервера</param>
        public void Connect(IPAddress address, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (socket.Connected)
            {
                socket.Close();
            }
            try
            {
                receiverMutex.WaitOne();
                isCloseReceiverThread = false;
                receiverMutex.ReleaseMutex();
                socket.Connect(address, port);
                receiverThread = new Thread(ReceiverThreadFunc);
                receiverThread.Start();
                connectEnding?.Invoke(ConnectStatus.Connected);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                connectEnding?.Invoke(ConnectStatus.Error);
            }
        }

        /// <summary>
        /// Функция отправки сообщения на сервер
        /// </summary>
        /// <param name="message">Отправляемое сообщение</param>
        public void Send(string message)
        {
            socket.Send(System.Text.Encoding.UTF8.GetBytes(message));
        }

        /// <summary>
        /// Функция отключения от сервера
        /// </summary>
        public void Disconnect()
        {
            receiverMutex.WaitOne();
            isCloseReceiverThread = true;
            receiverMutex.ReleaseMutex();
            socketMutex.WaitOne();
            if (socket.Connected)
            {
                socket.Close();
                connectEnding?.Invoke(ConnectStatus.Disconnected);
            }
            socketMutex.ReleaseMutex();
            receiverThread.Join();
        }


        // Receive
        protected void ReceiverThreadFunc()
        {
            bool isClose = false;
            byte[] buffer = new byte[1024];
            int readCount = 0;
            string message;
            while (!isClose)
            {
                if (socket.Connected)
                {
                    receiverMutex.WaitOne();
                    isClose = isCloseReceiverThread;
                    receiverMutex.ReleaseMutex();
                    socketMutex.WaitOne();
                    try
                    {
                        if (socket.Available > 0)
                        {
                            message = "";
                            while (socket.Available > 0)
                            {
                                readCount = socket.Receive(buffer);
                                message += System.Text.Encoding.UTF8.GetString(buffer, 0, readCount);
                            }
                            receivedMessage?.Invoke(message);
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        socketMutex.ReleaseMutex();
                    }
                }
            }
        }

        #endregion
    }
}
