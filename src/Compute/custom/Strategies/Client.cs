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
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.PowerShell.Cmdlets.Compute;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies;
using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    sealed class Client : IClient
    {
        IAzureContext _context;
        public string SubscriptionId { get; set; }

        public IAzureContext Context => _context;

        public PowerShell.Cmdlets.Compute.Runtime.ISendAsync Sender { get; set; }

        public PowerShell.Cmdlets.Compute.Runtime.IEventListener Listener { get; set; }


        public Client(AzureRMAsyncCmdlet adapter, IAsyncCmdlet cmdlet)
        {
            if (adapter?.SubscriptionId == null || !adapter.TryGetDefaultContext(out _context))
            {
                throw new ApplicationException(Resources.NoSubscriptionInContext);
            }

            SubscriptionId = adapter.SubscriptionId;
            _context = new AzureContext(new AzureSubscription { Id = SubscriptionId }, _context.Account, _context.Environment, _context.Tenant, _context.TokenCache?.CacheData);
            Sender = cmdlet;
            Listener = cmdlet;
        }

        public T GetClient<T>()
            where T : ServiceClient<T>
        {
            var client = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                Context, AzureEnvironment.Endpoint.ResourceManager);
            return client;
        }

        public T GetAutorestClient<T>() where T : class, IClient, new()
        {
            var client = new T();
            client.Sender = Sender;
            client.Listener = Listener;
            client.SubscriptionId = SubscriptionId;
            return client;
        }

    }
}
