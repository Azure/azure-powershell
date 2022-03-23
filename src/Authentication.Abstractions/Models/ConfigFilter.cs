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

namespace Microsoft.Azure.PowerShell.Common.Config
{
    /// <summary>
    /// Filter options for listing configurations. Used as input of some API of <see cref="IConfigManager" />
    /// </summary>
    public class ConfigFilter
    {
        /// <summary>
        /// Represents the global config "applies to" - the config applies to all cmdlets of Azure PowerShell.
        /// </summary>
        public const string GlobalAppliesTo = "Az";

        /// <summary>
        /// Keys of the configs to filter. When omitted, all the keys will be used.
        /// </summary>
        public IEnumerable<string> Keys { get; set; } = null;

        /// <summary>
        /// Specifies what part of Azure PowerShell the config applies to.
        /// </summary>
        /// <remarks>
        /// Possible values are:
        /// - null: the config applies to any of above.
        /// - <see cref="GlobalAppliesTo"/> ("Az"): the config applies to all modules and cmdlets of Azure PowerShell.
        /// - Name of a module: the config applies to a certain module of Azure PowerShell. For example, "Az.Storage".
        /// - Name of a cmdlet: the config applies to a certain cmdlet of Azure PowerShell. For example, "Get-AzKeyVault".
        /// </remarks>
        public string AppliesTo { get; set; } = null;
    }
}
