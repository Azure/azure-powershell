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

namespace Microsoft.WindowsAzure.Commands.Storage.Queue
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// list azure queues
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageNouns.Queue, DefaultParameterSetName = NameParameterSet),
        OutputType(typeof(AzureStorageQueue))]
    public class GetAzureStorageQueueCommand : StorageQueueBaseCmdlet
    {
        /// <summary>
        /// default parameter set name
        /// </summary>
        private const string NameParameterSet = "QueueName";

        /// <summary>
        /// prefix parameter set name
        /// </summary>
        private const string PrefixParameterSet = "QueuePrefix";

        [Alias("N", "Queue")]
        [Parameter(Position = 0, HelpMessage = "Queue name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameParameterSet)]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Queue Prefix",
            ParameterSetName = PrefixParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageQueueCommand class.
        /// </summary>
        public GetAzureStorageQueueCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageQueueCommand class.
        /// </summary>
        /// <param name="channel">IStorageQueueManagement channel</param>
        public GetAzureStorageQueueCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// list azure queues by name
        /// </summary>
        /// <param name="name">queue name</param>
        /// <returns>An enumerable collection of CloudQueue objects</returns>
        internal IEnumerable<CloudQueue> ListQueuesByName(string name)
        {
            string prefix = String.Empty;
            QueueListingDetails queueListingDetails = QueueListingDetails.All;
            QueueRequestOptions requestOptions = RequestOptions;

            if (String.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
            {
                IEnumerable<CloudQueue> queues = Channel.ListQueues(prefix, queueListingDetails, requestOptions, OperationContext);

                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!string.IsNullOrEmpty(name))
                {
                    wildcard = new WildcardPattern(name, options);
                }

                foreach (CloudQueue queue in queues)
                {
                    if (wildcard == null || wildcard.IsMatch(queue.Name))
                    {
                        yield return queue;
                    }
                }
            }
            else
            {
                if (!NameUtil.IsValidQueueName(name))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidQueueName, name));
                }

                CloudQueue queue = Channel.GetQueueReference(name);

                if (Channel.DoesQueueExist(queue, requestOptions, OperationContext))
                {
                    yield return queue;
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(Resources.QueueNotFound, name));
                }
            }
        }

        /// <summary>
        /// list azure queues by prefix
        /// </summary>
        /// <param name="prefix">queue prefix</param>
        /// <returns>An enumerable collection of CloudQueue objects</returns>
        internal IEnumerable<CloudQueue> ListQueuesByPrefix(string prefix)
        {
            List<CloudQueue> queueList = new List<CloudQueue>();
            QueueListingDetails queueListingDetails = QueueListingDetails.All;
            QueueRequestOptions requestOptions = RequestOptions;

            if (!NameUtil.IsValidQueuePrefix(prefix))
            {
                throw new ArgumentException(String.Format(Resources.InvalidQueueName, prefix));
            }

            return Channel.ListQueues(prefix, queueListingDetails, requestOptions, OperationContext);
        }

        /// <summary>
        /// write azure queue with message count
        /// </summary>
        /// <param name="queueList">An enumerable collection of CloudQueue objects</param>
        internal void WriteQueueWithCount(IEnumerable<CloudQueue> queueList)
        {
            if (null == queueList)
            {
                return;
            }

            QueueRequestOptions requestOptions = RequestOptions;

            foreach (CloudQueue queue in queueList)
            {
                //get message count
                Channel.FetchAttributes(queue, requestOptions, OperationContext);
                AzureStorageQueue azureQueue = new AzureStorageQueue(queue);

                WriteObjectWithStorageContext(azureQueue);
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<CloudQueue> queueList = null;

            if (PrefixParameterSet == ParameterSetName)
            {
                queueList = ListQueuesByPrefix(Prefix);
            }
            else
            {
                queueList = ListQueuesByName(Name);
            }

            WriteQueueWithCount(queueList);
        }
    }
}