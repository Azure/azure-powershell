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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class WorkItemOperationParameters : BatchClientParametersBase
    {
        public WorkItemOperationParameters(BatchAccountContext context, string workItemName, PSCloudWorkItem workItem,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if (string.IsNullOrWhiteSpace(workItemName) && workItem == null)
            {
                throw new ArgumentNullException(Resources.NoWorkItem);
            }

            this.WorkItemName = workItemName;
            this.WorkItem = workItem;
        }

        /// <summary>
        /// The name of the workitem
        /// </summary>
        public string WorkItemName { get; private set; }

        /// <summary>
        /// The PSCloudWorkItem object representing the target workitem
        /// </summary>
        public PSCloudWorkItem WorkItem { get; private set; }
    }
}
