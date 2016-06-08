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

namespace Microsoft.Azure.Commands.Automation.Model
{
    using Microsoft.Azure.Commands.Automation.Common;
    using System;
    using AutomationManagement = Microsoft.Azure.Management.Automation;

    /// <summary>
    /// The Dsc Node configuration
    /// </summary>
    public class NodeConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscNodeConfiguration"/> class.
        /// </summary>
        /// <param name="accountName">
        /// The account name.
        /// </param>
        /// <param name="nodeConfiguration">
        /// The NodeConfiguration.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public NodeConfiguration(string resourceGroupName, string accountName, AutomationManagement.Models.DscNodeConfiguration nodeConfiguration, string rollUpStatus)
        {
            Requires.Argument("nodeConfiguration", nodeConfiguration).NotNull();
            Requires.Argument("accountName", accountName).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = accountName;

            this.Name = nodeConfiguration.Name;
            this.CreationTime = nodeConfiguration.CreationTime.ToLocalTime();
            this.LastModifiedTime = nodeConfiguration.LastModifiedTime.ToLocalTime();
            this.RollupStatus = rollUpStatus;
            if (nodeConfiguration.Configuration != null)
            {
                this.ConfigurationName = nodeConfiguration.Configuration.Name;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeConfiguration"/> class.
        /// </summary>
        public NodeConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the node configuration name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time of the job.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the rollup status.
        /// </summary>
        public string RollupStatus { get; set; }
    }
}
