//------------------------------------------------------------------------------
// <copyright file="UsageMetric.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Microsoft.Web.Hosting.Administration
{

    /// <summary>
    /// Class that represents usage activity of the web site.
    /// </summary>
    [DataContract]
    public class UsageMetric
    {
        /// <summary>
        /// Timestamp of the activity
        /// </summary>
        [DataMember]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Number of requests
        /// </summary>
        [DataMember]
        public long Requests { get; set; }

        /// <summary>
        /// Bytes sent
        /// </summary>
        [DataMember]
        public long OutboundBandwidth { get; set; }

        /// <summary>
        /// Bytes received
        /// </summary>
        [DataMember]
        public long InboundBandwidth { get; set; }

        /// <summary>
        /// Processor time in milliseconds
        /// </summary>
        [DataMember]
        public long CpuTime { get; set; }
    }

    /// <summary>
    /// Collection of usage metrics
    /// </summary>
    [CollectionDataContract]
    public class UsageMetrics : List<UsageMetric>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public UsageMetrics() { }

        /// <summary>
        /// Initialize from list
        /// </summary>
        /// <param name="plans"></param>
        public UsageMetrics(List<UsageMetric> usageMetrics) : base(usageMetrics) { }
    }
}
