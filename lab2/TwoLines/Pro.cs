using System;
using System.Collections.Generic;

namespace lab2
{
    public class Pro
    {
        private string st1;
        private string st2;
        private List<int> st1Array = new List<int>();
        private List<int> st2Array = new List<int>();

        public string St1 { get => st1; set => st1 = value; }
        public string St2 { get => st2; set => st2 = value; }
        public List<int> St1Array { get => st1Array; set => st1Array = value; }
        public List<int> St2Array { get => st2Array; set => st2Array = value; }

        internal void makeArraySt2()
        {
            char[] a = St2.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                St2Array.Add(int.Parse(a[i].ToString()));
            }
        }

        internal void makeArraySt1()
        {
            char[] a = St1.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                St1Array.Add(int.Parse(a[i].ToString()));
            }
        }
    }
}