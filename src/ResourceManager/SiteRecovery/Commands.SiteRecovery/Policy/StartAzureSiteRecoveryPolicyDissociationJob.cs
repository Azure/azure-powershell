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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Adds Azure Site Recovery Policy settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryPolicyDissociationJob", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryPolicyDissociationJob : SiteRecoveryCmdletBase
    {

        #region Parameters

        /// <summary>
        /// Gets or sets Policy object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRPolicy Policy { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be removed the Policy settings off.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be removed the Policy settings off.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer RecoveryProtectionContainer { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToAzure:
                    this.EnterpriseToAzureDissociation();
                    break;
                case ASRParameterSets.EnterpriseToEnterprise:
                    this.EnterpriseToEnterpriseDissociation();
                    break;
            }
        }

        private void EnterpriseToEnterpriseDissociation()
        {
            if (string.Compare(
                this.Policy.ReplicationProvider,
                Constants.HyperVReplica2012,
                StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(
                this.Policy.ReplicationProvider,
                Constants.HyperVReplica2012R2,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.Policy.ReplicationProvider));
            }

            Dissociate(this.RecoveryProtectionContainer.ID);
        }

        private void EnterpriseToAzureDissociation()
        {
            if (string.Compare(
                this.Policy.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.Policy.ReplicationProvider));
            }

            Dissociate(Constants.AzureContainer);
        }

        /// <summary>
        /// Helper to configure cloud
        /// </summary>
        private void Dissociate(string targetProtectionContainerId)
        {
            RemoveProtectionContainerMappingInputProperties inputProperties = new RemoveProtectionContainerMappingInputProperties()
            {
                ProviderSpecificInput = new ReplicationProviderContainerUnmappingInput()
            };

            RemoveProtectionContainerMappingInput input = new RemoveProtectionContainerMappingInput()
            {
                Properties = inputProperties
            };

            ProtectionContainerMappingListResponse protectionContainerMappingListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(Utilities.GetValueFromArmId(PrimaryProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics), PrimaryProtectionContainer.Name);
            ProtectionContainerMapping protectionContainerMapping = protectionContainerMappingListResponse.ProtectionContainerMappings.SingleOrDefault(t => (t.Properties.PolicyId.CompareTo(this.Policy.ID) == 0 && t.Properties.TargetProtectionContainerId.CompareTo(targetProtectionContainerId) == 0));

            if (protectionContainerMapping == null)
            {
                throw new Exception("Cloud is not paired");
            }

            LongRunningOperationResponse response = RecoveryServicesClient.UnConfigureProtection(Utilities.GetValueFromArmId(this.PrimaryProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics), this.PrimaryProtectionContainer.Name, protectionContainerMapping.Name, input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
