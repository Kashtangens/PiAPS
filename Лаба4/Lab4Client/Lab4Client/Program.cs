using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RpcClientClass rpcClient = new RpcClientClass("http://127.0.0.1:2020");

            string input = "";
            while (input != "Exit")
            {
                // Вводим матрицу
                Console.WriteLine("Enter matr size or type \"Exit\" to close programm");
                input = Console.ReadLine();
                if (input != "Exit")
                {
                    try
                    {
                        int size = int.Parse(input);
                        ArrayList arr = new ArrayList();
                        Console.WriteLine("Enter matrice");
                        int k = 0;
                        while (k < size*size)
                        {
                            string[] inputArr = Console.ReadLine().Split(' ');
                            for (int j = 0; j < inputArr.Length && k < size*size; j++)
                            {
                                arr.Add(int.Parse(inputArr[j]));
                                k++;
                            }
                        }

                        Console.WriteLine("\n Start matrice");
                        // Выводим начальную матрицу
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                Console.Write("{0} ", (int)arr[i * size + j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();


                        ArrayList result = rpcClient.MatrixTransform(arr, size);
                        if (result != null)
                        {
                            // Выводим итоговую матрицу и минимальный элемент
                            Console.WriteLine("Min elememnt is: {0} \nResult matrice:", (int)result[(int)result[0] * (int)result[0] + 1]);
                            for (int i = 0; i < (int)result[0]; i++)
                            {
                                for (int j = 0; j < (int)result[0]; j++)
                                {
                                    Console.Write("{0} ", (int)result[i * size + j + 1]);
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Unsuccessfull");
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\n{0}\n", e.Message);
                    }
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
