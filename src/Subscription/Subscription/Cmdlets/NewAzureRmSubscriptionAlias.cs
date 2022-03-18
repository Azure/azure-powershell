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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SubscriptionAlias", SupportsShouldProcess =
         true), OutputType(typeof(PSAzureSubscription))]
    public class NewAzureRmSubscriptionAlias : AzureRmLongRunningCmdlet
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

        [Parameter(Mandatory = true, HelpMessage = "Alias for the subscription")]
        public string AliasName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Billing Scope")]
        public string BillingScope { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Type of Workload")]
        [PSArgumentCompleter("Production", "DevTest")]
        public string Workload { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the subscription")]
        public string SubscriptionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Reseller Id")]
        public string ResellerId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Existing Subscription Id")]
        public string SubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(target: this.AliasName, action: "New subscription Alias"))
            {
                SubscriptionAliasResponse result = new SubscriptionAliasResponse();

                // Create the subscription.
                result = this.SubscriptionClient.Alias.Create(
                    AliasName, new PutAliasRequest()
                    {
                        Properties = new PutAliasRequestProperties()
                        {
                            BillingScope = BillingScope,
                            Workload = Workload,
                            DisplayName = SubscriptionName,
                            SubscriptionId = SubscriptionId,
                            ResellerId = ResellerId       
                        }
                    });
              
                WriteObject(result);
            }
        }
    }
}
