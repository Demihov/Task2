using System;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomArray<int> arr = new CustomArray<int>(-5, 5);

            for (int i = -5; i < 5; i++)
            {
                arr[i] = i + (i - 1);
            }

            arr[-2] = 12;

            Console.WriteLine(arr[-2]);
        }
    }
}
