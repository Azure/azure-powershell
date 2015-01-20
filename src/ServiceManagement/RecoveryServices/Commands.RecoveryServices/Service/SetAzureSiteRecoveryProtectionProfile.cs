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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Updates Azure Site Recovery Protection Profile.
    /// Protection profile must be associated with the protection container.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSiteRecoveryProtectionProfile", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryProtectionProfile : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Gets or sets Protection Profile object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Protection Profile for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Protection Profile in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Protection Profile in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets Replication Start time of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica should be Deleted on 
        /// disabling protection of a protection entity protected by the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public bool AllowReplicaDeletion { get; set; }

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
                        this.EnterpriseToEnterpriseUpdate();
                        break;
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToAzureUpdate();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }

        /// <summary>
        /// Updates an E2A Protection Profile
        /// </summary>
        private void EnterpriseToAzureUpdate()
        {
            // Verify whether the storage account is associated with the account or not.
            PSRecoveryServicesClientHelper.ValidateStorageAccountAssociation(this.RecoveryAzureStorageAccount);

            HyperVReplicaAzureProtectionProfileInput hyperVReplicaAzureProtectionProfileInput
                    = new HyperVReplicaAzureProtectionProfileInput()
                    {
                        AppConsistencyFreq = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ApplicationConsistentSnapshotFrequencyInHours,
                        ReplicationInterval = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationFrequencyInSeconds,
                        OnlineIrStartTime = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationStartTime
                    };

            UpdateProtectionProfileInput updateProtectionProfileInput = 
                new UpdateProtectionProfileInput(
                    DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(hyperVReplicaAzureProtectionProfileInput));

            this.jobResponse = RecoveryServicesClient.UpdateAzureSiteRecoveryProtectionProfile(
                updateProtectionProfileInput,
                this.ProtectionProfile.ID);

            this.WriteJob(this.jobResponse.Job);
        }

        /// <summary>
        /// Updates an E2E Protection Profile
        /// </summary>
        private void EnterpriseToEnterpriseUpdate()
        {
            HyperVReplicaAzureProtectionProfileInput hyperVReplicaAzureProtectionProfileInput
                = new HyperVReplicaAzureProtectionProfileInput()
                {
                    AppConsistencyFreq = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ApplicationConsistentSnapshotFrequencyInHours,
                    ReplicationInterval = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationFrequencyInSeconds,
                    OnlineIrStartTime = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationStartTime
                };

            UpdateProtectionProfileInput updateProtectionProfileInput =
                new UpdateProtectionProfileInput(
                    DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(hyperVReplicaAzureProtectionProfileInput));
            
            this.jobResponse = RecoveryServicesClient.UpdateAzureSiteRecoveryProtectionProfile(
                updateProtectionProfileInput,
                this.ProtectionProfile.ID);

            this.WriteJob(this.jobResponse.Job);
        }

        /// <summary>
        /// Writes Job
        /// </summary>
        /// <param name="job">Job object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}
