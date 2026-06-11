
namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            int count = text.Count(c => c == ' ');
            Console.WriteLine(count);
        }

        private static void Exercise2(string text) {

            Console.Write("検索");
            var search = Console.ReadLine();
            Console.Write("置換");
            var replace = Console.ReadLine();

            var replaced = text.Replace(search, replace);
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            
        }

        private static void Exercise4(string text) {
            int count2 = text.Split(' ').Length;
            Console.WriteLine(count2);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ');

            foreach (var word in words.Where(w => w.Length <= 4)) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ", "");

            var alphDicCount = Enumerable.Range('a', 26).
                ToDictionary(num =>((char)num).ToString(), num => 0);


            //var dict = new SortedDictionary<char, int>();
            foreach (var word in alphDicCount) {
                Console.WriteLine(word.Key + ":" + word.Value);
            }

            var array = Enumerable.Repeat(0, 26).ToArray();
            foreach(var alph in str) {
                array[alph - 'a']++;
            }

            for(char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch-'a']}");
            }

           for (char ch ='a';ch <= 'z'; ch++) {
                Console.WriteLine($"{ ch}:{ str.Count(c => c == ch)}");
            }


        }
    }
}
