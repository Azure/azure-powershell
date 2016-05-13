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
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.Globalization;

    /// <summary>
    /// Extension methods for CloudBlobs and CloudFiles.
    /// </summary>
    internal static class StorageExtensions
    {
        private const int CopySASLifeTimeInMinutes = 7 * 24 * 60;

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
                return file.Uri;
            }
            else
            {
                return new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}", file.Uri.AbsoluteUri, sasToken));
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

            return new CloudFile(file.Uri, new StorageCredentials(sasToken));
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

        private static string GetBlobSasToken(CloudBlob blob)
        {
            if (null == blob.ServiceClient.Credentials
                || blob.ServiceClient.Credentials.IsAnonymous)
            {
                return string.Empty;
            }
            else if (blob.ServiceClient.Credentials.IsSAS)
            {
                return blob.ServiceClient.Credentials.SASToken;
            }

            // SAS life time is at least 10 minutes.
            TimeSpan sasLifeTime = TimeSpan.FromMinutes(CopySASLifeTimeInMinutes);

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

            return rootBlob.GetSharedAccessSignature(policy);
        }
    }
}