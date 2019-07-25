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
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines Get-AzDataShareInvitation cmdlets.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareInvitation",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShare))]
    public class GetAzDataShareInvitation : AzureDataShareCmdletBase
    {

        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Then name of azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Then name of azure data share invitation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data share invitation name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Invitation, "ResourceGroupName", "AccountName","ShareName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of azure data share invitation.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share invitation",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Invitation)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareName = parsedResourceId.GetShareName();
                this.Name = parsedResourceId.GetInvitationName();
            }

            if (this.Name != null)
            {
                try
                {
                    Invitation invitation = this.DataShareManagementClient.Invitations.Get(
                        this.ResourceGroupName,
                        this.AccountName,
                        this.ShareName,
                        this.Name);

                    this.WriteObject(invitation.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                }
            }
            else
            {
                string nextPageLink = null;
                List<Invitation> invitationList = new List<Invitation>();

                do
                {
                    IPage<Invitation> invitations = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.Invitations.ListByShare(this.ResourceGroupName, this.AccountName, this.ShareName)
                        : this.DataShareManagementClient.Invitations.ListByShareNext(nextPageLink);

                    invitationList.AddRange(invitations.AsEnumerable());
                    nextPageLink = invitations.NextPageLink;
                } while (nextPageLink != null);

                IEnumerable<PSDataShareInvitation> invitationsInShare = invitationList.Select(invitation => invitation.ToPsObject());
                this.WriteObject(invitationsInShare, true);
            }
        }
    }
}
