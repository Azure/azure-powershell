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
using Microsoft.Azure.Commands.Automation.Properties;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Start, "AzureRmAutomationDscNodeConfigurationDeployment", SupportsShouldProcess = true, 
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(NodeConfigurationDeployment))]
    public class StartAzureAutomationDscNodeConfigurationDeployment : AzureAutomationBaseCmdlet
    {

        /// <summary>
        /// Gets or sets the node configuration name.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AutomationCmdletParameterSets.ByAll, 
            HelpMessage = "The node configuration name to be deployed.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = AutomationCmdletParameterSets.ByInputObject,
            HelpMessage = "The node configuration name to be deployed.")]
        [Alias("Name")]
        public string NodeConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the node names list.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = false, ParameterSetName = AutomationCmdletParameterSets.ByAll,
            HelpMessage = "A two dimensional array of NodeNames to which the Node Configuration would be deployed.")]
        [Parameter(Position = 3, Mandatory = true, ParameterSetName = AutomationCmdletParameterSets.ByInputObject, 
            HelpMessage = "A two dimensional array of NodeNames to which the Node Configuration would be deployed.")]
        public string[][] NodeName { get; set; }

        /// <summary>
        /// Gets or sets the schedule.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutomationCmdletParameterSets.ByAll, 
            HelpMessage = "The compilation job configuration data.")]
        public Schedule Schedule { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to confirm on deploying the node configuration.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AutomationCmdletParameterSets.ByAll, 
            HelpMessage = "Forces the command to run without asking for user confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the switch parameter to confirm on deploying the node configuration.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AutomationCmdletParameterSets.ByInputObject, 
            HelpMessage = "Input object for Piping.")]
        public NodeConfigurationDeployment InputObject { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (ParameterSetName)
            {
                case AutomationCmdletParameterSets.ByInputObject:
                    if (ShouldProcess(NodeConfigurationName, VerbsLifecycle.Start))
                    {
                        if (Force || ShouldContinue(Resources.StartAzureAutomationNodeConfigurationWarning,
                                Resources.StartAzureAutomationNodeConfigurationDescription))
                        {
                            var nodeConfigurationDeployment = AutomationClient.StartNodeConfigurationDeployment(
                                InputObject.ResourceGroupName,
                                InputObject.AutomationAccountName,
                                InputObject.NodeConfigurationName,
                                NodeName,
                                Schedule);

                            WriteObject(nodeConfigurationDeployment);
                        }
                    }
                    break;
                case AutomationCmdletParameterSets.ByAll:
                    if (ShouldProcess(NodeConfigurationName, VerbsLifecycle.Start))
                    {
                        if (Force || ShouldContinue(Resources.StartAzureAutomationNodeConfigurationWarning,
                                Resources.StartAzureAutomationNodeConfigurationDescription))
                        {
                            var nodeConfigurationDeployment = AutomationClient.StartNodeConfigurationDeployment(ResourceGroupName,
                                AutomationAccountName,
                                NodeConfigurationName,
                                NodeName,
                                Schedule);

                            WriteObject(nodeConfigurationDeployment);
                        }
                    }
                    break;
            }
        }
    }
}
