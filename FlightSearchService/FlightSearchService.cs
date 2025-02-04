namespace HolidaySearch.FlightSearchService;

using HolidaySearch.DataStructures.Models;

public class FlightSearchService
{
    List<Flight> flight_data {get; set;}
    string destination {get;}
    string origin {get;}
    string date {get;}

    public FlightSearchService(List<Flight> flight_data, UserSearch user_search){
        this.flight_data = flight_data;
        this.destination = user_search.to;
        this.origin = user_search.from;
        this.date = user_search.date;
    }

    public List<Flight> Filter(){
        /*
        Returns a list of Flights meeting the input criteria.
        Inputs:
            - to: customer's intended travel destination (i.e. arrival airport)
            - from: customer's departure location/airport
            - date: date customer intends to leave on holiday
        Output: List of flight data (of type Flight)
        */
        this.flight_data = [.. flight_data.Where(x => 
            x.to == this.destination && 
            x.from == this.origin && 
            x.departure_date == this.date
            )
        ];
        return this.flight_data;
    }

    public Flight FindCheapestFlight(){
        /*
        Return the flight with the cheapest price from a list of Flight.

        Implementation note: if there are two items of the same price in the list,
        this method will just return the first (based on their order in the list). A more sophisticated
        search could allow user to choose between the different options
        */
        // var filtered_search = this.Filter();
        if (flight_data.Count() > 0) {
            return flight_data.OrderBy(x => x.price).First();
        }
        throw new ArgumentException("Flight data must not be empty.");
    }
}
