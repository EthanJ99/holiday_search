namespace HolidaySearch.DataStructures.Models;

public class Flight
{
    public int id { get; set; }
    public string airline { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public int price { get; set; }
    public string departure_date { get; set; }

    public override string ToString(){
        return $"Flight ID: {id}\n" +
            $"Airline: {airline}\n" +
            $"From: {from}\n" +
            $"To: {to}\n" +
            $"Price: £{price}\n" +
            $"Departure Date: {departure_date}";
    }
}

public class Hotel
{
    public int id { get; set; }
    public string name { get; set; }
    public string arrival_date { get; set; }
    public int price_per_night { get; set; }
    public List<string> local_airports { get; set; }
    public int nights { get; set; }

    public override string ToString(){
        return $"Hotel ID: {id}\n" +
               $"Name: {name}\n" +
               $"Arrival Date: {arrival_date}\n" +
               $"Price per Night: £{price_per_night}\n" +
               $"Nights: {nights}\n" +
               $"Local Airports: {string.Join(", ", local_airports)}";
    } 
}

public class Holiday {
    public float total_price { get; set; }
    public Hotel hotel { get; set; }
    public Flight flight { get; set; }

    public override string ToString(){
        return $"[Total Price]: £{total_price}\n\n" +
               $"[Hotel Details]:\n{hotel}\n\n" +
               $"[Flight Details]:\n{flight}";
    }
}

public class UserSearch {
    public string from { get; set; }
    public string to { get; set; }
    public string date { get; set; }
    public int duration { get; set; }
}