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

using System.Security;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ServicePrincipalParameters : AuthenticationParameters
    {
        public string ApplicationId { get; set; }

        public string Thumbprint { get; set; }

        public SecureString Secret { get; set; }

        public bool? SendCertificateChain { get; set; } = null;

        public string CertificatePath { get; set; }

        public SecureString CertificateSecret { get; set; }

        public ServicePrincipalParameters(
            PowerShellTokenCacheProvider tokenCacheProvider,
            IAzureEnvironment environment,
            IAzureTokenCache tokenCache,
            string tenantId,
            string resourceId,
            string applicationId,
            string thumbprint,
            string certificatePath,
            SecureString certificateSecret,
            SecureString secret,
            bool? sendCertificateChain) : base(tokenCacheProvider, environment, tokenCache, tenantId, resourceId)
        {
            ApplicationId = applicationId;
            Thumbprint = thumbprint;
            Secret = secret;
            SendCertificateChain = sendCertificateChain;
            CertificatePath = certificatePath;
            CertificateSecret = certificateSecret;
        }
    }
}
