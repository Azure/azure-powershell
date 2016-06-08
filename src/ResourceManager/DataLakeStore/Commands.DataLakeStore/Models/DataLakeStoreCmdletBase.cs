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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure DataLakeStore Management cmdlets
    /// </summary>
    public abstract class DataLakeStoreCmdletBase : AzureRMCmdlet
    {
        private DataLakeStoreClient dataLakeClient;

        /// <summary>
        /// The filesystem request timeout in minutes, which is used for long running upload/download operations
        /// </summary>
        private const int filesystemRequestTimeoutInMinutes = 5;
        public DataLakeStoreClient DataLakeStoreClient
        {
            get
            {
                if (dataLakeClient == null)
                {
                    dataLakeClient = new DataLakeStoreClient(DefaultProfile.Context);
                }
                return dataLakeClient;
            }

            set { dataLakeClient = value; }
        }

        internal static TClient CreateAdlsClient<TClient>(AzureContext context, AzureEnvironment.Endpoint endpoint, bool parameterizedBaseUri = false) where TClient : ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.NoSubscriptionInContext);
            }

            var creds = AzureSession.AuthenticationFactory.GetServiceClientCredentials(context);
            var clientFactory = AzureSession.ClientFactory;
            var newHandlers = clientFactory.GetCustomHandlers();
            TClient client;
            if (!parameterizedBaseUri)
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    // string.Empty ensures that we hit the constructors that set the assembly version properly
                    ? clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds, string.Empty)
                    : clientFactory.CreateCustomArmClient<TClient>(context.Environment.GetEndpointAsUri(endpoint), creds, string.Empty, clientFactory.GetCustomHandlers());
            }
            else
            {
                client = (newHandlers == null || newHandlers.Length == 0)
                    // string.Empty ensures that we hit the constructors that set the assembly version properly
                    ? clientFactory.CreateCustomArmClient<TClient>(creds, string.Empty, context.Environment.GetEndpoint(endpoint), filesystemRequestTimeoutInMinutes)
                    : clientFactory.CreateCustomArmClient<TClient>(creds, string.Empty, context.Environment.GetEndpoint(endpoint), filesystemRequestTimeoutInMinutes, clientFactory.GetCustomHandlers());
            }

            var subscriptionId = typeof(TClient).GetProperty("SubscriptionId");
            if (subscriptionId != null && context.Subscription != null)
            {
                subscriptionId.SetValue(client, context.Subscription.Id.ToString());
            }

            return client;
        }
    }
}