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
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Create a new Credential for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureAutomationCredential", DefaultParameterSetName = AutomationCmdletParameterSets.ByName)]
    [OutputType(typeof(CredentialInfo))]
    public class NewAzureAutomationCredential : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the credential name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The credential name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the credential name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The credential description.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the credential UserName.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The credential value.")]
        public PSCredential Value { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            string userName = null, password = null;

            if (Value != null)
            {
                userName = Value.UserName;
                password = Value.GetNetworkCredential().Password;
            }

            var createdCredential = this.AutomationClient.CreateCredential(this.AutomationAccountName, Name, userName, password, Description);

            this.WriteObject(createdCredential);
        }
    }
}
