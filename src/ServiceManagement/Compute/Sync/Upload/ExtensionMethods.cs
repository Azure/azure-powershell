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

using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model.Persistence;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    internal static class CloudPageBlobExtensions
    {
        public static void SetUploadMetaData(this CloudPageBlob blob, LocalMetaData metaData)
        {
            if (metaData == null)
            {
                throw new ArgumentNullException("metaData");
            }
            blob.Metadata[LocalMetaData.MetaDataKey] = SerializationUtil.GetSerializedString(metaData);
        }

        public static void CleanUpUploadMetaData(this CloudPageBlob blob)
        {
            blob.Metadata.Remove(LocalMetaData.MetaDataKey);
        }

        public static LocalMetaData GetUploadMetaData(this CloudPageBlob blob)
        {
            if (blob.Metadata.Keys.Contains(LocalMetaData.MetaDataKey))
            {
                return SerializationUtil.GetObjectFromSerializedString<LocalMetaData>(blob.Metadata[LocalMetaData.MetaDataKey]);
            }
            return null;
        }

        public static byte[] GetBlobMd5Hash(this CloudPageBlob blob)
        {
            blob.FetchAttributes();
            if (String.IsNullOrEmpty(blob.Properties.ContentMD5))
            {
                return null;
            }

            return Convert.FromBase64String(blob.Properties.ContentMD5);
        }

        public static byte[] GetBlobMd5Hash(this CloudPageBlob blob, BlobRequestOptions requestOptions)
        {
            blob.FetchAttributes(new AccessCondition(), requestOptions);
            if (String.IsNullOrEmpty(blob.Properties.ContentMD5))
            {
                return null;
            }

            return Convert.FromBase64String(blob.Properties.ContentMD5);
        }

        public static void SetBlobMd5Hash(this CloudPageBlob blob, byte[] md5Hash)
        {
            var base64String = Convert.ToBase64String(md5Hash);
            blob.Properties.ContentMD5 = base64String;
        }

        public static void RemoveBlobMd5Hash(this CloudPageBlob blob)
        {
            blob.Properties.ContentMD5 = null;
        }

        public static VhdFooter GetVhdFooter(this CloudPageBlob basePageBlob)
        {
            var vhdFileFactory = new VhdFileFactory();
            using (var file = vhdFileFactory.Create(basePageBlob.OpenRead()))
            {
                return file.Footer;
            }
        }

        public static bool Exists(this CloudPageBlob blob)
        {
            var listBlobItems = blob.Container.ListBlobs();
            var blobToUpload = listBlobItems.FirstOrDefault(b => b.Uri == blob.Uri);
            if (blobToUpload is CloudBlockBlob)
            {
                var message = String.Format(" CsUpload is expecting a page blob, however a block blob was found: '{0}'.", blob.Uri);
                throw new InvalidOperationException(message);
            }
            return blobToUpload != null;
        }

        public static bool Exists(this CloudPageBlob blob, BlobRequestOptions options)
        {
            var listBlobItems = blob.Container.ListBlobs(null, false, BlobListingDetails.UncommittedBlobs, options);
            var blobToUpload = listBlobItems.FirstOrDefault(b => b.Uri == blob.Uri);
            if (blobToUpload is CloudBlockBlob)
            {
                var message = String.Format(" CsUpload is expecting a page blob, however a block blob was found: '{0}'.", blob.Uri);
                throw new InvalidOperationException(message);
            }
            return blobToUpload != null;
        }
    }

    internal static class StringExtensions
    {
        public static string ToString<T>(this IEnumerable<T> source, string separator)
        {
            return "[" + string.Join(",", source.Select(s => s.ToString()).ToArray()) + "]";
        }
    }

    public class VhdFilePath
    {
        public VhdFilePath(string absolutePath, string relativePath)
        {
            AbsolutePath = absolutePath;
            RelativePath = relativePath;
        }

        public string AbsolutePath { get; private set; }
        public string RelativePath { get; private set; }
    }

    internal static class VhdFileExtensions
    {
        public static IEnumerable<Guid> GetChildrenIds(this VhdFile vhdFile, Guid uniqueId)
        {
            var identityChain = vhdFile.GetIdentityChain();

            if (!identityChain.Contains(uniqueId))
            {
                yield break;
            }

            foreach (var id in identityChain.TakeWhile(id => id != uniqueId))
            {
                yield return id;
            }
        }

        public static VhdFilePath GetFilePathBy(this VhdFile vhdFile, Guid uniqueId)
        {
            VhdFilePath result = null;
            string baseVhdPath = String.Empty;
            var newBlocksOwners = new List<Guid> { Guid.Empty };

            var current = vhdFile;
            while (current != null && current.Footer.UniqueId != uniqueId)
            {
                newBlocksOwners.Add(current.Footer.UniqueId);
                if (current.Parent != null)
                {
                    result = new VhdFilePath(current.Header.GetAbsoluteParentPath(),
                                             current.Header.GetRelativeParentPath());
                }
                current = current.Parent;
            }

            if (result == null)
            {
                string message = String.Format("There is no parent VHD file with with the id '{0}'", uniqueId);
                throw new InvalidOperationException(message);
            }

            return result;
        }
    }

    public static class UriExtensions
    {
        /// <summary>
        /// Normalizes a URI for use as a blob URI.
        /// </summary>
        /// <remarks>
        /// Ensures that the container name is lower-case.
        /// </remarks>
        public static Uri NormalizeBlobUri(this Uri uri)
        {
            var ub = new UriBuilder(uri);
            var parts = ub.Path
                .Split(new char[] { '/' }, StringSplitOptions.None)
                .Select((p, i) => i == 1 ? p.ToLowerInvariant() : p)
                .ToArray();
            ub.Path = string.Join("/", parts);
            return ub.Uri;
        }

    }

    public static class ExceptionUtil
    {
        public static string DumpStorageExceptionErrorDetails(StorageException storageException)
        {
            if (storageException == null)
            {
                return string.Empty;
            }

            var message = new StringBuilder();
            message.AppendLine("StorageException details");
            message.Append("Error.Code:").AppendLine(storageException.RequestInformation.ExtendedErrorInformation.ErrorCode);
            message.Append("ErrorMessage:").AppendLine(storageException.RequestInformation.ExtendedErrorInformation.ErrorMessage);
            foreach (var key in storageException.RequestInformation.ExtendedErrorInformation.AdditionalDetails.Keys)
            {
                message.Append(key).Append(":").Append(storageException.RequestInformation.ExtendedErrorInformation.AdditionalDetails[key]);
            }
            return message.ToString();
        }
    }
}
