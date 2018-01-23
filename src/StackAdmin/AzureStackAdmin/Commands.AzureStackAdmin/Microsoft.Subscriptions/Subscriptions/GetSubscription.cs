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
    /// Get Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Subscription)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("Get-AzureRmTenantSubscription")]
    public class GetSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        public Guid SubscriptionId { get; set; } // Allow for empty GUID for list scenario

        /// <summary>
        /// Performs the API operation(s) against subscriptions as tenant.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Get-AzureRmTenantSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Get-AzureRmTenantSubscription will be deprecated in a future release. Please use the cmdlet name Get-AzsSubscription instead");
            }

            using (var client = this.GetAzureStackClient())
            {
                if (this.SubscriptionId == Guid.Empty)
                {
                    this.WriteVerbose(Resources.ListingSubscriptions);
                    var result = client.Subscriptions.List(true).Subscriptions;
                    WriteObject(result, enumerateCollection: true);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingSubscriptionByID.FormatArgs(this.SubscriptionId));
                    var result = client.Subscriptions.Get(this.SubscriptionId.ToString()).Subscription;
                    WriteObject(result);
                }
            }
        }
    }
}
