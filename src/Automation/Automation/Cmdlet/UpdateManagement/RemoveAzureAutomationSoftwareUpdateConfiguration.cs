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
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;
using System.Globalization;

namespace Microsoft.Azure.Commands.Automation.Cmdlet.UpdateManagement
{
    /// <summary>
    /// Removes a Certificate for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSoftwareUpdateConfiguration", SupportsShouldProcess = true,
        DefaultParameterSetName = AutomationCmdletParameterSets.BySucName)]
    [OutputType(typeof(void), typeof(bool))]
    public class RemoveAzureAutomationSoftwareUpdateConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the certificate name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the software update configuration to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySuc, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The software update configuration to remove.")]
        [ValidateNotNullOrEmpty]
        public SoftwareUpdateConfiguration SoftwareUpdateConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the PassThru switch parameter to force return an object when removing the software update configuration.
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
            var name = this.ParameterSetName == AutomationCmdletParameterSets.BySucName ? this.Name : this.SoftwareUpdateConfiguration.Name;
            var resource = string.Format(CultureInfo.CurrentCulture, Resources.SoftwareUpdateConfigurationRemoveOperation);
            if (ShouldProcess(name, resource))
            {
                ConfirmAction(
                    string.Format(Resources.RemoveAzureAutomationResourceDescription, "SoftwareUpdateConfiguration"),
                    Name,
                    () =>
                    {
                        this.AutomationClient.DeleteSoftwareUpdateConfiguration(this.ResourceGroupName,
                            this.AutomationAccountName, name);
                    });

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
