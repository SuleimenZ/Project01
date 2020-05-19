using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Project01
{
    class Program
    {
        public static int[] GenerateRandomArray(int size)
        {
            var rnd = new Random();
            var array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        public static int[] GenerateSortedRandomArray(int size)
        {
            var sortedArray = new int[size];
            var array = new int[size];

            sortedArray = GenerateRandomArray(size);
            Array.Sort(sortedArray);

            return sortedArray;
        }

        static bool SimpleLinearSearch(int[] array, int searchedValue)
        {
            bool answer = false;
            for (int i = 0; i < array.Length; i++)
            {
                if ( searchedValue == array[i])
                {
                    answer = true;
                }
            }
            return answer;
        }

        static bool ImprovedLinearSearch(int[] array, int searchedValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (searchedValue == array[i]) 
                {
                    return true;
                }
            }
            return false;
        }

        static bool ImprovedLinearSearchWithSentinel(int[] array, int searchedValue)
        {
            int i = 0;
            var Last = array.Last();
            array[array.Length-1] = searchedValue;
            while (array[i] != searchedValue)
            {
                i++;
            }
            array[array.Length - 1] = Last;
            if (i < array.Length - 1 || (searchedValue == Last))
            {
                return true;
            }
            return false;
        }

        static bool BinarySearch(int[] array, int searchedValue)
        {
            int floor = 0;
            int ceiling = array.Length - 1;

            while(floor < ceiling)
            {
                int middle = ((ceiling + floor) / 2);
                if (middle == searchedValue)
                {
                    return true;
                }
                else if (middle < searchedValue)
                {
                    floor = middle + 1;
                }
                else
                {
                    ceiling = middle - 1;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            int searchedValue = 0;
            int size = 10000;
            int[] array;
            char userInput;
            bool isInt = false;

            var rnd = new Random();
            var stopwatch = new Stopwatch();

            do
            {
                Console.Clear();
                Console.WriteLine("What size of array should be?");
                isInt = int.TryParse(Console.ReadLine(), out size);
            } while (!isInt || !(size > 0));

            do
            {
                Console.Clear();
                Console.WriteLine("Choose:\n'1' for Best case scenario Linear Search;\n'2' for Random case Linear Search;\n'3' for Worst case Linear Search;\n'4' for Binary Search;");
                userInput = Console.ReadKey().KeyChar;

            } while (!(userInput == '1' || userInput == '2' || userInput == '3' || userInput == '4'));

            Console.Clear();

            switch (userInput)
            {
                case '1':
                case '2':
                case '3':
                    //Generates 10 results
                    for (int i = 0; i < 11; i++) // ignore first result(i=0) because it takes much more time to run code first time so we get more precise results
                    {
                        array = GenerateRandomArray(size);

                        var firstValue = array.First();             //first value in the array
                        var randomValue = array[rnd.Next(0, size)]; //random value in the array
                        var lastValue = array.Last();               //last value in the array

                        switch (userInput)
                        {
                            case '1': searchedValue = firstValue; break;
                            case '2': searchedValue = randomValue; break;
                            case '3': searchedValue = lastValue; break;
                        }
                        Console.WriteLine(i);

                        stopwatch.Start();
                        SimpleLinearSearch(array, searchedValue);
                        stopwatch.Stop();
                        Console.WriteLine($"Simple:   {stopwatch.Elapsed.TotalMilliseconds} ms");
                        stopwatch.Reset();

                        stopwatch.Start();
                        ImprovedLinearSearch(array, searchedValue);
                        stopwatch.Stop();
                        Console.WriteLine($"Improved: {stopwatch.Elapsed.TotalMilliseconds} ms");
                        stopwatch.Reset();

                        stopwatch.Start();
                        ImprovedLinearSearchWithSentinel(array, searchedValue);
                        stopwatch.Stop();
                        Console.WriteLine($"Sentinel: {stopwatch.Elapsed.TotalMilliseconds} ms");
                        stopwatch.Reset();

                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    break;
                case '4':
                    for (int i = 0; i < 11; i++) // ignore first result(i=0) because it takes much more time to run code first time so we get more precise results
                    {
                        array = GenerateSortedRandomArray(size);

                        Console.WriteLine(i);

                        stopwatch.Start();
                        BinarySearch(array, array.Last());
                        stopwatch.Stop();
                        Console.WriteLine($"Binary: {stopwatch.Elapsed.TotalMilliseconds}");
                        stopwatch.Reset();

                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    break;
            }
        }
    }
}