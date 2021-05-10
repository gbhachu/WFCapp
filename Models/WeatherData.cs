using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using WFCapp.Interfaces;

namespace WFCapp.Models
{
    public class WeatherData : IWeatherFactory
    {
        public DateTime? Date { get; set; }
        public string WeatherState { get; set; }
        public string WeatherStateIcon { get; set; }

        public JObject GetWeather(string city)
        {
            using var webClient = new WebClient();
            try
            {
                var metaWeatherCityDetails =
                    webClient.DownloadData($"{Api.MetaWeatherApiFindCityUrl}{city}");

                var cityDetails = JArray.Parse(Encoding.ASCII.GetString(metaWeatherCityDetails));

                var metaWeatherCityWoeId = cityDetails[0]["woeid"].ToString();

                var downloadedCityWeatherData =
                    webClient.DownloadData($"{Api.MetaWeatherApiFindWoeIdUrl}{metaWeatherCityWoeId}");

                return JObject.Parse(Encoding.ASCII.GetString(downloadedCityWeatherData));
            }
            catch (Exception ex)
            {
                throw new Exception($"Api call did not return data {city} : {ex.Message} ");
            }
        }

    }
}
