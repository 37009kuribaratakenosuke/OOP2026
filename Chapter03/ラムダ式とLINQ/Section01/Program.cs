namespace Section01 {
    internal class Program {

       
        
        static void Main(string[] args) {

            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var exists = cities.Exists(s => s[0] == 'A');
            Console.WriteLine(exists);

        }

      


    }
}
