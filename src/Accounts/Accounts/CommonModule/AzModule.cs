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
using System.Management.Automation;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System.Linq;
using System.Collections.Concurrent;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.Common
{

    using GetEventData = Func<EventArgs>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;
    using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;

    /// <summary>
    /// Cheap and dirty implementation of module functions (does not have to look like this!)
    /// </summary>
    public class AzModule : IDisposable
    {
        ICommandRuntime _runtime;
        IDictionary<string, AzurePSQoSEvent> _telemetryEvents;
        TelemetryProvider _metricHelper;
        AdalLogger _logger;
        ConcurrentQueue<string> _debugMessages;
        ConcurrentQueue<string> _warningMessages;
        public AzModule(ICommandRuntime runtime)
        {
            _runtime = runtime;
            _telemetryEvents = new Dictionary<string, AzurePSQoSEvent>(StringComparer.OrdinalIgnoreCase);
            _warningMessages = new ConcurrentQueue<string>();
            _debugMessages = new ConcurrentQueue<string>();
            _logger = new AdalLogger((message) => _debugMessages.CheckAndEnqueue(message));
            _metricHelper = TelemetryProvider.Create((message) => _warningMessages.CheckAndEnqueue(message), (message) => _debugMessages.CheckAndEnqueue(message));
        }

        /// <summary>
        /// Called when the module is loading. Allows adding HTTP pipeline steps that will always be present.
        /// </summary>
        /// <param name="resourceId"><c>string</c>containing the expected resource id (ie, ARM).</param>
        /// <param name="moduleName"><c>string</c>containing the name of the module being loaded.</param>
        /// <param name="prependStep">a delegate which allows the module to prepend a step in the HTTP Pipeline</param>
        /// <param name="appendStep">a delegate which allows the module to append a step in the HTTP Pipeline</param>
        public void OnModuleLoad(string resourceId, string moduleName, PipelineChangeDelegate prependStep, PipelineChangeDelegate appendStep)
        {
            // this will be called once when the module starts up 
            // the common module can prepend or append steps to the pipeline at this point.
            prependStep(UniqueId.Instance.SendAsync);
        }

        /// <summary>
        /// The cmdlet will call this for every event during the pipeline. 
        /// </summary>
        /// <param name="id">a <c>string</c> containing the name of the event being raised (well-known events are in <see cref="Microsoft.Azure.Commands.Common.Events"/></param>
        /// <param name="cancellationToken">a <c>CancellationToken</c> indicating if this request is being cancelled.</param>
        /// <param name="getEventData">a delegate to call to get the event data for this event</param>
        /// <param name="signal">a delegate to signal an event from the handler to the cmdlet.</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="parameterSetName">The <see cref="string" /> containing the name of the parameter set for this invocation (if available></param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet (if available)</param>
        /// <param name="processRecordId">The <see cref="string" /> containing the correlation id for the individual process record. (if available)</param>
        /// <param name="exception">The <see cref="System.Exception" /> that is being thrown (if available)</param>
        public async Task EventListener(string id, CancellationToken cancellationToken, GetEventData getEventData, SignalDelegate signal, InvocationInfo invocationInfo, string parameterSetName, string correlationId, string processRecordId, System.Exception exception)
        {
            /// Drain the queue of ADAL events whenever an event is fired
            DrainMessages(signal, cancellationToken);
            switch (id)
            {
                case Events.BeforeCall:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData()); // also, we manually use our TypeConverter to return an appropriate type
                        var request = data?.RequestMessage as HttpRequestMessage;
                        if (request != null)
                        {
                            AzurePSQoSEvent qos;
                            if (_telemetryEvents.TryGetValue(processRecordId, out qos))
                            {
                                IEnumerable<string> headers;
                                if (request.Headers != null && request.Headers.TryGetValues("x-ms-client-request-id", out headers))
                                {
                                    qos.ClientRequestId = headers.FirstOrDefault();
                                    await signal(Events.Debug, cancellationToken, 
                                        () => EventHelper.CreateLogEvent($"[{id}]: Amending QosEvent for command '{qos.CommandName}': {qos.ToString()}"));
                                }
                            }

                            /// Print formatted request message
                            await signal(Events.Debug, cancellationToken, 
                                () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(request)));
                        }
                    }

                    break;
                case Events.CmdletProcessRecordAsyncStart:
                    {
                        var qos = CreateQosEvent(invocationInfo, parameterSetName, correlationId);
                        await signal(Events.Debug, cancellationToken, 
                            () => EventHelper.CreateLogEvent($"[{id}]: Created new QosEvent for command '{qos.CommandName}': {qos.ToString()}"));
                        _telemetryEvents.Add(processRecordId, qos);
                    }
                    break;
                case Events.CmdletProcessRecordAsyncEnd:
                    {
                        AzurePSQoSEvent qos;
                        if (_telemetryEvents.TryGetValue(processRecordId, out qos))
                        {
                            qos.IsSuccess = qos.Exception == null;
                            await signal(Events.Debug, cancellationToken, 
                                () => EventHelper.CreateLogEvent($"[{id}]: Sending new QosEvent for command '{qos.CommandName}': {qos.ToString()}"));
                            _metricHelper.LogEvent(qos);
                            _telemetryEvents.Remove(processRecordId);
                        }
                    }
                    break;
                case Events.CmdletException:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        await signal(Events.Debug, cancellationToken, 
                            () => EventHelper.CreateLogEvent($"[{id}]: Received Exception with message '{data?.Message}'"));
                        AzurePSQoSEvent qos;
                        if (_telemetryEvents.TryGetValue(processRecordId, out qos))
                        {
                            await signal(Events.Debug, cancellationToken, 
                                () => EventHelper.CreateLogEvent($"[{id}]: Sending new QosEvent for command '{qos.CommandName}': {qos.ToString()}"));
                            qos.IsSuccess = false;
                            qos.Exception = exception;
                            _metricHelper.LogEvent(qos);
                            _telemetryEvents.Remove(processRecordId);
                        }
                    }

                    break;
                case Events.ResponseCreated:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        var response = data?.ResponseMessage as HttpResponseMessage;
                        if (response != null)
                        {
                            AzurePSQoSEvent qos;
                            if (_telemetryEvents.TryGetValue(processRecordId, out qos))
                            {
                                qos.ClientRequestId = response?.Headers?.GetValues("x-ms-request-id").FirstOrDefault();
                            }

                            /// Print formatted response message
                            await signal(Events.Debug, cancellationToken, 
                                () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(response)));
                        }
                    }

                    break;
                default:
                    getEventData.Print(signal, cancellationToken, Events.Information, id);
                    break;
            }
        }

        /// <summary>
        /// Free resources associated with this instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Free resources associated with this instance - allows customization in inheriting types
        /// </summary>
        /// <param name="disposing">True if the data should be disposed - differentiates from IDisposable call</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_telemetryEvents != null)
                {
                    _telemetryEvents.Clear();
                    _telemetryEvents = null;
                }

                if (_logger != null)
                {
                    _logger.Dispose();
                    _logger = null;
                }

                if (_warningMessages != null)
                {
                    string message;
                    while (_warningMessages.TryDequeue(out message)) ;
                    _warningMessages = null;
                }

                if (_debugMessages != null)
                {
                    string message;
                    while (_debugMessages.TryDequeue(out message)) ;
                    _debugMessages = null;
                }
            }
        }

        private AzurePSQoSEvent CreateQosEvent(InvocationInfo invocationInfo, string parameterSetName, string correlationId)
        {
            return new AzurePSQoSEvent
            {
                CommandName = invocationInfo.MyCommand.Name,
                ModuleName = invocationInfo.MyCommand.ModuleName,
                ModuleVersion = invocationInfo.MyCommand.Module.Version.ToString(),
                Parameters = string.Join(",", invocationInfo?.BoundParameters?.Keys?.ToArray()),
                SessionId = correlationId,
                ParameterSetName = parameterSetName,
                InvocationName = invocationInfo.InvocationName,
                InputFromPipeline = invocationInfo.PipelineLength > 0,
            };
        }

        private async void DrainMessages(SignalDelegate signal, CancellationToken token)
        {
            string message;
            while (_warningMessages.TryDequeue(out message) && !token.IsCancellationRequested)
            {
                await signal(Events.Warning, token, () => EventHelper.CreateLogEvent(message));
            }

            while (_debugMessages.TryDequeue(out message) && !token.IsCancellationRequested)
            {
                await signal(Events.Debug, token, () => EventHelper.CreateLogEvent(message));
            }

        }
    }

}
