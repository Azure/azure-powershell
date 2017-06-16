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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Updates Azure Site Recovery Policy.
    /// </summary>
    [Cmdlet(VerbsData.Update,
        "AzureRmRecoveryServicesAsrPolicy")]
    [Alias("Update-ASRPolicy")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrPolicy : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Name of the Policy.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true)]
        public ASRPolicy Policy { get; set; }

        /// <summary>
        ///     Gets or sets a value for Replication Method of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        ///     Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public int RecoveryPoints { get; set; }

        /// <summary>
        ///     Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Compression needs to be Enabled on the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.Enable,
            Constants.Disable)]
        public string Compression { get; set; }

        /// <summary>
        ///     Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        ///     Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

        /// <summary>
        ///     Gets or sets Replication Start time of the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Replica should be Deleted on
        ///     disabling protection of a protection entity protected by the Policy.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.Required,
            Constants.NotRequired)]
        public string ReplicaDeletion { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account Name of the Policy for E2A scenarios.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets Encrypt parameter. On passing, data will be encrypted.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.Enable,
            Constants.Disable)]
        public string Encryption { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplica2012,
                    StringComparison.OrdinalIgnoreCase) ==
                0 ||
                string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplica2012R2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                EnterpriseToEnterprisePolicyObject();
            }
            else if (string.Compare(Policy.ReplicationProvider,
                         Constants.HyperVReplicaAzure,
                         StringComparison.OrdinalIgnoreCase) ==
                     0)
            {
                EnterpriseToAzurePolicyObject();
            }
        }

        /// <summary>
        ///     Creates an E2E Policy object
        /// </summary>
        private void EnterpriseToEnterprisePolicyObject()
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

            var replicationProviderSettings =
                Policy.ReplicationProviderSettings as ASRHyperVReplicaPolicyDetails;

            replicationMethod =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationMethod))
                    ? (string.Compare(ReplicationMethod,
                           Constants.OnlineReplicationMethod,
                           StringComparison.OrdinalIgnoreCase) ==
                       0 ? "OverNetwork" : "Offline")
                    : (string.Compare(replicationProviderSettings.InitialReplicationMethod,
                           Constants.OnlineReplicationMethod,
                           StringComparison.OrdinalIgnoreCase) ==
                       0 ? "OverNetwork" : "Offline");
            replicationFrequencyInSeconds =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationFrequencyInSeconds))
                    ? PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(
                        ReplicationFrequencyInSeconds) : replicationProviderSettings
                        .ReplicationFrequencyInSeconds;
            recoveryPoints =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => RecoveryPoints)) ? RecoveryPoints
                    : replicationProviderSettings.RecoveryPoints;
            applicationConsistentSnapshotFrequencyInHours =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ApplicationConsistentSnapshotFrequencyInHours))
                    ? ApplicationConsistentSnapshotFrequencyInHours : replicationProviderSettings
                        .ApplicationConsistentSnapshotFrequencyInHours;
            compression =
                MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => Compression))
                    ? Compression : replicationProviderSettings.Compression;
            replicationPort =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationPort)) ? ReplicationPort
                    : replicationProviderSettings.ReplicationPort;
            authentication =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => Authentication))
                    ? (ushort) (string.Compare(Authentication,
                                    Constants.AuthenticationTypeKerberos,
                                    StringComparison.OrdinalIgnoreCase) ==
                                0 ? 1 : 2)
                    : (ushort) (string.Compare(
                                    replicationProviderSettings.AllowedAuthenticationType,
                                    Constants.AuthenticationTypeKerberos,
                                    StringComparison.OrdinalIgnoreCase) ==
                                0 ? 1 : 2);
            replicationStartTime =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationStartTime)) ? replicationStartTime
                    : replicationProviderSettings.OnlineReplicationStartTime;
            replicaDeletion =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicaDeletion)) ? ReplicaDeletion
                    : replicationProviderSettings.ReplicaDeletionOption;

            var updatePolicyProperties = new UpdatePolicyInputProperties();

            if (string.Compare(Policy.ReplicationProvider,
                    Constants.HyperVReplica2012,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                updatePolicyProperties.ReplicationProviderSettings = new HyperVReplicaPolicyInput
                {
                    AllowedAuthenticationType = authentication,
                    ApplicationConsistentSnapshotFrequencyInHours =
                        applicationConsistentSnapshotFrequencyInHours,
                    Compression = compression,
                    InitialReplicationMethod = replicationMethod,
                    OnlineReplicationStartTime = replicationStartTime.ToString(),
                    RecoveryPoints = recoveryPoints,
                    ReplicaDeletion = replicaDeletion,
                    ReplicationPort = replicationPort
                };
            }
            else
            {
                updatePolicyProperties.ReplicationProviderSettings =
                    new HyperVReplicaBluePolicyInput
                    {
                        AllowedAuthenticationType = authentication,
                        ApplicationConsistentSnapshotFrequencyInHours =
                            applicationConsistentSnapshotFrequencyInHours,
                        Compression = compression,
                        InitialReplicationMethod = replicationMethod,
                        OnlineReplicationStartTime = replicationStartTime.ToString(),
                        RecoveryPoints = recoveryPoints,
                        ReplicaDeletion = replicaDeletion,
                        ReplicationPort = replicationPort,
                        ReplicationFrequencyInSeconds = replicationFrequencyInSeconds
                    };
            }

            var updatePolicyInput = new UpdatePolicyInput {Properties = updatePolicyProperties};

            var responseBlue = RecoveryServicesClient.UpdatePolicy(Policy.Name,
                updatePolicyInput);

            var jobResponseBlue =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(responseBlue.Location));

            WriteObject(new ASRJob(jobResponseBlue));
        }

        /// <summary>
        ///     Creates an E2A Policy Object
        /// </summary>
        private void EnterpriseToAzurePolicyObject()
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

            var replicationProviderSettings =
                Policy.ReplicationProviderSettings as ASRHyperVReplicaAzurePolicyDetails;

            replicationFrequencyInSeconds =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationFrequencyInSeconds))
                    ? PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(
                        ReplicationFrequencyInSeconds) : (ushort) replicationProviderSettings
                        .ReplicationFrequencyInSeconds;
            recoveryPoints =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => RecoveryPoints)) ? RecoveryPoints
                    : replicationProviderSettings.RecoveryPoints;
            applicationConsistentSnapshotFrequencyInHours =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ApplicationConsistentSnapshotFrequencyInHours))
                    ? ApplicationConsistentSnapshotFrequencyInHours : replicationProviderSettings
                        .ApplicationConsistentSnapshotFrequencyInHours;
            replicationStartTime =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => ReplicationStartTime)) ? replicationStartTime
                    : replicationProviderSettings.OnlineReplicationStartTime;
            recoveryAzureStorageAccountId =
                MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => RecoveryAzureStorageAccountId))
                    ? RecoveryAzureStorageAccountId
                    : replicationProviderSettings.ActiveStorageAccountId;
            encryption =
                MyInvocation.BoundParameters.ContainsKey(Utilities.GetMemberName(() => Encryption))
                    ? Encryption : (string.Compare(replicationProviderSettings.Encryption,
                                        "Disabled",
                                        StringComparison.OrdinalIgnoreCase) ==
                                    0 ? Constants.Disable : Constants.Enable);

            var hyperVReplicaAzurePolicyInput = new HyperVReplicaAzurePolicyInput
            {
                ApplicationConsistentSnapshotFrequencyInHours =
                    applicationConsistentSnapshotFrequencyInHours,
                Encryption = encryption,
                OnlineReplicationStartTime = replicationStartTime.ToString(),
                RecoveryPointHistoryDuration = recoveryPoints,
                ReplicationInterval = replicationFrequencyInSeconds
            };

            hyperVReplicaAzurePolicyInput.StorageAccounts = new List<string>();

            if (RecoveryAzureStorageAccountId != null)
            {
                var storageAccount = recoveryAzureStorageAccountId;
                hyperVReplicaAzurePolicyInput.StorageAccounts.Add(storageAccount);
            }

            var updatePolicyProperties =
                new UpdatePolicyInputProperties
                {
                    ReplicationProviderSettings = hyperVReplicaAzurePolicyInput
                };

            var updatePolicyInput = new UpdatePolicyInput {Properties = updatePolicyProperties};

            var response = RecoveryServicesClient.UpdatePolicy(Policy.Name,
                updatePolicyInput);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

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
    }
}