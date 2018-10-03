using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace task2._2
{
    class Program
    {
        static int Number(string txt)
        {
            txt = txt.Trim(' ');
            int num = Convert.ToInt32(txt);
            return num;
        }
        static int[] Arr(string txt, int n)
        {
            txt = txt.Trim();
            Regex r = new Regex(@"[\s]+");
            string[] temp = r.Split(txt);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                temp[i] = temp[i].Trim(' ');
                arr[i] = Convert.ToInt32(temp[i]);
            }
            return arr;
        }
        static int Inversions(int[] a)
        {
            int inv = 0;
            for(int i = 0; i < a.Length-1; i++)
            {
                for(int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                        inv++;
                }
            }
            return inv;
        }
        static void Main(string[] args)
        {
            FileStream f = new FileStream("input.txt", FileMode.OpenOrCreate);
            StreamReader r = new StreamReader(f);
            string s1 = r.ReadLine();
            string s2 = r.ReadLine();
            r.Close();
            f.Close();
            int num = Number(s1);
            int[] arr = Arr(s2, num);
            int inv = Inversions(arr);
            FileStream f1 = new FileStream("output.txt", FileMode.OpenOrCreate);
            StreamWriter w = new StreamWriter(f1);
            w.WriteLine(inv);
            w.Close();
            f1.Close();
        }
    }
}
