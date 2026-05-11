using System;
using System.Collections.Generic;
using System.IO;

namespace SalesCalculator {
    // 売り上げ集計クラス
    public class SalesCounter {

        private readonly IEnumerable<Sale> _sales;

        // コンストラクター
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
        }

        public List<Sale> ReadSales(string filePath) {

            List<Sale> sales = new List<Sale>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines) {

                var items = line.Split(',');

                var sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };

                sales.Add(sale);
            }

            return sales;
        }

        // 店舗別売り上げを求める
        public IDictionary<string, int> GetPerStoreSales() {

            var dict = new SortedDictionary<string, int>();

            foreach (var sale in _sales) {

                if (dict.ContainsKey(sale.ShopName)) {
                    dict[sale.ShopName] += sale.Amount;
                } else {
                    dict[sale.ShopName] = sale.Amount;
                }
            }

            return dict;
        }
    }
}