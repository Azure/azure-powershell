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
    /// Gets azure automation configurations for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationDscConfiguration", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(DscConfiguration))]
    public class GetAzureAutomationDscConfiguration : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the configuration name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConfigurationName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The configuration name.")]
        [Alias("ConfigurationName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<DscConfiguration> ret = null;
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByConfigurationName)
            {
                ret = new List<DscConfiguration>
                {
                   this.AutomationClient.GetConfiguration(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByAll)
            {
                ret = this.AutomationClient.ListDscConfigurations(this.ResourceGroupName, this.AutomationAccountName);
            }

            this.GenerateCmdletOutput(ret);
        }
    }
}
