﻿// ----------------------------------------------------------------------------------
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
    }
}
