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

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using Microsoft.Azure.Management.DeploymentManager.Models;
    using System;

    public class PSRestRequest
    {
        public PSRestRequest()
        {
        }

        public PSRestRequest(RestRequest restRequest)
        {
            this.Method = (PSRestRequestMethod)Enum.Parse(typeof(PSRestRequestMethod), restRequest.Method.ToString(), ignoreCase: true);
            this.Uri = restRequest?.Uri;

            this.ResolveAuthentication(restRequest);
        }

        public PSRestRequestMethod Method { get; set; }

        public string Uri { get; set; }

        public PSRestRequestAuthentication Authentication { get; set; }

        internal RestRequest ToSdkType()
        {
            return new RestRequest(
                method: (RestRequestMethod)Enum.Parse(typeof(RestRequestMethod), this.Method.ToString(), ignoreCase: true),
                uri: this.Uri,
                authentication: this.Authentication.ToSdkType());
        }

        private void ResolveAuthentication(RestRequest restRequest)
        {
            if (restRequest.Authentication is ApiKeyAuthentication)
            {
                this.Authentication = new PSApiKeyAuthentication((ApiKeyAuthentication)restRequest.Authentication);
            }
            else if (restRequest.Authentication is RolloutIdentityAuthentication)
            {
                this.Authentication = new PSRolloutIdentityAuthentication((RolloutIdentityAuthentication)restRequest.Authentication);
            }
        }
    }
}
