using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            List<DateTime> holidays = new List<DateTime>();
            if(weekEnds != null)
            {
                foreach (WeekEnd weekend in weekEnds)
                {
                    for (DateTime date = weekend.StartDate; date <= weekend.EndDate; date = date.AddDays(1))
                    {
                        holidays.Add(date);
                    }
                }
            }

            DateTime endDate = startDate;
            while (dayCount != 0)
            {
                if (!holidays.Contains(endDate))
                {
                    dayCount--;
                }
                endDate = dayCount == 0 ? endDate : endDate.AddDays(1);
            }
            return endDate;
        }
    }
}
