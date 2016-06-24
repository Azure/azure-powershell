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

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    using Microsoft.WindowsAzure.Commands.Common.Storage.Properties;
    using Microsoft.WindowsAzure.Storage;
    using System;

    /// <summary>
    /// Storage context
    /// </summary>
    public class AzureStorageContext
    {
        private static AzureStorageContext emptyContextInstance = new AzureStorageContext();

        /// <summary>
        /// Storage account name used in this context
        /// </summary>
        public string StorageAccountName { get; protected set; }

        /// <summary>
        /// Blob end point of the storage context
        /// </summary>
        public virtual string BlobEndPoint { get; protected set; }

        /// <summary>
        /// Table end point of the storage context
        /// </summary>
        public virtual string TableEndPoint { get; protected set; }

        /// <summary>
        /// Queue end point of the storage context
        /// </summary>
        public virtual string QueueEndPoint { get; protected set; }

        /// <summary>
        /// File end point of the storage context
        /// </summary>
        public virtual string FileEndPoint { get; protected set; }

        /// <summary>
        /// Self reference, it could enable New-AzureStorageContext can be used in pipeline 
        /// </summary>
        public AzureStorageContext Context { get; protected set; }

        /// <summary>
        /// Name place holder, and force pipeline to ignore this property
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Storage account in context
        /// </summary>
        public virtual CloudStorageAccount StorageAccount { get; protected set; }

        /// <summary>
        /// Endpoint suffix (everything after "table.", "blob." or "queue.")
        /// </summary>
        /// <returns>
        /// This will return an empty string if the endpoints are not correctly set. 
        /// </returns>
        public string EndPointSuffix
        {
            get
            {
                if (!string.IsNullOrEmpty(BlobEndPoint))
                {
                    string blobSpliter = "blob.";
                    if (BlobEndPoint.LastIndexOf(blobSpliter) >= 0)
                        return BlobEndPoint.Substring(BlobEndPoint.LastIndexOf(blobSpliter) + blobSpliter.Length);
                }
                if (!string.IsNullOrEmpty(TableEndPoint))
                {
                    string tableSpliter = "table.";
                    if (TableEndPoint.LastIndexOf(tableSpliter) >= 0)
                        return TableEndPoint.Substring(TableEndPoint.LastIndexOf(tableSpliter) + tableSpliter.Length);
                }
                if (!string.IsNullOrEmpty(QueueEndPoint))
                {
                    string queueSpliter = "queue.";
                    if (QueueEndPoint.LastIndexOf(queueSpliter) >= 0)
                        return QueueEndPoint.Substring(QueueEndPoint.LastIndexOf(queueSpliter) + queueSpliter.Length);
                }
                if (!string.IsNullOrEmpty(FileEndPoint))
                {
                    string fileSpliter = "file.";
                    if (FileEndPoint.LastIndexOf(fileSpliter) >= 0)
                        return FileEndPoint.Substring(FileEndPoint.LastIndexOf(fileSpliter) + fileSpliter.Length);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Create a storage context usign cloud storage account
        /// </summary>
        /// <param name="account">cloud storage account</param>
        public AzureStorageContext(CloudStorageAccount account)
        {
            StorageAccount = account;

            if (account.BlobEndpoint != null)
            {
                BlobEndPoint = account.BlobEndpoint.ToString();
            }

            if (account.TableEndpoint != null)
            {
                TableEndPoint = account.TableEndpoint.ToString();
            }

            if (account.QueueEndpoint != null)
            {
                QueueEndPoint = account.QueueEndpoint.ToString();
            }

            if (account.FileEndpoint != null)
            {
                FileEndPoint = account.FileEndpoint.ToString();
            }

            StorageAccountName = account.Credentials.AccountName;
            Context = this;
            Name = String.Empty;

            if (string.IsNullOrEmpty(StorageAccountName))
            {
                if (account.Credentials.IsSAS)
                {
                    StorageAccountName = Resources.SasTokenAccountName;
                }
                else
                {
                    StorageAccountName = Resources.AnonymousAccountName;
                }
            }
        }

        /// <summary>
        /// Proivides a private constructor for building empty instance which
        /// contains no account information.
        /// </summary>
        protected AzureStorageContext()
        {
        }

        public static AzureStorageContext EmptyContextInstance
        {
            get
            {
                return emptyContextInstance;
            }
        }
    }
}
