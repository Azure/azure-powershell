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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageContainerNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSContainer))]
    public class NewAzureStorageContainerCommand : StorageBlobBaseCmdlet
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
        /// AccountName EncryptionScope Parameter Set
        /// </summary>
        private const string AccountNameEncryptionScopeParameterSet = "AccountNameEncryptionScope";

        /// <summary>
        /// Account object EncryptionScope parameter set 
        /// </summary>
        private const string AccountObjectEncryptionScopeParameterSet = "AccountObjectEncryptionScope";

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
            ParameterSetName = AccountNameEncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

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
            ParameterSetName = AccountNameEncryptionScopeParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectEncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("N", "ContainerName")]
        [Parameter(Mandatory = true, 
            HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Default the container to use specified encryption scope for all writes.",
            Mandatory = true,
            ParameterSetName = AccountNameEncryptionScopeParameterSet)]
        [Parameter(HelpMessage = "Default the container to use specified encryption scope for all writes.",
            Mandatory = true,
            ParameterSetName = AccountObjectEncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DefaultEncryptionScope { get; set; }

        [Parameter(HelpMessage = "Block override of encryption scope from the container default.",
            Mandatory = true,
            ParameterSetName = AccountNameEncryptionScopeParameterSet)]
        [Parameter(HelpMessage = "Block override of encryption scope from the container default.",
            Mandatory = true,
            ParameterSetName = AccountObjectEncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public bool PreventEncryptionScopeOverride
        {
            get
            {
                return preventEncryptionScopeOverride is null ? false : preventEncryptionScopeOverride.Value;
            }
            set
            {
                preventEncryptionScopeOverride = value;
            }
        }
        private bool? preventEncryptionScopeOverride;

        [Parameter(HelpMessage = "Container PublicAccess", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public PSPublicAccess PublicAccess
        {
            get
            {
                return publicAccess.Value;
            }

            set
            {
                publicAccess = value;
            }
        }
        private PSPublicAccess? publicAccess = null;

        [Parameter(HelpMessage = "Container Metadata", Mandatory = false)]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public Hashtable Metadata { get; set; }

        [Parameter(Mandatory = false,
        HelpMessage = "Sets reduction of the access rights for the remote superuser. Possible values include: 'NoRootSquash', 'RootSquash', 'AllSquash'")]
        [ValidateSet(RootSquashType.NoRootSquash,
            RootSquashType.RootSquash,
            RootSquashType.AllSquash,
            IgnoreCase = true)]
        public string RootSquash { get; set; }
        
        [Parameter(HelpMessage = "Enable object level immutability at the container level.", Mandatory = false)]
        public SwitchParameter EnableImmutableStorageWithVersioning { get; set; }        
        
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Create container"))
            {

                if (ParameterSetName == AccountObjectParameterSet)
                {
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                }

                Dictionary<string, string> MetadataDictionary = CreateMetadataDictionary(Metadata, validate: true);

                bool? enableNfsV3RootSquash = null;
                bool? enableNfsV3AllSquash = null;
                if (this.RootSquash != null)
                {
                    if (this.RootSquash.ToLower() == RootSquashType.RootSquash.ToLower())
                    {
                        enableNfsV3RootSquash = true;
                        enableNfsV3AllSquash = false;
                    }
                    if (this.RootSquash.ToLower() == RootSquashType.AllSquash.ToLower())
                    {
                        enableNfsV3RootSquash = false;
                        enableNfsV3AllSquash = true;
                    }
                    if (this.RootSquash.ToLower() == RootSquashType.NoRootSquash.ToLower())
                    {
                        enableNfsV3RootSquash = false;
                        enableNfsV3AllSquash = false;
                    }
                }

                var container =
                    this.StorageClient.BlobContainers.Create(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            this.Name,
                            new BlobContainer(
                                defaultEncryptionScope: this.DefaultEncryptionScope,
                                denyEncryptionScopeOverride: this.preventEncryptionScopeOverride,
                                publicAccess: (PublicAccess?)this.publicAccess,
                                metadata: MetadataDictionary,
                                immutableStorageWithVersioning: this.EnableImmutableStorageWithVersioning.IsPresent ? new ImmutableStorageWithVersioning(true) : null,
                                enableNfsV3RootSquash: enableNfsV3RootSquash,
                                enableNfsV3AllSquash: enableNfsV3AllSquash));

                container =
                    this.StorageClient.BlobContainers.Get(
                            this.ResourceGroupName,
                            this.StorageAccountName,
                            this.Name);

                WriteObject(new PSContainer(container));
            }
        }
    }
}
