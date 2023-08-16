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
using System.Linq;

namespace Microsoft.Azure.Commands.NetAppFiles.N
{
    [Cmdlet(
    "Get",
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesRegionInfo",
    DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSRegionInfo))]
    [Alias("Get-AnfRegionInfo")]
    public class GetAzureRmNetAppFilesNetAppFilesRegionInfo : AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/locations/quotaLimits")]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            var anfRegionInfo = AzureNetAppFilesManagementClient.NetAppResource.QueryRegionInfo(Location);
            WriteObject(anfRegionInfo.ConvertToPs());
        }
    }
}
