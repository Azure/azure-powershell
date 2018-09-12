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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageContainerImmutabilityPolicyNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSImmutabilityPolicy))]
    public class RemoveAzureStorageContainerImmutabilityPolicyCommand : StorageBlobBaseCmdlet
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
        /// Container object Parameter Set
        /// </summary>
        private const string ContainerObjectParameterSet = "ContainerObject";

        /// <summary>
        /// ImmutabilityPolicy object parameter set 
        /// </summary>
        private const string ImmutabilityPolicyObjectParameterSet = "ImmutabilityPolicyObject";

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

        [Alias("N")]
        [Parameter(Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountNameParameterSet)]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage container object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ContainerObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSContainer Container { get; set; }

        [Alias("IfMatch")]
        [Parameter(Mandatory = true,
            HelpMessage = "Immutability policy etag.",
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Immutability policy etag.",
            ParameterSetName = ContainerObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Immutability policy etag.",
            ParameterSetName = AccountNameParameterSet)]
        public string Etag { get; set; }

        [Alias("ImmutabilityPolicy")]
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "ImmutabilityPolicy Object to Remove",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ImmutabilityPolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSImmutabilityPolicy InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.ContainerName, "Remove ImmutabilityPolicy"))
            {
                switch (ParameterSetName)
                {
                    case ContainerObjectParameterSet:
                        this.ResourceGroupName = Container.ResourceGroupName;
                        this.StorageAccountName = Container.StorageAccountName;
                        this.ContainerName = Container.Name;
                        break;
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case ImmutabilityPolicyObjectParameterSet:
                        this.ResourceGroupName = PSContainer.ParseResourceGroupFromId(InputObject.Id);
                        this.StorageAccountName = PSContainer.ParseStorageAccountNameFromId(InputObject.Id);
                        this.ContainerName = PSContainer.ParseStorageContainerNameFromId(InputObject.Id);
                        this.Etag = InputObject.Etag;
                        break;
                    default:
                        break;
                }

                ImmutabilityPolicy policy = this.StorageClient.BlobContainers.DeleteImmutabilityPolicy(
                                                this.ResourceGroupName,
                                                this.StorageAccountName,
                                                this.ContainerName,
                                                this.Etag);

                WriteObject(new PSImmutabilityPolicy(policy));
            }
        }
    }
}
