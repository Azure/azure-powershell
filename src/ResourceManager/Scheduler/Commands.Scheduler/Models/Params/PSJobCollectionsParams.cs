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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    using Microsoft.Azure.Management.Scheduler.Models;

    public class PSJobCollectionsParams
    {
        /// <summary>
        /// Gets or sets region to create job collection.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets targeted resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets name of the job collection.
        /// </summary>
        public string JobCollectionName { get; set; }

        /// <summary>
        /// Gets or sets job collection plan.
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        /// Gets or sets maximum jobs that could be created for the job collection.
        /// </summary>
        public int? MaxJobCount { get; set; }

        /// <summary>
        /// Gets or sets interval between retries
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        ///  Gets or sets the frequency of recurrence (Minute, Hour, Day, Week, Month).
        /// </summary>
        public string Frequency { get; set; }
    }
}
