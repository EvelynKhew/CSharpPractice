using System;
using System.Threading;

namespace userBirthday
{

    /**
     * Lookup the System.DateTime structure.  This type contains a large amount of functionality that allows a user to perform all sorts 
     * of interesting operations with dates and times.  Use System.DateTime along with System.Console to implement a simple C# program that 
     * does the following:
     * Ask the user for their birthday.  It will probably easiest to ask year, then month, then day rather than parsing a combined string 
     * reliably.
     * Calculate the age of the user.
     * Check to see if the age of the user is impossible.  For example, if the user is not yet born, output an error message.  
     * If the user claims to be 135 years old, then let them know that's not possible.
     * Output the age of the user to the console.
     * If it is the user's birthday, output a nice message.
     * Compute the user's astrological sign according to both the Western (sun sign) and Chinese astrological systems.  
     * If you are not familiar with these astrological systems, look them up on the web.
     * Output the computed signs to the console.  Optionally output additional information (e.g. horoscope of the day) about the user 
     * based on their sign.
    **/

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to your personal birthday calculator! To start, please enter your birth year:");

            string bYear = Console.ReadLine();
            Console.WriteLine($"Cool! So your birth year is {bYear}, huh? Let's see...");
            Thread.Sleep(1000);
            Console.WriteLine("Okay, now, enter your birth month in numerics, January being 1 and December being 12, please.");
            string bMonth = Console.ReadLine();
            Console.WriteLine($"Okay, so you're born in {bMonth}. Cool, cool. Hmm....");

            DateTime today = DateTime.Now;
            Console.WriteLine(today.ToString());

            
        }
    }
}
