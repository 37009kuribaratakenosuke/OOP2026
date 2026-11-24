using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;

public class WeatherService {
    private readonly HttpClient _httpClient = new();

    public async Task<WeatherData> GetCurrentWeatherAsync() {
        string url =
            "https://api.open-meteo.com/v1/forecast" +
            "?latitude=35.6764" +
            "&longitude=139.6500" +
            "&current=temperature_2m,relative_humidity_2m,wind_speed_10m,weather_code" +
            "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
            "&forecast_days=7";

        string json = await _httpClient.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(json);

        var current = doc.RootElement.GetProperty("current");
        var daily = doc.RootElement.GetProperty("daily");

        double temperature =
            current.GetProperty("temperature_2m").GetDouble();

        double humidity =
            current.GetProperty("relative_humidity_2m").GetDouble();

        double windSpeed =
            current.GetProperty("wind_speed_10m").GetDouble();

        int weatherCode =
            current.GetProperty("weather_code").GetInt32();

        List<ForecastDay> forecasts = new();

        var dates = daily.GetProperty("time");
        var weatherCodes = daily.GetProperty("weather_code");
        var maxTemps = daily.GetProperty("temperature_2m_max");
        var minTemps = daily.GetProperty("temperature_2m_min");
        var precipitationProbs =
            daily.GetProperty("precipitation_probability_max");

        for (int i = 0; i < dates.GetArrayLength(); i++) {
            forecasts.Add(new ForecastDay {
                Date = dates[i].GetString() ?? "",
                WeatherCode = weatherCodes[i].GetInt32(),
                MaxTemperature = maxTemps[i].GetDouble(),
                MinTemperature = minTemps[i].GetDouble(),
                PrecipitationProbability = precipitationProbs[i].GetInt32()
            });
        }

        return new WeatherData {
            Temperature = temperature,
            Humidity = humidity,
            WindSpeed = windSpeed,
            WeatherCode = weatherCode,
            Forecasts = forecasts
        };
    }
}