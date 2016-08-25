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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure site Recovery Job.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryJob", DefaultParameterSetName = ASRParameterSets.ByParam)]
    [OutputType(typeof(IEnumerable<ASRJob>))]
    public class GetAzureSiteRecoveryJob : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Job Name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRJob Job { get; set; }

        /// <summary>
        /// Gets or sets start time. Allows to filter the list of jobs started after the given 
        /// start time.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, HelpMessage = "Represents start time of jobs to querying, jobs with the start time later than this will be returned")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets end time. Allows to filter the list of jobs ended before it.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, HelpMessage = "Represents end time of jobs to query.")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets target object id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, HelpMessage = "ID of the object on which Job was targeted to.")]
        [ValidateNotNullOrEmpty]
        public string TargetObjectId { get; set; }

        /// <summary>
        /// Gets or sets state. Take string input for possible States of ASR Job. Use this parameter 
        /// to get filtered view of Jobs
        /// </summary>
        /// Considered Valid states from WorkflowStatus enum in SRS (WorkflowData.cs)
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, HelpMessage = "State of job to return.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            "NotStarted",
            "InProgress",
            "Succeeded",
            "Other",
            "Failed",
            "Cancelled",
            "Suspended")]
        public string State { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObject:
                    this.Name = this.Job.Name;
                    this.GetByName();
                    break;

                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;

                case ASRParameterSets.ByParam:
                default:
                    this.GetByParam();
                    break;
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            this.WriteJob(RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(this.Name).Job);
        }

        /// <summary>
        /// Queries by Parameters.
        /// </summary>
        private void GetByParam()
        {
            JobQueryParameter jqp = new JobQueryParameter();

            if (this.StartTime.HasValue)
            {
                jqp.StartTime = this.StartTime.Value.ToUniversalTime().ToString("o");
            }

            if (this.EndTime.HasValue)
            {
                jqp.EndTime = this.EndTime.Value.ToUniversalTime().ToString("o");
            }

            if (this.State != null)
            {
                jqp.JobStatus = new List<string>();
                jqp.JobStatus.Add(this.State);
            }

            IList<Management.SiteRecovery.Models.Job> completeJobsList = RecoveryServicesClient.GetAzureSiteRecoveryJob(jqp).Jobs;

            // Filtering TargetObjectId
            IEnumerable<Management.SiteRecovery.Models.Job> filteredJobsList = completeJobsList.ToArray().AsEnumerable();
            if (this.TargetObjectId != null)
            {
                filteredJobsList = filteredJobsList.Where(j => 0 == string.Compare(j.Properties.TargetObjectId.ToString(),
                     this.TargetObjectId.ToString(), StringComparison.OrdinalIgnoreCase));
            }

            this.WriteJobs(filteredJobsList.ToList());
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.Azure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }

        /// <summary>
        /// Writes Jobs.
        /// </summary>
        /// <param name="jobs">Job objects</param>
        private void WriteJobs(IList<Microsoft.Azure.Management.SiteRecovery.Models.Job> jobs)
        {
            this.WriteObject(jobs.Select(j => new ASRJob(j)), true);
        }
    }
}
