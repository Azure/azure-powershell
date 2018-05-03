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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes the AD user.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADUser", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.UPNOrObjectId), OutputType(typeof(bool))]
    public class RemoveAzureADUserCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.UPNOrObjectId, HelpMessage = "The userPrincipalName or ObjectId of the user to be deleted.")]
        [ValidateNotNullOrEmpty]
        public string UPNOrObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.UPN, HelpMessage = "The user principal name of the user to be deleted.")]
        [ValidateNotNullOrEmpty]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The object Id of the user to be deleted.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the user to be deleted.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObject, HelpMessage = "The user object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSADUser InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    UPNOrObjectId = !string.IsNullOrEmpty(InputObject.UserPrincipalName) ?
                                        InputObject.UserPrincipalName :
                                        InputObject.Id.ToString();
                }
                else if (this.IsParameterBound(c => c.UserPrincipalName))
                {
                    UPNOrObjectId = UserPrincipalName;
                }
                else if (this.IsParameterBound(c => c.ObjectId))
                {
                    UPNOrObjectId = ObjectId.ToString();
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    UPNOrObjectId = ActiveDirectoryClient.GetUserObjectIdFromDisplayName(DisplayName).ToString();
                }

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemoveUserConfirmation, UPNOrObjectId),
                    ProjectResources.RemovingUser,
                    UPNOrObjectId,
                    () => ActiveDirectoryClient.RemoveUser(UPNOrObjectId));

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            });
        }
    }
}
