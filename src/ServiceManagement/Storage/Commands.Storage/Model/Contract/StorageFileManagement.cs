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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
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

        public CloudFileShare GetShareReference(string shareName)
        {
            return this.Client.GetShareReference(shareName);
        }

        public async Task EnumerateFilesAndDirectoriesAsync(CloudFileDirectory directory, Action<IListFileItem> enumerationAction, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            FileContinuationToken continuationToken = null;
            do
            {
                var segment = await directory.ListFilesAndDirectoriesSegmentedAsync(null, continuationToken, options, operationContext, token);
                foreach (var item in segment.Results)
                {
                    enumerationAction(item);
                }

                continuationToken = segment.ContinuationToken;
            }
            while (continuationToken != null);
        }

        public Task FetchShareAttributesAsync(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            return share.FetchAttributesAsync(accessCondition, options, operationContext, token);
        }

        public async Task EnumerateSharesAsync(string prefix, ShareListingDetails detailsIncluded, Action<CloudFileShare> enumerationAction, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            FileContinuationToken continuationToken = null;
            do
            {
                var segment = await this.Client.ListSharesSegmentedAsync(prefix, detailsIncluded, null, continuationToken, options, operationContext, token);
                foreach (var item in segment.Results)
                {
                    enumerationAction(item);
                }

                continuationToken = segment.ContinuationToken;
            }
            while (continuationToken != null);
        }

        public Task CreateDirectoryAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return directory.CreateAsync(options, operationContext, cancellationToken);
        }

        public Task<bool> DirectoryExistsAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return directory.ExistsAsync(options, operationContext, cancellationToken);
        }

        public Task<bool> FileExistsAsync(CloudFile file, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return file.ExistsAsync(options, operationContext, cancellationToken);
        }

        public Task CreateShareAsync(CloudFileShare share, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return share.CreateAsync(options, operationContext, cancellationToken);
        }

        public Task DeleteDirectoryAsync(CloudFileDirectory directory, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return directory.DeleteAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public Task DeleteShareAsync(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return share.DeleteAsync(accessCondition, options, operationContext, cancellationToken);
        }

        public Task DeleteFileAsync(CloudFile file, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return file.DeleteAsync(accessCondition, options, operationContext, cancellationToken);
        }
    }
}
