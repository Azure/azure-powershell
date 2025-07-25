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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Config;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.PowerShell.Authentication.Test.Mocks;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class ConfigTestsBase
    {
        private readonly Action<MockDataStore, string> _noopFileWriter = (x, y) => { };
        private readonly Action<MockEnvironmentVariableProvider> _noopEnvVarWriter = (x) => { };

        /// <summary>
        /// Initializes and returns an <see cref="IConfigManager"/> with the specified configs registered.
        /// </summary>
        /// <param name="config">Definitions of configs to be registered to the config manager.</param>
        /// <returns>A config manager ready to use.</returns>
        protected IConfigManager GetConfigManager(params ConfigDefinition[] config) => GetConfigManager(null, config);

        /// <summary>
        /// Initializes and returns an <see cref="IConfigManager"/> with the specified configs registered with initial state.
        /// </summary>
        /// <param name="configFileWriter">An action to set up the config file before config manager initializes.</param>
        /// <param name="envVarWriter">An action to set up the environments before config manager initializes.</param>
        /// <param name="config">Definitions of configs to be registered to the config manager.</param>
        /// <returns>A config manager with initial state, ready to use.</returns>
        internal IConfigManager GetConfigManager(InitSettings settings, params ConfigDefinition[] config)
        {
            var configPath = settings?.Path ?? Path.GetRandomFileName();
            var dataStore = settings?.DataStore;
            if (dataStore == null)
            {
                dataStore = new MockDataStore();
            }
            if (!dataStore.FileExists(configPath))
            {
                dataStore.WriteFile(configPath, @"{}");
            }
            var environmentVariableProvider = settings?.EnvironmentVariableProvider ?? new MockEnvironmentVariableProvider();

            IConfigManager icm = new DefaultConfigManager(configPath, dataStore, environmentVariableProvider);
            foreach (var configDefinition in config)
            {
                icm.RegisterConfig(configDefinition);
            }
            icm.BuildConfig();
            return icm;
        }

        internal class InitSettings
        {
            public IDataStore DataStore { get; set; } = null;
            public string Path { get; set; } = null;
            public IEnvironmentVariableProvider EnvironmentVariableProvider { get; set; } = null;
        }
    }
}
