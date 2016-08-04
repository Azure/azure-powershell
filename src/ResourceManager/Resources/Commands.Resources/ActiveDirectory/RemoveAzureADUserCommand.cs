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
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;


namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes the AD user.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADUser", SupportsShouldProcess = true)]
    public class RemoveAzureADUserCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The userPrincipalName or ObjectId of the user to be deleted.")]
        [ValidateNotNullOrEmpty]
        public string UPNOrObjectId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                ConfirmAction(
               Force.IsPresent,
               string.Format(ProjectResources.RemoveUserConfirmation, UPNOrObjectId),
               ProjectResources.RemovingUser,
               UPNOrObjectId,
               () => ActiveDirectoryClient.RemoveUser(UPNOrObjectId));
            });
        }
    }
}
