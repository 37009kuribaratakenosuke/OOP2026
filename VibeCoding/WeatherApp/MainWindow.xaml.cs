
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e) {
        try {
            WeatherService service = new();

            var weather = await service.GetCurrentWeatherAsync();

            // 現在の天気
            TemperatureText.Text = $"{weather.Temperature} ℃";

            WeatherText.Text =
                GetWeatherDescription(weather.WeatherCode);

            HumidityText.Text = $"湿度：{weather.Humidity} %";

            WindText.Text = $"風速：{weather.WindSpeed} m/s";

            // 週間予報をクリア
            ForecastList.Items.Clear();

            // 7日間予報をカード形式で追加
            foreach (ForecastDay forecast in weather.Forecasts) {
                ForecastList.Items.Add(CreateForecastCard(forecast));
            }
        }
        catch (Exception ex) {
            TemperatureText.Text = "取得失敗";

            MessageBox.Show(
                ex.Message,
                "天気情報の取得エラー",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    // 週間予報カードを作成
    private ListBoxItem CreateForecastCard(ForecastDay forecast) {
        DateTime date;

        bool validDate = DateTime.TryParse(
            forecast.Date.ToString(),
            CultureInfo.CurrentCulture,
            DateTimeStyles.None,
            out date);

        string dateText = validDate
            ? date.ToString("M/d")
            : forecast.Date.ToString();

        string weekdayText = validDate
            ? date.ToString("ddd")
            : "";

        // カード内部
        StackPanel panel = new() {
            Orientation = Orientation.Vertical,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };

        // 日付
        panel.Children.Add(new TextBlock {
            Text = dateText,
            FontSize = 12,
            Foreground = new SolidColorBrush(
                Color.FromRgb(174, 199, 230)),
            HorizontalAlignment = HorizontalAlignment.Center
        });

        // 曜日
        panel.Children.Add(new TextBlock {
            Text = weekdayText,
            FontSize = 12,
            FontWeight = FontWeights.Bold,
            Foreground = Brushes.White,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 2, 0, 3)
        });

        // 天気アイコン
        panel.Children.Add(new TextBlock {
            Text = GetWeatherIcon(forecast.WeatherCode),
            FontSize = 25,
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 2, 0, 4)
        });

        // 最高気温
        panel.Children.Add(new TextBlock {
            Text = $"{forecast.MaxTemperature}°",
            FontSize = 17,
            FontWeight = FontWeights.Bold,
            Foreground = Brushes.White,
            HorizontalAlignment = HorizontalAlignment.Center
        });

        // 最低気温
        panel.Children.Add(new TextBlock {
            Text = $"{forecast.MinTemperature}°",
            FontSize = 13,
            Foreground = new SolidColorBrush(
                Color.FromRgb(137, 164, 204)),
            HorizontalAlignment = HorizontalAlignment.Center
        });

        // 降水確率
        panel.Children.Add(new TextBlock {
            Text = $"☂ {forecast.PrecipitationProbability}%",
            FontSize = 10,
            Foreground = new SolidColorBrush(
                Color.FromRgb(111, 196, 255)),
            HorizontalAlignment = HorizontalAlignment.Center,
            Margin = new Thickness(0, 3, 0, 0)
        });

        // ListBoxItemとして返す
        return new ListBoxItem {
            Content = panel
        };
    }

    // 天気コードからアイコンを取得
    private string GetWeatherIcon(int code) {
        return code switch {
            0 => "☀️",
            1 => "🌤️",
            2 => "⛅",
            3 => "☁️",
            45 or 48 => "🌫️",
            51 or 53 or 55 => "🌦️",
            61 or 63 or 65 => "🌧️",
            71 or 73 or 75 => "❄️",
            80 or 81 or 82 => "🌧️",
            95 or 96 or 99 => "⛈️",
            _ => "❔"
        };
    }

    // 天気コードから説明を取得
    private string GetWeatherDescription(int code) {
        return code switch {
            0 => "☀️ 晴れ",
            1 => "🌤️ ほぼ晴れ",
            2 => "⛅ 一部曇り",
            3 => "☁️ 曇り",
            45 or 48 => "🌫️ 霧",
            51 or 53 or 55 => "🌦️ 霧雨",
            61 or 63 or 65 => "🌧️ 雨",
            71 or 73 or 75 => "❄️ 雪",
            80 or 81 or 82 => "🌧️ にわか雨",
            95 or 96 or 99 => "⛈️ 雷雨",
            _ => $"❔ コード:{code}"
        };
    }
}
