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
using System.Collections;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Microsoft.Azure.Management.Automation;

    /// <summary>
    /// The Configuration.
    /// </summary>
    public class DscConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DscConfiguration"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account.
        /// </param>
        /// <param name="configuration">
        /// The configuration script.
        /// </param>
        public DscConfiguration(string resourceGroupName, string automationAccountName, AutomationManagement.Models.DscConfiguration configuration)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("Configuration", configuration).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = configuration.Name;
            this.Location = configuration.Location;
            this.Tags = null;

            if (configuration.Properties == null) return;

            this.CreationTime = configuration.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = configuration.Properties.LastModifiedTime.ToLocalTime();
            this.Description = configuration.Properties.Description;
            this.LogVerbose = configuration.Properties.LogVerbose;
            this.State = configuration.Properties.State;
            this.JobCount = configuration.Properties.JobCount;

            this.Parameters = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in configuration.Properties.Parameters)
            {
                this.Parameters.Add(kvp.Key, (object)kvp.Value);
            }    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DscConfiguration"/> class.
        /// </summary>
        public DscConfiguration()
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
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets the JobCount.
        /// </summary>
        public int JobCount { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public Hashtable Parameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether log verbose is enabled.
        /// </summary>
        public bool LogVerbose { get; set; }
    }
}
