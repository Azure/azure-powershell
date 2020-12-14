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
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageContainerNounStr, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSContainer))]
    public class GetAzureStorageContainerCommand : StorageBlobBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("N", "ContainerName")]
        [Parameter(HelpMessage = "Container Name",
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ParameterSetName == AccountObjectParameterSet)
            {
                this.ResourceGroupName = StorageAccount.ResourceGroupName;
                this.StorageAccountName = StorageAccount.StorageAccountName;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var container = this.StorageClient.BlobContainers.Get(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           this.Name);
                WriteObject(new PSContainer(container));
            }
            else
            {
                IPage<ListContainerItem> containerlistResult = this.StorageClient.BlobContainers.List(
                               this.ResourceGroupName,
                               this.StorageAccountName);
                WriteContainerList(containerlistResult);
                while (containerlistResult.NextPageLink != null)
                {
                    containerlistResult = this.StorageClient.BlobContainers.ListNext(containerlistResult.NextPageLink);
                    WriteContainerList(containerlistResult);
                }
            }
        }
    }
}
