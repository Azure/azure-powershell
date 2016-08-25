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
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Regenerates the agent registration key based on the key name.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationKey")]
    [OutputType(typeof(AgentRegistration))]
    public class NewAzureAutomationKey : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the KeyType.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The key type of the agent registration key - primary or secondary")]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string KeyType { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            var agentRegistration = this.AutomationClient.NewAgentRegistrationKey(this.ResourceGroupName, this.AutomationAccountName, this.KeyType);
            this.WriteObject(agentRegistration);
        }
    }
}
