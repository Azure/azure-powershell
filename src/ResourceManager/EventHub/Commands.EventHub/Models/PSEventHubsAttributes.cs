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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Models
{
    public class PSEventHubAttributes
    {
        public PSEventHubAttributes()
        { }

        public PSEventHubAttributes(Microsoft.Azure.Management.EventHub.Models.Eventhub ehResource)
        {
            if (ehResource != null)
            {
                Name = ehResource.Name;
                CreatedAt = ehResource.CreatedAt;
                MessageRetentionInDays = ehResource.MessageRetentionInDays;
                PartitionCount = ehResource.PartitionCount;
                PartitionIds = ehResource.PartitionIds;
                Status = ehResource.Status;
                UpdatedAt = ehResource.UpdatedAt;
                if (ehResource.CaptureDescription != null)
                    CaptureDescription = new PSCaptureDescriptionAttributes(ehResource.CaptureDescription);
                else
                    CaptureDescription = null;
            }
        }

        public string Name { get; set; }
         
        /// <summary>
        /// Exact time the Event was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Number of days to retain the events for this Event Hub.
        /// </summary>
        public long? MessageRetentionInDays { get; set; }

        /// <summary>
        /// Number of partitions created for EventHub.
        /// </summary>
        public long? PartitionCount { get; set; }

        /// <summary>
        /// Current number of shards on the Event Hub.
        /// </summary>
        public IList<string> PartitionIds { get; set; }

        /// <summary>
        /// Enumerates the possible values for the status of the EventHub.
        /// Possible values include: 'Active', 'Disabled', 'Restoring',
        /// 'SendDisabled', 'ReceiveDisabled', 'Creating', 'Deleting',
        /// 'Renaming', 'Unknown'
        /// </summary>
        public EntityStatus? Status { get; set; }

        /// <summary>
        /// The exact time the message has been updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets properties of capture description
        /// </summary>
        public PSCaptureDescriptionAttributes CaptureDescription { get; set; }
    }
}
