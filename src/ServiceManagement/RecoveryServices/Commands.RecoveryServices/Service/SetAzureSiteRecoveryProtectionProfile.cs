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
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        #region Parameters

        /// <summary>
        /// Gets or sets Protection Profile object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets a value for Replication Method of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Protection Profile for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Protection Profile in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public int? RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Protection Profile in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public int? ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter? CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        public int? ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

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
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter? AllowReplicaDeletion { get; set; }

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
                        this.EnterpriseToAzureUpdate();
                        break;
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterpriseUpdate();
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
            if (string.Compare(this.ProtectionProfile.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ProtectionProfile.ReplicationProvider));
            }

            //// Verify whether the storage account is associated with the account or not.
            //// PSRecoveryServicesClientHelper.ValidateStorageAccountAssociation(this.RecoveryAzureStorageAccount);

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            ushort replicationFrequencyInSeconds = PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds);

            HyperVReplicaAzureProtectionProfileInput hyperVReplicaAzureProtectionProfileInput
                    = new HyperVReplicaAzureProtectionProfileInput()
                    {
                        ApplicationConsistentSnapshotFrequencyInHours = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ApplicationConsistentSnapshotFrequencyInHours,
                        ReplicationInterval = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationFrequencyInSeconds,
                        OnlineReplicationStartTime = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.ReplicationStartTime,
                        RecoveryPointHistoryDuration = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.RecoveryPoints,
                        EncryptionEnabled = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.EncryptStoredData
                    };

            var storageAccount = new CustomerStorageAccount();
            storageAccount.StorageAccountName = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.RecoveryAzureStorageAccountName;
            storageAccount.SubscriptionId = this.ProtectionProfile.HyperVReplicaAzureProviderSettingsObject.RecoveryAzureSubscription;

            hyperVReplicaAzureProtectionProfileInput.StorageAccounts = new System.Collections.Generic.List<CustomerStorageAccount>();
            hyperVReplicaAzureProtectionProfileInput.StorageAccounts.Add(storageAccount);

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
            if (string.Compare(this.ProtectionProfile.ReplicationProvider, Constants.HyperVReplica, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ProtectionProfile.ReplicationProvider));
            }

            HyperVReplicaProtectionProfileInput hyperVReplicaProtectionProfileInput
                    = new HyperVReplicaProtectionProfileInput()
                    {
                        OnlineReplicationStartTime = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationStartTime,
                        CompressionEnabled = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.CompressionEnabled,
                        OnlineReplicationMethod = (string.Compare(this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 1) ? true : false,
                        RecoveryPoints = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.RecoveryPoints,
                        ReplicationPort = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationPort,
                        AllowReplicaDeletion = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.AllowReplicaDeletion,
                        AllowedAuthenticationType = (ushort)((string.Compare(this.ProtectionProfile.HyperVReplicaProviderSettingsObject.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2),
                    };

            if (this.ApplicationConsistentSnapshotFrequencyInHours.HasValue)
            {
                hyperVReplicaProtectionProfileInput.ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours.Value;
            }

            hyperVReplicaProtectionProfileInput.ReplicationFrequencyInSeconds = PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds);

            UpdateProtectionProfileInput updateProtectionProfileInput =
                new UpdateProtectionProfileInput(
                    DataContractUtils<HyperVReplicaProtectionProfileInput>.Serialize(hyperVReplicaProtectionProfileInput));

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
