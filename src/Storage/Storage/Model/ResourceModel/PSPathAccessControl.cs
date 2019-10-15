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

using Microsoft.Azure.Storage.Shared.Protocol;
using XTable = Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Azure.Storage.File;
using System.Net;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    public class PSPathAccessControlEntry
    {

        public bool DefaultScope;
        public AccessControlType? AccessControlType;
        public string EntityId;
        public RolePermissions Permissions;

        public PSPathAccessControlEntry(AccessControlType accessControlType, RolePermissions permissions, bool defaultScope = false, string entityId = null)
        {
            this.DefaultScope = defaultScope;
            this.AccessControlType = accessControlType;
            this.EntityId = entityId;
            this.Permissions = permissions;
        }
        public PSPathAccessControlEntry(PathAccessControlEntry acl)
        {
            this.DefaultScope = acl.DefaultScope;
            this.AccessControlType = acl.AccessControlType;
            this.EntityId = acl.EntityId;
            this.Permissions = acl.Permissions;
        }

        public static List<PathAccessControlEntry> ParseAccessControls(PSPathAccessControlEntry[] psacls)
        {
            if (psacls == null || psacls.Count() == 0)
            {
                return null;
            }
            List<PathAccessControlEntry> acls = new List<PathAccessControlEntry>();
            foreach (PSPathAccessControlEntry psacl in psacls)
            {
                acls.Add(new PathAccessControlEntry()
                {
                    AccessControlType = psacl.AccessControlType,
                    Permissions = psacl.Permissions,
                    DefaultScope = psacl.DefaultScope,
                    EntityId = psacl.EntityId
                });
            }
            return acls;
        }

        public static PSPathAccessControlEntry[] ParsePSPathAccessControlEntrys(List<PathAccessControlEntry> acls)
        {
            if (acls == null || acls.Count() == 0)
            {
                return null;
            }
            List<PSPathAccessControlEntry> psacls = new List<PSPathAccessControlEntry>();
            foreach (PathAccessControlEntry acl in acls)
            {
                psacls.Add(new PSPathAccessControlEntry(acl));
            }
            return psacls.ToArray();
        }
    }

    public static class PSAccessControlType
    {
        public const string User = "User";
        public const string Group = "Group";
        public const string Mask = "Mask";
        public const string Other = "Other";
    }
}
