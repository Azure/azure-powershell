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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// New Tenant Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.Subscription, SupportsShouldProcess = true)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("New-AzureRmTenantSubscription")]
    public class NewSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the offer.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [Parameter]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier optional.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// This queue is used by the tests to assign fixed SubscritionIds
        /// every time the test runs
        /// </summary>
        public static Queue<Guid> SubscriptionIds { get; set; }

        static NewSubscription()
        {
            SubscriptionIds = new Queue<Guid>();
        }

        /// <summary>
        /// Gets the subscription definition.
        /// </summary>
        protected SubscriptionDefinition GetSubscriptionDefinition()
        {
            if (NewTenantSubscription.SubscriptionIds.Count != 0)
            {
                this.SubscriptionId = NewSubscription.SubscriptionIds.Dequeue().ToString();
            }
            else if (string.IsNullOrEmpty(this.SubscriptionId))
            {
                this.SubscriptionId = Guid.NewGuid().ToString();
            }

            return new SubscriptionDefinition()
            {
                SubscriptionId = this.SubscriptionId,
                DisplayName = this.DisplayName,
                OfferId = this.OfferId,
                State = SubscriptionState.Enabled,
            };
        }

        /// <summary>
        /// Performs the API operation(s) against subscriptions as tenant.
        /// </summary>
        protected override void ExecuteCore()
        {
            // note: this command should be deprecated
            WriteWarning("New-AzsSubscription cmdlet will be deprecated and moved to a different module in a future release.");

            if (ShouldProcess(this.SubscriptionId, VerbsCommon.New))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.CreatingNewSubscription.FormatArgs(this.OfferId, this.DisplayName));
                    var parameters = new SubscriptionCreateOrUpdateParameters(this.GetSubscriptionDefinition());
                    var result = client.Subscriptions.CreateOrUpdate(parameters).Subscription;
                    WriteObject(result);
                }
            }
        }

    }
}
