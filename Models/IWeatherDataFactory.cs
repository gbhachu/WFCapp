using Newtonsoft.Json.Linq;

namespace WFCapp.Models
{
    public interface IWeatherDataFactory
    {
        JObject GetCityWeatherData(string city);
    }
}