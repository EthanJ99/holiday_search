namespace HotelSearchService;
using DataReadService;

public class HotelSearchService
{
    List<Hotel> hotel_data;
    public HotelSearchService(List<Hotel> hotel_data){
        this.hotel_data = hotel_data;
    }
    public List<Hotel> HotelSearch(string to, string date){
        /*
        Returns a list of Hotels meeting the input criteria.
        Inputs:
            - to: customer's intended travel destination (i.e. arrival airport)
            - nights: number of nights customer intends to stay at the hotel
            - date: date customer intends to leave on holiday
        Output: List of hotel data (of type Hotel)
        */
        return [.. hotel_data.Where(x => x.local_airports.Contains(to) && x.arrival_date == date)];
    }

    public Hotel FindCheapestHotel(List<Hotel> hotels, int nights){
        /*
        Return the hotel with the cheapest price from a list of Hotel. Calculates based on customer's
        intended duration of stay and the hotel price.
        Implementation note: if there are two items of the same price in the list,
        this method will just return the first (based on their order in the list). A more sophisticated
        search could allow user to choose between the different options
        */
        if (hotels.Count > 0) {
            return hotels.OrderBy(x => x.price_per_night * nights).First();
        }
        throw new ArgumentException("Hotel data must not be empty.");
    }
}
