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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ServicePrincipalParameters : AuthenticationParameters
    {
        public string ApplicationId { get; set; }

        public string Thumbprint { get; set; }

        public SecureString Secret { get; set; }

        public ServicePrincipalParameters(
            IAzureEnvironment environment,
            IAzureTokenCache tokenCache,
            string tenantId,
            string applicationId,
            string thumbprint,
            SecureString secret) : base(environment, tokenCache, tenantId)
        {
            ApplicationId = applicationId;
            Thumbprint = thumbprint;
            Secret = secret;
        }
    }
}
