﻿// ----------------------------------------------------------------------------------
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
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities
{
    // Role is a user friendly way of grouping together a set of permissions and their scopes
    [DataContract(Name = "Role", Namespace = UriElements.ServiceNamespace)]
    public class Role
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember(IsRequired = false)]
        public string Description { get; set; }

        [DataMember(IsRequired = false)]
        public PermissionScopePairs Permissions { get; set; }
    }

    /// <summary>
    /// Collection of Roles
    /// </summary>
    [CollectionDataContract(Namespace = UriElements.ServiceNamespace)]
    public class Roles : List<Role>
    {

        /// <summary>
        /// Empty collection
        /// </summary>
        public Roles(){ }

        /// <summary>
        /// Initialize collection
        /// </summary>
        /// <param name="roles"></param>
        public Roles(List<Role> roles) : base(roles) { }
    }
}
