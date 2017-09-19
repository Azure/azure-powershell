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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Service
{
    /// <summary>
    /// Mocked queue management
    /// </summary>
    public class MockStorageQueueManagement : IStorageQueueManagement
    {
        /// <summary>
        /// Exists queue lists
        /// </summary>
        public List<CloudQueue> queueList = new List<CloudQueue>();

        /// <summary>
        /// Queue end point
        /// </summary>
        private string QueueEndPoint = "http://127.0.0.1/account/";

        /// <summary>
        /// List storage queues
        /// </summary>
        /// <param name="prefix">Queue name prefix</param>
        /// <param name="queueListingDetails">Queue listing details</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of the queues in the storage account.</returns>
        public IEnumerable<CloudQueue> ListQueues(string prefix, QueueListingDetails queueListingDetails, QueueRequestOptions options, OperationContext operationContext)
        {
            if(string.IsNullOrEmpty(prefix))
            {
                return queueList;
            }
            else
            {
                List<CloudQueue> prefixQueues = new List<CloudQueue>();
                foreach(CloudQueue queue in queueList)
                {
                    if(queue.Name.StartsWith(prefix))
                    {
                        prefixQueues.Add(queue);
                    }
                }
                return prefixQueues;
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
            return;
        }

        /// <summary>
        /// Get queue reference
        /// </summary>
        /// <param name="name">Queue name</param>
        /// <returns>Cloud Queue object</returns>
        public CloudQueue GetQueueReference(string name)
        {
            Uri queueUri = new Uri(String.Format("{0}{1}", QueueEndPoint, name));
            return new CloudQueue(queueUri);
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
            CloudQueue queueRef = GetQueueReference(queue.Name);
            if (DoesQueueExist(queueRef, options, operationContext))
            {
                return false;
            }
            else
            {
                queueRef = GetQueueReference(queue.Name);
                queueList.Add(queueRef);
                return true;
            }
        }

        /// <summary>
        /// Delete the specified storage queue.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        public void DeleteQueue(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            foreach (CloudQueue queueRef in queueList)
            {
                if (queue.Name == queueRef.Name)
                {
                    queueList.Remove(queueRef);
                    return;
                }
            }
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
            foreach (CloudQueue queueRef in queueList)
            {
                if (queue.Name == queueRef.Name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get queue permission
        /// </summary>
        /// <param name="queue">CloudQueue object</param>
        /// <param name="options">Queue request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>Queue permission</returns>
        public QueuePermissions GetPermissions(CloudQueue queue, QueueRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public Task<QueuePermissions> GetPermissionsAsync(CloudQueue queue, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public void SetPermissions(CloudQueue queue, QueuePermissions queuePermissions, QueueRequestOptions requestOptions, OperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public AzureStorageContext StorageContext
        {
            get { throw new NotImplementedException(); }
        }
    }
}
