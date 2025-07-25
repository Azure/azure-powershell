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

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// File management
    /// </summary>
    public class StorageFileManagement : IStorageFileManagement
    {
        private CloudFileClient client;

        public StorageFileManagement(AzureStorageContext context)
        {
            this.StorageContext = context;
        }

        public AzureStorageContext StorageContext
        {
            get;
            private set;
        }

        private CloudFileClient Client
        {
            get
            {
                if (this.client == null)
                {
                    if (this.StorageContext.StorageAccount == null)
                    {
                        throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
                    }
                    else
                    {
                        this.client = this.StorageContext.StorageAccount.CreateCloudFileClient();
                    }
                }

                return this.client;
            }
        }

        public CloudFileShare GetShareReference(string shareName, DateTimeOffset? snapshotTime = null)
        {
            return this.Client.GetShareReference(shareName, snapshotTime);
        }

        public Task<bool> DirectoryExistsAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return directory.ExistsAsync(options, operationContext, cancellationToken);
        }
    }
}
