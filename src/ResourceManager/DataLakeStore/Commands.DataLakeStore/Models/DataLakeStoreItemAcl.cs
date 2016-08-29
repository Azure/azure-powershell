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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    /// <summary>
    /// The object that is used to manage permissions for files and folders.
    /// </summary>
    public class DataLakeStoreItemAcl
    {
        public DataLakeStoreItemAcl()
        {
            IsInitialized = false;
        }

        public Hashtable GroupAces { get; set; }
        public Hashtable UserAces { get; set; }
        public Hashtable DefaultGroupAces { get; set; }
        public Hashtable DefaultUserAces { get; set; }
        public string OwnerPermission { get; set; }
        public string OwningGroupPermission { get; set; }
        public string DefaultOwnerPermission { get; set; }
        public string DefaultOwningGroupPermission { get; set; }
        public string MaskPermission { get; set; }
        public string OtherPermission { get; set; }
        public string DefaultMaskPermission { get; set; }
        public string DefaultOtherPermission { get; set; }
        internal bool IsInitialized { get; set; }

        public static DataLakeStoreItemAcl Parse(string aceString)
        {
            var aceList = aceString.Split(',');
            var groupAces = new Hashtable();
            var userAces = new Hashtable();
            var defaultGroupAces = new Hashtable();
            var defaultUserAces = new Hashtable();
            var defaultOtherAce = string.Empty;
            var otherAce = string.Empty;
            var defaultMaskAce = string.Empty;
            var maskAce = string.Empty;
            var defaultOwnerPermissions = string.Empty;
            var defaultOwningGroupPermissions = string.Empty;
            var ownerPermissions = string.Empty;
            var owningGroupPermissions = string.Empty;
            foreach (var ace in aceList)
            {
                var isDefaultAce = false;
                var typeIndex = 0;
                var singleSpec = ace.Split(':');
                if (singleSpec.Length == 4 && singleSpec[0].ToLowerInvariant().Equals("default"))
                {
                    isDefaultAce = true;
                    typeIndex = 1;
                }
                else if (singleSpec.Length != 3)
                {
                    throw new CloudException(string.Format(Resources.InvalidAce, ace));
                }

                switch (singleSpec[typeIndex].ToLowerInvariant())
                {
                    case "group":
                        if (isDefaultAce && !string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default group case
                            defaultGroupAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default owning group case
                            defaultOwningGroupPermissions = singleSpec[typeIndex + 2];
                        }
                        else if (!string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // group case
                            groupAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (!isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // owning group case
                            owningGroupPermissions = singleSpec[typeIndex + 2];
                        }
                        break;
                    case "user":
                        if (isDefaultAce && !string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default user case
                            defaultUserAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default owner case
                            defaultOwnerPermissions = singleSpec[typeIndex + 2];
                        }
                        else if (!string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // user case
                            userAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (!isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // owner case
                            ownerPermissions = singleSpec[typeIndex + 2];
                        }
                        break;
                    case "mask":
                        if (isDefaultAce)
                        {
                            defaultMaskAce = singleSpec[typeIndex + 2];
                        }
                        else
                        {
                            maskAce = singleSpec[typeIndex + 2];
                        }
                        break;
                    case "other":
                        if (isDefaultAce)
                        {
                            defaultOtherAce = singleSpec[typeIndex + 2];
                        }
                        else
                        {
                            otherAce = singleSpec[typeIndex + 2];
                        }
                        break;
                    default:
                        throw new CloudException(string.Format(Resources.InvalidParseAce, ace));
                }
            }

            return new DataLakeStoreItemAcl
            {
                IsInitialized = true,
                GroupAces = groupAces,
                UserAces = userAces,
                DefaultGroupAces = defaultGroupAces,
                DefaultUserAces = defaultUserAces,
                OtherPermission = otherAce,
                DefaultOtherPermission = defaultOtherAce,
                MaskPermission = maskAce,
                DefaultMaskPermission = defaultMaskAce,
                OwnerPermission = ownerPermissions,
                OwningGroupPermission = owningGroupPermissions,
                DefaultOwnerPermission = defaultOwnerPermissions,
                DefaultOwningGroupPermission = defaultOwningGroupPermissions
            };
        }

        internal string GetAclSpec(bool includePermissions = true)
        {
            List<string> toReturn;
            if (includePermissions)
            {
                toReturn =
                    (from object entry in GroupAces.Keys select string.Format("group:{0}:{1}", entry, GroupAces[entry]))
                        .ToList();

                toReturn.AddRange(from object entry in UserAces.Keys
                                  select string.Format("user:{0}:{1}", entry, UserAces[entry]));

                toReturn.AddRange(from object entry in DefaultUserAces.Keys
                                  select string.Format("default:user:{0}:{1}", entry, DefaultUserAces[entry]));

                toReturn.AddRange(from object entry in DefaultGroupAces.Keys
                                  select string.Format("default:group:{0}:{1}", entry, DefaultGroupAces[entry]));

                if (!string.IsNullOrEmpty(MaskPermission))
                {
                    toReturn.Add(string.Format("mask::{0}", MaskPermission));
                }

                if (!string.IsNullOrEmpty(OtherPermission))
                {
                    toReturn.Add(string.Format("other::{0}", OtherPermission));
                }

                if (!string.IsNullOrEmpty(DefaultMaskPermission))
                {
                    toReturn.Add(string.Format("default:mask::{0}", DefaultMaskPermission));
                }

                if (!string.IsNullOrEmpty(DefaultOtherPermission))
                {
                    toReturn.Add(string.Format("default:other::{0}", DefaultOtherPermission));
                }

                if (!string.IsNullOrEmpty(OwnerPermission))
                {
                    toReturn.Add(string.Format("user::{0}", OwnerPermission));
                }

                if (!string.IsNullOrEmpty(OwningGroupPermission))
                {
                    toReturn.Add(string.Format("group::{0}", OwningGroupPermission));
                }

                if (!string.IsNullOrEmpty(DefaultOwnerPermission))
                {
                    toReturn.Add(string.Format("default:user::{0}", DefaultOwnerPermission));
                }

                if (!string.IsNullOrEmpty(DefaultOwningGroupPermission))
                {
                    toReturn.Add(string.Format("default:group::{0}", DefaultOwningGroupPermission));
                }
            }
            else
            {
                toReturn =
                    (from object entry in GroupAces.Keys select string.Format("group:{0}", entry))
                        .ToList();

                toReturn.AddRange(from object entry in UserAces.Keys
                                  select string.Format("user:{0}", entry));

                toReturn.AddRange(from object entry in DefaultUserAces.Keys
                                  select string.Format("default:user:{0}", entry));

                toReturn.AddRange(from object entry in DefaultGroupAces.Keys
                                  select string.Format("default:group:{0}", entry));
            }

            return string.Join(",", toReturn);
        }

        internal void InitializeAces(AclStatus aclStatus)
        {
            GroupAces = new Hashtable();
            UserAces = new Hashtable();
            DefaultGroupAces = new Hashtable();
            DefaultUserAces = new Hashtable();

            foreach (var entry in aclStatus.Entries)
            {
                var isDefaultAce = false;
                var typeIndex = 0;
                var singleSpec = entry.Split(':');
                if (singleSpec.Length == 4 && singleSpec[0].ToLowerInvariant().Equals("default"))
                {
                    isDefaultAce = true;
                    typeIndex = 1;
                }
                else if (singleSpec.Length != 3)
                {
                    throw new CloudException(string.Format(Resources.InvalidAce, entry));
                }

                switch (singleSpec[typeIndex].ToLowerInvariant())
                {
                    case "group":
                        if (isDefaultAce && !string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default groups
                            DefaultGroupAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default owning group permissions
                            DefaultOwningGroupPermission = singleSpec[typeIndex + 2];
                        }
                        else if (!isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // owning group permissions
                            OwningGroupPermission = singleSpec[typeIndex + 2];
                        }
                        else
                        {
                            // regular groups
                            GroupAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        break;
                    case "user":
                        if (isDefaultAce && !string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default users
                            DefaultUserAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        else if (isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // default owner permissions
                            DefaultOwnerPermission = singleSpec[typeIndex + 2];
                        }
                        else if (!isDefaultAce && string.IsNullOrEmpty(singleSpec[typeIndex + 1]))
                        {
                            // owner permissions
                            OwnerPermission = singleSpec[typeIndex + 2];
                        }
                        else
                        {
                            // user aces
                            UserAces.Add(singleSpec[typeIndex + 1], singleSpec[typeIndex + 2]);
                        }
                        break;
                    case "mask":
                        MaskPermission = singleSpec[typeIndex + 2];
                        break;
                    case "other":
                        OtherPermission = singleSpec[typeIndex + 2];
                        break;
                    default:
                        throw new CloudException(string.Format(Resources.InvalidAce, entry));
                }
            }

            IsInitialized = true;
        }
    }
}