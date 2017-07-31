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

        public string RecoveryLevel { get; private set; }

        public KeyVaultCertificate( CertificateBundle certificateBundle )
        {
            if ( certificateBundle == null )
            {
                throw new ArgumentNullException( nameof( certificateBundle ) );
            }

            if ( certificateBundle.Id != null )
            {
                Id = certificateBundle.CertificateIdentifier.Identifier;
                Name = certificateBundle.CertificateIdentifier.Name;
            }

            if ( certificateBundle.Cer != null )
            {
                Certificate = new X509Certificate2( certificateBundle.Cer );
                Thumbprint = Certificate.Thumbprint;
            }

            if ( certificateBundle.KeyIdentifier != null )
            {
                KeyId = certificateBundle.KeyIdentifier.Identifier;
            }

            if ( certificateBundle.SecretIdentifier != null )
            {
                SecretId = certificateBundle.SecretIdentifier.Identifier;
            }

            if ( certificateBundle.Attributes != null )
            {
                Created = certificateBundle.Attributes.Created;
                Enabled = certificateBundle.Attributes.Enabled;
                Updated = certificateBundle.Attributes.Updated;
                RecoveryLevel = certificateBundle.Attributes.RecoveryLevel;
            }

            if ( certificateBundle.Tags != null )
            {
                Tags = certificateBundle.Tags;
            }
        }

        internal static KeyVaultCertificate FromCertificateBundle(CertificateBundle certificateBundle)
        {
            if ( certificateBundle == null )
            {
                return null;
            }

            return new KeyVaultCertificate( certificateBundle );
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
