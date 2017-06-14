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

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Adds Azure Site Recovery Protection Profile settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryProtectionProfileAssociationJob", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryProtectionProfileAssociationJob : RecoveryServicesCmdletBase
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
        /// Gets or sets Protection Container to be applied the Protection Profile settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Recovery Protection Container to be applied the Protection Profile settings on.
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
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

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
        /// Handles interrupts.
        /// </summary>
        protected override void StopProcessing()
        {
            // Ctrl + C and etc
            base.StopProcessing();
            this.StopProcessingFlag = true;
        }

        /// <summary>
        /// Associates protection profile with one enterprise based and an Azure protection container
        /// </summary>
        private void EnterpriseToAzureAssociation()
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

            CreateProtectionProfileInput createProtectionProfileInput =
                new CreateProtectionProfileInput(
                    string.IsNullOrEmpty(this.ProtectionProfile.Name) ? this.PrimaryProtectionContainer.Name : this.ProtectionProfile.Name,
                    this.ProtectionProfile.ReplicationProvider,
                    DataContractUtils<HyperVReplicaAzureProtectionProfileInput>.Serialize(hyperVReplicaAzureProtectionProfileInput));

            ProtectionProfileAssociationInput protectionProfileAssociationInput =
                new ProtectionProfileAssociationInput(
                    this.PrimaryProtectionContainer.ID,
                    Constants.AzureContainer);

            CreateAndAssociateProtectionProfileInput createAndAssociateProtectionProfileInput =
                new CreateAndAssociateProtectionProfileInput(
                    createProtectionProfileInput,
                    protectionProfileAssociationInput);

            this.jobResponse = RecoveryServicesClient.StartCreateAndAssociateAzureSiteRecoveryProtectionProfileJob(
                createAndAssociateProtectionProfileInput);

            this.WriteJob(this.jobResponse.Job);
        }

        /// <summary>
        /// Associates protection profile with enterprise based protection containers
        /// </summary>
        private void EnterpriseToEnterpriseAssociation()
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

            HyperVReplicaProtectionProfileInput hyperVReplicaProtectionProfileInput
                    = new HyperVReplicaProtectionProfileInput()
                    {
                        ApplicationConsistentSnapshotFrequencyInHours = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ApplicationConsistentSnapshotFrequencyInHours,
                        ReplicationFrequencyInSeconds = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationFrequencyInSeconds,
                        OnlineReplicationStartTime = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationStartTime,
                        CompressionEnabled = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.CompressionEnabled,
                        OnlineReplicationMethod = (string.Compare(this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? true : false,
                        RecoveryPoints = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.RecoveryPoints,
                        ReplicationPort = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.ReplicationPort,
                        AllowReplicaDeletion = this.ProtectionProfile.HyperVReplicaProviderSettingsObject.AllowReplicaDeletion,
                        AllowedAuthenticationType = (ushort)((string.Compare(this.ProtectionProfile.HyperVReplicaProviderSettingsObject.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2),
                    };

            CreateProtectionProfileInput createProtectionProfileInput =
                new CreateProtectionProfileInput(
                    //// Name of the protection profile as the name of the protection container if not given
                    string.IsNullOrEmpty(this.ProtectionProfile.Name) ? this.PrimaryProtectionContainer.Name : this.ProtectionProfile.Name,
                    this.ProtectionProfile.ReplicationProvider,
                    DataContractUtils<HyperVReplicaProtectionProfileInput>.Serialize(hyperVReplicaProtectionProfileInput));

            ProtectionProfileAssociationInput protectionProfileAssociationInput =
                new ProtectionProfileAssociationInput(
                    this.PrimaryProtectionContainer.ID,
                    this.RecoveryProtectionContainer.ID);

            CreateAndAssociateProtectionProfileInput createAndAssociateProtectionProfileInput =
                new CreateAndAssociateProtectionProfileInput(
                    createProtectionProfileInput,
                    protectionProfileAssociationInput);

            this.jobResponse = RecoveryServicesClient.StartCreateAndAssociateAzureSiteRecoveryProtectionProfileJob(
                createAndAssociateProtectionProfileInput);

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
