namespace dz06_12
{
    internal class Program
    {

        delegate bool NumberFilter(int number);

        static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 13, 21, 34 };
            var evenNumbers = FilterNumbers(array, IsEven);
            var oddNumbers = FilterNumbers(array, IsOdd);
            var primeNumbers = FilterNumbers(array, IsPrime);
            var fibonacciNumbers = FilterNumbers(array, IsFibonacci);

            Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Непарні числа: " + string.Join(", ", oddNumbers));
            Console.WriteLine("Прості числа: " + string.Join(", ", primeNumbers));
            Console.WriteLine("Числа Фібоначчі: " + string.Join(", ", fibonacciNumbers));
        }

        static List<int> FilterNumbers(int[] array, NumberFilter filter)
        {
            return array.Where(number => filter(number)).ToList();
        }


        static bool IsEven(int number) => number % 2 == 0;

        static bool IsOdd(int number) => number % 2 != 0;

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static bool IsFibonacci(int number)
        {
            if (number < 0) return false;

            bool IsPerfectSquare(int x) => Math.Sqrt(x) % 1 == 0;

            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }
    }
}
