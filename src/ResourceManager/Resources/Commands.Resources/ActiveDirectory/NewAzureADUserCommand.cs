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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD user.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmADUser", SupportsShouldProcess = true), OutputType(typeof(PSADUser))]
    public class NewAzureADUserCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The display name for the user.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The userPrincipalName.")]
        [ValidateNotNullOrEmpty]
        public string UserPrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Password for the user.")]
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "ImmutableId - to be specified only if you are using a federated domain for the user's user principal name (upn) property.")]
        [ValidateNotNullOrEmpty]
        public string ImmutableId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "It must be specified if the user should change the password on the next successful login. Default behavior is to not change the password on the next successful login.")]
        public SwitchParameter ForceChangePasswordNextLogin { get; set; }


        public override void ExecuteCmdlet()
        {
            var userCreateparameters = new UserCreateParameters
            {
                AccountEnabled = true,
                DisplayName = DisplayName,
                PasswordProfile = new PasswordProfile
                {
                    Password = Password,
                    ForceChangePasswordNextLogin = ForceChangePasswordNextLogin.IsPresent ? true : false
                },
                UserPrincipalName = UserPrincipalName
            };

            if(!string.IsNullOrEmpty(ImmutableId))
            {
                userCreateparameters.ImmutableId = ImmutableId;
            }

            ExecutionBlock(() =>
            {
                if (ShouldProcess(target: UserPrincipalName, action: string.Format("Adding a new user with UPN '{0}'", UserPrincipalName)))
                {
                    WriteObject(ActiveDirectoryClient.CreateUser(userCreateparameters));
                }
            });
        }
    }
}
