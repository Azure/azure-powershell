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
    public class InvalidCloudFile : CloudFile
    {
        public InvalidCloudFile(Uri objectAbsoluteUri, StorageCredentials credentials)
            : base(objectAbsoluteUri, credentials)
        {
            string objectUri = objectAbsoluteUri.ToString();
            if (credentials != null && credentials.IsSAS)
            {
                objectUri = objectUri.Replace(credentials.SASSignature, "[Sig]");
            }
            exception = new InvalidOperationException(string.Format("Only support run action on this Azure file with 'ShareFileClient', not support with 'CloudFile'. File Uri: {0}.", objectAbsoluteUri));
        }
        private InvalidOperationException exception;


        public override Stream OpenRead(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenRead(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenRead(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override Stream EndOpenRead(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync()
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<Stream> OpenReadAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<Stream> OpenReadAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override CloudFileStream OpenWrite(long? size, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenWrite(long? size, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginOpenWrite(long? size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override CloudFileStream EndOpenWrite(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<CloudFileStream> OpenWriteAsync(long? size)
        {
            throw exception;
        }

        public override Task<CloudFileStream> OpenWriteAsync(long? size, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<CloudFileStream> OpenWriteAsync(long? size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<CloudFileStream> OpenWriteAsync(long? size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void DownloadToStream(Stream target, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToStream(Stream target, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToStream(Stream target, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndDownloadToStream(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void DownloadToFile(string path, FileMode mode, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToFile(string path, FileMode mode, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndDownloadToFile(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override int DownloadToByteArray(byte[] target, int index, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadToByteArray(byte[] target, int index, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override int EndDownloadToByteArray(IAsyncResult asyncResult)
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

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override string DownloadText(Encoding encoding = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadText(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadText(Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override string EndDownloadText(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<string> DownloadTextAsync()
        {
            throw exception;
        }

        public override Task<string> DownloadTextAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void DownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToStream(Stream target, long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndDownloadRangeToStream(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

 
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override int DownloadRangeToByteArray(byte[] target, int index, long? fileOffset, long? length, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? fileOffset, long? length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginDownloadRangeToByteArray(byte[] target, int index, long? fileOffset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override int EndDownloadRangeToByteArray(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? fileOffset, long? length)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? fileOffset, long? length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? fileOffset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? fileOffset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? fileOffset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void UploadFromStream(Stream source, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override void UploadFromStream(Stream source, long length, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromStream(Stream source, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromStream(Stream source, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromStream(Stream source, long length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromStream(Stream source, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndUploadFromStream(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, long length)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, long length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void UploadFromFile(string path, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromFile(string path, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromFile(string path, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndUploadFromFile(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task UploadFromFileAsync(string path)
        {
            throw exception;
        }

        public override Task UploadFromFileAsync(string path, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromFileAsync(string path, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UploadFromFileAsync(string path, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task UploadFromFileAsync(string path, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void UploadFromByteArray(byte[] buffer, int index, int count, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromByteArray(byte[] buffer, int index, int count, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadFromByteArray(byte[] buffer, int index, int count, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndUploadFromByteArray(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            throw exception;
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void UploadText(string content, Encoding encoding = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadText(string content, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginUploadText(string content, Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndUploadText(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task UploadTextAsync(string content)
        {
            throw exception;
        }

        public override Task UploadTextAsync(string content, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void Create(long size, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreate(long size, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCreate(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndCreate(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task CreateAsync(long size)
        {
            throw exception;
        }

        public override Task CreateAsync(long size, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task CreateAsync(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task CreateAsync(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override bool Exists(FileRequestOptions options = null, OperationContext operationContext = null)
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

        public override void Delete(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
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

        public override bool DeleteIfExists(AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override IEnumerable<FileRange> ListRanges(long? offset = null, long? length = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginListRanges(AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginListRanges(long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override IEnumerable<FileRange> EndListRanges(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<IEnumerable<FileRange>> ListRangesAsync()
        {
            throw exception;
        }

        public override Task<IEnumerable<FileRange>> ListRangesAsync(CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<IEnumerable<FileRange>> ListRangesAsync(long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<IEnumerable<FileRange>> ListRangesAsync(long? offset, long? length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override FileHandleResultSegment ListHandlesSegmented(FileContinuationToken token = null, int? maxResults = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginListHandlesSegmented(FileContinuationToken token, int? maxResults, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override FileHandleResultSegment EndListHandlesSegmented(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<FileHandleResultSegment> ListHandlesSegmentedAsync(FileContinuationToken token = null, int? maxResults = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
        {
            throw exception;
        }

        public override CloseFileHandleResultSegment CloseAllHandlesSegmented(FileContinuationToken token = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCloseAllHandlesSegmented(FileContinuationToken token, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override CloseFileHandleResultSegment EndCloseAllHandlesSegmented(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<CloseFileHandleResultSegment> CloseAllHandlesSegmentedAsync(FileContinuationToken token = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
        {
            throw exception;
        }

        public override CloseFileHandleResultSegment CloseHandleSegmented(string handleId, FileContinuationToken token = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginCloseHandleSegmented(string handleId, FileContinuationToken token, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override CloseFileHandleResultSegment EndCloseHandleSegmented(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<CloseFileHandleResultSegment> CloseHandleSegmentedAsync(string handleId, FileContinuationToken token = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
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

        public override void Resize(long size, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginResize(long size, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginResize(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndResize(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task ResizeAsync(long size)
        {
            throw exception;
        }

        public override Task ResizeAsync(long size, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task ResizeAsync(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task ResizeAsync(long size, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
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

        public override void WriteRange(Stream rangeData, long startOffset, string contentMD5 = null, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override void WriteRange(Uri sourceUri, long sourceOffset, long count, long destOffset, Checksum sourceContentChecksum = null, AccessCondition sourceAccessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginWriteRange(Stream rangeData, long startOffset, string contentMD5, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginWriteRange(Stream rangeData, long startOffset, string contentMD5, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginWriteRange(Stream rangeData, long startOffset, string contentMD5, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndWriteRange(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task WriteRangeAsync(Stream rangeData, long startOffset, string contentMD5)
        {
            throw exception;
        }

        public override Task WriteRangeAsync(Stream rangeData, long startOffset, string contentMD5, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task WriteRangeAsync(Stream rangeData, long startOffset, string contentMD5, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task WriteRangeAsync(Stream rangeData, long startOffset, string contentMD5, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task WriteRangeAsync(Stream rangeData, long startOffset, string contentMD5, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            throw exception;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task WriteRangeAsync(Uri sourceUri, long sourceOffset, long count, long destOffset, Checksum sourceContentChecksum = null, AccessCondition sourceAccessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null, CancellationToken? cancellationToken = null)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw exception;
        }

        public override void ClearRange(long startOffset, long length, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginClearRange(long startOffset, long length, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginClearRange(long startOffset, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndClearRange(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task ClearRangeAsync(long startOffset, long length)
        {
            throw exception;
        }

        public override Task ClearRangeAsync(long startOffset, long length, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task ClearRangeAsync(long startOffset, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task ClearRangeAsync(long startOffset, long length, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override string StartCopy(Uri source, AccessCondition sourceAccessCondition = null, AccessCondition destAccessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override string StartCopy(CloudFile source, AccessCondition sourceAccessCondition = null, AccessCondition destAccessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(Uri source, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(CloudFile source, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginStartCopy(CloudFile source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override string EndStartCopy(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(CloudFile source)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(CloudFile source, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(CloudFile source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task<string> StartCopyAsync(CloudFile source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override void AbortCopy(string copyId, AccessCondition accessCondition = null, FileRequestOptions options = null, OperationContext operationContext = null)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAbortCopy(string copyId, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override ICancellableAsyncResult BeginAbortCopy(string copyId, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, AsyncCallback callback, object state)
        {
            throw exception;
        }

        public override void EndAbortCopy(IAsyncResult asyncResult)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, CancellationToken cancellationToken)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext)
        {
            throw exception;
        }

        public override Task AbortCopyAsync(string copyId, AccessCondition accessCondition, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw exception;
        }
    }
}
