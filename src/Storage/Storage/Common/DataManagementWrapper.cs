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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.DataMovement;
    using Microsoft.WindowsAzure.Storage.File;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class DataManagementWrapper : ITransferManager
    {
        // Powershell could be ran either in 32bit or 64bit
        // The default algorithm to calculate the size may be too much if PSH is ran under 32bit on a 64bit OS with big memory
        private const int Maximum32bitCacheSize = 512 * 1024 * 1024;

        public DataManagementWrapper(int concurrency)
        {
            TransferManager.Configurations.ParallelOperations = concurrency;
            TransferManager.Configurations.UserAgentPrefix = ApiConstants.UserAgentHeaderValue;
        }


        /// <summary>
        /// Download an Azure file from Azure File Storage.
        /// </summary>
        /// <param name="sourceFile">The Microsoft.WindowsAzure.Storage.File.CloudFile that is the source Azure file.</param>
        /// <param name="destPath">Path to the destination file.</param>
        /// <param name="options">A Microsoft.WindowsAzure.Storage.DataMovement.DownloadOptions object that specifies additional options for the operation.</param>
        /// <param name="context">A Microsoft.WindowsAzure.Storage.DataMovement.TransferContext object that represents
        ///     the context for the current operation.</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken object to observe while waiting for a task to complete.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public Task DownloadAsync(CloudFile sourceFile, string destPath, DownloadOptions options, SingleTransferContext context, CancellationToken cancellationToken)
        {
            return TransferManager.DownloadAsync(sourceFile, destPath, options, context, cancellationToken);
        }

        /// <summary>
        /// Download an Azure blob from Azure Blob Storage.
        /// </summary>
        /// <param name="sourceBlob">The Microsoft.WindowsAzure.Storage.Blob.CloudBlob that is the source Azure blob.</param>
        /// <param name="destPath">Path to the destination file.</param>
        /// <param name="options">A Microsoft.WindowsAzure.Storage.DataMovement.DownloadOptions object that specifies
        ///     additional options for the operation.</param>
        /// <param name="context">A Microsoft.WindowsAzure.Storage.DataMovement.TransferContext object that represents
        ///     the context for the current operation.</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken object to observe while waiting for a task
        ///     to complete.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public Task DownloadAsync(CloudBlob sourceBlob, string destPath, DownloadOptions options, SingleTransferContext context, CancellationToken cancellationToken)
        {
            return TransferManager.DownloadAsync(sourceBlob, destPath, options, context, cancellationToken);
        }

        /// <summary>
        /// Upload a file to Azure File Storage.
        /// </summary>
        /// <param name="sourcePath">Path to the source file.</param>
        /// <param name="destFile">The Microsoft.WindowsAzure.Storage.File.CloudFile that is the destination Azure file.</param>
        /// <param name="options">An Microsoft.WindowsAzure.Storage.DataMovement.UploadOptions object that specifies
        ///     additional options for the operation.</param>
        /// <param name="context"> A Microsoft.WindowsAzure.Storage.DataMovement.TransferContext object that represents
        ///     the context for the current operation.</param>
        /// <param name="cancellationToken"> A System.Threading.CancellationToken object to observe while waiting for a task
        ///     to complete.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public Task UploadAsync(string sourcePath, CloudFile destFile, UploadOptions options, SingleTransferContext context, CancellationToken cancellationToken)
        {
            return TransferManager.UploadAsync(sourcePath, destFile, options, context, cancellationToken);
        }

        /// <summary>
        /// Upload a file to Azure Blob Storage.
        /// </summary>
        /// <param name="sourcePath">Path to the source file.</param>
        /// <param name="destBlob">The Microsoft.WindowsAzure.Storage.Blob.CloudBlob that is the destination Azure blob.</param>
        /// <param name="options">An Microsoft.WindowsAzure.Storage.DataMovement.UploadOptions object that specifies
        ///     additional options for the operation.</param>
        /// <param name="context">A Microsoft.WindowsAzure.Storage.DataMovement.TransferContext object that represents
        ///     the context for the current operation.</param>
        /// <param name="cancellationToken">A System.Threading.CancellationToken object to observe while waiting for a task
        ///     to complete.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public Task UploadAsync(string sourcePath, CloudBlob destBlob, UploadOptions options, SingleTransferContext context, CancellationToken cancellationToken)
        {
            return TransferManager.UploadAsync(sourcePath, destBlob, options, context, cancellationToken);
        }
    }
}
