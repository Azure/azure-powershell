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
    /// The configuration content.
    /// </summary>
    public class ConfigurationContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationContent"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="accountName">
        /// The account name.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <param name="slot">
        /// Slot published or draft.
        /// </param>
        public ConfigurationContent(string resourceGroupName, string accountName, AutomationManagement.Models.DscConfiguration configuration, string content, string slot)
        {
            Requires.Argument("configuration", configuration).NotNull();
            Requires.Argument("accountName", accountName).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("slot", slot).NotNull();

            this.AutomationAccountName = accountName;
            this.Name = configuration.Name;
            this.Content = content;

            if (configuration.Properties == null) return;

            this.CreationTime = configuration.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = configuration.Properties.LastModifiedTime.ToLocalTime();
            this.Slot = slot;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationContent"/> class.
        /// </summary>
        public ConfigurationContent()
        {
        }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the slot (publised or draft) of runbook.
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the configuration script content.
        /// </summary>
        public string Content { get; set; }
    }
}
