namespace HolidaySearch.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var holiday_search = new HolidaySearch();
        Assert.True(holiday_search.give_one() == 1);
    }
}
