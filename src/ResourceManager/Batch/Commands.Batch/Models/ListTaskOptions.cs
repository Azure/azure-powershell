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

using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class ListTaskOptions
    {
        /// <summary>
        /// The account details
        /// </summary>
        public BatchAccountContext Context { get; set; }

        /// <summary>
        /// The name of the WorkItem to query for Tasks
        /// </summary>
        public string WorkItemName { get; set; }

        /// <summary>
        /// The name of the Job to query for Tasks
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// If specified, the single Task with this name will be returned
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// The Job to query for Tasks
        /// </summary>
        public PSCloudJob Job { get; set; }

        /// <summary>
        /// The OData filter to use when querying for Tasks
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The maximum number of Tasks to return
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// Additional client behaviors to perform
        /// </summary>
        public IEnumerable<BatchClientBehavior> AdditionalBehaviors { get; set; }
    }
}
