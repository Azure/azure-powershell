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

using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    // wrapper of LocalUser
    public class PSLocalUser
    {
        public PSLocalUser() { }

        public PSLocalUser(LocalUser user, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.Id = user.Id;
            this.Name = user.Name;
            this.Type = user.Type;
            this.Sid = user.Sid;
            //this.SharedKey = user.SharedKey;
            //this.SshPassword = user.SshPassword;
            this.HomeDirectory = user.HomeDirectory;
            this.HasSharedKey = user.HasSharedKey;
            this.HasSshKey = user.HasSshKey;
            this.HasSshPassword = user.HasSshPassword;
            this.SshAuthorizedKeys = PSSshPublicKey.GetPSSshPublicKeys(user.SshAuthorizedKeys);
            this.PermissionScopes = PSPermissionScope.GetPSPermissionScopes(user.PermissionScopes);
        }


        public LocalUser ParseLocalUser()
        {
            LocalUser user = new LocalUser();
            //user.SharedKey = this.SharedKey;
            user.HomeDirectory = this.HomeDirectory;
            user.HasSharedKey = this.HasSharedKey;
            user.HasSshKey = this.HasSshKey;
            user.HasSshPassword = this.HasSshPassword;
            user.SshAuthorizedKeys = PSSshPublicKey.ParseSshPublicKeyss(this.SshAuthorizedKeys);
            user.PermissionScopes = PSPermissionScope.ParsePermissionScopes(this.PermissionScopes);
            return user;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Sid { get; set; }
        //public string SharedKey { get; set; }
        //public string SshPassword { get; set; }
        public string HomeDirectory { get; set; }
        public bool? HasSharedKey { get; set; }
        public bool? HasSshKey { get; set; }
        public bool? HasSshPassword { get; set; }
        public PSSshPublicKey[] SshAuthorizedKeys { get; set; }
        public PSPermissionScope[] PermissionScopes { get; set; }
    }

    //wrapper of SshPublicKey
    public class PSSshPublicKey
    {
        public string Description { get; set; }
        public string Key { get; set; }

        public PSSshPublicKey()
        {
        }

        public PSSshPublicKey(SshPublicKey sshPublicKey)
        {
            if (sshPublicKey != null)
            {
                this.Description = sshPublicKey.Description;
                this.Key = sshPublicKey.Key;
            }
        }

        public SshPublicKey ParseSshPublicKey()
        {
            SshPublicKey sshPublicKey = new SshPublicKey();
            sshPublicKey.Description = this.Description;
            sshPublicKey.Key = this.Key;
            return sshPublicKey;
        }

        public static PSSshPublicKey[] GetPSSshPublicKeys(IList<SshPublicKey> keys)
        {
            if (keys == null)
            {
                return null;
            }
            List<PSSshPublicKey> pskeys = new List<PSSshPublicKey>();
            foreach (SshPublicKey key in keys)
            {
                pskeys.Add(new PSSshPublicKey(key));
            }
            return pskeys.ToArray();
        }

        public static List<SshPublicKey> ParseSshPublicKeyss(PSSshPublicKey[] pskeys)
        {
            if (pskeys == null)
            {
                return null;
            }
            List<SshPublicKey> keys = new List<SshPublicKey>();
            foreach (PSSshPublicKey pskey in pskeys)
            {
                keys.Add(pskey.ParseSshPublicKey());
            }
            return keys;
        }
    }

    //wrapper of PermissionScope
    public class PSPermissionScope
    {
        public string Permissions { get; set; }
        public string Service { get; set; }
        public string ResourceName { get; set; }

        public PSPermissionScope()
        {
        }

        public PSPermissionScope(PermissionScope permissionScope)
        {
            if (permissionScope != null)
            {
                this.Permissions = permissionScope.Permissions;
                this.Service = permissionScope.Service;
                this.ResourceName = permissionScope.ResourceName;
            }
        }

        public PermissionScope ParsePermissionScope()
        {
            PermissionScope scope = new PermissionScope();
            scope.Permissions = this.Permissions;
            scope.Service = this.Service;
            scope.ResourceName = this.ResourceName;
            return scope;
        }

        public static PSPermissionScope[] GetPSPermissionScopes(IList<PermissionScope> scopes)
        {
            if (scopes == null)
            {
                return null;
            }
            List<PSPermissionScope> psscopes = new List<PSPermissionScope>();
            foreach (PermissionScope scope in scopes)
            {
                psscopes.Add(new PSPermissionScope(scope));
            }
            return psscopes.ToArray();
        }

        public static List<PermissionScope> ParsePermissionScopes(PSPermissionScope[] psscopes)
        {
            if (psscopes == null)
            {
                return null;
            }
            List<PermissionScope> scopes = new List<PermissionScope>();
            foreach (PSPermissionScope psscope in psscopes)
            {
                scopes.Add(psscope.ParsePermissionScope());
            }
            return scopes;
        }
    }

    public class PSLocalUserKeys
    {
        public PSLocalUserKeys() { }

        public PSLocalUserKeys(LocalUserKeys keys)
        {
            if (keys == null)
            {
                return;
            }

            this.SharedKey = keys.SharedKey;
            this.SshAuthorizedKeys = PSSshPublicKey.GetPSSshPublicKeys(keys.SshAuthorizedKeys);
        }

        public PSSshPublicKey[] SshAuthorizedKeys { get; set; }
        public string SharedKey { get; set; }
    }

    public class PSLocalUserRegeneratePasswordResult
    {
        public PSLocalUserRegeneratePasswordResult() { }

        public PSLocalUserRegeneratePasswordResult(LocalUserRegeneratePasswordResult properties)
        {
                //this.Sid = properties.Sid;
                //this.SharedKey = properties.SharedKey;
                this.SshPassword = properties.SshPassword;
                //this.HomeDirectory = properties.HomeDirectory;
                //this.HasSharedKey = properties.HasSharedKey;
                //this.HasSshKey = properties.HasSshKey;
                //this.HasSshPassword = properties.HasSshPassword;
                //this.SshAuthorizedKeys = PSSshPublicKey.GetPSSshPublicKeys(properties.SshAuthorizedKeys);
                //this.PermissionScopes = PSPermissionScope.GetPSPermissionScopes(properties.PermissionScopes);
        }

        //public PSPermissionScope[] PermissionScopes { get; set; }
        //public string HomeDirectory { get; set; }
        //public PSSshPublicKey[] SshAuthorizedKeys { get; set; }
        //public string Sid { get; }
        //public string SharedKey { get; set; }
        public string SshPassword { get; }
        //public bool? HasSharedKey { get; set; }
        //public bool? HasSshKey { get; set; }
        //public bool? HasSshPassword { get; set; }
    }
}
