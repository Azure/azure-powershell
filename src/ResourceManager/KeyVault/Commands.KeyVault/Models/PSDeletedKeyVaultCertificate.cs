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

using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public sealed class PSDeletedKeyVaultCertificate : PSDeletedKeyVaultCertificateIdentityItem
    {
        internal PSDeletedKeyVaultCertificate(DeletedCertificateBundle deletedCertificateBundle, VaultUriHelper vaultUriHelper)
        {
            if (deletedCertificateBundle == null)
            {
                throw new ArgumentNullException(nameof(deletedCertificateBundle));
            }

            if (deletedCertificateBundle.CertificateIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, deletedCertificateBundle.CertificateIdentifier);

            // VaultName formatted incorrect in certificateBundle
            var vaultUri = new Uri(deletedCertificateBundle.CertificateIdentifier.Vault);
            VaultName = vaultUri.Host.Split('.').First();

            if (deletedCertificateBundle.Cer != null)
            {
                Certificate = new X509Certificate2(deletedCertificateBundle.Cer);
                Thumbprint = Certificate.Thumbprint;
            }

            if (deletedCertificateBundle.KeyIdentifier != null)
            {
                KeyId = deletedCertificateBundle.KeyIdentifier.Identifier;
            }

            if (deletedCertificateBundle.SecretIdentifier != null)
            {
                SecretId = deletedCertificateBundle.SecretIdentifier.Identifier;
            }

            if (deletedCertificateBundle.Attributes != null)
            {
                Created = deletedCertificateBundle.Attributes.Created;
                Expires = deletedCertificateBundle.Attributes.Expires;
                NotBefore = deletedCertificateBundle.Attributes.NotBefore;
                Enabled = deletedCertificateBundle.Attributes.Enabled;
                Updated = deletedCertificateBundle.Attributes.Updated;
                RecoveryLevel = deletedCertificateBundle.Attributes.RecoveryLevel;
            }

            if (deletedCertificateBundle.Tags != null)
            {
                Tags = (Hashtable) deletedCertificateBundle.Tags;
            }

            ScheduledPurgeDate = deletedCertificateBundle.ScheduledPurgeDate;
            DeletedDate = deletedCertificateBundle.DeletedDate;
        }

        internal PSDeletedKeyVaultCertificate(DeletedCertificateBundle deletedCertificateBundle)
        {
            if (deletedCertificateBundle == null)
            {
                throw new ArgumentNullException(nameof(deletedCertificateBundle));
            }

            if (deletedCertificateBundle.CertificateIdentifier == null)
                throw new ArgumentException(Resources.InvalidKeyIdentifier);

            var vaultUri = new Uri(deletedCertificateBundle.CertificateIdentifier.Vault);

            SetObjectIdentifier(new ObjectIdentifier
            {
                Id = deletedCertificateBundle.CertificateIdentifier.Identifier,
                Name = deletedCertificateBundle.CertificateIdentifier.Name,
                // VaultName formatted incorrect in certificateBundle
                VaultName = vaultUri.Host.Split('.').First(),
                Version = deletedCertificateBundle.CertificateIdentifier.Version
            });

            if (deletedCertificateBundle.Cer != null)
            {
                Certificate = new X509Certificate2(deletedCertificateBundle.Cer);
                Thumbprint = Certificate.Thumbprint;
            }

            if (deletedCertificateBundle.KeyIdentifier != null)
            {
                KeyId = deletedCertificateBundle.KeyIdentifier.Identifier;
            }

            if (deletedCertificateBundle.SecretIdentifier != null)
            {
                SecretId = deletedCertificateBundle.SecretIdentifier.Identifier;
            }

            if (deletedCertificateBundle.Attributes != null)
            {
                Created = deletedCertificateBundle.Attributes.Created;
                Expires = deletedCertificateBundle.Attributes.Expires;
                NotBefore = deletedCertificateBundle.Attributes.NotBefore;
                Enabled = deletedCertificateBundle.Attributes.Enabled;
                Updated = deletedCertificateBundle.Attributes.Updated;
                RecoveryLevel = deletedCertificateBundle.Attributes.RecoveryLevel;
            }

            if (deletedCertificateBundle.Tags != null)
            {
                Tags = (Hashtable) deletedCertificateBundle.Tags;
            }

            ScheduledPurgeDate = deletedCertificateBundle.ScheduledPurgeDate;
            DeletedDate = deletedCertificateBundle.DeletedDate;
        }

        internal static PSDeletedKeyVaultCertificate FromDeletedCertificateBundle( Azure.KeyVault.Models.DeletedCertificateBundle deletedCertificateBundle ) 
        {
            if ( deletedCertificateBundle == null )
            {
                return null;
            }

            return new PSDeletedKeyVaultCertificate( deletedCertificateBundle );
        }

        public X509Certificate2 Certificate { get; set; }
        public string KeyId { get; internal set; }
        public string SecretId { get; internal set; }
        public string Thumbprint { get; set; }

        public string RecoveryLevel { get; private set; }
    }
}
