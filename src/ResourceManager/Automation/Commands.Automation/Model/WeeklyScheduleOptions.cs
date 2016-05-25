using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class WeeklyScheduleOptions
    {
        /// <summary>
        /// Gets or sets the schedule days of the week.
        /// </summary>
        public IList<string> DaysOfWeek { get; set; }
    }
}
