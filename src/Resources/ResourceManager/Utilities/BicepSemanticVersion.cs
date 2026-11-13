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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parses and compares Bicep CLI release versions: "major[.minor[.patch]]", with
    /// omitted minor/patch defaulting to zero.
    /// </summary>
    internal class BicepSemanticVersion : IComparable<BicepSemanticVersion>
    {
        private static readonly Regex Pattern = new Regex(
            @"^(?<major>0|[1-9]\d*)(?:\.(?<minor>0|[1-9]\d*)(?:\.(?<patch>0|[1-9]\d*))?)?$",
            RegexOptions.Compiled);

        public int Major { get; }

        public int Minor { get; }

        public int Patch { get; }

        public BicepSemanticVersion(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public static bool TryParse(string text, out BicepSemanticVersion version)
        {
            version = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            var trimmed = text.Trim();

            var match = Pattern.Match(trimmed);
            if (!match.Success)
            {
                return false;
            }

            var minor = match.Groups["minor"].Success ? int.Parse(match.Groups["minor"].Value) : 0;
            var patch = match.Groups["patch"].Success ? int.Parse(match.Groups["patch"].Value) : 0;

            version = new BicepSemanticVersion(
                int.Parse(match.Groups["major"].Value),
                minor,
                patch);
            return true;
        }

        public static BicepSemanticVersion Parse(string text)
        {
            BicepSemanticVersion version;
            if (!TryParse(text, out version))
            {
                throw new FormatException($"'{text}' is not a valid version.");
            }

            return version;
        }

        public int CompareTo(BicepSemanticVersion other)
        {
            if (other == null)
            {
                return 1;
            }

            if (Major != other.Major)
            {
                return Major.CompareTo(other.Major);
            }

            if (Minor != other.Minor)
            {
                return Minor.CompareTo(other.Minor);
            }

            return Patch.CompareTo(other.Patch);
        }

        public override string ToString() => $"{Major}.{Minor}.{Patch}";
    }
}
