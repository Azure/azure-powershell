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
    using Management.Intune;
    using Management.Intune.Models;
    using Microsoft.Azure.Commands.Intune.Properties;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get existing Android Intune MAM Policy.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneAndroidMAMPolicy"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneAndroidMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the policy Name
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy name to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (Name != null)
            {
                GetAndroidPolicyById();
            }
            else
            {
                GetAndroidPolicies();
            }
        }

        /// <summary>
        /// Get Android policy by policy name.
        /// </summary>
        private void GetAndroidPolicyById()
        {
            var andriodPolicy = this.IntuneClient.Android.GetMAMPolicyById(this.AsuHostName, this.Name);
            this.WriteObject(andriodPolicy);
        }

        /// <summary>
        /// Get all Android Policies
        /// </summary>
        private void GetAndroidPolicies()
        {
            MultiPageGetter<AndroidMAMPolicy> mpg = new MultiPageGetter<AndroidMAMPolicy>();

            List<AndroidMAMPolicy> items = mpg.GetAllResources(
                this.IntuneClientWrapper.GetAndroidMAMPolicies,
                this.IntuneClientWrapper.GetAndroidMAMPoliciesNext,
                this.AsuHostName,
                filter: null,
                top: null,
                select: null);

            this.WriteObject(items, enumerateCollection: true);
        }
    }
}
