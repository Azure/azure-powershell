using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class UpdatePSTableParameters : OperationalInsightsParametersBase
    {
        public string TableName { get; set; }
        //public bool? IsTroubleshootEnabled { get; set; }//in the next API version i.e 2020-10-01
        public int? RetentionInDays { get; set; }

    }
}
