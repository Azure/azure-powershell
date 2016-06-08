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
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation dsc node.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscNode", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(DscNode))]
    public class GetAzureAutomationDscNode : AzureAutomationBaseCmdlet
    {
        /// <summary> 
        /// Gets or sets the job id. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ById, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node id.")]
        [Alias("NodeId")]
        public Guid Id { get; set; }

        /// <summary> 
        /// Gets or sets the status of a dsc node. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = false, HelpMessage = "Filter dsc nodes based on their status.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByNodeConfiguration, Mandatory = false, HelpMessage = "Filter dsc nodes based on their status.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter dsc nodes based on their status.")]
        [ValidateSet("Compliant", "NotCompliant", "Failed", "Pending", "Received", "Unresponsive", IgnoreCase = true)]
        public DscNodeStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the node name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The node name.")]
        [ValidateNotNullOrEmpty]
        [Alias("NodeName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the nodeconfiguration name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByNodeConfiguration, Mandatory = true, HelpMessage = "Filter dsc nodes based on their node configuration name.")]
        public string NodeConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the configuration name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfiguration, Mandatory = true, HelpMessage = "Filter dsc nodes based on the name of the configuration the node configuration they are mapped to was generated from")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<DscNode> ret = null;

            var nodeStatus = this.Status.ToString();
            if (nodeStatus.Equals("0"))
            {
                nodeStatus = null;
            }

            if (this.ParameterSetName == AutomationCmdletParameterSets.ById)
            {
                ret = new List<DscNode>
                {
                   this.AutomationClient.GetDscNodeById(this.ResourceGroupName, this.AutomationAccountName, this.Id)
                };
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByName)
            {
                ret = this.AutomationClient.ListDscNodesByName(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.Name,
                    nodeStatus);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByNodeConfiguration)
            {
                ret = this.AutomationClient.ListDscNodesByNodeConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.NodeConfigurationName,
                    nodeStatus);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByConfiguration)
            {
                ret = this.AutomationClient.ListDscNodesByConfiguration(
                    this.ResourceGroupName,
                    this.AutomationAccountName,
                    this.ConfigurationName,
                    nodeStatus);
            }
            else
            {
                // ByAll
                ret = this.AutomationClient.ListDscNodes(this.ResourceGroupName, this.AutomationAccountName, nodeStatus);
            }

            this.GenerateCmdletOutput(ret);
        }
    }
}
