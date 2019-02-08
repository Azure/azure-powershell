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
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Profile.Models;
using System.Globalization;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.Common
{
  using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
  using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;
  using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;

  internal class ContextAdapter
    {
        IProfileProvider _provider = AzureRmProfileProvider.Instance;
        IAuthenticationFactory _authenticator = AzureSession.Instance.AuthenticationFactory;

        internal static ContextAdapter Instance => new ContextAdapter();

        public void OnNewRequest(Dictionary<string, object> boundParameters, PipelineChangeDelegate prependStep, PipelineChangeDelegate appendStep)
        {
            appendStep(this.SendHandler(GetDefaultContext(_provider, boundParameters), AzureEnvironment.Endpoint.ResourceManager));
        }

        public object GetParameterValue(string resourceId, string moduleName, Dictionary<string, object> boundParameters, string name)
        {
            var defaultContext = GetDefaultContext(_provider, boundParameters);
            var endpoint = GetDefaultEndpoint(defaultContext, AzureEnvironment.Endpoint.ResourceManager);
            switch (name)
            {
                case "subscriptionId":
                    return defaultContext?.Subscription?.Id;
                case "host":
                    return endpoint?.Host;
                case "port":
                    return endpoint?.Port;
            }

            return string.Empty;
        }

        static IAzureContext GetDefaultContext(IProfileProvider provider, Dictionary<string, object> boundParameters)
        {
            IAzureContextContainer context;
            var contextConverter = new AzureContextConverter();
            if (boundParameters.ContainsKey("DefaultContext")
                && contextConverter.CanConvertFrom(boundParameters["DefaultContext"], typeof(IAzureContextContainer)))
            {
                context = contextConverter.ConvertFrom(boundParameters["DefaultContext"], typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true) as IAzureContextContainer;
            }
            else
            {
                context = provider.Profile;
            }

            return context?.DefaultContext;
        }

        static Uri GetDefaultEndpoint(IAzureContext context, string endpointName = AzureEnvironment.Endpoint.ResourceManager)
        {
            var environment = context?.Environment ?? AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            return environment.GetEndpointAsUri(endpointName);
        }

        internal Func<HttpRequestMessage, CancellationToken, Action, SignalDelegate, NextDelegate, Task<HttpResponseMessage>> SendHandler(IAzureContext context, string resourceId)
        {
            return async (request, cancelToken, cancelAction, signal, next) =>
            {
                await AuthorizeRequest(context, resourceId, request, cancelToken);
                return await next(request, cancelToken, cancelAction, signal);
            };
        }

        internal async Task AuthorizeRequest(IAzureContext context, string resourceId, HttpRequestMessage request, CancellationToken outerToken)
        {
            await Task.Run(() =>
            {
                var authToken = _authenticator.Authenticate(context.Account, context.Environment, context.Tenant.Id, null, "Never", null, resourceId);
                authToken.AuthorizeRequest((type, token) => request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(type, token));
            }, outerToken);
        }
    }

}
