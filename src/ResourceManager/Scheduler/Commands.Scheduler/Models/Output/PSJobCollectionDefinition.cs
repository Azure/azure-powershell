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
    public class PSJobCollectionDefinition
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; internal set; }

        /// <summary>
        /// Gets or sets job collection name.
        /// </summary>
        public string JobCollectionName { get; internal set; }

        /// <summary>
        /// Gets or sets location of job collection.
        /// </summary>
        public string Location { get; internal set; }

        /// <summary>
        /// Gets or sets job collection plan.
        /// </summary>
        public string Plan { get; internal set; }

        /// <summary>
        /// Gets or sets job collection state.
        /// </summary>
        public string State { get; internal set; }

        /// <summary>
        /// Gets or sets maximum jobs that could be created for the job collection.
        /// </summary>
        public string MaxJobCount { get; internal set; }

        /// <summary>
        /// Gets or sets maximum recurrence.
        /// </summary>
        public string MaxRecurrence { get; internal set; }

        /// <summary>
        /// Gets or sets full job collection uri.
        /// </summary>
        public string Uri { get; internal set; }
    }
}
