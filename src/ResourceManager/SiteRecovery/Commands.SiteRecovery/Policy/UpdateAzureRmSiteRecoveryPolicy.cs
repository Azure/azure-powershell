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
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Updates Azure Site Recovery Policy.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmSiteRecoveryPolicy", DefaultParameterSetName = ASRParameterSets.Default)]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Update-AzureRmRecoveryServicesAsrPolicy cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class UpdateAzureRmSiteRecoveryPolicy : SiteRecoveryCmdletBase
    {
        #region Private

        private string replicationMethod;
        private ushort replicationFrequencyInSeconds;
        private int recoveryPoints;
        private int applicationConsistentSnapshotFrequencyInHours;
        private string compression;
        private ushort replicationPort { get; set; }
        private ushort authentication { get; set; }
        private TimeSpan? replicationStartTime { get; set; }
        private string replicaDeletion { get; set; }
        private string recoveryAzureStorageAccountId { get; set; }
        private string encryption { get; set; }

        #endregion Private

        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Policy.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public ASRPolicy Policy { get; set; }

        /// <summary>
        /// Gets or sets a value for Replication Method of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Enable,
            Constants.Disable)]
        public string Compression { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets Replication Start time of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica should be Deleted on 
        /// disabling protection of a protection entity protected by the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Required,
            Constants.NotRequired)]
        public string ReplicaDeletion { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Storage Account Name of the Policy for E2A scenarios.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets Encrypt parameter. On passing, data will be encrypted.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Enable,
            Constants.Disable)]
        public string Encryption { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplica2012, StringComparison.OrdinalIgnoreCase) == 0 ||
                string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplica2012R2, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.EnterpriseToEnterprisePolicyObject();
            }
            else if (string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.EnterpriseToAzurePolicyObject();
            }
        }

        /// <summary>
        /// Creates an E2E Policy object
        /// </summary>
        private void EnterpriseToEnterprisePolicyObject()
        {
            if (string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplica2012, StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplica2012R2, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.Policy.ReplicationProvider));
            }

            var replicationProviderSettings = this.Policy.ReplicationProviderSettings as ASRHyperVReplicaPolicyDetails;

            this.replicationMethod = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationMethod)) ?
                ((string.Compare(this.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? "OverNetwork" : "Offline") :
                ((string.Compare(replicationProviderSettings.InitialReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? "OverNetwork" : "Offline");
            this.replicationFrequencyInSeconds = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationFrequencyInSeconds)) ?
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds) :
                replicationProviderSettings.ReplicationFrequencyInSeconds;
            this.recoveryPoints = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.RecoveryPoints)) ?
                this.RecoveryPoints :
                replicationProviderSettings.RecoveryPoints;
            this.applicationConsistentSnapshotFrequencyInHours = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ApplicationConsistentSnapshotFrequencyInHours)) ?
                this.ApplicationConsistentSnapshotFrequencyInHours :
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours;
            this.compression = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.Compression)) ?
                this.Compression :
                replicationProviderSettings.Compression;
            this.replicationPort = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationPort)) ?
                this.ReplicationPort :
                replicationProviderSettings.ReplicationPort;
            this.authentication = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.Authentication)) ?
                ((ushort)((string.Compare(this.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2)) :
                ((ushort)((string.Compare(replicationProviderSettings.AllowedAuthenticationType, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2));
            this.replicationStartTime = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationStartTime)) ?
                this.replicationStartTime :
                replicationProviderSettings.OnlineReplicationStartTime;
            this.replicaDeletion = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicaDeletion)) ?
                this.ReplicaDeletion :
                replicationProviderSettings.ReplicaDeletionOption;

            var updatePolicyProperties = new UpdatePolicyProperties();

            if (string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplica2012, StringComparison.OrdinalIgnoreCase) == 0)
            {
                updatePolicyProperties.ReplicationProviderSettings = new HyperVReplica2012PolicyInput()
                {
                    AllowedAuthenticationType = this.authentication,
                    ApplicationConsistentSnapshotFrequencyInHours = this.applicationConsistentSnapshotFrequencyInHours,
                    Compression = this.compression,
                    InitialReplicationMethod = this.replicationMethod,
                    OnlineReplicationStartTime = this.replicationStartTime,
                    RecoveryPoints = this.recoveryPoints,
                    ReplicaDeletion = this.replicaDeletion,
                    ReplicationPort = this.replicationPort
                };

            }
            else
            {
                updatePolicyProperties.ReplicationProviderSettings = new HyperVReplica2012R2PolicyInput()
                {
                    AllowedAuthenticationType = this.authentication,
                    ApplicationConsistentSnapshotFrequencyInHours = this.applicationConsistentSnapshotFrequencyInHours,
                    Compression = this.compression,
                    InitialReplicationMethod = this.replicationMethod,
                    OnlineReplicationStartTime = this.replicationStartTime,
                    RecoveryPoints = this.recoveryPoints,
                    ReplicaDeletion = this.replicaDeletion,
                    ReplicationPort = this.replicationPort,
                    ReplicationFrequencyInSeconds = replicationFrequencyInSeconds
                };
            }

            var updatePolicyInput = new UpdatePolicyInput()
            {
                Properties = updatePolicyProperties
            };

            LongRunningOperationResponse responseBlue =
                RecoveryServicesClient.UpdatePolicy(this.Policy.Name, updatePolicyInput);

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
            if (string.Compare(this.Policy.ReplicationProvider, Constants.HyperVReplicaAzure, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.Policy.ReplicationProvider));
            }

            var replicationProviderSettings = this.Policy.ReplicationProviderSettings as ASRHyperVReplicaAzurePolicyDetails;

            this.replicationFrequencyInSeconds = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationFrequencyInSeconds)) ?
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds) :
                (ushort)replicationProviderSettings.ReplicationFrequencyInSeconds;
            this.recoveryPoints = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.RecoveryPoints)) ?
                this.RecoveryPoints :
                replicationProviderSettings.RecoveryPoints;
            this.applicationConsistentSnapshotFrequencyInHours = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ApplicationConsistentSnapshotFrequencyInHours)) ?
                this.ApplicationConsistentSnapshotFrequencyInHours :
                replicationProviderSettings.ApplicationConsistentSnapshotFrequencyInHours;
            this.replicationStartTime = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.ReplicationStartTime)) ?
                this.replicationStartTime :
                replicationProviderSettings.OnlineReplicationStartTime;
            this.recoveryAzureStorageAccountId = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.RecoveryAzureStorageAccountId)) ?
                this.RecoveryAzureStorageAccountId :
                replicationProviderSettings.ActiveStorageAccountId;
            this.encryption = this.MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => this.Encryption)) ?
                this.Encryption :
                ((string.Compare(replicationProviderSettings.Encryption, "Disabled", StringComparison.OrdinalIgnoreCase) == 0) ? Constants.Disable : Constants.Enable);

            var hyperVReplicaAzurePolicyInput = new HyperVReplicaAzurePolicyInput()
            {
                ApplicationConsistentSnapshotFrequencyInHours = this.applicationConsistentSnapshotFrequencyInHours,
                Encryption = this.encryption,
                OnlineIrStartTime = this.replicationStartTime,
                RecoveryPointHistoryDuration = this.recoveryPoints,
                ReplicationInterval = this.replicationFrequencyInSeconds
            };

            hyperVReplicaAzurePolicyInput.StorageAccounts =
                   new System.Collections.Generic.List<string>();

            if (RecoveryAzureStorageAccountId != null)
            {
                string storageAccount = this.recoveryAzureStorageAccountId;
                hyperVReplicaAzurePolicyInput.StorageAccounts.Add(storageAccount);
            }

            var updatePolicyProperties = new UpdatePolicyProperties()
            {
                ReplicationProviderSettings = hyperVReplicaAzurePolicyInput
            };

            var updatePolicyInput = new UpdatePolicyInput()
            {
                Properties = updatePolicyProperties
            };

            LongRunningOperationResponse response =
                RecoveryServicesClient.UpdatePolicy(this.Policy.Name, updatePolicyInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
