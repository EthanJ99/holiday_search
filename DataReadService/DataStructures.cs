using System;

namespace DataReadService;

public class Flight
{
    public int id { get; set; }
    public string airline { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public int price { get; set; }
    public string departure_date { get; set; }
}

public class Hotel
{
    public int id { get; set; }
    public string name { get; set; }
    public string arrival_date { get; set; }
    public int price_per_night { get; set; }
    public List<string> local_airports { get; set; }
    public int nights { get; set; }
}