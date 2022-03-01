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
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// Remove-AzResourceManagementPrivateLinkAssociation Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceManagementPrivateLinkAssociation",
        DefaultParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class DeleteAzureResourceManagementPrivateLinkAssociation : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.ManagementGroupId,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkAssociationId,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkAssociationId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            try
            {
                 if (!string.IsNullOrEmpty(ManagementGroupId) && !string.IsNullOrEmpty(PrivateLinkAssociationId))
                 {
                     ResourceManagementPrivateLinkClient.PrivateLinkAssociation.Delete(
                         groupId: ManagementGroupId,
                         plaId: PrivateLinkAssociationId);
                     WriteObject(true);
                 }
            }
            catch (Exception ex)
            {
                this.WriteExceptionError(ex);
            }
        }
    }
}
