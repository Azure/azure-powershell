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
    using global::Azure;
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// list azure queues
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueue", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageQueue))]
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
        [SupportsWildcards()]
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
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            QueueServiceClient queueServiceClient = Util.GetTrack2QueueServiceClient((AzureStorageContext)this.Context, this.ClientOptions);
            switch (this.ParameterSetName)
            {
                case NameParameterSet:
                    if (String.IsNullOrEmpty(this.Name) || WildcardPattern.ContainsWildcardCharacters(this.Name))
                    {
                        WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                        WildcardPattern wildcard = null;

                        if (!string.IsNullOrEmpty(this.Name))
                        {
                            wildcard = new WildcardPattern(this.Name, options);
                        }

                        Pageable<QueueItem> queueItems = queueServiceClient.GetQueues(cancellationToken: this.CmdletCancellationToken);
                        foreach (QueueItem queueItem in queueItems)
                        {
                            if (wildcard == null || wildcard.IsMatch(queueItem.Name))
                            {
                                QueueClient queueClient = queueServiceClient.GetQueueClient(queueItem.Name);
                                QueueProperties queueProperties = queueClient.GetProperties(cancellationToken: this.CmdletCancellationToken);
                                WriteObjectWithStorageContext(new AzureStorageQueue(queueClient, queueProperties, (AzureStorageContext)this.Context));
                            }
                        }
                    }
                    else
                    {
                        if (!NameUtil.IsValidQueueName(this.Name))
                        {
                            throw new ArgumentException(String.Format(Resources.InvalidQueueName, this.Name));
                        }
                        QueueClient queueClient = queueServiceClient.GetQueueClient(this.Name);
                        if (!queueClient.Exists(CmdletCancellationToken)) {
                            throw new ResourceNotFoundException(String.Format(Resources.QueueNotFound, this.Name));
                        }
                        QueueProperties queueProperties = queueClient.GetProperties(cancellationToken: this.CmdletCancellationToken);
                        WriteObjectWithStorageContext(new AzureStorageQueue(queueClient, queueProperties, (AzureStorageContext)this.Context));
                    }
                    break;

                case PrefixParameterSet:
                    if (!NameUtil.IsValidQueuePrefix(this.Prefix))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidQueueName, this.Prefix));
                    }
                    Pageable<QueueItem> items = queueServiceClient.GetQueues(prefix: this.Prefix, cancellationToken: this.CmdletCancellationToken);
                    foreach (QueueItem queueItem in items)
                    {
                        QueueClient queueClient = queueServiceClient.GetQueueClient(queueItem.Name);
                        QueueProperties queueProperties = queueClient.GetProperties(cancellationToken: this.CmdletCancellationToken);
                        WriteObjectWithStorageContext(new AzureStorageQueue(queueClient, queueProperties, (AzureStorageContext)this.Context));
                    }
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }
        }
    }
}
