namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：splitで分けてname,subject,scoreをリストに追加している
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (string line in lines) {

                var items = line.Split(',');

                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };

                sales.Add(student);
            }

            return sales;
        }

        //メソッドの概要：学生の点数を求めている   
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();

            foreach (var sale in _score) {

                if (dict.ContainsKey(sale.Name)) {
                    dict[sale.Name] += sale.Score;
                } else {
                    dict[sale.Name] = sale.Score;
                }
            }

            return dict;
        }
    }
}
