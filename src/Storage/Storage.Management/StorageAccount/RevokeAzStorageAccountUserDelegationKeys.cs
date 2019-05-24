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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Revoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountUserDelegationKeys", SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(bool))]
    public class RevokeAzureStorageAccountUserDelegationKeysCommand : StorageAccountBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// Account ResourceId  parameter set 
        /// </summary>
        private const string AccountResourceIdParameterSet = "AccountResourceId";

        [Parameter(
          Position = 0,
          Mandatory = true,
          HelpMessage = "The resource group name containing the storage account resource.",
         ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "The name of the storage account resource.",
           ParameterSetName = AccountNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias, NameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "A storage account object, returned by Get_AzStorageAccount, New-AzStorageAccount.",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Alias("StorageAccount")]        
        [ValidateNotNullOrEmpty]
        public PSStorageAccount InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Resource Id.",
           ParameterSetName = AccountResourceIdParameterSet)]
        [Alias("StorageAccountResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess(this.StorageAccountName, "Remove Storage Account user delegation keys"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.StorageAccountName = InputObject.StorageAccountName;
                        break;
                    case AccountResourceIdParameterSet:
                        ResourceIdentifier accountResource = new ResourceIdentifier(ResourceId);
                        this.ResourceGroupName = accountResource.ResourceGroupName;
                        this.StorageAccountName = accountResource.ResourceName;
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }

                this.StorageClient.StorageAccounts.RevokeUserDelegationKeys(
                    this.ResourceGroupName,
                    this.StorageAccountName);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
