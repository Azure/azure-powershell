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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.NetAppFiles.Common;
using Microsoft.Azure.Commands.NetAppFiles.Helpers;
using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System.Linq;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.NetAppFiles.N
{
    [Cmdlet(
    "Get",
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesFilePathAvailability",
    DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSRegionInfo))]
    [Alias("Get-AnfRegionInfo")]
    public class GetAzureRmNetAppFilesFilePathAvailability : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/locations/checkFilePathAvailability")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. Example /subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/testVnet/subnets/{mySubnet}")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "File path to verify.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Logical availability zone")]
        public string Zone { get; set; }


        public override void ExecuteCmdlet()
        {
            try
            {
                var anfCheckAvailabilityResponse = AzureNetAppFilesManagementClient.NetAppResource.CheckFilePathAvailability(location: Location, name: Name, subnetId: SubnetId, availabilityZone: Zone);
                WriteObject(anfCheckAvailabilityResponse.ConvertToPs());
            }
            catch (ErrorResponseException ex)
            {
                throw new CloudException(ex.Body.Error.Message, ex);                
            }
        }
    }
}
