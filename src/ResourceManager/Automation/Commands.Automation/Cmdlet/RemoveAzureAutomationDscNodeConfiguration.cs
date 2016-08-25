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

using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Remove a DSC configuration
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmAutomationDscNodeConfiguration", SupportsShouldProcess = true)]
    public class RemoveAzureAutomationDscNodeConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the Configuration name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The node configuration name.")]
        [Alias("NodeConfigurationName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, HelpMessage = "Force confirmation of the removal of the node configuration")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 4, HelpMessage = "Remove the node configuration even if the node configuration is mapped to one or more nodes")]
        public SwitchParameter IgnoreNodeMappings { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingAzureAutomationResourceWarning, "DSC node configuration"),
                string.Format(Resources.RemoveAzureAutomationResourceDescription, "DSC node configuration"),
                Name,
                () => this.AutomationClient.DeleteNodeConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Name,
                    IgnoreNodeMappings.IsPresent));
        }
    }
}
