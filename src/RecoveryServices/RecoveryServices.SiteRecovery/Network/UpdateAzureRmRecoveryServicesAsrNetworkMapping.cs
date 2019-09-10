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
    ///     Updates Azure Site Recovery Network mapping.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrNetworkMapping",DefaultParameterSetName = ASRParameterSets.ByNetworkObject,SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrNetworkMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the ASR network mapping object corresponding to the ASR network mapping to be updated 
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ById,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByNetworkObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("NetworkMapping")]
        public ASRNetworkMapping InputObject { get; set; }

        /// <summary>
        ///     Gets or sets the recovery network object for the network mapping.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByNetworkObject,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        ///     Gets or sets the recovery azure network ID for the network mapping.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ById,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.FriendlyName,
                VerbsData.Update))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByNetworkObject:
                        this.UpdateEnterpriseToEnterpriseNetworkMapping();
                        break;
                    case ASRParameterSets.ById:
                        if (this.InputObject.ID.Contains(ARMResourceTypeConstants.AzureNetwork))
                        {
                            this.UpdateAzureToAzureNetworkMapping();
                        }
                        else
                        {
                            this.UpdateEnterpriseToAzureNetworkMapping();
                        }
                        break;
                }
            }
        }

        /// <summary>
        ///     Update Azure to Azure network mapping.
        /// </summary>
        private void UpdateAzureToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            var input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName = this.InputObject.RecoveryFabricFriendlyName,
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new AzureToAzureUpdateNetworkMappingInput
                    {
                        PrimaryNetworkId = this.InputObject.PrimaryNetworkId
                    }
                }
            };
            var response = this.RecoveryServicesClient.UpdateAzureSiteRecoveryNetworkMapping(
                this.InputObject.PrimaryFabricFriendlyName,
                ARMResourceTypeConstants.AzureNetwork,
                this.InputObject.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Enterprise to Azure network mapping.
        /// </summary>
        private void UpdateEnterpriseToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            var input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName = "Microsoft Azure",
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new VmmToAzureUpdateNetworkMappingInput()
                }
            };
            var response = this.RecoveryServicesClient.UpdateAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(
                    this.InputObject.PrimaryNetworkId,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(
                    this.InputObject.PrimaryNetworkId,
                    ARMResourceTypeConstants.ReplicationNetworks),
                this.InputObject.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Enterprise to enterprise network mapping.
        /// </summary>
        private void UpdateEnterpriseToEnterpriseNetworkMapping()
        {
            var input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName = Utilities.GetValueFromArmId(
                        this.RecoveryNetwork.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    RecoveryNetworkId = this.RecoveryNetwork.ID,
                    FabricSpecificDetails = new VmmToVmmUpdateNetworkMappingInput()
                }
            };
            var response = this.RecoveryServicesClient.UpdateAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(
                    this.InputObject.PrimaryNetworkId,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(
                    this.InputObject.PrimaryNetworkId,
                    ARMResourceTypeConstants.ReplicationNetworks),
                this.InputObject.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Get fabric by friendly name.
        /// </summary>
        private string GetFabricNameByFriendlyName(string fabricFriendlyName)
        {
            var fabricListResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            string fabricName = null;
            foreach (var fabric in fabricListResponse)
            {
                if (0 ==
                    string.Compare(
                        fabricFriendlyName,
                        fabric.Properties.FriendlyName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    fabricName = fabric.Name;

                }
            }

            if (string.IsNullOrEmpty(fabricName))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.FabricNotFound,
                        fabricFriendlyName,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
            else
            {
                return fabricName;
            }
        }
    }
}
