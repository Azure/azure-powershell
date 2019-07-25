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

namespace Microsoft.Azure.Commands.DataShare.ConsumerInvitation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines Get-AzDataShareReceivedInvitation cmdlets.
    /// </summary>
    [Cmdlet("Get",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareReceivedInvitation",
        DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShare))]
    public class GetAzDataShareReceivedInvitation : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The location of azure data share invitation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data share invitation location.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter(ResourceTypes.Invitation)]
        public string Location { get; set; }

        /// <summary>
        /// The invitation id of azure data share invitation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure dataShare invitation id.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string InvitationId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.InvitationId != null && this.Location != null)
            {
                try
                {
                    ConsumerInvitation ConsumerInvitation =
                        this.DataShareManagementClient.ConsumerInvitations.Get(this.Location, this.InvitationId);

                    this.WriteObject(ConsumerInvitation.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.InvitationId));
                }
            }
            else
            {
                string nextPageLink = null;
                List<ConsumerInvitation> invitationList = new List<ConsumerInvitation>();

                do
                {
                    IPage<ConsumerInvitation> invitations = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.ConsumerInvitations.ListInvitations()
                        : this.DataShareManagementClient.ConsumerInvitations.ListInvitationsNext(nextPageLink);

                    invitationList.AddRange(invitations.AsEnumerable());
                    nextPageLink = invitations.NextPageLink;

                } while (nextPageLink != null);

                IEnumerable<PSDataShareConsumerInvitation> consumerInvitations = invitationList.Select(invitation => invitation.ToPsObject());
                this.WriteObject(consumerInvitations, true);
            }
        }
    }
}

