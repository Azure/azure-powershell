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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Creates Azure Site Recovery Protection Profile object in memory.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSiteRecoveryProtectionProfile", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
    [OutputType(typeof(ASRProtectionProfile))]
    public class CreateAzureSiteRecoveryProtectionProfileObject : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Replication Provider of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.HyperVReplica,
            Constants.HyperVReplicaAzure)]
        public string ReplicationProvider { get; set; }

        /// <summary>
        /// Gets or sets a value for Replication Method of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        [DefaultValue(Constants.OnlineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets a value Recovery Azure Subscription of the Protection Profile for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureSubscription { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Protection Profile for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether stored data needs to be encrypted.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [DefaultValue(false)]
        public SwitchParameter EncryptStoredData { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Protection Profile in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(300)]
        public ushort ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Protection Profile in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(true)]
        public SwitchParameter CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(8084)]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        [DefaultValue(Constants.AuthenticationTypeCertificate)]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets Replication Start time of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(null)]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica should be Deleted on 
        /// disabling protection of a protection entity protected by the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(false)]
        public SwitchParameter AllowReplicaDeletion { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ReplicationProvider)
                {
                    case Constants.HyperVReplica:
                        this.EnterpriseToEnterpriseProtectionProfileObject();
                        break;
                    case Constants.HyperVReplicaAzure:
                        this.EnterpriseToAzureProtectionProfileObject();
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
        /// Creates an E2A Protection Profile Object
        /// </summary>
        private void EnterpriseToAzureProtectionProfileObject()
        {
            //// Verify whether the storage account is associated with the account or not.
            //// PSRecoveryServicesClientHelper.ValidateStorageAccountAssociation(this.RecoveryAzureStorageAccount);

            // Verify whether the subscription is associated with the account or not.
            PSRecoveryServicesClientHelper.ValidateSubscriptionAccountAssociation(this.RecoveryAzureSubscription);

            this.ValidateReplicationStartTime(this.ReplicationStartTime);

            ASRProtectionProfile protectionProfile = new ASRProtectionProfile()
            {
                ReplicationProvider = this.ReplicationProvider,
                HyperVReplicaAzureProviderSettingsObject = new HyperVReplicaAzureProviderSettings()
                {
                    RecoveryAzureSubscription = this.RecoveryAzureSubscription,
                    RecoveryAzureStorageAccountName = this.RecoveryAzureStorageAccount,
                    EncryptStoredData = this.EncryptStoredData,
                    ReplicationFrequencyInSeconds = this.ReplicationFrequencyInSeconds,
                    RecoveryPoints = this.RecoveryPoints,
                    ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                    ReplicationStartTime = this.ReplicationStartTime,
                },
                HyperVReplicaProviderSettingsObject = null
            };

            this.WriteObject(protectionProfile);
        }

        /// <summary>
        /// Validates if the time span object has a valid value.
        /// </summary>
        /// <param name="timeSpan">Time span object to be validated</param>
        private void ValidateReplicationStartTime(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
            {
                return;
            }

            if (TimeSpan.Compare(timeSpan.Value, new TimeSpan(24, 0, 0)) == 1)
            {
                throw new InvalidOperationException(
                    string.Format(Properties.Resources.ReplicationStartTimeInvalid));
            }
        }

        /// <summary>
        /// Creates an E2E Protection Profile object
        /// </summary>
        private void EnterpriseToEnterpriseProtectionProfileObject()
        {
            this.ValidateReplicationStartTime(this.ReplicationStartTime);

            ASRProtectionProfile protectionProfile = new ASRProtectionProfile()
            {
                ReplicationProvider = this.ReplicationProvider,
                HyperVReplicaAzureProviderSettingsObject = null,
                HyperVReplicaProviderSettingsObject = new HyperVReplicaProviderSettings()
                {
                    ReplicationMethod = this.ReplicationMethod,
                    ReplicationFrequencyInSeconds = this.ReplicationFrequencyInSeconds,
                    RecoveryPoints = this.RecoveryPoints,
                    ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                    CompressionEnabled = this.CompressionEnabled,
                    ReplicationPort = this.ReplicationPort,
                    Authentication = this.Authentication,
                    ReplicationStartTime = this.ReplicationStartTime,
                    AllowReplicaDeletion = this.AllowReplicaDeletion
                }
            };

            this.WriteObject(protectionProfile);
        }
    }
}
