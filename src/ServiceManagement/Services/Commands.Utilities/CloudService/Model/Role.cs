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

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.Model
{
    public class Role
    {
        private readonly List<ConfigurationSet> configurationSets = new List<ConfigurationSet>(); 

        public Role()
        {
        }

        public Role(Management.Compute.Models.Role role)
        {
            RoleName = role.RoleName;
            OsVersion = role.OSVersion;
            RoleType = role.RoleType;
            configurationSets.AddRange(role.ConfigurationSets.Select(cs => new ConfigurationSet(cs)));
        }

        public string RoleName { get; set; }
        public string OsVersion { get; set; }
        public string RoleType { get; set; }
        public IList<ConfigurationSet> ConfigurationSets { get { return configurationSets; } }
    }
}
