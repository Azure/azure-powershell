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

namespace Microsoft.Azure.Commands.DataShare.DataSetMapping
{
    using System;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the New-DataShareDataSetMapping cmdlet.
    /// </summary>
    [Cmdlet(
         "New",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareDataSetMapping",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true), OutputType(typeof(PSDataShareDataSetMapping))]
    public class NewAzDataShareDataSetMapping : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of the data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// Name of the data set.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data set mapping name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data set mapping name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource Id of Storage Account
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Storage Account ResourceId",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Storage Account ResourceId",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter(ResourceTypes.StorageAccount)]
        public string StorageAccountResourceId { get; set; }

        /// <summary>
        ///Data set id of consumer data set.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Consumer data set id",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Consumer data set id",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DataSetId { get; set; }

        /// <summary>
        /// Container name of storage account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure storage account container name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        /// <summary>
        /// File system name of ADLS gen2 storage account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure ADLS gen2 file system name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        /// <summary>
        /// File path of data set.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure storage file path",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure storage file path",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        /// <summary>
        /// Folder path of data set
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure storage folder path",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure storage folder path",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        public string FolderPath { get; set; }

        private const string ResourceType = "DataSetMapping";

        public override void ExecuteCmdlet()
        {
            var parsedStorageResourceId = new ResourceIdentifier(this.StorageAccountResourceId);
            string storageSubscriptionId = parsedStorageResourceId.Subscription;
            string storageResourceGroup = parsedStorageResourceId.ResourceGroupName;
            string storageAccountName = parsedStorageResourceId.GetStorageAccountName();

            if (this.ParameterSetName.Equals(
                ParameterSetNames.BlobDataSetParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareDataSetMapping.ResourceType)))
                {
                    if (this.FilePath != null)
                    {

                        var newDataSetMapping = (BlobDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new BlobDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                ContainerName = this.Container,
                                FilePath = this.FilePath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());

                    }
                    else if (this.FolderPath != null)
                    {

                        var newDataSetMapping = (BlobFolderDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new BlobFolderDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                ContainerName = this.Container,
                                Prefix = this.FolderPath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());

                    }
                    else
                    {

                        var newDataSetMapping = (BlobContainerDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new BlobContainerDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                ContainerName = this.Container,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());
                    }
                }
            }

            if (this.ParameterSetName.Equals(
                ParameterSetNames.AdlsGen2DataSetParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {

                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareDataSetMapping.ResourceType)))
                {
                    if (this.FilePath != null)
                    {

                        var newDataSetMapping = (ADLSGen2FileDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new ADLSGen2FileDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                FileSystem = this.FileSystem,
                                FilePath = this.FilePath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());

                    }
                    else if (this.FolderPath != null)
                    {

                        var newDataSetMapping = (ADLSGen2FolderDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new ADLSGen2FolderDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                FileSystem = this.FileSystem,
                                FolderPath = this.FolderPath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());

                    }
                    else
                    {

                        var newDataSetMapping = (ADLSGen2FileSystemDataSetMapping)this.DataShareManagementClient.DataSetMappings.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareSubscriptionName,
                            this.Name,
                            new ADLSGen2FileSystemDataSetMapping()
                            {
                                DataSetId = this.DataSetId,
                                FileSystem = this.FileSystem,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSetMapping.ToPsObject());
                    }
                }
            }
        }
    }
}
