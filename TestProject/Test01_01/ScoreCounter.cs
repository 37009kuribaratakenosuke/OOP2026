namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        // CSVを読み込む
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (string line in lines) {
                var items = line.Split(',');

                if (items.Length != 3)
                    continue;

                if (!int.TryParse(items[2], out int score))
                    continue;

                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = score
                };

                students.Add(student);
            }

            return students;
        }

        // 学生ごとの合計点を求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();

            foreach (var student in _score) {
                if (dict.ContainsKey(student.Name)) {
                    dict[student.Name] += student.Score;
                } else {
                    dict[student.Name] = student.Score;
                }
            }

            return dict;
        }
    }
}