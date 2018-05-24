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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD group.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmADGroup", SupportsShouldProcess = true), OutputType(typeof(PSADGroup))]
    public class NewAzureADGroupCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The display name for the group.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail nickname for the group.")]
        [ValidateNotNullOrEmpty]
        public string MailNickname { get; set; }

        public override void ExecuteCmdlet()
        {
            var groupCreateParams = new GroupCreateParameters()
            {
                DisplayName = DisplayName,
                MailNickname = MailNickname
            };

            ExecutionBlock(() =>
            {
                if (ShouldProcess(target: DisplayName, action: string.Format("Creating a new AD group with display name '{0}'", DisplayName)))
                {
                    WriteObject(ActiveDirectoryClient.CreateGroup(groupCreateParams));
                }
            });
        }
    }
}
