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
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Storage Queue management
    /// </summary>
    public class StorageQueueManagement : IStorageQueueManagement
    {
        /// <summary>
        /// Cloud queue client
        /// </summary>
        private CloudQueueClient queueClient;

        /// <summary>
        /// Internal storage context
        /// </summary>
        private AzureStorageContext internalStorageContext;

        /// <summary>
        /// The azure storage context assoicated with this IStorageBlobManagement
        /// </summary>
        public AzureStorageContext StorageContext
        {
            get
            {
                return internalStorageContext;
            }
        }

        /// <summary>
        /// Queue management constructor
        /// </summary>
        /// <param name="client">Cloud queue client</param>
        public StorageQueueManagement(AzureStorageContext context)
        {
            internalStorageContext = context;
            queueClient = internalStorageContext.StorageAccount.CreateCloudQueueClient();
        }

        /// <summary>
        /// List storage queues
        /// </summary>
        /// <param name="prefix">Queue name prefix</param>
        /// <param name="queueListingDetails">Queue listing details</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of the queues in the storage account.</returns>
        public IEnumerable<CloudQueue> ListQueues(string prefix, QueueListingDetails queueListingDetails,
            QueueRequestOptions options, OperationContext operationContext)
        {
            return queueClient.ListQueues(prefix, queueListingDetails, options, operationContext);
        }

        /// <summary>
        /// Get an queue reference from azure server.
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>Cloud queue object if the specified queue exists, otherwise null.</returns>
        public CloudQueue GetQueueReferenceFromServer(string name, QueueRequestOptions options, OperationContext operationContext)
        {
            CloudQueue queue = queueClient.GetQueueReference(name);
            if (queue.Exists(options, operationContext))
            {
                return queue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Fetch queue attributes
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        public void FetchAttributes(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            queue.FetchAttributes(options, operationContext);
        }

        /// <summary>
        /// Get queue reference
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <returns>Cloud Queue object</returns>
        public CloudQueue GetQueueReference(string name)
        {
            return queueClient.GetQueueReference(name);
        }

        /// <summary>
        /// Create an cloud queue on azure if not exists.
        /// </summary>
        /// <param name="queue">Cloud queue object.</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the queue did not already exist and was created; otherwise false.</returns>
        public bool CreateQueueIfNotExists(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            return queue.CreateIfNotExists(options, operationContext);
        }

        /// <summary>
        /// Delete the specified storage queue.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        public void DeleteQueue(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            queue.Delete(options, operationContext);
        }

        /// <summary>
        /// Checks existence of the queue.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="requestOptions">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the queue exists, otherwise false</returns>
        public bool DoesQueueExist(CloudQueue queue, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            return queue.Exists(requestOptions, operationContext);
        }

        /// <summary>
        /// Get queue permission
        /// </summary>
        /// <param name="options">Queue request options </param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>QueuePermissions object</returns>
        public QueuePermissions GetPermissions(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            return queue.GetPermissions(options, operationContext);
        }

        /// <summary>
        /// Get queue permission async
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="requestOptions"></param>
        /// <param name="operationContext"></param>
        /// <returns></returns>
        public Task<QueuePermissions> GetPermissionsAsync(CloudQueue queue, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            return queue.GetPermissionsAsync(requestOptions, operationContext);
        }

        /// <summary>
        /// set queue permission
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="queuePermissions"></param>
        /// <param name="requestOptions"></param>
        /// <param name="operationContext"></param>
        public void SetPermissions(CloudQueue queue, QueuePermissions queuePermissions, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            queue.SetPermissions(queuePermissions, requestOptions, operationContext);
        }
    }
}
