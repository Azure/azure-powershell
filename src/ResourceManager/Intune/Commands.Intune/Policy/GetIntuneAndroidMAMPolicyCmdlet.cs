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
    using System.Linq;
    using System.Management.Automation;
    using RestClient;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneAndroidMAMPolicy"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneAndroidMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the policy Name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The policy name to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            Action action = () =>
            {
                if (Name != null)
                {
                    GetAndroidPolicyById();
                }
                else
                {
                    GetAndroidPolicies();
                }
            };

            base.SafeExecutor(action);
        }

        /// <summary>
        /// Get Android policy by policy Id
        /// </summary>
        private void GetAndroidPolicyById()
        {
            var andriodPolicy = this.IntuneClient.GetAndroidMAMPolicyById(this.AsuHostName, this.Name);
            if (andriodPolicy != null)
            {
                this.WriteObject(andriodPolicy);
            }
            else
            {
                this.WriteObject("0 Policies returned");
            }
        }

        /// <summary>
        /// Get all Android Policies
        /// </summary>
        private void GetAndroidPolicies()
        {
            var androidPolicies = this.IntuneClient.GetAndroidMAMPolicies(this.AsuHostName);
            if (androidPolicies != null && androidPolicies.Value.Count > 0)
            {
                for (int start = 0; start < androidPolicies.Value.Count; start += IntuneConstants.BATCH_SIZE)
                {
                    var batch = androidPolicies.Value.Skip(start).Take(IntuneConstants.BATCH_SIZE);
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
