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
    using System.Management.Automation;

    /// <summary>
    /// Cmdlet to get existing resources.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntuneiOSMAMPolicy"), OutputType(typeof(PSObject))]
    public sealed class GetIntuneiOSMAMPolicyCmdlet : IntuneBaseCmdlet
    {
        /// <summary>
        /// Gets the policy name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The policy name to fetch.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (Name != null)
            {
                GetiOSPolicyByName();
            }
            else
            {
                GetiOSPolicies();
            }
        }

        /// <summary>
        /// Get iOS policy by policy name.
        /// </summary>
        private void GetiOSPolicyByName()
        {
            var iOSPolicy = this.IntuneClient.Ios.GetMAMPolicyById(this.AsuHostName, this.Name);
            if (iOSPolicy != null)
            {
                this.WriteObject(iOSPolicy);
            }
            else
            {
                this.WriteObject(Resources.NoItemsReturned);
            }
        }

        /// <summary>
        /// Get all iOS Policies
        /// </summary>
        private void GetiOSPolicies()
        {
            MultiPageGetter<IOSMAMPolicy> mpg = new MultiPageGetter<IOSMAMPolicy>();
            var items = mpg.GetAllResources(
                this.IntuneClient.Ios.GetMAMPolicies,
                this.IntuneClient.Ios.GetMAMPoliciesNext,
                this.AsuHostName, filter: null);

            if (items.Count > 0)
            {
                this.WriteObject(items, enumerateCollection: true);
            }
            else
            {
                this.WriteObject(Resources.NoItemsReturned);
            }
        }
    }
}
