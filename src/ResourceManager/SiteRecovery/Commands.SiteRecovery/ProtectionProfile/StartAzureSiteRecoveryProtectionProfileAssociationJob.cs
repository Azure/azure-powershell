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
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Adds Azure Site Recovery Protection Profile settings to a Protection Container.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryProtectionProfileAssociationJob")]
    // [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryProtectionProfileAssociationJob : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Protection Profile object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be applied the Protection Profile settings on.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
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
                this.EnterpriseToEnterpriseAssociation();
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Associates protection profile with enterprise based protection containers
        /// </summary>
        private void EnterpriseToEnterpriseAssociation()
        {
            if (string.Compare(
                this.ProtectionProfile.ReplicationProvider,
                Constants.HyperVReplica,
                StringComparison.OrdinalIgnoreCase) != 0 &&
                string.Compare(
                this.ProtectionProfile.ReplicationProvider,
                Constants.San,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.IncorrectReplicationProvider,
                    this.ProtectionProfile.ReplicationProvider));
            }

            ProtectionProfileAssociationInput protectionProfileAssociationInput =
                new ProtectionProfileAssociationInput(
                    this.PrimaryProtectionContainer.Name,
                    this.RecoveryProtectionContainer.Name);

            LongRunningOperationResponse response = RecoveryServicesClient.AssociateAzureSiteRecoveryProtectionProfile(
                this.ProtectionProfile.Name,
                protectionProfileAssociationInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse.Job));
        }

        ///// <summary>
        ///// Writes Job
        ///// </summary>
        ///// <param name="job">Job object</param>
        //private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        //{
        //    this.WriteObject(new ASRJob(job));
        //}
    }
}
