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
    ///     Removes the vCenter server from the ASR fabric and stops discovery of virtual machines from the vCenter server.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRvCenter")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the resourceId of vCenter to remove.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        /// <summary>
        ///     Gets or sets the vCenter object representing the vCenter server to be removed.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("vCenter")]
        public ASRvCenter InputObject { get; set; }

        /// <summary>
        ///     Gets or sets fabric object representing the Configuration Server.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets name of the vCenter.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            string vCenterName = null;
            string fabricName = null;
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

                case ASRParameterSets.ByName:
                    vCenterName = this.Name;
                    fabricName = this.Fabric.Name;
                    break;

                case ASRParameterSets.Default:
                    vCenterName = this.InputObject.Name;
                    fabricName = this.InputObject.FabricArmResourceName;
                    break;

            }

            if (this.ShouldProcess(vCenterName, VerbsCommon.Remove))
            {
                var response = this.RecoveryServicesClient.RemoveAzureRmSiteRecoveryvCenter(
                    fabricName,
                    vCenterName);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));

            }
        }
    }
}
