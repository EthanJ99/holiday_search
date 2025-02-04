namespace HolidaySearch.HotelSearchService.Tests;
using DataStructures.Models;

public class HotelSearchServiceTests
{
    [Fact]
    public void Filter_ValidHotelDataListWithNoMatch_ReturnsEmptyList()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2022-11-05", id = 2, local_airports = ["TFS"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "MAN", date = "2022-01-01", duration = 7}
        );
        List<Hotel> filtered_list = hotel_service.Filter();
        Assert.Empty(filtered_list);
    
    }

    [Fact]
    public void Filter_ValidHotelDataList_ReturnsListWithOneEntry()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2022-11-05", id = 2, local_airports = ["TPR"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "TFS", date = "2022-11-05", duration = 7}
        );
        List<Hotel> filtered_list = hotel_service.Filter();
        Assert.Single(filtered_list);
        Assert.Equal(expected: 1, actual: filtered_list[0].id);
    } 

    [Fact]
    public void Filter_ValidHotelDataListWithMultipleAirports_ReturnsListWithOneEntry()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS", "TXR", "TDA"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2022-11-05", id = 2, local_airports = ["TPR", "LDN"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI", "LGW"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "TFS", date = "2022-11-05", duration = 7}
        );
        List<Hotel> filtered_list = hotel_service.Filter();
        Assert.Single(filtered_list);
        Assert.Equal(expected: 1, actual: filtered_list[0].id);
    } 

    [Fact]
    public void Filter_ValidHotelDataList_ReturnsListWithMultipleEntries()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2023-06-15", id = 2, local_airports = ["PMI"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 7, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "PMI", date = "2023-06-15", duration = 7}
        );
        List<Hotel> filtered_list = hotel_service.Filter();
        Assert.Equal(expected: 2, actual: filtered_list.Count());
        Assert.Equal(expected: 2, actual: filtered_list[0].id);
        Assert.Equal(expected: 3, actual: filtered_list[1].id);
    } 

    [Fact]
    public void FindCheapestHotel_ValidHotelData_ReturnsCheapestHotel()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2023-06-15", id = 2, local_airports = ["PMI"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "PMI", date = "2023-06-15", duration = 7}
        );
        Hotel cheapest = hotel_service.FindCheapestHotel();
        Assert.Equal(hotels[1].id, cheapest.id);
    } 

    [Fact]
    public void FindCheapestHotel_EmptyHotelData_ThrowsArgumentException()
    {
        List<Hotel> hotels = new List<Hotel> {};
        var hotel_service = new HotelSearchService(
            hotel_data: hotels,
            user_search: new UserSearch{to = "PMI", date = "2023-06-15", duration = 7}
        );
        Assert.Throws<ArgumentException>(() => hotel_service.FindCheapestHotel());
    } 
}