# Holiday Search Program
A program which searches a database of available flights and hotels and returns the best value holiday based on user input.

## File Structure
- Main function is within `/HolidaySearchApplication/HolidaySearchApplication.cs`
  - Hotel and Flight JSON data is stored within the `/data` subfolder here
- Source code is stored in individual folders for each service, e.g. `/DataReadService`
- `/models` contains definitions for new data structures and exceptions
- `/tests` contains XUnit unit tests for each service.
- Functional testing evidence is stored in `Test Evidence.docx`

## Todo
* [x] Refactor FlightSearchService and HotelSearchService to work more according to SOLID principles. The parameters for each search should be stored per-object instead of passing in different values in each method (this would be okay if the methods were called statically, but they aren't!)
* [x] Add additional unit tests (e.g. check hotels with multiple values in the 'local_airports' work fine)
* [x] Make test project names more consistent (HolidaySearch.Tests vs. HotelSearchServiceTests)
* [x] Move data structures into a more general folder so they're easily accessible by other classes
* [x] Add user input processing
* [x] Do functional testing and provide test evidence

## Long term goals & improvements
The following would be ideal if the project were to grow in scope. As the current solution is fairly small/simple it will still work, however it would be best to address these before growing the project further:

* Further refactor the Hotel and Flight search services. They have similar functionality so could be based on a generic Search interface and built out from there. Additionally the 'Filter' method is used in such a way it should probably just be a private/internal method rather than public. This would simplify the unit testing as well as we can just test the main public FindCheapestHotel/Flight method.
* Add validation to user input (e.g. so invalid date formats or data types can't be accidentally typed in)
* Add an 'Any airport' search to allow more broad searches
* Add searches for all airports in a specific city, e.g. London (maybe allow multiple inputs from user?)
* Add further unit testing e.g. for user inputs