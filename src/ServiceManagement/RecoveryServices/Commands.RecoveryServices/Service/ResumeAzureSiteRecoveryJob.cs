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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Resumes Azure Site Recovery Job.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Resume, "AzureSiteRecoveryJob", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(ASRJob))]
    public class ResumeAzureSiteRecoveryJob : RecoveryServicesCmdletBase
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
        /// Gets or sets job comments.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Comments { get; set; }
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
            ResumeJobParams resumeJobParams = new ResumeJobParams();
            if (string.IsNullOrEmpty(this.Comments))
            {
                this.Comments = " ";
            }

            resumeJobParams.Comments = this.Comments;
            this.WriteJob(
                RecoveryServicesClient.ResumeAzureSiteRecoveryJob(this.Id, resumeJobParams).Job);
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}