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
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.PowerShell.Common.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Initializes the config file and config manager.
    /// </summary>
    internal class ConfigInitializer
    {
        internal IDataStore DataStore { get; set; } = new DiskDataStore();
        private static readonly object _fsLock = new object();

        internal IEnvironmentVariableProvider EnvironmentVariableProvider { get; set; } = new DefaultEnvironmentVariableProvider();

        private readonly string _pathToConfigFile;

        public ConfigInitializer(IEnumerable<string> paths)
        {
            _ = paths ?? throw new ArgumentNullException(nameof(paths));
            _pathToConfigFile = GetPathToConfigFile(paths);
        }

        /// <summary>
        /// Loop through the fallback list of paths of the config file. Returns the first usable one.
        /// </summary>
        /// <param name="paths">A list of paths to the config file. When one is not usable, it will fallback to the next.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">When no one in the list is usable.</exception>
        private string GetPathToConfigFile(IEnumerable<string> paths)
        {
            // find first exist path and use it
            foreach (string path in paths)
            {
                if (DataStore.FileExists(path))
                {
                    return path;
                }
            }
            // if not found, use the first writable path
            foreach (string path in paths)
            {
                try
                {
                    DirectoryInfo dir = new FileInfo(path).Directory;
                    DataStore.CreateDirectory(dir.FullName); // create directory if not exists
                    using (var _ = DataStore.OpenForExclusiveWrite(path)) { }
                    return path;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            throw new ApplicationException($"Failed to store the config file. Please make sure any one of the following paths is accessible: {string.Join(", ", paths)}");
        }

        internal IConfigManager GetConfigManager()
        {
            lock (_fsLock)
            {
                ValidateConfigFile();
            }
            return new ConfigManager(_pathToConfigFile, DataStore, EnvironmentVariableProvider);
        }

        private void ValidateConfigFileContent()
        {
            string json = DataStore.ReadFileAsText(_pathToConfigFile);

            bool isValidJson = true;
            try
            {
                JObject.Parse(json);
            }
            catch (Exception)
            {
                isValidJson = false;
            }

            if (string.IsNullOrEmpty(json) || !isValidJson)
            {
                Debug.Write($"[ConfigInitializer] Failed to parse the config file at {_pathToConfigFile}. Clearing the file.");
                ResetConfigFileToDefault();
            }
        }

        private void ValidateConfigFile()
        {
            if (!DataStore.FileExists(_pathToConfigFile))
            {
                ResetConfigFileToDefault();
            }
            else
            {
                ValidateConfigFileContent();
            }
        }

        private void ResetConfigFileToDefault()
        {
            try
            {
                DataStore.WriteFile(_pathToConfigFile, @"{}");
            }
            catch (Exception ex)
            {
                // do not halt for IO exception
                Debug.WriteLine(ex.Message);
            }
        }

        // todo: tests initializes configs in a different way. Maybe there should be an abstraction IConfigInitializer and two concrete classes ConfigInitializer + TestConfigInitializer
        internal void InitializeForAzureSession(AzureSession session)
        {
            IConfigManager configManager = GetConfigManager();
            session.RegisterComponent(nameof(IConfigManager), () => configManager);
            RegisterConfigs(configManager);
            configManager.BuildConfig();
        }

        private void RegisterConfigs(IConfigManager configManager)
        {
            // simple configs
            // todo: review the help messages
            //configManager.RegisterConfig(new SimpleTypedConfig<bool>(ConfigKeys.SuppressWarningMessage, "Controls if the warning messages of upcoming breaking changes are enabled or suppressed. The messages are typically displayed when a cmdlet that will have breaking change in the future is executed.", false, BreakingChangeAttributeHelper.SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME));
            //configManager.RegisterConfig(new SimpleTypedConfig<bool>(ConfigKeys.EnableInterceptSurvey, "When enabled, a message of taking part in the survey about the user experience of Azure PowerShell will prompt at low frequency.", true, "Azure_PS_Intercept_Survey"));
            // todo: when the input is not a valid subscription name or id. Connect-AzAccount will throw an error. Is it right?
            //configManager.RegisterConfig(new SimpleTypedConfig<string>(ConfigKeys.DefaultSubscriptionForLogin, "Subscription name or GUID. If defined, when logging in Azure PowerShell without specifying the subscription, this one will be used to select the default context.", string.Empty));
            // todo: add later
            //configManager.RegisterConfig(new RetryConfig());
            // todo: how to migrate old config
        //configManager.RegisterConfig(new EnableDataCollectionConfig());
        }
    }
}
