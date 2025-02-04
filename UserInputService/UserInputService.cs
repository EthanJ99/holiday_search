namespace HolidaySearch.UserInputService;

using HolidaySearch.DataStructures.Models;

public class UserInputService
{
    public UserSearch GetUserSearch(){
        UserSearch user_search = new UserSearch();

        try {
            // Get user input
            Console.Write("Enter departure location: ");
            user_search.from = Console.ReadLine();

            Console.Write("Enter destination: ");
            user_search.to = Console.ReadLine();

            Console.Write("Enter date (in format e.g. YYYY-MM-DD e.g. 2025-02-04): ");
            user_search.date = Console.ReadLine();

            Console.Write("Enter duration (in days): ");
            user_search.duration = int.Parse(Console.ReadLine());

            return user_search;
        } catch (Exception) {
            Console.WriteLine($"Error reading user input. Please try again.");
            return GetUserSearch();
        }
    }
}
