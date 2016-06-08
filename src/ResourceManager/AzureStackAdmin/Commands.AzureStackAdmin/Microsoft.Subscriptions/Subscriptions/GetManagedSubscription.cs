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
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Get Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.ManagedSubscription)]
    [OutputType(typeof(SubscriptionDefinition))]
    public class GetManagedSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public Guid TargetSubscriptionId { get; set; } // Allow for empty GUID for list scenario

        /// <summary>
        /// Gets or sets the admin subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Performs the API operation(s) against managed subscriptions.
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                if (this.TargetSubscriptionId == Guid.Empty)
                {
                    this.WriteVerbose(Resources.ListingManagedSubscriptions);
                    return client.ManagedSubscriptions.List(includeDetails: true).Subscriptions;
                }
                else
                {
                    this.WriteVerbose(Resources.GettingSubscriptionByID.FormatArgs(this.TargetSubscriptionId));
                    return client.ManagedSubscriptions.Get(this.TargetSubscriptionId.ToString()).Subscription;
                }
            }
        }
    }
}
