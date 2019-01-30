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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.Profile.Models;
using System.Globalization;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Common
{

    using GetEventData = Func<EventArgs>;
    using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;
    using EventListenerDelegate = Func<string, CancellationToken, Func<EventArgs>, Func<string, CancellationToken, Func<EventArgs>, Task>, Task>;
    using GetParameterDelegate = Func<string, string, Dictionary<string, object>, string, object>;
    using SendAsyncStepDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>;
    using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;
    using ModuleLoadPipelineDelegate = Action<string, string, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;
    using NewRequestPipelineDelegate = Action<Dictionary<string, object>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;


    /// <summary>
    /// The Virtual Call table of the functions to be exported to the generated module
    /// </summary>
    public class VTable
    {
        public GetParameterDelegate GetParameterValue;
        public EventListenerDelegate EventListener;
        public ModuleLoadPipelineDelegate OnModuleLoad;
        public NewRequestPipelineDelegate OnNewRequest;
    }

    public class UniqueId
    {
        private static UniqueId _instance;
        public static UniqueId Instance => UniqueId._instance ?? (UniqueId._instance = new UniqueId());

        private int count;

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token, Action cancel, SignalDelegate signal, NextDelegate next)
        {
            // add a header...
            request.Headers.Add("x-ms-unique-id", Interlocked.Increment(ref this.count).ToString());

            // continue with pipeline.
            return next(request, token, cancel, signal);
        }
    }

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

    internal static class EventHelper
    {
        public static EventData CreateLogEvent(string message)
        {
            return new EventData
            {
                Id = Guid.NewGuid().ToString(),
                Message = message

            };
        }

        public static async void Print( this GetEventData getEventData, SignalDelegate signal, CancellationToken token, string streamName, string eventName)
        {
            var eventDisplayName = SplitPascalCase(eventName).ToUpperInvariant();
            var data = EventDataConverter.ConvertFrom(getEventData()); // also, we manually use our TypeConverter to return an appropriate type
            if (data.Id != "Verbose" && data.Id != "Warning" && data.Id != "Debug" && data.Id != "Information" && data.Id != "Error")
            {
                await signal(streamName, token, () => EventHelper.CreateLogEvent($"{eventDisplayName} The contents are '{data?.Id}' and '{data?.Message}'"));
                if (data != null)
                {
                    await signal(streamName, token, () => EventHelper.CreateLogEvent($"{eventDisplayName} Parameter: '{data.Parameter}'\n{eventDisplayName} RequestMessage '{data.RequestMessage}'\n{eventDisplayName} Response: '{data.ResponseMessage}'\n{eventDisplayName} Value: '{data.Value}'"));
                    await signal(streamName, token, () => EventHelper.CreateLogEvent($"{eventDisplayName} ExtendedData Type: '{data.ExtendedData?.GetType()}'\n{eventDisplayName} ExtendedData '{data.ExtendedData}'"));
                }
            }
        }

        static string SplitPascalCase(string word)
        {
            var regex = new Regex("([a-z]+)([A-Z])");
            var output = regex.Replace(word, "$1 $2");
            regex = new Regex("([A-Z])([A-Z][a-z])");
            return regex.Replace(output, "$1 $2");
        }
    }

    internal static class PSModuleExtensions
    {
        internal static Module GetModule(this PSCmdlet cmdlet)
        {
            return new Module(cmdlet.CommandRuntime);
        }
    }
    /// <summary>
    /// Cheap and dirty implementation of module functions (does not have to look like this!)
    /// </summary>
    public class Module
    {
        ICommandRuntime _runtime;
        public Module(ICommandRuntime runtime)
        {
            _runtime = runtime;
        }

        public void OnModuleLoad(string resourceId, string moduleName, PipelineChangeDelegate prependStep, PipelineChangeDelegate appendStep)
        {
            // this will be called once when the module starts up 
            // the common module can prepend or append steps to the pipeline at this point.
            prependStep(UniqueId.Instance.SendAsync);

            // appendStep( RetryHandler.SendAsync );
        }

        public async Task EventListener(string id, CancellationToken token, GetEventData getEventData, SignalDelegate signal)
        {
            switch (id)
            {
                case Events.CmdletException:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        await signal("Warning", token, () => EventHelper.CreateLogEvent($"Received Exception with message '{data?.Message}'"));
                    }

                    break;

                case Events.BeforeCall:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData()); // also, we manually use our TypeConverter to return an appropriate type
                        await signal("Debug", token, () => EventHelper.CreateLogEvent($"BEFORE CALL The contents are '{data?.Id}' and '{data?.Message}'"));
                        var request = data?.RequestMessage as HttpRequestMessage;
                        if (request != null)
                        {
                            // alias/casting the request message to an HttpRequestMessage is necessary so that we can 
                            // support other protocols later on. (ie, JSONRPC, MQTT, GRPC ,AMPQ, Etc..)

                            // at this point, we can do with the request  
                            request.Headers.Add("x-ms-peekaboo", "true");
                            await signal("Debug", token, () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(request)));
                        }
                    }
                    break;

                case Events.ResponseCreated:
                    {
                        // once we're sure we're handling the event, then we can retrieve the event data. 
                        // (this ensures that we're not doing any of the work unless we really care about the event. )
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        await signal("Debug", token, () => EventHelper.CreateLogEvent($"RESPONSE CREATED The contents are '{data?.Id}' and '{data?.Message}'"));
                        var response = data?.ResponseMessage as HttpResponseMessage;
                        if (response != null)
                        {
                            await signal("Debug", token, () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(response)));
                        }
                    }
                    break;

                default:
                    // By default, just print out event details
                    getEventData.Print(signal, token, "Verbose", id);
                    break;
            }
        }
    }


    [Cmdlet(VerbsLifecycle.Register, @"AzModule")]
    public class RegisterAzModule : System.Management.Automation.PSCmdlet
    {

        protected override void ProcessRecord()
        {
            try
            {
                var module = this.GetModule();
                WriteObject(new VTable
                {
                    // this gets called when the generated cmdlet needs a value
                    GetParameterValue = ContextAdapter.Instance.GetParameterValue,

                    // this gets called for every event that is signaled
                    EventListener = module.EventListener,

                    // this gets called at module load time (allows you to change the http pipeline)
                    OnModuleLoad = module.OnModuleLoad,

                    // this gets called before the generated cmdlet makes a call across the wire (allows you to change the HTTP pipeline)
                    OnNewRequest = ContextAdapter.Instance.OnNewRequest
                });
            }
            catch (Exception exception)
            {
                // Write exception out to error channel.
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.CloseError, null));
            }
        }
    }

}
