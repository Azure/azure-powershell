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

using Microsoft.Azure.Commands.NetAppFiles.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Helpers
{
    public static class NetAppAccountExtensions
    {
        public static PSNetAppFilesAccount ConvertToPs(this NetAppAccount netAppAccount)
        {
            string resourceGroupName = new ResourceIdentifier(netAppAccount.Id).ResourceGroupName;
            return new PSNetAppFilesAccount
            {
                ResourceGroupName = resourceGroupName,
                Location = netAppAccount.Location,
                Id = netAppAccount.Id,
                Name = netAppAccount.Name,
                Type = netAppAccount.Type,
                Tags = netAppAccount.Tags,
                Etag = netAppAccount.Etag,
                ActiveDirectories = (netAppAccount.ActiveDirectories != null) ? netAppAccount.ActiveDirectories.ConvertToPs(resourceGroupName, netAppAccount.Name) : null,
                ProvisioningState = netAppAccount.ProvisioningState,
                Identity = netAppAccount.Identity?.ConvertToPs(),
                DisableShowmount = netAppAccount.DisableShowmount,
                Encryption = netAppAccount.Encryption?.ConvertToPs(),
                SystemData = netAppAccount.SystemData?.ToPsSystemData()
            };
        }


        public static PSManagedServiceIdentity ConvertToPs(this ManagedServiceIdentity identity)
        {
            return new PSManagedServiceIdentity
            {
                PrincipalId = identity.PrincipalId.ToString(),
                TenantId = identity.TenantId,
                Type = identity.Type,
                UserAssignedIdentities = identity.UserAssignedIdentities?.ConvertToPs()
            };
        }

        public static PSEncryptionIdentity ConvertToPs(this EncryptionIdentity identity)
        {            
            return new PSEncryptionIdentity
            {
                PrincipalId = identity.PrincipalId,
                UserAssignedIdentity = identity.UserAssignedIdentity
            };
        }

        public static EncryptionIdentity ConvertFromPs(this PSEncryptionIdentity encryptionIdentity)
        {
            return new EncryptionIdentity(principalId: encryptionIdentity.PrincipalId)
            {
                UserAssignedIdentity = encryptionIdentity.UserAssignedIdentity
            };
        }

        public static IDictionary<string, PSUserAssignedIdentity> ConvertToPs(this IDictionary<string, UserAssignedIdentity> uaIdentities)
        {
            var userAssignedIdentities = new Dictionary<string, PSUserAssignedIdentity>();
            foreach (var uaIdentity in uaIdentities)
            {
                userAssignedIdentities.Add(uaIdentity.Key, uaIdentity.Value.ConvertToPs());
            }
            return userAssignedIdentities;
        }

        public static PSUserAssignedIdentity ConvertToPs(this UserAssignedIdentity identity)
        {
            return new PSUserAssignedIdentity
            {
                ClientId = identity.ClientId.ToString(),
                PrincipalId = identity.PrincipalId.ToString()
            };
        }

        public static IDictionary<string, UserAssignedIdentity> ConvertFromPs(this IDictionary<string, PSUserAssignedIdentity> uaIdentities)
        {
            var userAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
            foreach (var uaIdentity in uaIdentities)
            {
                userAssignedIdentities.Add(uaIdentity.Key, uaIdentity.Value.ConvertFromPs());
            }
            return userAssignedIdentities;
        }

        public static UserAssignedIdentity ConvertFromPs(this PSUserAssignedIdentity userAssignedIdentity)
        {
            if (!Guid.TryParse(userAssignedIdentity.ClientId, out Guid clientIdGuid))
            {
                throw new ArgumentException($"ClientId {userAssignedIdentity.ClientId} is not a valid Guid");
            }
            if (!Guid.TryParse(userAssignedIdentity.PrincipalId, out Guid principalIdGuid))
            {
                throw new ArgumentException($"PrincipalId {userAssignedIdentity.PrincipalId} is not a valid Guid");
            }
            return new UserAssignedIdentity(principalId: principalIdGuid, clientId: clientIdGuid);
        }

        public static ManagedServiceIdentity ConvertFromPs(this PSManagedServiceIdentity identity)
        {
            if (!Guid.TryParse(identity.PrincipalId, out Guid principalIdGuid))
            {
                throw new ArgumentException($"PrincipalId {identity.PrincipalId} is not a valid Guid");
            }
            return new ManagedServiceIdentity(type: identity.Type, principalId: principalIdGuid, tenantId: identity.TenantId)
            {
                UserAssignedIdentities = identity.UserAssignedIdentities.ConvertFromPs()
            };
        }



        public static PSNetAppFilesAccountEncryption ConvertToPs(this AccountEncryption encryption)
        {
            return new PSNetAppFilesAccountEncryption
            {
                KeySource = encryption.KeySource,
                Identity = encryption.Identity?.ConvertToPs(),
                KeyVaultProperties = encryption.KeyVaultProperties?.ConvertToPs()
            };
        }

        public static PSNetAppFilesKeyVaultProperties ConvertToPs(this KeyVaultProperties encryption)
        {
            return new PSNetAppFilesKeyVaultProperties
            {
                KeyName = encryption.KeyName,
                KeyVaultId = encryption.KeyVaultId,
                KeyVaultResourceId = encryption.KeyVaultResourceId,
                KeyVaultUri = encryption.KeyVaultUri,
                Status = encryption.Status,
            };
        }

        public static KeyVaultProperties ConvertFromPs(this PSNetAppFilesKeyVaultProperties encryption)
        {
            return new KeyVaultProperties(keyName: encryption.KeyName, keyVaultResourceId: encryption.KeyVaultResourceId, keyVaultId: encryption.KeyVaultId, keyVaultUri: encryption.KeyVaultUri, status: encryption.Status);
        }

        public static AccountEncryption ConvertFromPs(this PSNetAppFilesAccountEncryption encryption)
        {
            return new AccountEncryption
            {
                KeySource = encryption.KeySource,
                Identity = encryption.Identity?.ConvertFromPs(),
                KeyVaultProperties = encryption.KeyVaultProperties?.ConvertFromPs()
            };
        }
    }
}
