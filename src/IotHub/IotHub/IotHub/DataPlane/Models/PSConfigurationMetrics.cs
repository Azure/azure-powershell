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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System;
    using System.Collections;
    using Newtonsoft.Json;

    /// <summary>
    /// Azure IoT Configuration Metrics
    /// </summary>
    public class PSConfigurationMetrics
    {
        /// <summary>
        /// Results of the metrics collection queries
        /// </summary>
        [JsonProperty("results")]
        public Hashtable Results { get; set; }

        /// <summary>
        /// Queries used for metrics collection
        /// </summary>
        [JsonProperty("queries")]
        public Hashtable Queries { get; set; }
    }
}