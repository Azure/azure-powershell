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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.Resources.PrivateLinks
{
    /// <summary>
    /// Remove-AzResourceManagementPrivateLink Cmdlet
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ResourceManagementPrivateLink",
        DefaultParameterSetName = Constants.ParameterSetNames.DeleteParameterSet,
        SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class DeleteAzureResourceManagementPrivateLink : PrivateLinksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.DeleteParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.ResourceGroupName,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; } = null;

        [Parameter(
            ParameterSetName = Constants.ParameterSetNames.DeleteParameterSet,
            Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkName,
            Position = 1)]
        [Alias("PrivateLinkName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.DeleteParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.DeleteParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.HelpMessage)]
        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet,
            Mandatory = false,
            HelpMessage = Constants.HelpMessages.HelpMessage)]
        public SwitchParameter Force { get; set; }

        [Parameter(ParameterSetName = Constants.ParameterSetNames.ObjectParameterSet, Mandatory = true,
            HelpMessage = Constants.HelpMessages.PrivateLinkObject, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSResourceManagementPrivateLink InputObject { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(Constants.ParameterSetNames.ObjectParameterSet))
            {
                this.Name = InputObject.Name;
                try
                {
                    ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);

                    // Retrieve only the resource group name from the Id
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                }
                catch (Exception ex)
                {
                    this.WriteExceptionError(ex);
                }
            }

            this.ConfirmAction(
                this.Force,
                string.Format("Are you sure you want to delete the following resource management private link: {0}", Name),
                "Deleting the resource management private link...",
                Name,
                () =>
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
                        {
                            ResourceManagementPrivateLinkClient.ResourceManagementPrivateLink.Delete(
                                resourceGroupName: ResourceGroupName,
                                rmplName: Name);

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
