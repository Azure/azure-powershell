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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Config manager in safe mode.
    /// </summary>
    /// <remarks>
    /// No config providers are added, so updating configs and listing configs with a non-default scope are both not supported.
    /// </remarks>
    internal class SafeConfigManager : ConfigManager
    {
        private string _notSupported = "[SafeConfigManager] ConfigManager was initialized in safe mode. {0} is not supported.";

        /// <inheritdoc/>
        public override string ConfigFilePath
        {
            get => throw new AzPSApplicationException(string.Format(_notSupported, "Getting the path of config file"), ErrorKind.UserError);
            protected set => throw new AzPSApplicationException(string.Format(_notSupported, "Setting the path of config file"), ErrorKind.UserError);
        }

        internal SafeConfigManager()
        {
        }

        /// <inheritdoc/>
        public override void BuildConfig()
        {
            var builder = new ConfigurationBuilder();
            // add no providers
            _root = builder.Build();
        }

        /// <inheritdoc/>
        public override IEnumerable<ConfigData> ListConfigs(ConfigFilter filter = null)
        {
            if (filter.Scope != null && filter.Scope != ConfigScope.Default)
            {
                throw new AzPSApplicationException(string.Format(_notSupported, "Listing configs with non-default scope"), ErrorKind.UserError);
            }

            IEnumerable<string> keys = filter?.Keys ?? Enumerable.Empty<string>();
            // include default values
            bool isRegisteredKey(string key) => _configDefinitionMap.Keys.Contains(key, StringComparer.OrdinalIgnoreCase);
            IEnumerable<ConfigDefinition> configDefinitions = keys.Any() ? keys.Where(isRegisteredKey).Select(key => _configDefinitionMap[key]) : _configDefinitionMap.Select(x => x.Value);
            IList<ConfigData> results = configDefinitions.Select(x => x.ToDefaultConfigData()).ToList();

            // filter by appliesTo
            string appliesTo = filter?.AppliesTo;
            if (!string.IsNullOrEmpty(appliesTo))
            {
                results = results.Where(x => string.Equals(appliesTo, x.AppliesTo, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return results.OrderBy(configData => configData.Definition.Key);
        }

        /// <inheritdoc/>
        public override ConfigData UpdateConfig(UpdateConfigOptions options)
        {
            throw new AzPSApplicationException(string.Format(_notSupported, "Updating configs"), ErrorKind.UserError);
        }

        /// <inheritdoc/>
        public override void ClearConfig(ClearConfigOptions options)
        {
            throw new AzPSApplicationException(string.Format(_notSupported, "Clearing configs"), ErrorKind.UserError);
        }
    }
}
