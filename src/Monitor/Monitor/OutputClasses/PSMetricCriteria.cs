using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSMetricCriteria : MetricCriteria
    {
        /// <summary>
        /// Initializes a new instance of the PSMetricCriteria class.
        /// </summary>
        /// <param name="metricCriteria">The input MetricCriteria object</param>
        public PSMetricCriteria(MetricCriteria metricCriteria)
            :base(name: metricCriteria.Name, metricName: metricCriteria.MetricName, operatorProperty: metricCriteria.OperatorProperty, timeAggregation: metricCriteria.TimeAggregation, threshold: metricCriteria.Threshold, metricNamespace: metricCriteria.MetricNamespace, dimensions: metricCriteria.Dimensions)
        {
        }
    }
}
