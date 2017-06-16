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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Network mapping.
    /// </summary>
    [Cmdlet(VerbsCommon.New,
        "AzureRmRecoveryServicesAsrNetworkMapping",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
    [Alias("New-ASRNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrNetworkMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Primary Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork PrimaryNetwork { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        ///     Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToEnterprise:
                    EnterpriseToEnterpriseNetworkMapping();
                    break;
                case ASRParameterSets.EnterpriseToAzure:
                    EnterpriseToAzureNetworkMapping();
                    break;
            }
        }

        /// <summary>
        ///     Enterprise to enterprise network mapping.
        /// </summary>
        private void EnterpriseToEnterpriseNetworkMapping()
        {
            var mappingName = Name;

            var input = new CreateNetworkMappingInput
            {
                Properties = new CreateNetworkMappingInputProperties
                {
                    RecoveryFabricName = Utilities.GetValueFromArmId(RecoveryNetwork.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    RecoveryNetworkId = RecoveryNetwork.ID,
                    FabricSpecificDetails = new VmmToVmmCreateNetworkMappingInput()
                }
            };

            var response = RecoveryServicesClient.NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Enterprise to Azure network mapping.
        /// </summary>
        private void EnterpriseToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            var mappingName = Name;

            var input = new CreateNetworkMappingInput
            {
                Properties = new CreateNetworkMappingInputProperties
                {
                    RecoveryFabricName = "Microsoft Azure",
                    RecoveryNetworkId = RecoveryAzureNetworkId,
                    FabricSpecificDetails = new VmmToAzureCreateNetworkMappingInput()
                }
            };

            var response = RecoveryServicesClient.NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}