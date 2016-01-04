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
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Server.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryPolicy", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRPolicy>))]
    public class GetAzureSiteRecoveryPolicy : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }
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
            catch (Exception exception)
            {
                this.HandleException(exception);
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
                    this.WritePolicy(policy);
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
                    this.WritePolicy(policy);
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
        /// <param name="policy">List of Profiles</param>
        private void WritePolicies(IList<Policy> policy)
        {
            this.WriteObject(policy.Select(p => new ASRPolicy(p)), true);
        }

        /// <summary>
        /// Write Profile.
        /// </summary>
        /// <param name="policy">Profile object</param>
        private void WritePolicy(Policy policy)
        {
            this.WriteObject(new ASRPolicy(policy));
        }
    }
}