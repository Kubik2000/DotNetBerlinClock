using BerlinClock.Classes;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        #region fields
        Clock clock = new Clock();
        const string constY = "Y";
        const string constO = "O";
        const string constR = "R";
        #endregion

        #region constructors
        #endregion

        #region properties
        #endregion

        #region methods
        public string convertTime(string aTime)
        {
            string[] aTimeParts = aTime.Split(':');
            calculateHours(aTimeParts[0]);
            calculateMinutes(aTimeParts[1]);
            calculateSeconds(aTimeParts[2]);
            return ToString();
        }
        private void calculateHours(string hours)
        {
            int number;
            if (int.TryParse(hours, out number))
            {
                int outNumber = 0;
                if (number > 4)
                {
                    clock.SecondRow_hours = calculateHoursRow(number, 5, out outNumber);
                }
                clock.ThirdRow_hours = calculateHoursRow(outNumber, 1, out number);
            }
            else { throw new NotANumberException(); }
        }
        private string calculateHoursRow(int number, int parametricInt, out int outNumber)
        {
            string result = "";
            int counter = 0;
            for (int i = 1; i <= 4; i++)
            {
                if (number - parametricInt * i >= 0)
                {
                    result += constR;
                    counter++;
                }
                else { result += constO; }
            }
            outNumber = number - counter * parametricInt;
            return result;
        }
        private void calculateMinutes(string minutes)
        {
            int number;
            if (int.TryParse(minutes, out number))
            {
                int outNumber = 0;
                if (number > 4)
                {
                    clock.ForthRow_minutes = calculateMinutesRow(number, 5, out outNumber);
                }
                clock.FifthRow_minutes = calculateMinutesRow(outNumber, 1, out number);
            }
            else { throw new NotANumberException(); }
        }
        private string calculateMinutesRow(int number, int parametricInt, out int outNumber)
        {
            string result = "";
            int counter = 0;

            int forParameter = 4;
            if (parametricInt == 5) { forParameter = 11; }

            for (int i = 1; i <= forParameter; i++)
            {
                if (number - parametricInt * i >= 0)
                {
                    counter++;
                    if (counter % 3 == 0 & forParameter == 11) { result += constR; }
                    else { result += constY; }
                }
                else { result += constO; }
            }
            outNumber = number - counter * parametricInt;
            return result;
        }
        private void calculateSeconds(string seconds)
        {
            int number;
            if (int.TryParse(seconds, out number))
            {
                if (number % 2 == 1) { clock.FirstRow_seconds = constO; }
                else { clock.FirstRow_seconds = constY; }
            }
            else { throw new NotANumberException(); }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\"\"\"");
            builder.AppendLine(clock.FirstRow_seconds);
            builder.AppendLine(clock.SecondRow_hours);
            builder.AppendLine(clock.ThirdRow_hours);
            builder.AppendLine(clock.ForthRow_minutes);
            builder.AppendLine(clock.FifthRow_minutes);
            builder.AppendLine("\"\"\"");
            return builder.ToString();
        }
        #endregion
    }
}
