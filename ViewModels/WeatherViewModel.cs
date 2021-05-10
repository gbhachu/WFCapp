using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WFCapp.Models;

namespace WFCapp.ViewModels
{
    public class WeatherViewModel
    {
        public List<WeatherData> WeatherRecords { get; set; }

        public WeatherViewModel()
        {
            WeatherRecords = new List<WeatherData>();
        }

        //ConvertApiDataToWeatherRecords
        public WeatherViewModel(JObject jObject)
        {
            WeatherRecords = new List<WeatherData>();
            var consolidatedWeather = JArray.Parse(jObject["consolidated_weather"].ToString());

            for (var i = 0; i < consolidatedWeather.Count - 1; i++)
            {
                WeatherRecords.Add(new WeatherData
                {
                    Date = DateTime.Parse(consolidatedWeather[i]["applicable_date"].ToString()),
                    WeatherState = consolidatedWeather[i]["weather_state_name"].ToString(),
                    WeatherStateIcon = consolidatedWeather[i]["weather_state_abbr"].ToString()
                });
            }
        }
    }
}

