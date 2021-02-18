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

namespace Microsoft.Azure.Commands.DataShare.Invitation
{
    using System;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using System.Management.Automation;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the New-DataShareInvitation cmdlet.
    /// </summary>
    [Cmdlet("New",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareInvitation",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true),
     OutputType(typeof(PSDataShareInvitation))]
    public class NewAzDataShareInvitation : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account name.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.InvitationEmailParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.InvitationEmailParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of azure data share.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.InvitationEmailParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Name of the azure data share invitation.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share invitation name",
            ParameterSetName = ParameterSetNames.InvitationEmailParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Azure data share invitation name",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Target object id of recipient.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Target object id",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TargetObjectId { get; set; }

        /// <summary>
        /// Target tenant id of recipient.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Target tenant id",
            ParameterSetName = ParameterSetNames.InvitationTenantParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TargetTenantId { get; set; }

        /// <summary>
        /// Email id of recipient.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Target email id",
            ParameterSetName = ParameterSetNames.InvitationEmailParameterSet)]
        [ValidateNotNullOrEmpty]
        public string TargetEmail { get; set; }

        private const string ResourceType = "Invitation";

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.InvitationEmailParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareInvitation.ResourceType)))
                {
                    Invitation newInvitation = this.DataShareManagementClient.Invitations.Create(
                        this.ResourceGroupName,
                        this.AccountName,
                        this.ShareName,
                        this.Name,
                        new Invitation()
                        {
                            TargetEmail = this.TargetEmail
                        });

                    this.WriteObject(newInvitation.ToPsObject());
                }
            }

            if (this.ParameterSetName.Equals(ParameterSetNames.InvitationTenantParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareInvitation.ResourceType)))
                {
                    Invitation newInvitation = this.DataShareManagementClient.Invitations.Create(
                        this.ResourceGroupName,
                        this.AccountName,
                        this.ShareName,
                        this.Name,
                        new Invitation()
                        {
                            TargetObjectId = this.TargetObjectId,
                            TargetActiveDirectoryId = this.TargetTenantId
                        });

                    this.WriteObject(newInvitation.ToPsObject());
                }
            }
        }
    }
}
