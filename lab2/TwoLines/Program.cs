using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "input.txt";
            Pro pr = new Pro();
            bool first = true;
            
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    if (!first)
                    {
                        pr.St2 = line;
                        pr.makeArraySt2();
                    }
                    else
                    {
                        pr.St1 = line;
                        pr.makeArraySt1();
                    }
                    first = false;

                }
            }
            Console.WriteLine("Input: " + pr.St1);
            Console.WriteLine("       " + pr.St2);
            int cnt = 0;
            for (int i = 0; i < pr.St1Array.Count; i++)
            {
              if (i < pr.St1Array.Count && i < pr.St2Array.Count)
                {
                    if (pr.St1Array[i] + pr.St2Array[i] > 3)
                    {
                        cnt++;
                    }
                }
            }
            int dist = 0;
            if (pr.St1Array.Count > pr.St2Array.Count)
            {
                dist = pr.St2Array.Count;
            }
            else
            {
                dist = pr.St1Array.Count;
            }
            dist += cnt;
            Console.WriteLine("" + dist);

            string writePath = @"output.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(dist);
                }

              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}