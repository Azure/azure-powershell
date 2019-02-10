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

namespace Microsoft.Azure.Commands.Common
{

    using GetEventData = Func<EventArgs>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;
    using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;

    /// <summary>
    /// Cheap and dirty implementation of module functions (does not have to look like this!)
    /// </summary>
    public class AzModule
    {
        ICommandRuntime _runtime;
        public AzModule(ICommandRuntime runtime)
        {
            _runtime = runtime;
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

            // appendStep( RetryHandler.SendAsync );
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
        public async Task EventListener(string id, CancellationToken cancellationToken, GetEventData getEventData, SignalDelegate signal, System.Management.Automation.InvocationInfo invocationInfo, string parameterSetName, string correlationId, string processRecordId, System.Exception exception)
        {
            switch (id)
            {
                case Events.CmdletException:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        await signal("Warning", cancellationToken, () => EventHelper.CreateLogEvent($"Received Exception with message '{data?.Message}'"));
                    }

                    break;

                case Events.BeforeCall:
                    {
                        var data = EventDataConverter.ConvertFrom(getEventData()); // also, we manually use our TypeConverter to return an appropriate type
                        await signal("Debug", cancellationToken, () => EventHelper.CreateLogEvent($"BEFORE CALL The contents are '{data?.Id}' and '{data?.Message}'"));
                        var request = data?.RequestMessage as HttpRequestMessage;
                        if (request != null)
                        {
                            // alias/casting the request message to an HttpRequestMessage is necessary so that we can 
                            // support other protocols later on. (ie, JSONRPC, MQTT, GRPC ,AMPQ, Etc..)

                            // at this point, we can do with the request  
                            request.Headers.Add("x-ms-peekaboo", "true");
                            await signal("Debug", cancellationToken, () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(request)));
                        }
                    }
                    break;

                case Events.ResponseCreated:
                    {
                        // once we're sure we're handling the event, then we can retrieve the event data. 
                        // (this ensures that we're not doing any of the work unless we really care about the event. )
                        var data = EventDataConverter.ConvertFrom(getEventData());
                        await signal("Debug", cancellationToken, () => EventHelper.CreateLogEvent($"RESPONSE CREATED The contents are '{data?.Id}' and '{data?.Message}'"));
                        var response = data?.ResponseMessage as HttpResponseMessage;
                        if (response != null)
                        {
                            await signal("Debug", cancellationToken, () => EventHelper.CreateLogEvent(GeneralUtilities.GetLog(response)));
                        }
                    }
                    break;

                default:
                    // By default, just print out event details
                    getEventData.Print(signal, cancellationToken, "Verbose", id);
                    break;
            }
        }
    }

}
