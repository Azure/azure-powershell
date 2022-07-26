//------------------------------------------------------------------------------
// <copyright file="BlobExtensions.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//      Extensions methods for CloudBlobs and CloudFiles for use with BlobTransfer
// </summary>
//------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using global::Azure.Storage;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Specialized;
    using global::Azure.Storage.Sas;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Globalization;

    /// <summary>
    /// Extension methods for CloudBlobs and CloudFiles.
    /// </summary>
    internal static class StorageExtensions
    {
        private const int CopySASLifeTimeInMinutes = 7 * 24 * 60;

        // The Oauth delegate SAS expire time must be in 7 days.
        // As client and server has time difference, to make it more stable, the time will be 2 hour less than 7 days.
        private const int CopySASLifeTimeInMinutesOauth = 7 * 24 * 60 - 2 * 60;

        internal static Uri GenerateUriWithCredentials(
            this CloudFile file)
        {
            if (null == file)
            {
                throw new ArgumentNullException("file");
            }

            string sasToken = GetFileSASToken(file);

            if (string.IsNullOrEmpty(sasToken))
            {
                return file.SnapshotQualifiedUri;
            }
            else
            {
                return new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}", file.SnapshotQualifiedUri.AbsoluteUri, sasToken));
            }
        }

        internal static CloudFile GenerateCopySourceFile(
           this CloudFile file)
        {
            if (null == file)
            {
                throw new ArgumentNullException("file");
            }

            string sasToken = GetFileSASToken(file);

            if (string.IsNullOrEmpty(sasToken))
            {
                return file;
            }

            return new CloudFile(file.SnapshotQualifiedUri, new StorageCredentials(sasToken));
        }

        private static string GetFileSASToken(CloudFile file)
        {
            if (null == file.ServiceClient.Credentials
                || file.ServiceClient.Credentials.IsAnonymous)
            {
                return string.Empty;
            }
            else if (file.ServiceClient.Credentials.IsSAS)
            {
                return file.ServiceClient.Credentials.SASToken;
            }

            // SAS life time is at least 10 minutes.
            TimeSpan sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutes);

            SharedAccessFilePolicy policy = new SharedAccessFilePolicy()
            {
                SharedAccessExpiryTime = DateTime.Now.Add(sasLifeTime),
                Permissions = SharedAccessFilePermissions.Read,
            };

            return file.GetSharedAccessSignature(policy);
        }

        /// <summary>
        /// Append an auto generated SAS to a blob uri.
        /// </summary>
        /// <param name="blob">Blob to append SAS.</param>
        /// <returns>Blob Uri with SAS appended.</returns>
        internal static CloudBlob GenerateCopySourceBlob(
            this CloudBlob blob)
        {
            if (null == blob)
            {
                throw new ArgumentNullException("blob");
            }

            string sasToken = GetBlobSasToken(blob);

            if (string.IsNullOrEmpty(sasToken))
            {
                return blob;
            }

            Uri blobUri = null;

            if (blob.IsSnapshot)
            {
                blobUri = blob.SnapshotQualifiedUri;
            }
            else
            {
                blobUri = blob.Uri;
            }

            return Util.GetBlobReference(blobUri, new StorageCredentials(sasToken), blob.BlobType);
        }

        /// <summary>
        /// Append an auto generated SAS to a blob uri.
        /// </summary>
        /// <param name="blob">Blob to append SAS.</param>
        /// <returns>Blob Uri with SAS appended.</returns>
        internal static Uri GenerateUriWithCredentials(
            this CloudBlob blob)
        {
            if (null == blob)
            {
                throw new ArgumentNullException("blob");
            }

            string sasToken = GetBlobSasToken(blob);

            if (string.IsNullOrEmpty(sasToken))
            {
                return blob.SnapshotQualifiedUri;
            }

            string uriStr = null;

            if (blob.IsSnapshot)
            {
                uriStr = string.Format(CultureInfo.InvariantCulture, "{0}&{1}", blob.SnapshotQualifiedUri.AbsoluteUri, sasToken.Substring(1));
            }
            else
            {
                uriStr = string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri.AbsoluteUri, sasToken);
            }

            return new Uri(uriStr);
        }

        /// <summary>
        /// Append an auto generated SAS to a blob uri.
        /// </summary>
        /// <param name="blob">Blob to append SAS.</param>
        /// <param name="context">The storage context for the storage account</param>
        /// <returns>Blob Uri with SAS appended.</returns>
        internal static Uri GenerateUriWithCredentials(
            this BlobBaseClient blob, AzureStorageContext context)
        {
            if (null == blob)
            {
                throw new ArgumentNullException("blob");
            }
            else if (context.StorageAccount.Credentials.IsSAS)
            {
                return blob.Uri;
            }

            string sasToken = GetBlobSasToken(blob, context);

            if (string.IsNullOrEmpty(sasToken))
            {
                return blob.Uri;
            }

            string uriStr = null;

            if (!string.IsNullOrEmpty(blob.Uri.Query))
            {
                uriStr = string.Format(CultureInfo.InvariantCulture, "{0}&{1}", blob.Uri.AbsoluteUri, sasToken.Substring(1));
            }
            else
            {
                uriStr = string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri.AbsoluteUri, sasToken);
            }

            return new Uri(uriStr);
        }

        private static string GetBlobSasToken(CloudBlob blob)
        {
            if (null == blob.ServiceClient.Credentials
                || (blob.ServiceClient.Credentials.IsAnonymous && !blob.ServiceClient.Credentials.IsToken))
            {
                return string.Empty;
            }
            else if (blob.ServiceClient.Credentials.IsSAS)
            {
                return blob.ServiceClient.Credentials.SASToken;
            }

            // SAS life time is at least 10 minutes.
            TimeSpan sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutes);
            if (blob.ServiceClient.Credentials.IsToken)
            {
                sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutesOauth);
            }

            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.Now.Add(sasLifeTime),
                Permissions = SharedAccessBlobPermissions.Read,
            };

            CloudBlob rootBlob = null;

            if (!blob.IsSnapshot)
            {
                rootBlob = blob;
            }
            else
            {
                rootBlob = Util.GetBlobReference(blob.Uri, blob.ServiceClient.Credentials, blob.BlobType);
            }
            if (!blob.ServiceClient.Credentials.IsToken) // not oauth, generated normal sas
            {
                return rootBlob.GetSharedAccessSignature(policy);
            }
            else // oauth, generate identity sas
            {
                DateTimeOffset userDelegationKeyStartTime = DateTime.Now;
                DateTimeOffset userDelegationKeyEndTime = userDelegationKeyStartTime.AddMinutes(CopySASLifeTimeInMinutes) ;
                Azure.Storage.UserDelegationKey userDelegationKey = rootBlob.ServiceClient.GetUserDelegationKey(userDelegationKeyStartTime, userDelegationKeyEndTime);

                return rootBlob.GetUserDelegationSharedAccessSignature(userDelegationKey, policy);
            }
        }

        private static string GetBlobSasToken(BlobBaseClient blob, AzureStorageContext context)
        {
            if (null == context.StorageAccount.Credentials
                || (context.StorageAccount.Credentials.IsAnonymous && !context.StorageAccount.Credentials.IsToken))
            {
                return string.Empty;
            }
            else if (context.StorageAccount.Credentials.IsSAS)
            {
                return context.StorageAccount.Credentials.SASToken;
            }

            // SAS life time is at least 10 minutes.
            TimeSpan sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutes);
            if (context.StorageAccount.Credentials.IsToken)
            {
                sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutesOauth);
            }

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                ExpiresOn = DateTimeOffset.UtcNow.Add(sasLifeTime),
            };
            if (Util.GetVersionIdFromBlobUri(blob.Uri) != null)
            {
                sasBuilder.BlobVersionId = Util.GetVersionIdFromBlobUri(blob.Uri);
            }
            sasBuilder.SetPermissions("rt");

            string sasToken = null;
            if (context != null && context.StorageAccount.Credentials.IsToken) //oauth
            {
                global::Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey = null;
                BlobServiceClient oauthService = new BlobServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, null);

                Util.ValidateUserDelegationKeyStartEndTime(sasBuilder.StartsOn, sasBuilder.ExpiresOn);

                userDelegationKey = oauthService.GetUserDelegationKey(
                    startsOn: sasBuilder.StartsOn == DateTimeOffset.MinValue || sasBuilder.StartsOn == null? DateTimeOffset.UtcNow : sasBuilder.StartsOn.ToUniversalTime(),
                    expiresOn: sasBuilder.ExpiresOn.ToUniversalTime());

                sasToken = sasBuilder.ToSasQueryParameters(userDelegationKey, context.StorageAccountName).ToString();
            }
            else // sharedkey
            {
                sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey())).ToString();
            }

            if (sasToken[0] != '?')
            {
                sasToken = "?" + sasToken;
            }
            return sasToken;
        }
    }
}