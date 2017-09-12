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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Used to initiate resync / repair replication.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start, 
        "AzureRmRecoveryServicesAsrResyncReplication", 
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias(
        "Start-ASRResyncReplication",
        "Start-ASRResync")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrResyncReplication : SiteRecoveryCmdletBase
    {
        /// <summary>
        /// Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            // Set the Fabric Name and Protection Container Name.
            this.fabricName =
                Utilities.GetValueFromArmId(
                    this.ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);
            this.protectionContainerName =
                Utilities.GetValueFromArmId(
                    this.ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);

            // Resync Replication of the Protected Item.
            PSSiteRecoveryLongRunningOperation response =
                RecoveryServicesClient.StartAzureSiteRecoveryResyncReplication(
                    this.fabricName,
                    this.protectionContainerName,
                    this.ReplicationProtectedItem.Name);

            Job jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails
                    (PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        #region Private Parameters

        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        /// Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        #endregion Local Parameters
    }
}
