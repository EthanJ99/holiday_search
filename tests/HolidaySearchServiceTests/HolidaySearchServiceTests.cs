namespace HolidaySearch.Tests;

using HolidaySearch.HolidaySearchService;
using HolidaySearch.DataReadService;
using HolidaySearch.DataStructures.Models;

using Xunit;

public class HolidaySearchServiceTests
{
    [Fact]
    public void HolidaySearchTest_ValidUserInput_FindsCheapestHoliday()
    {
        var flight_data = ReadFlightData.ReadData("../../../test_data/flights.json");
        var hotel_data = ReadHotelData.ReadData("../../../test_data/hotels.json");
        var user_search = new UserSearch{from = "MAN", to = "AGP", date = "2023-07-01", duration = 7};

        var holiday_service = new HolidaySearchService(flight_data: flight_data, hotel_data: hotel_data, user_search: user_search);
        Holiday result = holiday_service.FindCheapestHoliday();
        Assert.Equal(expected: 2, actual: result.flight.id);
        Assert.Equal(expected: 9, actual: result.hotel.id);
    }
}
