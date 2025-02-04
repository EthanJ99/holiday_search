namespace HotelSearchService;
using DataStructures.Models;

public class HotelSearchService
{
    List<Hotel> hotel_data { get; set; }
    string to { get; } 
    string date { get; }
    int nights { get; }
    public HotelSearchService(List<Hotel> hotel_data, UserSearch user_search){
        this.hotel_data = hotel_data;
        this.to = user_search.to;
        this.date = user_search.date;
        this.nights = user_search.duration;
    }

    public List<Hotel> Filter(){
        /*
        Returns a list of Hotels meeting the input criteria.
        Inputs:
            - to: customer's intended travel destination (i.e. arrival airport)
            - nights: number of nights customer intends to stay at the hotel
            - date: date customer intends to leave on holiday
        Output: List of hotel data (of type Hotel)
        */
        this.hotel_data = [.. hotel_data.Where(x => x.local_airports.Contains(this.to) && x.arrival_date == this.date && x.nights == this.nights)];
        return this.hotel_data;
    }

    public Hotel FindCheapestHotel(){
        /*
        Return the hotel with the cheapest price from a list of Hotel. Calculates based on customer's
        intended duration of stay and the hotel price.

        Implementation note: if there are two items of the same price in the list,
        this method will just return the first (based on their order in the list). A more sophisticated
        search could allow user to choose between the different options
        */
        if (this.hotel_data.Count > 0) {
            return this.hotel_data.OrderBy(x => x.price_per_night * this.nights).First();
        }
        throw new ArgumentException("Hotel data must not be empty.");
    }
}
