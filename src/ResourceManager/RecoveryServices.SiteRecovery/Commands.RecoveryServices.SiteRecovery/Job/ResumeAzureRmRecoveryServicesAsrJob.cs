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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Resumes Azure Site Recovery Job.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Resume,
        "AzureRmRecoveryServicesAsrJob",
        DefaultParameterSetName = ASRParameterSets.ByObject,
        SupportsShouldProcess = true)]
    [Alias("Resume-ASRJob")]
    [OutputType(typeof(ASRJob))]
    public class ResumeAzureRmRecoveryServicesAsrJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Job Object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Job")]
        public ASRJob InputObject { get; set; }

        /// <summary>
        ///     Gets or sets job comments.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [Alias("Comments")]
        public string Comment { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.InputObject != null)
            {
                this.Name = this.InputObject.Name;
            }

            if (this.ShouldProcess(
                this.Name,
                VerbsLifecycle.Resume))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByObject:
                        this.Name = this.InputObject.Name;
                        this.ResumesByName();
                        break;

                    case ASRParameterSets.ByName:
                        this.ResumesByName();
                        break;
                }
            }
        }

        /// <summary>
        ///     Resumes by Name.
        /// </summary>
        private void ResumesByName()
        {
            var resumeJobParams = new ResumeJobParams();
            if (string.IsNullOrEmpty(this.Comment))
            {
                this.Comment = " ";
            }

            resumeJobParams.Properties = new ResumeJobParamsProperties();
            resumeJobParams.Properties.Comments = this.Comment;
            var job = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(this.Name);
            if (job != null)
            {
                if (job.Properties.ScenarioName.Equals("TestFailover", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException(
                      string.Format(Resources.ResumeTFOJobNotSupported, job.Name));
                }
            }
            var response = this.RecoveryServicesClient.ResumeAzureSiteRecoveryJob(
                this.Name,
                resumeJobParams);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}