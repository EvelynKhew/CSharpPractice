using System;
using System.Threading;

namespace userBirthday
{

   /**Exercise 1 from: www1.cs.columbia.ecu/~lok/csharp/assignments.html
    * Takes in user's birthday and calculates the age of the user. Outputs a nice message if it is the birthday of user. 
    * Computers user's Western and Chinese astrological sign and outputs to console. 
    * Optional (unimplemented): Horoscope of the day. 
    * 
    * @author: Evelyn Khew
    */

    class Program
    {
        //method used to calculate western zodiac
        private String westZodiac(int mth, int date) {
            if ((mth == 3 && date >= 21) || (mth == 4 && date <= 19))
                return "Aries";
            else if ((mth == 4 && date >= 20) || (mth == 5 && date <= 20))
                return "Taurus";
            else if ((mth == 5 && date >= 21) || (mth == 6 && date <= 20))
                return "Gemini";
            else if ((mth == 6 && date >= 21) || (mth == 7 && date <= 22))
                return "Cancer";
            else if ((mth == 7 && date >= 23) || (mth == 8 && date <= 22))
                return "Leo";
            else if ((mth == 8 && date >= 23) || (mth == 9 && date <= 22))
                return "Virgo";
            else if ((mth == 9 && date >= 23) || (mth == 10 && date <= 22))
                return "Libra";
            else if ((mth == 10 && date >= 23) || (mth == 11 && date <= 21))
                return "Scorpio";
            else if ((mth == 11 && date >= 22) || (mth == 12 && date <= 21))
                return "Sagittarius";
            else if ((mth == 12 && date >= 22) || (mth == 1 && date <= 19))
                return "Capricorn";
            else if ((mth == 1 && date >= 20) || (mth == 2 && date <= 18))
                return "Aquarius";
            else if ((mth == 2 && date >= 19) || (mth == 3 && date <= 20))
                return "Pisces";
            else
                return null;
        }

        /** method used to calculate a rough estimate of the Chinese Zodiac. Does not take actual birth date into consideration. 
         * E.G.: if you were born before CNY in 2020, i.e. Jan 25, 2020, you would still be considered a Rat, even though technically you're a Pig. 
         * Unfortunate, but I have yet to figure out a way to do it properly :(
         */
        private string cnZodiac(int year) {
            //starting with Monkey because the Monkey years are divisible by 12.
            string[] zodiacAnimals = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Snake", "Horse", "Sheep" };

            return zodiacAnimals[year % 12];
        }

        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            int curYear = today.Year;
            int curMonth = today.Month;
            int curDay = today.Day;
            int uAge = 0;
            string wZodiac = "<western zodiac unimplemented yet>";
            string cZodiac = "<chinese zodiac unimplemented yet>";

            //getting user birth year
            Console.WriteLine("Hello! Welcome to your personal birthday calculator! To start, please enter your birth year:");
            string sYear = null;
            int iYear= 0;
            while (true){
                while (true){
                    sYear = Console.ReadLine();
                    bool wrongYearInput = false;
                    if (!int.TryParse(sYear, out iYear)){
                        Console.WriteLine("I would really appreciate it if you gave me a single number for your birthyear, please...");
                        wrongYearInput = true;
                    }
                    else if (iYear < 1){
                        Console.WriteLine($"Excuse me, sir! There are no negative numbers in years, and {iYear} clearly is one!");
                        wrongYearInput = true;
                    }
                    if (wrongYearInput == false) { break; }

                }

                Console.WriteLine($"Cool! So your birth year is {iYear}, huh? Let's see...");
                uAge = curYear - iYear;

                //for flavour purposes. I'm trying to make it seem like the console is thinking
                Thread.Sleep(3000);
                if (uAge < 0 || uAge > 120){
                    Console.WriteLine($"Wait, hold on just a minute!! If you were born in the year {iYear}, then that means you would be {uAge} years old!");
                    Console.WriteLine("That's not possible, unless if you're not a human! Please just give me a real birthyear!!");
                }
                else {
                    break; 
                }

            }

            //getting user birth month
            Console.WriteLine("Okay, now, enter your birth month in numerics, January being 1 and December being 12, please.");
            string sMonth = null;
            int iMonth = 0;
            while (true){
                sMonth = Console.ReadLine();
                if (!int.TryParse(sMonth, out iMonth)) {
                    Console.WriteLine($"I'm sorry, but uh, {sMonth} doesn't look like a number to me, man. Try again?");
                }
                else if(iMonth < 1 || iMonth > 12) {
                    Console.WriteLine($"Okay but like I said, January is supposed to be 1 and December is supposed to be 12. Does {iMonth} look like its between 1 and 12? Geez...");
                }
                else {
                    DateTime temp = new DateTime(iYear, iMonth, 3);
                    sMonth = temp.ToString("MMMM");
                    break;
                }
            }
            Console.WriteLine($"Okay, so you're born in {sMonth}. Cool, cool. Hmm....");

            //getting user birth date.
            Console.WriteLine("One last thing, and you won't have to do anything anymore. I promise. What date were you born on?");
            int daysInMonth = System.DateTime.DaysInMonth(iYear, iMonth); 
            string sDate = null;
            int iDate = 0;
            while (true) {
                sDate = Console.ReadLine();

                if (!int.TryParse(sDate, out iDate)) {
                    Console.WriteLine($"{sDate} is not a valid date. Please try again.");
                }
                else if (iDate < 1 || iDate > daysInMonth) {
                    Console.WriteLine("That must have been a mistake, try again?");
                }
                else { 
                    break; }
            }
            if (iMonth == today.Month && iDate == today.Day)
                Console.WriteLine("Oh, its your birthday today! Happy birthday!! :D \nHave lots and lots of cake for me, okay?");

            if ((iMonth > today.Month) || (iMonth == today.Month && iDate > today.Day)) {
                uAge--;
                if ((iMonth == today.Month && (iDate == today.Day + 1)))
                    Console.WriteLine("Oh, your birthday is tomorrow! Happy birthday in advance!! I hope you have a good one this year!");
            }

            Console.WriteLine($"Okay, so I've determined that you're currently {uAge}. How nice!");

            Program p = new Program();
            wZodiac = p.westZodiac(iMonth, iDate);
            cZodiac = p.cnZodiac(iYear);

            Console.WriteLine($"You're a {wZodiac} (according to the western zodiac), and a {cZodiac} (according to the eastern, specifically Chinese Zodiac). Huh. Good to know.");
            
        }

    }
}
