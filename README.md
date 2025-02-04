# Holiday Search Program
A program which searches a database of available flights and hotels and returns the best value holiday based on user parameters.

## Todo
* [x] Refactor FlightSearchService and HotelSearchService to work more according to SOLID principles. The parameters for each search should be stored per-object instead of passing in different values in each method (this would be okay if the methods were called statically, but they aren't!)
* [x] Add additional unit tests (e.g. check hotels with multiple values in the 'local_airports' work fine)
* [x] Make test project names more consistent (HolidaySearch.Tests vs. HotelSearchServiceTests)
* [x] Move data structures into a more general folder so they're easily accessible by other classes
* [ ] Add user input processing
* [ ] Do functional testing and provide test evidence

## Long term goals (no particular order)
* [ ] Add an 'Any airport' search
* [ ] Add searches for all airports in a specific city, e.g. London (maybe allow multiple inputs from user?)