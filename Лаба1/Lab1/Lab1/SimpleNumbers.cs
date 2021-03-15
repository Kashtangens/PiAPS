using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Класс, реализующий работу с простыми числами
    /// </summary>
    class SimpleNumbers
    {
        /// <summary>
        /// Выводит все простые числа до maxNumber включительно
        /// </summary>
        /// <param name="maxNumber">число, до которого ищем простые числа</param>
        public static void Print(int maxNumber)
        {
            if (maxNumber >= 1)
            {
                Console.WriteLine(1);
                //Инициализируем массив, определяющий, является ли i-ое число простым
                bool[] isSimple = new bool[maxNumber + 1];
                for (int i = 0; i <= maxNumber; i++)
                {
                    isSimple[i] = true;
                }
                //Решето Эратосфена
                for (int i = 2; i <= maxNumber; i++) {
                    if (isSimple[i])
                    {
                        Console.WriteLine(i);
                        for (int j = 2; j*i <= maxNumber; j++)
                        {
                            isSimple[j * i] = false;
                        }
                    }
                }
            }
        }

    }
}
