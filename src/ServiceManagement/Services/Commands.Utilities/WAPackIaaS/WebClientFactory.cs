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

using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS
{
    /// <summary>
    /// An object that knows how to create SPFWebClients with the appropriate
    /// channel type and subscription.
    /// </summary>
    internal class WebClientFactory
    {
        private readonly Subscription subscription;
        private readonly IRequestChannel channel;

        public WebClientFactory(Subscription subscription, IRequestChannel channel)
        {
            this.subscription = subscription;
            this.channel = channel;
        }

        public WAPackIaaSClient CreateClient(string uriSuffix)
        {
            var client = new WAPackIaaSClient(subscription, channel);
            client.SetUriSuffix(uriSuffix);
            return client;
        }
    }
}
