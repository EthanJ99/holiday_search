using System.Text.Json;
namespace DataReadService;

public class ReadFlightData : IReadData<Flight>
{
    /*
    Read flight data from a given .json filepath.
    Return: List<Flight> a list of formatted flight data.
     */
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
    /*
        Read hotel data from a given .json filepath.
        Return: List<Hotel> a list of formatted flight data.
     */
        StreamReader file = new StreamReader(filepath);
        string json = file.ReadToEnd();
        file.Close();
        return JsonSerializer.Deserialize<List<Hotel>>(json);
    }
}