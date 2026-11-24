using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherApp.Models;

public class WeatherData {
    public double Temperature { get; set; }

    public double Humidity { get; set; }

    public double WindSpeed { get; set; }

    public int WeatherCode { get; set; }

    public List<ForecastDay> Forecasts { get; set; } = new();
}

