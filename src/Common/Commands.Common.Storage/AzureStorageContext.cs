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

using System;
using Microsoft.WindowsAzure.Commands.Common.Storage.Properties;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    /// <summary>
    /// Storage context
    /// </summary>
    public class AzureStorageContext
    {
        private static AzureStorageContext emptyContextInstance = new AzureStorageContext();

        /// <summary>
        /// Storage account name used in this context
        /// </summary>
        public string StorageAccountName { get; private set; }

        /// <summary>
        /// Blob end point of the storage context
        /// </summary>
        public string BlobEndPoint { get; private set; }

        /// <summary>
        /// Table end point of the storage context
        /// </summary>
        public string TableEndPoint { get; private set; }

        /// <summary>
        /// Queue end point of the storage context
        /// </summary>
        public string QueueEndPoint { get; private set; }

        /// <summary>
        /// Self reference, it could enable New-AzureStorageContext can be used in pipeline 
        /// </summary>
        public AzureStorageContext Context { get; private set; }

        /// <summary>
        /// Name place holder, and force pipeline to ignore this property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Storage account in context
        /// </summary>
        public CloudStorageAccount StorageAccount { get; private set; }

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
                if (string.IsNullOrEmpty(BlobEndPoint) || string.IsNullOrEmpty(TableEndPoint))
                {
                    return string.Empty;
                }

                string suffix;

                if (StorageAccountName.EndsWith("blob", StringComparison.InvariantCultureIgnoreCase))
                {
                    // Cannot use the blob endpoint if the account name ends with blob...
                    // However it is OK if "blob" is in the account name but not as a suffix
                    int tableIndex = TableEndPoint.IndexOf("table.", 0, StringComparison.InvariantCultureIgnoreCase);
                    if (tableIndex <= 0)
                    {
                        suffix = string.Empty;
                    }
                    else
                    {
                        suffix = TableEndPoint.Substring(tableIndex + "table.".Length);
                    }
                }
                else
                {
                    int blobIndex = BlobEndPoint.IndexOf("blob.", 0, StringComparison.InvariantCultureIgnoreCase);
                    if (blobIndex <= 0)
                    {
                        suffix = string.Empty;
                    }
                    else
                    {
                        suffix = BlobEndPoint.Substring(blobIndex + "blob.".Length);
                    }
                }

                return suffix;
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
        private AzureStorageContext()
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
