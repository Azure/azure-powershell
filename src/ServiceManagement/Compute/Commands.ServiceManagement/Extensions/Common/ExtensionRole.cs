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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public class ExtensionRole
    {
        protected const string DefaultExtensionIdPrefixStr = "Default";
        protected const string ExtensionIdTemplate = "{0}-{1}-{2}-Ext-{3}";

        public string RoleName { get; private set; }
        public string PrefixName { get; private set; }
        public ExtensionRoleType RoleType { get; private set; }
        public bool Default { get; private set; }

        public ExtensionRole()
        {
            RoleName = string.Empty;
            RoleType = ExtensionRoleType.AllRoles;
            PrefixName = DefaultExtensionIdPrefixStr;
            Default = true;
        }

        public ExtensionRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                RoleName = string.Empty;
                RoleType = ExtensionRoleType.AllRoles;
                PrefixName = DefaultExtensionIdPrefixStr;
                Default = true;
            }
            else
            {
                PrefixName = RoleName = roleName.Trim();
                RoleType = ExtensionRoleType.NamedRoles;
                Default = false;
            }
        }

        public override string ToString()
        {
            return PrefixName;
        }

        public string GetExtensionId(string extensionName, string slot, int index)
        {
            return string.Format(ExtensionIdTemplate, PrefixName, extensionName, slot, index);
        }
    }
}
