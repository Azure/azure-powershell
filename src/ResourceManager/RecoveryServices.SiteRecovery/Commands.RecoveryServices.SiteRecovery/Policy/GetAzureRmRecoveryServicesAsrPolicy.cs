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
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrPolicy",
        DefaultParameterSetName = ASRParameterSets.Default)]
    [Alias("Get-ASRPolicy")]
    [OutputType(typeof(IEnumerable<ASRPolicy>))]
    public class GetAzureRmRecoveryServicesAsrPolicy : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets name of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of the Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByFriendlyName:
                    GetByFriendlyName();
                    break;
                case ASRParameterSets.ByName:
                    GetByName();
                    break;
                case ASRParameterSets.Default:
                    GetAll();
                    break;
            }
        }

        /// <summary>
        ///     Queries by Friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            var profileListResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy();
            var found = false;

            foreach (var policy in profileListResponse)
            {
                if (0 ==
                    string.Compare(FriendlyName,
                        policy.Properties.FriendlyName,
                        true))
                {
                    var policyByName =
                        RecoveryServicesClient.GetAzureSiteRecoveryPolicy(policy.Name);
                    WritePolicy(policyByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(string.Format(Resources.PolicyNotFound,
                    FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Name);

                if (policyResponse != null)
                {
                    WritePolicy(policyResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(string.Format(Resources.PolicyNotFound,
                        Name,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Queries all / by default.
        /// </summary>
        private void GetAll()
        {
            var policyListResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy();

            WritePolicies(policyListResponse);
        }

        /// <summary>
        ///     Write Policies.
        /// </summary>
        /// <param name="policy">List of Policies</param>
        private void WritePolicies(IList<Policy> policy)
        {
            WriteObject(policy.Select(p => new ASRPolicy(p)),
                true);
        }

        /// <summary>
        ///     Write Policy.
        /// </summary>
        /// <param name="policy">Policy object</param>
        private void WritePolicy(Policy policy)
        {
            WriteObject(new ASRPolicy(policy));
        }
    }
}