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

using Azure.Storage.Files.Shares;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System;
    using System.IO;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using global::Azure.Storage.Sas;
    using global::Azure.Storage.Blobs.Specialized;
    using System.Collections.Generic;
    using System.Collections;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage;
    using global::Azure.Storage.Files.Shares.Models;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Queues;

    internal static class Util
    {
        /// <summary>
        /// Size formats
        /// </summary>
        private static string[] sizeFormats =
        {
            Resources.HumanReadableSizeFormat_Bytes,
            Resources.HumanReadableSizeFormat_KiloBytes,
            Resources.HumanReadableSizeFormat_MegaBytes,
            Resources.HumanReadableSizeFormat_GigaBytes,
            Resources.HumanReadableSizeFormat_TeraBytes,
            Resources.HumanReadableSizeFormat_PetaBytes,
            Resources.HumanReadableSizeFormat_ExaBytes
        };

        /// <summary>
        /// Translate a size in bytes to human readable form.
        /// </summary>
        /// <param name="size">Size in bytes.</param>
        /// <returns>Human readable form string.</returns>
        public static string BytesToHumanReadableSize(double size)
        {
            int order = 0;

            while (size >= 1024 && order + 1 < sizeFormats.Length)
            {
                ++order;
                size /= 1024;
            }

            return string.Format(sizeFormats[order], size);
        }

        public static CloudBlob GetBlobReferenceFromServer(
            CloudBlobContainer container,
            string blobName,
            AccessCondition accessCondition = null,
            BlobRequestOptions options = null,
            OperationContext operationContext = null,
            DateTimeOffset? snapshotTime = null)
        {
            CloudBlob blob = container.GetBlobReference(blobName, snapshotTime);
            return GetBlobReferenceFromServer(blob, accessCondition, options, operationContext);
        }

        public static CloudBlob GetBlobReferenceFromServer(CloudBlobClient client, Uri blobUri)
        {
            CloudBlob blob = new CloudBlob(blobUri, client.Credentials);
            return GetBlobReferenceFromServer(blob);
        }

        private static CloudBlob GetBlobReferenceFromServer(
            CloudBlob blob,
            AccessCondition accessCondition = null,
            BlobRequestOptions options = null,
            OperationContext operationContext = null,
            DateTimeOffset? snapshotTime = null)
        {
            try
            {
                Task.Run(() => blob.FetchAttributesAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
            {
                if (((StorageException)e.InnerException).RequestInformation == null ||
                    (((StorageException)e.InnerException).RequestInformation.HttpStatusCode != (int)HttpStatusCode.NotFound))
                {
                    throw e.InnerException;
                }

                return null;
            }
            catch (StorageException se)
            {
                if (se.RequestInformation == null ||
                    (se.RequestInformation.HttpStatusCode != (int)HttpStatusCode.NotFound))
                {
                    throw;
                }

                return null;
            }

            return GetCorrespondingTypeBlobReference(blob, operationContext);
        }

        public static CloudBlob GetCorrespondingTypeBlobReference(CloudBlob blob, OperationContext operationContext)
        {
            CloudBlob targetBlob;
            switch (blob.Properties.BlobType)
            {
                case BlobType.BlockBlob:
                    targetBlob = new CloudBlockBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                case BlobType.PageBlob:
                    targetBlob = new CloudPageBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                case BlobType.AppendBlob:
                    targetBlob = new CloudAppendBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blob.Properties.BlobType,
                        blob.Name));
            }

            try
            {
                Task.Run(() => targetBlob.FetchAttributesAsync(null, null, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
            {
                throw e.InnerException;
            }

            return targetBlob;
        }

        public static CloudBlob GetBlobReference(CloudBlobContainer container, string blobName, BlobType blobType)
        {
            switch (blobType)
            {
                case BlobType.BlockBlob:
                    return container.GetBlockBlobReference(blobName);
                case BlobType.PageBlob:
                    return container.GetPageBlobReference(blobName);
                case BlobType.AppendBlob:
                    return container.GetAppendBlobReference(blobName);
                default:
                    throw new ArgumentException(String.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blobType,
                        blobName));
            }
        }

        public static CloudBlob GetBlobReference(Uri blobUri, StorageCredentials storageCredentials, BlobType blobType)
        {
            switch (blobType)
            {
                case BlobType.BlockBlob:
                    return new CloudBlockBlob(blobUri, storageCredentials);
                case BlobType.PageBlob:
                    return new CloudPageBlob(blobUri, storageCredentials);
                case BlobType.AppendBlob:
                    return new CloudAppendBlob(blobUri, storageCredentials);
                case BlobType.Unspecified:
                    return new CloudBlob(blobUri, storageCredentials);
                default:
                    throw new ArgumentException(String.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blobType,
                        blobUri));
            }
        }

        public static IPAddressOrRange SetupIPAddressOrRangeForSAS(string inputIPACL)
        {
            if (string.IsNullOrEmpty(inputIPACL)) return null;

            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new IPAddressOrRange(inputIPACL);
            }
            else
            {
                return new IPAddressOrRange(inputIPACL.Substring(0, separator), inputIPACL.Substring(separator + 1));
            }
        }

        /// <summary>
        /// Create SAS IP range for use in SAS created
        /// </summary>
        /// <param name="inputIPACL">The input string should not be null as already checked outside</param>
        public static SasIPRange SetupIPAddressOrRangeForSASTrack2(string inputIPACL)
        {
            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new SasIPRange(IPAddress.Parse(inputIPACL));
            }
            else
            {
                return new SasIPRange(IPAddress.Parse(inputIPACL.Substring(0, separator)), IPAddress.Parse(inputIPACL.Substring(separator + 1)));
            }
        }

        public static XTable.IPAddressOrRange SetupTableIPAddressOrRangeForSAS(string inputIPACL)
        {
            if (string.IsNullOrEmpty(inputIPACL)) return null;

            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new XTable.IPAddressOrRange(inputIPACL);
            }
            else
            {
                return new XTable.IPAddressOrRange(inputIPACL.Substring(0, separator), inputIPACL.Substring(separator + 1));
            }
        }

        /// <summary>
        /// Used in DMlib ShouldOverwriteCallback, to convert object to blob/file/localpath, and return path
        /// </summary>
        /// <param name="instance">object instace</param>
        /// <returns>path of the object</returns>
        public static string ConvertToString(this object instance)
        {
            CloudBlob blob = instance as CloudBlob;

            if (null != blob)
            {
                return blob.SnapshotQualifiedUri.AbsoluteUri;
            }

            CloudFile file = instance as CloudFile;

            if (null != file)
            {
                return file.SnapshotQualifiedUri.AbsoluteUri;
            }

            return instance.ToString();
        }

        /// <summary>
        /// Get VersionID of a blob Uri.
        /// </summary>
        public static string GetVersionIdFromBlobUri(Uri BlobUri)
        {
            string versionIdQueryParameter = "versionid=";
            string[] queryBlocks = BlobUri.Query.Split(new char[] { '&', '?' });
            foreach (string block in queryBlocks)
            {
                if (block.StartsWith(versionIdQueryParameter))
                {
                    return block.Replace(versionIdQueryParameter, "");
                }
            }
            return null;
        }

        /// <summary>
        /// Get snapshot Time of a blob/file Uri.
        /// </summary>
        public static DateTimeOffset? GetSnapshotTimeFromUri(Uri itemUri)
        {
            string snapshotTimeString = GetSnapshotTimeStringFromUri(itemUri);
            if (snapshotTimeString != null)
            {
                return DateTimeOffset.Parse(snapshotTimeString).ToUniversalTime();
            }
            return null;
        }

        /// <summary>
        /// Get snapshot Time string of a blob/file Uri.
        /// </summary>
        public static string GetSnapshotTimeStringFromUri(Uri itemUri)
        {
            string snapshotQueryParameter = "snapshot=";
            string shareSnapshotQueryParameter = "sharesnapshot=";
            string[] queryBlocks = itemUri.Query.Split(new char[] { '&', '?' });
            foreach (string block in queryBlocks)
            {
                if (block.StartsWith(snapshotQueryParameter))
                {
                    return System.Web.HttpUtility.UrlDecode(block.Replace(snapshotQueryParameter, ""));
                }
                if (block.StartsWith(shareSnapshotQueryParameter))
                {
                    return System.Web.HttpUtility.UrlDecode(block.Replace(shareSnapshotQueryParameter, ""));
                }
            }
            return null;
        }

        public static global::Azure.Storage.Blobs.Models.BlobType? convertBlobType_Track1ToTrack2(Azure.Storage.Blob.BlobType track1type)
        {
            switch (track1type)
            {
                case Azure.Storage.Blob.BlobType.AppendBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Append;
                case Azure.Storage.Blob.BlobType.PageBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Page;
                case Azure.Storage.Blob.BlobType.BlockBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Block;
                default:
                    return null;
            }
        }

        public static Azure.Storage.Blob.BlobType convertBlobType_Track2ToTrack1(global::Azure.Storage.Blobs.Models.BlobType? track2type)
        {
            if (track2type == null)
            {
                return Azure.Storage.Blob.BlobType.Unspecified;
            }
            switch (track2type.Value)
            {
                case global::Azure.Storage.Blobs.Models.BlobType.Append:
                    return Azure.Storage.Blob.BlobType.AppendBlob;
                case global::Azure.Storage.Blobs.Models.BlobType.Page:
                    return Azure.Storage.Blob.BlobType.PageBlob;
                default:
                    return Azure.Storage.Blob.BlobType.BlockBlob;
            }
        }

        /// <summary>
        /// Convert a directory to hashtable
        /// Used in mata data convert
        /// </summary>
        public static Hashtable GetHashtableFromDictionary(IDictionary<string, string> dic)
        {
            if (dic == null)
            {
                return null;
            }
            Hashtable table = new Hashtable();
            foreach (string key in dic.Keys)
            {
                table.Add(key, dic[key]);
            }
            return table;
        }

        /// <summary>
        /// Get the Blob Type of the Track2 Blob client type
        /// </summary>
        /// <param name="blob"></param>
        /// <param name="CheckOnServer"> If Track2 blob Client don't contain blob type inforamtion, try to get it on server</param>
        public static global::Azure.Storage.Blobs.Models.BlobType? GetBlobType(BlobBaseClient blob, bool CheckOnServer = false)
        {
            if (blob is BlockBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Block;
            }
            if (blob is PageBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Page;
            }
            if (blob is AppendBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Append;
            }
            if (!CheckOnServer)
            {
                return null;
            }
            else
            {
                return blob.GetProperties().Value.BlobType;
            }
        }

        public static BlobBaseClient GetTrack2BlobClient(BlobContainerClient track2container, string blobName, AzureStorageContext context, string versionId = null, bool? IsCurrentVersion = null, string snapshot = null, BlobClientOptions options = null, global::Azure.Storage.Blobs.Models.BlobType? blobType = null, bool shouldTrimSlash = true)
        {
            //Get Track2 Blob Client Uri
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(track2container.Uri, trimBlobNameSlashes: shouldTrimSlash)
            {
                BlobName = blobName
            };
            if (versionId != null && (IsCurrentVersion == null || !IsCurrentVersion.Value)) // only none current version blob need versionId in Uri
            {
                blobUriBuilder.VersionId = versionId;
            }
            if (snapshot != null)
            {
                blobUriBuilder.Snapshot = snapshot;
            }
            if (shouldTrimSlash == false)
            {
                if (options == null)
                {
                    options = new BlobClientOptions();
                }
                options.TrimBlobNameSlashes = shouldTrimSlash;
            }

            return GetTrack2BlobClient(blobUriBuilder.ToUri(), context, options, blobType);
        }

        public static BlobBaseClient GetTrack2BlobClient(Uri blobUri, AzureStorageContext context, BlobClientOptions options = null, global::Azure.Storage.Blobs.Models.BlobType? blobType = null)
        {
            BlobBaseClient blobClient;
            if (options is null)
            {
                options = new BlobClientOptions();
            }
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsToken) //Oauth
            {
                if (blobType == null)
                {
                    blobClient = new BlobBaseClient(blobUri, context.Track2OauthToken, options);
                }
                else
                {
                    switch (blobType.Value)
                    {
                        case global::Azure.Storage.Blobs.Models.BlobType.Page:
                            blobClient = new PageBlobClient(blobUri, context.Track2OauthToken, options);
                            break;
                        case global::Azure.Storage.Blobs.Models.BlobType.Append:
                            blobClient = new AppendBlobClient(blobUri, context.Track2OauthToken, options);
                            break;
                        default: //Block
                            blobClient = new BlockBlobClient(blobUri, context.Track2OauthToken, options);
                            break;
                    }
                }
            }
            else if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey) //Shared Key
            {
                if (blobType == null)
                {
                    blobClient = new BlobBaseClient(blobUri, new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
                }
                else
                {
                    switch (blobType.Value)
                    {
                        case global::Azure.Storage.Blobs.Models.BlobType.Page:
                            blobClient = new PageBlobClient(blobUri, new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
                            break;
                        case global::Azure.Storage.Blobs.Models.BlobType.Append:
                            blobClient = new AppendBlobClient(blobUri, new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
                            break;
                        default: //Block
                            blobClient = new BlockBlobClient(blobUri, new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
                            break;
                    }
                }
            }
            else //SAS or Anonymous
            {
                if (blobType == null)
                {
                    blobClient = new BlobBaseClient(blobUri, options);
                }
                else
                {
                    switch (blobType.Value)
                    {
                        case global::Azure.Storage.Blobs.Models.BlobType.Page:
                            blobClient = new PageBlobClient(blobUri, options);
                            break;
                        case global::Azure.Storage.Blobs.Models.BlobType.Append:
                            blobClient = new AppendBlobClient(blobUri, options);
                            break;
                        default: //Block
                            blobClient = new BlockBlobClient(blobUri, options);
                            break;
                    }
                }
            }
            return blobClient;
        }

        public static BlobBaseClient GetTrack2BlobClientWithType(BlobBaseClient blob, AzureStorageContext context, global::Azure.Storage.Blobs.Models.BlobType blobType, BlobClientOptions options = null)
        {
            return GetTrack2BlobClient(blob.Uri, context, options, blobType);
        }

        public static BlobServiceClient GetTrack2BlobServiceClient(AzureStorageContext context, BlobClientOptions options = null)
        {
            BlobServiceClient blobServiceClient;
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsToken) //Oauth
            {
                blobServiceClient = new BlobServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, options);
            }
            else  //sas , key or Anonymous, use connection string
            {
                string connectionString = context.ConnectionString;

                // remove the "?" at the begin of SAS if any
                if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSAS)
                {
                    connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
                }
                blobServiceClient = new BlobServiceClient(connectionString, options);
            }
            return blobServiceClient;
        }

        public static DataLakeServiceClient GetTrack2DataLakeServiceClient(AzureStorageContext context, DataLakeClientOptions options = null)
        {
            DataLakeServiceClient serviceClient;
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsToken) //Oauth
            {
                serviceClient = new DataLakeServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, options);
            }
            else if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSharedKey) //key 
            {
                serviceClient = new DataLakeServiceClient(context.StorageAccount.BlobEndpoint, new StorageSharedKeyCredential(context.StorageAccountName, context.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
            }
            else if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSAS) //sas 
            {
                serviceClient = new DataLakeServiceClient(new Uri(context.StorageAccount.BlobEndpoint.ToString() + context.StorageAccount.Credentials.SASToken), options);
            }
            else // Anonymous
            {
                serviceClient = new DataLakeServiceClient(context.StorageAccount.BlobEndpoint, options);
            }
            return serviceClient;
        }
        /// <summary>
        /// Validate if Start Time and Expire time meet the requirement of userDelegationKey
        /// </summary>
        /// <param name="userDelegationKeyStartTime"></param>
        /// <param name="userDelegationKeyEndTime"></param>
        public static void ValidateUserDelegationKeyStartEndTime(DateTimeOffset userDelegationKeyStartTime, DateTimeOffset userDelegationKeyEndTime)
        {
            //Check the Expire Time and Start Time, should remove this if server can rerturn clear error message
            const double MAX_LIFE_TIME_DAYS = 7;
            TimeSpan maxLifeTime = TimeSpan.FromDays(MAX_LIFE_TIME_DAYS);
            if (userDelegationKeyEndTime <= DateTimeOffset.UtcNow)
            {
                throw new ArgumentException(string.Format("Expiry time {0} is earlier than now.", userDelegationKeyEndTime.ToString()));
            }
            else if (userDelegationKeyStartTime != null && userDelegationKeyStartTime >= userDelegationKeyEndTime)
            {
                throw new ArgumentException(string.Format("Start time {0} is later than expiry time {1}.", userDelegationKeyStartTime.ToString(), userDelegationKeyEndTime.ToString()));
            }
            else if (userDelegationKeyEndTime - DateTimeOffset.UtcNow > maxLifeTime)
            {
                throw new ArgumentException(string.Format("Generate User Delegation SAS with OAuth bases Storage context. User Delegate Key expiry time {0} must be in {1} days from now.",
                    userDelegationKeyEndTime.ToString(),
                    MAX_LIFE_TIME_DAYS));
            }
        }

        public static global::Azure.Storage.Blobs.Models.AccessTier? ConvertAccessTier_Track1ToTrack2(PremiumPageBlobTier? pageBlobTier)
        {
            if (pageBlobTier == null)
            {
                return null;
            }

            switch (pageBlobTier)
            {
                case PremiumPageBlobTier.P4:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P4;
                case PremiumPageBlobTier.P6:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P6;
                case PremiumPageBlobTier.P10:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P10;
                case PremiumPageBlobTier.P20:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P20;
                case PremiumPageBlobTier.P30:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P30;
                case PremiumPageBlobTier.P40:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P40;
                case PremiumPageBlobTier.P50:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P50;
                case PremiumPageBlobTier.P60:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P60;
                case PremiumPageBlobTier.P70:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P70;
                case PremiumPageBlobTier.P80:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P80;
                default:
                    return null;
            }
        }

        public static global::Azure.Storage.Blobs.Models.AccessTier? ConvertAccessTier_Track1ToTrack2(StandardBlobTier? standardBlobTier)
        {
            if (standardBlobTier == null)
            {
                return null;
            }

            switch (standardBlobTier)
            {
                case StandardBlobTier.Hot:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Hot;
                case StandardBlobTier.Cool:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Cool;
                case StandardBlobTier.Archive:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Archive;
                default:
                    return null;
            }
        }

        public static global::Azure.Storage.Blobs.Models.RehydratePriority? ConvertRehydratePriority_Track1ToTrack2(RehydratePriority? rehydratePriority)
        {
            if (rehydratePriority == null)
            {
                return null;
            }

            switch (rehydratePriority)
            {
                case RehydratePriority.High:
                    return global::Azure.Storage.Blobs.Models.RehydratePriority.High;
                case RehydratePriority.Standard:
                    return global::Azure.Storage.Blobs.Models.RehydratePriority.Standard;
                default:
                    return null;
            }
        }

        public static FileAttributes AzureFileNtfsAttributesToLocalAttributes(NtfsFileAttributes cloudFileNtfsAttributes)
        {
            FileAttributes fileAttributes = FileAttributes.Normal;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.ReadOnly) == NtfsFileAttributes.ReadOnly)
                fileAttributes |= FileAttributes.ReadOnly;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.Hidden) == NtfsFileAttributes.Hidden)
                fileAttributes |= FileAttributes.Hidden;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.System) == NtfsFileAttributes.System)
                fileAttributes |= FileAttributes.System;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.Directory) == NtfsFileAttributes.Directory)
                fileAttributes |= FileAttributes.Directory;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.Archive) == NtfsFileAttributes.Archive)
                fileAttributes |= FileAttributes.Archive;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.Temporary) == NtfsFileAttributes.Temporary)
                fileAttributes |= FileAttributes.Temporary;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.Offline) == NtfsFileAttributes.Offline)
                fileAttributes |= FileAttributes.Offline;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.NotContentIndexed) == NtfsFileAttributes.NotContentIndexed)
                fileAttributes |= FileAttributes.NotContentIndexed;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.NoScrubData) == NtfsFileAttributes.NoScrubData)
                fileAttributes |= FileAttributes.NoScrubData;

            if ((cloudFileNtfsAttributes & NtfsFileAttributes.None) == NtfsFileAttributes.None)
            {
                if (fileAttributes != FileAttributes.Normal)
                {
                    fileAttributes = fileAttributes & (~FileAttributes.Normal);
                }
            }

            return fileAttributes;
        }

        public static NtfsFileAttributes LocalAttributesToAzureFileNtfsAttributes(FileAttributes fileAttributes)
        {
            NtfsFileAttributes cloudFileNtfsAttributes = NtfsFileAttributes.None;

            if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                cloudFileNtfsAttributes |= NtfsFileAttributes.ReadOnly;

            if ((fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                cloudFileNtfsAttributes |= NtfsFileAttributes.Hidden;

            if ((fileAttributes & FileAttributes.System) == FileAttributes.System)
                cloudFileNtfsAttributes |= NtfsFileAttributes.System;

            if ((fileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                cloudFileNtfsAttributes |= NtfsFileAttributes.Directory;

            if ((fileAttributes & FileAttributes.Archive) == FileAttributes.Archive)
                cloudFileNtfsAttributes |= NtfsFileAttributes.Archive;

            if ((fileAttributes & FileAttributes.Normal) == FileAttributes.Normal)
                cloudFileNtfsAttributes |= NtfsFileAttributes.None;

            if ((fileAttributes & FileAttributes.Temporary) == FileAttributes.Temporary)
                cloudFileNtfsAttributes |= NtfsFileAttributes.Temporary;

            if ((fileAttributes & FileAttributes.Offline) == FileAttributes.Offline)
                cloudFileNtfsAttributes |= NtfsFileAttributes.Offline;

            if ((fileAttributes & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed)
                cloudFileNtfsAttributes |= NtfsFileAttributes.NotContentIndexed;

            if ((fileAttributes & FileAttributes.NoScrubData) == FileAttributes.NoScrubData)
                cloudFileNtfsAttributes |= NtfsFileAttributes.NoScrubData;

            if (cloudFileNtfsAttributes != NtfsFileAttributes.None) cloudFileNtfsAttributes &= (~NtfsFileAttributes.None);

            return cloudFileNtfsAttributes;
        }

        public static string GetSASStringWithoutQuestionMark(string sas)
        {
            if (sas.StartsWith("?"))
            {
                sas = sas.Substring(1);
            }
            return sas;
        }

        /// <summary>
        /// When request doesn't container a proper bearer token, server will return 401 error include the audience of the required bearer token.
        /// This function will get the audience of bearer token from SDK exception message.
        /// If server not return audience, will output null.
        /// </summary>
        public static string GetAudienceFrom401ExceptionMessage(string exceptionMessage)
        {
            string authenticateHeaderName = "WWW-Authenticate";
            string audienceName = "resource_id=";
            string[] exceptionMessageTexts = exceptionMessage.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string messageText in exceptionMessageTexts)
            {
                if (messageText.StartsWith(authenticateHeaderName))
                {
                    string[] authTexts = messageText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string authText in authTexts)
                    {
                        if (authText.StartsWith(audienceName))
                        {
                            return authText.Substring(audienceName.Length);
                        }
                    }
                }
            }
            return null;
        }

        public static ShareServiceClient GetTrack2FileServiceClient(AzureStorageContext context, ShareClientOptions options = null)
        {
            if (context == null || string.IsNullOrEmpty(context.ConnectionString))
            {
                throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
            }

            ShareServiceClient shareServiceClient;
            if (context.StorageAccount!= null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsToken) //Oauth
            {
                if (context.ShareTokenIntent != null)
                {
                    options.ShareTokenIntent = context.ShareTokenIntent.Value;   
                }
                shareServiceClient = new ShareServiceClient(context.StorageAccount.FileEndpoint, context.Track2OauthToken, options);
            }
            else  //sas , key or Anonymous, use connection string
            {
                string connectionString = context.ConnectionString;

                // remove the "?" at the begin of SAS if any
                if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSAS)
                {
                    connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
                }
                shareServiceClient = new ShareServiceClient(connectionString, options);
            }
            return shareServiceClient;
        }

        public static ShareClient GetTrack2ShareReference(string shareName, AzureStorageContext context, string snapshotTime = null, ShareClientOptions options = null)
        {
            ShareClient shareClient = GetTrack2FileServiceClient(context, options).GetShareClient(shareName);
            if (snapshotTime != null)
            {
                return shareClient.WithSnapshot(snapshotTime);
            }
            else
            {
                return shareClient;
            }
        }

        public static QueueClient GetTrack2QueueClient(string queueName, AzureStorageContext context, QueueClientOptions options)
        {
            if (context == null || string.IsNullOrEmpty(context.ConnectionString))
            {
                throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
            }

            string connectionString = context.ConnectionString;
            if (context != null && context.StorageAccount != null && context.StorageAccount.Credentials != null && context.StorageAccount.Credentials.IsSAS)
            {
                connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
            }

            QueueClient queueClient;

            queueClient = new QueueClient(connectionString, queueName, options);
            return queueClient;
        }

        /// <summary>
        /// Get SnapshotQualifiedUri without credential from a blob/file service item Uri.
        /// </summary>
        public static string GetSnapshotQualifiedUri(Uri itemUri)
        {
            string snapshotQueryParameter = "snapshot=";
            string shareSnapshotQueryParameter = "sharesnapshot=";
            string blobVersionQueryParameter = "versionid=";
            if (!string.IsNullOrEmpty(itemUri.Query))
            {
                string[] queryBlocks = itemUri.Query.Split(new char[] { '&', '?' });
                foreach (string block in queryBlocks)
                {
                    if (block.StartsWith(snapshotQueryParameter) || block.StartsWith(shareSnapshotQueryParameter) || block.StartsWith(blobVersionQueryParameter))
                    {
                        return itemUri.ToString().Replace(itemUri.Query, "?" + block);
                    }
                }
                return itemUri.ToString().Replace(itemUri.Query, "");
            }
            else
            {
                return itemUri.ToString();
            }
        }
    }
}
