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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using global::Azure.Core;
    using global::Azure.Storage;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Blobs.Specialized;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using global::Azure.Storage.Sas;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using XTable = Microsoft.Azure.Cosmos.Table;

    internal class SasTokenHelper
    {
        private const string HttpsOrHttp = "httpsorhttp";

        /// <summary>
        /// Validate the container access policy
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        /// <param name="containerName">Container name</param>
        /// <param name="policy">SharedAccessBlobPolicy object</param>
        /// <param name="policyIdentifier">The policy identifier which need to be checked.</param>
        public static bool ValidateContainerAccessPolicy(IStorageBlobManagement channel, string containerName,
            SharedAccessBlobPolicy policy, string policyIdentifier)
        {
            if (string.IsNullOrEmpty(policyIdentifier)) return true;
            CloudBlobContainer container = channel.GetContainerReference(containerName);
            AccessCondition accessCondition = null;
            BlobRequestOptions options = null;
            OperationContext context = null;
            BlobContainerPermissions permission = channel.GetContainerPermissions(container, accessCondition, options, context);

            SharedAccessBlobPolicy sharedAccessPolicy =
                GetExistingPolicy<SharedAccessBlobPolicy>(permission.SharedAccessPolicies, policyIdentifier);

            if (policy.Permissions != SharedAccessBlobPermissions.None)
            {
                throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
            }

            if (policy.SharedAccessExpiryTime.HasValue && sharedAccessPolicy.SharedAccessExpiryTime.HasValue)
            {
                throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
            }

            return !sharedAccessPolicy.SharedAccessExpiryTime.HasValue;
        }

        /// <summary>
        /// Validate the table access policy
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel object</param>
        /// <param name="tableName">Table name</param>
        /// <param name="policy">SharedAccessBlobPolicy object</param>
        /// <param name="policyIdentifier">The policy identifier which need to be checked.</param>
        internal static bool ValidateTableAccessPolicy(IStorageTableManagement channel,
            string tableName, XTable.SharedAccessTablePolicy policy, string policyIdentifier)
        {
            if (string.IsNullOrEmpty(policyIdentifier)) return true;
            XTable.CloudTable table = channel.GetTableReference(tableName);
            XTable.TableRequestOptions options = null;
            XTable.OperationContext context = null;
            XTable.TablePermissions permission = channel.GetTablePermissions(table, options, context);

            XTable.SharedAccessTablePolicy sharedAccessPolicy =
                GetExistingPolicy<XTable.SharedAccessTablePolicy>(permission.SharedAccessPolicies, policyIdentifier);

            if (policy.Permissions != XTable.SharedAccessTablePermissions.None)
            {
                throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
            }

            if (policy.SharedAccessExpiryTime.HasValue && sharedAccessPolicy.SharedAccessExpiryTime.HasValue)
            {
                throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
            }

            return !sharedAccessPolicy.SharedAccessExpiryTime.HasValue;
        }

        /// <summary>
        /// Validate access policy
        /// </summary>
        /// <param name="policies">Access policy</param>
        /// <param name="policyIdentifier">policyIdentifier</param>
        internal static T GetExistingPolicy<T>(IDictionary<string, T> policies, string policyIdentifier)
        {
            policyIdentifier = policyIdentifier.ToLower();//policy name should case-insensitive in url.
            foreach (KeyValuePair<string, T> pair in policies)
            {
                if (pair.Key.ToLower() == policyIdentifier)
                {
                    return pair.Value;
                }
            }

            throw new ArgumentException(string.Format(Resources.InvalidAccessPolicy, policyIdentifier));
        }

        public static void SetupAccessPolicyLifeTime(DateTime? startTime, DateTime? expiryTime,
            out DateTimeOffset? SharedAccessStartTime, out DateTimeOffset? SharedAccessExpiryTime, bool shouldSetExpiryTime)
        {
            SharedAccessStartTime = null;
            SharedAccessExpiryTime = null;
            //Set up start/expiry time
            if (startTime != null)
            {
                SharedAccessStartTime = startTime.Value.ToUniversalTime();
            }

            if (expiryTime != null)
            {
                SharedAccessExpiryTime = expiryTime.Value.ToUniversalTime();
            }
            else if (shouldSetExpiryTime)
            {
                double defaultLifeTime = 1.0; //Hours

                if (SharedAccessStartTime != null)
                {
                    SharedAccessExpiryTime = SharedAccessStartTime.Value.AddHours(defaultLifeTime).ToUniversalTime();
                }
                else
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(defaultLifeTime).ToUniversalTime();
                }
            }

            if (SharedAccessStartTime != null && SharedAccessExpiryTime.HasValue
                && SharedAccessExpiryTime <= SharedAccessStartTime)
            {
                throw new ArgumentException(String.Format(Resources.ExpiryTimeGreatThanStartTime,
                    SharedAccessExpiryTime.ToString(), SharedAccessStartTime.ToString()));
            }
        }

        public static string GetFullUriWithSASToken(string absoluteUri, string sasToken)
        {            
            // make sure sas token not contains prefix "?"
            sasToken = Util.GetSASStringWithoutQuestionMark(sasToken);

            if (absoluteUri.Contains("?"))
            {
                // There is already a query string in the URI, so just append sas
                return absoluteUri + "&" + sasToken;
            }
            else
            {
                return absoluteUri + "?" + sasToken;
            }
        }

        /// <summary>
        /// Get a BlobSignedIdentifier from container with a specific Id
        /// </summary>
        public static BlobSignedIdentifier GetBlobSignedIdentifier(BlobContainerClient container, string identifierId, CancellationToken cancellationToken)
        {
            IEnumerable<BlobSignedIdentifier> signedIdentifiers = container.GetAccessPolicy(cancellationToken: cancellationToken).Value.SignedIdentifiers;
            foreach (BlobSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == identifierId)
                {
                    return identifier;
                }
            }
            throw new ArgumentException(string.Format(Resources.InvalidAccessPolicy, identifierId));
        }

        /// <summary>
        /// Get a ShareSignedIdentifier from share with a specific Id
        /// </summary>
        public static ShareSignedIdentifier GetShareSignedIdentifier(ShareClient share, string identifierId, CancellationToken cancellationToken)
        {
            IEnumerable<ShareSignedIdentifier> signedIdentifiers = share.GetAccessPolicy(cancellationToken: cancellationToken).Value;
            foreach (ShareSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == identifierId)
                {
                    return identifier;
                }
            }
            throw new ArgumentException(string.Format(Resources.InvalidAccessPolicy, identifierId));
        }

        /// <summary>
        /// Get a QueueSignedIdentifier from queue with a specific id 
        /// </summary>
        public static QueueSignedIdentifier GetQueueSignedIdentifier(QueueClient queue, string identifierId, CancellationToken cancellationToken)
        {
            IEnumerable<QueueSignedIdentifier> signedIdentifiers = queue.GetAccessPolicy(cancellationToken: cancellationToken).Value;
            foreach (QueueSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == identifierId)
                {
                    return identifier;
                }
            }
            throw new ArgumentException(string.Format(Resources.InvalidAccessPolicy, identifierId));
        }


        /// <summary>
        /// Create a share SAS build from file Object
        /// </summary>
        public static ShareSasBuilder SetShareSasBuilder_FromFile(ShareFileClient file,
            ShareSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            string Protocol = null,
            string delegatedUserObjectId = null)
        {
            ShareSasBuilder sasBuilder = SetShareSasBuilder(file.ShareName,
                file.Path,
                signedIdentifier,
                Permission,
                StartTime,
                ExpiryTime,
                iPAddressOrRange,
                Protocol,
                delegatedUserObjectId);
            return sasBuilder;
        }

        /// <summary>
        /// Create a share SAS build from share Object
        /// </summary>
        public static ShareSasBuilder SetShareSasBuilder_FromShare(ShareClient share,
            ShareSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            string Protocol = null,
            string delegatedUserObjectId = null)
        {
            ShareSasBuilder sasBuilder = SetShareSasBuilder(share.Name,
                null,
                signedIdentifier,
                Permission,
                StartTime,
                ExpiryTime,
                iPAddressOrRange,
                Protocol,
                null,
                delegatedUserObjectId);
            return sasBuilder;
        }

        /// <summary>
        /// Create a Queue SAS builder 
        /// </summary>
        public static QueueSasBuilder SetQueueSasbuilder(QueueClient queue, 
            QueueSignedIdentifier signedIdentifier = null, 
            string permission = null,
            DateTime? startTime = null,
            DateTime? expiryTime = null,
            string iPAddressOrRange = null,
            string protocol = null,
            string delegatedUserObjectId = null)
        {
            QueueSasBuilder sasBuilder = new QueueSasBuilder
            {
                QueueName = queue.Name,
            };

            if (signedIdentifier != null)
            {
                sasBuilder.Identifier = signedIdentifier.Id;

                if (startTime != null)
                {
                    if (signedIdentifier.AccessPolicy.StartsOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.StartsOn != null)
                    {
                        throw new InvalidOperationException(Resources.SignedStartTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.StartsOn = startTime.Value.ToUniversalTime();
                    }
                }
                if (expiryTime != null)
                {
                    if (signedIdentifier.AccessPolicy.ExpiresOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.ExpiresOn != null)
                    {
                        throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = expiryTime.Value.ToUniversalTime();
                    }
                }
                // Set up expiry time if it is not set by user input or the policy
                else if (signedIdentifier.AccessPolicy.ExpiresOn == DateTimeOffset.MinValue || signedIdentifier.AccessPolicy.ExpiresOn == null)
                {
                    if (sasBuilder.StartsOn != DateTimeOffset.MinValue && sasBuilder.StartsOn != null)
                    {
                        sasBuilder.ExpiresOn = sasBuilder.StartsOn.ToUniversalTime().AddHours(1);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                    }
                }
                if (permission != null)
                {
                    if (signedIdentifier.AccessPolicy.Permissions != null)
                    {
                        throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.SetPermissions(permission, true);
                    }
                }
            }
            else
            {
                sasBuilder.SetPermissions(permission, true);

                if (startTime != null)
                {
                    sasBuilder.StartsOn = startTime.Value.ToUniversalTime();
                }
                if (expiryTime != null)
                {
                    sasBuilder.ExpiresOn = expiryTime.Value.ToUniversalTime();
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
            if (iPAddressOrRange != null)
            {
                sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(iPAddressOrRange);
            }
            if (protocol != null)
            {
                if (protocol.ToLower() == HttpsOrHttp)
                {
                    sasBuilder.Protocol = SasProtocol.HttpsAndHttp;
                }
                else //HttpsOnly
                {
                    sasBuilder.Protocol = SasProtocol.Https;
                }
            }
            if (delegatedUserObjectId != null)
            {
                sasBuilder.DelegatedUserObjectId = delegatedUserObjectId; 
            }
            return sasBuilder;
        }

        /// <summary>
        /// Create a share SAS builder
        /// </summary>
        public static ShareSasBuilder SetShareSasBuilder(string shareName,
            string filePath = null,
            ShareSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            string Protocol = null,
            string EncryptionScope = null,
            string delegatedUserObjectId = null)
        {
            ShareSasBuilder sasBuilder;
            if (signedIdentifier != null) // Use save access policy
            {
                sasBuilder = new ShareSasBuilder
                {
                    ShareName = shareName,
                    FilePath = filePath,
                    Identifier = signedIdentifier.Id
                };

                if (StartTime != null)
                {
                    if (signedIdentifier.AccessPolicy.StartsOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.StartsOn != null)
                    {
                        throw new InvalidOperationException(Resources.SignedStartTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
                    }
                }

                if (ExpiryTime != null)
                {
                    if (signedIdentifier.AccessPolicy.PolicyExpiresOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.PolicyExpiresOn != null)
                    {
                        throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
                    }
                }
                else if (signedIdentifier.AccessPolicy.PolicyExpiresOn == DateTimeOffset.MinValue || signedIdentifier.AccessPolicy.PolicyExpiresOn == null)
                {
                    if (sasBuilder.StartsOn != DateTimeOffset.MinValue && sasBuilder.StartsOn != null)
                    {
                        sasBuilder.ExpiresOn = sasBuilder.StartsOn.ToUniversalTime().AddHours(1);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                    }
                }

                if (Permission != null)
                {
                    if (signedIdentifier.AccessPolicy.Permissions != null)
                    {
                        throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.SetPermissions(Permission, true);
                    }
                }
            }
            else // use user input permission, starton, expireon
            {
                sasBuilder = new ShareSasBuilder
                {
                    ShareName = shareName,
                    FilePath = filePath,
                };
                sasBuilder.SetPermissions(Permission, true);
                if (StartTime != null)
                {
                    sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
                }
                if (ExpiryTime != null)
                {
                    sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
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
            if (iPAddressOrRange != null)
            {
                sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(iPAddressOrRange);
            }
            if (Protocol != null)
            {
                if (Protocol.ToLower() == HttpsOrHttp)
                {
                    sasBuilder.Protocol = SasProtocol.HttpsAndHttp;
                }
                else //HttpsOnly
                {
                    sasBuilder.Protocol = SasProtocol.Https;
                }
            }
            if (delegatedUserObjectId != null)
            {
                sasBuilder.DelegatedUserObjectId = delegatedUserObjectId;
            }
            return sasBuilder;
        }

        /// <summary>
        /// Get SAS string
        /// </summary>
        public static string GetFileSharedAccessSignature(AzureStorageContext context, ShareSasBuilder sasBuilder, bool generateUserDelegationSas, CancellationToken cancelToken)
        {
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey)
            {
                return sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }

            if (generateUserDelegationSas)
            {
                if (context.StorageAccountName.StartsWith("["))
                {
                    throw new InvalidOperationException("Please provide '-Context' as a storage context created by cmdlet `New-AzStorageContext` with parameters include '-StorageAccountName'.");
                }
                global::Azure.Storage.Files.Shares.Models.UserDelegationKey userDelegationKey = null;
                ShareServiceClient oauthService = new ShareServiceClient(context.StorageAccount.FileEndpoint, context.Track2OauthToken);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue || sasBuilder.StartsOn == null ? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime(),
                    cancellationToken: cancelToken);

                return sasBuilder.ToSasQueryParameters(userDelegationKey, context.StorageAccountName).ToString();
            }

            throw new InvalidOperationException("Create File service SAS only supported with SharedKey or OAuth token credential.");
        }

        /// <summary>
        /// Get Queue SAS string
        /// </summary>
        public static string GetQueueSharedAccessSignature(AzureStorageContext context, QueueSasBuilder sasBuilder, bool generateUserDelegationSas, CancellationToken cancellationToken)
        {
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey)
            {
                return sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }

            if (generateUserDelegationSas)
            {
                if (context.StorageAccountName.StartsWith("["))
                {
                    throw new InvalidOperationException("Please provide '-Context' as a storage context created by cmdlet `New-AzStorageContext` with parameters include '-StorageAccountName'.");
                }
                global::Azure.Storage.Queues.Models.UserDelegationKey userDelegationKey = null;
                QueueServiceClient oauthService = new QueueServiceClient(context.StorageAccount.QueueEndpoint, context.Track2OauthToken);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue || sasBuilder.StartsOn == null ? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime(),
                    cancellationToken: cancellationToken);

                return sasBuilder.ToSasQueryParameters(userDelegationKey, context.StorageAccountName).ToString();
            }
            
            throw new InvalidOperationException("Create Queue service SAS only supported with SharedKey or OAuth token credential.");
        }


        /// <summary>
        /// Create a blob SAS build from Blob Object
        /// </summary>
        public static BlobSasBuilder SetBlobSasBuilder_FromBlob(BlobBaseClient blobClient,
            BlobSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            SharedAccessProtocol? Protocol = null,
            string EncryptionScope = null,
            string DelegatedUserObjectId = null)
        {
            BlobSasBuilder sasBuilder = SetBlobSasBuilder(blobClient.BlobContainerName,
                blobClient.Name,
                signedIdentifier,
                Permission,
                StartTime,
                ExpiryTime,
                iPAddressOrRange,
                Protocol,
                EncryptionScope,
                DelegatedUserObjectId);
            if (Util.GetVersionIdFromBlobUri(blobClient.Uri) != null)
            {
                sasBuilder.BlobVersionId = Util.GetVersionIdFromBlobUri(blobClient.Uri);
            }
            if (Util.GetSnapshotTimeFromUri(blobClient.Uri) != null)
            {
                sasBuilder.Snapshot = Util.GetSnapshotTimeStringFromUri(blobClient.Uri);
            }
            return sasBuilder;
        }

        /// <summary>
        /// Create a blob SAS build from container Object
        /// </summary>
        public static BlobSasBuilder SetBlobSasBuilder_FromContainer(BlobContainerClient container,
            BlobSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            SharedAccessProtocol? Protocol = null,
            string EncryptionScope = null,
            string DelegatedUserObjectId = null)
        {
            BlobSasBuilder sasBuilder = SetBlobSasBuilder(container.Name,
                null,
                signedIdentifier,
                Permission,
                StartTime,
                ExpiryTime,
                iPAddressOrRange,
                Protocol,
                EncryptionScope,
                DelegatedUserObjectId);
            return sasBuilder;
        }

        /// <summary>
        /// Create a blob SAS build from Blob Object
        /// </summary>
        public static BlobSasBuilder SetBlobSasBuilder(string containerName,
            string blobName = null,
            BlobSignedIdentifier signedIdentifier = null,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            SharedAccessProtocol? Protocol = null,
            string EncryptionScope = null,
            string DelegatedUserObjectId = null)
        {
            BlobSasBuilder sasBuilder;
            if (signedIdentifier != null) // Use save access policy
            {
                sasBuilder = new BlobSasBuilder
                {
                    BlobContainerName = containerName,
                    BlobName = blobName,
                    Identifier = signedIdentifier.Id
                };

                if (StartTime != null)
                {
                    if (signedIdentifier.AccessPolicy.StartsOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.StartsOn != null)
                    {
                        throw new InvalidOperationException(Resources.SignedStartTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
                    }
                }

                if (ExpiryTime != null)
                {
                    if (signedIdentifier.AccessPolicy.PolicyExpiresOn != DateTimeOffset.MinValue && signedIdentifier.AccessPolicy.PolicyExpiresOn != null)
                    {
                        throw new ArgumentException(Resources.SignedExpiryTimeMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
                    }
                }
                else if (signedIdentifier.AccessPolicy.PolicyExpiresOn == DateTimeOffset.MinValue || signedIdentifier.AccessPolicy.PolicyExpiresOn == null)
                {
                    if (sasBuilder.StartsOn != DateTimeOffset.MinValue && sasBuilder.StartsOn != null)
                    {
                        sasBuilder.ExpiresOn = sasBuilder.StartsOn.ToUniversalTime().AddHours(1);
                    }
                    else
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                    }
                }

                if (Permission != null)
                {
                    if (signedIdentifier.AccessPolicy.Permissions != null)
                    {
                        throw new ArgumentException(Resources.SignedPermissionsMustBeOmitted);
                    }
                    else
                    {
                        sasBuilder = SetBlobPermission(sasBuilder, Permission);
                    }
                }
            }
            else // use user input permission, starton, expireon
            {
                sasBuilder = new BlobSasBuilder
                {
                    BlobContainerName = containerName,
                    BlobName = blobName,
                };
                sasBuilder = SetBlobPermission(sasBuilder, Permission);
                if (StartTime != null)
                {
                    sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
                }
                if (ExpiryTime != null)
                {
                    sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
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
            if (iPAddressOrRange != null)
            {
                sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(iPAddressOrRange);
            }
            if (Protocol != null)
            {
                if (Protocol.Value == SharedAccessProtocol.HttpsOrHttp)
                {
                    sasBuilder.Protocol = SasProtocol.HttpsAndHttp;
                }
                else //HttpsOnly
                {
                    sasBuilder.Protocol = SasProtocol.Https;
                }
            }
            if (EncryptionScope != null)
            {
                sasBuilder.EncryptionScope = EncryptionScope;
            }
            if (DelegatedUserObjectId != null)
            {
                sasBuilder.DelegatedUserObjectId = DelegatedUserObjectId;
            }
            return sasBuilder;
        }

        /// <summary>
        /// Set blob permission to SAS builder
        /// </summary>
        public static BlobSasBuilder SetBlobPermission(BlobSasBuilder sasBuilder, string rawPermission)
        {
            BlobContainerSasPermissions permission = 0;
            foreach (char c in rawPermission)
            {
                switch (c)
                {
                    case 'r':
                        permission = permission | BlobContainerSasPermissions.Read;
                        break;
                    case 'a':
                        permission = permission | BlobContainerSasPermissions.Add;
                        break;
                    case 'c':
                        permission = permission | BlobContainerSasPermissions.Create;
                        break;
                    case 'w':
                        permission = permission | BlobContainerSasPermissions.Write;
                        break;
                    case 'd':
                        permission = permission | BlobContainerSasPermissions.Delete;
                        break;
                    case 'l':
                        permission = permission | BlobContainerSasPermissions.List;
                        break;
                    case 't':
                        permission = permission | BlobContainerSasPermissions.Tag;
                        break;
                    case 'x':
                        permission = permission | BlobContainerSasPermissions.DeleteBlobVersion;
                        break;
                    case 'i':
                        permission = permission | BlobContainerSasPermissions.SetImmutabilityPolicy;
                        break;
                    default:
                        // Can't convert to permission supported by XSCL, so use raw permission string
                        sasBuilder.SetPermissions(rawPermission);
                        return sasBuilder;
                }
            }
            sasBuilder.SetPermissions(permission);
            return sasBuilder;
        }

        /// <summary>
        /// Get SAS string
        /// </summary>
        public static string GetBlobSharedAccessSignature(AzureStorageContext context, BlobSasBuilder sasBuilder, bool generateUserDelegationSas, BlobClientOptions ClientOptions, CancellationToken cancelToken)
        {
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey)
            {
                return sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }
            if (generateUserDelegationSas)
            {
                if (context.StorageAccountName.StartsWith("["))
                {
                    throw new InvalidOperationException("Please provide '-Context' as a storage context created by cmdlet `New-AzStorageContext` with parameters include '-StorageAccountName'.");
                }
                global::Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey = null;
                BlobServiceClient oauthService = new BlobServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, ClientOptions);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue || sasBuilder.StartsOn == null ? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime(),
                    cancellationToken: cancelToken);

                return sasBuilder.ToSasQueryParameters(userDelegationKey, context.StorageAccountName).ToString();
            }
            else
            {
                throw new InvalidOperationException("Create SAS only supported with SharedKey or Oauth credential.");
            }
        }

        /// <summary>
        /// Get SAS string for DatalakeGen2
        /// </summary>
        public static string GetDatalakeGen2SharedAccessSignature(AzureStorageContext context, DataLakeSasBuilder sasBuilder, bool generateUserDelegationSas, DataLakeClientOptions clientOptions, CancellationToken cancelToken)
        {
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey)
            {
                return sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }
            if (generateUserDelegationSas)
            {
                if (context.StorageAccountName.StartsWith("["))
                {
                    throw new InvalidOperationException("Please provide '-Context' as a storage context created by cmdlet `New-AzStorageContext` with parameters include '-StorageAccountName'.");
                }
                global::Azure.Storage.Files.DataLake.Models.UserDelegationKey userDelegationKey = null;
                DataLakeServiceClient oauthService = new DataLakeServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, clientOptions);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue || sasBuilder.StartsOn == null ? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime(),
                    cancellationToken: cancelToken);

                return sasBuilder.ToSasQueryParameters(userDelegationKey, context.StorageAccountName).ToString();
            }
            else
            {
                throw new InvalidOperationException("Create SAS only supported with SharedKey or Oauth credential.");
            }
        }

        /// <summary>
        /// Create a account SAS builder
        /// </summary>
        public static AccountSasBuilder SetAccountSasBuilder(SharedAccessAccountServices Service,
            SharedAccessAccountResourceTypes type,
            string Permission = null,
            DateTime? StartTime = null,
            DateTime? ExpiryTime = null,
            string iPAddressOrRange = null,
            SharedAccessProtocol? Protocol = null,
            string EncryptionScope = null)
        {
            AccountSasBuilder sasBuilder = new AccountSasBuilder();
            sasBuilder.ResourceTypes = GetAccountSasResourceTypes(type);
            sasBuilder.Services = GetAccountSasServices(Service);

            sasBuilder = SetAccountPermission(sasBuilder, Permission);
            if (StartTime != null)
            {
                sasBuilder.StartsOn = StartTime.Value.ToUniversalTime();
            }
            if (ExpiryTime != null)
            {
                sasBuilder.ExpiresOn = ExpiryTime.Value.ToUniversalTime();
            }
            else
            {
                if (sasBuilder.StartsOn != DateTimeOffset.MinValue && sasBuilder.StartsOn != null)
                {
                    sasBuilder.ExpiresOn = sasBuilder.StartsOn.AddHours(1).ToUniversalTime();
                }
                else
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                }
            }
            if (iPAddressOrRange != null)
            {
                sasBuilder.IPRange = Util.SetupIPAddressOrRangeForSASTrack2(iPAddressOrRange);
            }
            if (Protocol != null)
            {
                if (Protocol.Value == SharedAccessProtocol.HttpsOrHttp)
                {
                    sasBuilder.Protocol = SasProtocol.HttpsAndHttp;
                }
                else //HttpsOnly
                {
                    sasBuilder.Protocol = SasProtocol.Https;
                }
            }
            if (EncryptionScope != null)
            {
                sasBuilder.EncryptionScope = EncryptionScope;
            }
            return sasBuilder;
        }

        /// <summary>
        /// Get Track2 account sas SasServices
        /// </summary>
        public static AccountSasServices GetAccountSasServices(SharedAccessAccountServices Service)
        {
            AccountSasServices outputService = 0;
            if ((Service & SharedAccessAccountServices.Blob) == SharedAccessAccountServices.Blob)
            {
                outputService = outputService | AccountSasServices.Blobs;
            }
            if ((Service & SharedAccessAccountServices.File) == SharedAccessAccountServices.File)
            {
                outputService = outputService | AccountSasServices.Files;
            }
            if ((Service & SharedAccessAccountServices.Queue) == SharedAccessAccountServices.Queue)
            {
                outputService = outputService | AccountSasServices.Queues;
            }
            if ((Service & SharedAccessAccountServices.Table) == SharedAccessAccountServices.Table)
            {
                outputService = outputService | AccountSasServices.Tables;
            }
            return outputService;
        }

        /// <summary>
        /// Get Track2 account sas ResourceTypes
        /// </summary>
        public static AccountSasResourceTypes GetAccountSasResourceTypes(SharedAccessAccountResourceTypes type)
        {
            AccountSasResourceTypes outputType = 0;
            if ((type & SharedAccessAccountResourceTypes.Service) == SharedAccessAccountResourceTypes.Service)
            {
                outputType = outputType | AccountSasResourceTypes.Service;
            }
            if ((type & SharedAccessAccountResourceTypes.Container) == SharedAccessAccountResourceTypes.Container)
            {
                outputType = outputType | AccountSasResourceTypes.Container;
            }
            if ((type & SharedAccessAccountResourceTypes.Object) == SharedAccessAccountResourceTypes.Object)
            {
                outputType = outputType | AccountSasResourceTypes.Object;
            }
            return outputType;
        }

        /// <summary>
        /// Set account permission to SAS builder
        /// </summary>
        public static AccountSasBuilder SetAccountPermission(AccountSasBuilder sasBuilder, string rawPermission)
        {
            AccountSasPermissions permission = 0;
            foreach (char c in rawPermission)
            {
                switch (c)
                {
                    case 'r':
                        permission = permission | AccountSasPermissions.Read;
                        break;
                    case 'a':
                        permission = permission | AccountSasPermissions.Add;
                        break;
                    case 'c':
                        permission = permission | AccountSasPermissions.Create;
                        break;
                    case 'w':
                        permission = permission | AccountSasPermissions.Write;
                        break;
                    case 'd':
                        permission = permission | AccountSasPermissions.Delete;
                        break;
                    case 'l':
                        permission = permission | AccountSasPermissions.List;
                        break;
                    case 'u':
                        permission = permission | AccountSasPermissions.Update;
                        break;
                    case 'p':
                        permission = permission | AccountSasPermissions.Process;
                        break;
                    case 't':
                        permission = permission | AccountSasPermissions.Tag;
                        break;
                    case 'f':
                        permission = permission | AccountSasPermissions.Filter;
                        break;
                    case 'x':
                        permission = permission | AccountSasPermissions.DeleteVersion;
                        break;
                    case 'i':
                        permission = permission | AccountSasPermissions.SetImmutabilityPolicy;
                        break;
                    case 'y':
                        permission = permission | AccountSasPermissions.PermanentDelete;
                        break;
                    default:
                        // Can't convert to permission supported by XSCL, so use raw permission string
                        sasBuilder.SetPermissions(rawPermission);
                        return sasBuilder;
                }
            }
            sasBuilder.SetPermissions(permission);
            return sasBuilder;
        }

        /// <summary>
        /// Return true if the permission can only be handled by Track2 SDK
        /// </summary>
        public static bool IsTrack2Permission(string permission)
        {
            if (permission is null)
            {
                return false;
            }

            string permission_Track1 = "rwdlacup";
            foreach (char c in permission)
            {
                if (!permission_Track1.Contains(c.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
