namespace HotelSearchServiceTests;
using HotelSearchService;
using DataReadService;
using System.Globalization;

public class HotelSearchServiceTests
{
    [Fact]
    public void FlightSearch_ValidFlightDataListWithNoMatch_ReturnsEmptyList()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2022-11-05", id = 2, local_airports = ["TFS"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(hotel_data: hotels);
        List<Hotel> searched_list = hotel_service.HotelSearch(to: "MAN", date: "2022-01-01");
        Assert.Empty(searched_list);
    
    }

    [Fact]
    public void FlightSearch_ValidFlightDataList_ReturnsListWithOneEntry()
    {
        
    }

    [Fact]
    public void FlightSearch_ValidFlightDataList_ReturnsListWithMultipleEntries()
    {
        Assert.True(false);
    }

    [Fact]
    public void FindCheapestFlight_ValidFlightData_ReturnsCheapestFlight()
    {
        Assert.True(false);
    }

    [Fact]
    public void FindCheapestFlight_EmptyFlightData_ThrowsArgumentException()
    {
        Assert.True(false);
    }
}
