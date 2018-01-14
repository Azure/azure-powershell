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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Policy object in memory.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrPolicy",
        DefaultParameterSetName = ASRParameterSets.HyperVToAzure,
        SupportsShouldProcess = true)]
    [Alias("New-ASRPolicy")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrPolicy : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch Paramter to create VMwareToAzure / InMageV2Azure policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Position = 0,
            Mandatory = true)]
        public SwitchParameter VMwareToAzure { get; set; }

        /// <summary>
        ///    Switch Paramter to create VMwareToAzure / InMage policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToVMware,
            Position = 0,
            Mandatory = true)]
        public SwitchParameter AzureToVMware { get; set; }

        /// <summary>
        ///    Switch Paramter to create VMwareToAzure / InMage policy.
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = false)]
        public SwitchParameter HyperVToAzure { get; set; }

        /// <summary>
        ///    Switch Paramter to create VMwareToAzure / InMage policy.
        /// </summary>
        [Parameter(Position = 0,
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = false)]
        public SwitchParameter VmmToVmm { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Policy.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Replication Provider of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.HyperVReplica2012R2,
            Constants.HyperVReplica2012,
            Constants.HyperVReplicaAzure)]
        public string ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets a value for Replication Method of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        ///     Gets or sets Replication Frequency of the Policy in seconds.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Points of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        [Alias("RecoveryPoints")]
        public int NumberOfRecoveryPointsToRetain { get; set; }

        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int RecoveryPointRetentionInHours { get; set; }

        /// <summary>
        ///     Gets or sets Application Consistent Snapshot Frequency of the Policy in hours.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Compression needs to be Enabled on the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(Constants.Disable)]
        [ValidateSet(
            Constants.Enable,
            Constants.Disable)]
        public string Compression { get; set; }

        /// <summary>
        ///     Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        ///     Gets or sets the Replication Port of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

        /// <summary>
        ///     Gets or sets Replication Start time of the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether Replica should be Deleted on
        ///     disabling protection of a protection entity protected by the Policy.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [DefaultValue(Constants.NotRequired)]
        [ValidateSet(
            Constants.Required,
            Constants.NotRequired)]
        public string ReplicaDeletion { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account Name of the Policy for E2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets Encrypt parameter. On passing, data will be encrypted.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [DefaultValue(Constants.Disable)]
        [ValidateSet(
            Constants.Enable,
            Constants.Disable)]
        public string Encryption { get; set; }

        /// <summary>
        ///     Gets or sets Multi VM sync status parameter.
        /// </summary>
        [Parameter(
            DontShow = true,
            ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(
            DontShow = true,
            ParameterSetName = ASRParameterSets.AzureToVMware)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(Constants.Enable)]
        [ValidateSet(Constants.Enable,Constants.Disable)]
        public string MultiVmSyncStatus { get; set; }

        /// <summary>
        ///     Gets or sets RPO warning threshold in minutes.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        public int RPOWarningThresholdInMinutes { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterprisePolicyObject();
                        break;
                    case ASRParameterSets.HyperVToAzure:
                        this.HyperVToAzurePolicyObject();
                        break;
                    case ASRParameterSets.VMwareToAzure:
                    case ASRParameterSets.AzureToVMware:
                        this.ReplicationProvider = (this.ParameterSetName == ASRParameterSets.VMwareToAzure) ?
                            Constants.InMageAzureV2
                            : Constants.InMage;
                        this.V2AandV2VPolicyObject();
                        break;
                }
            }
        }

        /// <summary>
        ///     Creates an E2A Policy Object
        /// </summary>
        private void HyperVToAzurePolicyObject()
        {
            if (string.Compare(
                    this.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase) !=
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.IncorrectReplicationProvider,
                        this.ReplicationProvider));
            }

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            var replicationFrequencyInSeconds =
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(
                    this.ReplicationFrequencyInSeconds);

            var hyperVReplicaAzurePolicyInput = new HyperVReplicaAzurePolicyInput
            {
                ApplicationConsistentSnapshotFrequencyInHours =
                    this.ApplicationConsistentSnapshotFrequencyInHours,
                Encryption =
                    this.MyInvocation.BoundParameters.ContainsKey(
                        Utilities.GetMemberName(() => this.Encryption)) ? this.Encryption
                        : Constants.Disable,
                OnlineReplicationStartTime =
                    this.ReplicationStartTime == null ? null : this.ReplicationStartTime.ToString(),
                RecoveryPointHistoryDuration = this.NumberOfRecoveryPointsToRetain,
                ReplicationInterval = replicationFrequencyInSeconds
            };

            hyperVReplicaAzurePolicyInput.StorageAccounts = new List<string>();

            if (this.RecoveryAzureStorageAccountId != null)
            {
                var storageAccount = this.RecoveryAzureStorageAccountId;
                hyperVReplicaAzurePolicyInput.StorageAccounts.Add(storageAccount);
            }

            var createPolicyInputProperties =
                new CreatePolicyInputProperties
                {
                    ProviderSpecificInput = hyperVReplicaAzurePolicyInput
                };

            var createPolicyInput =
                new CreatePolicyInput { Properties = createPolicyInputProperties };

            var response = this.RecoveryServicesClient.CreatePolicy(
                this.Name,
                createPolicyInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Creates an E2E Policy object
        /// </summary>
        private void EnterpriseToEnterprisePolicyObject()
        {
            if ((string.Compare(
                     this.ReplicationProvider,
                     Constants.HyperVReplica2012,
                     StringComparison.OrdinalIgnoreCase) !=
                 0) &&
                (string.Compare(
                     this.ReplicationProvider,
                     Constants.HyperVReplica2012R2,
                     StringComparison.OrdinalIgnoreCase) !=
                 0))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.IncorrectReplicationProvider,
                        this.ReplicationProvider));
            }

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            var replicationFrequencyInSeconds =
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(
                    this.ReplicationFrequencyInSeconds);

            var createPolicyInputProperties = new CreatePolicyInputProperties();

            if (string.Compare(
                    this.ReplicationProvider,
                    Constants.HyperVReplica2012,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                createPolicyInputProperties.ProviderSpecificInput = new HyperVReplicaPolicyInput
                {
                    AllowedAuthenticationType = (ushort)(string.Compare(
                                                             this.Authentication,
                                                             Constants.AuthenticationTypeKerberos,
                                                             StringComparison.OrdinalIgnoreCase) ==
                                                         0 ? 1 : 2),
                    ApplicationConsistentSnapshotFrequencyInHours =
                        this.ApplicationConsistentSnapshotFrequencyInHours,
                    Compression =
                        this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.Compression)) ? this.Compression
                            : Constants.Disable,
                    InitialReplicationMethod = string.Compare(
                                                   this.ReplicationMethod,
                                                   Constants.OnlineReplicationMethod,
                                                   StringComparison.OrdinalIgnoreCase) ==
                                               0 ? "OverNetwork" : "Offline",
                    OnlineReplicationStartTime = this.ReplicationStartTime.ToString(),
                    RecoveryPoints = this.NumberOfRecoveryPointsToRetain,
                    ReplicaDeletion =
                        this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.ReplicaDeletion))
                            ? this.ReplicaDeletion : Constants.NotRequired,
                    ReplicationPort = this.ReplicationPort
                };
            }
            else
            {
                createPolicyInputProperties.ProviderSpecificInput =
                    new HyperVReplicaBluePolicyInput
                    {
                        AllowedAuthenticationType = (ushort)(string.Compare(
                                                                 this.Authentication,
                                                                 Constants
                                                                     .AuthenticationTypeKerberos,
                                                                 StringComparison
                                                                     .OrdinalIgnoreCase) ==
                                                             0 ? 1 : 2),
                        ApplicationConsistentSnapshotFrequencyInHours =
                            this.ApplicationConsistentSnapshotFrequencyInHours,
                        Compression =
                            this.MyInvocation.BoundParameters.ContainsKey(
                                Utilities.GetMemberName(() => this.Compression)) ? this.Compression
                                : Constants.Disable,
                        InitialReplicationMethod = string.Compare(
                                                       this.ReplicationMethod,
                                                       Constants.OnlineReplicationMethod,
                                                       StringComparison.OrdinalIgnoreCase) ==
                                                   0 ? "OverNetwork" : "Offline",
                        OnlineReplicationStartTime = this.ReplicationStartTime.ToString(),
                        RecoveryPoints = this.NumberOfRecoveryPointsToRetain,
                        ReplicaDeletion =
                            this.MyInvocation.BoundParameters.ContainsKey(
                                Utilities.GetMemberName(() => this.ReplicaDeletion))
                                ? this.ReplicaDeletion : Constants.NotRequired,
                        ReplicationFrequencyInSeconds = replicationFrequencyInSeconds,
                        ReplicationPort = this.ReplicationPort
                    };
            }

            var createPolicyInput =
                new CreatePolicyInput { Properties = createPolicyInputProperties };

            var responseBlue = this.RecoveryServicesClient.CreatePolicy(
                this.Name,
                createPolicyInput);

            var jobResponseBlue = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(responseBlue.Location));

            this.WriteObject(new ASRJob(jobResponseBlue));
        }

        /// <summary>
        ///     Creates an InMageAzureV2 / InMage Policy Object.
        /// </summary>
        private void V2AandV2VPolicyObject()
        {
            // Validate the Replication Provider.
            if (string.Compare(
                    this.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) !=
                0 &&
                string.Compare(
                    this.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) !=
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.IncorrectReplicationProvider,
                        this.ReplicationProvider));
            }

            // Set the Default Parameters.
            this.ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours;
            this.RecoveryPointRetentionInHours =
                this.MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => this.RecoveryPointRetentionInHours))
                    ? this.RecoveryPointRetentionInHours
                    : 24;
            this.RPOWarningThresholdInMinutes =
                this.MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => this.RPOWarningThresholdInMinutes))
                    ? this.RPOWarningThresholdInMinutes
                    : 15;
            this.MultiVmSyncStatus =
                this.MyInvocation.BoundParameters.ContainsKey(
                    Utilities.GetMemberName(() => this.MultiVmSyncStatus))
                    ? this.MultiVmSyncStatus
                    : Constants.Enable;
            var crashConsistentFrequencyInMinutes = 5;

            // Create the Create Policy Input.
            var createPolicyInput = new CreatePolicyInput
            {
                Properties = new CreatePolicyInputProperties()
            };

            // Check the Replication Provider Type.
            if (string.Compare(
                    this.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Set the Provider Specific Input for InMageAzureV2.
                createPolicyInput.Properties.ProviderSpecificInput = new InMageAzureV2PolicyInput
                {
                    AppConsistentFrequencyInMinutes =
                        this.ApplicationConsistentSnapshotFrequencyInHours * 60,
                    RecoveryPointHistory =
                        this.RecoveryPointRetentionInHours * 60, // Convert from hours to minutes.
                    RecoveryPointThresholdInMinutes = this.RPOWarningThresholdInMinutes,
                    MultiVmSyncStatus = (SetMultiVmSyncStatus)Enum.Parse(
                                            typeof(SetMultiVmSyncStatus),
                                            this.MultiVmSyncStatus),
                    CrashConsistentFrequencyInMinutes = crashConsistentFrequencyInMinutes
                };
            }
            else
            {
                // Set the Provider Specific Input for InMage.
                createPolicyInput.Properties.ProviderSpecificInput = new InMagePolicyInput
                {
                    AppConsistentFrequencyInMinutes =
                        this.ApplicationConsistentSnapshotFrequencyInHours * 60,
                    RecoveryPointHistory =
                        this.RecoveryPointRetentionInHours * 60, // Convert from hours to minutes.
                    RecoveryPointThresholdInMinutes = this.RPOWarningThresholdInMinutes,
                    MultiVmSyncStatus = (SetMultiVmSyncStatus)Enum.Parse(
                                            typeof(SetMultiVmSyncStatus),
                                            this.MultiVmSyncStatus)
                };
            }

            var response = this.RecoveryServicesClient.CreatePolicy(this.Name, createPolicyInput);

            var jobId = PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location);
            var jobResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(jobId);

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}
