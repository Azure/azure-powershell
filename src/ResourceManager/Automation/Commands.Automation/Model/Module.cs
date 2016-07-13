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

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class Module
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The account name.
        /// </param>
        /// <param name="module">
        /// The Module.
        /// </param>
        public Module(string resourceGroupName, string automationAccountName, Azure.Management.Automation.Models.Module module)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("module", module).NotNull();

            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = module.Name;

            if (module.Properties == null) return;

            this.CreationTime = module.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = module.Properties.LastModifiedTime.ToLocalTime();
            this.IsGlobal = module.Properties.IsGlobal;
            this.Version = module.Properties.Version;
            this.ProvisioningState = module.Properties.ProvisioningState.ToString();
            this.ActivityCount = module.Properties.ActivityCount;
            this.SizeInBytes = module.Properties.SizeInBytes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        public Module()
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
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IsGlobal.
        /// </summary>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the SizeInBytes.
        /// </summary>
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the ActivityCount.
        /// </summary>
        public int ActivityCount { get; set; }

        /// <summary>
        /// Gets or sets the CreationTime.
        /// </summary>
        public DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the LastPublishTime.
        /// </summary>
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the ProvisioningState.
        /// </summary>
        public string ProvisioningState { get; set; }
    }
}
