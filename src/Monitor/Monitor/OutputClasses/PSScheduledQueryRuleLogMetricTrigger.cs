using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSScheduledQueryRuleLogMetricTrigger : ScheduledQueryRuleLogMetricTrigger
    {
        public PSScheduledQueryRuleLogMetricTrigger(Microsoft.Azure.Management.Monitor.Models.LogMetricTrigger metricTrigger)
            : base(metricTrigger: metricTrigger)
        { }
    }
}
