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
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageContainerNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSContainer))]
    public class UpdateAzureStorageContainerCommand : StorageBlobBaseCmdlet
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
        /// ContainerObject Parameter Set
        /// </summary>
        private const string ContainerObjectParameterSet = "ContainerObject";

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

        [Alias("N", "ContainerName")]
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
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("Container")]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage container object",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ContainerObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSContainer InputObject { get; set; }

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

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case ContainerObjectParameterSet:
                    this.ResourceGroupName = InputObject.ResourceGroupName;
                    this.StorageAccountName = InputObject.StorageAccountName;
                    this.Name = InputObject.Name;
                    break;
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                default:
                    break;
            }

            if (ShouldProcess(this.Name, "Update container"))
            {
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

                var container = this.StorageClient.BlobContainers.Update(
                                    this.ResourceGroupName,
                                    this.StorageAccountName,
                                    this.Name,
                                    new BlobContainer(
                                        publicAccess: (PublicAccess?)this.publicAccess,
                                        metadata: MetadataDictionary,
                                        enableNfsV3RootSquash: enableNfsV3RootSquash,
                                        enableNfsV3AllSquash: enableNfsV3AllSquash));

                WriteObject(new PSContainer(container));
            }
        }
    }
}
