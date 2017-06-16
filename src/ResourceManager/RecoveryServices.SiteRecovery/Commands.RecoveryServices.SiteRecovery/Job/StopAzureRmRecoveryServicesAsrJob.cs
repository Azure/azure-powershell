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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Resumes Azure Site Recovery Job.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop,
        "AzureRmRecoveryServicesAsrJob",
        DefaultParameterSetName = ASRParameterSets.ByObject)]
    [Alias("Stop-ASRJob")]
    [OutputType(typeof(ASRJob))]
    public class StopAzureRmRecoveryServicesAsrJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Job ID.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Job Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRJob Job { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByObject:
                    Name = Job.Name;
                    StopByName();
                    break;

                case ASRParameterSets.ByName:
                    StopByName();
                    break;
            }
        }

        /// <summary>
        ///     Restart by Name.
        /// </summary>
        private void StopByName()
        {
            var response = RecoveryServicesClient.CancelAzureSiteRecoveryJob(Name);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}