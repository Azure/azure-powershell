﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet(VerbsLifecycle.Start, "AzureSiteRecoveryProtectionProfileDissociationJob", DefaultParameterSetName = ASRParameterSets.EnterpriseToAzure)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryProtectionProfileDissociationJob : RecoveryServicesCmdletBase
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
        /// Gets or sets Protection Container to be removed the Protection Profile settings off.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer PrimaryProtectionContainer { get; set; }

        /// <summary>
        /// Gets or sets Protection Container to be removed the Protection Profile settings off.
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
                string recoveryContainerId = string.Empty;
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.EnterpriseToAzure:
                        if (this.ProtectionProfile.ReplicationProvider != Constants.HyperVReplicaAzure)
                        {
                            throw new Exception("Please provide recovery container object.");
                        }
                        else
                        {
                            recoveryContainerId = Constants.AzureContainer;
                        }

                        break;
                    case ASRParameterSets.EnterpriseToEnterprise:
                             recoveryContainerId = this.RecoveryProtectionContainer.ID;
                       break;
                }

                CreateProtectionProfileInput createProtectionProfileInput = null;
                if (string.Compare(
                    this.ProtectionProfile.ReplicationProvider,
                    Constants.San,
                    StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        SanProtectionProfileInput sanProtectionProfileInput
                                = new SanProtectionProfileInput()
                                {
                                    CloudId = this.ProtectionProfile.SanProviderSettingsObject.CloudId,
                                    RemoteCloudId = this.ProtectionProfile.SanProviderSettingsObject.RemoteCloudId,
                                    ArrayUniqueId = this.ProtectionProfile.SanProviderSettingsObject.ArrayUniqueId,
                                    RemoteArrayUniqueId = this.ProtectionProfile.SanProviderSettingsObject.RemoteArrayUniqueId
                                };

                        createProtectionProfileInput =
                                new CreateProtectionProfileInput(
                                    //// Name of the protection profile as the name of the protection container if not given
                                    string.IsNullOrEmpty(this.ProtectionProfile.Name) ? this.PrimaryProtectionContainer.Name : this.ProtectionProfile.Name,
                                    this.ProtectionProfile.ReplicationProvider,
                                    DataContractUtils<SanProtectionProfileInput>.Serialize(sanProtectionProfileInput));
                    }

                ProtectionProfileAssociationInput protectionProfileAssociationInput =
                    new ProtectionProfileAssociationInput(
                        this.PrimaryProtectionContainer.ID,
                        recoveryContainerId);

                CreateAndAssociateProtectionProfileInput createAndAssociateProtectionProfileInput =
                    new CreateAndAssociateProtectionProfileInput(
                        createProtectionProfileInput,
                        protectionProfileAssociationInput);

                this.jobResponse = RecoveryServicesClient.StartDeleteAndDissociateAzureSiteRecoveryProtectionProfileJob(
                    this.ProtectionProfile.ID,
                    createAndAssociateProtectionProfileInput);

                this.WriteJob(this.jobResponse.Job);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
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
