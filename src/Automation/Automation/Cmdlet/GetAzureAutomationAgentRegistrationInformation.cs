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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation agent registration information for a given account.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationRegistrationInfo")]
    [OutputType(typeof(AgentRegistration))]
    public class GetAzureAutomationRegistrationInfo : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<AgentRegistration> ret = null;

            var agentRegInfo = this.AutomationClient.GetAgentRegistration(
                                  this.ResourceGroupName,
                                  this.AutomationAccountName);

            if (agentRegInfo.PrimaryKey == null && agentRegInfo.SecondaryKey == null)
            {
                throw new AzureAutomationOperationException(Resources.InsufficientUserPermissions);
            }

            ret = new List<AgentRegistration>
                          {
                              agentRegInfo
                          };

            this.GenerateCmdletOutput(ret);
        }

    }
}
