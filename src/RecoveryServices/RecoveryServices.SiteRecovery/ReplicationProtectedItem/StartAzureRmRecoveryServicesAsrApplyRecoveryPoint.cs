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
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Changes a recovery point for a failed over protected item before committing the failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrApplyRecoveryPoint",DefaultParameterSetName = ASRParameterSets.ByPEObject,SupportsShouldProcess = true)]
    [Alias("Start-ASRApplyRecoveryPoint")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrApplyRecoveryPoint : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the recovery point object corresponding to the recovery point to be applied.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByPEObject,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPoint RecoveryPoint { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByPEObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets data encryption primary certificate file path for failover of protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption secondary certificate file path for failover of protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.ReplicationProtectedItem.FriendlyName,
                "Apply recovery point"))
            {
                if (!string.IsNullOrEmpty(this.DataEncryptionPrimaryCertFile))
                {
                    var certBytesPrimary = File.ReadAllBytes(this.DataEncryptionPrimaryCertFile);
                    this.primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
                }

                if (!string.IsNullOrEmpty(this.DataEncryptionSecondaryCertFile))
                {
                    var certBytesSecondary =
                        File.ReadAllBytes(this.DataEncryptionSecondaryCertFile);
                    this.secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
                }

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByPEObject:
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.StartPEApplyRecoveryPoint();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts PE Apply Recovery Point.
        /// </summary>
        private void StartPEApplyRecoveryPoint()
        {
            var applyRecoveryPointInputProperties = new ApplyRecoveryPointInputProperties
            {
                RecoveryPointId = this.RecoveryPoint.ID,
                ProviderSpecificDetails = new ApplyRecoveryPointProviderSpecificInput()
            };

            var input =
                new ApplyRecoveryPointInput { Properties = applyRecoveryPointInputProperties };

            if (0 ==
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                var hyperVReplicaAzureApplyRecoveryPointInput =
                    new HyperVReplicaAzureApplyRecoveryPointInput
                    {
                        PrimaryKekCertificatePfx = this.primaryKekCertpfx,
                        SecondaryKekCertificatePfx = this.secondaryKekCertpfx
                    };
                input.Properties.ProviderSpecificDetails =
                    hyperVReplicaAzureApplyRecoveryPointInput;
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Create the InMageAzureV2 specific Apply Recovery Point Input.
                var inMageAzureV2ApplyRecoveryPointInput =
                    new InMageAzureV2ApplyRecoveryPointInput();
                input.Properties.ProviderSpecificDetails = inMageAzureV2ApplyRecoveryPointInput;
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForApplyRecoveryPoint,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }
            else if (Constants.A2A.Equals(this.ReplicationProtectedItem.ReplicationProvider,StringComparison.OrdinalIgnoreCase))
            {
                input.Properties.ProviderSpecificDetails = new A2AApplyRecoveryPointInput();
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageRcm,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                input.Properties.ProviderSpecificDetails = new InMageRcmApplyRecoveryPointInput
                {
                    RecoveryPointId = this.RecoveryPoint.ID
                };
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageRcmFailback,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForApplyRecoveryPoint,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryApplyRecoveryPoint(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local parameters

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Primary Kek Cert pfx file.
        /// </summary>
        private string primaryKekCertpfx;

        /// <summary>
        ///     Secondary Kek Cert pfx file.
        /// </summary>
        private string secondaryKekCertpfx;

        #endregion local parameters
    }
}
