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
using Microsoft.Azure.Commands.Automation.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Sets (updates) a Runtime Environment for automation.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationRuntimeEnvironment", DefaultParameterSetName = AutomationCmdletParameterSets.ByName, SupportsShouldProcess = true)]
    [OutputType(typeof(RuntimeEnvironment))]
    public class SetAzureAutomationRuntimeEnvironment : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the runtime environment name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The runtime environment name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

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

            if (ShouldProcess(this.Name, "Update Runtime Environment"))
            {
                var updatedRuntimeEnvironment = this.AutomationClient.UpdateRuntimeEnvironment(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Name,
                    defaultPackagesDict,
                    this.Description,
                    tagsDict);

                this.WriteObject(updatedRuntimeEnvironment);
            }
        }
    }
}
