using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class DayOfWeek
    {
        /// <summary>
        /// Gets or sets the schedule day of the week occurrence.
        /// </summary>
        public string Occurrence { get; set; }

        /// <summary>
        /// Gets or sets the schedule day of the week.
        /// </summary>
        public string Day { get; set; }

    }
}
