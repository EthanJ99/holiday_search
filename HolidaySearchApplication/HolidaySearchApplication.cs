using HolidaySearch.HolidaySearchService;
using HolidaySearch.DataReadService;
using HolidaySearch.DataStructures.Models;
using HolidaySearch.UserInputService;

class HolidaySearchApplication
{
    static void Main(string[] args)
    {   
        // Read Data
        var flight_data = ReadFlightData.ReadData("../../../data/flights.json");
        var hotel_data = ReadHotelData.ReadData("../../../data/hotels.json");

        // Read user input
        var input_service = new UserInputService();
        UserSearch user_search = input_service.GetUserSearch();

        // Set up holiday search
        var holiday_service = new HolidaySearchService(
            flight_data: flight_data,
            hotel_data: hotel_data,
            user_search: user_search
        );

        try {
            Holiday result = holiday_service.FindCheapestHoliday();
            Console.WriteLine(result);
        }
        catch (Exception e) {
            Console.WriteLine($"Error: {e}");
            throw;
        }
        
    }
}