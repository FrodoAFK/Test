using System;
using System.Configuration;
using System.Collections.Specialized;
using RestSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int n = 30;
            int[] Mas = new int[n];
            int[] SortMas = new int[n];
            Random(Mas, n);

            Random Ind = new Random();
            int Index = Ind.Next(1, 3);
            if (Index == 1) BubbleSort(Mas);
            else if (Index == 2) InsertionSort(Mas, n);
            else if (Index == 3) SelectionSort(SortMas);

            Console.Read();

            string sAttr = ConfigurationManager.AppSettings.Get("Key0");
            var client = new RestClient(sAttr);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Sorting Massiv", Convert.ToString(SortMas));
            IRestResponse response = client.Execute(request);
        }

        static void Random(int[] Mas, int n)
        {
            Random rnd = new Random();
            Mas[0] = rnd.Next(-100, 100);
            for (int i = 1; i < n;)
            {
                int num = rnd.Next(-100, 100);
                int j;
                for (j = 0; j < i; j++)
                {
                    if (num == Mas[j])
                        break;
                }
                if (j == i)
                {
                    Mas[i] = num;
                    i++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,4} ", Mas[i]);
            }
            Console.WriteLine();
        }


        static int[] BubbleSort(int[] SortMas)
        {
            int temp;
            for (int i = 0; i < SortMas.Length; i++)
            {
                for (int j = i + 1; j < SortMas.Length; j++)
                {
                    if (SortMas[i] > SortMas[j])
                    {
                        temp = SortMas[i];
                        SortMas[i] = SortMas[j];
                        SortMas[j] = temp;
                    }
                }
            }
            Console.WriteLine("Bubble Sort");
            for (int i = 0; i < SortMas.Length; i++)
            {
                Console.Write("{0,4} ", SortMas[i]);
            }
            return SortMas;
        }

        static int[] InsertionSort(int[] SortMas, int n)
        {
            for (int i = 1; i < n; i++)
                for (int j = i; j > 0 && SortMas[j - 1] > SortMas[j]; j--)
                {
                    int d = SortMas[j - 1];
                    SortMas[j - 1] = SortMas[j];
                    SortMas[j] = d;
                }

            Console.WriteLine("Insertion Sort");

            for (int i = 0; i < SortMas.Length; i++)
            {
                Console.Write("{0,4} ", SortMas[i]);
            }
            return SortMas;
        }

        static int[] SelectionSort(int[] SortMas)
        {

            for (int i = 0; i < SortMas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < SortMas.Length; j++)
                {
                    if (SortMas[j] < SortMas[min])
                    {
                        min = j;
                    }
                }
                int temp = SortMas[min];
                SortMas[min] = SortMas[i];
                SortMas[i] = temp;
            }

            Console.WriteLine("Selection Sort");

            for (int i = 0; i < SortMas.Length; i++)
            {
                Console.Write("{0,4} ", SortMas[i]);
            }
            return SortMas;
        }
    }
}
