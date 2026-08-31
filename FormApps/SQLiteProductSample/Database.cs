using Microsoft.Data.Sqlite;

namespace SQLiteProductSample;


public static class Database
{
    //DBファイルの保存場所
    private static readonly string DatabasePath =
        Path.Combine(AppContext.BaseDirectory, "product.db");

    //SQLiteへ接続するための接続文字列
    private static readonly string ConnectionString =
        $"Data Source={DatabasePath}";


    //DBファイルの保存場所を外部から確認するための読み取り専用プロパティ
    public static string FilePath => DatabasePath;


    public static SqliteConnection GetConnection() {
        return new SqliteConnection(ConnectionString);
    }

    //DBの初期化処理
    public static void Initialize() {
        //接続オブジェクトを生成する。
        using var connection = GetConnection();

        //DBを開く
        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText =
        """            
        CREATE TABLE IF NOT EXISTS Product(
           Id       INTEGER PRIMARY KEY AUTOINCREMENT,
           Name     TEXT NOT NULL,
           Price    INTEGER NOT NULL CHECK (Price >= 0)
        


        );
        """;

        //結果行を返さないSQLを実行する
        command.ExecuteNonQuery();
        

        

    }


}
