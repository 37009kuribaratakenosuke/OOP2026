
namespace Section04 {
    internal class Program {
        static void Main(string[] args) {


            #region nullの判定
            string? name = null;

            if (name is not null)
                Console.WriteLine("nameはnullです");

            #endregion

            //GetMwssage()メソッドの戻り値がnullだったら、
            //DefaultMessage()メソッドが実行される
            #region null合体演算子
            string code = "12345";
            var message = GetMessage(code) ?? DefaultMessage();
            Console.WriteLine(message);

            #endregion

            #region null合体代入演算子
            message = null;
            message ??= DefaultMessage();


            #endregion


            #region null条件演算子
            Sale? sale = new Sale {
                ShopName = "新宿店",
                ProductCategory = "洋菓子",
                Amount = 523100,
            };

            int? amount = sale?.Amount;
            Console.WriteLine("売上高:" + amount);
            #endregion

            #region 2つの要素を入れ替える
            int a = 10;
            int b = 20;
            int c = 30;

            Console.Write("入れ替え前:");
            Console.WriteLine("a =" + a + "b = " + b);

            (b, a) = (a, b);
                #endregion
        }

        private static string? DefaultMessage() {
            return "DefaultMessage";
        }

        private static string? GetMessage(string code) {
            return null;
        }


        // 売り上げクラス
        public class Sale {
            // 店舗名
            public string ShopName { get; set; } = string.Empty;

            // 商品カテゴリー
            public string ProductCategory { get; set; } = string.Empty;

            // 売上高
            public int Amount { get; set; }
        }
    }
}



