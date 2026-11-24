using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models;

public class ForecastDay {
    public string Date { get; set; } = "";

    public double MaxTemperature { get; set; }

    public double MinTemperature { get; set; }

    public int WeatherCode { get; set; }

    public int PrecipitationProbability { get; set; }
}
