using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс, реализующий работу с числами Фибоначи
    /// </summary>
    class Fibbonachi
    {
        /// <summary>
        /// Выводит числа Фибоначи, не превышающие maxNumber
        /// </summary>
        /// <param name="maxNumber">число, до которого ищем числа Фибоначи</param>
        public static void Print(int maxNumber)
        {
            int num1 = 1;
            int num2 = 1;
            while (num1 <= maxNumber)
            {
                Console.Write(num1);
                Console.Write(" ");
                num2 += num1;
                num1 = num2 - num1;
            }
            Console.WriteLine();
        }
    }
}
