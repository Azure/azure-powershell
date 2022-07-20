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

using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <summary>
    /// Utility class about PowerShell naming (cmdlet name, module name).
    /// </summary>
    /// <remarks>
    /// All the mothods are within Azure PowerShell context, for example, module name should start with "Az.".
    /// </remarks>
    public static class PSNamingUtilities
    {
        private static readonly Regex ModulePattern = new Regex(@"^az\.[a-z]+$", RegexOptions.IgnoreCase);
        private static readonly Regex CmdletPattern = new Regex(@"^[a-z]+-[a-z\d]+$", RegexOptions.IgnoreCase);
        private static readonly Regex ModuleOrCmdletPattern = new Regex(@"^az\.[a-z]+$|^[a-z]+-[a-z\d]+$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Returns if the given <paramref name="moduleName"/> is a valid module name.
        /// </summary>
        /// <remarks>
        /// This method only does pattern-matching. It does not check if the name is real.
        /// </remarks>
        public static bool IsModuleName(string moduleName)
        {
            return ModulePattern.IsMatch(moduleName);
        }

        /// <summary>
        /// Returns if the given <paramref name="cmdletName"/> is a valid cmdlet name.
        /// </summary>
        /// <remarks>
        /// This method only does pattern-matching. It does not check if the name is real.
        /// </remarks>
        public static bool IsCmdletName(string cmdletName)
        {
            return CmdletPattern.IsMatch(cmdletName);
        }

        /// <summary>
        /// Returns if the given <paramref name="moduleOrCmdletName"/> is a valid module name or cmdlet name.
        /// </summary>
        /// <remarks>
        /// This method only does pattern-matching. It does not check if the name is real.
        /// </remarks>
        public static bool IsModuleOrCmdletName(string moduleOrCmdletName)
        {
            return ModuleOrCmdletPattern.IsMatch(moduleOrCmdletName);
        }
    }
}
