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

namespace Microsoft.Azure.Commands.Management.Storage
{
    using Microsoft.Azure.Commands.Management.Storage.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    /// <summary>
    /// Modify Azure Storage service properties
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + StorageBlobServiceProperty, SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSBlobServiceProperties))]
    public class UpdateAzStorageBlobServicePropertyCommand : StorageBlobBaseCmdlet
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

        [Parameter(Mandatory = false, HelpMessage = "Default Service Version to Set")]
        [ValidateNotNull]
        public string DefaultServiceVersion { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Enable Change Feed logging for the storage account by set to $true, disable Change Feed logging by set to $false.")]
        [ValidateNotNullOrEmpty]
        public bool EnableChangeFeed
        {
            get
            {
                return enableChangeFeed is null ? false : enableChangeFeed.Value;
            }
            set
            {
                enableChangeFeed = value;
            }
        }
        private bool? enableChangeFeed = null;

        [Parameter(
        Mandatory = false,
        HelpMessage = "Indicates the duration of changeFeed retention in days. Minimum value is 1 day and maximum value is 146000 days (400 years). Never specify it when enabled changeFeed will get null value in service properties, indicates an infinite retention of the change feed.")]
        [ValidateNotNullOrEmpty]
        public int ChangeFeedRetentionInDays
        {
            get
            {
                return changeFeedRetentionInDays is null ? 0 : changeFeedRetentionInDays.Value;
            }
            set
            {
                changeFeedRetentionInDays = value;
            }
        }
        private int? changeFeedRetentionInDays = null;
        
        [Parameter(
        Mandatory = false,
        HelpMessage = "Gets or sets versioning is enabled if set to true.")]
        [ValidateNotNullOrEmpty]
        public bool IsVersioningEnabled
        {
            get
            {
                return isVersioningEnabled is null ? false : isVersioningEnabled.Value;
            }
            set
            {
                isVersioningEnabled = value;
            }
        }
        private bool? isVersioningEnabled = null;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess("BlobServiceProperties", "Update"))
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
                BlobServiceProperties serviceProperties = new BlobServiceProperties();

                if (DefaultServiceVersion != null)
                {
                    serviceProperties.DefaultServiceVersion = this.DefaultServiceVersion;
                }
                if (enableChangeFeed != null)
                {
                    serviceProperties.ChangeFeed = new ChangeFeed();
                    serviceProperties.ChangeFeed.Enabled = enableChangeFeed;
                    if (this.changeFeedRetentionInDays != null)
                    {
                        serviceProperties.ChangeFeed.RetentionInDays = this.changeFeedRetentionInDays;
                    }
                }
                else
                {
                    if (this.changeFeedRetentionInDays != null)
                    {
                        throw new ArgumentException("ChangeFeed RetentionInDays can only be specified when enable Changefeed.", "ChangeFeedRetentionInDays");
                    }
                }
                if (isVersioningEnabled != null)
                {
                    serviceProperties.IsVersioningEnabled = isVersioningEnabled;
                }

                serviceProperties = this.StorageClient.BlobServices.SetServiceProperties(this.ResourceGroupName, this.StorageAccountName, serviceProperties);

                //Get the full service properties for output
                serviceProperties = this.StorageClient.BlobServices.GetServiceProperties(this.ResourceGroupName, this.StorageAccountName);

                WriteObject(new PSBlobServiceProperties(serviceProperties));
            }
        }
    }
}
