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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseCmdletBase : AzureRMCmdlet
    {
        internal static TClient CreateSynapseClient<TClient>(IAzureContext context, string endpoint, bool parameterizedBaseUri = false) where TClient : ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.NoSubscriptionInContext);
            }

            var creds = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, endpoint);
            var clientFactory = AzureSession.Instance.ClientFactory;
            var newHandlers = clientFactory.GetCustomHandlers();
            TClient client;
            if (!parameterizedBaseUri)
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    ? clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds)
                    : clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds, clientFactory.GetCustomHandlers());
            }
            else
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    ? clientFactory.CreateCustomArmClient<TClient>(creds)
                    : clientFactory.CreateCustomArmClient<TClient>(creds, clientFactory.GetCustomHandlers());
            }

            var subscriptionId = typeof(TClient).GetProperty("SubscriptionId");
            if (subscriptionId != null && context.Subscription != null)
            {
                subscriptionId.SetValue(client, context.Subscription.Id.ToString());
            }

            return client;
        }

        /// <summary>
        /// Write log in debug mode
        /// </summary>
        /// <param name="msg">Debug log</param>
        internal void WriteDebugLog(string msg)
        {
            WriteDebugWithTimestamp(msg);
        }
    }
}