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

using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using KeyVaultManagement = Microsoft.Azure.Management.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSVaultAccessPolicy
    {
        public PSVaultAccessPolicy(Guid tenantId, string objectId, Guid? applicationId, string[] permissionsToKeys, string[] permissionsToSecrets)
        {
            TenantId = tenantId;
            ObjectId = objectId;
            ApplicationId = applicationId;
            PermissionsToSecrets = permissionsToSecrets == null ? new List<string>() : new List<string>(permissionsToSecrets);
            PermissionsToKeys = permissionsToKeys == null ? new List<string>() : new List<string>(permissionsToKeys);
        }

        public PSVaultAccessPolicy(KeyVaultManagement.AccessPolicyEntry s, ActiveDirectoryClient adClient)
        {
            ObjectId = s.ObjectId;
            DisplayName = ModelExtensions.GetDisplayNameForADObject(s.ObjectId, adClient);
            ApplicationId = s.ApplicationId;
            TenantId = s.TenantId;
            TenantName = s.TenantId.ToString();
            PermissionsToSecrets = new List<string>(s.PermissionsToSecrets);
            PermissionsToKeys = new List<string>(s.PermissionsToKeys);
        }

        public Guid TenantId { get; private set; }

        public string TenantName { get; private set; }

        public string ObjectId { get; private set; }

        public Guid? ApplicationId { get; private set; }
        public string DisplayName { get; private set; }

        public string ApplicationIdDisplayName { get { return this.ApplicationId.HasValue ? this.ApplicationId.Value.ToString() : string.Empty; } }

        public List<string> PermissionsToKeys { get; private set; }

        public string PermissionsToKeysStr { get { return string.Join(", ", PermissionsToKeys); } }

        public List<string> PermissionsToSecrets { get; private set; }

        public string PermissionsToSecretsStr { get { return string.Join(", ", PermissionsToSecrets); } }
    }
}
