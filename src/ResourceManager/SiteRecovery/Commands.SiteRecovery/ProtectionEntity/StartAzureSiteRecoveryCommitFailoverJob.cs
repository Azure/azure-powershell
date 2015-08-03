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
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;
using Microsoft.Azure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryCommitFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryCommitFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Gets or sets ID of the PE.
        /// </summary>
        public string protectionEntityId;

        /// <summary>
        /// Gets or sets ID of the Protection Container.
        /// </summary>
        public string protectionContainerId;

        #region Parameters
        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }
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
                        this.protectionEntityId = this.ProtectionEntity.Name;
                        this.protectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                        this.SetPECommit();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Start PE Commit.
        /// </summary>
        private void SetPECommit()
        {
            var request = new CommitFailoverRequest();

            if (this.ProtectionEntity == null)
            {
                var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                    this.protectionContainerId,
                    this.protectionEntityId);
                this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);

                this.ValidateUsageById(
                    this.ProtectionEntity.ReplicationProvider, 
                    Constants.ProtectionEntityId);
            }

            request.ReplicationProvider = this.ProtectionEntity.ReplicationProvider;
            request.ReplicationProviderSettings = string.Empty;
            request.FailoverDirection = this.Direction;
 
            //if (this.ProtectionEntity.ActiveLocation == Constants.PrimaryLocation)
            //{
            //    request.FailoverDirection = Constants.RecoveryToPrimary;
            //}
            //else
            //{
            //    request.FailoverDirection = Constants.PrimaryToRecovery;
            //}

            LongRunningOperationResponse response = RecoveryServicesClient.StartAzureSiteRecoveryCommitFailover(
                this.protectionContainerId,
                this.protectionEntityId,
                request);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}