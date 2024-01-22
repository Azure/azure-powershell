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

using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Files.DataLake.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    /// <summary>
    /// Wrapper class of Microsoft.Azure.Storage.Blob.PathAccessControlEntry
    /// </summary>
    public class PSPathAccessControlEntry
    {

        public bool DefaultScope;
        public AccessControlType AccessControlType;
        public string EntityId;
        public RolePermissions Permissions;

        public PSPathAccessControlEntry(AccessControlType accessControlType, RolePermissions permissions, bool defaultScope = false, string entityId = null)
        {
            this.DefaultScope = defaultScope;
            this.AccessControlType = accessControlType;
            this.EntityId = entityId;
            this.Permissions = permissions;
        }
        public PSPathAccessControlEntry(PathAccessControlItem acl)
        {
            this.DefaultScope = acl.DefaultScope;
            this.AccessControlType = acl.AccessControlType;
            this.EntityId = acl.EntityId;
            this.Permissions = acl.Permissions;
        }

        public static List<PathAccessControlItem> ParseAccessControls(PSPathAccessControlEntry[] psacls)
        {
            if (psacls == null || psacls.Count() == 0)
            {
                return null;
            }
            List<PathAccessControlItem> acls = new List<PathAccessControlItem>();
            foreach (PSPathAccessControlEntry psacl in psacls)
            {
                acls.Add(new PathAccessControlItem()
                {
                    AccessControlType = psacl.AccessControlType,
                    Permissions = psacl.Permissions,
                    DefaultScope = psacl.DefaultScope,
                    EntityId = psacl.EntityId
                });
            }
            return acls;
        }

        public static List<RemovePathAccessControlItem> ParseRemoveAccessControls(PSPathAccessControlEntry[] psacls)
        {
            if (psacls == null || psacls.Count() == 0)
            {
                return null;
            }
            List<RemovePathAccessControlItem> acls = new List<RemovePathAccessControlItem>();
            foreach (PSPathAccessControlEntry psacl in psacls)
            {
                acls.Add(new RemovePathAccessControlItem(psacl.AccessControlType, psacl.DefaultScope, psacl.EntityId));
            }
            return acls;
        }

        public static PSPathAccessControlEntry[] ParsePSPathAccessControlEntrys(IEnumerable<PathAccessControlItem> acls)
        {
            if (acls == null || acls.Count() == 0)
            {
                return null;
            }
            List<PSPathAccessControlEntry> psacls = new List<PSPathAccessControlEntry>();
            foreach (PathAccessControlItem acl in acls)
            {
                psacls.Add(new PSPathAccessControlEntry(acl));
            }
            return psacls.ToArray();
        }

        public string GetSymbolicRolePermissions()
        {
            return PathAccessControlExtensions.ToSymbolicRolePermissions(this.Permissions);
        }
    }

    /// <summary>
    /// wrapper class of Microsoft.Azure.Storage.Blob.AccessControlType
    /// </summary>
    public static class PSAccessControlType
    {
        public const string User = "User";
        public const string Group = "Group";
        public const string Mask = "Mask";
        public const string Other = "Other";
    }
}
