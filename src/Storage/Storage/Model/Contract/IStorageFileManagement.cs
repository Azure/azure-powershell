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
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// File management interface
    /// </summary>
    public interface IStorageFileManagement : IStorageManagement
    {
        bool IsSasWithOAuthCredential();

        /// <summary>
        ///  Returns a reference to a Microsoft.Azure.Storage.File.CloudFileShare
        ///  object with the specified name.
        /// </summary>
        /// <param name="shareName">A string containing the name of the share.</param>
        /// <param name="snapshotTime">Snapshot time to append.</param>
        /// <returns>A reference to a share.</returns>
        CloudFileShare GetShareReference(string shareName, DateTimeOffset? snapshotTime = null);

        /// <summary>
        /// Returns a task that performs an asynchronous operation to determine whether a
        /// directory exists.
        /// </summary>
        /// <param name="directory">
        /// Indicating the reference of the directory.
        /// </param>
        /// <param name="options">
        ///  A Microsoft.Azure.Storage.File.FileRequestOptions object that specifies
        ///  additional options for the request.
        /// </param>
        /// <param name="operationContext">
        ///  A Microsoft.WindowsAzure.Storage.OperationContext object that represents
        ///  the context for the current operation.
        ///  </param>
        /// <param name="cancellationToken">
        ///  A System.Threading.CancellationToken to observe while waiting for a task
        ///  to complete.
        /// </param>
        /// <returns>
        ///  A System.Threading.Tasks.Task object that represents the current operation.
        /// </returns>
        Task<bool> DirectoryExistsAsync(CloudFileDirectory directory, FileRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
    }
}
