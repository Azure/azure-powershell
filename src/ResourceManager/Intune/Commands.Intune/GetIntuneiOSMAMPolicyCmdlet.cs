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

namespace Microsoft.Azure.Commands.Intune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using RestClient;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneiOSMAMPolicy"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the policy Id
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The policy Id to fetch.")]
        [ValidateNotNullOrEmpty]
        public string PolicyId { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            Action action = () =>
            {
                if (PolicyId != null)
                {
                    GetiOSPolicyById();
                }
                else
                {
                    GetiOSPolicies();
                }
            };

            base.SafeExecutor(action);
        }

        /// <summary>
        /// Get iOS policy by policy Id
        /// </summary>
        private void GetiOSPolicyById()
        {
            var iOSPolicy = this.IntuneClient.GetiOSMAMPolicyById(this.AsuHostName, this.PolicyId);
            if (iOSPolicy != null)
            {
                this.WriteObject(iOSPolicy);
            }
            else
            {
                this.WriteObject("0 Policies returned");
            }
        }

        /// <summary>
        /// Get all iOS Policies
        /// </summary>
        private void GetiOSPolicies()
        {
            var iOSPolicies = this.IntuneClient.GetiOSMAMPolicies(this.AsuHostName);
            if (iOSPolicies != null && iOSPolicies.Value.Count > 0)
            {
                for (int batchSize = 10, start = 0; start < iOSPolicies.Value.Count; start += batchSize)
                {
                    var batch = iOSPolicies.Value.Skip(start).Take(batchSize);
                    this.WriteObject(batch, enumerateCollection: true);
                }
            }
            else
            {
                this.WriteObject("0 Policies returned");
            }
        }
    }
}
