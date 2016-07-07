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

using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyVaultCertificate
    {
        public string Name { get; set; }
        public X509Certificate2 Certificate { get; set; }
        public string Id { get; internal set; }
        public string KeyId { get; internal set; }
        public string SecretId { get; internal set; }
        public string Thumbprint { get; set; }
        public IDictionary<string, string> Tags { get; set; }

        public bool? Enabled { get; set; }
        public DateTime? Created { get; internal set; }
        public DateTime? Updated { get; internal set; }

        internal static KeyVaultCertificate FromCertificateBundle(CertificateBundle certificateBundle)
        {
            if (certificateBundle == null)
            {
                return null;
            }

            var kvCertificate = new KeyVaultCertificate();

            if (certificateBundle.Id != null)
            {
                kvCertificate.Id = certificateBundle.CertificateIdentifier.Identifier;
                kvCertificate.Name = certificateBundle.CertificateIdentifier.Name;
            }

            if (certificateBundle.Cer != null)
            {
                kvCertificate.Certificate = new X509Certificate2(certificateBundle.Cer);
                kvCertificate.Thumbprint = kvCertificate.Certificate.Thumbprint;
            }

            if (certificateBundle.KeyIdentifier != null)
            {
                kvCertificate.KeyId = certificateBundle.KeyIdentifier.Identifier;
            }

            if (certificateBundle.SecretIdentifier != null)
            {
                kvCertificate.SecretId = certificateBundle.SecretIdentifier.Identifier;
            }

            if (certificateBundle.Attributes != null)
            {
                kvCertificate.Created = certificateBundle.Attributes.Created;
                kvCertificate.Enabled = certificateBundle.Attributes.Enabled;
                kvCertificate.Updated = certificateBundle.Attributes.Updated;
            }

            if (certificateBundle.Tags != null)
            {
                kvCertificate.Tags = certificateBundle.Tags;
            }

            return kvCertificate;
        }

        internal static List<KeyVaultCertificate> FromCertificateBundles(IEnumerable<CertificateBundle> certificateBundles)
        {
            if (certificateBundles == null || certificateBundles.Count() == 0)
            {
                return null;
            }

            return certificateBundles.Select(certificateBundle => KeyVaultCertificate.FromCertificateBundle(certificateBundle)).ToList();
        }
    }
}
