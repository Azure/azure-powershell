﻿// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;

namespace Microsoft.AzureStack.Commands
{
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// New Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.ManagedSubscription)]
    [OutputType(typeof(SubscriptionDefinition))]
    public class NewManagedSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Owner { get; set; }

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
        /// This queue is used by the tests to assign fixed SubscritionIds
        /// every time the test runs
        /// </summary>
        public static Queue<Guid> SubscriptionIds { get; set; }

        static NewManagedSubscription()
        {
            SubscriptionIds = new Queue<Guid>();
        }

        /// <summary>
        /// Gets the subscription definition.
        /// </summary>
        protected SubscriptionDefinition GetSubscriptionDefinition()
        {
            return new SubscriptionDefinition()
            {
                SubscriptionId = (NewManagedSubscription.SubscriptionIds.Count == 0
                           ? Guid.NewGuid()
                           : NewManagedSubscription.SubscriptionIds.Dequeue()).ToString(),
                DisplayName = this.DisplayName,
                OfferId = this.OfferId,
                OfferName = GetAndValidateOfferName(this.OfferId),
                Owner = this.Owner,
                State = SubscriptionState.Enabled,
            };
        }

        /// <summary>
        /// Performs the API operation(s) against managed subscriptions.
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                this.WriteVerbose(Resources.CreatingNewSubscription.FormatArgs(this.Owner, this.OfferId, this.DisplayName));
                var parameters = new ManagedSubscriptionCreateOrUpdateParameters(this.GetSubscriptionDefinition());
                return client.ManagedSubscriptions.CreateOrUpdate(parameters).Subscription;
            }
        }

        /// <summary>
        /// Gets and validates the name of the offer.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        private static string GetAndValidateOfferName(string offerId)
        {
            ArgumentValidator.ValidateNotNull("offerId", offerId);

            var parts = offerId.Trim('/').Split('/');

            if (parts.Length != 4
                || !"delegatedProviders".EqualsInsensitively(parts[0])
                || !"offers".EqualsInsensitively(parts[2])
                || string.IsNullOrWhiteSpace(parts[1])
                || string.IsNullOrWhiteSpace(parts[3]))
            {
                throw new ArgumentException(
                    message: "Invalid offer identifier; must be of the form '/delegatedProviders/{providerId}/offers/{offerName}'",
                    paramName: "offerId");
            }

            return parts[3];
        }
    }
}
