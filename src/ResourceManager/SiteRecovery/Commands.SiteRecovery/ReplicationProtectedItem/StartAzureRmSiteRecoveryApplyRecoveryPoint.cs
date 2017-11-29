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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a apply recovery point operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryApplyRecoveryPoint", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Start-AzureRmRecoveryServicesAsrApplyRecoveryPoint cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class StartAzureRmSiteRecoveryApplyRecoveryPoint : SiteRecoveryCmdletBase
    {
        #region local parameters

        /// <summary>
        /// Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        /// Primary Kek Cert pfx file.
        /// </summary>
        string primaryKekCertpfx = null;

        /// <summary>
        /// Secondary Kek Cert pfx file.
        /// </summary>
        string secondaryKekCertpfx = null;

        #endregion local parameters

        #region Parameters

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPoint RecoveryPoint { get; set; }

        /// <summary>
        /// Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (!string.IsNullOrEmpty(this.DataEncryptionPrimaryCertFile))
            {
                byte[] certBytesPrimary = File.ReadAllBytes(this.DataEncryptionPrimaryCertFile);
                primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
            }

            if (!string.IsNullOrEmpty(this.DataEncryptionSecondaryCertFile))
            {
                byte[] certBytesSecondary = File.ReadAllBytes(this.DataEncryptionSecondaryCertFile);
                secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
            }

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByPEObject:
                    this.fabricName = Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics);
                    this.protectionContainerName =
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers);
                    this.StartPEApplyRecoveryPoint();
                    break;
            }
        }

        /// <summary>
        /// Starts PE Apply Recovery Point.
        /// </summary>
        private void StartPEApplyRecoveryPoint()
        {
            var applyRecoveryPointInputProperties = new ApplyRecoveryPointInputProperties()
            {
                RecoveryPointId = this.RecoveryPoint.ID,
                ProviderSpecificDetails = new ApplyRecoveryPointProviderSpecificInput()
            };

            var input = new ApplyRecoveryPointInput()
            {
                Properties = applyRecoveryPointInputProperties
            };

            if (0 == string.Compare(
                this.ReplicationProtectedItem.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase))
            {
                var hyperVReplicaAzureApplyRecoveryPointInput = new HyperVReplicaAzureApplyRecoveryPointInput()
                {
                    PrimaryKekCertificatePfx = primaryKekCertpfx,
                    SecondaryKekCertificatePfx = secondaryKekCertpfx,
                    VaultLocation = this.GetCurrentVaultLocation()
                };
                input.Properties.ProviderSpecificDetails = hyperVReplicaAzureApplyRecoveryPointInput;
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryApplyRecoveryPoint(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}