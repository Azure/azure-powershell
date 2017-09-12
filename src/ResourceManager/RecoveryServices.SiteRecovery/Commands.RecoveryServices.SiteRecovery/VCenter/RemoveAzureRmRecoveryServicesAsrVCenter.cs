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

using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Removes the Azure Site Recovery vCenter.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRvCenter")]
    [OutputType(typeof(IEnumerable<ASRJob>))]
    public class RemoveAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the vCenter.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRvCenter InputObject { get; set; }

        [Parameter(
           ParameterSetName = ASRParameterSets.ByFabricObject,
           Mandatory = true,
           ValueFromPipeline = false)]
        public ASRFabric Fabric { get; set; }

        [Parameter(
          ParameterSetName = ASRParameterSets.ByFabricObject,
          Mandatory = true,
          ValueFromPipeline = false)]
        public string FriendlyName { get; set; }
        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(this.InputObject.FriendlyName, VerbsCommon.Remove))
            {

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByFabricObject:
                        this.RemovevCenterByName();
                        break;
                    case ASRParameterSets.Default:
                        this.RemovevCenter();
                        break;
                }
               
            }
        }

        /// <summary>
        ///     Removes the vCenter.
        /// </summary>
        private void RemovevCenter()
        {
            var response = this.RecoveryServicesClient.RemoveAzureRmSiteRecoveryvCenter(
                this.InputObject.FabricArmResourceName,
                this.InputObject.FriendlyName);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Removes the vCenter by Name and fabricObject.
        /// </summary>
        private void RemovevCenterByName()
        {
            var response = this.RecoveryServicesClient.RemoveAzureRmSiteRecoveryvCenter(
                this.Fabric.Name,
                this.FriendlyName);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}