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
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.Resources.Models.ManagementGroups
{
    public class PSEntityInfo
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public string Parent { get; private set; }

        public string Permissions { get; private set; }

        public string InheritedPermissions { get; private set; }

        public int? NumberOfDescendants { get; private set; }

        //public int? NumberOfChildren { get; private set; }

        //public int? NumberOfChildGroups { get; private set; }

        public IList<string> ParentDisplayNameChain { get; private set; }

        public IList<string> ParentNameChain { get; private set; }

        public PSEntityInfo(EntityInfo entityInfo)
        {
            Id = entityInfo.Id;
            Type = entityInfo.Type;
            Name = entityInfo.Name;
            TenantId = entityInfo.TenantId;
            DisplayName = entityInfo.DisplayName;
            Parent = entityInfo.Parent.Id;
            Permissions = entityInfo.Permissions;
            InheritedPermissions = entityInfo.InheritedPermissions;
            NumberOfDescendants = entityInfo.NumberOfDescendants;
            //NumberOfChildren = entityInfo.NumberOfChildren;
            //NumberOfChildGroups = entityInfo.NumberOfChildGroups;
            ParentDisplayNameChain = entityInfo.ParentDisplayNameChain;
            ParentNameChain = entityInfo.ParentNameChain;
        }
    }
}
