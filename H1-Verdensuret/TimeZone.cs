using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Verdensuret
{
    internal class TimeZone
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string TimeZoneName { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }

        public TimeZone(int id, string city, string timeZoneName)
        {
            ID = id;
            City = city;
            TimeZoneName = timeZoneName;
            TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneName);
        }

        // ToString() outputs the cities name and current time, with the time aligned so that multiple time zones will have the clocks displayed neatly stacked.
        public override string ToString()
        {
            return String.Format("Time in {0,-15} {1,10}", City + ':', TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo).ToLongTimeString());
        }
    }
}
