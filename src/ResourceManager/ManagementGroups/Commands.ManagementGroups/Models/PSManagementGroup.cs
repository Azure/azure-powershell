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
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroup
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public System.DateTime? UpdatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public string ParentId { get; set; }

        public string ParentDisplayName { get; set; }

        public IList<PSManagementGroupChildInfo> Children { get; private set; }


        public PSManagementGroup()
        {
        }

        public PSManagementGroup(ManagementGroup managementGroup)
        {
            if (managementGroup != null)
            {
                Id = managementGroup.Id;
                Type = managementGroup.Type;
                Name = managementGroup.Name;
                TenantId = managementGroup.TenantId;
                DisplayName = managementGroup.DisplayName;
                UpdatedTime = managementGroup.Details.UpdatedTime;
                UpdatedBy = managementGroup.Details.UpdatedBy;

                if (managementGroup.Details.Parent != null)
                {
                    if (managementGroup.Details.Parent.ParentId != null)
                    {
                        ParentId = managementGroup.Details.Parent.ParentId;
                    }
                    if (managementGroup.Details.Parent.DisplayName != null)
                    {
                        ParentDisplayName = managementGroup.Details.Parent.DisplayName;
                    }
                }

                if (managementGroup.Children != null)
                {
                    this.Children = managementGroup.Children.Select(child => new PSManagementGroupChildInfo(child)).ToList();
                }
            }
        }
    }
}
