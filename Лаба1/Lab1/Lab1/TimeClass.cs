using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс, реализующий работу годами
    /// </summary>
    class TimeClass
    {
        /// <summary>
        /// Выводит года с 1900 до 2000 и определяет, высокосный или нет
        /// </summary>
        public static void Print()
        {
            for (int year = 1900; year <= 2000; year++)
            {
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                {
                    Console.WriteLine("{0} - високосный", year);
                }
                else
                {
                    Console.WriteLine("{0} - не високосный", year);
                }
            }
        }

    }
}
