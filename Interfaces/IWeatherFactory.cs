using Newtonsoft.Json.Linq;

namespace WFCapp.Interfaces
{
    public interface IWeatherFactory
    {
        JObject GetWeather(string city);
    }
}
