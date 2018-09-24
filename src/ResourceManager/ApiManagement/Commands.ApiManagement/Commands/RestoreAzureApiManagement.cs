﻿//  
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
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using WindowsAzure.Commands.Storage.Adapters;

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
            HelpMessage = "Sends restored PsApiManagement to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var account = StorageContext.GetCloudStorageAccount();
            var apimanagementResource = Client.RestoreApiManagement(
                    ResourceGroupName,
                    Name,
                    account.Credentials.AccountName,
                    account.Credentials.ExportBase64EncodedKey(),
                    SourceContainerName,
                    SourceBlobName);

            if (PassThru.IsPresent)
            {
                this.WriteObject(apimanagementResource);
            }
        }
    }
}
