﻿// ----------------------------------------------------------------------------------
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
    using System.Globalization;
    using System.Net;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

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
            OperationContext operationContext = null)
        {
            CloudBlob blob = container.GetBlobReference(blobName);
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
            OperationContext operationContext = null)
        {
            try
            {
                blob.FetchAttributes(accessCondition, options, operationContext);
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

            return GetCorrespondingTypeBlobReference(blob);
        }

        public static CloudBlob GetCorrespondingTypeBlobReference(CloudBlob blob)
        {
            if (BlobType.BlockBlob == blob.Properties.BlobType)
            {
                return new CloudBlockBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
            }

            if (BlobType.PageBlob == blob.Properties.BlobType)
            {
                return new CloudPageBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
            }

            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidBlobType, blob.Name));
        }
    }
}
