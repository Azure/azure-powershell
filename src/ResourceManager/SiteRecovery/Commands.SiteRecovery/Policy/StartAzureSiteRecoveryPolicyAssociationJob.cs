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
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Adds Azure Site Recovery Policy settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryPolicyAssociationJob", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [Alias("Start-AzureRmSiteRecoveryProtectionProfileAssociationJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryPolicyAssociationJob : SiteRecoveryCmdletBase
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
        /// Gets or sets Protection Container to be applied the Policy settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Recovery Protection Container to be applied the Policy settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer RecoveryProtectionContainer { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToAzure:
                        this.EnterpriseToAzureAssociation();
                        break;
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterpriseAssociation();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Associates Policy with enterprise based protection containers
        /// </summary>
        private void EnterpriseToEnterpriseAssociation()
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

            Associate(this.RecoveryProtectionContainer.ID);
        }


        /// <summary>
        /// Associates Azure Policy with enterprise based protection containers
        /// </summary>
        private void EnterpriseToAzureAssociation()
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

            Associate(Constants.AzureContainer);         
        }

        /// <summary>
        /// Helper to configure cloud
        /// </summary>
        private void Associate(string targetProtectionContainerId)
        {
            CreateProtectionContainerMappingInputProperties inputProperties = new CreateProtectionContainerMappingInputProperties()
            {
                PolicyId = this.Policy.ID,
                ProviderSpecificInput = new ReplicationProviderContainerMappingInput(),
                TargetProtectionContainerId = targetProtectionContainerId
            };

            CreateProtectionContainerMappingInput input = new CreateProtectionContainerMappingInput()
            {
                Properties = inputProperties
            };

            string mappingName = "ContainerMapping_" + Guid.NewGuid().ToString();
            LongRunningOperationResponse response = RecoveryServicesClient.ConfigureProtection(Utilities.GetValueFromArmId(this.PrimaryProtectionContainer.ID, ARMResourceTypeConstants.ReplicationFabrics), this.PrimaryProtectionContainer.Name, mappingName, input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse.Job));
        }

    }
}
