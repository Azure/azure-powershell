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

namespace Microsoft.Azure.PowerShell.Common.Config
{
    public interface IConfigManager
    {
        /// <summary>
        /// Path of the config file.
        /// </summary>
        string ConfigFilePath { get; }

        /// <summary>
        /// Register a config.
        /// </summary>
        /// <remarks>Register all the configs before <see cref="BuildConfig"/></remarks>
        void RegisterConfig(ConfigDefinition config);

        /// <summary>
        /// Retrieve data from all the providers and build config values.
        /// </summary>
        void BuildConfig();

        /// <summary>
        /// Get the value of a config by key.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="key">Key of the config.</param>
        /// <param name="invocation">PowerShell cmdlet invocation info. If not null, the config that matches the module or cmdlet name will be returned.</param>
        /// <remarks>For the list of available keys, see <see cref="ConfigKeys"/>, for those used in service projects, or see <see cref="ConfigKeysForCommon"/> for those used in common projects.
        /// The `invocation` parameter is typed `object` because we don't want Authentication.Abstractions project to take dependency on PowerShell SDK.
        /// However at runtime it needs to be of type `InvocationInfo`.</remarks>
        /// <returns>Value of the config, or the default value if never set.</returns>
        T GetConfigValue<T>(string key, object invocation = null);

        /// <summary>
        /// List all configs with values.
        /// </summary>
        /// <param name="filter">Filter the result by config key or level etc.</param>
        IEnumerable<ConfigData> ListConfigs(ConfigFilter filter = null);

        /// <summary>
        /// List all the definitions of all the registered configs.
        /// </summary>
        IEnumerable<ConfigDefinition> ListConfigDefinitions();

        /// <summary>
        /// Update the value of a config.
        /// </summary>
        /// <param name="key">Key of the config.</param>
        /// <param name="value">Value to update.</param>
        /// <param name="scope">Scope of the config to update.</param>
        /// <remarks>This is a simple version of <see cref="UpdateConfig(UpdateConfigOptions)"/>.</remarks>
        /// <returns>The updated config, both definition and value.</returns>
        ConfigData UpdateConfig(string key, object value, ConfigScope scope);

        /// <summary>
        /// Update the value of a config.
        /// </summary>
        /// <param name="options">Specify the key, value, and optionally scope and appliesTo etc. to update.</param>
        /// <returns>The updated config, both definition and value.</returns>
        ConfigData UpdateConfig(UpdateConfigOptions options);

        /// <summary>
        /// Clear a config set previously.
        /// </summary>
        /// <remarks>This is a simple version of <see cref="ClearConfig(ClearConfigOptions)"/>.</remarks>
        /// <param name="key">Key of the config to clear.</param>
        /// <param name="scope">Scope of the config to update.</param>
        void ClearConfig(string key, ConfigScope scope);

        /// <summary>
        /// Clear a config set previously.
        /// </summary>
        /// <param name="options">Specify the key, and optionally scope and appliesTo etc. to update.</param>
        void ClearConfig(ClearConfigOptions options);
    }
}
