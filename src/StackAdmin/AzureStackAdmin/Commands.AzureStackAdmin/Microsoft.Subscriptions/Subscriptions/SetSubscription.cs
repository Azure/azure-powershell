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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.Subscription, SupportsShouldProcess = true)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("Set-AzureRmTenantSubscription")]
    public class SetSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription to be updated.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public SubscriptionDefinition Subscription { get; set; }

        /// <summary>
        /// Performs the API operation(s) against subscriptions as tenant.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Set-AzureRmTenantSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Set-AzureRmTenantSubscription will be deprecated in a future release. Please use the cmdlet name Set-AzsSubscription instead");
            }

            if (ShouldProcess(this.Subscription.SubscriptionId, VerbsCommon.Set))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.UpdatingSubscription.FormatArgs(this.Subscription.SubscriptionId));
                    var parameters = new SubscriptionCreateOrUpdateParameters(this.Subscription);
                    var result = client.Subscriptions.CreateOrUpdate(parameters).Subscription;
                    WriteObject(result);
                }
            }
        }
    }
}
