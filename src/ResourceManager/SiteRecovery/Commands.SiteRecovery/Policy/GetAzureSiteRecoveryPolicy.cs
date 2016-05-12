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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryPolicy", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRPolicy>))]
    public class GetAzureSiteRecoveryPolicy : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets name of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.ByName:
                    this.GetByName();
                    break;
                case ASRParameterSets.Default:
                    this.GetAll();
                    break;
            }
        }

        /// <summary>
        /// Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            PolicyListResponse profileListResponse =
                 RecoveryServicesClient.GetAzureSiteRecoveryPolicy();
            bool found = false;

            foreach (Policy policy in profileListResponse.Policies)
            {
                if (0 == string.Compare(this.FriendlyName, policy.Properties.FriendlyName, true))
                {
                    var policyByName = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(policy.Name).Policy;
                    this.WritePolicy(policyByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.PolicyNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }

        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            PolicyListResponse profileListResponse =
                 RecoveryServicesClient.GetAzureSiteRecoveryPolicy();
            bool found = false;

            foreach (Policy policy in profileListResponse.Policies)
            {
                if (0 == string.Compare(this.Name, policy.Name, true))
                {
                    var policyByName = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(policy.Name).Policy;
                    this.WritePolicy(policyByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.PolicyNotFound,
                    this.Name,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            PolicyListResponse policyListResponse =
                 RecoveryServicesClient.GetAzureSiteRecoveryPolicy();

            this.WritePolicies(policyListResponse.Policies);
        }

        /// <summary>
        /// Write Policies.
        /// </summary>
        /// <param name="policy">List of Policies</param>
        private void WritePolicies(IList<Policy> policy)
        {
            this.WriteObject(policy.Select(p => new ASRPolicy(p)), true);
        }

        /// <summary>
        /// Write Policy.
        /// </summary>
        /// <param name="policy">Policy object</param>
        private void WritePolicy(Policy policy)
        {
            this.WriteObject(new ASRPolicy(policy));
        }
    }
}