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

namespace Microsoft.Azure.Commands.Common
{
  using EventListenerDelegate = Func<string, CancellationToken, Func<EventArgs>, Func<string, CancellationToken, Func<EventArgs>, Task>, Task>;
  using GetParameterDelegate = Func<string, string, Dictionary<string, object>, string, object>;
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

}
