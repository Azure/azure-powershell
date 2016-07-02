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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure site Recovery Job.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryJob", DefaultParameterSetName = ASRParameterSets.ByParam)]
    [OutputType(typeof(IEnumerable<ASRJob>))]
    public class GetAzureSiteRecoveryJob : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ById, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

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
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByObject:
                        this.Id = this.Job.ID;
                        this.GetById();
                        break;

                    case ASRParameterSets.ById:
                        this.GetById();
                        break;

                    case ASRParameterSets.ByParam:
                    default:
                        this.GetByParam();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by ID.
        /// </summary>
        private void GetById()
        {
            this.WriteJob(RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(this.Id).Job);
        }

        /// <summary>
        /// Queries by Parameters.
        /// </summary>
        private void GetByParam()
        {
            JobQueryParameter jqp = new JobQueryParameter();

            if (this.StartTime.HasValue)
            {
                jqp.StartTime =
                    this.StartTime.Value.ToUniversalTime().ToBinary().ToString();
            }

            if (this.EndTime.HasValue)
            {
                jqp.EndTime =
                    this.EndTime.Value.ToUniversalTime().ToBinary().ToString();
            }

            jqp.State = this.State;
            jqp.ObjectId = this.TargetObjectId;

            this.WriteJobs(RecoveryServicesClient.GetAzureSiteRecoveryJob(jqp).Jobs);
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }

        /// <summary>
        /// Writes Jobs.
        /// </summary>
        /// <param name="jobs">Job objects</param>
        private void WriteJobs(IList<Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job> jobs)
        {
            this.WriteObject(jobs.Select(j => new ASRJob(j)), true);
        }
    }
}
