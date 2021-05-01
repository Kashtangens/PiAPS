using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComObject;

namespace Client
{
    class Program
    { 

        static MatrixCalculator matrixCalculatorClient = new MatrixCalculator();

        static void Main(string[] args)
        {
            string inputStr= "";
            while (inputStr != "Exit" && inputStr != "4" && inputStr != "4) Exit")
            {
                Console.WriteLine("Enter command:");
                Console.WriteLine("1) Add two matrices");
                Console.WriteLine("2) Subdivide two matrices");
                Console.WriteLine("3) Multiply two matrices");
                Console.WriteLine("4) Exit");
                inputStr = Console.ReadLine();
                try
                {
                    if (inputStr == "1" || inputStr == "Add two matrices" || inputStr == "1) Add two matrices")
                    {
                        int[][] matr1 = EnterMatrix();
                        int[][] matr2 = EnterMatrix();
                        int[][] resultMatr = null;
                        if (matr1 != null && matr2 != null)
                            resultMatr = matrixCalculatorClient.Add(matr1, matr2);
                        if (resultMatr != null)
                        {
                            Console.WriteLine("Result:");
                            PrintMatrix(resultMatr);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessful");
                        }

                    }
                    else if (inputStr == "2" || inputStr == "Subdivide two matrices" || inputStr == "2) Subdivide two matrices")
                    {
                        int[][] matr1 = EnterMatrix();
                        int[][] matr2 = EnterMatrix();
                        int[][] resultMatr = null;
                        if (matr1 != null && matr2 != null)
                            resultMatr = matrixCalculatorClient.Sub(matr1, matr2);
                        if (resultMatr != null)
                        {
                            Console.WriteLine("Result:");
                            PrintMatrix(resultMatr);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessful");
                        }
                    }
                    else if (inputStr == "3" || inputStr == "Multiply two matrices" || inputStr == "3) Multiply two matrices")
                    {
                        int[][] matr1 = EnterMatrix();
                        int[][] matr2 = EnterMatrix();
                        int[][] resultMatr = null;
                        if (matr1 != null && matr2 != null)
                            resultMatr = matrixCalculatorClient.Mul(matr1, matr2);
                        if (resultMatr != null)
                        {
                            Console.WriteLine("Result:");
                            PrintMatrix(resultMatr);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessful");
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Функция ввода матрицы через консоль
        /// </summary>
        /// <returns>Введенная матрицы</returns>
        static int[][] EnterMatrix()
        {
            Console.WriteLine("Enter width and height of matrice");
            int width, height;
            int[][] matr = null;
            string[] inputs = Console.ReadLine().Split(' ');
            if (inputs.Length == 2)
            {
                if (!int.TryParse(inputs[0], out width))
                    return null;
                if (!int.TryParse(inputs[1], out height))
                    return null;
                if (width < 1 || height < 1)
                    return null;
                matr = new int[height][];
                Console.WriteLine("Enter matrix");
                for (int i = 0; i < height; i++)
                {
                    matr[i] = new int[width];
                    inputs = Console.ReadLine().Split(' ');
                    for (int j = 0; j < width; j++)
                    {
                        if (!int.TryParse(inputs[j], out matr[i][j]))
                            return null;
                    }
                }
            }
            return matr;
        }

        /// <summary>
        /// Выводит матрицу в консоль
        /// </summary>
        /// <param name="matr">Матрицы, которая будет выведена в консоль</param>
        static void PrintMatrix(int[][] matr)
        {
            for (int i = 0; i < matr.Length; i++)
            {
                for (int j = 0; j < matr[i].Length; j++)
                {
                    Console.Write("{0} ", matr[i][j]);
                }
                Console.WriteLine();
            }
        }
    }

}
