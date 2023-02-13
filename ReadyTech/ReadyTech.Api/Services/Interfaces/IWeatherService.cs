using ReadyTech.Api.Models;

namespace ReadyTech.Api.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<Weather> GetTemperatureFromCoordinates(string latitude, string longitude);
    }
}
