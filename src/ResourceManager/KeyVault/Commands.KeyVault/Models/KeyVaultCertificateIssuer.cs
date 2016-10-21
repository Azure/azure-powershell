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
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCertificateIssuer
    {
        public string Name { get; set; }
        public string IssuerProvider { get; set; }
        public string AccountId { get; set; }
        public SecureString ApiKey { get; set; }
        public KeyVaultCertificateOrganizationDetails OrganizationDetails { get; set; }

        internal static KeyVaultCertificateIssuer FromIssuer(IssuerBundle issuer)
        {
            if (issuer == null)
            {
                return null;
            }

            var kvcIssuer = new KeyVaultCertificateIssuer
            {
                Name = issuer.IssuerIdentifier.Name,
                IssuerProvider = issuer.Provider,
                OrganizationDetails = KeyVaultCertificateOrganizationDetails.FromOrganizationalDetails(issuer.OrganizationDetails),
            };

            if (issuer.Credentials != null)
            {
                kvcIssuer.AccountId = issuer.Credentials.AccountId;
                kvcIssuer.ApiKey = issuer.Credentials.Password == null ? null : issuer.Credentials.Password.ConvertToSecureString();
            }

            return kvcIssuer;
        }
    }
}
