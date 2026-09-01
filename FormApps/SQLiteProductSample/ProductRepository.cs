using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Xml.Linq;

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
    public int Add(string name,int price) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
        """
        INSERT INTO Product (Name,Price)
        VALUES($name,$price);

        SELECT last_insert_rowid();
        """;

        command.Parameters.AddWithValue("$name",name);
        command.Parameters.AddWithValue("$price" ,price);

        var result = command.ExecuteScalar();

        if (result is null) {
            throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");
        }
            

        return Convert.ToInt32((long)result);

        

    }

    public void Update(Product product) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
        """
        UPDATE Product
        SET Name = $name,
            Price = $price
        WHERE Id = $Id;
        """;

        command.Parameters.AddWithValue("$name", product.Name);
        command.Parameters.AddWithValue("$price", product.Price);
        command.Parameters.AddWithValue("$Id", product.Id);

        var result = command.ExecuteNonQuery();

        if (result == 0) {
            throw new InvalidOperationException("修正対象の商品が見つかりませんでした。");
        }


        

    }


    public void Delete(int id) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
        """
        DELETE FROM Product
        WHERE Id =$id;
        """;

        command.Parameters.AddWithValue("$id", id);
        

        var result = command.ExecuteNonQuery();

        if (result == 0) {
            throw new InvalidOperationException("削除対象の商品が見つかりませんでした。");
        }
    }

}
