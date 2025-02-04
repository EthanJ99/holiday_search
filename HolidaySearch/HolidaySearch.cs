﻿namespace HolidaySearchService;

using System.Collections.Generic;
using System.Linq;
using System;
using DataReadService;
using FlightSearchService;
using HotelSearchService;
using System.Diagnostics;

public class HolidaySearchService {
    private List<Flight> flight_data;
    private List<Hotel> hotel_data;
    UserSearch user_search;

    public HolidaySearchService(List<Flight> flight_data, List<Hotel> hotel_data, UserSearch user_search){
        this.flight_data = flight_data;
        this.hotel_data = hotel_data;
        this.user_search = user_search;
    }
    
    public Holiday FindCheapestHoliday(){
        // Get user input (done in test)
        // Read Data (done in test)
    
        // Search Flights using user criteria
        FlightSearchService flight_service = new FlightSearchService(
            flight_data: this.flight_data
        );

        var filtered_flights = flight_service.FlightSearch(
            from: this.user_search.from,
            to: this.user_search.to,
            date: this.user_search.date
        );

        // Search Hotels using user criteria
        HotelSearchService hotel_service = new HotelSearchService(
            hotel_data: this.hotel_data
        );

        var filtered_hotels = hotel_service.HotelSearch(
            to: this.user_search.to,
            date: this.user_search.date
        );

        // Check cheapest flight & hotel
        Flight cheapest_flight = flight_service.FindCheapestFlight(filtered_flights);
        Hotel cheapest_hotel = hotel_service.FindCheapestHotel(hotels: filtered_hotels, nights: user_search.duration);

        // Return final selection
        float total_price = cheapest_flight.price + (cheapest_hotel.price_per_night * cheapest_hotel.nights);
        return new Holiday {
            flight = cheapest_flight,
            hotel = cheapest_hotel,
            total_price = total_price
        };
    }
}