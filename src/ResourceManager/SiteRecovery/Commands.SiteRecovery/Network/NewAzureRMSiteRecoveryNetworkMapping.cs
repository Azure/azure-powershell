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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Network mapping.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSiteRecoveryNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "New-AzureRmRecoveryServicesAsrNetworkMapping cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class NewAzureRmSiteRecoveryNetworkMapping : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = false)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Primary Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork PrimaryNetwork { get; set; }

        /// <summary>
        /// Gets or sets Recovery Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AzureVMNetworkId { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.EnterpriseToEnterprise:
                    this.EnterpriseToEnterpriseNetworkMapping();
                    break;
                case ASRParameterSets.EnterpriseToAzure:
                    this.EnterpriseToAzureNetworkMapping();
                    break;
            }
        }

        /// <summary>
        /// Enterprise to enterprise network mapping.
        /// </summary>
        private void EnterpriseToEnterpriseNetworkMapping()
        {
            string mappingName = String.IsNullOrEmpty(this.Name) ?
                this.PrimaryNetwork.FriendlyName.Replace(" ", "") + "-" + this.RecoveryNetwork.FriendlyName.Replace(" ", "") + "-" + Guid.NewGuid().ToString() :
                this.Name;

            LongRunningOperationResponse response =
                RecoveryServicesClient
                .NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(this.PrimaryNetwork.ID, ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(this.PrimaryNetwork.ID, ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                Utilities.GetValueFromArmId(this.RecoveryNetwork.ID, ARMResourceTypeConstants.ReplicationFabrics),
                this.RecoveryNetwork.ID);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }

        /// <summary>
        /// Enterprise to Azure network mapping.
        /// </summary>
        private void EnterpriseToAzureNetworkMapping()
        {
            string mappingName = String.IsNullOrEmpty(this.Name) ?
                this.PrimaryNetwork.FriendlyName.Replace(" ", "") + "-" + Utilities.GetValueFromArmId(this.AzureVMNetworkId, ARMResourceTypeConstants.VirtualNetworks).Replace(" ", "") + "-" + Guid.NewGuid().ToString() :
                this.Name;

            LongRunningOperationResponse response =
                RecoveryServicesClient
                .NewAzureSiteRecoveryNetworkMapping(
                Utilities.GetValueFromArmId(this.PrimaryNetwork.ID, ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(this.PrimaryNetwork.ID, ARMResourceTypeConstants.ReplicationNetworks),
                mappingName,
                "Microsoft Azure",
                this.AzureVMNetworkId);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}