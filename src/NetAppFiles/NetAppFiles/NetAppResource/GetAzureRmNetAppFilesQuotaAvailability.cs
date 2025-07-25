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
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesQuotaAvailability",
    DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSRegionInfo))]
    [Alias("Get-AnfQuotaAvailability")]
    public class GetAzureRmNetAppFilesQuotaAvailability : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The resource group of the ANF resource")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/locations/checkQuotaAvailability")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource type used for verification")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Microsoft.NetApp/netAppAccounts", "Microsoft.NetApp/netAppAccounts/capacityPools", "Microsoft.NetApp/netAppAccounts/capacityPools/volumes", "Microsoft.NetApp/netAppAccounts/capacityPools/volumes/snapshots")]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the resource to verify")]
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
                var anfCheckAvailabilityResponse = AzureNetAppFilesManagementClient.NetAppResource.CheckQuotaAvailability(location: Location, name: Name, type: Type, resourceGroup: ResourceGroupName);
                WriteObject(anfCheckAvailabilityResponse.ConvertToPs());
            }
            catch (ErrorResponseException ex)
            {
                throw new CloudException(ex.Body.Error.Message, ex);                
            }
        }
    }
}
