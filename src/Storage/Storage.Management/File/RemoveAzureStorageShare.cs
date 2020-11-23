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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageShareNounStr, DefaultParameterSetName = AccountNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureStorageShareCommand : StorageFileBaseCmdlet
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
        /// ShareObject Parameter Set
        /// </summary>
        private const string ShareObjectParameterSet = "ShareObject";

        /// <summary>
        /// Share ResourceId  parameter set 
        /// </summary>
        private const string ShareResourceIdParameterSet = "ShareResourceId";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Alias("N", "ShareName")]
        [Parameter(Mandatory = true,
            HelpMessage = "Share Name",
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "Share Name",
            ParameterSetName = AccountNameParameterSet)]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Input a File Share Resource Id.",
           ParameterSetName = ShareResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("Share")]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage Share object",
            ValueFromPipeline = true,
            ParameterSetName = ShareObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSShare InputObject { get; set; }

        [Parameter(HelpMessage = "Force to remove the Share and all content in it")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (ShouldProcess(this.Name, "Remove Share"))
            {
                switch (ParameterSetName)
                {
                    case ShareObjectParameterSet:
                        this.ResourceGroupName = InputObject.ResourceGroupName;
                        this.StorageAccountName = InputObject.StorageAccountName;
                        this.Name = InputObject.Name;
                        break;
                    case AccountObjectParameterSet:
                        this.ResourceGroupName = StorageAccount.ResourceGroupName;
                        this.StorageAccountName = StorageAccount.StorageAccountName;
                        break;
                    case ShareResourceIdParameterSet:
                        ResourceIdentifier shareResource = new ResourceIdentifier(ResourceId);
                        this.ResourceGroupName = shareResource.ResourceGroupName;
                        this.StorageAccountName = PSBlobServiceProperties.GetStorageAccountNameFromResourceId(ResourceId);
                        this.Name = shareResource.ResourceName;
                        break;
                    default:
                        break;
                }
                if (Force.IsPresent || ShouldContinue(String.Format("Remove Share and all files in it: {0}", this.Name), ""))
                {
                    this.StorageClient.FileShares.Delete(
                       this.ResourceGroupName,
                       this.StorageAccountName,
                       this.Name);

                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
