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
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, "AzureStorageQueue"),
        OutputType(typeof(AzureStorageQueue))]
    public class NewAzureStorageQueueCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Queue")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Queue name",
             ValueFromPipeline = true,
             ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageQueueCommand class.
        /// </summary>
        public NewAzureStorageQueueCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageQueueCommand class.
        /// </summary>
        /// <param name="channel">IStorageQueueManagement channel</param>
        public NewAzureStorageQueueCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// create an azure queue
        /// </summary>
        /// <param name="name">queue name</param>
        /// <returns>an AzureStorageQueue object</returns>
        internal AzureStorageQueue CreateAzureQueue(string name)
        {
            if (!NameUtil.IsValidQueueName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidQueueName, name));
            }

            QueueRequestOptions requestOptions = RequestOptions;
            CloudQueue queue = Channel.GetQueueReference(name);
            bool created = Channel.CreateQueueIfNotExists(queue, requestOptions, OperationContext);

            if (!created)
            {
                throw new ResourceAlreadyExistException(String.Format(Resources.QueueAlreadyExists, name));
            }

            return new AzureStorageQueue(queue);
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            AzureStorageQueue azureQueue = CreateAzureQueue(Name);
            WriteObjectWithStorageContext(azureQueue);
        }
    }
}