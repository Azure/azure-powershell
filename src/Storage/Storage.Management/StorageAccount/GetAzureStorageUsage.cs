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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage.StorageAccount
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageUsage"), OutputType(typeof(PSUsage))]
    public class GetAzureStorageUsageCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Accounts Location.")]
        [LocationCompleter("Microsoft.Storage/storageAccounts")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            //Get usage
            IEnumerable<Usage> usages = this.StorageClient.Usages.ListByLocation(Location);

            //Output usage
            foreach (var usage in usages)
            {
                WriteObject(new PSUsage()
                {
                    LocalizedName = usage.Name.LocalizedValue,
                    Name = usage.Name.Value,
                    Unit = usage.Unit,
                    CurrentValue = usage.CurrentValue,
                    Limit = usage.Limit
                });
            }
        }
    }
}
