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

using Microsoft.Azure.Management.SqlVirtualMachine.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Availability Group Listener. It mirrors the .NET client object
    /// Microsoft.Azure.Management.SqlVirtualMachine.Models.SqlVirtualMachineGroup
    /// </summary>
    public class AzureAvailabilityGroupListenerModel
    {
        public AzureAvailabilityGroupListenerModel(string resourceGroupName, string groupName)
        {
            this.ResourceGroupName = resourceGroupName;
            this.GroupName = groupName;
        }

        /// <summary>
        /// Gets or sets the name of the resource group the Availability Group Listener is in
        /// </summary>
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; }

        /// <summary>
        /// Gets or sets the name of the SQL VM Group the Availability Group Listener is in
        /// </summary>
        [Ps1Xml(Label = "GroupName", Target = ViewControl.Table, Position = 2)]
        public string GroupName { get; }

        /// <summary>
        /// Gets or sets the name of the Availability Group Listener
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Availability Group Listener
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Provisioning State of the Listener
        /// </summary>
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Name of the Availability Group
        /// </summary>
        public string AvailabilityGroupName { get; set; }

        /// <summary>
        /// List of load balancer configurations for an availability group listener.
        /// </summary>
        public IList<LoadBalancerConfiguration> LoadBalancerConfigurations { get; set; }

        /// <summary>
        /// Listener port.
        /// </summary>
        public int? Port { get; set; }
    }
}
