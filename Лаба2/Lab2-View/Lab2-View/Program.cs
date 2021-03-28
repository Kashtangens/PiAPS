using System;
using Lab2_Server;
using System.Net;

namespace Lab2_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string address;
            int port;
            Server server;
            try
            {
                //Создание экземлпяра сервера
                Console.WriteLine("Введите адрес сервера");
                address = Console.ReadLine();
                Console.WriteLine("Введите порт");
                input = Console.ReadLine();
                port = int.Parse(input);
                server = new Server(IPAddress.Parse(address), port);
                server.receiveMessage += new Server.ReceiveMessage(PrintMessage);
                //Начало прослушки
                server.Listen();
                //Цикл приема команд
                do
                {
                    Console.WriteLine("Введите 'Exit', чтобы закрыть соединения и выключить сервер");
                    input = Console.ReadLine();
                } while (input != "Exit");
                server.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Нажмите любую кнопку для выхода из программы");
            Console.ReadKey();
        }

        static void PrintMessage(string name, IPAddress address, string message)
        {
            Console.WriteLine(name + " - " + address.ToString() + ": " + message);
        }
    }
}
