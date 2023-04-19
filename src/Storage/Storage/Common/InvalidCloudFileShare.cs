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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.Core.Util;
    using Microsoft.Azure.Storage.File;
    using Microsoft.Azure.Storage.File.Protocol;
    using Microsoft.Azure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This class is used to handle the Azure file which can't be handle in Track1 File Object, like .
    /// </summary>
    public class InvalidCloudFileShare : CloudFileShare
    {
        public InvalidCloudFileShare(Uri objectAbsoluteUri, StorageCredentials credentials)
            : base(objectAbsoluteUri, credentials)
        {
            string objectUri = objectAbsoluteUri.ToString();
            if (credentials != null && credentials.IsSAS)
            {
                objectUri = objectUri.Replace(credentials.SASSignature, "[Sig]");
            }
            exception = new InvalidOperationException(string.Format("Only support run action on this Azure file share with 'ShareClient', not support with 'CloudFileShare'. Share Uri: {0}.", objectAbsoluteUri));
        }
        private InvalidOperationException exception;

        public override void Create(FileRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreate(FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndCreate(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task CreateAsync()
        {
            throw exception;
        }

        public override Task CreateAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task CreateAsync(FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task CreateAsync(FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override bool CreateIfNotExists(FileRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreateIfNotExists(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreateIfNotExists(FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override bool EndCreateIfNotExists(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<bool> CreateIfNotExistsAsync()
        {
            throw exception;
        }

        public override Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<bool> CreateIfNotExistsAsync(FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<bool> CreateIfNotExistsAsync(FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void Delete(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override void Delete(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDelete(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDelete(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndDelete(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task DeleteAsync()
        {
            throw exception;
        }

        public override Task DeleteAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DeleteAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DeleteAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DeleteAsync(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override bool DeleteIfExists(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override bool DeleteIfExists(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDeleteIfExists(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDeleteIfExists(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<bool> DeleteIfExistsAsync()
        {
            throw exception;
        }

        public override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<bool> DeleteIfExistsAsync(DeleteShareSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override bool Exists(FileRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginExists(FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override bool EndExists(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync()
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync(FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync(FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void FetchAttributes(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndFetchAttributes(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task FetchAttributesAsync()
        {
            throw exception;
        }

        public override Task FetchAttributesAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override FileSharePermissions GetPermissions(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetPermissions(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override FileSharePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<FileSharePermissions> GetPermissionsAsync()
        {
            throw exception;
        }

        public override Task<FileSharePermissions> GetPermissionsAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<FileSharePermissions> GetPermissionsAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<FileSharePermissions> GetPermissionsAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override ShareStats GetStats(FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetStats(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetStats(FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ShareStats EndGetStats(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<ShareStats> GetStatsAsync()
        {
            throw exception;
        }

        public override Task<ShareStats> GetStatsAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<ShareStats> GetStatsAsync(FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<ShareStats> GetStatsAsync(FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void SetMetadata(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndSetMetadata(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task SetMetadataAsync()
        {
            throw exception;
        }

        public override Task SetMetadataAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void SetPermissions(FileSharePermissions permissions, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetPermissions(FileSharePermissions permissions, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetPermissions(FileSharePermissions permissions, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndSetPermissions(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task SetPermissionsAsync(FileSharePermissions permissions)
        {
            throw exception;
        }

        public override Task SetPermissionsAsync(FileSharePermissions permissions, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task SetPermissionsAsync(FileSharePermissions permissions, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task SetPermissionsAsync(FileSharePermissions permissions, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void SetProperties(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetProperties(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetProperties(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndSetProperties(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync()
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override string CreateFilePermission(string permission, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<string> CreateFilePermissionAsync(string permission, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
        {
            throw exception;
        }

        public override string GetFilePermission(string filePermissionKey, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<string> GetFilePermissionAsync(string filePermissionKey, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
        {
            throw exception;
        }

        //public override CloudFileDirectory GetRootDirectoryReference()
        //{
        //    throw exception;
        //}
    }
}
