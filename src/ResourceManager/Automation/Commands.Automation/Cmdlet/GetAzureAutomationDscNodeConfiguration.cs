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
    /// Gets Azure automation node configurations
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscNodeConfiguration", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(CompilationJob))]
    public class GetAzureAutomationDscNodeConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary> 
        /// Gets or sets the job id. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByNodeConfigurationName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The dsc node configuration name.")]
        [Alias("NodeConfigurationName")]
        public string Name { get; set; }

        /// <summary> 
        /// Gets or sets the runbook name of the job. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "The configuration name.")]
        public string ConfigurationName { get; set; }

        /// <summary> 
        /// Gets or sets the status of a job. 
        /// </summary> 
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Mandatory = false, HelpMessage = "Filter node configurations by RollupStatus.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, HelpMessage = "Filter node configurations by RollupStatus.")]
        [ValidateSet("Good", "Bad", IgnoreCase = true)]
        public string RollupStatus { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<NodeConfiguration> nodeConfigurations;

            if (this.Name != null)
            {
                nodeConfigurations = new List<NodeConfiguration> { this.AutomationClient.GetNodeConfiguration(this.ResourceGroupName, this.AutomationAccountName, this.Name, this.RollupStatus) };
            }
            else if (this.ConfigurationName != null)
            {
                // ByConfiguration 
                nodeConfigurations = this.AutomationClient.ListNodeConfigurationsByConfigurationName(this.ResourceGroupName, this.AutomationAccountName, this.ConfigurationName, this.RollupStatus);
            }
            else
            {
                // ByAll 
                nodeConfigurations = this.AutomationClient.ListNodeConfigurations(this.ResourceGroupName, this.AutomationAccountName, this.RollupStatus);
            }

            this.WriteObject(nodeConfigurations, true);
        }
    }
}
