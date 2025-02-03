namespace FlightSearchServiceTests;

using DataReadService;
using FlightSearchService;
using Xunit;

public class FlightSearchServiceTests
{
    [Fact]
    public void FlightSearch_ValidFlightDataListWithNoMatch_ReturnsEmptyList()
    {
        List<Flight> flights = new List<Flight> {
            new Flight { airline = "First Class Air", departure_date = "2023-07-01", from = "MAN", id = 1, price = 470, to = "TFS" },
            new Flight { airline = "Oceanic Airlines", departure_date = "2023-07-01", from = "MAN", id = 2, price = 245, to = "AGP" },
            new Flight { airline = "Trans American Airlines", departure_date = "2023-06-15", from = "MAN", id = 3, price = 170, to = "PMI" }
        };

        var flight_service = new FlightSearchService(flights);
        List<Flight> searched_list = flight_service.FlightSearch(to: "TBA", from: "MAN", date: "2023-07-01");
        Assert.Empty(collection: searched_list);
    }

    [Fact]
    public void FlightSearch_ValidFlightDataList_ReturnsListWithOneEntry()
    {
        List<Flight> flights = new List<Flight> {
            new Flight { airline = "First Class Air", departure_date = "2023-07-01", from = "MAN", id = 1, price = 470, to = "TFS" },
            new Flight { airline = "Oceanic Airlines", departure_date = "2023-07-01", from = "MAN", id = 2, price = 245, to = "AGP" },
            new Flight { airline = "Trans American Airlines", departure_date = "2023-06-15", from = "MAN", id = 3, price = 170, to = "PMI" }
        };

        var flight_service = new FlightSearchService(flights);
        List<Flight> searched_list = flight_service.FlightSearch(to: "TFS", from: "MAN", date: "2023-07-01");
        Assert.Single(collection: searched_list);
        Assert.Equal(expected: flights[0].id, actual: searched_list[0].id);
    }

    [Fact]
    public void FlightSearch_ValidFlightDataList_ReturnsListWithMultipleEntries()
    {
        List<Flight> flights = new List<Flight> {
            new Flight { airline = "First Class Air", departure_date = "2023-07-01", from = "MAN", id = 1, price = 470, to = "TFS" },
            new Flight { airline = "Oceanic Airlines", departure_date = "2023-07-01", from = "MAN", id = 2, price = 245, to = "AGP" },
            new Flight { airline = "Trans American Airlines", departure_date = "2023-06-15", from = "MAN", id = 3, price = 170, to = "PMI" },
            new Flight { airline = "Southern Airlines", departure_date = "2023-07-01", from = "MAN", id = 4, price = 170, to = "TFS" }
        };

        var flight_service = new FlightSearchService(flights);
        List<Flight> searched_list = flight_service.FlightSearch(to: "TFS", from: "MAN", date: "2023-07-01");
        Assert.Equal(expected: 2, actual: searched_list.Count());
        Assert.Equal(expected: flights[0].id, actual: searched_list[0].id);
        Assert.Equal(expected: flights[3].id, actual: searched_list[1].id);
    }

    [Fact]
    public void FindCheapestFlight_ValidFlightData_ReturnsCheapestFlight()
    {
        List<Flight> flights = new List<Flight> {
            new Flight { airline = "First Class Air", departure_date = "2023-07-01", from = "MAN", id = 1, price = 470, to = "TFS" },
            new Flight { airline = "Oceanic Airlines", departure_date = "2023-07-01", from = "MAN", id = 2, price = 245, to = "AGP" },
            new Flight { airline = "Trans American Airlines", departure_date = "2023-06-15", from = "MAN", id = 3, price = 170, to = "PMI" }
        };

        var flight_service = new FlightSearchService(flights);
        Flight cheapest = flight_service.FindCheapestFlight(flights: flights);
        Assert.Equal(flights[2].id, cheapest.id);
    }

    [Fact]
    public void FindCheapestFlight_EmptyFlightData_ThrowsArgumentException()
    {
        List<Flight> flights = new List<Flight> {};

        var flight_service = new FlightSearchService(flights);
        Assert.Throws<ArgumentException>(() => flight_service.FindCheapestFlight(flights));
    }
}
