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

using Microsoft.Azure.Commands.Resources.Models.PrivateLinks;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// New-AzPrivateLinkAssociation Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkAssociation",
        DefaultParameterSetName = Constants.ParameterSetNames.PutPLAssociationParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSResourceManagementPrivateLinkAssociation))]
    public class NewAzurePrivateLinkAssociation : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.PutPLAssociationParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.ManagementGroupId,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.PutPLAssociationParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkAssociationId,
            Position = 1)]
        [Alias("PrivateLinkAssociationId")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           ParameterSetName = Constants.ParameterSetNames.PutPLAssociationParameterSet,
           Mandatory = true,
           HelpMessage = Constants.HelpMessages.PrivateLinkName,
           Position = 2)]
        [ValidateNotNullOrEmpty]
        public string PrivateLink { get; set; }

        [Parameter(
           ParameterSetName = Constants.ParameterSetNames.PutPLAssociationParameterSet,
           Mandatory = true,
           HelpMessage = Constants.HelpMessages.PublicNetworkAccess,
           Position = 3)]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(ManagementGroupId) && !string.IsNullOrEmpty(Name))
                {
                    var response = ResourceManagementPrivateLinkClient.PrivateLinkAssociation.Put(
                        groupId: ManagementGroupId,
                        plaId: Name,
                        parameters: new PrivateLinkAssociationObject(new PrivateLinkAssociationProperties(PrivateLink, PublicNetworkAccess)));
                    WriteObject(new PSResourceManagementPrivateLinkAssociation(response));
                }
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }
    }
}
