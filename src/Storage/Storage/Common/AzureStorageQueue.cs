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
    using Microsoft.Azure.Storage.Queue;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using global::Azure.Storage;
    using global::Azure.Storage.Queues;
    using Microsoft.WindowsAzure.Commands.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;

    /// <summary>
    /// Azure storage queue
    /// </summary>
    public class AzureStorageQueue : AzureStorageBase
    {
        /// <summary>
        /// Cloud Queue object
        /// </summary>
        [Ps1Xml(Label = "Queue End Point", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudQueue.ServiceClient.BaseUri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0)]
        public CloudQueue CloudQueue { get; private set; }

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
        /// Whether applied base64 encoding
        /// </summary>
        [Ps1Xml(Label = "EncodeMessage", Target = ViewControl.Table, ScriptBlock = "$_.EncodeMessage", Position = 3)]
        public bool EncodeMessage { get; private set; }

        /// <summary>
        /// XSCL Track2 Queue Client, used to run Queue APIs
        /// </summary>
        public QueueClient QueueClient
        {
            get
            {
                if (privateQueueClient == null)
                {
                    privateQueueClient = GetTrack2QueueClient(this.CloudQueue, (AzureStorageContext)this.Context);
                }
                return privateQueueClient;
            }
        }
        private QueueClient privateQueueClient = null;

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

        /// <summary>
        /// Azure storage queue constructor.
        /// </summary>
        /// <param name="queue">Cloud queue object</param>
        public AzureStorageQueue(CloudQueue queue)
        {
            CloudQueue = queue;
            Name = queue.Name;
            Uri = queue.Uri;
            ApproximateMessageCount = queue.ApproximateMessageCount;
            EncodeMessage = queue.EncodeMessage;
        }

        // Convert Track1 queue object to Track 2 queue Client
        protected static QueueClient GetTrack2QueueClient(CloudQueue cloudQueue, AzureStorageContext context)
        {
            QueueClient queueClient;
            if (cloudQueue.ServiceClient.Credentials.IsToken) //Oauth
            {
                if (context == null)
                {
                    //TODO : Get Oauth context from current login user.
                    throw new System.Exception("Need Storage Context to convert Track1 Blob object in token credentail to Track2 Blob object.");
                }
                queueClient = new QueueClient(cloudQueue.Uri, context.Track2OauthToken);
            }
            else if (cloudQueue.ServiceClient.Credentials.IsSAS) //SAS
            {
                string sas = Util.GetSASStringWithoutQuestionMark(cloudQueue.ServiceClient.Credentials.SASToken);
                string fullUri = cloudQueue.Uri.ToString();
                fullUri = fullUri + "?" + sas;
                queueClient = new QueueClient(new Uri(fullUri));
            }
            else if (cloudQueue.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                queueClient = new QueueClient(cloudQueue.Uri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloudQueue.ServiceClient.Credentials.ExportBase64EncodedKey()));
            }
            else //Anonymous
            {
                queueClient = new QueueClient(cloudQueue.Uri);
            }

            return queueClient;
        }
    }
}
