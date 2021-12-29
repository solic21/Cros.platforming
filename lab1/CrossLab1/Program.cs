using System;
using System.IO;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StreamReader sr = new StreamReader("C:/Users/Dell7240/Desktop/lab1/input.txt");
            line = sr.ReadLine();
            string[] arr = line.Split(" ");
            int n = Convert.ToInt32(arr[1]);
            int blue = Convert.ToInt32(arr[0]);
            int red = Convert.ToInt32(arr[1]);
            int result = (blue + red) * (blue + red) * n;
            Console.WriteLine(result);
            sr.Close();
            Console.ReadKey();
        }
    }
}