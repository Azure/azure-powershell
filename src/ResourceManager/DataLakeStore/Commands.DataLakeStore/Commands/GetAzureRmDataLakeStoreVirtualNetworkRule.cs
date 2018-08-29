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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.PowerShell.Commands;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeStore
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeStoreVirtualNetworkRule"), OutputType(typeof(DataLakeStoreVirtualNetworkRule))]
    [Alias("Get-AdlStoreVirtualNetworkRule")]
    public class GetAzureRmDataLakeStoreVirtualNetworkRule : DataLakeStoreCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The Data Lake Store account to get the virtual network rule from")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The name of the virtual network rule.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // get the current virtual network rule
            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(DataLakeStoreClient.ListVirtualNetworkRules(Account)
                    .Select(element => new DataLakeStoreVirtualNetworkRule(element))
                    .ToList(), true);
            }
            else
            {
                WriteObject(new DataLakeStoreVirtualNetworkRule(DataLakeStoreClient.GetVirtualNetworkRule(Account, Name)));
            }
        }
    }
}
