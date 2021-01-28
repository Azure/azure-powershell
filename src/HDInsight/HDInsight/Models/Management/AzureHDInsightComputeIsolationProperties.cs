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

using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightComputeIsolationProperties
    {
        public AzureHDInsightComputeIsolationProperties() { }

        public AzureHDInsightComputeIsolationProperties(bool? enableComputeIsolation = null, string hostSku = null)
        {
            EnableComputeIsolation = enableComputeIsolation;
            HostSku = hostSku;
        }

        public AzureHDInsightComputeIsolationProperties(ComputeIsolationProperties computeIsolationProperties = null)
        {
            EnableComputeIsolation = computeIsolationProperties?.EnableComputeIsolation;
            HostSku = computeIsolationProperties?.HostSku;
        }

        /// <summary>
        /// Gets or sets the direction for the resource provider connection. Possible values include: 'Inbound', 'Outbound'
        /// </summary>
        public bool? EnableComputeIsolation { get; set; }

        /// <summary>
        /// Gets or sets indicates whether or not private link is enabled. Possible values include: 'Disabled', 'Enabled'
        /// </summary>
        public string HostSku { get; set; }
    }
}
