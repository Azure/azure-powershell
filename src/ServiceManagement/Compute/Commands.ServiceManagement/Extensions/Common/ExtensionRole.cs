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

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    public class ExtensionRole
    {
        protected const string DefaultExtensionIdPrefixStr = "Default";
        protected const string ExtensionIdSuffixTemplate = "-{0}-{1}-Ext-{2}";
        protected const int MaxExtensionIdLength = 60;
        protected const int MinRoleNamePartLength = 1;
        protected const int MaxSuffixLength = MaxExtensionIdLength - MinRoleNamePartLength;

        public string RoleName { get; private set; }
        public string PrefixName { get; private set; }
        public ExtensionRoleType RoleType { get; private set; }
        public bool Default { get; private set; }

        private static string RemoveDisallowedCharacters(string roleName)
        {
            // Remove characters that are not allowed in the extension id
            var disallowedCharactersRegex = new Regex(@"[^A-Za-z0-9\-]");
            return disallowedCharactersRegex.Replace(roleName, string.Empty);
        }

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
                PrefixName = RemoveDisallowedCharacters(PrefixName);
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
            var normalizedExtName = RemoveDisallowedCharacters(extensionName);

            var suffix = new StringBuilder();
            // Suffix format: -{extension_name_part}-{slot}-Ext-{index}
            suffix.AppendFormat(ExtensionIdSuffixTemplate, normalizedExtName, slot, index);
            if (suffix.Length > MaxSuffixLength)
            {
                // If the suffix is too long, truncate the {extension_name_part}
                int lenDiff = suffix.Length - MaxSuffixLength;
                int startIndex = 1; // Suffix starts with '-'
                suffix.Remove(startIndex + normalizedExtName.Length - lenDiff, lenDiff);
            }

            // Calculate the prefix length by the difference between the suffix and the max ID length.
            // The difference should always be at least 1.
            int prefixSubStrLen = Math.Min(Math.Max(MaxExtensionIdLength - suffix.Length, 0), PrefixName.Length);

            var result = new StringBuilder();
            result.Append(PrefixName, 0, prefixSubStrLen);
            result.Append(suffix);

            return result.ToString();
        }
    }
}
