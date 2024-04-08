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
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Sas;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Blobs;
    using System.Collections.Generic;
    using global::Azure.Storage;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobSASToken", DefaultParameterSetName = BlobNamePipelineParmeterSetWithPermission, SupportsShouldProcess = true), OutputType(typeof(String))]
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

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSetWithPolicy)]
        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSetWithPermision)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Encryption scope to use when sending requests authorized with this SAS URI.")]
        [ValidateNotNullOrEmpty]
        public string EncryptionScope { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        public override string TagCondition { get; set; }

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

            // When the input context is Oauth bases, can't generate normal SAS, but UserDelegationSas
            bool generateUserDelegationSas = false;
            if (Channel != null && Channel.StorageContext != null && Channel.StorageContext.StorageAccount.Credentials != null && Channel.StorageContext.StorageAccount.Credentials.IsToken)
            {
                if (ShouldProcess(blob.Name, "Generate User Delegation SAS, since input Storage Context is OAuth based."))
                {
                    generateUserDelegationSas = true;
                    if (!string.IsNullOrEmpty(accessPolicyIdentifier))
                    {
                        throw new ArgumentException("When input Storage Context is OAuth based, Saved Policy is not supported.", "Policy");
                    }
                }
                else
                {
                    return;
                }
            }
            //Get blob instance
            BlobBaseClient blobClient;
            if (this.BlobBaseClient != null)
            {
                blobClient = this.BlobBaseClient;
            }
            else
            {
                blobClient = AzureStorageBlob.GetTrack2BlobClient(blob, Channel.StorageContext, this.ClientOptions);
            }

            // Get contaienr saved policy if any
            BlobSignedIdentifier identifier = null;
            if (ParameterSetName == BlobNamePipelineParmeterSetWithPolicy || ParameterSetName == BlobPipelineParameterSetWithPolicy)
            {
                BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(Channel.GetContainerReference(blobClient.BlobContainerName), Channel.StorageContext, ClientOptions);
                identifier = SasTokenHelper.GetBlobSignedIdentifier(container, this.Policy, CmdletCancellationToken);
            }

            //Create SAS builder
            BlobSasBuilder sasBuilder = SasTokenHelper.SetBlobSasBuilder_FromBlob(blobClient, identifier, this.Permission, this.StartTime, this.ExpiryTime, this.IPAddressOrRange, this.Protocol, this.EncryptionScope);

            //Create SAS and output
            string sasToken = SasTokenHelper.GetBlobSharedAccessSignature(Channel.StorageContext, sasBuilder, generateUserDelegationSas, ClientOptions, CmdletCancellationToken);
            
            // remove prefix "?" of SAS if any
            sasToken = Util.GetSASStringWithoutQuestionMark(sasToken);

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(blobClient.Uri.ToString(), sasToken);
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
        /// <param name="protocol"></param>
        /// <param name="iPAddressOrRange"></param>
        /// <param name="generateUserDelegationSas"></param>
        /// <returns></returns>
        private string GetBlobSharedAccessSignature(CloudBlob blob, SharedAccessBlobPolicy accessPolicy, string policyIdentifier, SharedAccessProtocol? protocol, IPAddressOrRange iPAddressOrRange, bool generateUserDelegationSas)
        {
            CloudBlobContainer container = blob.Container;
            if (generateUserDelegationSas)
            {
                Azure.Storage.UserDelegationKey userDelegationKey = Channel.GetUserDelegationKey(accessPolicy.SharedAccessStartTime, accessPolicy.SharedAccessExpiryTime, null, null, OperationContext);
                return blob.GetUserDelegationSharedAccessSignature(userDelegationKey, accessPolicy, null, protocol, iPAddressOrRange);
            }
            else
            {
                return blob.GetSharedAccessSignature(accessPolicy, null, policyIdentifier, protocol, iPAddressOrRange);
            }
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
            //Create a block blob object in local no matter what's the real blob type. If so, we can save the unnecessary request calls.
            return container.GetBlockBlobReference(BlobName);
        }
    }
}
