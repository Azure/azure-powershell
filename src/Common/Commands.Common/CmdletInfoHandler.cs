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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common
{
    /// <summary>
    /// A delegating handler that writes the current cmdlet info into request headers.
    /// </summary>
    public class CmdletInfoHandler : DelegatingHandler, ICloneable
    {
        /// <summary>
        /// The name of the cmdlet.
        /// </summary>
        public string Cmdlet { get; private set; }

        /// <summary>
        /// The name of the parameter set specified by user.
        /// </summary>
        public string ParameterSet { get; private set; }

        /// <summary>
        /// The unique client request id.
        /// </summary>
        public string ClientRequestId { get; private set; }

        /// <summary>
        /// Initializes an instance of a CmdletInfoHandler with the name of the cmdlet and the parameter set.
        /// </summary>
        /// <param name="cmdlet">the name of the cmdlet</param>
        /// <param name="parameterSet">the name of the parameter set specified by user</param>
        /// <param name="clientRequestId">the unique clientRequestId</param>
        public CmdletInfoHandler(string cmdlet, string parameterSet, string clientRequestId)
        {
            this.Cmdlet = cmdlet;
            this.ParameterSet = parameterSet;
            this.ClientRequestId = clientRequestId;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (Cmdlet != null)
            {
                request.Headers.Add("CommandName", Cmdlet);
            }
            if (ParameterSet != null)
            {
                request.Headers.Add("ParameterSetName", ParameterSet);
            }
            if (ClientRequestId != null)
            {
                if (request.Headers.Contains("x-ms-client-request-id"))
                {
                    request.Headers.Remove("x-ms-client-request-id");
                }
                request.Headers.TryAddWithoutValidation("x-ms-client-request-id", ClientRequestId);
            }
            return base.SendAsync(request, cancellationToken);
        }

        public object Clone()
        {
            return new CmdletInfoHandler(this.Cmdlet, this.ParameterSet, this.ClientRequestId);
        }
    }
}
