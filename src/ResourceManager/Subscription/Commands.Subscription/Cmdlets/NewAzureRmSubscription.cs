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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Subscription.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Subscription.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "AzureRmSubscription", SupportsShouldProcess = true), OutputType(typeof(PSAzureSubscription))]
    public class NewAzureRmSubscription : AzureRmLongRunningCmdlet
    {
        private ActiveDirectoryClient _activeDirectoryClient;
        private ISubscriptionClient _subscriptionClient;

        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient == null)
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultContext);
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

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

        [Parameter(Mandatory = true, HelpMessage = "Name of the enrollment account to use when creating the subscription.")]
        public string EnrollmentAccountObjectId { get; set; }

        [Parameter(Mandatory = false, Position = 0, HelpMessage = "Name of the subscription. When not specified, a name will be generated based on the specified offer type.")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Offer type of the subscription.")]
        [PSArgumentCompleter("MS-AZR-0017P", "MS-AZR-0148P")]
        public string OfferType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The user(s) or group object(s) id(s) to be granted Owner access to the subscription.")]
        [Alias("OwnerId", "OwnerPrincipalId")]
        public string[] OwnerObjectId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The user(s) to be granted Owner access to the subscription.")]
        [Alias("OwnerEmail", "OwnerUserPrincipalName")]
        public string[] OwnerSignInName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The app SPN(s) to be granted Owner access to the subscription.")]
        [Alias("OwnerSPN", "OwnerServicePrincipalName")]
        public string[] OwnerApplicationId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(target: this.Name, action: "Create subscription"))
            {
                var owners = this.ResolveObjectIds(this.OwnerObjectId, this.OwnerApplicationId, this.OwnerSignInName).Select(id => new AdPrincipal() { ObjectId = id }).ToArray();

                // Create the subscription.
                var result = this.SubscriptionClient.SubscriptionFactory.CreateSubscriptionInEnrollmentAccount(EnrollmentAccountObjectId, new SubscriptionCreationParameters()
                {
                    DisplayName = this.Name,
                    OfferType = this.OfferType,
                    Owners = owners
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

        private string[] ResolveObjectIds(string[] objectIds, string[] servicePrincipalNames, string[] userPrincipalNames)
        {
            var uniqueObjectIds = new HashSet<Guid>(objectIds?.Select(id => Guid.Parse(id)) ?? new Guid[0]);

            if (servicePrincipalNames != null)
            {
                foreach (string spn in servicePrincipalNames)
                {
                    uniqueObjectIds.Add(ActiveDirectoryClient.GetObjectIdFromSPN(spn));
                }
            }

            if (userPrincipalNames != null)
            {
                foreach (string upn in userPrincipalNames)
                {
                    // TODO: Revert once available: uniqueObjectIds.Add(Guid.Parse(ActiveDirectoryClient.GetObjectIdFromUPN(upn)));
                    uniqueObjectIds.Add(Guid.Parse(GetObjectIdFromUPN(ActiveDirectoryClient, upn)));
                }
            }

            return uniqueObjectIds.Select(id => id.ToString()).ToArray();
        }

        // Temporary until this code has moved into ActiveDirectoryClient.
        private static string GetObjectIdFromUPN(ActiveDirectoryClient activeDirectoryClient, string upn)
        {
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<User>(s => s.UserPrincipalName == upn);
            var user = activeDirectoryClient.GraphClient.Users.List(odataQueryFilter.ToString()).SingleOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format("User with UPN '{0}' does not exist.", upn));
            }

            return user.ObjectId;
        }
    }
}
