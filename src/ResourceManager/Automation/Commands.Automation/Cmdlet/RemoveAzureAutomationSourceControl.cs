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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;
using System.Globalization;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes an azure automation source control for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSourceControl",
        SupportsShouldProcess = true)]
    [OutputType(typeof(void), typeof(bool))]
    public class RemoveAzureAutomationSourceControl : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the source control name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "The source control name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing the source control.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "PassThru returns an object representing the item with which you are working." +
            " By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            string resource = string.Format(CultureInfo.CurrentCulture, Resources.SourceControlRemoveAction);
            if (ShouldProcess(Name, resource))
            {
                this.AutomationClient.DeleteSourceControl(this.ResourceGroupName, this.AutomationAccountName, this.Name);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
