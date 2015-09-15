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

using System;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Security;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Get, "AzureRMSubscription"), OutputType(typeof(AzureSubscription))]
    public class GetAzureRMSubscriptionCommand : AzureRMCmdlet
    {
        protected override void ProcessRecord()
        {
            var subscriptionClient = AzureSession.ClientFactory.CreateClient<SubscriptionClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
            var subscriptions = subscriptionClient.Subscriptions.List();
            WriteObject(subscriptions.Subscriptions.Select((s) =>
            {
                var subscription = new AzureSubscription();
                subscription.Account = DefaultContext.Account != null? DefaultContext.Account.Id : null;
                subscription.Environment = DefaultContext.Environment != null? DefaultContext.Environment.Name : EnvironmentName.AzureCloud;
                subscription.Id = new Guid(s.SubscriptionId);
                subscription.Name = s.DisplayName;
                subscription.SetProperty(AzureSubscription.Property.Tenants,
                    DefaultContext.Tenant.Id.ToString());
                return subscription;
            }));
        }
    }
}
