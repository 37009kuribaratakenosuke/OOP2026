
using Exercise01;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // 5.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2024, 12),
            };

           

            Console.WriteLine("5.2.2");
            Exercise2(ymCollection);

            Console.WriteLine("5.2.4");
            Exercise4(ymCollection);


            Console.WriteLine("5.2.5");
            Exercise5(ymCollection);
        }

        private static void Exercise2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine($"{ym.Year}/{ym.Month}");
            }
        }

        private static YearMonth? Exercise4(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                if (ym.Year >= 2001 && ym.Year <= 2100) {
                    return ym;
                }
            }
            return null;
        }

        private static void Exercise5(YearMonth[] ymCollection) {
            
        }
    }
}
