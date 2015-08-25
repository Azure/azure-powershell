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
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryTestFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryTestFailoverJob : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Network ID.
        /// </summary>
        private string networkId = string.Empty;

        /// <summary>
        /// Network Type (Logical network or VM network).
        /// </summary>
        private string networkType = string.Empty;

        /// <summary>
        /// Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
          Constants.PrimaryToRecovery,
          Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByPEObject:
                        this.networkType = "DisconnectedVMNetworkTypeForTestFailover";
                        this.StartPETestFailover();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Starts PE Test failover.
        /// </summary>
        private void StartPETestFailover()
        {
            var request = new TestFailoverRequest();

            if (this.ProtectionEntity == null)
            {
                var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.ProtectionEntity.ProtectionContainerId,
                    this.ProtectionEntity.Name);
                this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);
            }

            request.FailoverDirection = this.Direction;
            request.NetworkID = this.networkId;
            request.NetworkType = this.networkType;

            if (string.IsNullOrEmpty(this.ProtectionEntity.ReplicationProvider))
            {
                // fetch the latest PE object
                // As get PE by name is failing before protection, get all & filter.
                // Once after we fix get pe by name, change the logic to use the same.
                ProtectionEntityListResponse protectionEntityListResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.ProtectionEntity.ProtectionContainerId);

                foreach (ProtectionEntity pe in protectionEntityListResponse.ProtectionEntities)
                {
                    if (0 == string.Compare(this.ProtectionEntity.FriendlyName, pe.Properties.FriendlyName, true))
                    {
                        this.ProtectionEntity = new ASRProtectionEntity(pe);
                        break;
                    }
                }
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.ReplicationProviderSettings = new FailoverReplicationProviderSpecificInput();

            if (0 == string.Compare(
                this.ProtectionEntity.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase))
            {
                AzureFailoverInput failoverInput = new AzureFailoverInput()
                {
                    PrimaryKekCertificatePfx = string.Empty,
                    SecondaryKekCertificatePfx = string.Empty,
                    VaultLocation = this.GetCurrentValutLocation()
                };
                request.ReplicationProviderSettings = failoverInput;
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.ProtectionEntity.ProtectionContainerId,
                this.ProtectionEntity.Name,
                request);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}