using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRecord
{
    class MNK
    {
        double a, b, delta;

        public double A { get;  }
        public double B { get; }
        public double Delta { get; }

        public int Step { get; set; }

        int N;
        public MNK() { }

        void minQuad(double[] x_array, double[] y_array, int arrSize)
        {
            double sumX = 0, sumY = 0, sumX2 = 0, sumXY = 0;
            arrSize /= sizeof(int);
            for (int i = 0; i < arrSize; i++)
            {    // для всех элементов массива
                sumX += x_array[i];
                sumY += y_array[i];
                sumX2 += x_array[i] * x_array[i];
                sumXY += y_array[i] * x_array[i];
            }
            a = arrSize * sumXY;             // расчёт коэффициента наклона прямой
            a = a - sumX * sumY;
            a = a / (arrSize * sumX2 - sumX * sumX);
            b = (sumY - a * sumX) / arrSize;
            delta = a * (x_array[arrSize - 1] - x_array[0]);  // расчёт изменения
        }

        public double[,] MakeSystem(double[] xTable, double[] yTable, int basis)
        {
            double[,] matrix = new double[basis, basis + 1];
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < basis; i++)
            {
                for (int j = 0; j < basis; j++)
                {
                    double sumA = 0, sumB = 0;
                    for (int k = 0; k < xTable.Length / 2; k++)
                    {
                        sumA += Math.Pow(xTable[ k], i) * Math.Pow(xTable[ k], j);
                        sumB += yTable[k] * Math.Pow(xTable[ k], i);
                    }
                    matrix[i, j] = sumA;
                    matrix[i, basis] = sumB;
                }
            }
            return matrix;
        }
    }
}
