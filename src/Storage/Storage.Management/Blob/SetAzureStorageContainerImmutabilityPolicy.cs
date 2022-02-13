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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageContainerImmutabilityPolicyNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSImmutabilityPolicy))]
    public class SetAzureStorageContainerImmutabilityPolicyCommand : StorageBlobBaseCmdlet
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

        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string ExtendAccountNameParameterSet = "ExtendAccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string ExtendAccountObjectParameterSet = "ExtendAccountObject";

        /// <summary>
        /// Container object Parameter Set
        /// </summary>
        private const string ExtendContainerObjectParameterSet = "ExtendContainerObject";

        /// <summary>
        /// ImmutabilityPolicy object parameter set 
        /// </summary>
        private const string ExtendImmutabilityPolicyObjectParameterSet = "ExtendImmutabilityPolicyObject";


        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = ExtendAccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias(AccountNameAlias)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = ExtendAccountNameParameterSet)]
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
        [Parameter(Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExtendAccountObjectParameterSet)]
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExtendAccountNameParameterSet)]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExtendAccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage container object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ContainerObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage container object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExtendContainerObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSContainer Container { get; set; }

        [Alias("ImmutabilityPolicy")]
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ImmutabilityPolicyObjectParameterSet)]
        [Parameter(Position = 0,
            Mandatory = true,
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExtendImmutabilityPolicyObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSImmutabilityPolicy InputObject { get; set; }

        [Alias("ImmutabilityPeriodSinceCreationInDays")]
        [Parameter(Mandatory = false, ParameterSetName = AccountNameParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = false, ParameterSetName = AccountObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = false, ParameterSetName = ContainerObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = false, ParameterSetName = ImmutabilityPolicyObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendAccountNameParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendAccountObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendContainerObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendImmutabilityPolicyObjectParameterSet, HelpMessage = "Immutability period since creation in days.")]
        public int ImmutabilityPeriod
        {
            get
            {
                return immutabilityPeriod is null ? 0 : immutabilityPeriod.Value;
            }
            set
            {
                immutabilityPeriod = value;
            }
        }

        public int? immutabilityPeriod;

        [Parameter(Mandatory = false, ParameterSetName = AccountNameParameterSet, HelpMessage = "This property can only be changed for unlocked policies. When enabled, new blocks can be written to both 'Appened and Block Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = AccountObjectParameterSet, HelpMessage = "This property can only be changed for unlocked policies. When enabled, new blocks can be written to both 'Appened and Block Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = ContainerObjectParameterSet, HelpMessage = "This property can only be changed for unlocked policies. When enabled, new blocks can be written to both 'Appened and Block Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = ImmutabilityPolicyObjectParameterSet, HelpMessage = "This property can only be changed for unlocked policies. When enabled, new blocks can be written to both 'Appened and Block Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        public bool AllowProtectedAppendWriteAll
        {
            get
            {
                return allowProtectedAppendWriteAll is null ? false : allowProtectedAppendWriteAll.Value;
            }
            set
            {
                allowProtectedAppendWriteAll = value;
            }
        }
        private bool? allowProtectedAppendWriteAll;

        [Parameter(Mandatory = false, ParameterSetName = AccountNameParameterSet, HelpMessage = "This property can only be changed for unlocked time-based retention policies. With this property enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = AccountObjectParameterSet, HelpMessage = "This property can only be changed for unlocked time-based retention policies. With this property enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = ContainerObjectParameterSet, HelpMessage = "This property can only be changed for unlocked time-based retention policies. With this property enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        [Parameter(Mandatory = false, ParameterSetName = ImmutabilityPolicyObjectParameterSet, HelpMessage = "This property can only be changed for unlocked time-based retention policies. With this property enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. '-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive.")]
        public bool AllowProtectedAppendWrite
        {
            get
            {
                return allowProtectedAppendWrite is null ? false : allowProtectedAppendWrite.Value;
            }
            set
            {
                allowProtectedAppendWrite = value;
            }
        }
        private bool? allowProtectedAppendWrite;

        [Alias("IfMatch")]
        [Parameter(Mandatory = false, ParameterSetName = AccountNameParameterSet, HelpMessage = "Immutability policy etag.")]
        [Parameter(Mandatory = false, ParameterSetName = AccountObjectParameterSet, HelpMessage = "Immutability policy etag.")]
        [Parameter(Mandatory = false, ParameterSetName = ContainerObjectParameterSet, HelpMessage = "Immutability policy etag.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendAccountNameParameterSet, HelpMessage = "Immutability policy etag.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendAccountObjectParameterSet, HelpMessage = "Immutability policy etag.")]
        [Parameter(Mandatory = true, ParameterSetName = ExtendContainerObjectParameterSet, HelpMessage = "Immutability policy etag.")]
        public string Etag { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Indicate ExtendPolicy to Extend an existing ImmutabilityPolicy.", ParameterSetName = ExtendAccountNameParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Indicate ExtendPolicy to Extend an existing ImmutabilityPolicy.", ParameterSetName = ExtendAccountObjectParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Indicate ExtendPolicy to Extend an existing ImmutabilityPolicy.", ParameterSetName = ExtendContainerObjectParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Indicate ExtendPolicy to Extend an existing ImmutabilityPolicy.", ParameterSetName = ExtendImmutabilityPolicyObjectParameterSet)]
        public SwitchParameter ExtendPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if ((this.allowProtectedAppendWrite.HasValue && this.allowProtectedAppendWrite.Value) && 
                (this.allowProtectedAppendWriteAll.HasValue && this.allowProtectedAppendWriteAll.Value))
            {
                throw new ArgumentException("'-AllowProtectedAppendWrites' and '-AllowProtectedAppendWritesAll' are mutually exclusive. They can't be set both to true.");
            }
            if (ShouldProcess(this.ContainerName, "Set container ImmutabilityPolicy"))
            {

                switch (ParameterSetName)
                {
                    case ContainerObjectParameterSet:
                    case ExtendContainerObjectParameterSet:
                        this.ResourceGroupName = Container.ResourceGroupName;
                        this.StorageAccountName = Container.StorageAccountName;
                        this.ContainerName = Container.Name;
                        break;
                    case AccountObjectParameterSet:
                    case ExtendAccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case ImmutabilityPolicyObjectParameterSet:
                    case ExtendImmutabilityPolicyObjectParameterSet:
                        this.ResourceGroupName = PSContainer.ParseResourceGroupFromId(InputObject.Id);
                        this.StorageAccountName = PSContainer.ParseStorageAccountNameFromId(InputObject.Id);
                        this.ContainerName = PSContainer.ParseStorageContainerNameFromId(InputObject.Id);
                        this.Etag = InputObject.Etag;
                        break;
                    default:
                        break;
                }

                ImmutabilityPolicy policy;
                if (!ExtendPolicy.IsPresent)
                {
                    policy = this.StorageClient.BlobContainers.CreateOrUpdateImmutabilityPolicy(
                                this.ResourceGroupName,
                                this.StorageAccountName,
                                this.ContainerName,
                                new ImmutabilityPolicy(
                                    immutabilityPeriodSinceCreationInDays: immutabilityPeriod,
                                    allowProtectedAppendWrites: this.allowProtectedAppendWrite,
                                    allowProtectedAppendWritesAll: this.allowProtectedAppendWriteAll),
                                this.Etag);
                }
                else
                {
                    policy = this.StorageClient.BlobContainers.ExtendImmutabilityPolicy(
                                this.ResourceGroupName,
                                this.StorageAccountName,
                                this.ContainerName,
                                this.Etag,
                                new ImmutabilityPolicy(
                                    immutabilityPeriodSinceCreationInDays: immutabilityPeriod));
                }
                WriteObject(new PSImmutabilityPolicy(policy));
            }
        }
    }
}
