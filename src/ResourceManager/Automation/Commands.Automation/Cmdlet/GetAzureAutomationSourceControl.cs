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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation source controls for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSourceControl",
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(SourceControl))]
    public class GetAzureAutomationSourceControl : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the variable source control.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true,
                   ValueFromPipelineByPropertyName = true, HelpMessage = "The source control name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the source control SourceType.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, HelpMessage = "The source control type.")]
        [ValidateSet(Constants.SupportedSourceType.GitHub,
                     Constants.SupportedSourceType.VsoGit,
                     Constants.SupportedSourceType.VsoTfvc, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string SourceType { get;  set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                var result = this.AutomationClient.GetSourceControl(
                                this.ResourceGroupName,
                                this.AutomationAccountName,
                                this.Name);

                WriteObject(result);
            }
            
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                IEnumerable<SourceControl> result = null;
                var nextLink = string.Empty;

                do
                {
                    result = this.AutomationClient.ListSourceControl(
                                this.ResourceGroupName,
                                this.AutomationAccountName,
                                this.SourceType,
                                ref nextLink);

                    WriteObject(result, true);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
