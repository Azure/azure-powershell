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

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common
{
    /// <summary>
    /// A delegating handler that writes the current cmdlet info into request headers.
    /// </summary>
    public class CmdletInfoHandler : DelegatingHandler
    {
        private string _cmdlet;
        private string _parameterSet;

        /// <summary>
        /// Initializes an instance of a CmdletInfoHandler with the name of the cmdlet and the parameter set.
        /// </summary>
        /// <param name="cmdlet">the name of the cmdlet</param>
        /// <param name="parameterSet">the name of the parameter set specified by user</param>
        public CmdletInfoHandler(string cmdlet, string parameterSet)
        {
            this._cmdlet = cmdlet;
            this._parameterSet = parameterSet;
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("CommandName", _cmdlet);
            request.Headers.Add("ParameterSetName", _parameterSet);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
