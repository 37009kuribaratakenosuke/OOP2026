

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];


            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            var max = numbers.Max(x => x);

            Console.WriteLine($"最大値: {max}");
        }

        private static void Exercise2(int[] numbers) {
            var last1 = numbers[numbers.Length - 2];
            var last2 = numbers[numbers.Length - 1];

            Console.WriteLine(last1);
            Console.WriteLine(last2);
        }

        private static void Exercise3(int[] numbers) {
           foreach (var num in numbers) {
    Console.WriteLine($"{num:D3}");
}
        }

        private static void Exercise4(int[] numbers) {
            var results = numbers
                .Where(n => n > 0)
                .OrderBy(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(", ", results));
        }

        private static void Exercise5(int[] numbers) {
            var results = numbers.Distinct();
            int count =  0;
           foreach(var num in results) {
                if(num >= 10) {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
