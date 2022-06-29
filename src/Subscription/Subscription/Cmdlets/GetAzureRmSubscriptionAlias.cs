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
using Microsoft.Azure.Commands.Subscription.Models;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;

namespace Microsoft.Azure.Commands.Subscription.Cmdlets
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SubscriptionAlias", SupportsShouldProcess =
         true), OutputType(typeof(PSAzureSubscription))]
    public class GetAzureRmSubscriptionAlias : AzureRmLongRunningCmdlet
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

        [Parameter(Mandatory = false, HelpMessage = "Alias for the subscription")]
        public string AliasName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(target: this.AliasName, action: "Get subscription Alias"))
            {
                if (AliasName != null)
                {
                    SubscriptionAliasResponse result = new SubscriptionAliasResponse();

                    result = this.SubscriptionClient.Alias.Get(AliasName);

                    WriteObject(result);
                }
                else
                {
                    SubscriptionAliasListResult result = new SubscriptionAliasListResult();

                    result = this.SubscriptionClient.Alias.List();

                    WriteObject(result);
                }
            }
        }
    }
}
