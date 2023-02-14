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

using Microsoft.Azure.Commands.DataLakeStore.Properties;
using Microsoft.Rest.Azure;
using System;
using System.Linq;
using Microsoft.Azure.DataLake.Store.Acl;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders. This is an exposed model to public so it should be independent of SDK models. We will never be able to remove members. 
    /// The sdk model AclEntry is mapped to this model.
    /// </summary>
    public class DataLakeStoreItemAce
    {
        public DataLakeStoreItemAce(DataLakeStoreEnums.ScopeType scope, DataLakeStoreEnums.AceType type, string id, string permission)
        {
            Scope = scope;
            Type = type;
            Id = id;
            Permission = permission;

            Entry = $"{(Scope == DataLakeStoreEnums.ScopeType.Default ? "default:" : string.Empty)}{Type}:{Id}:{Permission}";
            NoPermissionEntry =
                $"{(Scope == DataLakeStoreEnums.ScopeType.Default ? "default:" : string.Empty)}{Type}:{Id}";
        }

        private DataLakeStoreEnums.AceType MapAclEntryType(AclType aclType)
        {
            switch (aclType)
            {
                case AclType.group: return DataLakeStoreEnums.AceType.Group;
                case AclType.user: return DataLakeStoreEnums.AceType.User;
                case AclType.mask: return DataLakeStoreEnums.AceType.Mask;
                case AclType.other: return DataLakeStoreEnums.AceType.Other;
                default: throw new ArgumentException("AclType is invalid");
            }
        }
        private AclType MapAceType(DataLakeStoreEnums.AceType aclType)
        {
            switch (aclType)
            {
                case DataLakeStoreEnums.AceType.Group: return AclType.group;
                case DataLakeStoreEnums.AceType.User: return AclType.user;
                case DataLakeStoreEnums.AceType.Mask : return AclType.mask;
                case DataLakeStoreEnums.AceType.Other: return AclType.other;
                default: throw new ArgumentException("AceType is invalid");
            }
        }
        internal DataLakeStoreItemAce(AclEntry entry)
        {
            Scope = (DataLakeStoreEnums.ScopeType)entry.Scope;
            Type = MapAclEntryType(entry.Type);
            Id = entry.UserOrGroupId;
            Permission = entry.Action.GetRwx();

            Entry = $"{(Scope == DataLakeStoreEnums.ScopeType.Default ? "default:":string.Empty)}{Type}:{Id}:{Permission}";
            NoPermissionEntry =
                $"{(Scope == DataLakeStoreEnums.ScopeType.Default ? "default:" : string.Empty)}{Type}:{Id}";
        }

        internal AclEntry ParseDataLakeStoreItemAce()
        {
            return new AclEntry(MapAceType(Type), Id,(AclScope)Scope, AclActionExtension.GetAclAction(Permission).Value);
        }
        public DataLakeStoreEnums.ScopeType Scope { get; set; }
        public DataLakeStoreEnums.AceType Type { get; set; }

        public string Id { get; set; }

        public string Permission { get; set; }

        public string Entry { get; set; }

        internal string NoPermissionEntry { get; set; }

        public static DataLakeStoreItemAce Parse(string aceString)
        {
            var aceList = aceString.Split(',');
            if(aceList.Length != 1)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidAce, aceString));
            }

            var scope = DataLakeStoreEnums.ScopeType.Access;
            var typeIndex = 0;
            var singleSpec = aceString.Split(':');
            if (singleSpec.Length == 4 && singleSpec[0].ToLowerInvariant().Equals("default"))
            {
                scope = DataLakeStoreEnums.ScopeType.Default;
                typeIndex = 1;
            }
            else if (singleSpec.Length != 3)
            {
                throw new InvalidOperationException(string.Format(Resources.InvalidAce, aceString));
            }

            switch (singleSpec[typeIndex].ToLowerInvariant())
            {
                case "group":
                    if (!string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                    {
                        // default group and regular group case
                        return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.Group, singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                    }
                    else if (string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                    {
                        // default owning group and regular owning group case
                        return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.Group, string.Empty, singleSpec[typeIndex + 2]);
                    }

                    throw new InvalidOperationException(string.Format(Resources.InvalidAce, aceString));
                case "user":
                    if (!string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                    {
                        // default user and regular user case
                        return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.User, singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                    }
                    else if (string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                    {
                        // default owner and owner case
                        return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.User, string.Empty, singleSpec[typeIndex + 2]);
                    }

                    throw new InvalidOperationException(string.Format(Resources.InvalidAce, aceString));
                case "mask":
                    return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.Mask, string.Empty, singleSpec[typeIndex + 2]);
                case "other":
                    return new DataLakeStoreItemAce(scope, DataLakeStoreEnums.AceType.Other, string.Empty, singleSpec[typeIndex + 2]);
                default:
                    throw new CloudException(string.Format(Resources.InvalidParseAce, aceString));
            }
        }

        internal static DataLakeStoreItemAce[] GetAclFromStatus(AclStatus aclStatus)
        {
            return aclStatus.Entries.Select(entry => new DataLakeStoreItemAce(entry)).ToArray();
        }

        internal static string GetAclSpec(DataLakeStoreItemAce[] aces, bool includePermission = true)
        {
            string toReturn = string.Empty;
            foreach(var item in aces)
            {
                toReturn += string.Format("{0},", includePermission ? item.Entry : item.NoPermissionEntry);
            }

            return toReturn.TrimEnd(',').ToLowerInvariant();
        }
    }
}