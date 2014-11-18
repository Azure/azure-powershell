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
using System.Globalization;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class IdnHelper
    {
        private const string idnHostNamePrefix = "xn--";

        private static IdnMapping idnMapping = new IdnMapping();

        public static string GetUnicode(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Contains(idnHostNamePrefix))
            {
                try
                {
                    name = idnMapping.GetUnicode(name);
                }
                catch (ArgumentException)
                {
                    // In the case of invalid punycode we will use the original name.
                }
            }

            return name;
        }

        public static string GetUnicodeForUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Contains(idnHostNamePrefix))
            {
                // Handle "$<name>" and "<username>@<domain>" in a specific way.
                if (name.StartsWith("$"))
                {
                    return "$" + GetUnicode(name.Substring(1));
                }

                string[] parts = name.Split('@');
                if (parts.Length == 2)
                {
                    return GetUnicode(parts[0]) + "@" + GetUnicode(parts[1]);
                }

                // Fall through.
                return GetUnicode(name);
            }

            return name;
        }

        public static string GetAscii(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    name = idnMapping.GetAscii(name);
                }
                catch (ArgumentException)
                {
                    // In the case of invalid unicode we will use the original name.
                }
            }

            return name;
        }

        public static string GetAsciiForUserName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Handle "$<name>" and "<username>@<domain>" in a specific way.
                if (name.StartsWith("$"))
                {
                    return "$" + GetAscii(name.Substring(1));
                }

                string[] parts = name.Split('@');
                if (parts.Length == 2)
                {
                    return GetAscii(parts[0]) + "@" + GetAscii(parts[1]);
                }

                // Fall through.
                return GetAscii(name);
            }

            return name;
        }
    }
}
