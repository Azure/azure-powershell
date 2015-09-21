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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to change current Azure context. 
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRMContext")]
    [OutputType(typeof(AzureContext))]
    public class SetAzureRMContextCommand : AzureRMCmdlet
    {
        private const string TenantParameterSet = "Tenant";
        private const string SubscriptionParameterSet = "Subscription";
        private const string TenantAndSubscriptionParameterSet = "TenantAndSubscription";

        [Parameter(ParameterSetName = TenantParameterSet, Mandatory = true, HelpMessage = "Tenant name or ID")]
        [Parameter(ParameterSetName = TenantAndSubscriptionParameterSet, Mandatory = true, HelpMessage = "Tenant name or ID")]
        [ValidateNotNullOrEmpty]
        public string Tenant { get; set; }

        [Parameter(ParameterSetName = SubscriptionParameterSet, Mandatory = true, HelpMessage = "Subscription")]
        [Parameter(ParameterSetName = TenantAndSubscriptionParameterSet, Mandatory = true, HelpMessage = "Subscription")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        protected override void ProcessRecord()
        {
            var profileClient = new RMProfileClient(AzureRMCmdlet.DefaultProfile);

            AzureRMCmdlet.DefaultProfile.Context = profileClient.SetCurrentContext(SubscriptionId, Tenant);

            WriteObject(AzureRMCmdlet.DefaultProfile.Context);
        }
    }
}
