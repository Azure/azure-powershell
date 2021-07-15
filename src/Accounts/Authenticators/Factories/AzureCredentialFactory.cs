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

using Azure.Core;
using Azure.Identity;
using Microsoft.WindowsAzure.Commands.Common;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.PowerShell.Authenticators.Factories
{
    public class AzureCredentialFactory
    {
        public virtual TokenCredential CreateManagedIdentityCredential(string clientId)
        {
            return new ManagedIdentityCredential(clientId);
        }

        public virtual TokenCredential CreateClientSecretCredential(string tenantId, string clientId, SecureString secret, ClientCertificateCredentialOptions options)
        {
            return new ClientSecretCredential(tenantId, clientId, secret.ConvertToString(), options);
        }

        public virtual TokenCredential CreateClientCertificateCredential(string tenantId, string clientId, X509Certificate2 certifiate, ClientCertificateCredentialOptions options)
        {
            return new ClientCertificateCredential(tenantId, clientId, certifiate, options);
        }

        public virtual TokenCredential CreateClientCertificateCredential(string tenantId, string clientId, string certificatePath, ClientCertificateCredentialOptions options)
        {
            return new ClientCertificateCredential(tenantId, clientId, certificatePath, options);
	}

        public virtual TokenCredential CreateSharedTokenCacheCredentials(SharedTokenCacheCredentialOptions options)
        {
            return new SharedTokenCacheCredential(options);
        }
    }
}
