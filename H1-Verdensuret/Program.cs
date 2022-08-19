using System;
using System.Collections.Generic;
using System.Threading;

namespace H1_Verdensuret
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeZoneManager tzm = new TimeZoneManager();

            // Get timezones to display

            bool errorFound; // If error is found in input, this will be set to true and user has to input again
            int[] ids;

            do
            {
                errorFound = false; // errorFound is always false until userinput has been received and checked.

                Console.Clear();

                if (errorFound == true) // If user input was bad, encourage them to use correct input.
                {
                    Console.WriteLine("FEJL: Indtast venligst kun gyldige id'er, adskilt af mellemrum.");
                }

                Console.WriteLine("Indtast ID på alle de tidszoner du vil se, adskilt med mellemrum.");
                Console.WriteLine(tzm.PrintAllTimeZones()); // List all currently available timezones.

                string chosenTimeZones = Console.ReadLine(); // Read user choices.
                string[] stringIds = chosenTimeZones.Split(" "); // Split users choices into a string array.
                ids = new int[stringIds.Length]; // Array to store the int values of what the user inputted.

                // Check if each id is actually valid
                for (int i = 0; i < ids.Length; i++)
                {
                    int idToCheck; // Store id temporarily while checking if it is valid
                    if (int.TryParse(stringIds[i], out idToCheck) == true) // Can this entry be read as a number?
                    {
                        if (idToCheck < 0 || idToCheck > tzm.AllTimeZones.Length) // Does this entry correspond to a valid id?
                        {
                            errorFound = true; // Entry was a number, but not a valid ID
                        }
                        else
                        {
                            ids[i] = idToCheck; // Entry corresponded to valid id - add to array of ids
                        }
                    }
                    else
                    {
                        errorFound = true; // Entry was not a number
                    }
                }
            } while (errorFound); // Only continue running if an error was found.

            tzm.GetTimeZonesToDisplay(ids); // The time zone manager will find out which time zones to display.

            Console.Clear(); // Clear the console, preparing it to display time zones.

            // Display time

            ConsoleKeyInfo cki;

            do
            {
                while (Console.KeyAvailable == false) // Check if a key is being pressed
                {
                    Console.SetCursorPosition(0, 0); // Overwrite previous text by writing from the top left corner again.
                                                     // The jumping cursor is less distracting than the blinking of Console.Clear() in my opinion.
                    
                    foreach (TimeZone t in tzm.ChosenTimeZones)
                    {
                        Console.WriteLine(t.ToString()); // Write the timezone
                    }

                    Thread.Sleep(1000); // Wait one full second before updating the display.
                }

                // When a keypress is detected, stop the program if the key pressed was escape.
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
