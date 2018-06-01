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

using Microsoft.Azure.Management.Sql.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobModel : AzureSqlElasticJobBaseModel
    {
        /// <summary>
        /// Gets or sets the description of the job
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the job version
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// Gets or sets the job schedule start time
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the job schedule end time
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the job schedule type - Once or Recurring
        /// </summary>
        public JobScheduleType? ScheduleType { get; set; }

        /// <summary>
        /// Gets or sets the job's enabled value.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets the job's schedule interval value.
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// The job schedule intervals
        /// </summary>
        public enum JobScheduleReccuringScheduleTypes
        {
            Minute,
            Hour,
            Day,
            Week,
            Month
        }
    }
}