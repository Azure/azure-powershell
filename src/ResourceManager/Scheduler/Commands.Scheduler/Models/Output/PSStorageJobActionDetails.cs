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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    using System;
    using SchedulerModels = Microsoft.Azure.Management.Scheduler.Models;

    public class PSStorageJobActionDetails : PSJobActionDetails
    {
        /// <summary>
        /// Gets or sets Storage account.
        /// </summary>
        public string StorageAccount { get; internal set; }

        /// <summary>
        /// Gets or sets Storage queue name.
        /// </summary>
        public string StorageQueueName { get; internal set; }

        /// <summary>
        /// Gets or sets Storage SAS token.
        /// </summary>
        public string StorageSasToken { get; internal set; }

        /// <summary>
        /// Gets or sets Storage queue message.
        /// </summary>
        public string StorageQueueMessage { get; internal set; }

        public PSStorageJobActionDetails(SchedulerModels.JobActionType jobActionType)
        {
            if (jobActionType != SchedulerModels.JobActionType.StorageQueue)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.JobActionType = jobActionType;
        }
    }
}
