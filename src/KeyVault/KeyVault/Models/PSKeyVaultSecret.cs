﻿// ----------------------------------------------------------------------------------
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
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultSecret : PSKeyVaultSecretIdentityItem
    {
        public PSKeyVaultSecret()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="secret">secret returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal PSKeyVaultSecret(Azure.KeyVault.Models.SecretBundle secret, VaultUriHelper vaultUriHelper)
        {
            if (secret == null)
                throw new ArgumentNullException("secret");

            SetObjectIdentifier(vaultUriHelper, secret.SecretIdentifier);
            if (secret.Value != null)
                SecretValue = secret.Value.ConvertToSecureString();

            Attributes = new PSKeyVaultSecretAttributes(
                secret.Attributes.Enabled,
                secret.Attributes.Expires,
                secret.Attributes.NotBefore,
                secret.Attributes.Created,
                secret.Attributes.Updated,
                secret.ContentType,
                secret.Attributes.RecoveryLevel,
                secret.Tags);

            Enabled = secret.Attributes.Enabled;
            Expires = secret.Attributes.Expires;
            NotBefore = secret.Attributes.NotBefore;
            Created = secret.Attributes.Created;
            Updated = secret.Attributes.Updated;
            ContentType = secret.ContentType;
            Tags = (secret.Tags == null) ? null : secret.Tags.ConvertToHashtable();
        }

        public SecureString SecretValue { get; set; }

        public PSKeyVaultSecretAttributes Attributes { get; set; }

    }
}
