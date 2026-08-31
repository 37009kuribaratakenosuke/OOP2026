using Microsoft.Data.Sqlite;

namespace SQLiteProductSample;

//Productテーブルに対するDB操作をまとめたクラス
//CRUD (Create / Read / Update
public class ProductRepository
{
    public List <Product> GetAll() {

        var products = new List<Product>();
        using var connection = Database.GetConnection();

        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
        """            
        SELECT Id,Name,Price
        FROM Product
        ORDER BY Id;
        """;

        //SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()){
            products.Add(new Product {
                 Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetInt32(2)
            });
        }
        return products;

    }
}
