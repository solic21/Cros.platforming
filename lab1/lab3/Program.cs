using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace lab3
{
    public class Program
    {
        private static int n, m;
        private char[,] T;

        private bool CheckN(int n) => !(1 <= n && n <= 10);
        private bool CheckM(int m) => !(0 <= m && m < 100);

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


        private void OnExecute()
        {
            string[] lines = File.ReadAllLines(InputFile);

            T = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    T[i, j] = ' ';
                }
            }

            string[] NM = lines[0].Split();

            if (NM.Length != 2)
                throw new ArgumentException("First line must have two numbers!");

            n = ConvertToInt32(NM[0]);
            m = ConvertToInt32(NM[1]);

            if (CheckN(n))
                throw new ArgumentException("Input value N do not match criteria 1 <= N <= 10");

            if (CheckM(m))
                throw new ArgumentException("Input value M do not match criteria 0 <= N <= 100");

            for (int z = 0; z < n; z++)
            {
                string word = lines[z + 1];
                for (int x = 0; x < n; x++) T[z, x] = word[x];
            }

            for (int z = 0; z < m; z++)
            {
                string word = lines[z + 1 + n];

                for (int x = 0; x < word.Length; x++)
                {
                    bool c = false;
                    for (int i = 0; i < n; i++)
                    { // ищем нужную букву в таблице
                        for (int j = 0; j < n; j++)
                        {       // где угодно, нам пофиг
                            if (T[i, j] == word[x])
                            { 
                                T[i, j] = ' '; 
                                c = true; 
                                break; 
                            }
                        }
                        if (c) break; // и заменяем ее пробелом
                    }
                }
            }      // теперь в таблице только «лишние» буквы

            int count = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (T[i, j] != ' ')
                        count += 1;
                }
            }

            char[] res1 = new char[count];
            int t = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (T[i, j] != ' ')
                        res1[t++] = T[i, j];
                }
            }

            Array.Sort(res1);
            String res2 = new String(res1);

            Console.WriteLine(res2);

            File.WriteAllText(OutputFile, res2);
        }
    }
}
