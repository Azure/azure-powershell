//
// Copyright (c) Microsoft.  All rights reserved.
//

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Legacy.Models;

namespace Microsoft.Azure.Insights.Legacy.Customizations.Shoebox
{
    /// <summary>
    /// Generic interface for retrieving various types of metrics
    /// </summary>
    internal interface IMetricRetriever
    {
        Task<MetricListResponse> GetMetricsAsync(string resourceId, string filterString, IEnumerable<MetricDefinition> definitions, string invocationId);
    }
}
