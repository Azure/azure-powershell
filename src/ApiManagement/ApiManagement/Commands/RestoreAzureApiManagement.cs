//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using Microsoft.WindowsAzure.Storage;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using SdkModels = Microsoft.Azure.Management.ApiManagement.Models;

    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagement"), OutputType(typeof(PsApiManagement))]
    public class RestoreAzureApiManagement : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of the API Management instance that will be restored with this backup.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage context
        /// </summary>
        [Parameter(
            Mandatory = true,
            Position = 1,
            HelpMessage = "The storage connection context.")]
        [ValidateNotNull]
        public IStorageContext StorageContext { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of Azure Storage backup source container.")]
        [ValidateNotNullOrEmpty]
        public string SourceContainerName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of Azure Storage backup source blob.")]
        [ValidateNotNullOrEmpty]
        public string SourceBlobName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The type of access to be used for the storage account. The default value is AccessKey.")]
        [PSArgumentCompleter(SdkModels.AccessType.AccessKey, SdkModels.AccessType.SystemAssignedManagedIdentity, SdkModels.AccessType.UserAssignedManagedIdentity)]
        public string AccessType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Client ID of user assigned managed identity. Required only if accessType is set to UserAssignedManagedIdentity.")]
        public string IdentityClientId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sends restored PsApiManagement to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrWhiteSpace(AccessType))
            {
                this.AccessType = SdkModels.AccessType.AccessKey;
            }

            PsApiManagement apiManagement = null;
            if (this.AccessType == SdkModels.AccessType.AccessKey)
            {
                CloudStorageAccount account = null;
                if (CloudStorageAccount.TryParse(StorageContext.ConnectionString, out account))
                {
                    apiManagement = Client.RestoreApiManagement(
                        ResourceGroupName,
                        Name,
                        account.Credentials.AccountName,
                        account.Credentials.ExportBase64EncodedKey(),
                        SourceContainerName,
                        SourceBlobName,
                        AccessType,
                        IdentityClientId);
                }
                else
                {
                    throw new PSArgumentException("Failed to parse the storage connection string.", nameof(StorageContext));
                }
            }
            else 
            {
                apiManagement = Client.RestoreApiManagement(
                        ResourceGroupName,
                        Name,
                        StorageContext.StorageAccountName,
                        null,
                        SourceContainerName,
                        SourceBlobName,
                        AccessType,
                        IdentityClientId);
            }

            if (PassThru.IsPresent && apiManagement != null)
            {
                this.WriteObject(apiManagement);
            }
        }
    }
}
