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

using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultCertificate : PSKeyVaultCertificateIdentityItem
    {
        public X509Certificate2 Certificate { get; set; }
        public string KeyId { get; internal set; }
        public string SecretId { get; internal set; }
        public string Thumbprint { get; set; }

        public string RecoveryLevel { get; private set; }

        internal PSKeyVaultCertificate(CertificateBundle certificateBundle, VaultUriHelper vaultUriHelper)
        {
            if ( certificateBundle == null )
            {
                throw new ArgumentNullException( nameof( certificateBundle ) );
            }

            if (certificateBundle.CertificateIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, certificateBundle.CertificateIdentifier);

            // VaultName formatted incorrect in certificateBundle
            var vaultUri = new Uri(certificateBundle.CertificateIdentifier.Vault);
            VaultName = vaultUri.Host.Split('.').First();

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
                Expires = certificateBundle.Attributes.Expires;
                NotBefore = certificateBundle.Attributes.NotBefore;
                Enabled = certificateBundle.Attributes.Enabled;
                Updated = certificateBundle.Attributes.Updated;
                RecoveryLevel = certificateBundle.Attributes.RecoveryLevel;
            }

            if ( certificateBundle.Tags != null )
            {
                Tags = (Hashtable) certificateBundle.Tags;
            }
        }

        internal PSKeyVaultCertificate(CertificateBundle certificateBundle)
        {
            if (certificateBundle == null)
            {
                throw new ArgumentNullException(nameof(certificateBundle));
            }

            if (certificateBundle.CertificateIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            var vaultUri = new Uri(certificateBundle.CertificateIdentifier.Vault);

            SetObjectIdentifier(new ObjectIdentifier
            {
                Id = certificateBundle.CertificateIdentifier.Identifier,
                Name = certificateBundle.CertificateIdentifier.Name,
                // VaultName formatted incorrect in certificateBundle
                VaultName = vaultUri.Host.Split('.').First(),
                Version = certificateBundle.CertificateIdentifier.Version
            });

            if (certificateBundle.Cer != null)
            {
                Certificate = new X509Certificate2(certificateBundle.Cer);
                Thumbprint = Certificate.Thumbprint;
            }

            if (certificateBundle.KeyIdentifier != null)
            {
                KeyId = certificateBundle.KeyIdentifier.Identifier;
            }

            if (certificateBundle.SecretIdentifier != null)
            {
                SecretId = certificateBundle.SecretIdentifier.Identifier;
            }

            if (certificateBundle.Attributes != null)
            {
                Created = certificateBundle.Attributes.Created;
                Expires = certificateBundle.Attributes.Expires;
                NotBefore = certificateBundle.Attributes.NotBefore;
                Enabled = certificateBundle.Attributes.Enabled;
                Updated = certificateBundle.Attributes.Updated;
                RecoveryLevel = certificateBundle.Attributes.RecoveryLevel;
            }

            if (certificateBundle.Tags != null)
            {
                Tags = (Hashtable)certificateBundle.Tags;
            }
        }

        internal static PSKeyVaultCertificate FromCertificateBundle(CertificateBundle certificateBundle)
        {
            if ( certificateBundle == null )
            {
                return null;
            }

            return new PSKeyVaultCertificate( certificateBundle );
        }

        internal static List<PSKeyVaultCertificate> FromCertificateBundles(IEnumerable<CertificateBundle> certificateBundles)
        {
            if (certificateBundles == null || certificateBundles.Count() == 0)
            {
                return null;
            }

            return certificateBundles.Select(certificateBundle => PSKeyVaultCertificate.FromCertificateBundle(certificateBundle)).ToList();
        }
    }
}
