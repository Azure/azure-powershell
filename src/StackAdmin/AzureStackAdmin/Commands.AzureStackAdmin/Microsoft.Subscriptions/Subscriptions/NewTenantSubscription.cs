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
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// New Managed Subscription Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, Nouns.TenantSubscription, SupportsShouldProcess = true)]
    [OutputType(typeof(SubscriptionDefinition))]
    [Alias("New-AzureRmManagedSubscription", "New-AzsTenantSubscription")]
    public class NewTenantSubscription : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription owner.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the offer.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateLength(1, 512)]
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
        /// Gets or sets the display name.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string DelegatedProviderSubscriptionId { get; set; }

        /// <summary>
        /// This queue is used by the tests to assign fixed SubscritionIds
        /// every time the test runs
        /// </summary>
        public static Queue<Guid> SubscriptionIds { get; set; }

        static NewTenantSubscription()
        {
            SubscriptionIds = new Queue<Guid>();
        }

        /// <summary>
        /// Gets the subscription definition.
        /// </summary>
        protected AdminSubscriptionDefinition GetSubscriptionDefinition()
        {
            if (NewTenantSubscription.SubscriptionIds.Count != 0)
            {
                this.SubscriptionId = NewTenantSubscription.SubscriptionIds.Dequeue().ToString();
            }
            else if (string.IsNullOrEmpty(this.SubscriptionId))
            {
                this.SubscriptionId = Guid.NewGuid().ToString();
            }

            return new AdminSubscriptionDefinition()
                   {
                       SubscriptionId = this.SubscriptionId,
                       DelegatedProviderSubscriptionId = this.DelegatedProviderSubscriptionId ?? this.DefaultContext.Subscription.Id.ToString(),
                       DisplayName = this.DisplayName,
                       OfferId = this.OfferId,
                       Owner = this.Owner,
                       State = SubscriptionState.Enabled
                   };
        }

        /// <summary>
        /// Performs the API operation(s) against subscriptions as administrator.
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("New-AzureRmManagedSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias New-AzureRmManagedSubscription will be deprecated in a future release. Please use the cmdlet name New-AzsUserSubscription instead");
            }

            if (this.MyInvocation.InvocationName.Equals("New-AzsTenantSubscription", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias New-AzsTenantSubscription will be deprecated in a future release. Please use the cmdlet name New-AzsUserSubscription instead");
            }

            if (ShouldProcess(this.SubscriptionId, VerbsCommon.New))
            {
                using (var client = this.GetAzureStackClient())
                {
                    this.WriteVerbose(Resources.CreatingNewSubscription.FormatArgs(this.OfferId, this.DisplayName));
                    var parameters = new SubscriptionCreateOrUpdateAsAdminParameters(this.GetSubscriptionDefinition());
                    var result = client.TenantSubscriptions.CreateOrUpdate(parameters).Subscription;
                    WriteObject(result);
                }
            }
        }
    }
}
