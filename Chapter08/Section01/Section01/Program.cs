namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> preOfficeDict = new Dictionary<string, string>();
        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了:Ctrl + 'Z'】");

            while (true) {
                //都道府県の入力   
                Console.Write("都道府県:");
                pref = Console.ReadLine();
                

                if (pref == null) break; //無限ループを抜ける(Ctrl + 'Z')

                //県庁所在地の入力  
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                Console.WriteLine();

                if (prefCaptalLocation == null) break;

                //県庁所在地登録処理 

                preOfficeDict[pref] = prefCaptalLocation;

            }
            Menu();
        }

                static void Menu() {
                    while (true) {
                        Console.WriteLine();
                        Console.WriteLine("**** メニュー ****");
                        Console.WriteLine("1: 一覧表示");
                        Console.WriteLine("2: 検索");
                        Console.WriteLine("9: 終了");
                        Console.Write("選択:");

                        string? menu = Console.ReadLine();

                        switch (menu) {
                            case "1":
                                foreach (var item in preOfficeDict) {
                                    Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です");
                                }
                                break;

                            case "2":
                                Console.Write("都道府県 :");
                                string? pref = Console.ReadLine();

                                if (pref != null && preOfficeDict.ContainsKey(pref)) {
                                    Console.WriteLine($"県庁所在地: {preOfficeDict[pref]}");
                                } 
                                break;

                            case "9":
                                Console.WriteLine("終了");
                                return;

                        }

                    }
                }

        //private static int menuDisp() {
        //    Console.WriteLine();
        //    Console.WriteLine("**** メニュー ****");
        //    Console.WriteLine("1: 一覧表示");
        //    Console.WriteLine("2: 検索");
        //    Console.WriteLine("9: 終了");
        //    Console.Write(">");

        //    return  
        //}

    }
        }
  