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
using System;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedKeyVaultSecret : PSDeletedKeyVaultSecretIdentityItem
    {
        public PSDeletedKeyVaultSecret()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="deletedSecret">secret returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal PSDeletedKeyVaultSecret(Azure.KeyVault.Models.DeletedSecretBundle deletedSecret, VaultUriHelper vaultUriHelper)
        {
            if (deletedSecret == null)
                throw new ArgumentNullException("secret");
            if (deletedSecret.Attributes == null)
                throw new ArgumentException(Resources.InvalidSecretAttributes);
            if (deletedSecret.SecretIdentifier == null)
                throw new ArgumentException(Resources.InvalidSecretIdentifier);

            SetObjectIdentifier(vaultUriHelper, deletedSecret.SecretIdentifier);
            if (deletedSecret.Value != null)
                SecretValue = deletedSecret.Value.ConvertToSecureString();

            Enabled = deletedSecret.Attributes.Enabled;
            Expires = deletedSecret.Attributes.Expires;
            NotBefore = deletedSecret.Attributes.NotBefore;
            Created = deletedSecret.Attributes.Created;
            Updated = deletedSecret.Attributes.Updated;
            ContentType = deletedSecret.ContentType;
            Tags = (deletedSecret.Tags == null) ? null : deletedSecret.Tags.ConvertToHashtable();

            Attributes = new PSKeyVaultSecretAttributes(
                deletedSecret.Attributes.Enabled,
                deletedSecret.Attributes.Expires,
                deletedSecret.Attributes.NotBefore,
                deletedSecret.Attributes.Created,
                deletedSecret.Attributes.Updated,
                deletedSecret.ContentType,
                deletedSecret.Attributes.RecoveryLevel,
                deletedSecret.Tags);

            ScheduledPurgeDate = deletedSecret.ScheduledPurgeDate;
            DeletedDate = deletedSecret.DeletedDate;
        }

        public SecureString SecretValue { get; set; }

        public string SecretValueText
        {
            get
            {
                string text = null;
                if (SecretValue != null)
                    text = SecretValue.ConvertToString();
                return text;
            }
        }
        public PSKeyVaultSecretAttributes Attributes { get; set; }
    }
}