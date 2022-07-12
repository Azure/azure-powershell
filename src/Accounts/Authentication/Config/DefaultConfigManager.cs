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

using Microsoft.Azure.Commands.Common.Authentication.Config.Internal;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Providers;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Default implementation of <see cref="IConfigManager"/>, providing full CRUD abilities and all of the config providers.
    /// </summary>
    internal class DefaultConfigManager : ConfigManager
    {
        /// <inheritdoc/>
        public override string ConfigFilePath { get; protected set; }

        private readonly ConcurrentDictionary<string, EnvironmentVariableConfigurationParser> EnvironmentVariableParsers = new ConcurrentDictionary<string, EnvironmentVariableConfigurationParser>();
        private readonly IEnvironmentVariableProvider _environmentVariableProvider;
        private readonly IDataStore _dataStore;
        private readonly JsonConfigHelper _jsonConfigHelper;
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private IDictionary<string, string> _processLevelConfigs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Creates an instance of <see cref="ConfigManager"/>.
        /// </summary>
        /// <param name="configFilePath">Path to the config file.</param>
        /// <param name="dataStore">Provider of file system APIs.</param>
        /// <param name="environmentVariableProvider">Provider of environment variable APIs.</param>
        internal DefaultConfigManager(string configFilePath, IDataStore dataStore, IEnvironmentVariableProvider environmentVariableProvider)
        {
            _ = dataStore ?? throw new AzPSArgumentNullException($"{nameof(dataStore)} cannot be null.", nameof(dataStore));
            _ = configFilePath ?? throw new AzPSArgumentNullException($"{nameof(configFilePath)} cannot be null.", nameof(configFilePath));
            _ = environmentVariableProvider ?? throw new AzPSArgumentNullException($"{nameof(environmentVariableProvider)} cannot be null.", nameof(environmentVariableProvider));
            ConfigFilePath = configFilePath;
            _environmentVariableProvider = environmentVariableProvider;
            _dataStore = dataStore;
            _jsonConfigHelper = new JsonConfigHelper(ConfigFilePath, _dataStore);
        }

        /// <inheritdoc/>
        public override void BuildConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonStream(Constants.ConfigProviderIds.UserConfig, _dataStore.ReadFileAsStream(ConfigFilePath))
                .AddEnvironmentVariables(Constants.ConfigProviderIds.EnvironmentVariable, new EnvironmentVariablesConfigurationOptions()
                {
                    EnvironmentVariableProvider = _environmentVariableProvider,
                    EnvironmentVariableTarget = EnvironmentVariableTarget.Process,
                    EnvironmentVariableParsers = EnvironmentVariableParsers
                })
                .AddUnsettableInMemoryCollection(Constants.ConfigProviderIds.ProcessConfig, _processLevelConfigs);

            _lock.EnterReadLock();
            try
            {
                _root = builder.Build();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        /// <inheritdoc/>
        public override void RegisterConfig(ConfigDefinition config)
        {
            base.RegisterConfig(config);
            // configure environment variable provider
            EnvironmentVariableParsers[config.Key] = config.ParseFromEnvironmentVariables;
        }

        /// <inheritdoc/>
        public override IEnumerable<ConfigData> ListConfigs(ConfigFilter filter = null)
        {
            string filterProviderId = null;
            bool filterByScope = filter != null && filter.Scope.HasValue;
            if (filterByScope)
            {
                filterProviderId = ConfigScopeHelper.GetProviderIdByScope(filter.Scope.Value);
            }

            IList<ConfigData> results = new List<ConfigData>();
            ISet<string> noNeedForDefault = new HashSet<string>();

            // if not filtering by default scope, include all values
            if (filterProviderId != Constants.ConfigProviderIds.None)
            {
                foreach (var appliesToSection in _root.GetChildren())
                {
                    foreach (var configSection in appliesToSection.GetChildren())
                    {
                        string key = configSection.Key;
                        if (_configDefinitionMap.TryGetValue(key, out var configDefinition))
                        {
                            if (filterByScope)
                            {
                                // try getting the config by the specific provider ID
                                object value = GetConfigValueOrDefault(configSection, configDefinition, filterProviderId);
                                if (value != null)
                                {
                                    results.Add(new ConfigData(configDefinition, value, filter.Scope.Value, appliesToSection.Key));
                                }
                            }
                            else
                            {
                                (object value, string providerId) = GetConfigValueOrDefault(configSection, configDefinition);
                                ConfigScope scope = ConfigScopeHelper.GetScopeByProviderId(providerId);
                                results.Add(new ConfigData(configDefinition, value, scope, appliesToSection.Key));
                                // if a config is already set at global level, there's no need to return its default value
                                if (string.Equals(ConfigFilter.GlobalAppliesTo, appliesToSection.Key, StringComparison.OrdinalIgnoreCase))
                                {
                                    noNeedForDefault.Add(configDefinition.Key);
                                }
                            }
                        }
                    }
                }
            }

            IEnumerable<string> keys = filter?.Keys ?? Enumerable.Empty<string>();

            // include default values
            if (filterByScope && filter.Scope.Value == ConfigScope.Default || !filterByScope)
            {
                bool isRegisteredKey(string key) => _configDefinitionMap.Keys.Contains(key, StringComparer.OrdinalIgnoreCase);
                IEnumerable<ConfigDefinition> configDefinitions = keys.Any() ? keys.Where(isRegisteredKey).Select(key => _configDefinitionMap[key]) : _configDefinitionMap.Select(x => x.Value);
                configDefinitions.Where(x => !noNeedForDefault.Contains(x.Key)).Select(x => x.ToDefaultConfigData()).ForEach(x => results.Add(x));
            }

            // filter by keys
            if (keys.Any())
            {
                results = results.Where(x => keys.Contains(x.Definition.Key, StringComparer.OrdinalIgnoreCase)).ToList();
            }

            // filter by appliesTo
            string appliesTo = filter?.AppliesTo;
            if (!string.IsNullOrEmpty(appliesTo))
            {
                results = results.Where(x => string.Equals(appliesTo, x.AppliesTo, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return results.OrderBy(configData => configData.Definition.Key);
        }


        /// <summary>
        /// Gets the value of a config from only the specified provider.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="definition"></param>
        /// <param name="providerId"></param>
        /// <returns></returns>
        private object GetConfigValueOrDefault(IConfigurationSection section, ConfigDefinition definition, string providerId)
        {
            try
            {
                return section.Get(definition.ValueType, providerId);
            }
            catch (InvalidOperationException ex)
            {
                WriteWarning($"[ConfigManager] Failed to get value for [{definition.Key}]. Using the default value [{definition.DefaultValue}] instead. Error: {ex.Message}. {ex.InnerException?.Message}");
                WriteDebug($"[ConfigManager] Exception: {ex.Message}, stack trace: \n{ex.StackTrace}");
                return definition.DefaultValue;
            }
        }

        // A bulk update API is currently unnecessary as we don't expect users to do that.
        // But if telemetry data proves it's a demanded feature, we might add it in the future.
        // public IEnumerable<Config> UpdateConfigs(IEnumerable<UpdateConfigOptions> updateConfigOptions) => updateConfigOptions.Select(UpdateConfig);

        /// <inheritdoc/>
        public override ConfigData UpdateConfig(UpdateConfigOptions options)
        {
            if (options == null)
            {
                throw new AzPSArgumentNullException($"{nameof(options)} cannot be null when updating config.", nameof(options));
            }

            if (!_configDefinitionMap.TryGetValue(options.Key, out ConfigDefinition definition) || definition == null)
            {
                throw new AzPSArgumentException($"Config with key [{options.Key}] was not registered.", nameof(options.Key));
            }

            try
            {
                definition.Validate(options.Value);
            }
            catch (Exception e)
            {
                throw new AzPSArgumentException(e.Message, e);
            }

            if (AppliesToHelper.TryParseAppliesTo(options.AppliesTo, out var appliesTo) && !definition.CanApplyTo.Contains(appliesTo))
            {
                throw new AzPSArgumentException($"[{options.AppliesTo}] is not a valid value for AppliesTo - it doesn't match any of ({AppliesToHelper.FormatOptions(definition.CanApplyTo)}).", nameof(options.AppliesTo));
            }

            definition.Apply(options.Value);

            string path = ConfigPathHelper.GetPathOfConfig(options.Key, options.AppliesTo);

            switch (options.Scope)
            {
                case ConfigScope.Process:
                    SetProcessLevelConfig(path, options.Value);
                    break;
                case ConfigScope.CurrentUser:
                    SetUserLevelConfig(path, options.Value);
                    break;
            }

            WriteDebug($"[ConfigManager] Updated [{options.Key}] to [{options.Value}]. Scope = [{options.Scope}], AppliesTo = [{options.AppliesTo}]");

            return new ConfigData(definition, options.Value, options.Scope, options.AppliesTo);
        }

        private void SetProcessLevelConfig(string path, object value)
        {
            _processLevelConfigs[path] = value.ToString();
            GetProcessLevelConfigProvider().Set(path, value.ToString());
        }

        private UnsettableMemoryConfigurationProvider GetProcessLevelConfigProvider()
        {
            return _root.GetConfigurationProvider(Constants.ConfigProviderIds.ProcessConfig) as UnsettableMemoryConfigurationProvider;
        }

        private void SetUserLevelConfig(string path, object value)
        {
            _lock.EnterWriteLock();
            try
            {
                _jsonConfigHelper.Update(path, value);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
            BuildConfig(); // reload the config values
        }

        /// <inheritdoc/>
        public override void ClearConfig(ClearConfigOptions options)
        {
            _ = options ?? throw new AzPSArgumentNullException($"{nameof(options)} cannot be null.", nameof(options));

            bool clearAll = string.IsNullOrEmpty(options.Key);

            if (clearAll)
            {
                ClearAllConfigs(options);
            }
            else
            {
                ClearConfigByKey(options);
            }
        }

        private void ClearAllConfigs(ClearConfigOptions options)
        {
            switch (options.Scope)
            {
                case ConfigScope.Process:
                    ClearProcessLevelAllConfigs(options);
                    break;
                case ConfigScope.CurrentUser:
                    ClearUserLevelAllConfigs(options);
                    break;
                default:
                    throw new AzPSArgumentException($"[{options.Scope}] is not a valid scope when clearing configs.", nameof(options.Scope));
            }
            WriteDebug($"[ConfigManager] Cleared all the configs. Scope = [{options.Scope}].");
        }

        private void ClearProcessLevelAllConfigs(ClearConfigOptions options)
        {
            var configProvider = GetProcessLevelConfigProvider();
            if (string.IsNullOrEmpty(options.AppliesTo))
            {
                configProvider.UnsetAll();
                _processLevelConfigs.Clear();
            }
            else
            {
                foreach (var key in _configDefinitionMap.Keys)
                {
                    string path = ConfigPathHelper.GetPathOfConfig(key, options.AppliesTo);
                    configProvider.Unset(path);
                    _processLevelConfigs.Remove(path);
                }
            }
        }

        private void ClearUserLevelAllConfigs(ClearConfigOptions options)
        {
            _lock.EnterWriteLock();
            try
            {
                if (string.IsNullOrEmpty(options.AppliesTo))
                {
                    _jsonConfigHelper.ClearAll();
                }
                else
                {
                    foreach (var key in _configDefinitionMap.Keys)
                    {
                        _jsonConfigHelper.Clear(ConfigPathHelper.GetPathOfConfig(key, options.AppliesTo));
                    }
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
            BuildConfig();
        }

        private void ClearConfigByKey(ClearConfigOptions options)
        {
            if (!_configDefinitionMap.TryGetValue(options.Key, out _))
            {
                throw new AzPSArgumentException($"Config with key [{options.Key}] was not registered.", nameof(options.Key));
            }

            switch (options.Scope)
            {
                case ConfigScope.Process:
                    ClearProcessLevelConfigByKey(options);
                    break;
                case ConfigScope.CurrentUser:
                    ClearUserLevelConfigByKey(options);
                    break;
            }

            WriteDebug($"[ConfigManager] Cleared [{options.Key}]. Scope = [{options.Scope}], AppliesTo = [{options.AppliesTo}]");
        }

        private void ClearProcessLevelConfigByKey(ClearConfigOptions options)
        {
            var configProvider = GetProcessLevelConfigProvider();
            if (string.IsNullOrEmpty(options.AppliesTo))
            {
                // find config by key with any possible AppliesTo value
                var match = configProvider.Where(pair => ConfigPathHelper.ArePathAndKeyMatch(pair.Key, options.Key))
                    .Select(pair => pair.Key)
                    .ToList();
                match.ForEach(key =>
                {
                    configProvider.Unset(key);
                    _processLevelConfigs.Remove(key);
                });
            }
            else
            {
                string path = ConfigPathHelper.GetPathOfConfig(options.Key, options.AppliesTo);
                configProvider.Unset(path);
                _processLevelConfigs.Remove(path);
            }
        }

        private void ClearUserLevelConfigByKey(ClearConfigOptions options)
        {
            _lock.EnterWriteLock();
            try
            {
                if (string.IsNullOrEmpty(options.AppliesTo))
                {
                    IList<string> keysToClear = new List<string>();
                    foreach (var appliesToSection in _root.GetChildren())
                    {
                        if (appliesToSection.GetSection(options.Key).Exists())
                        {
                            keysToClear.Add(ConfigPathHelper.GetPathOfConfig(options.Key, appliesToSection.Key));
                        }
                    }
                    foreach (var key in keysToClear)
                    {
                        _jsonConfigHelper.Clear(key);
                    }
                }
                else
                {
                    _jsonConfigHelper.Clear(ConfigPathHelper.GetPathOfConfig(options.Key, options.AppliesTo));
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
            BuildConfig();
        }
    }
}
