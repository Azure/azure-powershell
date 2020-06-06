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

using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Subscription.Models;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;

namespace Microsoft.Azure.Commands.Subscription.Cmdlets
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ModernSubscription", SupportsShouldProcess = true), OutputType(typeof(PSAzureSubscription))]
    public class NewAzureRmModernSubscription : AzureRmLongRunningCmdlet
    {
        private ISubscriptionClient _subscriptionClient;

        /// <summary>
        /// Gets or sets the subscription client.
        /// </summary>
        public ISubscriptionClient SubscriptionClient
        {
            get
            {
                return _subscriptionClient ??
                       (_subscriptionClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<SubscriptionClient>(DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _subscriptionClient = value; }
        }

        [Parameter(Mandatory = true, HelpMessage = "Name of the billing account to use when creating the subscription.")]
        public string BillingAccountId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the billing profile to use when creating the subscription.")]
        public string BillingProfileId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the invoice section to use when creating the subscription.")]
        public string InvoiceSectionId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the subscription.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Management Group Id.")]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "SkuId of the subscription.")]
        [PSArgumentCompleter("0001", "0002")]
        public string SkuId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The user or group object id to be granted Owner access to the subscription.")]
        public string OwnerObjectId { get; set; }


        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(target: this.Name, action: "Create Modern subscription"))
            {
                var owners = new AdPrincipal() { ObjectId = OwnerObjectId };

                // Create the subscription.
                var result = this.SubscriptionClient.Subscription.CreateSubscription(BillingAccountId, BillingProfileId, InvoiceSectionId, new ModernSubscriptionCreationParameters()
                {
                    DisplayName = this.Name,
                    SkuId = this.SkuId,
                    ManagementGroupId = this.ManagementGroupId,
                    Owner = owners
                });

                // Write output.
                var createdSubscription = new AzureSubscription()
                {
                    // SubscriptionLink format is: "/subscriptions/{subscriptionid}"
                    Id = result.SubscriptionLink.Split('/')[2],
                    Name = this.Name,
                    // By definition, a new subscription is always in the enabled state.
                    State = "Enabled",
                };
                createdSubscription.SetTenant(DefaultContext.Tenant.Id);
                WriteObject(new PSAzureSubscription(createdSubscription));
            }
        }
    }
}
