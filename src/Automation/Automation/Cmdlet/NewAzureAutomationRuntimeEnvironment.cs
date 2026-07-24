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

using Microsoft.Azure.Commands.Automation.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Runtime Environment for automation.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationRuntimeEnvironment", SupportsShouldProcess = true)]
    [OutputType(typeof(RuntimeEnvironment))]
    public class NewAzureAutomationRuntimeEnvironment : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runtime environment name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runtime environment name. Must begin with a letter, contain only letters, numbers, underscores and dashes, and be less than 64 characters.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure region for the runtime environment. If not specified, uses the Automation Account location.")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The language of the runtime environment. Valid values are 'PowerShell' or 'Python'.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("PowerShell", "Python")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The version of the language. For PowerShell: '7.6', '7.4', '7.2', '5.1'. For Python: '3.10', '3.8'.")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the default packages.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The default packages for the runtime environment as a hashtable of package name to version (e.g., @{'Az'='12.3.0'}).")]
        public Hashtable DefaultPackages { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The description of the runtime environment.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource tags for the runtime environment as a hashtable (e.g., @{'Environment'='Production'; 'Team'='DevOps'}).")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            // Validate name format
            if (!Regex.IsMatch(this.Name, "^[a-zA-Z][a-zA-Z0-9_-]{0,62}$"))
            {
                throw new PSArgumentException(
                    "The name can contain only letters, numbers, underscores and dashes. The name must begin with a letter. The name must be less than 64 characters.",
                    nameof(Name));
            }

            IDictionary<string, string> defaultPackagesDict = null;
            if (this.DefaultPackages != null)
            {
                defaultPackagesDict = this.DefaultPackages.Cast<DictionaryEntry>()
                    .ToDictionary(d => d.Key.ToString(), d => d.Value?.ToString());
            }

            IDictionary<string, string> tagsDict = null;
            if (this.Tag != null)
            {
                tagsDict = this.Tag.Cast<DictionaryEntry>()
                    .ToDictionary(d => d.Key.ToString(), d => d.Value?.ToString());
            }

            if (ShouldProcess(this.Name, "Create Runtime Environment"))
            {
                var createdRuntimeEnvironment = this.AutomationClient.CreateRuntimeEnvironment(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Name,
                    this.Location,
                    this.Language,
                    this.Version,
                    defaultPackagesDict,
                    this.Description,
                    tagsDict);

                this.WriteObject(createdRuntimeEnvironment);
            }
        }
    }
}
