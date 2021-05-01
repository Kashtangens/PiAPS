using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwc.XmlRpc;

namespace Lab4Server
{
    class Program
    {
        const int port = 2020;

        static void Main(string[] args)
        {
            XmlRpcServer server = new XmlRpcServer(port);
            server.Add("server", new Program());
            server.Start();
        }

        [XmlRpcExposed]
        public ArrayList MatrixTransform(ArrayList arr, int size)
        {
            // находим диагональ с минимальным элементом
            int minEl = (int)arr[0];
            int minElNumber = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((int)arr[i * size + j] < minEl)
                    {
                        minEl = (int)arr[i * size + j];
                        minElNumber = i * size + j;
                    }
                }
            }

            // Заменяем элементы этой диагонали нулями
            for (int i = minElNumber % (size + 1); i < size * size; i += size + 1)
            {
                arr[i] = 0;
                if (i % size == size - 1)
                {
                    break;
                }
            }

            // Возводим в квадрат элементы, стоящие ниже
            for (int i = (minElNumber % (size + 1)) / size, diagIndex = (minElNumber % (size + 1)) % size; i < size; i++, diagIndex++)
            {
                for (int j = 0; j < diagIndex && j < size; j++)
                {
                    arr[i * size + j] = (int)arr[i * size + j] * (int)arr[i * size + j];
                }
            }

            // Сохраняем матрицу и минимальный элемент
            ArrayList result = new ArrayList();
            result.Add(size);
            result.AddRange(arr);
            result.Add(minEl);
            return result;
        }
    }
}
