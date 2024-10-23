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
using Microsoft.Rest.Azure;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccount"), OutputType(typeof(PSStorageAccount))]
    public class GetAzureStorageAccountCommand : StorageAccountBaseCmdlet
    {
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string AccountNameParameterSet = "AccountNameParameterSet";
        protected const string BlobRestoreStatusParameterSet = "BlobRestoreStatusParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = AccountNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = BlobRestoreStatusParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountNameParameterSet,
            HelpMessage = "Storage Account Name.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = BlobRestoreStatusParameterSet,
            HelpMessage = "Storage Account Name.")]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = AccountNameParameterSet,
            HelpMessage = "Get the GeoReplicationStats of the Storage account.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeGeoReplicationStats { get; set; }
        
       [Parameter(
            Mandatory = true,
            ParameterSetName = BlobRestoreStatusParameterSet,
            HelpMessage = "Get the BlobRestoreStatus of the Storage account.")]
        public SwitchParameter IncludeBlobRestoreStatus { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(this.ResourceGroupName))
            {
                IPage<Microsoft.Azure.Management.Storage.Models.StorageAccount> storageAccounts = this.StorageClient.StorageAccounts.List();
                WriteStorageAccountList(storageAccounts, DefaultContext);

                while (storageAccounts.NextPageLink != null)
                {
                    storageAccounts = this.StorageClient.StorageAccounts.ListNext(storageAccounts.NextPageLink);
                    WriteStorageAccountList(storageAccounts, DefaultContext);
                }
            }
            else if (string.IsNullOrEmpty(this.Name))
            {
                IPage<Microsoft.Azure.Management.Storage.Models.StorageAccount> storageAccounts = this.StorageClient.StorageAccounts.ListByResourceGroup(this.ResourceGroupName);
                WriteStorageAccountList(storageAccounts, DefaultContext);

                while (storageAccounts.NextPageLink != null)
                {
                    storageAccounts = this.StorageClient.StorageAccounts.ListByResourceGroupNext(storageAccounts.NextPageLink);
                    WriteStorageAccountList(storageAccounts, DefaultContext);
                }
            }
            else
            {
                // ParameterSet ensure can only set one of the following 2 parameters
                StorageAccountExpand? expandproperties = null;
                if (this.IncludeGeoReplicationStats)
                {
                    expandproperties = StorageAccountExpand.GeoReplicationStats;
                }
                if (this.IncludeBlobRestoreStatus)
                {
                    expandproperties = StorageAccountExpand.BlobRestoreStatus;
                }

                var storageAccount = this.StorageClient.StorageAccounts.GetProperties(
                    this.ResourceGroupName,
                    this.Name,
                    expandproperties);

                WriteStorageAccount(storageAccount, DefaultContext);
            }
        }
    }
}
