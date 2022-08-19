using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Verdensuret
{
    internal class TimeZoneManager
    {
        public TimeZone[] AllTimeZones { get; set; }
        public List<TimeZone> ChosenTimeZones { get; set; }

        public TimeZoneManager()
        {
            // This is a hardcoded mess, but there isn't a way to map cities to timezones without
            // using external tools.
            //
            // Ideally, it would be great to have the user input any city in the world and get the
            // time zone from an API. Then I wouldn't need to know the TimeZoneInfo, and could just
            // use DateTime.UtcNow.AddHours(UtcOffset). That would both allow for extremely flexible
            // input, remove the reason to hardcode anything, AND it would account for summertime. :)

            TimeZone Paris = new TimeZone(0, "Paris", "Central Europe Standard Time");
            TimeZone London = new TimeZone(1, "London", "GMT Standard Time");
            TimeZone NewYork = new TimeZone(2, "New York", "Eastern Standard Time");
            TimeZone Perth = new TimeZone(3, "Perth", "W. Australia Standard Time");
            TimeZone Santiago = new TimeZone(4, "Santiago", "Atlantic Standard Time");
            TimeZone SaltLakeCity = new TimeZone(5, "Salt Lake City", "Mountain Standard Time");
            TimeZone Copenhagen = new TimeZone(6, "Copenhagen", "Central Europe Standard Time");

            AllTimeZones = new TimeZone[7]
            {
                Paris,
                London,
                NewYork,
                Perth,
                Santiago,
                SaltLakeCity,
                Copenhagen
            };

            ChosenTimeZones = new List<TimeZone>();
        }

        // Grab the time zones from the list of all times, with the ids that the user has inputted, and store them in the list of time zones to output.
        public void GetTimeZonesToDisplay(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                ChosenTimeZones.Add(AllTimeZones[id[i]]);
            }
        }

        // Prints a list of all available time zones.
        public string PrintAllTimeZones()
        {
            string result = "";

            for (int i = 0; i < AllTimeZones.Length; i++)
            {
                result += AllTimeZones[i].ID + ": " + AllTimeZones[i].City + '\n';
            }

            return result;
        }
    }
}
