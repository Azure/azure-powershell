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

using Microsoft.Azure.Commands.Common.Authentication.Config;
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
        protected IConfigManager GetConfigManager(params ConfigDefinition[] config) => GetConfigManagerWithInitState(null, null, config);

        /// <summary>
        /// Initializes and returns an <see cref="IConfigManager"/> with the specified configs registered with initial state.
        /// </summary>
        /// <param name="configFileWriter">An action to set up the config file before config manager initializes.</param>
        /// <param name="envVarWriter">An action to set up the environments before config manager initializes.</param>
        /// <param name="config">Definitions of configs to be registered to the config manager.</param>
        /// <returns>A config manager with initial state, ready to use.</returns>
        protected IConfigManager GetConfigManagerWithInitState(Action<MockDataStore, string> configFileWriter, Action<MockEnvironmentVariableProvider> envVarWriter, params ConfigDefinition[] config)
        {
            if (configFileWriter == null)
            {
                configFileWriter = _noopFileWriter;
            }

            if (envVarWriter == null)
            {
                envVarWriter = _noopEnvVarWriter;
            }

            string configPath = Path.GetRandomFileName();
            var mockDataStore = new MockDataStore();
            configFileWriter(mockDataStore, configPath);
            var environmentVariables = new MockEnvironmentVariableProvider();
            envVarWriter(environmentVariables);
            ConfigInitializer ci = new ConfigInitializer(new List<string>() { configPath })
            {
                DataStore = mockDataStore,
                EnvironmentVariableProvider = environmentVariables
            };
            IConfigManager icm = ci.GetConfigManager();
            foreach (var configDefinition in config)
            {
                icm.RegisterConfig(configDefinition);
            }
            icm.BuildConfig();
            return icm;
        }
    }
}
