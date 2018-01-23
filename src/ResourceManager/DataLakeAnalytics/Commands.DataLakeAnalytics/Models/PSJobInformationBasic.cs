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

using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    ///    A wrapper for all ADLA supported data sources.
    ///    This object is returned from a GET
    /// </summary>
    class PSJobInformationBasic : JobInformationBasic
    {
        /// <summary>
        /// Gets or sets the job specific properties.
        /// </summary>
        [Obsolete("This property is in JobInformation but removed in JobInformationBasic because the server does not return this property when listing jobs. This will be removed in a future release.")]
        public JobProperties Properties { get; private set; }

        /// <summary>
        /// Gets the error message details for the job, if the job failed.
        /// </summary>
        [Obsolete("This property is in JobInformation but removed in JobInformationBasic because the server does not return this property when listing jobs. This will be removed in a future release.")]
        public IList<JobErrorDetails> ErrorMessage { get; private set; }

        /// <summary>
        /// Gets the job state audit records, indicating when various
        /// operations have been performed on this job.
        /// </summary>
        [Obsolete("This property is in JobInformation but removed in JobInformationBasic because the server does not return this property when listing jobs. This will be removed in a future release.")]
        public IList<JobStateAuditRecord> StateAuditRecords { get; private set; }

        public PSJobInformationBasic(JobInformationBasic baseJob) :
            base(
                baseJob.Name,
                baseJob.Type,
                baseJob.JobId,
                baseJob.Submitter,
                baseJob.DegreeOfParallelism,
                baseJob.Priority,
                baseJob.SubmitTime,
                baseJob.StartTime,
                baseJob.EndTime,
                baseJob.State,
                baseJob.Result,
                baseJob.LogFolder,
                baseJob.LogFilePatterns,
                baseJob.Related)
        {
            this.Properties = null;
            this.ErrorMessage = null;
            this.StateAuditRecords = null;
        }
    }
}
