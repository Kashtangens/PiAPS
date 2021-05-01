using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ComObject
{

    [Guid("8C034F6A-1D3F-4DB8-BC99-B73873D8C297")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class MatrixCalculator : IMatrixCalculator
    {
        public int[][] Add(int[][] matr1, int[][] matr2)
        {
            int[][] resMatr = null;
            if (matr1.Length == matr2.Length && matr1.Length > 0)
            {
                if (matr1[0].Length == matr2[0].Length && matr1[0].Length > 0)
                {
                    resMatr = new int[matr1.Length][];
                    for (int i = 0; i < matr1.Length; i++)
                    {
                        resMatr[i] = new int[matr1[i].Length];
                        for (int j = 0; j < matr2.Length; j++)
                        {
                            resMatr[i][j] = matr1[i][j] + matr2[i][j];
                        }
                    }
                }
            }
            return resMatr;
        }

        public int[][] Mul(int[][] matr1, int[][] matr2)
        {
            int[][] resMatr = null;
            if (matr1.Length > 0 && matr2.Length > 0)
            {
                if (matr1[0].Length == matr2.Length)
                {
                    resMatr = new int[matr1.Length][];
                    for (int i = 0; i < matr1.Length; i++)
                    {
                        resMatr[i] = new int[matr2[0].Length];
                        for (int j = 0; j < matr2[0].Length; j++)
                        {
                            resMatr[i][j] = 0;
                            for (int k = 0; k < matr2.Length; k++)
                            {
                                resMatr[i][j] += matr1[i][k] * matr2[k][j];
                            }
                        }
                    }
                }
            }
            return resMatr;
        }

        public int[][] Sub(int[][] matr1, int[][] matr2)
        {
            int[][] resMatr = null;
            if (matr1.Length == matr2.Length && matr1.Length > 0)
            {
                if (matr1[0].Length == matr2[0].Length && matr1[0].Length > 0)
                {
                    resMatr = new int[matr1.Length][];
                    for (int i = 0; i < matr1.Length; i++)
                    {
                        resMatr[i] = new int[matr1[i].Length];
                        for (int j = 0; j < matr2.Length; j++)
                        {
                            resMatr[i][j] = matr1[i][j] - matr2[i][j];
                        }
                    }
                }
            }
            return resMatr;
        }
    }
}
