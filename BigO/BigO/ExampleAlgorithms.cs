using System;
using System.Collections.Generic;

namespace BigO
{
    // Given an unsorted array of integers, write an algorithm to determine
    // whether the array contains any duplicates
    public class ExampleAlgorithms
    {
        public static bool FirstAlgorithm(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = 0; j < numbers.Length; j++)
                {
                    if (j != i && numbers[i] == numbers[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool SecondAlgorithm(int[] numbers)
        {
            var numbersFound = new List<int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbersFound.Contains(numbers[i]))
                {
                    return true;
                }

                numbersFound.Add(numbers[i]);
            }

            return false;
        }

        public static bool ThirdAlgorithm(int[] numbers)
        {
            Array.Sort(numbers);

            for (var i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FourthAlgorithm(int[] numbers)
        {
            var numbersFound = new HashSet<int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbersFound.Contains(numbers[i]))
                {
                    return true;
                }

                numbersFound.Add(numbers[i]);
            }

            return false;
        }
    }
}
