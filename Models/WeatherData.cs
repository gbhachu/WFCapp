using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WFCapp.Models
{
    public class WeatherData : IWeatherDataFactory
    {
        public DateTime? Date { get; set; }
        public string WeatherState { get; set; }
        public string WeatherStateIcon { get; set; }

        public string City => "Belfast";

        public object Api { get; private set; }

        public JObject GetCityWeatherData(string city)
        {
            using var webClient = new WebClient();
            try
            {
                var metaWeatherCityDetails =
                    webClient.DownloadData($"{API.MetaWeatherApiFindCityUrl}{City}");

                var cityDetails = JArray.Parse(Encoding.ASCII.GetString(metaWeatherCityDetails));

                var metaWeatherCityWoeId = cityDetails[0]["woeid"].ToString();

                var downloadedCityWeatherData =
                    webClient.DownloadData($"{API.MetaWeatherApiFindWoeIdUrl}{metaWeatherCityWoeId}");

                return JObject.Parse(Encoding.ASCII.GetString(downloadedCityWeatherData));
            }
            catch (Exception ex)
            {
                throw new Exception($"MetaWeather did not return any results for {City} : {ex.Message} ");
            }
        }

    
}
}
