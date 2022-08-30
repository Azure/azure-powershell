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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models.PrivateLinks;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// Get-AzPrivateLinkAssociation Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkAssociation",
        DefaultParameterSetName = Constants.ParameterSetNames.GetPLAssociationParameterSet), OutputType(typeof(PSResourceManagementPrivateLinkAssociation))]
    public class GetAzurePrivateLinkAssociation : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.GetPLAssociationParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.ManagementGroupId,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.GetPLAssociationParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.PrivateLinkAssociationId,
            Position = 1)]
        [Alias("PrivateLinkAssociationId")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(ManagementGroupId) && string.IsNullOrEmpty(Name))
                {
                    var response = ResourceManagementPrivateLinkClient.PrivateLinkAssociation.List(
                        groupId: ManagementGroupId);
                    var items = response.Value.Select(privateLinkAssociation => new PSResourceManagementPrivateLinkAssociation(privateLinkAssociation))
                        .ToList();
                    WriteObject(items);
                }
                else if (!string.IsNullOrEmpty(ManagementGroupId) && !string.IsNullOrEmpty(Name))
                {
                    var response = ResourceManagementPrivateLinkClient.PrivateLinkAssociation.Get(
                        groupId: ManagementGroupId,
                        plaId: Name);
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
