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

using Microsoft.Azure.Commands.Automation.Common;
using System;
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Dsc Node.
    /// </summary>
    public class DscNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscNode"/> class.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="automationAccountName">The automation account.</param>
        /// <param name="node">The dsc node.</param>
        public DscNode(string resourceGroupName, string automationAccountName, AutomationManagement.Models.DscNode node)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("Node", node).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = node.Name;
            this.Id = node.NodeId.ToString("D");
            this.IpAddress = node.Ip;
            this.LastSeen = node.LastSeen.ToLocalTime();
            this.RegistrationTime = node.RegistrationTime.ToLocalTime();
            this.Status = node.Status;
            this.NodeConfigurationName = node.NodeConfiguration.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DscNode"/> class.
        /// </summary>
        public DscNode()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the registration time.
        /// </summary>
        public DateTimeOffset RegistrationTime { get; set; }

        /// <summary>
        /// Gets or sets the last seen time.
        /// </summary>
        public DateTimeOffset LastSeen { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the nodeconfiguration.
        /// </summary>
        public string NodeConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}
