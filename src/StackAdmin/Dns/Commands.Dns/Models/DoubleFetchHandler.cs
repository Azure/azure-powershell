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

namespace Microsoft.Azure.Commands.Dns.Models
{
    public class DoubleFetchHandler : DelegatingHandler, ICloneable
    {
        public object Clone() {
            return new DoubleFetchHandler();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(response =>
            {
                var result = response.Result;
                    if (result.Headers.Contains("Location") && result.Headers.Contains("Azure-AsyncOperation"))
                    {
                        result.Headers.Remove("Location");
                    }

                return result;
            });
        }

    }
}
