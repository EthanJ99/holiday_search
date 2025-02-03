namespace FlightSearchService;
using DataReadService;

public class FlightSearchService
{
    List<Flight> flight_data;
    public FlightSearchService(List<Flight> flight_data){
        this.flight_data = flight_data;
    }
    public List<Flight> FlightSearch(string to, string from, string date){
        /*
        Returns a list of Flights meeting the input criteria.
        Inputs:
            - to: customer's intended travel destination (i.e. arrival airport)
            - from: customer's departure location/airport
            - date: date customer intends to leave on holiday
        Output: List of flight data (of type Flight)
        */
        return [.. flight_data.Where(x => x.to == to && x.from == from && x.departure_date == date)];
    }

    public Flight FindCheapestFlight(List<Flight> flights){
        /*
        Return the flight with the cheapest price from a list of Flight.

        Implementation note: if there are two items of the same price in the list,
        this method will just return the first (based on their order in the list). A more sophisticated
        search could allow user to choose between the different options
        */
        if (flights.Count > 0) {
            return flights.OrderBy(x => x.price).First();
        }
        throw new ArgumentException("Flight data must not be empty.");
    }
}
