using System.Text.Json;
namespace DataReadService;

public class ReadFlightData : IReadData<Flight>
{
    public static List<Flight> ReadData(string filepath) {
        StreamReader file = new StreamReader(filepath);
        string json = file.ReadToEnd();
        file.Close();
        return JsonSerializer.Deserialize<List<Flight>>(json);
    }
}

public class ReadHotelData : IReadData<Hotel>
{
    public static List<Hotel> ReadData(string filepath) {
        StreamReader file = new StreamReader(filepath);
        string json = file.ReadToEnd();
        file.Close();
        return JsonSerializer.Deserialize<List<Hotel>>(json);
    }
}