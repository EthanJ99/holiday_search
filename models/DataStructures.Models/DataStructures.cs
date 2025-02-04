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
        return "id: " + id + " airline: " + airline + " from: " + from + " to:" + to + " price:" + price + " departure_date:" + departure_date;
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
        string output_str = "id: " + id + " name: " + name + " arrival_date: " + arrival_date + " price_per_night" + price_per_night + " nights" + nights;
        for (int i = 0; i < local_airports.Count; i++)
        {
            output_str = output_str + " " + i;
        }
        return output_str;
    } 
}

public class Holiday {
    public float total_price { get; set; }
    public Hotel hotel { get; set; }
    public Flight flight { get; set; }
}

public class UserSearch {
    public string from { get; set; }
    public string to { get; set; }
    public string date { get; set; }
    public int duration { get; set; }
}