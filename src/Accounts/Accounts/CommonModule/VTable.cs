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

namespace Microsoft.Azure.Commands.Common
{
    using EventListenerDelegate = Func<string, CancellationToken, Func<EventArgs>, Func<string, CancellationToken, Func<EventArgs>, Task>, System.Management.Automation.InvocationInfo, string, string, string, System.Exception, Task>;
    using GetParameterDelegate = Func<string, string, System.Management.Automation.InvocationInfo, string, string, object>;
    using ModuleLoadPipelineDelegate = Action<string, string, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;
    using NewRequestPipelineDelegate = Action<System.Management.Automation.InvocationInfo, string, string, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;
    using ArgumentCompleterDelegate = Func<string, System.Management.Automation.InvocationInfo, string, string[], string[], string[]>;
    using AuthorizeRequestDelegate = global::System.Action<System.Management.Automation.InvocationInfo,
                                        string,
                                        string,
                                        global::System.Action<global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>>,
                                        global::System.Action<global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Func<global::System.Net.Http.HttpRequestMessage, global::System.Threading.CancellationToken, global::System.Action, global::System.Func<string, global::System.Threading.CancellationToken, global::System.Func<global::System.EventArgs>, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>, global::System.Threading.Tasks.Task<global::System.Net.Http.HttpResponseMessage>>>,
                                        global::System.Func<string, string, string, string, global::System.Uri, string>,
                                        System.Collections.Generic.IDictionary<string, object>>;

    /// <summary>
    /// The Virtual Call table of the functions to be exported to the generated module
    /// </summary>
    public class VTable
    {
        /// <summary>
        /// The cmdlet will call this when it is trying to fill in a parameter value that it needs
        /// </summary>
        /// <param name="resourceId"><c>string</c>containing the expected resource id (ie, ARM).</param>
        /// <param name="moduleName"><c>string</c>containing the name of the module being loaded.</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet</param>
        /// <param name="name">The <see cref="string" /> parameter name being asked for</param>
        /// <example>public object GetParameterValue(string resourceId, string moduleName, System.Management.Automation.InvocationInfo invocationInfo, string name)</example>
        public GetParameterDelegate GetParameterValue;

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
        public EventListenerDelegate EventListener;

        /// <summary>
        /// Called when the module is loading. Allows adding HTTP pipeline steps that will always be present.
        /// </summary>
        /// <param name="resourceId"><c>string</c>containing the expected resource id (ie, ARM).</param>
        /// <param name="moduleName"><c>string</c>containing the name of the module being loaded.</param>
        /// <param name="prependStep">a delegate which allows the module to prepend a step in the HTTP Pipeline</param>
        /// <param name="appendStep">a delegate which allows the module to append a step in the HTTP Pipeline</param>
        public ModuleLoadPipelineDelegate OnModuleLoad;

        /// <summary>
        /// Called when the cmdlet is constructing a new Request 
        /// </summary>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet (if available)</param>
        /// <param name="processRecordId">The <see cref="string" /> containing the correlation id for the individual process record. (if available)</param>
        /// <param name="prependStep">a delegate which allows the module to prepend a step in the HTTP Pipeline</param>
        /// <param name="appendStep">a delegate which allows the module to append a step in the HTTP Pipeline</param>
        public NewRequestPipelineDelegate OnNewRequest;

        public NewRequestPipelineDelegate AddRequestUserAgentHandler;

        public NewRequestPipelineDelegate AddPatchRequestUriHandler;

        public AuthorizeRequestDelegate AddAuthorizeRequestHandler;

        /// <summary>
        /// Called for well-known parameters that require argument completers
        /// </summary>
        /// <param name="completerName">string - the type of completer requested (Resource, Location)</param>
        /// <param name="invocationInfo">The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</param>
        /// <param name="correlationId">The <see cref="string" /> containing the correlation id for the cmdlet (if available)</param>
        /// <param name="resourceTypes">An <see cref="System.String[]"/> containing resource (or resource types) being completed  </param >
        /// <param name="parentResourceParameterNames"> An <see cref="System.String[]"/> containing list of parent resource parameter names (if applicable)</param >
        /// <returns>A <c>string[]</c> containing the valid options for the completer.</returns>
        public ArgumentCompleterDelegate ArgumentCompleter;

        /// <summary>
        /// The name of the currently selected Azure profile
        /// </summary>
        public string ProfileName { get; internal set; }
    }
}
