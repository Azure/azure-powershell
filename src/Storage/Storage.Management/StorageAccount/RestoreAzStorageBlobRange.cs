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

using Azure;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobRange", SupportsShouldProcess = true, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSBlobRestoreStatus))]
    public class RestoreAzureStorageBlobRangeCommand : StorageAccountBaseCmdlet
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
        /// Account ResourceId  parameter set 
        /// </summary>
        private const string AccountResourceIdParameterSet = "AccountResourceId";

        [Parameter(
         Position = 0,
         Mandatory = true,
         HelpMessage = "Resource Group Name.",
        ParameterSetName = AccountNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
           ParameterSetName = AccountNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Storage/storageAccounts", nameof(ResourceGroupName))]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Resource Id.",
           ParameterSetName = AccountResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Time to Restore Blob.")]
        [ValidateNotNull]
        public DateTimeOffset TimeToRestore { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The blob range to Restore.")]
        [ValidateNotNull]
        public PSBlobRestoreRange[] BlobRestoreRange { get; set; }

        [Parameter(HelpMessage = "Wait for Restore task complete")]
        public SwitchParameter WaitForComplete
        {
            get { return waitForComplete; }
            set { waitForComplete = value; }
        }
        private bool waitForComplete;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                case AccountResourceIdParameterSet:
                    ResourceIdentifier accountResource = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = accountResource.ResourceGroupName;
                    this.StorageAccountName = accountResource.ResourceName;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (ShouldProcess(this.StorageAccountName, "Restore Blob Range"))
            {
                Track2.StorageAccountResource account = this.StorageClientTrack2.GetStorageAccount(this.ResourceGroupName, this.StorageAccountName);
                var restoreLro = account.RestoreBlobRanges(
                    WaitUntil.Started,
                    new Track2Models.BlobRestoreContent(
                        this.TimeToRestore.ToUniversalTime(),
                        PSBlobRestoreRange.ParseBlobRestoreRanges(this.BlobRestoreRange)));

                // This is a temporary workaround of SDK issue https://github.com/Azure/azure-sdk-for-net/issues/29060
                // The workaround is to get the raw response and parse it into the output desired
                // The Blob restore status should be got from SDK directly once the issue is fixed
                Dictionary<string, object> temp = restoreLro.GetRawResponse().Content.ToObjectFromJson() as Dictionary<string, object>;

                if (waitForComplete)
                {
                    if (temp == null)
                    {
                        throw new InvalidJobStateException("Could not fetch the Blob restore response.");
                    }
                    PSBlobRestoreStatus blobRestoreStatus = ParseRestoreRawResponse(temp);
                    if (blobRestoreStatus.RestoreId != null)
                    {
                        WriteWarning(string.Format("Restore blob ranges with Id '{0}' started. Restore blob ranges time to complete is dependent on the size of the restore.", blobRestoreStatus.RestoreId));
                    }
                    else
                    {
                        WriteWarning(string.Format("Could not fetch the Restore Id."));
                    }

                    try
                    {
                        var result = restoreLro.WaitForCompletion().Value;
                        WriteObject(new PSBlobRestoreStatus(result));
                    }
                    catch (System.AggregateException ex) when (ex.InnerException is CloudException)
                    {
                        throw new InvalidJobStateException(string.Format("Blob ranges restore failed with information: '{0}'.", ex.ToString()));
                    }
                }
                else
                {
                    if (temp == null)
                    {
                        throw new InvalidJobStateException("Could not fetch the Blob restore response.");
                    }

                    PSBlobRestoreStatus blobRestoreStatus = ParseRestoreRawResponse(temp);

                    if (blobRestoreStatus.Status != null)
                    {
                        if (blobRestoreStatus.Status == Track2Models.BlobRestoreProgressStatus.Failed.ToString())
                        {
                            throw new InvalidJobStateException("Blob ranges restore failed.");
                        }
                    } 
                    else
                    {
                        WriteWarning(string.Format("Could not fetch the status."));
                    }
                    WriteObject(blobRestoreStatus);
                }
            }
        }

        private PSBlobRestoreStatus ParseRestoreRawResponse(Dictionary<string, object> response)
        {
            response.TryGetValue("restoreId", out object restoreId);
            response.TryGetValue("status", out object jobStatus);
            response.TryGetValue("parameters", out object parameters);

            PSBlobRestoreParameters blobRestoreParameters;
            Dictionary<string, object> paramMap = parameters as Dictionary<string, object>;

            if (paramMap == null)
            {
                blobRestoreParameters = null;
            }
            else
            {
                blobRestoreParameters = new PSBlobRestoreParameters();
                paramMap.TryGetValue("timetoRestore", out object timeToRestore);
                DateTimeOffset.TryParse(timeToRestore?.ToString(), out DateTimeOffset parseDate);
                blobRestoreParameters.TimeToRestore = parseDate;

                paramMap.TryGetValue("blobRanges", out object ranges);
                List<PSBlobRestoreRange> blobRestoreRanges = new List<PSBlobRestoreRange>();

                object[] rangesList = ranges as object[];
                foreach (object range in rangesList)
                {
                    Dictionary<string, object> rangeMap = range as Dictionary<string, object>;

                    rangeMap.TryGetValue("startRange", out object startRange);
                    rangeMap.TryGetValue("endRange", out object endRange);

                    PSBlobRestoreRange blobRestoreRange = new PSBlobRestoreRange
                    {
                        StartRange = startRange?.ToString(),
                        EndRange = endRange?.ToString()
                    };

                    blobRestoreRanges.Add(blobRestoreRange);
                }
                blobRestoreParameters.BlobRanges = blobRestoreRanges.ToArray();
            }

            return new PSBlobRestoreStatus(
                status: jobStatus?.ToString(),
                failureReason: null,
                restoreId: restoreId?.ToString(),
                parameters: blobRestoreParameters);
        }
    }
}
