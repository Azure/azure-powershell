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

using System;
using System.Management.Automation;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.Internal.Resources;
    using Microsoft.Azure.Management.Internal.Resources.Models;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

    static class Utility
    {
        // TODO (sepancha 12/9/2017) - This is temporary until I can figure out a better way to deal with error handling.
        public static void HandleErrorResponseException(ErrorResponseException ex)
        {
            if (!string.IsNullOrEmpty(ex.Response.Content))
            {
                Dictionary<string, object> content;
                try
                {
                    content = JsonConvert.DeserializeObject<Dictionary<string, object>>(ex.Response.Content);
                }
                catch
                {
                    throw ex;
                }

                if (content.ContainsKey("Message"))
                {
                    throw new CloudException(content["Message"].ToString());
                }

                if (content.ContainsKey("error"))
                {
                    JObject errorResponse = (JObject)content["error"];
                    JToken errorMessage;
                    if (errorResponse.TryGetValue("message", StringComparison.InvariantCultureIgnoreCase, out errorMessage))
                    {
                        throw new CloudException(errorMessage.ToString());
                    }
                }
            }
            else
            {
                throw ex;
            }
        }

        public static void AzureManagementGroupAutoRegisterSubscription(string subcriptionId, IAzureContext context)
        {
            short RetryCount = 10;
            string providerName = "Microsoft.Management";
            try
            {
                var rmclient = new ResourceManagementClient(
                            context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                            AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager))
                {
                    SubscriptionId = subcriptionId
                };
                var provider = rmclient.Providers.Get(providerName);
                if (provider.RegistrationState != RegistrationState.Registered)
                {
                    short retryCount = 0;
                    do
                    {
                        if (retryCount++ > RetryCount)
                        {
                            throw new TimeoutException();
                        }
                        provider = rmclient.Providers.Register(providerName);
                        TestMockSupport.Delay(2000);
                    } while (provider.RegistrationState != RegistrationState.Registered);
                }
            }
            catch (Exception e)
            {
                if (e.Message?.IndexOf("does not have authorization") >= 0 && e.Message?.IndexOf("register/action",
                        StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    throw new CloudException(e.Message);
                }
            }
        }
    }
}
