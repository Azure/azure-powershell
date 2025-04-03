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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common
{
    using NextDelegate = Func<HttpRequestMessage, CancellationToken, Action, Func<string, CancellationToken, Func<EventArgs>, Task>, Task<HttpResponseMessage>>;
    using SignalDelegate = Func<string, CancellationToken, Func<EventArgs>, Task>;

    /// <summary>
    /// Pipeline step for adding x-ms-unique-id header
    /// </summary>
    public class UserAgent
    {
        private ProductInfoHeaderValue[] _userAgents;

        public UserAgent(InvocationInfo invocation)
        {
            List<ProductInfoHeaderValue> list = new List<ProductInfoHeaderValue>();
            string azVersion = (String.IsNullOrWhiteSpace(AzurePSCmdlet.AzVersion)) ? "0.0.0" : AzurePSCmdlet.AzVersion;
            list.Add(new ProductInfoHeaderValue("AzurePowershell", $"v{azVersion}"));
            if(!String.IsNullOrWhiteSpace(AzurePSCmdlet.PowerShellVersion))
            {
                list.Add(new ProductInfoHeaderValue("PSVersion", $"v{AzurePSCmdlet.PowerShellVersion}"));
            }
            string moduleName = TelemetryProvider.TrimModuleName(invocation?.MyCommand?.ModuleName);
            string moduleVersion = TelemetryProvider.TrimModuleVersion(invocation?.MyCommand?.Module?.Version);
            if(!string.IsNullOrWhiteSpace(moduleName))
            {
                list.Add(new ProductInfoHeaderValue(moduleName, moduleVersion));
            }
            try
            {
                string hostEnv = Environment.GetEnvironmentVariable("AZUREPS_HOST_ENVIRONMENT");
                if (!String.IsNullOrWhiteSpace(hostEnv))
                {
                    hostEnv = hostEnv.Trim().Replace("@", "_").Replace("/", "_");
                    list.Add(new ProductInfoHeaderValue(hostEnv, ""));
                }
            }
            catch (Exception ) 
            {
                // ignore it
            }
                
            _userAgents = list.ToArray();
        }

        /// <summary>
        /// Pipeline delegate to add a unique id header to an outgoing request
        /// </summary>
        /// <param name="request">The outgpoing request</param>
        /// <param name="token">The cancellation token</param>
        /// <param name="cancel">Additional cancellation action if the operation is cancelled</param>
        /// <param name="signal">Signal delegate for logging events</param>
        /// <param name="next">The next step in the pipeline</param>
        /// <returns>Amended pipeline for retrieving a response</returns>
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token, Action cancel, SignalDelegate signal, NextDelegate next)
        {
            foreach (var userAgent in _userAgents)
            {
                request.Headers.UserAgent.Add(userAgent);
            }

            // continue with pipeline.
            return next(request, token, cancel, signal);
        }
    }

}
