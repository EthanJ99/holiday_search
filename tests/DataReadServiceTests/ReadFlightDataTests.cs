using System.Text.Json;
using DataStructures.Models;

namespace DataReadService.Tests;

public class ReadFlightDataTests
{
    [Fact]
    public void ReadJson_ValidJsonFileSingleEntry_ReadsDataSuccessfully()
    {
        List<Flight> result = ReadFlightData.ReadData("../../../test_data/flights_single_entry.json");
        
        Assert.True(result.Count == 1);
        Assert.True(result[0].airline == "First Class Air");
        Assert.True(result[0].departure_date == "2023-07-01");
        Assert.True(result[0].from == "MAN");
        Assert.True(result[0].id ==  1);
        Assert.True(result[0].price ==  470);
        Assert.True(result[0].to == "TFS");
        
    }

    [Fact]
    public void ReadJson_ValidJsonFileMultipleEntries_ReadsDataSuccessfully()
    {
        List<Flight> result = ReadFlightData.ReadData("../../../test_data/flights_multiple_entries.json");
        Assert.True(result.Count == 2);
        Assert.True(result[0].airline == "First Class Air");
        Assert.True(result[0].departure_date == "2023-07-01");
        Assert.True(result[0].from == "MAN");
        Assert.True(result[0].id ==  1);
        Assert.True(result[0].price ==  470);
        Assert.True(result[0].to == "TFS");
        Assert.True(result[1].airline == "Oceanic Airlines");
        Assert.True(result[1].departure_date == "2023-07-01");
        Assert.True(result[1].from == "MAN");
        Assert.True(result[1].id ==  2);
        Assert.True(result[1].price ==  245);
        Assert.True(result[1].to == "AGP");
    }

    [Fact]
    public void ReadJson_InvalidJsonFile_ThrowsException()
    {
        Assert.Throws<JsonException>(() => ReadFlightData.ReadData("../../../test_data/flights_invalid_data.json"));
    }

    [Fact]
    public void ReadJson_FileNotFound_ThrowsException()
    {
        Assert.Throws<FileNotFoundException>(() => ReadFlightData.ReadData("this_file_isnt_real.json"));
    }
}
