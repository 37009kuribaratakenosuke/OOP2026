
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(" --- 4.2.1 ---");
            Exercise1();
            Console.WriteLine("\n --- 4.2.2 ---");
            Exercise2();
            Console.WriteLine("\n --- 4.2.3 ---");
            Exercise3();
        }

        

        private static void Exercise1() {
            //if-else文を使用


            Console.Write("点数を入力してください: ");

            int score = int.Parse(Console.ReadLine());

            if (score < 0) {
                Console.WriteLine(score);
            }else if (score < 100) {
                Console.WriteLine(score * 2);
            } else if (score < 500) {
                Console.WriteLine(score * 3);
            } else {
                Console.WriteLine(score);
            }


        }

        private static void Exercise2() {
            //switch文を使用

        }

        private static void Exercise3() {
            //switch式を使用

        }
    }
}
