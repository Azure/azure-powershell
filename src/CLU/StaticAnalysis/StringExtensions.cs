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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StaticAnalysis
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string input)
        {
            var trimmed = input.Trim();
            var result = trimmed;
            if (!string.IsNullOrWhiteSpace(trimmed))
            {
                if (trimmed.Length < 4)
                {
                    result = trimmed.ToLower();
                }
                trimmed = Regex.Replace(trimmed, "^VM", "vm");
                trimmed = Regex.Replace(trimmed, "^AD", "ad");
                trimmed = Regex.Replace(trimmed, "^SPN", "spn");
                trimmed = Regex.Replace(trimmed, "^PS", "ps");
                result = trimmed.Substring(0, 1).ToLower();
                if (trimmed.Length > 1)
                {
                    result += trimmed.Substring(1);
                }
            }

            return result;
        }

        public static string GetEntityName(this string input)
        {
            var trimmed = input.Trim();
            var result = trimmed;
            if (!string.IsNullOrWhiteSpace(trimmed))
            {
                if (trimmed.Length < 4)
                {
                    result = trimmed.ToLower();
                }
                trimmed = Regex.Replace(trimmed, "^VM", "virtual machine ");
                trimmed = Regex.Replace(trimmed, "^AD", "acive directory ");
                trimmed = Regex.Replace(trimmed, "^SPN", "service principal ");
                trimmed = Regex.Replace(trimmed, "([a-z])([A-Z]+)", "$1 $2");
                result = trimmed.ToLower().Trim();
            }

            return result;
        }

        public static int CommandOrder(this string command)
        {
            var trimmed = command.Trim();
            var result = 2;
            if (trimmed.EndsWith("create"))
            {
                result = 0;
            }
            else if (trimmed.EndsWith("ls"))
            {
                result = 1;
            }

            return result;
        }
    }
}
