using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Lab2_Server
{
    /// <summary>
    /// Структура клиента, содержащая сокет и имя пользователя
    /// </summary>
    public struct Client
    {
        public Socket socket;
        public string name;
    }


    public class Server
    {

        #region Properties
        /// <summary>
        /// Tcp сервер
        /// </summary>
        TcpListener listener;
        /// <summary>
        /// Порт
        /// </summary>
        int port;
        /// <summary>
        /// Адрес
        /// </summary>
        IPAddress localAddr;
        /// <summary>
        /// Поток прослушки
        /// </summary>
        Thread listenerThread;
        /// <summary>
        /// Поток общения
        /// </summary>
        Thread rxtxThread;
        /// <summary>
        /// Список сокетов клиентов 
        /// </summary>
        List<Client> clients;
        /// <summary>
        /// Мьютекс для синхронизации добавления новых клиентов и прослушки сообщения с них
        /// </summary>
        Mutex clientMutex = new Mutex();
        /// <summary>
        /// Мьютекс для синхронизации потока завершения и потока приема/отправки данных
        /// </summary>
        Mutex closeRxTxMutex = new Mutex();
        /// <summary>
        /// Мьютекс для синхронизации потока завершения и потока прослушивания порта
        /// </summary>
        Mutex closeListenerMutex = new Mutex();
        /// <summary>
        /// Флаг завершения работы потока приема/отправки данных
        /// </summary>
        bool isClosingRxTxThread;
        /// <summary>
        /// Флаг завершения работы потока прослушивания порта
        /// </summary>
        bool isClosingListenerThread;
        #endregion

        #region Model Delegates

        /// <summary>
        /// Делегат получения сообщения от пользователя
        /// </summary>
        /// <param name="name">Имя пользователя, отправившего сообщение</param>
        /// <param name="address">IP адресс пользователя, который отправил сообщение</param>
        /// <param name="message">Сообщение, которое отправил пользователь</param>
        public delegate void ReceiveMessage(string name, IPAddress address, string message);
        public delegate void ClientConnected();
        public ReceiveMessage receiveMessage;
        public ClientConnected clientConnected;

        #endregion

        #region Control Functions
        /// <summary>
        /// Конструктор сервера
        /// </summary>
        /// <param name="address">IP адрес сервера</param>
        /// <param name="port">Порт сервера</param>
        public Server(IPAddress address, int port)
        {
            this.localAddr = address;
            this.port = port;
            this.clients = new List<Client>();
            this.listener = new TcpListener(localAddr, this.port);
        }

        /// <summary>
        /// Функция прослушки
        /// </summary>
        public void Listen()
        {
            isClosingListenerThread = false;
            isClosingRxTxThread = false;
            listener.Start();
            listenerThread = new Thread(ListenerThreadFunc);
            listenerThread.Start();
            rxtxThread = new Thread(rxtxThreadFunc);
            rxtxThread.Start();
        }


        //Функция потока прослушки
        protected void ListenerThreadFunc()
        {
            byte[] bytes = new byte[1024];
            string mes;
            bool isClosing = false;
            while (!isClosing)
            {
                // Проверяем, не надо ли закрыть поток
                closeListenerMutex.WaitOne();
                isClosing = isClosingListenerThread;
                closeListenerMutex.ReleaseMutex();
                // Если не надо, то работаем
                if (listener.Pending())
                {
                    // Строчка для дебага и проверки наличия подключения
                    //Console.WriteLine("Есть попытка подключения");
                    Socket sock = listener.AcceptSocket();
                    sock.Receive(bytes);
                    mes = System.Text.Encoding.UTF8.GetString(bytes);
                    Client client;
                    client.name = mes;
                    client.socket = sock;
                    clientMutex.WaitOne();
                    clients.Add(client);
                    clientMutex.ReleaseMutex();
                    receiveMessage?.Invoke(client.name, (client.socket.RemoteEndPoint as IPEndPoint).Address, "Успешно подключился");
                }
            }
            listener.Stop();
        }


        // Функция потока общения с клиентом
        protected void rxtxThreadFunc()
        {
            string message = "";
            bool isClosing = false;
            while (!isClosing)
            {
                // Проверяем, не надо ли закрыть поток
                closeRxTxMutex.WaitOne();
                isClosing = isClosingRxTxThread;
                closeRxTxMutex.ReleaseMutex();
                // Если не надо, то работаем
                clientMutex.WaitOne();
                foreach (Client client in clients)
                {
                    // Смотрим сокет
                    if (client.socket.Connected)
                    {
                        // Если есть, что читать - читаем
                        if (client.socket.Available > 0)
                        {
                            byte[] messageBytes = new byte[1024];
                            message = "";
                            int endpoint = 0;
                            while (client.socket.Available > 0)
                            {
                                endpoint = client.socket.Receive(messageBytes);
                                messageBytes[endpoint] = 0;
                                message += System.Text.Encoding.UTF8.GetString(messageBytes);
                            }
                            // Вызов делегата
                            receiveMessage?.Invoke(client.name, (client.socket.RemoteEndPoint as IPEndPoint).Address, message);
                            // Отправка сообщения другим клиентам
                            foreach (Client send_client in clients)
                            {
                                if (send_client.socket != client.socket)
                                {
                                    message = client.name + " " + message;
                                    byte[] sendBytes = new byte[message.Length];
                                    send_client.socket.Send(sendBytes);
                                }
                            }
                        }
                    }
                }
                clientMutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// Функция закрытия сервера
        /// </summary>
        public void Close()
        {
            // Закрываем потоки
            closeListenerMutex.WaitOne();
            isClosingListenerThread = true;
            closeListenerMutex.ReleaseMutex();

            closeRxTxMutex.WaitOne();
            isClosingRxTxThread = true;
            closeRxTxMutex.ReleaseMutex();

            // Закрываем соединения
            clientMutex.WaitOne();
            foreach (Client client in clients)
            {
                client.socket.Close();
            }
            clientMutex.ReleaseMutex();
    
        }

        #endregion
    }
}
