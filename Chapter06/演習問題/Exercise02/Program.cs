namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var int1 = Console.ReadLine();

            if(int.TryParse(int1,out int number)) {
                string result = number.ToString("#,0");
                Console.WriteLine(result);
            } else {
                Console.WriteLine("整数文字列ではありません");
            }

        }
    }
}
