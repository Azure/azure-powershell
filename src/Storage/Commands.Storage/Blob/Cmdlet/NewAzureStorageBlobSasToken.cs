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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, StorageNouns.BlobSas, DefaultParameterSetName = BlobNamePipelineParmeterSetWithPermission), OutputType(typeof(String))]
    public class NewAzureStorageBlobSasTokenCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// container pipeline paremeter set name with permission
        /// </summary>
        private const string BlobNamePipelineParmeterSetWithPermission = "BlobNameWithPermission";

        /// <summary>
        /// container pipeline paremeter set name with policy
        /// </summary>
        private const string BlobNamePipelineParmeterSetWithPolicy = "BlobNameWithPolicy";

        /// <summary>
        /// Blob Pipeline parameter set name with permission
        /// </summary>
        private const string BlobPipelineParameterSetWithPermision = "BlobPipelineWithPermission";

        /// <summary>
        /// Blob Pipeline parameter set name with policy
        /// </summary>
        private const string BlobPipelineParameterSetWithPolicy = "BlobPipelineWithPolicy";

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSetWithPolicy)]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSetWithPermision)]
        [ValidateNotNull]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Container Name",
            ParameterSetName = BlobNamePipelineParmeterSetWithPermission)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Container Name",
            ParameterSetName = BlobNamePipelineParmeterSetWithPolicy)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Blob Name",
            ParameterSetName = BlobNamePipelineParmeterSetWithPermission)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Blob Name",
            ParameterSetName = BlobNamePipelineParmeterSetWithPolicy)]
        [ValidateNotNullOrEmpty]
        public string Blob { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Policy Identifier",
            ParameterSetName = BlobNamePipelineParmeterSetWithPolicy)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Policy Identifier",
            ParameterSetName = BlobPipelineParameterSetWithPolicy)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a blob. Permissions can be any not-empty subset of \"rwd\".",
            ParameterSetName = BlobNamePipelineParmeterSetWithPermission)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a blob. Permissions can be any not-empty subset of \"rwd\".",
            ParameterSetName = BlobPipelineParameterSetWithPermision)]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateNotNull]
        public SharedAccessProtocol? Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Start Time")]
        [ValidateNotNull]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expiry Time")]
        [ValidateNotNull]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageBlobSasCommand class.
        /// </summary>
        public NewAzureStorageBlobSasTokenCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageBlobSasCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageBlobSasTokenCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudBlob blob = null;

            if (ParameterSetName == BlobNamePipelineParmeterSetWithPermission ||
                ParameterSetName == BlobNamePipelineParmeterSetWithPolicy)
            {
                blob = GetCloudBlobByName(Container, Blob);
            }
            else
            {
                blob = this.CloudBlob;
            }

            SharedAccessBlobPolicy accessPolicy = new SharedAccessBlobPolicy();
            bool shouldSetExpiryTime = SasTokenHelper.ValidateContainerAccessPolicy(Channel, blob.Container.Name, accessPolicy, accessPolicyIdentifier);
            SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);
            string sasToken = GetBlobSharedAccessSignature(blob, accessPolicy, accessPolicyIdentifier, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange));

            if (FullUri)
            {
                string fullUri = blob.Uri.ToString() + sasToken;
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }

        }

        /// <summary>
        /// Get blob shared access signature
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessPolicy">SharedAccessBlobPolicy object</param>
        /// <param name="policyIdentifier">The existing policy identifier.</param>
        /// <returns></returns>
        private string GetBlobSharedAccessSignature(CloudBlob blob, SharedAccessBlobPolicy accessPolicy, string policyIdentifier, SharedAccessProtocol? protocol, IPAddressOrRange iPAddressOrRange)
        {
            CloudBlobContainer container = blob.Container;
            return blob.GetSharedAccessSignature(accessPolicy, null, policyIdentifier, protocol, iPAddressOrRange);
        }

        /// <summary>
        /// Update the access policy
        /// </summary>
        /// <param name="policy">Access policy object</param>
        /// <param name="shouldSetExpiryTime">Should set the default expiry time</param>
        private void SetupAccessPolicy(SharedAccessBlobPolicy accessPolicy, bool shouldSetExpiryTime)
        {
            AccessPolicyHelper.SetupAccessPolicyPermission(accessPolicy, Permission);
            DateTimeOffset? accessStartTime;
            DateTimeOffset? accessEndTime;
            SasTokenHelper.SetupAccessPolicyLifeTime(StartTime, ExpiryTime,
                out accessStartTime, out accessEndTime, shouldSetExpiryTime);
            accessPolicy.SharedAccessStartTime = accessStartTime;
            accessPolicy.SharedAccessExpiryTime = accessEndTime;
        }

        /// <summary>
        /// Get CloudBlob object by name
        /// </summary>
        /// <param name="ContainerName">Container name</param>
        /// <param name="BlobName">Blob name.</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobByName(string ContainerName, string BlobName)
        {
            CloudBlobContainer container = Channel.GetContainerReference(ContainerName);
            //Create a block blob object in local no mattter what's the real blob type. If so, we can save the unnecessary request calls.
            return container.GetBlockBlobReference(BlobName);
        }
    }
}
