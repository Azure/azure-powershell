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
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Updates configuration on the dsc node.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmAutomationDscNode", SupportsShouldProcess = true)]
    [OutputType(typeof(DscNode))]
    public class SetAzureAutomationDscNode : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// True to overwrite the existing configuration; false otherwise.
        /// </summary>        
        private bool overwriteExistingNodeConfiguration;

        /// <summary> 
        /// Gets or sets the node id. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ById, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node id.")]
        [Alias("NodeId")]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the nodeconfiguration name.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The node configuration name that the node should now be mapped to.")]
        [ValidateNotNullOrEmpty]
        public string NodeConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets switch parameter to confirm overwriting of existing nodeconfigurations.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force
        {
            get { return this.overwriteExistingNodeConfiguration; }
            set { this.overwriteExistingNodeConfiguration = value; }
        }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(CultureInfo.CurrentCulture, Resources.SetnodeconfigurationWarning),
                string.Format(CultureInfo.CurrentCulture, Resources.SetnodeconfigurationDescription),
                this.NodeConfigurationName,
                () =>
                {
                    var node = this.AutomationClient.SetDscNodeById(this.ResourceGroupName, this.AutomationAccountName, this.Id, this.NodeConfigurationName);
                    this.WriteObject(node);
                });

        }
    }
}
