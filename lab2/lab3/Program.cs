using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;

namespace lab2
{
    class Info
    {
        public bool possible;
        public int nOnes;
        public int lastDigit;
        public int prevResult;

        public Info(bool pos, int n, int l, int prev)
        {
            possible = pos;
            nOnes = n;
            lastDigit = l;
            prevResult = prev;
        }
    }

    public class Program
    {
        private static int n, m;
        private char[,] T;

        private bool CheckN(int n) => !(2 <= n && n <= 100000);

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

            n = ConvertToInt32(lines[0].Split()[0]);
            string res = "";

            if (CheckN(n))
                throw new ArgumentException("Input value N do not match criteria 1 <= N <= 10");

            int[,] f = new int[2, 2];

            f[0, 0] = (int)Char.GetNumericValue(lines[1][0]);
            f[0, 1] = (int)Char.GetNumericValue(lines[1][1]);
            f[1, 0] = (int)Char.GetNumericValue(lines[1][2]);
            f[1, 1] = (int)Char.GetNumericValue(lines[1][3]);

            List<List<Info>> info = new List<List<Info>>(2);

            for (int i = 0; i < 2; i++)
            {
                info.Add(new List<Info>());

                for (int j = 0; j < n + 1; j++)
                {
                    info[i].Add(new Info(false, 0, -1, -1));
                }
            }

            info[0][1].possible = true;
            info[0][1].nOnes = 0;
            info[0][1].lastDigit = 0;
            info[0][1].prevResult = -1;
            info[1][1].possible = true;
            info[1][1].nOnes = 1;
            info[1][1].lastDigit = 1;
            info[1][1].prevResult = -1;

            for (int len = 2; len <= n; len++)
            {
                for (int prevResult = 0; prevResult <= 1; prevResult++)
                {
                    if (!info[prevResult][len - 1].possible)
                    {
                        continue;
                    }
                    for (int lastDigit = 0; lastDigit <= 1; lastDigit++)
                    {
                        int result = f[prevResult, lastDigit];
                        int nOnes = info[prevResult][len - 1].nOnes + lastDigit;
                        if (!info[result][len].possible || nOnes > info[result][len].nOnes)
                        {
                            info[result][len].possible = true;
                            info[result][len].nOnes = nOnes;
                            info[result][len].lastDigit = lastDigit;
                            info[result][len].prevResult = prevResult;
                        }
                    }
                }
            }
            if (!info[1][n].possible)
            {
                res = "No solution";
            }
            else
            {
                Queue<int> ans = new Queue<int>();
                int result = 1;
                int len = n;
                int count = 0;

                while (len > 0)
                {
                    ans.Enqueue(info[result][len].lastDigit);
                    result = info[result][len].prevResult;
                    len--;
                    count++;
                }

                for (int i = 0; i < count; i++)
                {
                    res += ans.Dequeue();
                }
            }

            File.WriteAllText(OutputFile, res);
            Console.WriteLine(res);
        }
    }
}
