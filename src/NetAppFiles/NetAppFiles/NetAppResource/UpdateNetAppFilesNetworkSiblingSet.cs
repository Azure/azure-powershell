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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.Pool
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesNetworkSiblingSet",
        SupportsShouldProcess = true,
        DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesPool))]
    [Alias("Update-AnfNetworkSiblingSet")]
    public class UpdateAzureRmNetAppFilesNetworkSiblingSet : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/locations/NetworkSiblingSetQuery")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. Example /subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/testVnet/subnets/{mySubnet}")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Network Sibling Set ID for a group of volumes sharing networking resources in a subnet.")]
        [ValidateNotNullOrEmpty]
        public string NetworkSiblingSetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Network sibling set state Id identifying the current state of the sibling set.")]
        [ValidateNotNullOrEmpty]
        public string NetworkSiblingSetStateId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Network features available to the volume, or current state of update.")]
        [PSArgumentCompleter("Basic", "Standard", "Basic_Standard", "Standard_Basic")]
        [ValidateNotNullOrEmpty]
        public string NetworkFeature{ get; set; }


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(NetworkSiblingSetId, string.Format(PowerShell.Cmdlets.NetAppFiles.Properties.Resources.UpdateNetworkSiblingSet, NetworkSiblingSetId)))
            {
                try
                {
                    UpdateNetworkSiblingSetRequest updateNetworkSiblingSetRequest = new UpdateNetworkSiblingSetRequest
                    {
                        NetworkSiblingSetId = this.NetworkSiblingSetId,
                        SubnetId = this.SubnetId,
                        NetworkSiblingSetStateId = this.NetworkSiblingSetStateId,
                        NetworkFeatures = this.NetworkFeature
                    };
                    var anfNetworkSiblingSet = AzureNetAppFilesManagementClient.NetAppResource.UpdateNetworkSiblingSet(Location, updateNetworkSiblingSetRequest).ConvertToPs();
                    WriteObject(anfNetworkSiblingSet);
                }
                catch (ErrorResponseException ex)
                {
                    throw new CloudException(ex.Body.Error.Message, ex);
                }
            }
        }
    }
}
