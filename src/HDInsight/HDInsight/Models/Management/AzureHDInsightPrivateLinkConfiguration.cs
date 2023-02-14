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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Models.Management;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightPrivateLinkConfiguration
    {
        public AzureHDInsightPrivateLinkConfiguration() { }

        public AzureHDInsightPrivateLinkConfiguration(PrivateLinkConfiguration privateLinkConfiguration)
        {
            Id = privateLinkConfiguration.Id;
            Name = privateLinkConfiguration.Name;
            Type = privateLinkConfiguration.Type;
            GroupId = privateLinkConfiguration.GroupId;
            ProvisioningState = privateLinkConfiguration.ProvisioningState;
            IpConfigurations = privateLinkConfiguration.IpConfigurations?.Select(item => new AzureHDInsightIPConfiguration(item)).ToList();
        }

        public PrivateLinkConfiguration ToPrivateLinkConfiguration()
        {
            return new PrivateLinkConfiguration()
            {
                Name = this.Name,
                GroupId = this.GroupId,
                IpConfigurations = this.IpConfigurations.Select(item=> item.ToIPConfiguration()).ToList()
            };
        }

        /// <summary>
        /// The private link configuration id.
        /// </summary>
        public string Id { get; }

        public string Name { get; set; }

        public string Type { get; }

        public string GroupId { get; set; }

        public string ProvisioningState { get; }

        public List<AzureHDInsightIPConfiguration> IpConfigurations { get; set; }
    }
}
