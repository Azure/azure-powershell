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

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        protected override bool UseTrack2SDK()
        {
            if (this.Permission != null && this.Permission.ToLower().Contains("t"))
            {
                return true;
            }
            return base.UseTrack2SDK();
        }
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
            if (Channel != null && Channel.StorageContext != null && Channel.StorageContext.StorageAccount.Credentials.IsToken)
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

            if (!(blob is InvalidCloudBlob) && !UseTrack2SDK())
            {

                SharedAccessBlobPolicy accessPolicy = new SharedAccessBlobPolicy();
                bool shouldSetExpiryTime = SasTokenHelper.ValidateContainerAccessPolicy(Channel, blob.Container.Name, accessPolicy, accessPolicyIdentifier);
                SetupAccessPolicy(accessPolicy, shouldSetExpiryTime);
                string sasToken = GetBlobSharedAccessSignature(blob, accessPolicy, accessPolicyIdentifier, Protocol, Util.SetupIPAddressOrRangeForSAS(IPAddressOrRange), generateUserDelegationSas);

                if (FullUri)
                {
                    string fullUri = blob.SnapshotQualifiedUri.ToString();
                    if (blob.IsSnapshot)
                    {
                        // Since snapshot URL already has '?', need remove '?' in the first char of sas
                        fullUri = fullUri + "&" + sasToken.Substring(1);
                    }
                    else
                    {
                        fullUri = fullUri + sasToken;
                    }
                    WriteObject(fullUri);
                }
                else
                {
                    WriteObject(sasToken);
                }
            }
            else // Use Track2 SDk
            {
                BlobBaseClient blobClient;
                if (this.BlobBaseClient != null)
                {
                    blobClient = this.BlobBaseClient;
                }
                else
                {
                    blobClient = AzureStorageBlob.GetTrack2BlobClient(blob, Channel.StorageContext, this.ClientOptions);
                }

                BlobSasBuilder sasBuilder;
                if (ParameterSetName == BlobNamePipelineParmeterSetWithPolicy || ParameterSetName == BlobPipelineParameterSetWithPolicy)
                {
                    BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(Channel.GetContainerReference(blobClient.BlobContainerName), Channel.StorageContext, ClientOptions);
                    IEnumerable<BlobSignedIdentifier> signedIdentifiers = container.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value.SignedIdentifiers;
                    BlobSignedIdentifier signedIdentifier = null;
                    foreach (BlobSignedIdentifier identifier in signedIdentifiers)
                    {
                        if (identifier.Id == this.Policy)
                        {
                            signedIdentifier = identifier;
                            break;
                        }
                    }
                    if (signedIdentifier is null)
                    {
                        throw new ArgumentException(string.Format(Resources.InvalidAccessPolicy, this.Policy));
                    }
                    sasBuilder = new BlobSasBuilder
                    {
                        BlobContainerName = blobClient.BlobContainerName,
                        BlobName = blobClient.Name,
                        Identifier = this.Policy
                    };

                    if (this.StartTime != null)
                    {
                        if (signedIdentifier.AccessPolicy.StartsOn != DateTimeOffset.MinValue)
                        {
                            throw new InvalidOperationException(Resources.SignedStartTimeMustBeOmitted);
                        }
                        else
                        {
                            sasBuilder.StartsOn = this.StartTime.Value.ToUniversalTime();
                        }
                    }

                    if (this.ExpiryTime != null)
                    {
                        if (signedIdentifier.AccessPolicy.ExpiresOn != DateTimeOffset.MinValue)
                        {
                            throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
                        }
                        else
                        {
                            sasBuilder.ExpiresOn = this.ExpiryTime.Value.ToUniversalTime();
                        }
                    }
                    else if (signedIdentifier.AccessPolicy.ExpiresOn == DateTimeOffset.MinValue)
                    {
                        if (sasBuilder.StartsOn != DateTimeOffset.MinValue)
                        {
                            sasBuilder.ExpiresOn = sasBuilder.StartsOn.ToUniversalTime().AddHours(1);
                        }
                        else
                        {
                            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                        }
                    }

                    if (this.Permission != null)
                    {
                        if (signedIdentifier.AccessPolicy.Permissions != null)
                        {
                            throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
                        }
                        else
                        {
                            sasBuilder.SetPermissions(this.Permission);
                        }
                    }
                }
                else
                {
                    sasBuilder = new BlobSasBuilder
                    {
                        BlobContainerName = blobClient.BlobContainerName,
                        BlobName = blobClient.Name,
                    };
                    sasBuilder.SetPermissions(this.Permission);
                    if (this.StartTime != null)
                    {
                        sasBuilder.StartsOn = this.StartTime.Value.ToUniversalTime();
                    }
                    if (this.ExpiryTime != null)
                    {
                        sasBuilder.ExpiresOn = this.ExpiryTime.Value.ToUniversalTime();
                    }
                    else
                    {
                        if (sasBuilder.StartsOn != DateTimeOffset.MinValue)
                        {
                            sasBuilder.ExpiresOn = sasBuilder.StartsOn.AddHours(1).ToUniversalTime();
                        }
                        else
                        {
                            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                        }
                    }
                }
                if (this.IPAddressOrRange != null)
                {
                    sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(this.IPAddressOrRange);
                }
                if (this.Protocol != null)
                {
                    if (this.Protocol.Value == SharedAccessProtocol.HttpsOrHttp)
                    {
                        sasBuilder.Protocol = SasProtocol.HttpsAndHttp;
                    }
                    else //HttpsOnly
                    {
                        sasBuilder.Protocol = SasProtocol.Https;
                    }
                }
                if (Util.GetVersionIdFromBlobUri(blobClient.Uri) != null)
                {
                    sasBuilder.BlobVersionId = Util.GetVersionIdFromBlobUri(blobClient.Uri);
                }
                if (Util.GetSnapshotTimeFromBlobUri(blobClient.Uri) != null)
                {
                    sasBuilder.Snapshot = Util.GetSnapshotTimeFromBlobUri(blobClient.Uri).Value.ToString("o");
                }

                string sasToken = GetBlobSharedAccessSignature(blobClient, sasBuilder, generateUserDelegationSas);
                if (sasToken[0] != '?')
                {
                    sasToken = "?" + sasToken;
                }

                if (FullUri)
                {
                    string fullUri = blobClient.Uri.ToString();
                    if (blob.IsSnapshot)
                    {
                        // Since snapshot URL already has '?', need remove '?' in the first char of sas
                        fullUri = fullUri + "&" + sasToken.Substring(1);
                    }
                    else
                    {
                        fullUri = fullUri + sasToken;
                    }
                    WriteObject(fullUri);
                }
                else
                {
                    WriteObject(sasToken);
                }
            }
        }

        private string GetBlobSharedAccessSignature(BlobBaseClient blob, BlobSasBuilder sasBuilder, bool generateUserDelegationSas)
        {
            if (Channel != null && Channel.StorageContext != null && Channel.StorageContext.StorageAccount.Credentials.IsSharedKey)
            {
                return sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(Channel.StorageContext.StorageAccountName, Channel.StorageContext.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }
            if (generateUserDelegationSas)
            {
                global::Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey = null;
                BlobServiceClient oauthService = new BlobServiceClient(Channel.StorageContext.StorageAccount.BlobEndpoint, Channel.StorageContext.Track2OauthToken, ClientOptions);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue ? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime(),
                    cancellationToken: CmdletCancellationToken);

                return sasBuilder.ToSasQueryParameters(userDelegationKey, blob.AccountName).ToString();
            }
            else
            {
                throw new InvalidOperationException("Create SAS only supported with SharedKey or Oauth credentail.");
            }
        }

        /// <summary>
        /// Get blob shared access signature
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessPolicy">SharedAccessBlobPolicy object</param>
        /// <param name="policyIdentifier">The existing policy identifier.</param>
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
            //Create a block blob object in local no matter what's the real blob type. If so, we can save the unnecessary request calls.
            return container.GetBlockBlobReference(BlobName);
        }
    }
}
