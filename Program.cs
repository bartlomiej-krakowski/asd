using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static int[] tablica(int size)
        {
            int[] tablica_rand = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                tablica_rand[i] = random.Next(100000);
            }
            return tablica_rand;
        }
        static void wyszukiwanie(int length)
        {
            int[] T = new int[length];
            T = tablica(length);
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", T[i]);

            }
            Console.WriteLine();
            int s;
            Random r = new Random();
            s = r.Next(100000);
            bool znaleziona = false;
            for (int i = 0; i < length; i++)
            {
                if (T[i] == s)
                {
                    Console.WriteLine("ta liczba jest na {0} miejscu", i + 1);
                    znaleziona = true;
                    break;
                }
            }
            if (!znaleziona) Console.WriteLine("nie ma jej tutaj :-(");
            return;
        }
        static int[] posortowana(int length)
        {
            int[] T = new int[length];
            T = tablica(length);
            int swap;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (T[i] < T[j])
                    {
                        swap = T[i];
                        T[i] = T[j];
                        T[j] = swap;
                    }
                }
            }
            return T;
        }
        static void binarne(int length)
        {
            int[] T = new int[length];
            T = posortowana(length);
            Random r = new Random();
            int s;
            s = r.Next(268435456);
            int n = length / 2;
            int len = length / 2;

            while (len != 0)
            {

                if (T[n] == s) { Console.WriteLine("ta liczba jest na {0} miejscu", n + 1); break; }
                else if (T[n] < s)
                {
                    n += len - 1;
                }
                else if (T[n] > s)
                {
                    n -= len;
                }
                len = len / 2 + 1;

            }
            return;
        }
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("linioowe.txt"))
            {

                writer.WriteLine("n t");
                long milisekundy;
                for (int i = 0; i < 100000; i++)
                {

                    if (Console.KeyAvailable) break;
                    DateTime teraz = DateTime.Now;
                    {
                        wyszukiwanie(i);
                    }
                    TimeSpan zaraz = DateTime.Now - teraz;


                    writer.WriteLine("{0} {1}", i, zaraz.TotalMilliseconds);



                }

            }
            using (StreamWriter bin = new StreamWriter("binarne.txt"))
            {
                bin.WriteLine("n t");
                long milisekundy;
                for (int i = 0; i < 100000; i++)
                {
                    if (Console.KeyAvailable) break;
                    DateTime teraz = DateTime.Now;
                    {
                        binarne(i);
                    }
                    TimeSpan zaraz = DateTime.Now - teraz;


                    bin.WriteLine("{0} {1}", i, zaraz.TotalMilliseconds);


                }

            }
        }
    }
}