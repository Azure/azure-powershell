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

namespace Microsoft.Azure.Commands.NetAppFiles.QuotaItem
{
    [Cmdlet(
    "Get",
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetAppFilesQuotaLimit",
    DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSNetAppFilesSubscriptionQuotaLimit))]
    [Alias("Get-AnfQuotaLimit")]
    public class GetAzureRmNetAppFilesQuotaLimit: AzureNetAppFilesCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = FieldsParameterSet,
            HelpMessage = "The location of the resource")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.NetApp/locations/quotaLimits")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the Quota Limit")]
        [ValidateNotNullOrEmpty]
        [Alias("QuotaLimitName")]        
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                //var anfSubscriptionQuotaLimits = AzureNetAppFilesManagementClient.NetAppResourceQuotaLimits.List(Location).Select(e => e.ConvertToPs());
                var anfSubscriptionQuotaLimits = AzureNetAppFilesManagementClient.NetAppResourceQuotaLimits.List(Location).ConvertToPS();
                WriteObject(anfSubscriptionQuotaLimits, true);
            }
            else
            {
                var anfSubscriptionQuotaLimit = AzureNetAppFilesManagementClient.NetAppResourceQuotaLimits.Get(Location, Name);
                WriteObject(anfSubscriptionQuotaLimit.ConvertToPs());
            }
        }
    }
}
