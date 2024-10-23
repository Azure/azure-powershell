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

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using System;

    /// <summary>
    /// Azure storage queue
    /// </summary>
    public class AzureStorageQueue : AzureStorageBase
    {
        /// <summary>
        /// XSCL Track2 Queue Client, used to run Queue APIs
        /// </summary>
        [Ps1Xml(Label = "Storage Account Name", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.QueueClient.AccountName")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0)]
        public QueueClient QueueClient { get; private set; }

        /// <summary>
        /// Queue uri
        /// </summary>
        [Ps1Xml(Label = "Uri", Target = ViewControl.Table, ScriptBlock = "$_.Uri", Position = 1)]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Approximate message count
        /// </summary>
        [Ps1Xml(Label = "ApproximateMessageCount", Target = ViewControl.Table, ScriptBlock = "$_.ApproximateMessageCount", Position = 2)]
        public int? ApproximateMessageCount { get; private set; }

        /// <summary>
        /// XSCL Track2 Queue properties, will retrieve the properties on server and return to user
        /// </summary>
        public global::Azure.Storage.Queues.Models.QueueProperties QueueProperties
        {
            get
            {
                if (privateQueueProperties == null)
                {
                    privateQueueProperties = QueueClient.GetProperties().Value;
                }
                return privateQueueProperties;
            }
        }
        private global::Azure.Storage.Queues.Models.QueueProperties privateQueueProperties = null;

        public AzureStorageQueue(QueueClient queueClient, QueueProperties queueProperties, AzureStorageContext storageContext)
        {
            Name = queueClient.Name;
            QueueClient = queueClient;
            Uri = queueClient.Uri;
            this.Context = storageContext;
            if (queueProperties != null)
            {
                privateQueueProperties = queueProperties;
                ApproximateMessageCount = queueProperties.ApproximateMessagesCount;
            }
        }
    }
}
