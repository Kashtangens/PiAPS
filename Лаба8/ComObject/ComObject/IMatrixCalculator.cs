using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ComObject
{
    [Guid("364C5E66-4412-48E3-8BD8-7B2BF09E8922")]
    [ComVisible(true)]
    public interface IMatrixCalculator
    {
        /// <summary>
        /// Функция сложения двух матриц
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Сумма первой и второй матриц</returns>
        int[][] Add(int[][] matr1, int[][] matr2);
        
        /// <summary>
        /// Функция вычитания матриц
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Разность между первой и второй матрицами</returns>
        int[][] Sub(int[][] matr1, int[][] matr2);
        
        /// <summary>
        /// Функция перемножения матриц
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Произведение первой матрицы на вторую</returns>
        int[][] Mul(int[][] matr1, int[][] matr2);
    }
}
