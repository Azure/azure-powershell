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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.Queue;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.Remove, "AzureStorageQueue", SupportsShouldProcess = true),
        OutputType(typeof(Boolean))]
    public class RemoveAzureStorageQueueCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Queue")]
        [Parameter(Position = 0, HelpMessage = "Queue name",
                   Mandatory = true,
                   ValueFromPipeline = true,
                   ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Force to remove the queue and all content in it")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }

        private bool force;

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified queue is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageQueueCommand class.
        /// </summary>
        public RemoveAzureStorageQueueCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageQueueCommand class.
        /// </summary>
        /// <param name="channel">IStorageQueueManagement channel</param>
        public RemoveAzureStorageQueueCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// confirm the remove operation
        /// </summary>
        /// <param name="message">confirmation message</param>
        /// <returns>true if user confirm the operation, otherwise false</returns>
        internal virtual bool ConfirmRemove(string message)
        {
            return ShouldProcess(message);
        }

        /// <summary>
        /// remove an azure queue
        /// </summary>
        /// <param name="name">queue name</param>
        /// <returns>
        /// true if the queue is removed successfully, false if user cancel the remove operation,
        /// otherwise throw an exception
        /// </returns>
        internal bool RemoveAzureQueue(string name)
        {
            if (!NameUtil.IsValidQueueName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidQueueName, name));
            }

            QueueRequestOptions requestOptions = RequestOptions;
            CloudQueue queue = Channel.GetQueueReference(name);

            if (!Channel.DoesQueueExist(queue, requestOptions, OperationContext))
            {
                throw new ResourceNotFoundException(String.Format(Resources.QueueNotFound, name));
            }

            if (force || ShouldContinue(string.Format("Remove queue and all content in it: {0}", name), ""))
            {
                Channel.DeleteQueue(queue, requestOptions, OperationContext);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "Remove queue"))
            {
                String result = string.Empty;

                bool success = RemoveAzureQueue(Name);

                if (success)
                {
                    result = String.Format(Resources.RemoveQueueSuccessfully, Name);
                }
                else
                {
                    result = String.Format(Resources.RemoveQueueCancelled, Name);
                }

                WriteVerbose(result);

                if (PassThru)
                {
                    WriteObject(success);
                }
            }
        }
    }
}