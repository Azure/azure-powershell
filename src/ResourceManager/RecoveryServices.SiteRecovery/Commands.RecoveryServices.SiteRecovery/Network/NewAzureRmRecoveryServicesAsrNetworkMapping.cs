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
    ///     Creates an ASR network mapping between two networks.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrNetworkMapping",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
        SupportsShouldProcess = true)]
    [Alias("New-ASRNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrNetworkMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch parameter specifying that the network mapping being created will be used 
        ///    to replicated Azure virtual machines between two Azure regions.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///     Gets or sets name of the ASR network mapping to create.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Primary Network object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork PrimaryNetwork { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        /// Gets or sets the ASR fabric where mapping should be created.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric PrimaryFabric { get; set; }

        /// <summary>
        /// Gets or sets the primary azure network resource id to be used in network mapping
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string PrimaryAzureNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Azure Site Recovery fabric name corresponding to the recovery Azure region.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric RecoveryFabric { get; set; }

        /// <summary>
        ///     Gets or sets the recovery azure network ID for the network mapping.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureNetworkId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterpriseNetworkMapping();
                        break;
                    case ASRParameterSets.EnterpriseToAzure:
                        this.EnterpriseToAzureNetworkMapping();
                        break;
                    case ASRParameterSets.AzureToAzure:
                        this.AzureToAzureNetworkMapping();
                        break;
                }
            }
        }

        /// <summary>
        ///     Enterprise to Azure network mapping.
        /// </summary>
        private void EnterpriseToAzureNetworkMapping()
        {
            // Add following checks if needed:
            // Verify whether the subscription is associated with the account or not.
            // Check if the Azure VM Network is associated with the Subscription or not.

            var mappingName = this.Name;

            var input = new CreateNetworkMappingInput
            {
                Properties = new CreateNetworkMappingInputProperties
                {
                    RecoveryFabricName = "Microsoft Azure",
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new VmmToAzureCreateNetworkMappingInput()
                }
            };

            var response = this.RecoveryServicesClient.NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(
                    this.PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(
                    this.PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Enterprise to enterprise network mapping.
        /// </summary>
        private void EnterpriseToEnterpriseNetworkMapping()
        {
            var mappingName = this.Name;

            var input = new CreateNetworkMappingInput
            {
                Properties = new CreateNetworkMappingInputProperties
                {
                    RecoveryFabricName = Utilities.GetValueFromArmId(
                        this.RecoveryNetwork.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    RecoveryNetworkId = this.RecoveryNetwork.ID,
                    FabricSpecificDetails = new VmmToVmmCreateNetworkMappingInput()
                }
            };

            var response = this.RecoveryServicesClient.NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(
                    this.PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(
                    this.PrimaryNetwork.ID,
                    ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        /// Azure to Azure network mapping.
        /// </summary>
        private void AzureToAzureNetworkMapping()
        {
            CreateNetworkMappingInput input = new CreateNetworkMappingInput
            {
                Properties = new CreateNetworkMappingInputProperties
                {
                    RecoveryFabricName = this.RecoveryFabric.Name,
                    RecoveryNetworkId = this.RecoveryAzureNetworkId,
                    FabricSpecificDetails = new AzureToAzureCreateNetworkMappingInput()
                    {
                        PrimaryNetworkId = this.PrimaryAzureNetworkId
                    }
                }
            };

            var response =
                RecoveryServicesClient
                .NewAzureSiteRecoveryNetworkMapping(
                    this.PrimaryFabric.Name,
                    ARMResourceTypeConstants.AzureNetwork,
                    this.Name,
                    input);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}
