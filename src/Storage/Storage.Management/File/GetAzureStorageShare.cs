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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageShareNounStr, DefaultParameterSetName = AccountNameSingleParameterSet), OutputType(typeof(PSShare))]
    public class GetAzureStorageShareCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName list Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object list parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameSingleParameterSet = "AccountNameSingle";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectSingleParameterSet = "AccountObjectSingle";

        /// <summary>
        /// Share ResourceId  parameter set 
        /// </summary>
        private const string ShareResourceIdParameterSet = "ShareResourceId";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameSingleParameterSet)]
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
            ParameterSetName = AccountNameSingleParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectSingleParameterSet)]
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

        [Alias("N", "ShareName")]
        [Parameter(HelpMessage = "Share Name",
            Mandatory = true,
            ParameterSetName = AccountObjectSingleParameterSet)]
        [Parameter(HelpMessage = "Share Name",
            Mandatory = false,
            ParameterSetName = AccountNameSingleParameterSet)]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Share SnapshotTime",
            Mandatory = false,
            ParameterSetName = AccountObjectSingleParameterSet)]
        [Parameter(HelpMessage = "Share SnapshotTime",
            Mandatory = false,
            ParameterSetName = AccountNameSingleParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTime? SnapshotTime { get; set; }

        [Parameter(HelpMessage = "Specify this parameter to get the Share Usage in Bytes.",
            Mandatory = false,
            ParameterSetName = AccountObjectSingleParameterSet)]
        [Parameter(HelpMessage = "Specify this parameter to get the Share Usage in Bytes.",
            Mandatory = false,
            ParameterSetName = AccountNameSingleParameterSet)]
        [Parameter(HelpMessage = "Specify this parameter to get the Share Usage in Bytes.",
            Mandatory = false,
            ParameterSetName = ShareResourceIdParameterSet)]
        public SwitchParameter GetShareUsage { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Include deleted shares, by default list shares won't include deleted shares",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "Include deleted shares, by default list shares won't include deleted shares",
            ParameterSetName = AccountObjectParameterSet)]
        public SwitchParameter IncludeDeleted { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Include share snapshots, by default list shares won't include share snapshots.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "Include share snapshots, by default list shares won't include share snapshots.",
            ParameterSetName = AccountObjectParameterSet)]
        public SwitchParameter IncludeSnapshot { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectSingleParameterSet:
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                case ShareResourceIdParameterSet:
                    if (!string.IsNullOrEmpty(this.Name))
                    {
                        WriteWarning("The -Name parameter will be omit, as -ResourceId already contains share name.");
                    }
                    ResourceIdentifier shareResource = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = shareResource.ResourceGroupName;
                    this.StorageAccountName = PSBlobServiceProperties.GetStorageAccountNameFromResourceId(ResourceId);
                    this.Name = shareResource.ResourceName;
                    break;
                default:
                    // For AccountNameParameterSet, AccountNameSingleParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                string expend = null;
                if(this.GetShareUsage)
                {
                    expend = ShareGetExpand.Stats;
                }
                var Share = this.StorageClient.FileShares.Get(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           this.Name,
                           expend,
                           xMsSnapshot: this.SnapshotTime is null? null : this.SnapshotTime.Value.ToUniversalTime().ToString("o"));
                WriteObject(new PSShare(Share));
            }
            else
            {
                string listSharesExpand = null;
                if (this.IncludeDeleted.IsPresent)
                {
                    listSharesExpand = ShareListExpand.Deleted;
                }
                if (this.IncludeSnapshot.IsPresent)
                {
                    listSharesExpand = string.IsNullOrEmpty(listSharesExpand) ? ShareListExpand.Snapshots : listSharesExpand + "," + ShareListExpand.Snapshots;
                }
                IPage<FileShareItem> shares = this.StorageClient.FileShares.List(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           expand: listSharesExpand);
                WriteShareList(shares);
                while (shares.NextPageLink != null)
                {
                    shares = this.StorageClient.FileShares.ListNext(shares.NextPageLink);
                    WriteShareList(shares);
                }
            }
        }
    }
}
