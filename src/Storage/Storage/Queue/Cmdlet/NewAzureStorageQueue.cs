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
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueue"),OutputType(typeof(AzureStorageQueue))]
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
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (!NameUtil.IsValidQueueName(this.Name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidQueueName, this.Name));
            }

            QueueClient queueClient = Util.GetTrack2QueueClient(this.Name, (AzureStorageContext)this.Context, this.ClientOptions);
            queueClient.Create(cancellationToken: this.CmdletCancellationToken);
            QueueProperties queueProperties = queueClient.GetProperties(cancellationToken: this.CmdletCancellationToken);
            WriteObject(new AzureStorageQueue(queueClient, queueProperties, (AzureStorageContext)this.Context));
        }
    }
}
