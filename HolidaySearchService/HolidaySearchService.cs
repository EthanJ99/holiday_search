namespace HolidaySearch.HolidaySearchService;

using System.Collections.Generic;
using HolidaySearch.FlightSearchService;
using HolidaySearch.HotelSearchService;
using HolidaySearch.DataStructures.Models;
using HolidaySearch.Exceptions;

public class HolidaySearchService {
    List<Flight> flight_data;
    List<Hotel> hotel_data;
    UserSearch user_search;

    public HolidaySearchService(List<Flight> flight_data, List<Hotel> hotel_data, UserSearch user_search){
        this.flight_data = flight_data;
        this.hotel_data = hotel_data;
        this.user_search = user_search;
    }
    
    public Holiday FindCheapestHoliday(){
        // Search Flights using user criteria
        FlightSearchService flight_service = new FlightSearchService(
            flight_data: this.flight_data,
            user_search: this.user_search
        );

        // Search Hotels using user criteria
        HotelSearchService hotel_service = new HotelSearchService(
            hotel_data: this.hotel_data,
            user_search: this.user_search
        );

        // Filter results based on user search
        flight_service.Filter();
        hotel_service.Filter();

        try {
            // Check cheapest flight & hotel
            Flight cheapest_flight = flight_service.FindCheapestFlight();
            Hotel cheapest_hotel = hotel_service.FindCheapestHotel();

            // Return final selection
            float total_price = cheapest_flight.price + (cheapest_hotel.price_per_night * cheapest_hotel.nights);
            return new Holiday {
                flight = cheapest_flight,
                hotel = cheapest_hotel,
                total_price = total_price
            };
        } catch(Exception) {
            throw new MissingDataException();
        }
    }
}