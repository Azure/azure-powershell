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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Subscription;
using System;
using System.Linq;
using System.Management.Automation;
using System.Threading;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.New, "AzureRmSubscription"),
        OutputType(typeof(PSAzureSubscription))]
    public class NewAzureRMSubscriptionCommand : AzureRmLongRunningCmdlet
    {
        private RMProfileClient _client;
        private ISubscriptionClient _subscriptionClient;

        /// <summary>
        /// Gets or sets the subscription management client.
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

        [Parameter(ParameterSetName = "Project", Mandatory = true, HelpMessage = "The commercial subscription in which to create the subscription.")]
        public string CommercialSubscriptionId { get; set; }

        [Parameter(ParameterSetName = "Account", Mandatory = true, HelpMessage = "The account in which to create the subscription.")]
        public string AccountUserPrincipalName { get; set; }

        [Parameter(ParameterSetName = "Account", Mandatory = true, HelpMessage = "The subscription's offer type.")]
        [PSArgumentCompleter("MS-AZR-0017P", "MS-AZR-0148P")]
        public string OfferType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the subscription.")]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            var profile = DefaultProfile as AzureRmProfile;
            if (profile == null)
            {
                throw new InvalidOperationException(Resources.RmProfileNull);
            }

            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }

            _client = new RMProfileClient(profile);
            _client.WarningLog = (s) => WriteWarning(s);
        }

        public override void ExecuteCmdlet()
        {
            // Simulate subscription creation delay.
            Thread.Sleep(2000);

            var tenant = string.Empty;
            var subscriptions = _client.ListSubscriptions(tenant);
            var sub = subscriptions.Select((s) => new PSAzureSubscription(s)).First();
            sub.Name = Name ?? OfferType ?? "ACE - 17G";
            sub.Id = Guid.NewGuid().ToString();
            WriteObject(sub);
        }
    }
}
