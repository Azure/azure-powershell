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

using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.PowerShell.Commands;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreVirtualNetworkRule", SupportsShouldProcess = true), OutputType(typeof(DataLakeStoreVirtualNetworkRule))]
    [Alias("Set-AdlStoreVirtualNetworkRule")]
    public class SetAzureRmDataLakeStoreVirtualNetworkRule : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to update the virtual network rule in")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the virtual network rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The start of the valid ip range for the virtual network rule")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        public override void ExecuteCmdlet()
        {
            // get the current virtual network rule
            VirtualNetworkRule rule = DataLakeStoreClient.GetVirtualNetworkRule(Account, Name);
            if (rule == null)
            {
                throw new PSInvalidOperationException(string.Format(Resources.VirtualNetworkRuleNotFound, Name));
            }

            var subnetId = SubnetId ?? rule.SubnetId;
            ConfirmAction(
                string.Format(Resources.SetDataLakeVirtualNetworkRule, Name),
                Name,
                () => 
                    WriteObject(new DataLakeStoreVirtualNetworkRule(DataLakeStoreClient.AddOrUpdateVirtualNetworkRule(
                        Account, Name, subnetId, this)))
            );
        }
    }
}
