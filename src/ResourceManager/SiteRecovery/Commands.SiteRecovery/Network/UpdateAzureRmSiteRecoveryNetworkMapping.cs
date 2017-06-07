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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Updates Azure Site Recovery Network mapping.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmSiteRecoveryNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmSiteRecoveryNetworkMapping : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ById, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByNetworkObject, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetworkMapping Mapping { get; set; }

        /// <summary>
        /// Gets or sets Recovery Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByNetworkObject, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ById, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByNetworkObject:
                    this.UpdateEnterpriseToEnterpriseNetworkMapping();
                    break;
                case ASRParameterSets.ById:
                    if (this.Mapping.ID.Contains(ARMResourceTypeConstants.AzureNetwork))
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

        /// <summary>
        /// Enterprise to enterprise network mapping.
        /// </summary>
        private void UpdateEnterpriseToEnterpriseNetworkMapping()
        {
            UpdateNetworkMappingInput input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName =
                        Utilities.GetValueFromArmId(
                            this.RecoveryNetwork.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                    RecoveryNetworkId = this.RecoveryNetwork.ID,
                    FabricSpecificDetails = new VmmToVmmUpdateNetworkMappingInput()
                }
            };
            var response =
                RecoveryServicesClient
                .UpdateAzureSiteRecoveryNetworkMapping(
                    Utilities.GetValueFromArmId(
                        this.Mapping.PrimaryNetworkId,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.Mapping.PrimaryNetworkId,
                        ARMResourceTypeConstants.ReplicationNetworks),
                    this.Mapping.Name,
                    input);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        /// Enterprise to Azure network mapping.
        /// </summary>
        private void UpdateEnterpriseToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            UpdateNetworkMappingInput input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName = "Microsoft Azure",
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new VmmToAzureUpdateNetworkMappingInput()
                }
            };
            var response =
                RecoveryServicesClient
                .UpdateAzureSiteRecoveryNetworkMapping(
                    Utilities.GetValueFromArmId(
                        this.Mapping.PrimaryNetworkId,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.Mapping.PrimaryNetworkId,
                        ARMResourceTypeConstants.ReplicationNetworks),
                    this.Mapping.Name,
                    input);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        /// Update Azure to Azure network mapping.
        /// </summary>
        private void UpdateAzureToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            UpdateNetworkMappingInput input = new UpdateNetworkMappingInput
            {
                Properties = new UpdateNetworkMappingInputProperties
                {
                    RecoveryFabricName = this.Mapping.RecoveryFabricFriendlyName,
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new AzureToAzureUpdateNetworkMappingInput
                    {
                        PrimaryNetworkId = this.Mapping.PrimaryNetworkId
                    }
                }
            };
            var response =
                RecoveryServicesClient
                .UpdateAzureSiteRecoveryNetworkMapping(
                    this.Mapping.PrimaryFabricFriendlyName,
                    ARMResourceTypeConstants.AzureNetwork,
                    this.Mapping.Name,
                    input);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}