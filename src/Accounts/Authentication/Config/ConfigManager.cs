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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Abstract implementation of <see cref="IConfigManager"/>, providing only the read ability to the configs.
    /// </summary>
    internal abstract class ConfigManager : IConfigManager
    {
        protected readonly ConcurrentDictionary<string, ConfigDefinition> _configDefinitionMap = new ConcurrentDictionary<string, ConfigDefinition>(StringComparer.OrdinalIgnoreCase);
        protected IConfigurationRoot _root;

        /// <summary>
        /// Path of the config file.
        /// </summary>
        public abstract string ConfigFilePath { get; protected set; }

        /// <summary>
        /// Retrieve data from all the providers and build config values.
        /// </summary>
        public abstract void BuildConfig();

        /// <summary>
        /// Clear a config set previously.
        /// </summary>
        /// <remarks>This is a simple version of <see cref="ClearConfig(ClearConfigOptions)"/>.</remarks>
        /// <param name="key">Key of the config to clear.</param>
        /// <param name="scope">Scope of the config to update.</param>
        public void ClearConfig(string key, ConfigScope scope) => ClearConfig(new ClearConfigOptions(key, scope));

        /// <summary>
        /// Clear a config set previously.
        /// </summary>
        /// <param name="options">Specify the key, and optionally scope and appliesTo etc. to update.</param>
        public abstract void ClearConfig(ClearConfigOptions options);

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
        public virtual T GetConfigValue<T>(string key, object invocation = null)
        {
            if (invocation != null && !(invocation is InvocationInfo))
            {
                throw new AzPSArgumentException($"Type error: type of {nameof(invocation)} must be {nameof(InvocationInfo)}", nameof(invocation));
            }
            return GetConfigValueInternal<T>(key, new InvocationInfoAdapter((InvocationInfo)invocation));
        }

        internal T GetConfigValueInternal<T>(string key, InternalInvocationInfo invocation) => (T)GetConfigValueInternal(key, invocation);

        internal object GetConfigValueInternal(string key, InternalInvocationInfo invocation)
        {
            _ = key ?? throw new AzPSArgumentNullException($"{nameof(key)} cannot be null.", nameof(key));
            if (!_configDefinitionMap.TryGetValue(key, out ConfigDefinition definition) || definition == null)
            {
                throw new AzPSArgumentException($"Config with key [{key}] was not registered.", nameof(key));
            }

            foreach (var path in ConfigPathHelper.EnumerateConfigPaths(key, invocation))
            {
                IConfigurationSection section = _root.GetSection(path);
                if (section.Exists())
                {
                    (object value, _) = GetConfigValueOrDefault(section, definition);
                    WriteDebug($"[ConfigManager] Got [{value}] from [{key}], Module = [{invocation?.ModuleName}], Cmdlet = [{invocation?.CmdletName}].");
                    return value;
                }
            }

            WriteDebug($"[ConfigManager] Got nothing from [{key}], Module = [{invocation?.ModuleName}], Cmdlet = [{invocation?.CmdletName}]. Returning default value [{definition.DefaultValue}].");
            return definition.DefaultValue;
        }

        /// <summary>
        /// Get the value and the ID of the corresponding provider of the config.
        /// </summary>
        /// <param name="section">The section that stores the config.</param>
        /// <param name="definition">The definition of the config.</param>
        /// <returns>A tuple containing the value of the config and the ID of the provider from which the value is got.</returns>
        /// <remarks>Exceptions are handled gracefully in this method.</remarks>
        protected (object value, string providerId) GetConfigValueOrDefault(IConfigurationSection section, ConfigDefinition definition)
        {
            try
            {
                return section.Get(definition.ValueType);
            }
            catch (InvalidOperationException ex)
            {
                WriteWarning($"[ConfigManager] Failed to get value for [{definition.Key}]. Using the default value [{definition.DefaultValue}] instead. Error: {ex.Message}. {ex.InnerException?.Message}");
                WriteDebug($"[ConfigManager] Exception: {ex.Message}, stack trace: \n{ex.StackTrace}");
                return (definition.DefaultValue, Constants.ConfigProviderIds.None);
            }
        }

        /// <summary>
        /// List all the definitions of all the registered configs.
        /// </summary>
        public IEnumerable<ConfigDefinition> ListConfigDefinitions()
        {
            return _configDefinitionMap.OrderBy(x => x.Key).Select(x => x.Value);
        }

        /// <summary>
        /// List all configs with values.
        /// </summary>
        /// <param name="filter">Filter the result by config key or level etc.</param>
        public abstract IEnumerable<ConfigData> ListConfigs(ConfigFilter filter = null);

        /// <summary>
        /// Register a config.
        /// </summary>
        /// <remarks>Register all the configs before <see cref="BuildConfig"/></remarks>
        public virtual void RegisterConfig(ConfigDefinition config)
        {
            // check if key already taken
            if (_configDefinitionMap.ContainsKey(config.Key))
            {
                if (_configDefinitionMap[config.Key] == config)
                {
                    Debug.WriteLine($"Config with key [{config.Key}] was registered twice");
                }
                else
                {
                    throw new AzPSArgumentException($"Duplicated config key. [{config.Key}] was already taken.", nameof(config.Key));
                }
                return;
            }
            _configDefinitionMap[config.Key] = config;
        }

        /// <summary>
        /// Update the value of a config.
        /// </summary>
        /// <param name="key">Key of the config.</param>
        /// <param name="value">Value to update.</param>
        /// <param name="scope">Scope of the config to update.</param>
        /// <remarks>This is a simple version of <see cref="UpdateConfig(UpdateConfigOptions)"/>.</remarks>
        /// <returns>The updated config, both definition and value.</returns>
        public ConfigData UpdateConfig(string key, object value, ConfigScope scope) => UpdateConfig(new UpdateConfigOptions(key, value, scope));

        /// <summary>
        /// Update the value of a config.
        /// </summary>
        /// <param name="options">Specify the key, value, and optionally scope and appliesTo etc. to update.</param>
        /// <returns>The updated config, both definition and value.</returns>
        public abstract ConfigData UpdateConfig(UpdateConfigOptions options);

        protected void WriteDebug(string message)
        {
            WriteMessage(message, AzureRMCmdlet.WriteDebugKey);
        }

        private void WriteMessage(string message, string eventHandlerKey)
        {
            try
            {
                if (AzureSession.Instance.TryGetComponent(eventHandlerKey, out EventHandler<StreamEventArgs> writeDebug))
                {
                    writeDebug.Invoke(this, new StreamEventArgs() { Message = message });
                }
            }
            catch (Exception)
            {
                // do not throw when session is not initialized
            }
        }

        protected void WriteWarning(string message)
        {
            WriteMessage(message, AzureRMCmdlet.WriteWarningKey);
        }
    }
}
