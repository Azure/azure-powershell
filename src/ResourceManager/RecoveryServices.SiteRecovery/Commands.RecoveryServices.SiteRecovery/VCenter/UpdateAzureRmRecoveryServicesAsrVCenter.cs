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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Updates the Azure Site Recovery vCenter.
    /// </summary>
    [Cmdlet(
        VerbsData.Update,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Update-ASRvCenter")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {

        /// <summary>
        ///     Gets or sets Resource Id.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        /// <summary>
        ///     Gets or sets the vCenter object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("vCenter")]
        public ASRvCenter InputObject { get; set; }

        /// <summary>
        ///     Gets or sets Run as Account object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets the port number.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public int? Port { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByResourceId:
                    vCenterName = Utilities.GetValueFromArmId(
                    this.ResourceId,
                    ARMResourceTypeConstants.vCenters);

                    fabricName = Utilities.GetValueFromArmId(
                    this.ResourceId,
                    ARMResourceTypeConstants.ReplicationFabrics);
                    break;

                case ASRParameterSets.Default:
                    vCenterName = this.InputObject.Name;
                    fabricName = this.InputObject.FabricArmResourceName;
                    break;
            }

            if (this.ShouldProcess(vCenterName, VerbsData.Update))
            {
                this.UpdatevCenter();
            }
        }

        /// <summary>
        ///     Update the vCenter.
        /// </summary>
        private void UpdatevCenter()
        {
            var updatevCenterInput = new UpdateVCenterRequest();

            var vcenterResponse =
               this.RecoveryServicesClient.GetAzureRmSiteRecoveryvCenter(
                   fabricName,
                   vCenterName);
            var updatevCenterProperties =
                 new UpdateVCenterRequestProperties()
                 {
                     FriendlyName = vcenterResponse.Properties.FriendlyName,
                     IpAddress = vcenterResponse.Properties.IpAddress,
                     ProcessServerId = vcenterResponse.Properties.ProcessServerId,
                     Port = vcenterResponse.Properties.Port,
                     RunAsAccountId = vcenterResponse.Properties.RunAsAccountId
                 };

            if (this.Account != null && !string.IsNullOrEmpty(this.Account.AccountId))
            {
                updatevCenterProperties.RunAsAccountId = this.Account.AccountId;
            }

            if (this.Port.HasValue)
            {
                updatevCenterProperties.Port = this.Port.ToString();
            }

            updatevCenterInput.Properties = updatevCenterProperties;

            var response = this.RecoveryServicesClient.UpdateAzureRmSiteRecoveryvCenter(
                fabricName,
                vCenterName,
                updatevCenterInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region private 

        private string vCenterName = null;

        private string fabricName = null;
        #endregion
    }
}
