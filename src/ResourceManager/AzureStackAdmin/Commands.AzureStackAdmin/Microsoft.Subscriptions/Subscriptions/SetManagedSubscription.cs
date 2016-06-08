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
    /// Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, Nouns.ManagedSubscription)]
    [OutputType(typeof(SubscriptionDefinition))]
    public class SetManagedSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the subscription to be updated.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public SubscriptionDefinition Subscription { get; set; }

        /// <summary>
        /// Performs the API operation(s) against managed subscriptions.
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                this.WriteVerbose(
                    Resources.UpdatingManagedSubscription.FormatArgs(
                        this.Subscription.SubscriptionId,
                        this.Subscription.Owner,
                        this.SubscriptionId));

                var parameters = new ManagedSubscriptionCreateOrUpdateParameters(this.Subscription);
                return client.ManagedSubscriptions.CreateOrUpdate(parameters).Subscription;
            }
        }
    }
}
