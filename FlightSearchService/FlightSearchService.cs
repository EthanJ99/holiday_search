namespace FlightSearchService;

using DataReadService;

public class FlightSearchService
{
    List<Flight> flight_data;
    string destination;
    string origin;
    string date;
    public FlightSearchService(List<Flight> flight_data, UserSearch user_search){
        this.flight_data = flight_data;
        this.destination = user_search.to;
        this.origin = user_search.from;
        this.date = user_search.date;
    }
    private List<Flight> Filter(){
        /*
        Returns a list of Flights meeting the input criteria.
        Inputs:
            - to: customer's intended travel destination (i.e. arrival airport)
            - from: customer's departure location/airport
            - date: date customer intends to leave on holiday
        Output: List of flight data (of type Flight)
        */
        return [.. flight_data.Where(x => 
            x.to == this.destination && 
            x.from == this.origin && 
            x.departure_date == this.date
            )
        ];
    }

    public Flight FindCheapestFlight(){
        /*
        Return the flight with the cheapest price from a list of Flight.

        Implementation note: if there are two items of the same price in the list,
        this method will just return the first (based on their order in the list). A more sophisticated
        search could allow user to choose between the different options
        */
        var filtered_search = this.Filter();
        if (filtered_search.Count() > 0) {
            return filtered_search.OrderBy(x => x.price).First();
        }
        throw new ArgumentException("Flight data must not be empty.");
    }
}
