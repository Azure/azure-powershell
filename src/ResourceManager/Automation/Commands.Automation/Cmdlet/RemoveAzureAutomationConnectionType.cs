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
using Microsoft.Azure.Commands.Automation.Properties;
using System;
using System.Linq;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Removes a Connection type for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmAutomationConnectionType", SupportsShouldProcess = true, 
        DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    public class RemoveAzureAutomationConnectionType : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the connection name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The connection type name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 3, HelpMessage = "Confirm the removal of the connection type")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var nextLink = string.Empty;
            var removeMessageWarning = Resources.RemovingAzureAutomationResourceWarning;
            bool shouldConfirm = false;

            // check if any connections exists that use this connection type
            do
            {
                var ret = this.AutomationClient.ListConnections(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);

                if (ret.ToList().Any(connection => 0 ==
                                                   string.Compare(connection.ConnectionTypeName, this.Name,
                                                       StringComparison.CurrentCultureIgnoreCase)))
                {
                    removeMessageWarning = Resources.RemoveConnectionTypeThatHasConnectionWarning;
                    shouldConfirm = true;
                    break;
                }

            } while (!string.IsNullOrEmpty(nextLink));


            ConfirmAction(
                       Force.IsPresent,
                       string.Format(removeMessageWarning, "ConnectionType"),
                       string.Format(Resources.RemoveAzureAutomationResourceDescription, "ConnectionType"),
                       Name,
                       () => this.AutomationClient.DeleteConnectionType(this.ResourceGroupName, this.AutomationAccountName, Name),
                       () => shouldConfirm);
        }
    }
}
