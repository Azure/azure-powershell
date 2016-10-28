﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{

    public class PSWindowsPerformanceCounterDataSourceProperties : PSDataSourcePropertiesBase
    {
        [JsonIgnore]
        public override string Kind { get { return PSDataSourceKinds.WindowsPerformanceCounter; } }

        [JsonProperty(PropertyName= "objectName")]
        public string ObjectName { get; set; }

        [JsonProperty(PropertyName = "instanceName")]
        public string InstanceName { get; set; }

        [JsonProperty(PropertyName = "intervalSeconds")]
        public int IntervalSeconds { get; set; }

        [JsonProperty(PropertyName = "counterName")]
        public string CounterName { get; set; }

        /// <summary>
        /// Whether to collect syslog from Linux computers.
        /// </summary>
        [JsonProperty(PropertyName = "collectorType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectorType CollectorType { get; set; }
    }

    /// <summary>
    /// The type of the Collector.
    /// </summary>
    public enum CollectorType
    {
        /// <summary>
        /// Default collector, meaning <LegacyCollector>false</LegacyCollector>.
        /// </summary>
        Default,

        /// <summary>
        /// The LegacyCollector, meaning <LegacyCollector>true</LegacyCollector>.
        /// </summary>
        Legacy
    }
}
