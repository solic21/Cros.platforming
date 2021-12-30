using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Collections.Generic;

namespace lab3
{
    public class Program
    {
        private static Queue<int> q = new Queue<int>();
        private static int i, j;
        private static int n, m;
        private int[,] a;

        private bool CheckInputData(int n) => !(0 < n && n <= 70);
        private static int ConvertToInt32(string value)
        {
            bool parsed = Int32.TryParse(value, out int result);

            if (!parsed)
                throw new ArgumentException($"The value {value} was not parsed to int");

            return result;
        }

        [Option(ShortName = "i")]
        public string InputFile { get; }

        [Option(ShortName = "o")]
        public string OutputFile { get; }

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);


        private void check(int y, int x)
        {    //проверка клетки таблицы
            if (0 <= x && x < m && 0 <= y && y < n && a[y, x] < 0)
            {
                a[y, x] = a[i, j] + 1; //если клетка существует и еще не

                q.Enqueue(y);      //использовалась, то увеличиваем её

                q.Enqueue(x);      //на 1 и ставим в очередь
            }
        }

        private void OnExecute()
        {
            string[] lines = File.ReadAllLines(InputFile);

            MyLibrary.ParseStrings(lines, out n, out m, out a);

            //MyLibrary.PrintArr(a);

            for (i = 0; i < n; i++)

                for (j = 0; j < m; j++)
                {
                    a[i, j] -= 1;

                    if (a[i, j] == 0)
                    {  // исходные значения уменьшаем на 1
                        q.Enqueue(i); //координаты всех единиц записываем
                        q.Enqueue(j); // в очередь
                    }
                }



            while (q.Count > 0)
            {                // пока очередь не пуста

                i = q.Dequeue();    // извлекаем координаты
                j = q.Dequeue();    // следующей клетки

                check(i - 1, j);    // и проверяем её соседей
                check(i + 1, j);
                check(i, j - 1);
                check(i, j + 1);

            }

            MyLibrary.PrintArr(a);
            File.WriteAllText(OutputFile, MyLibrary.ArrayToString(a));
        }
    }
}
