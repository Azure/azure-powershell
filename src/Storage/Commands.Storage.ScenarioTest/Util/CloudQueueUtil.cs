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
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Commands.Storage.ScenarioTest.Util
{
    public class CloudQueueUtil
    {
        private CloudStorageAccount account;
        private CloudQueueClient client;
        private Random random;

        private CloudQueueUtil()
        { }

        /// <summary>
        /// init cloud queue util
        /// </summary>
        /// <param name="account">storage account</param>
        public CloudQueueUtil(CloudStorageAccount account)
        {
            this.account = account;
            client = account.CreateCloudQueueClient();
            random = new Random();
        }

        /// <summary>
        /// create a container with random properties and metadata
        /// </summary>
        /// <param name="queueName">container name</param>
        /// <returns>the created container object with properties and metadata</returns>
        public CloudQueue CreateQueue(string queueName)
        {
            CloudQueue queue = client.GetQueueReference(queueName);
            queue.CreateIfNotExists();

            int count = random.Next(1, 5);
            for (int i = 0; i < count; i++)
            {
                string metaKey = Utility.GenNameString("metatest");
                int valueLength = random.Next(10, 20);
                string metaValue = Utility.GenNameString("metavalue-", valueLength);
                queue.Metadata.Add(metaKey, metaValue);
            }

            queue.SetMetadata();

            return queue;
        }

        /// <summary>
        /// create mutiple containers
        /// </summary>
        /// <param name="queueNames">container names list</param>
        /// <returns>a list of container object</returns>
        public List<CloudQueue> CreateQueue(List<string> queueNames)
        {
            List<CloudQueue> queues = new List<CloudQueue>();

            foreach (string name in queueNames)
            {
                queues.Add(CreateQueue(name));
            }

            queues = queues.OrderBy(queue => queue.Name).ToList();

            return queues;
        }

        /// <summary>
        /// remove specified container
        /// </summary>
        /// <param name="queueName">container name</param>
        public void RemoveQueue(string queueName)
        {
            CloudQueue queue = client.GetQueueReference(queueName);
            queue.DeleteIfExists();
        }

        /// <summary>
        /// remove a list containers
        /// </summary>
        /// <param name="queueNames">container names</param>
        public void RemoveQueue(List<string> queueNames)
        {
            foreach (string name in queueNames)
            {
                RemoveQueue(name);
            }
        }

        public int GetExistingQueueCount()
        {
            List<CloudQueue> queues = client.ListQueues().ToList();
            return queues.Count;
        }
    }
}
