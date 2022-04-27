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
using Microsoft.Azure.Commands.Resources.Models.PrivateLinks;
using Microsoft.Azure.Commands.Resources.PrivateLinks.Common;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// Remove-AzPrivateLinkAssociation Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkAssociation",
        DefaultParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class DeleteAzurePrivateLinkAssociation : PrivateLinksCmdletBase
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
        [Alias("PrivateLinkAssociationId")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.PLAObjectParameterSet, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.DeletePLAssociationParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.HelpMessage)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.PLAObjectParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.HelpMessage)]
        public SwitchParameter Force { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.PLAObjectParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkAssociationObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSResourceManagementPrivateLinkAssociation InputObject { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                this.Name = InputObject.Name;
                try
                {
                    // Retrieve only the management group  from the Id
                    this.ManagementGroupId = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components.ResourceIdUtility.GetManagementGroupId(InputObject.Id);
                }
                catch (Exception ex)
                {
                    this.WriteExceptionError(ex);
                }
            }

            this.ConfirmAction(
                this.Force,
                string.Format("Are you sure you want to delete the following private link association: {0}", Name),
                "Deleting the private link association...",
                Name,
                () =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(ManagementGroupId) && !string.IsNullOrEmpty(Name))
                        {
                            ResourceManagementPrivateLinkClient.PrivateLinkAssociation.Delete(
                                groupId: ManagementGroupId,
                                plaId: Name);

                            if (PassThru.IsPresent)
                            {
                                WriteObject(true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.WriteExceptionError(ex);
                    }
                });
        }
    }
}