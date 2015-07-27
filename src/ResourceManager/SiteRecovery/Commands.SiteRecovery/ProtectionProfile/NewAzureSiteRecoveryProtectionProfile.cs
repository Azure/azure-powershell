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
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Protection Profile object in memory.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSiteRecoveryProtectionProfile")]
    public class NewAzureSiteRecoveryProtectionProfile : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Holds Name (if passed) of the protection profile object.
        /// </summary>
        private string targetName = string.Empty;

        #region Parameters

        /// <summary>
        /// Gets or sets Name of the Protection Profile.
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Replication Provider of the Protection Profile.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.HyperVReplica)]
        public string ReplicationProvider { get; set; }

        /// <summary>
        /// Gets or sets a value for Replication Method of the Protection Profile.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OnlineReplicationMethod,
            Constants.OfflineReplicationMethod)]
        public string ReplicationMethod { get; set; }

        /// <summary>
        /// Gets or sets Replication Frequency of the Protection Profile in seconds.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Thirty,
            Constants.ThreeHundred,
            Constants.NineHundred)]
        public string ReplicationFrequencyInSeconds { get; set; }

        /// <summary>
        /// Gets or sets Recovery Points of the Protection Profile.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int RecoveryPoints { get; set; }

        /// <summary>
        /// Gets or sets Application Consistent Snapshot Frequency of the Protection Profile in hours.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [DefaultValue(0)]
        public int ApplicationConsistentSnapshotFrequencyInHours { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Compression needs to be Enabled on the Protection Profile.
        /// </summary>
        [Parameter]
        [DefaultValue(false)]
        public SwitchParameter CompressionEnabled { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ushort ReplicationPort { get; set; }

        /// <summary>
        /// Gets or sets the Replication Port of the Protection Profile.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.AuthenticationTypeCertificate,
            Constants.AuthenticationTypeKerberos)]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets Replication Start time of the Protection Profile.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public TimeSpan? ReplicationStartTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Replica should be Deleted on 
        /// disabling protection of a protection entity protected by the Protection Profile.
        /// </summary>
        [Parameter]
        [DefaultValue(false)]
        public SwitchParameter AllowReplicaDeletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.EnterpriseToEnterpriseProtectionProfileObject();
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
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

            HyperVReplicaProtectionProfileInput hyperVReplicaProtectionProfileInput
                    = new HyperVReplicaProtectionProfileInput()
                    {
                        ApplicationConsistentSnapshotFrequencyInHours = this.ApplicationConsistentSnapshotFrequencyInHours,
                        ReplicationFrequencyInSeconds = replicationFrequencyInSeconds,
                        OnlineReplicationStartTime = this.ReplicationStartTime,
                        Compression = this.CompressionEnabled == true ? "Enable" : "Disable",
                        InitialReplicationMethod = (string.Compare(this.ReplicationMethod, Constants.OnlineReplicationMethod, StringComparison.OrdinalIgnoreCase) == 0) ? "OverNetwork" : "Offline",
                        RecoveryPoints = this.RecoveryPoints,
                        ReplicationPort = this.ReplicationPort,
                        ReplicaDeletion = this.AllowReplicaDeletion == true ? "Required" : "NotRequired",
                        AllowedAuthenticationType = (ushort)((string.Compare(this.Authentication, Constants.AuthenticationTypeKerberos, StringComparison.OrdinalIgnoreCase) == 0) ? 1 : 2)
                    };

            CreateProtectionProfileInput createProtectionProfileInput = new CreateProtectionProfileInput();
            createProtectionProfileInput.Name = this.Name;
            createProtectionProfileInput.ReplicationProvider = this.ReplicationProvider;
            createProtectionProfileInput.ReplicationProviderSettings = hyperVReplicaProtectionProfileInput;

            LongRunningOperationResponse response = 
                RecoveryServicesClient.CreateProtectionProfile(createProtectionProfileInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
