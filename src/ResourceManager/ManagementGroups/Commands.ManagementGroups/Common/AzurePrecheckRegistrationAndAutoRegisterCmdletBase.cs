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

namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Management.Internal.Resources;

    public abstract class AzurePrecheckRegistrationAndAutoRegisterCmdletBase : AzureManagementGroupsCmdletBase
    {
        protected abstract string ProviderNamespace { get;  }

        protected override void BeginProcessing()
        {
            AzureSession.Instance.ClientFactory.RemoveHandler(typeof(AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler));
            IAzureContext context;
            if (TryGetDefaultContext(out context)
                && context.Account != null
                && context.Subscription != null)
            {
                AzureSession.Instance.ClientFactory.AddHandler(new AzurePrecheckRegistrationAndAutoRegisterDelegatingHandler(
                    this.ProviderNamespace,
                    () =>
                    {
                        var client = new ResourceManagementClient(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager));
                        client.SubscriptionId = context.Subscription.Id;
                        return client;
                    },
                    s => DebugMessages.Enqueue(s)));
            }

            base.BeginProcessing();
        }
    }
}