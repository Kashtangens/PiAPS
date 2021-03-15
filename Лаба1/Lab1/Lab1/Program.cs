using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input != "6")
            {
                //Вывод меню
                Console.Clear();
                Console.WriteLine("1) вывести аргументы");
                Console.WriteLine("2) вывести года");
                Console.WriteLine("3) вывести фибоначи");
                Console.WriteLine("4) вывести факториал");
                Console.WriteLine("5) вывести простые числа");
                Console.WriteLine("6) выйти");
                
                //Выбираем команду и выполняем ее
                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Результат:");
                    PrintArguments.Print(args);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Результат:");
                    TimeClass.Print();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Введите ограничение для чисел фибоначи");
                    input = Console.ReadLine();
                    Console.WriteLine("Результат:");
                    Fibbonachi.Print(int.Parse(input));
                }
                else if (input == "4")
                {
                    Console.WriteLine("Введите число, от которого считаем факториал");
                    input = Console.ReadLine();
                    Console.WriteLine("Результат:");
                    Factorial.Print(int.Parse(input));
                }
                else if (input == "5")
                {
                    Console.WriteLine("Введите число, до которого ищем простое число");
                    input = Console.ReadLine();
                    Console.WriteLine("Результат:");
                    SimpleNumbers.Print(int.Parse(input));
                }

                //Ожидание нажатия ввода для очистки экрана
                Console.WriteLine("Нажмите Enter");
                Console.ReadLine();
            }
        }
    }
}
