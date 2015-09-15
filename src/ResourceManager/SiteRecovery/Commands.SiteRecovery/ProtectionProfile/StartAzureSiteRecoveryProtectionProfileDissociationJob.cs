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

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Adds Azure Site Recovery Protection Profile settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryProtectionProfileDissociationJob", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryProtectionProfileDissociationJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Job response.
        /// </summary>
        private LongRunningOperationResponse response = null;

        #region Parameters

        /// <summary>
        /// Gets or sets Protection Profile object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be removed the Protection Profile settings off.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be removed the Protection Profile settings off.
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
                        this.EnterpriseToAzureDissociation();
                        break;
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterpriseDissociation();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        private void EnterpriseToEnterpriseDissociation()
        {
            if (string.Compare(
                this.ProtectionProfile.ReplicationProvider,
                Constants.HyperVReplica,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ProtectionProfile.ReplicationProvider));
            }

            DisassociateProtectionProfileInput disassociateProtectionProfileInput = new DisassociateProtectionProfileInput();
            disassociateProtectionProfileInput.PrimaryProtectionContainerId = this.PrimaryProtectionContainer.Name;
            disassociateProtectionProfileInput.RecoveryProtectionContainerId = this.RecoveryProtectionContainer.Name;
            disassociateProtectionProfileInput.Name = this.ProtectionProfile.Name;
            disassociateProtectionProfileInput.ReplicationProviderSettings = new ProtectionProfileProviderSpecificInput();

            this.response = RecoveryServicesClient.DissociateAzureSiteRecoveryProtectionProfile(
                this.ProtectionProfile.Name,
                disassociateProtectionProfileInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }

        private void EnterpriseToAzureDissociation()
        {
            if (string.Compare(
                this.ProtectionProfile.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ProtectionProfile.ReplicationProvider));
            }

            DisassociateProtectionProfileInput disassociateProtectionProfileInput = new DisassociateProtectionProfileInput();
            disassociateProtectionProfileInput.PrimaryProtectionContainerId = this.PrimaryProtectionContainer.Name;
            disassociateProtectionProfileInput.RecoveryProtectionContainerId = Constants.AzureContainer;
            disassociateProtectionProfileInput.Name = this.ProtectionProfile.Name;
            disassociateProtectionProfileInput.ReplicationProviderSettings = new ProtectionProfileProviderSpecificInput();

            this.response = RecoveryServicesClient.DissociateAzureSiteRecoveryProtectionProfile(
                this.ProtectionProfile.Name,
                disassociateProtectionProfileInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
