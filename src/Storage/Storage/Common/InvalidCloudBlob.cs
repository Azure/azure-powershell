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
    using Microsoft.Azure.Storage.Blob;
    using System;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.Azure.Storage.Core.Util;
    using Microsoft.Azure.Storage.Shared.Protocol;

    /// <summary>
    /// This class is used to handle the Blob Type which can't be handle in Track1 Blob Object, like blob version.
    /// </summary>
    public class InvalidCloudBlob : CloudBlob
    {
        public InvalidCloudBlob(Uri blobAbsoluteUri, StorageCredentials credentials)
            : base(blobAbsoluteUri)
        {
            string blobUri = blobAbsoluteUri.ToString();
            if (credentials != null && credentials.IsSAS)
            {
                blobUri = blobUri.Replace(credentials.SASSignature, "[Sig]");
            }
            exception = new InvalidOperationException(string.Format("Only support run action on this blob with 'BlobBaseClient', not support with 'ICloudBlob'. Blob Uri: {0}.", blobUri));
        }
        private InvalidOperationException exception;


        public override void AbortCopy(string copyId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId)
        {
            throw exception;
        }

        public override string AcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAbortCopy(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAbortCopy(string copyId, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAcquireLease(TimeSpan? leaseTime, string proposedLeaseId, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginBreakLease(TimeSpan? breakPeriod, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDelete(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDeleteIfExists(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToStream(Stream target, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToStream(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginExists(BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginFetchAttributes(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetAccountProperties(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginGetAccountProperties(BlobRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenRead(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenRead(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginReleaseLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginRenewLease(AccessCondition accessCondition, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginRotateEncryptionKey(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginRotateEncryptionKey(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetMetadata(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetProperties(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSetProperties(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSnapshot(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginSnapshot(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(Uri source, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUndelete(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUndelete(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override TimeSpan BreakLease(TimeSpan? breakPeriod = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            throw exception;
        }

        public override Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override string ChangeLease(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            throw exception;
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void Delete(DeleteSnapshotsOption deleteSnapshotsOption = DeleteSnapshotsOption.None, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DeleteAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DeleteAsync()
        {
            throw exception;
        }

        public override Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override bool DeleteIfExists(DeleteSnapshotsOption deleteSnapshotsOption = DeleteSnapshotsOption.None, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
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

        public override Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override int DownloadRangeToByteArray(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void DownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override int DownloadToByteArray(byte[] target, int index, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void DownloadToFile(string path, FileMode mode, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadToFileParallelAsync(string path, FileMode mode, int parallelIOCount, long? rangeSizeInBytes, long offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToFileParallelAsync(string path, FileMode mode, int parallelIOCount, long? rangeSizeInBytes)
        {
            throw exception;
        }

        public override Task DownloadToFileParallelAsync(string path, FileMode mode, int parallelIOCount, long? rangeSizeInBytes, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void DownloadToStream(Stream target, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target)
        {
            throw exception;
        }

        public override void EndAbortCopy(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override string EndAcquireLease(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override TimeSpan EndBreakLease(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override string EndChangeLease(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndDelete(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override bool EndDeleteIfExists(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override int EndDownloadRangeToByteArray(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndDownloadRangeToStream(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override int EndDownloadToByteArray(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndDownloadToFile(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndDownloadToStream(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override bool EndExists(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndFetchAttributes(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override AccountProperties EndGetAccountProperties(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Stream EndOpenRead(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndReleaseLease(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndRenewLease(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndRotateEncryptionKey(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndSetMetadata(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndSetProperties(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override CloudBlob EndSnapshot(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override string EndStartCopy(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override void EndUndelete(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override bool Exists(BlobRequestOptions options = null, OperationContext operationContext = null)
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

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<bool> ExistsAsync(bool primaryOnly, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void FetchAttributes(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
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

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override AccountProperties GetAccountProperties(BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<AccountProperties> GetAccountPropertiesAsync(BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<AccountProperties> GetAccountPropertiesAsync(BlobRequestOptions requestOptions, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<AccountProperties> GetAccountPropertiesAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<AccountProperties> GetAccountPropertiesAsync()
        {
            throw exception;
        }

        //public override string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange)
        //{
        //    throw exception;
        //}

        //public override string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        //{
        //    throw exception;
        //}

        //public override string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers)
        //{
        //    throw exception;
        //}

        //public override string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier)
        //{
        //    throw exception;
        //}

        //public override string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        //{
        //    throw exception;
        //}

        //public override string GetUserDelegationSharedAccessSignature(UserDelegationKey delegationKey, SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers = null, SharedAccessProtocol? protocols = null, IPAddressOrRange ipAddressOrRange = null)
        //{
        //    throw exception;
        //}

        public override Stream OpenRead(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync()
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void ReleaseLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            throw exception;
        }

        public override void RenewLease(AccessCondition accessCondition, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            throw exception;
        }

        public override Task RenewLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void RotateEncryptionKey(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task RotateEncryptionKeyAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task RotateEncryptionKeyAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task RotateEncryptionKeyAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task RotateEncryptionKeyAsync()
        {
            throw exception;
        }

        public override void SetMetadata(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task SetMetadataAsync()
        {
            throw exception;
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task SetMetadataAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void SetProperties(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task SetPropertiesAsync()
        {
            throw exception;
        }

        public override Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override CloudBlob Snapshot(IDictionary<string, string> metadata = null, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<CloudBlob> SnapshotAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<CloudBlob> SnapshotAsync()
        {
            throw exception;
        }

        public override Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override string StartCopy(Uri source, AccessCondition sourceAccessCondition = null, AccessCondition destAccessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, PremiumPageBlobTier? premiumPageBlobTier, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, StandardBlobTier? standardBlockBlobTier, RehydratePriority? rehydratePriority, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source)
        {
            throw exception;
        }

        public override void Undelete(AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override Task UndeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UndeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UndeleteAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UndeleteAsync()
        {
            throw exception;
        }
    }
    
}
