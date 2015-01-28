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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Connection for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureAutomationConnectionFieldValue", DefaultParameterSetName = AutomationCmdletParameterSets.ByConnectionName)]
    [OutputType(typeof(Connection))]
    public class SetAzureAutomationConnectionFieldValue : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the connection name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the connection field name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection field name.")]
        public string ConnectionFieldName { get; set; }

        /// <summary>
        /// Gets or sets the connection field value.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByConnectionName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The connection field value.")]
        public object Value { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {

            var updatedConnection = this.AutomationClient.UpdateConnectionFieldValue(this.AutomationAccountName, this.Name, this.ConnectionFieldName, this.Value);

            this.WriteObject(updatedConnection);
        }
    }
}
