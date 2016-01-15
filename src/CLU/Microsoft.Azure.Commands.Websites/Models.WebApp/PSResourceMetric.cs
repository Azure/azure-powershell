// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Resources;

namespace Microsoft.Azure.Commands.Websites.Models.WebApp
{
    public class PSResourceMetric
    {
        public static implicit operator PSResourceMetric(ResourceMetric metric)
        {
            return metric == null ? null : new PSResourceMetric(metric);
        }

        public PSResourceMetric()
        {
        }

        protected PSResourceMetric(ResourceMetric metric)
        {
            EndTime = metric.EndTime;
            MetricValues = metric.MetricValues;
            Name = metric.Name;
            Properties = metric.Properties;
            ResourceId = metric.ResourceId;
            StartTime = metric.StartTime;
            TimeGrain = metric.TimeGrain;
            Unit = metric.Unit;
        }

        /// <summary>
        /// Name of metric
        /// </summary>
        public ResourceMetricName Name { get; set; }

        [JsonIgnore]
        public string NameText { get { return Name.SerializeJson(); } }

        /// <summary>
        /// Metric unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Metric granularity. E.g PT1H, PT5M, P1D
        /// </summary>
        public string TimeGrain { get; set; }

        /// <summary>
        /// Metric start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Metric end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Metric resource Id
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Metric values
        /// </summary>
        public IList<ResourceMetricValue> MetricValues { get; set; }

        [JsonIgnore]
        public string MetricValuesText {  get { return MetricValues.SerializeJsonCollection(); } }

        /// <summary>
        /// Properties
        /// </summary>
        public IList<KeyValuePairStringString> Properties { get; set; }

        [JsonIgnore]
        public string PropertiesText {
            get { return MetricValues.SerializeJsonCollection(); }
        }
    }
}
