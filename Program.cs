using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {

        static int[] array(int size)
        {
            int[] radomArray = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                radomArray[i] = random.Next(100000);
            }
            return radomArray;
        }

        static void search(int length)
        {
            int[] time = new int[length];
            time = array(length);
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{time[i]}");
            }

            Console.WriteLine();
            int s;
            Random r = new Random();
            s = r.Next(100000);
            bool found = false;
            for (int i = 0; i < length; i++)
            {
                if (time[i] == s)
                {
                    Console.WriteLine($"Index: {i + 1}");
                    found = true;
                    break;
                }
            }
            if (!found) Console.WriteLine("Not found");
            return;
        }

        static int[] sortedArray(int length)
        {
            int[] time = new int[length];
            time = array(length);
            int swap;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (time[i] < time[j])
                    {
                        swap = time[i];
                        time[i] = time[j];
                        time[j] = swap;
                    }
                }
            }
            return time;
        }

        static void binarySearch(int length)
        {
            int[] time = new int[length];
            time = sortedArray(length);
            Random r = new Random();
            int s;
            s = r.Next(268435456);
            int n = length / 2;
            int len = length / 2;

            while (len != 0)
            {
                if (time[n] == s) {
                    Console.WriteLine($"Index: {n + 1}");
                    break;
                }
                else if (time[n] < s)
                {
                    n += len - 1;
                }
                else if (time[n] > s)
                {
                    n -= len;
                }
                len = len / 2 + 1;
            }
            return;
        }

        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("linearSearch.txt"))
            {

                writer.WriteLine("n t");

                for (int i = 0; i < 100000; i++)
                {

                    if (Console.KeyAvailable) break;
                    DateTime now = DateTime.Now;
                    {
                        search(i);
                    }
                    TimeSpan difference = DateTime.Now - now;

                    writer.WriteLine($"{i} {difference.TotalMilliseconds}");

                }

            }


            using (StreamWriter bin = new StreamWriter("binarySearch.txt"))
            {
                bin.WriteLine("n t");
                for (int i = 0; i < 100000; i++)
                {
                    if (Console.KeyAvailable) break;
                    DateTime now = DateTime.Now;
                    binarySearch(i);
                    TimeSpan difference = DateTime.Now - now;

                    bin.WriteLine($"{i} {difference.TotalMilliseconds}");

                }

            }

        }
    }
}
