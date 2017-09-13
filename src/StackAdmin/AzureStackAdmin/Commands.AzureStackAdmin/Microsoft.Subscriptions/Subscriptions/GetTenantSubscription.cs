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
    [Cmdlet(VerbsCommon.Get, Nouns.TenantSubscription)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("Get-AzureRmManagedSubscription")]
    public class GetTenantSubscription : AdminApiCmdlet 
    {
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetSubscriptionId")]
        public Guid SubscriptionId { get; set; } // Allow for empty GUID for list scenario

        /// <summary>
        /// Performs the API operation(s) against subscriptions as administrator.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Get-AzureRmManagedSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Get-AzureRmManagedSubscription will be deprecated in a future release. Please use the cmdlet name Get-AzsTenantSubscription instead");
            }

            using (var client = this.GetAzureStackClient())
            {
                if (this.SubscriptionId == Guid.Empty)
                {
                    this.WriteVerbose(Resources.ListingTenantSubscriptions);
                    var result = client.TenantSubscriptions.List(includeDetails: true).Subscriptions;
                    WriteObject(result, enumerateCollection: true);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingSubscriptionByID.FormatArgs(this.SubscriptionId));
                    var result = client.TenantSubscriptions.Get(this.SubscriptionId.ToString()).Subscription;
                    WriteObject(result);
                }
            }
        }
    }
}
