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

using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.PowerShell.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Helper class to deal with AppliesTo (how large is the scope that the config affects Azure PowerShell).
    /// </summary>
    public static class AppliesToHelper
    {
        /// <summary>
        /// Tries to parse a user-input text to an <see cref="AppliesTo"/> enum.
        /// </summary>
        /// <param name="text">Input from user.</param>
        /// <param name="appliesTo">Result if successful.</param>
        /// <returns>True if parsed successfully.</returns>
        public static bool TryParseAppliesTo(string text, out AppliesTo appliesTo)
        {
            if (string.IsNullOrEmpty(text) || string.Equals(ConfigFilter.GlobalAppliesTo, text, StringComparison.OrdinalIgnoreCase))
            {
                appliesTo = AppliesTo.Az;
                return true;
            }

            if (PSNamingUtilities.IsModuleName(text))
            {
                appliesTo = AppliesTo.Module;
                return true;
            }

            if (PSNamingUtilities.IsCmdletName(text))
            {
                appliesTo = AppliesTo.Cmdlet;
                return true;
            }

            appliesTo = AppliesTo.Az;
            return false;
        }

        /// <summary>
        /// Gets a comma-divided string for human-readable description of the AppliesTo options.
        /// </summary>
        /// <param name="options">Options of AppliesTo.</param>
        /// <returns>The formated string.</returns>
        internal static string FormatOptions(IReadOnlyCollection<AppliesTo> options)
        {
            if (options == null || !options.Any())
            {
                throw new ArgumentException($"Make sure the config definition has a non-empty {nameof(ConfigDefinition.CanApplyTo)}.", nameof(options));
            }
            var sb = new StringBuilder();
            bool isFirst = true;
            foreach (var option in options)
            {
                if (!isFirst)
                {
                    sb.Append(", ");
                    isFirst = false;
                }
                switch (option)
                {
                    case AppliesTo.Az:
                        sb.Append(ConfigFilter.GlobalAppliesTo);
                        break;
                    case AppliesTo.Cmdlet:
                        sb.Append("name of a cmdlet");
                        break;
                    case AppliesTo.Module:
                        sb.Append("name of a module");
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
