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
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedKeyVaultKeyIdentityItem : PSKeyVaultKeyIdentityItem
    {
        public PSDeletedKeyVaultKeyIdentityItem()
        { }

        internal PSDeletedKeyVaultKeyIdentityItem(Azure.KeyVault.Models.DeletedKeyItem keyItem, VaultUriHelper vaultUriHelper, bool isHsm = false) : base(keyItem, vaultUriHelper, isHsm)
        {
            ScheduledPurgeDate = keyItem.ScheduledPurgeDate;
            DeletedDate = keyItem.DeletedDate;
        }
        internal PSDeletedKeyVaultKeyIdentityItem(Track2Sdk.DeletedKey deletedKey, VaultUriHelper vaultUriHelper, bool isHsm = false) : base(deletedKey.Properties, vaultUriHelper, isHsm)
        {
            ScheduledPurgeDate = deletedKey.ScheduledPurgeDate?.UtcDateTime;
            DeletedDate = deletedKey.DeletedOn?.UtcDateTime;
        }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
