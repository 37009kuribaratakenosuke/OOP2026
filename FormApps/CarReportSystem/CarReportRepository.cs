using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class CarReportRepository {
        public List<CarReport> GetAll() {

            var carReports = new List<CarReport>();
            using var connection = Database.GetConnection();

            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText =
            """            
        SELECT Id,Date,Author,Maker,CarName,Report,Picture
        FROM CarReports
        ORDER BY Id;
        """;

            //SELECTを実行し、複数行の検索結果を読み取る
            using var reader = command.ExecuteReader();

            while (reader.Read()) {
                carReports.Add(new CarReport {
                    Id = reader.GetInt32(0),
                    Date = DateTime.ParseExact(
                        reader.GetString(1),
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture),
                    Author =  reader.GetString(2),
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                    CarName = reader.GetString(4),
                    Report = reader.GetString(5),
                    Picture = null
                });
            }
            return carReports;



        }
        public int Add(DateTime date, string author, CarReport.MakerGroup maker, string carName, string report, Image? picture) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
            """
        INSERT INTO CarReports
        (Date,Author,Maker,CarName,Report,Picture)
        VALUES
        ($date,$author,$maker,$carName,$report,$picture);

        SELECT last_insert_rowid();
        """;

            command.Parameters.AddWithValue("$date", date);
            command.Parameters.AddWithValue("$author", author);
            command.Parameters.AddWithValue("$maker", (int)maker);
            command.Parameters.AddWithValue("$carName", carName);
            command.Parameters.AddWithValue("$report", report);
            command.Parameters.AddWithValue("$picture", picture);

            var result = command.ExecuteScalar();

            if (result is null) {
                throw new InvalidOperationException("登録したレポートのIDを取得できませんでした。");
            }


            return Convert.ToInt32((long)result);



        }

        public void Update(CarReport carReport) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
            """
        UPDATE CarReports
        SET Date = $date, Author = $author, Maker = $maker, CarName = $carName,
            Report = $report, Picture = $picture
        WHERE Id = $Id;
        """;

            command.Parameters.AddWithValue("$date", carReport.Date);
            command.Parameters.AddWithValue("$author", carReport.Author);
            command.Parameters.AddWithValue("$maker", (int)carReport.Maker);
            command.Parameters.AddWithValue("$carName", carReport.CarName);
            command.Parameters.AddWithValue("$report", carReport.Report);
            command.Parameters.AddWithValue("$picture", carReport.Picture);
            command.Parameters.AddWithValue("$Id", carReport.Id);

            var result = command.ExecuteNonQuery();

            if (result == 0) {
                throw new InvalidOperationException("修正対象のレポートが見つかりませんでした。");
            }




        }


        public void Delete(int id) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
            """
        DELETE FROM CarReports
        WHERE Id =$id;
        """;

            command.Parameters.AddWithValue("$id", id);


            var result = command.ExecuteNonQuery();

            if (result == 0) {
                throw new InvalidOperationException("削除対象のレポートが見つかりませんでした。");
            }
        }

    }
}
