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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Common
{
    using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;
    using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;
    using TokenAudienceConverterDelegate = Func<IAzureEnvironment, IAzureEnvironment, Uri, string>;

    /// <summary>
    /// Perform authentication and parameter completion based on the value of the context
    /// </summary>
    internal class ContextAdapter
    {
        private readonly IProfileProvider _provider = AzureRmProfileProvider.Instance;
        private readonly IAuthenticationFactory _authenticator = AzureSession.Instance.AuthenticationFactory;

        internal static ContextAdapter Instance => new ContextAdapter();

        /// <summary>
        /// The name of the selected profile
        /// </summary>
        internal string SelectedProfile
        {
            get => _provider.Profile?.DefaultContext?.VersionProfile ?? string.Empty;
            set
            {
                if (_provider.Profile?.DefaultContext != null)
                {
                    _provider.Profile.DefaultContext.VersionProfile = value;
                }
            }
        }

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
        public void OnNewRequest(InvocationInfo invocationInfo, string correlationId, string processRecordId, PipelineChangeDelegate prependStep, PipelineChangeDelegate appendStep)
        {
            appendStep(new UserAgent(invocationInfo).SendAsync);
            appendStep(this.SendHandler(GetDefaultContext(_provider, invocationInfo), AzureEnvironment.Endpoint.ResourceManager));
        }

        internal void AddRequestUserAgentHandler(
            InvocationInfo invocationInfo,
            string correlationId,
            string processRecordId,
            PipelineChangeDelegate prependStep,
            PipelineChangeDelegate appendStep)
        {
            appendStep(new UserAgent(invocationInfo).SendAsync);
        }

        internal void AddPatchRequestUriHandler(
            InvocationInfo invocationInfo,
            string correlationId,
            string processRecordId,
            PipelineChangeDelegate prependStep,
            PipelineChangeDelegate appendStep)
        {
            appendStep(
                async (request, cancelToken, cancelAction, signal, next) =>
                {
                    var context = GetDefaultContext(_provider, invocationInfo);
                    PatchRequestUri(context, request);
                    return await next(request, cancelToken, cancelAction, signal);
                });
        }

        internal void AddAuthorizeRequestHandler(
            InvocationInfo invocationInfo,
            string resourceId,
            PipelineChangeDelegate prependStep,
            PipelineChangeDelegate appendStep,
            TokenAudienceConverterDelegate tokenAudienceConverter,
            IDictionary<string, object> extensibleParameters = null)
        {
            appendStep(
                async (request, cancelToken, cancelAction, signal, next) =>
                {
                    resourceId = resourceId ?? AzureEnvironment.Endpoint.ResourceManager;
                    var context = GetDefaultContext(_provider, invocationInfo);
                    await AuthorizeRequest(context, resourceId, request, cancelToken);
                    return await next(request, cancelToken, cancelAction, signal);
                });
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
        public string[] CompleteArgument(string completerName, InvocationInfo invocationInfo, string correlationId, string[] resourceTypes, string[] parentResourceParameterNames)
        {
            var defaultValue = new string[0];
            switch (completerName)
            {
                case "Resource":
                    {
                        var resourceType = resourceTypes?.FirstOrDefault();
                        string[] parentResources = ResolveParameterValues<string>(parentResourceParameterNames, invocationInfo);
                        if (string.IsNullOrWhiteSpace(resourceType) || parentResources == null || parentResources.Length < 1)
                        {
                            return defaultValue;
                        }

                        return ResourceNameCompleterAttribute.FindResources(resourceType, parentResourceParameterNames);
                    }
                case "ResourceGroup":
                    {
                        return ResourceGroupCompleterAttribute.GetResourceGroups();
                    }
                case "ResourceId":
                    {
                        var resourceType = resourceTypes?.FirstOrDefault();
                        if (string.IsNullOrWhiteSpace(resourceType))
                        {
                            return defaultValue;
                        }

                        return ResourceIdCompleterAttribute.GetResourceIds(resourceType).ToArray();
                    }
                case "Location":
                    return LocationCompleterAttribute.FindLocations(resourceTypes);
                default:
                   return defaultValue;
            }
        }

        /// <summary>
        /// The cmdlet will call this when it is trying to fill in a parameter value that it needs
        /// </summary>
        /// <param name="resourceId"><c>string</c>containing the expected resource id (ie, ARM).</param>
        /// <param name="moduleName"><c>string</c>containing the name of the module being loaded.</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet</param>
        /// <param name="name">The <see cref="string" /> parameter name being asked for</param>
        public object GetParameterValue(string resourceId, string moduleName, InvocationInfo invocationInfo, string correlationId, string name)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        internal Func<HttpRequestMessage, CancellationToken, Action, SignalDelegate, NextDelegate, Task<HttpResponseMessage>> SendHandler(IAzureContext context, string resourceId)
        {
            return async (request, cancelToken, cancelAction, signal, next) =>
            {
                PatchRequestUri(context, request);
                await AuthorizeRequest(context, resourceId, request, cancelToken);
                return await next(request, cancelToken, cancelAction, signal);
            };
        }

        /// <summary>
        /// Pipeline step for authenticating requests
        /// </summary>
        /// <param name="context"></param>
        /// <param name="resourceId"></param>
        /// <param name="request"></param>
        /// <param name="outerToken"></param>
        /// <returns></returns>
        internal async Task AuthorizeRequest(IAzureContext context, string resourceId, HttpRequestMessage request, CancellationToken outerToken, 
                        TokenAudienceConverterDelegate tokenAudienceConverter = null, IDictionary<string, object> extensibleParamters = null)
        {
            if (context == null || context.Account == null || context.Environment == null)
            {
                throw new InvalidOperationException(Resources.InvalidAzureContext);
            }

            await Task.Run(() =>
            {
                if (tokenAudienceConverter != null)
                {
                    var tokenAudience = tokenAudienceConverter.Invoke(context.Environment, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], request.RequestUri);
                    resourceId = tokenAudience ?? resourceId;
                }
                else
                {
                    resourceId = context?.Environment?.GetAudienceFromRequestUri(request.RequestUri) ?? resourceId;
                }
                var authToken = _authenticator.Authenticate(context.Account, context.Environment, context.Tenant.Id, null, "Never", null, resourceId);
                authToken.AuthorizeRequest((type, token) => request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(type, token));
            }, outerToken);
        }

        internal void PatchRequestUri(IAzureContext context, HttpRequestMessage request)
        {
            var requestUri = context?.Environment?.GetUriFromBaseRequestUri(request.RequestUri);
            request.RequestUri = requestUri ?? request.RequestUri;
        }

        /// <summary>
        /// Gets the currently selected profile from the context
        /// </summary>
        /// <returns>The name of the selected profile</returns>
        internal string GetSelectedProfile()
        {
            // TODO: Implement profile support into the context and return it here.
            return _provider?.Profile?.DefaultContext?.VersionProfile ?? string.Empty;
        }

        private static IAzureContext GetDefaultContext(IProfileProvider provider, InvocationInfo invocationInfo)
        {
            IAzureContextContainer profile;
            var contextConverter = new AzureContextConverter();
            if (invocationInfo.BoundParameters.ContainsKey("DefaultContext")
                && contextConverter.CanConvertFrom(invocationInfo.BoundParameters["DefaultContext"], typeof(IAzureContextContainer)))
            {
                profile = contextConverter.ConvertFrom(invocationInfo.BoundParameters["DefaultContext"], typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true) as IAzureContextContainer;
            }
            else
            {
                profile = provider.Profile;
            }

            return profile?.DefaultContext;
        }

        private static Uri GetDefaultEndpoint(IAzureContext context, string endpointName = AzureEnvironment.Endpoint.ResourceManager)
        {
            var environment = context?.Environment ?? AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud];
            return environment.GetEndpointAsUri(endpointName);
        }

        /// <summary>
        /// Resolve an array of parameter names into their bound parameter values
        /// </summary>
        /// <param name="parameterNames">The set of parameter names to resolve</param>
        /// <param name="info">The invocation information for the cmdlet</param>
        /// <returns>Resolved parameter names if all parameters could be matched. Otherwise an empty array</returns>
        private static T[] ResolveParameterValues<T>(string[] parameterNames, InvocationInfo info) where T:  class
        {
            var outputList = new List<T>();
            foreach( var parameter in parameterNames)
            {
                if (!info.BoundParameters.ContainsKey(parameter))
                {
                    return new T[0];
                }

                var parameterValue = info.BoundParameters[parameter] as T;
                if (null == parameterValue)
                {
                    return new T[0];
                }

                outputList.Add(parameterValue);
            }

            return outputList.ToArray();
        }
    }

}
