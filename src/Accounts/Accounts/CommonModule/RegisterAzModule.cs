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
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Common
{
    using SendAsyncStepDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>;
    using PipelineChangeDelegate = Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>;
    using EventListenerDelegate = Func<string, CancellationToken, Func<EventArgs>, Func<string, CancellationToken, Func<EventArgs>, Task>, System.Management.Automation.InvocationInfo, string, string, string, System.Exception, Task>;
    using GetParameterDelegate = Func<string, string, InvocationInfo, string, string, object>;
    using ModuleLoadPipelineDelegate = Action<string, string, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;
    using NewRequestPipelineDelegate = Action<InvocationInfo, string, string, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>, Action<Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>, Task<HttpResponseMessage>>>>;
    using ArgumentCompleterDelegate = Func<string, InvocationInfo, string, string[], string[], string[]>;

    /// <summary>
    /// Return runtime services for generated cmdlets
    /// </summary>
    [OutputType(typeof(VTable))]
    [Cmdlet(VerbsLifecycle.Register, @"AzModule", SupportsShouldProcess = true)]
    public class RegisterAzModule : PSCmdlet
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

                    // this gets called to get the telemetryId
                    GetTelemetryId = () => { return MetricHelper.TelemetryId; },

                    // this gets called when a telemetry related operation is made, e.g. create/send a telemetry
                    Telemetry = module.Telemetry,

                    // this gets called at module load time (allows you to change the http pipeline)
                    OnModuleLoad = module.OnModuleLoad,

                    // this gets called to sanitize the output object
                    SanitizerHandler = module.SanitizerHandler,

                    // this gets called to get the sanitizer info
                    GetTelemetryInfo = module.GetTelemetryInfo,

                    // this gets called before the generated cmdlet makes a call across the wire (allows you to change the HTTP pipeline)
                    OnNewRequest = ContextAdapter.Instance.OnNewRequest,

                    //OnNewRequest = AddRequestUserAgentHandler + AddPatchRequestUriHandler + AddAuthorizeRequestHandler
                    AddRequestUserAgentHandler = ContextAdapter.Instance.AddRequestUserAgentHandler,

                    AddPatchRequestUriHandler = ContextAdapter.Instance.AddPatchRequestUriHandler,

                    AddAuthorizeRequestHandler = ContextAdapter.Instance.AddAuthorizeRequestHandler,

                    // Called for well-known parameters that require argument completers
                    ArgumentCompleter = ContextAdapter.Instance.CompleteArgument,

                    // Gets the selected Azure profile from the context
                    ProfileName = ContextAdapter.Instance.SelectedProfile
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
