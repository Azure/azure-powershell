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
using System.ComponentModel;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Policy object in memory.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSiteRecoveryPolicy", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    public class NewAzureSiteRecoveryPolicy : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Holds Name (if passed) of the Policy object.
        /// </summary>
        private string targetName = string.Empty;

        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Replication Provider of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.HyperVReplica2012R2,
            Constants.HyperVReplica2012,
            Constants.HyperVReplicaAzure)]
        public string ReplicationProvider { get; set; }

        /// <summary>
        /// Gets or sets a value for Replication Method of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(false)]
        public SwitchParameter CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets Replication Start time of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica should be Deleted on 
        /// disabling protection of a protection entity protected by the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(false)]
        public SwitchParameter AllowReplicaDeletion { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Policy for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets Encrypt parameter. On passing, data will be encrypted.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        public SwitchParameter Encrypt { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToEnterprise:
                    this.EnterpriseToEnterprisePolicyObject();
                    break;
                case ASRParameterSets.EnterpriseToAzure:
                    this.EnterpriseToAzurePolicyObject();
                    break;
            }
        }

        /// <summary>
        /// Creates an E2E Policy object
        /// </summary>
        private void EnterpriseToEnterprisePolicyObject()
        {
            if (string.Compare(this.ReplicationProvider, Constants.HyperVReplica2012, StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(this.ReplicationProvider, Constants.HyperVReplica2012R2, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ReplicationProvider));
            }

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            ushort replicationFrequencyInSeconds =
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds);

            var createPolicyInputProperties = new CreatePolicyInputProperties();

            if (string.Compare(this.ReplicationProvider, Constants.HyperVReplica2012, StringComparison.OrdinalIgnoreCase) == 0)
            {
                createPolicyInputProperties.ProviderSpecificInput = new HyperVReplica2012PolicyInput()
                {
                    AllowedAuthenticationType =
                        (ushort)((string.Compare(this.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2),
                    ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                    Compression = this.CompressionEnabled == true ? "Enable" : "Disable",
                    InitialReplicationMethod =
                     (string.Compare(this.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? "OverNetwork" : "Offline",
                    OnlineReplicationStartTime = this.ReplicationStartTime,
                    RecoveryPoints = this.RecoveryPoints,
                    ReplicaDeletion = this.AllowReplicaDeletion == true ? "Required" : "NotRequired",
                    ReplicationPort = this.ReplicationPort
                };

            }
            else
            {
                createPolicyInputProperties.ProviderSpecificInput = new HyperVReplica2012R2PolicyInput()
                {
                    AllowedAuthenticationType =
                        (ushort)((string.Compare(this.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2),
                    ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                    Compression = this.CompressionEnabled == true ? "Enable" : "Disable",
                    InitialReplicationMethod =
                     (string.Compare(this.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? "OverNetwork" : "Offline",
                    OnlineReplicationStartTime = this.ReplicationStartTime,
                    RecoveryPoints = this.RecoveryPoints,
                    ReplicaDeletion = this.AllowReplicaDeletion == true ? "Required" : "NotRequired",
                    ReplicationFrequencyInSeconds = replicationFrequencyInSeconds,
                    ReplicationPort = this.ReplicationPort
                };
            }

            var createPolicyInput = new CreatePolicyInput()
            {
                Properties = createPolicyInputProperties
            };

            LongRunningOperationResponse responseBlue =
                RecoveryServicesClient.CreatePolicy(this.Name, createPolicyInput);

            JobResponse jobResponseBlue =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(responseBlue.Location));

            WriteObject(new ASRJob(jobResponseBlue.Job));
        }

        /// <summary>
        /// Creates an E2A Policy Object
        /// </summary>
        private void EnterpriseToAzurePolicyObject()
        {
            if (string.Compare(this.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ReplicationProvider));
            }

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            ushort replicationFrequencyInSeconds =
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds);

            var hyperVReplicaAzurePolicyInput = new HyperVReplicaAzurePolicyInput()
            {
                ApplicationConsistentSnapshotFrequencyInHours =
                    this.ApplicationConsistentSnapshotFrequencyInHours,
                Encryption = this.Encrypt ? "Enable" : "Disable",
                OnlineIrStartTime = this.ReplicationStartTime,
                RecoveryPointHistoryDuration = this.RecoveryPoints,
                ReplicationInterval = replicationFrequencyInSeconds,

            };

            hyperVReplicaAzurePolicyInput.StorageAccounts =
                   new System.Collections.Generic.List<string>();

            if (RecoveryAzureStorageAccountId != null)
            {
                string storageAccount = this.RecoveryAzureStorageAccountId;
                hyperVReplicaAzurePolicyInput.StorageAccounts.Add(storageAccount);
            }

            var createPolicyInputProperties = new CreatePolicyInputProperties()
            {
                ProviderSpecificInput = hyperVReplicaAzurePolicyInput
            };

            var createPolicyInput = new CreatePolicyInput()
            {
                Properties = createPolicyInputProperties
            };

            LongRunningOperationResponse response =
                RecoveryServicesClient.CreatePolicy(this.Name, createPolicyInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
