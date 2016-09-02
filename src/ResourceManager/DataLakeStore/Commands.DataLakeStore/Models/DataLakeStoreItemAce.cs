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
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders.
    /// </summary>
    public class DataLakeStoreItemAce
    {
        public DataLakeStoreItemAce(DataLakeStoreEnums.ScopeType scope, DataLakeStoreEnums.AceType type, string id, string permission)
        {
            Scope = scope;
            Type = type;
            Id = id;
            Permission = permission;

            Entry = string.Format("{0}{1}:{2}:{3}", Scope == DataLakeStoreEnums.ScopeType.Default ? "default:" : string.Empty, Type, Id, permission);
            NoPermissionEntry = string.Format("{0}{1}:{2}", Scope == DataLakeStoreEnums.ScopeType.Default ? "default:" : string.Empty, Type, Id);
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
            var toReturn = new DataLakeStoreItemAce[aclStatus.Entries.Count()];
            var index = 0;
            foreach(var entry in aclStatus.Entries)
            {
                toReturn[index++] = Parse(entry);
            }

            return toReturn;
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