using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс, реализующий работу с факториалами
    /// </summary>
    class Factorial
    {
        /// <summary>
        /// Выводит факториал числа number
        /// </summary>
        /// <param name="number"></param>
        public static void Print(int number)
        {
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }

    }
}
