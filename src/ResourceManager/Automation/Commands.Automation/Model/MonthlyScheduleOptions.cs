using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Automation.Cmdlet;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class MonthlyScheduleOptions
    {
        /// <summary>
        /// Gets or sets the schedule days of the month.
        /// </summary>
        public IList<DaysOfMonth> DaysOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the day of week.
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }
    }
}
