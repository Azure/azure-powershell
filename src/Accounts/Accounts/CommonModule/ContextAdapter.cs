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

        /// <summary>
        /// Implementation of the OnNewRequest Event
        ///  
        /// The cmdlet will call this when a new request is being created.
        /// </summary>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet (if available)</param>
        /// <param name="processRecordId">The <see cref="string" /> containing the correlation id for the individual process record. (if available)</param>
        /// <param name="prependStep">a delegate which allows the module to prepend a step in the HTTP Pipeline</param>
        /// <param name="appendStep">a delegate which allows the module to append a step in the HTTP Pipeline</param>
        public void OnNewRequest(System.Management.Automation.InvocationInfo invocationInfo, string correlationId, string processRecordId, PipelineChangeDelegate prependStep, PipelineChangeDelegate appendStep)
        {
            appendStep(this.SendHandler(GetDefaultContext(_provider, invocationInfo), AzureEnvironment.Endpoint.ResourceManager));
        }

        /// <summary>
        ///  Called for well-known parameters that require argument completers
        ///  </summary>
        /// <param name="completerName">string - the type of completer requested (Resource, Location)</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet (if available)</param>
        /// <param name="resourceTypes">An <see cref="System.String[]"/> containing resource (or resource types) being completed  </param >
        /// <param name="parentResourceParameterNames"> An <see cref="System.String[]"/> containing list of parent resource parameter names (if applicable)</param >
        /// <returns>A <see cref="System.String[]"/> containing the valid options for the completer.</returns>
        public string[] CompleteArgument(string completerName, System.Management.Automation.InvocationInfo invocationInfo, string correlationId, string[] resourceTypes, string[] parentResourceParameterNames)
        {
            return new string[] { "" };
        }

        /// <summary>
        /// The cmdlet will call this when it is trying to fill in a parameter value that it needs
        /// </summary>
        /// <param name="resourceId"><c>string</c>containing the expected resource id (ie, ARM).</param>
        /// <param name="moduleName"><c>string</c>containing the name of the module being loaded.</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet</param>
        /// <param name="name">The <see cref="string" /> parameter name being asked for</param>
        public object GetParameterValue(string resourceId, string moduleName, System.Management.Automation.InvocationInfo invocationInfo, string correlationId, string name)
        {
            var defaultContext = GetDefaultContext(_provider, invocationInfo);
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

        static IAzureContext GetDefaultContext(IProfileProvider provider, System.Management.Automation.InvocationInfo invocationInfo)
        {
            IAzureContextContainer context;
            var contextConverter = new AzureContextConverter();
            if (invocationInfo.BoundParameters.ContainsKey("DefaultContext")
                && contextConverter.CanConvertFrom(invocationInfo.BoundParameters["DefaultContext"], typeof(IAzureContextContainer)))
            {
                context = contextConverter.ConvertFrom(invocationInfo.BoundParameters["DefaultContext"], typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true) as IAzureContextContainer;
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

        /// <summary>
        /// Gets the currently selected profile from the context
        /// </summary>
        /// <returns>The name of the selected profile</returns>
        internal string GetSelectedProfile()
        {
            // TODO: Implement profile support into the context and return it here.
            return String.Empty;
        }
    }

}
