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

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Storage queue management interface
    /// </summary>
    public interface IStorageQueueManagement : IStorageManagement
    {
        /// <summary>
        /// List storage queues
        /// </summary>
        /// <param name="prefix">Queue name prefix</param>
        /// <param name="queueListingDetails">Queue listing details</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of the queues in the storage account.</returns>
        IEnumerable<CloudQueue> ListQueues(string prefix, QueueListingDetails queueListingDetails,
            QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Fetch queue attributes
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        void FetchAttributes(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Get queue reference
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <returns>Cloud Queue object</returns>
        CloudQueue GetQueueReference(String name);

        /// <summary>
        /// Checks existence of the queue.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="requestOptions">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the queue exists, otherwise false</returns>
        bool DoesQueueExist(CloudQueue queue, QueueRequestOptions requestOptions, OperationContext operationContext);

        /// <summary>
        /// Create an cloud queue on azure if not exists.
        /// </summary>
        /// <param name="queue">Cloud queue object.</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the queue did not already exist and was created; otherwise false.</returns>
        bool CreateQueueIfNotExists(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Delete the specified storage queue.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        void DeleteQueue(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Get queue permission
        /// </summary>
        /// <param name="options">Queue request options </param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>QueuePermissions object</returns>
        QueuePermissions GetPermissions(CloudQueue queue, QueueRequestOptions options = null, OperationContext operationContext = null);


        /// <summary>
        /// Get queue permission async
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="requestOptions"></param>
        /// <param name="operationContext"></param>
        /// <returns></returns>
        Task<QueuePermissions> GetPermissionsAsync(CloudQueue queue, QueueRequestOptions requestOptions = null, OperationContext operationContext = null);

        /// <summary>
        /// set queue permission
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="queuePermissions"></param>
        /// <param name="requestOptions"></param>
        /// <param name="operationContext"></param>
        void SetPermissions(CloudQueue queue, QueuePermissions queuePermissions, QueueRequestOptions requestOptions = null, OperationContext operationContext = null);
    }
}
