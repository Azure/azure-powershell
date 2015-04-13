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

using System.Collections;
using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class NewWorkItemParameters
    {
        /// <summary>
        /// The account details
        /// </summary>
        public BatchAccountContext Context { get; set; }

        /// <summary>
        /// The name of the WorkItem to create
        /// </summary>
        public string WorkItemName { get; set; }

        /// <summary>
        /// The Schedule to use when creating a new WorkItem
        /// </summary>
        public PSWorkItemSchedule Schedule { get; set; }

        /// <summary>
        /// The Job Specification to use when creating a new WorkItem
        /// </summary>
        public PSJobSpecification JobSpecification { get; set; }

        /// <summary>
        /// The Job Execution Enviornment to use when creating a new WorkItem
        /// </summary>
        public PSJobExecutionEnvironment JobExecutionEnvironment { get; set; }

        /// <summary>
        /// Metadata to add to the new WorkItem
        /// </summary>
        public IDictionary Metadata { get; set; }

        /// <summary>
        /// Additional client behaviors to perform
        /// </summary>
        public IEnumerable<BatchClientBehavior> AdditionalBehaviors { get; set; }
    }
}
