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
using System.Collections;
using System.Management.Automation;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Connection for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationConnection", DefaultParameterSetName = AutomationCmdletParameterSets.ByConnectionName)]
    [OutputType(typeof(Connection))]
    public class NewAzureAutomationConnection : AzureAutomationBaseCmdlet
    {

        /// <summary>
        /// Gets or sets the connection name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the connection type name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection type name.")]
        [ValidateNotNullOrEmpty]
        public string ConnectionTypeName { get; set; }

        /// <summary>
        /// Gets or sets the connection field values.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection field values.")]
        public IDictionary ConnectionFieldValues { get; set; }

        /// <summary>
        /// Gets or sets the connection description.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection description.")]
        public string Description { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {

            var createdConnection = this.AutomationClient.CreateConnection(this.ResourceGroupName, this.AutomationAccountName, this.Name, this.ConnectionTypeName, this.ConnectionFieldValues, this.Description);

            this.WriteObject(createdConnection);
        }
    }
}
