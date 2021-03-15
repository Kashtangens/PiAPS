using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс, реализующий работу с аргументами консоли
    /// </summary>
    class PrintArguments
    {
        /// <summary>
        /// Выводит аргументы консоли
        /// </summary>
        /// <param name="args">аргументы консоли</param>
        public static void Print(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
