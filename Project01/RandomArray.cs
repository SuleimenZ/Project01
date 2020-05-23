using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    class RandomArray
    {

        public static int[] Generate(int size)
        {
            var rnd = new Random();
            var array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(int.MinValue, int.MaxValue);
            }

            return array;
        }

        public static int[] GenerateSorted(int size)
        {
            var array = Generate(size);
            Array.Sort(array);

            return array;
        }

        public static bool SimpleLinearSearch(int[] array, int searchedValue)
        {
            bool answer = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (searchedValue == array[i])
                {
                    answer = true;
                }
            }
            return answer;
        }

        public static bool ImprovedLinearSearch(int[] array, int searchedValue)
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

        public static bool ImprovedLinearSearchWithSentinel(int[] array, int searchedValue)
        {
            int i = 0;
            var Last = array.Last();
            array[array.Length - 1] = searchedValue;
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

        public static bool BinarySearch(int[] array, int searchedValue)
        {
            int floor = 0;
            int ceiling = array.Length - 1;

            while (floor < ceiling)
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
    }
}
