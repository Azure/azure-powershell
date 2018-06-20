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
    using Microsoft.WindowsAzure.Commands.Storage.Adapters;
    using System.Management.Automation;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsData.Backup, "AzureRmApiManagement"), OutputType(typeof(PsApiManagement))]
    public class BackupAzureApiManagement : AzureApiManagementCmdletBase
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
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the storage context
        /// </summary>
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "The storage connection context.")]
        [ValidateNotNull]
        public IStorageContext StorageContext { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of target Azure Storage container. If container does not exist it will be created.")]
        [ValidateNotNullOrEmpty]
        public string TargetContainerName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of target Azure Storage blob. If the blob does not exist it will be created.")]
        public string TargetBlobName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sends backed up PsApiManagement to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var account = StorageContext.GetCloudStorageAccount();
            var apiManagementResource = Client.BackupApiManagement(
                ResourceGroupName,
                Name,
                account.Credentials.AccountName,
                account.Credentials.ExportBase64EncodedKey(),
                TargetContainerName,
                TargetBlobName);

            if (PassThru.IsPresent)
            {
                this.WriteObject(apiManagementResource);
            }
        }
    }
}