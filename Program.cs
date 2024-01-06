using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputString = "20230911 asd2324234jghjsd hjsdg sdhk 01072024 idf32432 32423 d34234jh dfh";
        
        // Define the regular expression pattern for MMDDYYYY format
        string pattern = @"\b(\d{2})(\d{2})(\d{4})\b";
        
        // Use Regex to find matches in the input string
        MatchCollection matches = Regex.Matches(inputString, pattern);

        // Iterate through matches and print valid dates
        foreach (Match match in matches)
        {
            int month = int.Parse(match.Groups[1].Value);
            int day = int.Parse(match.Groups[2].Value);
            int year = int.Parse(match.Groups[3].Value);

            if (IsValidDate(month, day, year))
            {
                string formattedDate = $"{month:D2}{day:D2}{year:D4}";
                Console.WriteLine("Valid Date Found: " + formattedDate);
            }
        }
    }

    // Function to check if the date is valid
    static bool IsValidDate(int month, int day, int year)
    {
        try
        {
            DateTime date = new DateTime(year, month, day);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
    }
}
