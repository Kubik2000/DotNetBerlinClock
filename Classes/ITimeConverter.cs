using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public interface ITimeConverter
    {
        String convertTime(String aTime);
        /*
        void calculateHours(string hours);
        string calculateHoursRow(int number, int parametricInt, out int outNumber);
        void calculateMinutes(string minutes);
        string calculateMinutesRow(int number, int parametricInt, out int outNumber);
        void calculateSeconds(string seconds);
         */
    }
}
