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

    /// <summary>
    /// Modify Azure Storage service properties
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + StorageFileServiceProperty, SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSFileServiceProperties))]
    public class UpdateAzStorageFileServicePropertyCommand : StorageFileBaseCmdlet
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
        private const string PropertiesResourceIdParameterSet = "FileServicePropertiesResourceId";

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
            HelpMessage = "Input a Storage account Resource Id, or a File service properties Resource Id.",
           ParameterSetName = PropertiesResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
        Mandatory = false,
        HelpMessage = "Enable share Delete Retention Policy for the storage account by set to $true, disable share Delete Retention Policy  by set to $false.")]
        [ValidateNotNullOrEmpty]
        public bool EnableShareDeleteRetentionPolicy
        {
            get
            {
                return enableShareDeleteRetentionPolicy is null ? false : enableShareDeleteRetentionPolicy.Value;
            }
            set
            {
                enableShareDeleteRetentionPolicy = value;
            }
        }
        private bool? enableShareDeleteRetentionPolicy = null;

        [Parameter(Mandatory = false, HelpMessage = "Sets the number of retention days for the share DeleteRetentionPolicy. The value should only be set when enable share Delete Retention Policy.")]
        [Alias("Days", "RetentionDays")]
        public int ShareRetentionDays
        {
            get
            {
                return shareRetentionDays is null ? 0 : shareRetentionDays.Value;
            }
            set
            {
                shareRetentionDays = value;
            }
        }
        private int? shareRetentionDays = null;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Check input parameter
            // ShareRetentionDays should only be specified when EnableShareDeleteRetentionPolicy is true
            if (this.enableShareDeleteRetentionPolicy == null || this.enableShareDeleteRetentionPolicy.Value == false)
            {
                if (this.ShareRetentionDays != 0)
                {
                    throw new ArgumentException("ShareRetentionDays should only be specified when EnableShareDeleteRetentionPolicy is true.");
                }
            }
            else
            {
                if (this.ShareRetentionDays == 0)
                {
                    throw new ArgumentException("ShareRetentionDays must be specified when EnableShareDeleteRetentionPolicy is true.");
                }
            }

            if (ShouldProcess("FileServiceProperties", "Update"))
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
                DeleteRetentionPolicy deleteRetentionPolicy = null;
                if (this.enableShareDeleteRetentionPolicy != null)
                {
                    deleteRetentionPolicy = new DeleteRetentionPolicy();
                    deleteRetentionPolicy.Enabled = this.enableShareDeleteRetentionPolicy.Value;
                    if (this.enableShareDeleteRetentionPolicy.Value == true)
                    {
                        deleteRetentionPolicy.Days = ShareRetentionDays;
                    }
                }

                FileServiceProperties serviceProperties = this.StorageClient.FileServices.SetServiceProperties(this.ResourceGroupName, this.StorageAccountName, 
                    shareDeleteRetentionPolicy: deleteRetentionPolicy);

                // Get all File service properties from server for output
                serviceProperties = this.StorageClient.FileServices.GetServiceProperties(this.ResourceGroupName, this.StorageAccountName);

                WriteObject(new PSFileServiceProperties(serviceProperties));
            }
        }
    }
}
