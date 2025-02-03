﻿namespace HotelSearchServiceTests;
using HotelSearchService;
using DataReadService;
using System.Globalization;

public class HotelSearchServiceTests
{
    [Fact]
    public void HotelSearch_ValidHotelDataListWithNoMatch_ReturnsEmptyList()
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
    public void HotelSearch_ValidHotelDataList_ReturnsListWithOneEntry()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2022-11-05", id = 2, local_airports = ["TFS"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(hotel_data: hotels);
        List<Hotel> searched_list = hotel_service.HotelSearch(to: "PMI", date: "2023-06-15");
        Assert.Single(searched_list);
        Assert.Equal(expected: 3, actual: searched_list[0].id);
    }

    [Fact]
    public void HotelSearch_ValidHotelDataList_ReturnsListWithMultipleEntries()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2023-06-15", id = 2, local_airports = ["PMI"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(hotel_data: hotels);
        List<Hotel> searched_list = hotel_service.HotelSearch(to: "PMI", date: "2023-06-15");
        Assert.Equal(expected: 2, actual: searched_list.Count());
        Assert.Equal(expected: 2, actual: searched_list[0].id);
        Assert.Equal(expected: 3, actual: searched_list[1].id);
    }

    [Fact]
    public void FindCheapestHotel_ValidHotelData_ReturnsCheapestHotel()
    {
        List<Hotel> hotels = new List<Hotel> {
            new Hotel{ arrival_date = "2022-11-05", id = 1, local_airports = ["TFS"], name = "Iberostar Grand Portals Nous", nights = 7, price_per_night = 100},
            new Hotel{ arrival_date = "2023-06-15", id = 2, local_airports = ["PMI"], name = "Laguna Park 2", nights = 7, price_per_night = 50},
            new Hotel{ arrival_date = "2023-06-15", id = 3, local_airports = ["PMI"], name = "Sol Katmandu Park & Resort", nights = 14, price_per_night = 59},
        };

        var hotel_service = new HotelSearchService(hotels);
        Hotel cheapest = hotel_service.FindCheapestHotel(hotels: hotels, nights: 7);
        Assert.Equal(hotels[1].id, cheapest.id);
    }

    [Fact]
    public void FindCheapestHotel_EmptyHotelData_ThrowsArgumentException()
    {
        List<Hotel> hotels = new List<Hotel> {};
        var hotel_service = new HotelSearchService(hotels);
        Assert.Throws<ArgumentException>(() => hotel_service.FindCheapestHotel(hotels: hotels, nights: 7));
    }
}