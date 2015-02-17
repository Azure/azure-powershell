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

using System.Collections;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class Module
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="Module">
        /// The Module.
        /// </param>
        public Module(string automationAccountName, WindowsAzure.Management.Automation.Models.Module module)
        {
            Requires.Argument("module", module).NotNull();
            this.AutomationAccountName = automationAccountName;
            this.Name = module.Name;
            this.Location = module.Location;
            this.Tags = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in module.Tags)
            {
                this.Tags.Add(kvp.Key, kvp.Value);
            }

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
        /// Gets or sets the automaiton account name.
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
        /// Gets or sets the tags.
        /// </summary>
        public Hashtable Tags { get; set; }

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

    public class ContentLink
    {
        /// <summary>
        /// Gets or sets the Uri.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the Content hash.
        /// </summary>
        public ContentHash ContentHash { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version { get; set; }
    }

    public class ContentHash
    {
        /// <summary>
        /// Gets or sets the Algorithm.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        public string Value { get; set; }
    }
}
