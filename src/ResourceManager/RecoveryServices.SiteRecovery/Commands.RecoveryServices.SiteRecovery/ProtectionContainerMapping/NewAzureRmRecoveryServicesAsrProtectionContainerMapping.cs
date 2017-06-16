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
    ///     Adds Azure Site Recovery Policy settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsCommon.New,
        "AzureRmRecoveryServicesAsrProtectionContainerMapping",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [Alias("New-ASRProtectionContainerMapping")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrProtectionContainerMapping : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Policy object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Policy object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRPolicy Policy { get; set; }

        /// <summary>
        ///     Gets or sets Protection Container to be applied the Policy settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Protection Container to be applied the Policy settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer RecoveryProtectionContainer { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToAzure:
                    EnterpriseToAzureAssociation();
                    break;
                case ASRParameterSets.EnterpriseToEnterprise:
                    EnterpriseToEnterpriseAssociation();
                    break;
            }
        }

        /// <summary>
        ///     Associates Policy with enterprise based protection containers
        /// </summary>
        private void EnterpriseToEnterpriseAssociation()
        {
            if (string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplica2012,
                    StringComparison.OrdinalIgnoreCase) !=
                0 &&
                string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplica2012R2,
                    StringComparison.OrdinalIgnoreCase) !=
                0)
            {
                throw new InvalidOperationException(string.Format(
                    Resources.IncorrectReplicationProvider,
                    Policy.ReplicationProvider));
            }

            Associate(RecoveryProtectionContainer.ID);
        }

        /// <summary>
        ///     Associates Azure Policy with enterprise based protection containers
        /// </summary>
        private void EnterpriseToAzureAssociation()
        {
            if (string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase) !=
                0)
            {
                throw new InvalidOperationException(string.Format(
                    Resources.IncorrectReplicationProvider,
                    Policy.ReplicationProvider));
            }

            Associate(Constants.AzureContainer);
        }

        /// <summary>
        ///     Helper to configure cloud
        /// </summary>
        private void Associate(string targetProtectionContainerId)
        {
            var inputProperties = new CreateProtectionContainerMappingInputProperties
            {
                PolicyId = Policy.ID,
                ProviderSpecificInput = new ReplicationProviderSpecificContainerMappingInput(),
                TargetProtectionContainerId = targetProtectionContainerId
            };

            var input = new CreateProtectionContainerMappingInput {Properties = inputProperties};

            var response = RecoveryServicesClient.ConfigureProtection(Utilities.GetValueFromArmId(
                    PrimaryProtectionContainer.ID,
                    ARMResourceTypeConstants.ReplicationFabrics),
                PrimaryProtectionContainer.Name,
                Name,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}