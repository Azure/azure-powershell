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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Resumes Azure Site Recovery Job.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Resume, "AzureRmSiteRecoveryJob", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(ASRJob))]
    public class ResumeAzureSiteRecoveryJob : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Job ID.
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
        /// Gets or sets job comments.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Comments { get; set; }
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
                    this.ResumesByName();
                    break;

                case ASRParameterSets.ByName:
                    this.ResumesByName();
                    break;
            }
        }

        /// <summary>
        /// Resumes by Name.
        /// </summary>
        private void ResumesByName()
        {
            ResumeJobParams resumeJobParams = new ResumeJobParams();
            if (string.IsNullOrEmpty(this.Comments))
            {
                this.Comments = " ";
            }

            resumeJobParams.Properties = new ResumeJobParamsProperties();
            resumeJobParams.Properties.Comments = this.Comments;

            LongRunningOperationResponse response = RecoveryServicesClient.ResumeAzureSiteRecoveryJob(this.Name, resumeJobParams);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}