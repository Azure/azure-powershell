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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Runtime Environment model for Azure Automation.
    /// </summary>
    public class RuntimeEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeEnvironment"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param>
        /// <param name="runtimeEnvironment">
        /// The Runtime Environment.
        /// </param>
        public RuntimeEnvironment(string resourceGroupName, string automationAccountName, Azure.Management.Automation.Models.RuntimeEnvironment runtimeEnvironment)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("runtimeEnvironment", runtimeEnvironment).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = runtimeEnvironment.Name;
            this.Location = runtimeEnvironment.Location;
            this.Description = runtimeEnvironment.Description;

            if (runtimeEnvironment.Runtime != null)
            {
                this.Language = runtimeEnvironment.Runtime.Language;
                this.Version = runtimeEnvironment.Runtime.Version;
            }

            if (runtimeEnvironment.DefaultPackages != null)
            {
                this.DefaultPackages = new Dictionary<string, string>(runtimeEnvironment.DefaultPackages);
            }

            if (runtimeEnvironment.SystemData != null)
            {
                this.CreatedAt = runtimeEnvironment.SystemData.CreatedAt;
                this.LastModifiedAt = runtimeEnvironment.SystemData.LastModifiedAt;
            }

            if (runtimeEnvironment.Tags != null)
            {
                this.Tags = new Dictionary<string, string>(runtimeEnvironment.Tags);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeEnvironment"/> class.
        /// </summary>
        public RuntimeEnvironment()
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
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the language (e.g., PowerShell, Python).
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the version (e.g., 7.4, 7.2, 5.1).
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the default packages.
        /// </summary>
        public IDictionary<string, string> DefaultPackages { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset? LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }
    }
}
