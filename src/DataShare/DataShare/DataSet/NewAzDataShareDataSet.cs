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

namespace Microsoft.Azure.Commands.DataShare.DataSet
{
    using System;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;

    /// <summary>
    /// Defines the New-DataShareDataSet cmdlet.
    /// </summary>
    [Cmdlet(
         "New",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareDataSet",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet,
         SupportsShouldProcess = true), OutputType(typeof(PSDataShareDataSet))]
    public class NewAzDataShareDataSet : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the data share account name.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
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
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of the data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// Name of the data set.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data set name",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data set name",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data set name",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Resource id of storage account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure storage account resourceId",
            ParameterSetName = ParameterSetNames.BlobDataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure storage account resourceId",
            ParameterSetName = ParameterSetNames.AdlsGen2DataSetParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure storage account resourceId",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.StorageAccount, "ResourceGroupName")]
        public string StorageAccountResourceId { get; set; }

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
        /// File path of blob data set.
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
        /// Folder path of blob data set.
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

        /// <summary>
        /// ADLS gen1 file name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure storage ADLS gen1 file name",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileName { get; set; }

        /// <summary>
        /// ADLS gen1 folder path.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure storage ADLS gen1 folder path",
            ParameterSetName = ParameterSetNames.AdlsGen1DataSetParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AdlsGen1FolderPath { get; set; }

        private const string ResourceType = "DataSet";

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
                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareDataSet.ResourceType)))
                {
                    if (this.FilePath != null)
                    {

                        var newDataSet = (BlobDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new BlobDataSet()
                            {
                                ContainerName = this.Container,
                                FilePath = this.FilePath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());

                    }
                    else if (this.FolderPath != null)
                    {

                        var newDataSet = (BlobFolderDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new BlobFolderDataSet()
                            {
                                ContainerName = this.Container,
                                Prefix = this.FolderPath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());

                    }
                    else
                    {

                        var newDataSet = (BlobContainerDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new BlobContainerDataSet()
                            {
                                ContainerName = this.Container,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());
                    }
                }
            }

            if (this.ParameterSetName.Equals(
                ParameterSetNames.AdlsGen2DataSetParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {

                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareDataSet.ResourceType)))
                {
                    if (this.FilePath != null)
                    {

                        var newDataSet = (ADLSGen2FileDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new ADLSGen2FileDataSet()
                            {
                                FileSystem = this.FileSystem,
                                FilePath = this.FilePath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());

                    }
                    else if (this.FolderPath != null)
                    {

                        var newDataSet = (ADLSGen2FolderDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new ADLSGen2FolderDataSet()
                            {
                                FileSystem = this.FileSystem,
                                FolderPath = this.FolderPath,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());

                    }
                    else
                    {

                        var newDataSet = (ADLSGen2FileSystemDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new ADLSGen2FileSystemDataSet()
                            {
                                FileSystem = this.FileSystem,
                                ResourceGroup = storageResourceGroup,
                                StorageAccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());
                    }
                }
            }

            if (this.ParameterSetName.Equals(
                ParameterSetNames.AdlsGen1DataSetParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                storageAccountName = parsedStorageResourceId.GetAccountName();

                if (this.ShouldProcess(this.Name, string.Format(Resources.ResourceCreateMessage, NewAzDataShareDataSet.ResourceType)))
                {
                    if (this.FileName != null)
                    {
                        var newDataSet = (ADLSGen1FileDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new ADLSGen1FileDataSet()
                            {
                                FileName = this.FileName,
                                FolderPath = this.AdlsGen1FolderPath,
                                ResourceGroup = storageResourceGroup,
                                AccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());
                    }
                    else
                    {
                        var newDataSet = (ADLSGen1FolderDataSet)this.DataShareManagementClient.DataSets.Create(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.Name,
                            new ADLSGen1FolderDataSet()
                            {
                                FolderPath = this.AdlsGen1FolderPath,
                                ResourceGroup = storageResourceGroup,
                                AccountName = storageAccountName,
                                SubscriptionId = storageSubscriptionId
                            });

                        this.WriteObject(newDataSet.ToPsObject());
                    }
                }
            }
        }
    }
}
