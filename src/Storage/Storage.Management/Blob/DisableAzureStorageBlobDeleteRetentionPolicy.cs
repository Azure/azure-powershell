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

using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    using Microsoft.Azure.Commands.Management.Storage.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    /// <summary>
    /// Modify Azure Storage service properties
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + StorageBlobDeleteRetentionPolicy, SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSDeleteRetentionPolicy))]
    public class DisableAzStorageBlobDeleteRetentionPolicyCommand : StorageBlobBaseCmdlet
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
        /// BlobServiceProperties ResourceId  parameter set 
        /// </summary>
        private const string PropertiesResourceIdParameterSet = "BlobServicePropertiesResourceId";

        [Parameter(
          Position = 0,
          Mandatory = true,
          HelpMessage = "Resource Group Name.",
         ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias, NameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Input a Storage account Resource Id, or a Blob service properties Resource Id.",
           ParameterSetName = PropertiesResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display ServiceProperties")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess("BlobDeleteRetentionPolicy", "Disable"))
            {
                switch (ParameterSetName)
                {
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case PropertiesResourceIdParameterSet:
                        ResourceIdentifier blobServicePropertiesResource = new ResourceIdentifier(ResourceId);
                        this.ResourceGroupName = blobServicePropertiesResource.ResourceGroupName;
                        this.StorageAccountName = PSBlobServiceProperties.GetStorageAccountNameFromResourceId(ResourceId);
                        break;
                    default:
                        // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                        break;
                }

                Track2.BlobServiceData data = new Track2.BlobServiceData();
                data.DeleteRetentionPolicy = new Track2Models.DeleteRetentionPolicy
                {
                    Enabled = false,
                    Days = null,
                };

                Track2.BlobServiceResource properties = this.StorageClientTrack2.GetBlobServiceResource(this.ResourceGroupName, this.StorageAccountName)
                    .CreateOrUpdate(global::Azure.WaitUntil.Completed, data).Value;
                    
                if (PassThru)
                {
                    WriteObject(new PSDeleteRetentionPolicy(properties.Data.DeleteRetentionPolicy));
                }

            }
        }
    }
}
