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
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Creates Azure Site Recovery Protection Profile object in memory.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSiteRecoveryProtectionProfileObject", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [OutputType(typeof(ASRProtectionProfile))]
    public class CreateAzureSiteRecoveryProtectionProfileObject : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// Holds Name (if passed) of the protection profile object.
        /// </summary>
        private string targetName = string.Empty;

        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        public string Name { get; set; }

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
        /// Gets or sets Replication Frequency of the Protection Profile in seconds.
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
        [DefaultValue(false)]
        public SwitchParameter CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

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
        [DefaultValue(false)]
        public SwitchParameter AllowReplicaDeletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.EnterpriseToEnterpriseProtectionProfileObject();
                        break;
                    case ASRParameterSets.EnterpriseToAzure:
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
            if (string.Compare(
                this.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ReplicationProvider));
            }

            // Verify whether the storage account is associated with the subscription or not.
            bool validationSuccessful;
            bool locationValid;
            RecoveryServicesClient.ValidateStorageAccountAssociation(
                this.RecoveryAzureSubscription,
                this.RecoveryAzureStorageAccount,
                this.GetCurrentValutLocation(),
                out validationSuccessful,
                out locationValid);

            if (!validationSuccessful)
            {
                this.WriteWarning(string.Format(Properties.Resources.StorageAccountValidationUnsuccessful));
            }

            if (validationSuccessful && !locationValid)
            {
                this.WriteWarning(string.Format(Properties.Resources.StorageIsNotInTheSameLocationAsVault));
            }

            if (!validationSuccessful || !locationValid)
            {
                this.ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.ValidationUnsuccessfulWarning, this.targetName),
                    string.Format(Properties.Resources.NewProtectionProfileObjectWhatIfMessage),
                    this.targetName,
                    new Action(this.ProceedToCreateProtectionProfileObject));
            }
            else
            {
                this.ProceedToCreateProtectionProfileObject();
            }
        }

        /// <summary>
        /// Proceeds to Create an E2A Protection Profile Object after all the validations are done.
        /// </summary>
        private void ProceedToCreateProtectionProfileObject()
        {
            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            ushort replicationFrequencyInSeconds = 
                PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(
                this.ReplicationFrequencyInSeconds);

            ASRProtectionProfile protectionProfile = new ASRProtectionProfile()
            {
                Name = this.Name,
                ReplicationProvider = this.ReplicationProvider,
                HyperVReplicaAzureProviderSettingsObject = new HyperVReplicaAzureProviderSettings()
                {
                    RecoveryAzureSubscription = this.RecoveryAzureSubscription,
                    RecoveryAzureStorageAccountName = this.RecoveryAzureStorageAccount,
                    //// Currently Data Encryption is not supported.
                    EncryptStoredData = false,
                    ReplicationFrequencyInSeconds = replicationFrequencyInSeconds,
                    RecoveryPoints = this.RecoveryPoints,
                    ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                    ReplicationStartTime = this.ReplicationStartTime,
                },
                HyperVReplicaProviderSettingsObject = null
            };

            this.WriteObject(protectionProfile);
        }

        /// <summary>
        /// Creates an E2E Protection Profile object
        /// </summary>
        private void EnterpriseToEnterpriseProtectionProfileObject()
        {
            if (string.Compare(this.ReplicationProvider, Constants.HyperVReplica, StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ReplicationProvider));
            }

            PSRecoveryServicesClient.ValidateReplicationStartTime(this.ReplicationStartTime);

            ushort replicationFrequencyInSeconds = PSRecoveryServicesClient.ConvertReplicationFrequencyToUshort(this.ReplicationFrequencyInSeconds);

            ASRProtectionProfile protectionProfile = new ASRProtectionProfile()
            {
                Name = this.Name,
                ReplicationProvider = this.ReplicationProvider,
                HyperVReplicaAzureProviderSettingsObject = null,
                HyperVReplicaProviderSettingsObject = new HyperVReplicaProviderSettings()
                {
                    ReplicationMethod = this.ReplicationMethod,
                    ReplicationFrequencyInSeconds = replicationFrequencyInSeconds,
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
