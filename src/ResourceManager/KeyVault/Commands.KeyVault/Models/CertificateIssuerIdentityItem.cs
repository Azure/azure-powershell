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
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class CertificateIssuerIdentityItem
    {
        internal CertificateIssuerIdentityItem(CertificateIssuerItem issuerItem, VaultUriHelper vaultUriHelper)
        {
            if (issuerItem == null)
                throw new ArgumentNullException("issuerItem");

            Name = new CertificateIssuerIdentifier(issuerItem.Id).Name;
            IssuerProvider = issuerItem.Provider;
        }

        internal CertificateIssuerIdentityItem(IssuerBundle issuer)
        {
            if (issuer == null)
                throw new ArgumentNullException("issuer");

            Name = issuer.IssuerIdentifier.Name;
            IssuerProvider = issuer.Provider;
        }

        public string Name { get; set; }

        public string IssuerProvider { get; private set; }
    }
}
