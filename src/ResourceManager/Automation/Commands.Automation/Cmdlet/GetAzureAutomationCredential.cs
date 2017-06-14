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
    /// Gets a Credential for automation.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationCredential", DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(CredentialInfo))]
    public class GetAzureAutomationCredential : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the credential name.
        /// </summary>
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The credential name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<CredentialInfo> ret = null;
            if (!string.IsNullOrEmpty(this.Name))
            {
                ret = new List<CredentialInfo>
                {
                   this.AutomationClient.GetCredential(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                };

                this.GenerateCmdletOutput(ret);
            }
            else
            {
                var nextLink = string.Empty;

                do
                {
                    ret = this.AutomationClient.ListCredentials(this.ResourceGroupName, this.AutomationAccountName, ref nextLink);
                    this.GenerateCmdletOutput(ret);

                } while (!string.IsNullOrEmpty(nextLink));
            }
        }
    }
}
