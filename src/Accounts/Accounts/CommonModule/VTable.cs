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
    using TelemetryDelegate = Action<string, System.Management.Automation.InvocationInfo, string, System.Management.Automation.PSCmdlet>;
    using GetTelemetryIdDelegate = Func<string>;
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
    using SanitizerDelegate = Action<object, string>;
    using GetTelemetryInfoDelegate = Func<string, System.Collections.Generic.Dictionary<string, string>>;

    /// <summary>
    /// The Virtual Call table of the functions to be exported to the generated module
    /// </summary>
    public class VTable
    {
        /// <summary>
        /// The cmdlet will call this when it is trying to fill in a parameter value that it needs
        /// </summary>
        /// <example>
        /// <code>
        /// public object GetParameterValue(string resourceId, string moduleName, System.Management.Automation.InvocationInfo invocationInfo, string name)
        /// </code>
        /// <para>resourceId: <c>string</c>containing the expected resource id (ie, ARM).</para>
        /// <para>moduleName: <c>string</c>containing the name of the module being loaded.</para>
        /// <para>invocationInfo: The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</para>
        /// <para>correlationId: The <see cref="string" /> containing the correlation id for the cmdlet</para>
        /// <para>name: The <see cref="string" /> parameter name being asked for</para>
        /// </example>
        public GetParameterDelegate GetParameterValue;

        public GetTelemetryIdDelegate GetTelemetryId;

        public TelemetryDelegate Telemetry;

        /// <summary>
        /// The cmdlet will call this for every event during the pipeline. 
        /// </summary>
        /// <example>
        /// <para>id: a <c>string</c> containing the name of the event being raised (well-known events are in <see cref="Microsoft.Azure.Commands.Common.Events"/></para>
        /// <para>cancellationToken: a <c>CancellationToken</c> indicating if this request is being cancelled.</para>
        /// <para>getEventData: a delegate to call to get the event data for this event</para>
        /// <para>signal: a delegate to signal an event from the handler to the cmdlet.</para>
        /// <para>invocationInfo: The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</para>
        /// <para>parameterSetName: The <see cref="string" /> containing the name of the parameter set for this invocation (if available></para>
        /// <para>correlationId: The <see cref="string" /> containing the correlation id for the cmdlet (if available)</para>
        /// <para>processRecordId: The <see cref="string" /> containing the correlation id for the individual process record. (if available)</para>
        /// <para>exception: The <see cref="System.Exception" /> that is being thrown (if available)</para>
        /// </example>
        public EventListenerDelegate EventListener;

        /// <summary>
        /// Called when the module is loading. Allows adding HTTP pipeline steps that will always be present.
        /// </summary>
        /// <example>
        /// <para>resourceId: <c>string</c>containing the expected resource id (ie, ARM).</para>
        /// <para>moduleName: <c>string</c>containing the name of the module being loaded.</para>
        /// <para>prependStep: a delegate which allows the module to prepend a step in the HTTP Pipeline</para>
        /// <para>appendStep: a delegate which allows the module to append a step in the HTTP Pipeline</para>
        ///</example>
        public ModuleLoadPipelineDelegate OnModuleLoad;

        /// <summary>
        /// Called when the cmdlet is constructing a new Request 
        /// </summary>
        /// <example>
        /// <para>invocationInfo: The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</para>
        /// <para>correlationId: The <see cref="string" /> containing the correlation id for the cmdlet (if available)</para>
        /// <para>processRecordId: The <see cref="string" /> containing the correlation id for the individual process record. (if available)</para>
        /// <para>prependStep: a delegate which allows the module to prepend a step in the HTTP Pipeline</para>
        /// <para>appendStep: a delegate which allows the module to append a step in the HTTP Pipeline</para>
        /// </example>
        public NewRequestPipelineDelegate OnNewRequest;

        public NewRequestPipelineDelegate AddRequestUserAgentHandler;

        public NewRequestPipelineDelegate AddPatchRequestUriHandler;

        public AuthorizeRequestDelegate AddAuthorizeRequestHandler;

        public SanitizerDelegate SanitizerHandler;

        public GetTelemetryInfoDelegate GetTelemetryInfo;

        /// <summary>
        /// Called for well-known parameters that require argument completers, it
        /// </summary>
        /// <example>
        /// public string[] ArgumentCompleter(string completerName, System.Management.Automation.InvocationInfo invocationInfo, string correlationId, string[] resourceTypes, string[] parentResourceParameterNames)
        ///     <para> completerName: string - the type of completer requested (Resource, Location)</para>
        ///     <para> invocationInfo: The <see cref="System.Management.Automation.InvocationInfo" /> from the cmdlet</para>
        ///     <para> correlationId: The <see cref="string" /> containing the correlation id for the cmdlet (if available)</para>
        ///     <para> resourceTypes: An <see cref="System.String"/>[] containing resource (or resource types) being completed</para>
        ///     <para> parentResourceParameterNames: An <see cref="System.String"/>[] containing list of parent resource parameter names (if applicable)</para>
        /// </example>
        /// <returns>A <c>string[]</c> containing the valid options for the completer.</returns>
        public ArgumentCompleterDelegate ArgumentCompleter;

        /// <summary>
        /// The name of the currently selected Azure profile
        /// </summary>
        public string ProfileName { get; internal set; }
    }
}
