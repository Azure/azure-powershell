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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Creates Azure Site Recovery Network mapping.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSiteRecoveryNetworkMapping")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureSiteRecoveryNetworkMapping : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Primary Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork PrimaryNetwork {get; set;}

        /// <summary>
        /// Gets or sets Recovery Network object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRNetwork RecoveryNetwork { get; set; }

        /// <summary>
        /// Gets or sets Azure subscription.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AzureSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string AzureVMNetworkId { get; set; }

        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;
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
                        case ASRParameterSets.EnterpriseToEnterprise:
                            this.EnterpriseToEnterpriseNetworkMapping();
                            break;
                        case ASRParameterSets.EnterpriseToAzure:
                            this.EnterpriseToAzureNetworkMapping();
                            break;
                    }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        private void EnterpriseToEnterpriseNetworkMapping()
        {
            this.jobResponse =
                RecoveryServicesClient
                .NewAzureSiteRecoveryNetworkMapping(
                PrimaryNetwork.ServerId,
                PrimaryNetwork.ID,
                RecoveryNetwork.ServerId,
                RecoveryNetwork.ID);

            this.WriteJob(this.jobResponse.Job);
        }

        private void EnterpriseToAzureNetworkMapping()
        {
            //validate AzureVM Network and then gen the name

            // Verify whether the subscription is associated with the account or not.
            RecoveryServicesClient.ValidateSubscriptionAccountAssociation(this.AzureSubscriptionId);

            // Check if the Azure VM Network is associated with the Subscription or not.
            RecoveryServicesClient.ValidateVMNetworkSubscriptionAssociation(this.AzureSubscriptionId, this.AzureVMNetworkId);

            string azureVMNetworkName = string.Empty;
            this.jobResponse =
                RecoveryServicesClient
                .NewAzureSiteRecoveryAzureNetworkMapping(
                PrimaryNetwork.ServerId,
                PrimaryNetwork.ID,
                azureVMNetworkName,
                AzureVMNetworkId);

            this.WriteJob(this.jobResponse.Job);
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}