using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class MyLibrary
    {
        private static bool CheckNM(int x) => !(x < 100);
        private static int ConvertToInt32(string value)
        {
            bool parsed = Int32.TryParse(value, out int result);

            if (!parsed)
                throw new ArgumentException($"The value {value} was not parsed to int");

            return result;
        }
        public static void ParseStrings(string[] lines, out int N, out int M, out int[,] matrix)
        {
            string[] NM = lines[0].Split();

            if (NM.Length != 2)
                throw new ArgumentException("First line must have two numbers!");

            N = ConvertToInt32(NM[0]);
            M = ConvertToInt32(NM[1]);

            if (CheckNM(N) || CheckNM(M))
                throw new ArgumentException("Input values do not match criteria M, N <= 100");

            if (lines.Length - 1 != N)
                throw new ArgumentException("Must be N lines");

            matrix = new int[N, M];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split();

                if (numbers.Length != M)
                    throw new ArgumentException("Must be M numbers in all lines");

                for (int j = 0; j < M; j++)
                {
                    int node = ConvertToInt32(numbers[j]);
                    matrix[i - 1, j] = ConvertToInt32(numbers[j]);
                }
            }
        }
    }
}
