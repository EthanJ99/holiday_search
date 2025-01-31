using System;
using System.Text.Json;
using DataReadService;

namespace DataReadServiceTests;

public class ReadHotelDataTests
{
    [Fact]
    public void ReadJson_ValidJsonFileSingleEntry_ReadsDataSuccessfully()
    {
        List<Hotel> result = ReadHotelData.ReadData("../../../test_data/hotels_single_entry.json");
        
        Assert.True(result.Count == 1);
        Assert.True(result[0].arrival_date == "2022-11-05");
        Assert.True(result[0].id == 1);
        Assert.True(result[0].local_airports[0] == "TFS");
        Assert.True(result[0].name == "Iberostar Grand Portals Nous");
        Assert.True(result[0].nights == 7);
        Assert.True(result[0].price_per_night == 100);
        
    }

    [Fact]
    public void ReadJson_ValidJsonFileMultipleEntries_ReadsDataSuccessfully()
    {
        List<Hotel> result = ReadHotelData.ReadData("../../../test_data/hotels_multiple_entries.json");
        
        Assert.True(result.Count == 2);
        Assert.True(result[0].arrival_date == "2022-11-05");
        Assert.True(result[0].id == 1);
        Assert.True(result[0].local_airports[0] == "TFS");
        Assert.True(result[0].name == "Iberostar Grand Portals Nous");
        Assert.True(result[0].nights == 7);
        Assert.True(result[0].price_per_night == 100);

        Assert.True(result[1].arrival_date == "2022-11-05");
        Assert.True(result[1].id == 2);
        Assert.True(result[1].local_airports[0] == "TFS");
        Assert.True(result[1].name == "Laguna Park 2");
        Assert.True(result[1].nights == 7);
        Assert.True(result[1].price_per_night == 50);
    }

    [Fact]
    public void ReadJson_InvalidJsonFile_ThrowsException()
    {
        Assert.Throws<JsonException>(() => ReadHotelData.ReadData("../../../test_data/hotels_invalid_data.json"));
    }

    [Fact]
    public void ReadJson_FileNotFound_ThrowsException()
    {
        Assert.Throws<FileNotFoundException>(() => ReadHotelData.ReadData("this_file_isnt_real.json"));
    }
}
