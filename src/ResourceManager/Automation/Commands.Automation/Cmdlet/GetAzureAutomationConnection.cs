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
    /// Gets a connection for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationConnection", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(Connection))]
    public class GetAzureAutomationConnection : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the connection name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The connection name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the connection name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionTypeName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The connection name.")]
        [ValidateNotNullOrEmpty]
        public string ConnectionTypeName { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<Connection> ret = null;
            if (this.ParameterSetName == AutomationCmdletParameterSets.ByConnectionName)
            {
                ret = new List<Connection>
                {
                   this.AutomationClient.GetConnection(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };
                this.GenerateCmdletOutput(ret);
            }
            else if (this.ParameterSetName == AutomationCmdletParameterSets.ByConnectionTypeName)
            {
                ret = this.AutomationClient.ListConnectionsByType(this.ResourceGroupName, this.AutomationAccountName, this.ConnectionTypeName);
                this.GenerateCmdletOutput(ret);
            }
            else
            {
                var nextLink = string.Empty;

                do
                {
                    ret = this.AutomationClient.ListConnections(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    this.GenerateCmdletOutput(ret);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
