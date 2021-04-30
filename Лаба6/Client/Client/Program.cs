using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RailwayService.ServiceClient railwayServiceClient = new RailwayService.ServiceClient();

            string input = "";
            while (input != "Exit")
            {
                Console.WriteLine("Enter command:");
                Console.WriteLine("1 Get trip");
                Console.WriteLine("2 Get tickets count");
                Console.WriteLine("3 Buy ticket on a trip");
                Console.WriteLine("Exit");
                input = Console.ReadLine();
                if (input == "1" || input == "Get trip")
                {
                    Console.WriteLine("Enter way name:");
                    input = Console.ReadLine();
                    try
                    {
                        RailwayService.Trip[] trips = railwayServiceClient.GetTrip(input);
                        foreach (RailwayService.Trip trip in trips)
                        {
                            Console.WriteLine("{0} tickets count: {1}; time: {2};", input, trip.TicketsCount, trip.Time);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (input == "2" || input == "Get tickets count")
                {
                    Console.WriteLine("Enter way name:");
                    string wayName = Console.ReadLine();
                    Console.WriteLine("Enter time:");
                    string time = Console.ReadLine();
                    try
                    {
                        int ticketsCount = railwayServiceClient.GetTicketsCount(wayName, time);
                        if (ticketsCount >= 0)
                        {
                            Console.WriteLine("Way: {0}; Time: {1}; Tickets count: {2};", wayName, time, ticketsCount);
                        }   
                        else
                        {
                            Console.WriteLine("There are no trips with this way and time");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (input == "3" || input == "Buy ticket on a trip")
                {
                    Console.WriteLine("Enter way name:");
                    string wayName = Console.ReadLine();
                    Console.WriteLine("Enter time:");
                    string time = Console.ReadLine();
                    try
                    {
                        if(railwayServiceClient.BuyTicketOnTrip(wayName, time))
                        {
                            Console.WriteLine("Successfuly buing ticket");
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessful");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
