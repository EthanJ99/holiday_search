using System.Text.Json;
namespace DataReadService;

public class ReadFlightData : IReadData<FlightList>
{
    public FlightList readJson(string filepath) {
        return JsonSerializer.Deserialize<FlightList>(filepath);
    }
}

public class ReadHotelData : IReadData<HotelList>
{
    public HotelList readJson(string filepath) {
        return JsonSerializer.Deserialize<HotelList>(filepath);
    }
}