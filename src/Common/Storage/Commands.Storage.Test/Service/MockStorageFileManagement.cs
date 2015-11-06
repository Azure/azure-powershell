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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Management.Storage.Test.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Management.Storage.Test.Service
{
    public sealed class MockStorageFileManagement : IStorageFileManagement
    {
        private const string MockupConnectionString = "DefaultEndpointsProtocol=http;AccountName=MockUp;AccountKey=FjUfNl1KiJttbXlsdkMzBTC7WagvrRM9/g6UPBuy0ypCpAbYTL6/KA+dI/7gyoWvLFYmah3IviUP1jykOHHOlA==";

        private CloudFileClient client = CloudStorageAccount.Parse(MockupConnectionString).CreateCloudFileClient();

        private Dictionary<string, IListFileItem[]> enumerationResults = new Dictionary<string, IListFileItem[]>();

        private List<string> availableShareNames = new List<string>();

        private List<string> availableDirectoryNames = new List<string>();

        public void SetsEnumerationResults(string directoryName, IEnumerable<IListFileItem> enumerationItems)
        {
            this.enumerationResults[directoryName] = enumerationItems.ToArray();
        }

        public void SetsAvailableShare(params string[] shareNames)
        {
            availableShareNames.AddRange(shareNames);
        }

        public void SetsAvailableDirectories(params string[] directoryNames)
        {
            this.availableDirectoryNames.AddRange(directoryNames);
        }

        public CloudFileShare GetShareReference(string shareName)
        {
            return client.GetShareReference(shareName);
        }

        public void FetchShareAttributes(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public void SetShareProperties(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public Task EnumerateFilesAndDirectoriesAsync(CloudFileDirectory directory, Action<IListFileItem> enumerationAction, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            IListFileItem[] enumerationItems;
            if (this.enumerationResults.TryGetValue(directory.Name, out enumerationItems))
            {
                foreach (var item in enumerationItems)
                {
                    enumerationAction(item);
                }

                return TaskEx.FromResult(true);
            }
            else
            {
                throw new MockupException("DirectoryNotFound");
            }
        }

        public Task FetchShareAttributesAsync(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            if (this.availableShareNames.Contains(share.Name))
            {
                return TaskEx.FromResult(true);
            }
            else
            {
                throw new MockupException("ShareNotExist");
            }
        }

        public Task EnumerateSharesAsync(string prefix, ShareListingDetails detailsIncluded, Action<CloudFileShare> enumerationAction, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            foreach (var shareName in this.availableShareNames)
            {
                if (shareName.StartsWith(prefix))
                {
                    enumerationAction(this.client.GetShareReference(shareName));
                }
            }

            return TaskEx.FromResult(true);
        }

        public Task CreateDirectoryAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(true);
        }

        public Task<bool> DirectoryExistsAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(this.availableDirectoryNames.Contains(directory.Name));
        }

        public Task<bool> FileExistsAsync(CloudFile file, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(true);
        }

        public Task CreateShareAsync(CloudFileShare share, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(share);
        }

        public Task DeleteDirectoryAsync(CloudFileDirectory directory, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(true);
        }

        public Task DeleteShareAsync(CloudFileShare share, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(true);
        }

        public Task DeleteFileAsync(CloudFile file, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return TaskEx.FromResult(true);
        }

        public AzureStorageContext StorageContext
        {
            get { throw new NotImplementedException(); }
        }

        public Task<FileSharePermissions> GetSharePermissionsAsync(CloudFileShare share, AccessCondition accessCondition,
            FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public FileSharePermissions GetSharePermissions(CloudFileShare share, AccessCondition accessCondition = null,
            FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public void SetSharePermissions(CloudFileShare share, FileSharePermissions permissions,
            AccessCondition accessCondition = null,
            FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task FetchFileAttributesAsync(CloudFile file, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken token)
        {
            if (this.availableDirectoryNames.Contains(file.Name))
            {
                return TaskEx.FromResult(true);
            }
            else
            {
                throw new MockupException("FileNotFound");
            }
        }

        public Task FetchDirectoryAttributesAsync(CloudFileDirectory directory, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            if (this.availableDirectoryNames.Contains(directory.Name))
            {
                return TaskEx.FromResult(true);
            }
            else
            {
                throw new MockupException("DirectoryNotFound");
            }
        }

        public Task AbortCopyAsync(CloudFile file, string copyId, AccessCondition accessCondition, FileRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
