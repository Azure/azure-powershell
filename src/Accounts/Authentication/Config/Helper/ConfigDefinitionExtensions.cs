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

using Microsoft.Azure.PowerShell.Common.Config;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    public static class ConfigDefinitionExtensions
    {
        /// <summary>
        /// Convert a <see cref="ConfigDefinition"/> to a <see cref="ConfigData"/>
        /// representing the definition with its default value.
        /// </summary>
        /// <param name="configDefinition">Definition of the config.</param>
        public static ConfigData ToDefaultConfigData(this ConfigDefinition configDefinition)
        {
            return new ConfigData(configDefinition,
               configDefinition.DefaultValue,
               ConfigScope.Default,
               ConfigFilter.GlobalAppliesTo);
        }
    }
}
