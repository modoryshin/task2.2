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
        static double inversionsCount;
        static int[] Sort(int[] buff)
        {
            if (buff.Length > 1) //Если длинна массива больше 1

            {

                int[] left = new int[buff.Length / 2]; // массив left равен длинна вставленного массива  разделить на 2

                int[] right = new int[buff.Length - left.Length]; // массив right  равен длинна вставленного массива минус массив left

                for (int i = 0; i < left.Length; i++)  // равно 0 , меньше длинны массива left, добавялем 1
                {
                    left[i] = buff[i]; // результат left[i] = buff[i]
                }
                for (int i = 0; i < right.Length; i++) // массив right
                {
                    right[i] = buff[left.Length + i];
                }
                /*Сортируем массивы*/
                if (left.Length > 1)
                    left = Sort(left);
                if (right.Length > 1)
                    right = Sort(right);

                buff = MergeSort(left, right);
            }

            return buff;
        }
        static int[] MergeSort(int[] left, int[] right)
        {
            int[] buff = new int[left.Length + right.Length];

            int i = 0;  //соединенный массив
            int l = 0;  //левый массив
            int r = 0;  //правый массив

            for (; i < buff.Length; i++)
            {

                if (r >= right.Length)
                {
                    buff[i] = left[l];
                    l++;
                }

                else if (l < left.Length && left[l] <= right[r])
                {
                    buff[i] = left[l];
                    l++;
                }

                else
                {
                    buff[i] = right[r];
                    r++;

                    if (l < left.Length)
                        inversionsCount += left.Length - l;
                }
            }

            return buff;
        }
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
            arr = Sort(arr);
            FileStream f1 = new FileStream("output.txt", FileMode.OpenOrCreate);
            StreamWriter w = new StreamWriter(f1);
            w.WriteLine(inversionsCount);
            w.Close();
            f1.Close();
        }
    }
}
