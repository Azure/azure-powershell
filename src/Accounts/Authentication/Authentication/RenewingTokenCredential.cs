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

using Microsoft.Rest;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Threading;
using System.Net.Http;
using System.Management.Automation.Language;
using System;
using System.ComponentModel;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class RenewingTokenCredential : ServiceClientCredentials
    {
        private IAccessToken _token;
        private readonly Func<IAccessToken> _authenticate;


        public RenewingTokenCredential(IAccessToken token, Func<IAccessToken> authenticate = null)
        {
            _authenticate = authenticate;
            _token = token;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Run(() => 
                {
                    _token = (_authenticate == null) ? _token : _authenticate();
                    _token.AuthorizeRequest((type, token) => request.Headers.Authorization = new AuthenticationHeaderValue(type, token));
                });
        }

    }
}
