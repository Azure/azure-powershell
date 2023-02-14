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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.Common;
using Xunit;
using Microsoft.Azure.PowerShell.Common.Config;
using System.IO;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections.Generic;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class JsonConfigHelperTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanExportConfig()
        {
            string key = "key1";
            var config = new SimpleTypedConfig<bool>(key, "", true);
            string configPath = Path.GetTempFileName();
            var dataStore = new MockDataStore();
            var configManager = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore,
                    Path = configPath
                },
                config);

            // update config to false
            configManager.UpdateConfig(key, false, ConfigScope.CurrentUser);

            // export config file
            string path = Path.GetTempFileName();
            Assert.False(dataStore.FileExists(path));
            new JsonConfigHelper(configPath, dataStore).ExportConfigFile(path);

            // config file should be exported and be correct
            Assert.True(dataStore.FileExists(path));
            var json = JsonUtilities.DeserializeJson(dataStore.ReadFileAsText(path), true);
            Assert.True(json.ContainsKey(ConfigFilter.GlobalAppliesTo));
            var jsonConfig = json.GetProperty(ConfigFilter.GlobalAppliesTo) as IDictionary<string, object>;
            Assert.NotNull(jsonConfig);
            Assert.False((bool)jsonConfig.GetProperty(key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanImportConfig()
        {
            string key = "key1";
            var config = new SimpleTypedConfig<bool>(key, "", true);
            var dataStore = new MockDataStore();
            var configManager = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore
                },
                config);

            // import a config file
            string path = Path.GetTempFileName();
            dataStore.WriteFile(path,
@"{
    ""Az"": {
        ""key1"": false
    }
}");
            new JsonConfigHelper(configManager.ConfigFilePath, dataStore).ImportConfigFile(path);
            configManager.BuildConfig();

            // configs should be imported correctly
            Assert.False(configManager.GetConfigValue<bool>(key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ConfigsShouldBeMergedWhenImport()
        {
            string key1 = "key1";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            string key3 = "key3";
            var config3 = new SimpleTypedConfig<bool>(key3, "", true);
            string key4 = "key4";
            var config4 = new SimpleTypedConfig<bool>(key4, "", true);

            var dataStore = new MockDataStore();
            var configManager = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore
                },
                config1, config2, config3, config4);

            // update config3 and config4 to false
            configManager.UpdateConfig(key3, false, ConfigScope.CurrentUser);
            configManager.UpdateConfig(key4, false, ConfigScope.CurrentUser);
            Assert.True(configManager.GetConfigValue<bool>(key1));
            Assert.True(configManager.GetConfigValue<bool>(key2));
            Assert.False(configManager.GetConfigValue<bool>(key3));
            Assert.False(configManager.GetConfigValue<bool>(key4));

            // import a config file, setting config2 to false and config4 to true
            string path = Path.GetTempFileName();
            dataStore.WriteFile(path,
@"{
    ""Az"": {
        ""key2"": false,
        ""key4"": true
    }
}");
            new JsonConfigHelper(configManager.ConfigFilePath, dataStore).ImportConfigFile(path);
            configManager.BuildConfig();

            // config1 should be true => not imported, use default value
            Assert.True(configManager.GetConfigValue<bool>(key1));
            // config2 should be false => imported, should overwrite default value
            Assert.False(configManager.GetConfigValue<bool>(key2));
            // config3 should be false => not imported, use value in config
            Assert.False(configManager.GetConfigValue<bool>(key3));
            // config4 should be true => imported, should overwrite previous value in config
            Assert.True(configManager.GetConfigValue<bool>(key4));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ExportImportE2E()
        {
            string key = "key1";
            var config = new SimpleTypedConfig<bool>(key, "", true);
            var dataStore = new MockDataStore();
            var configManager = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore
                },
                config);
            // update
            configManager.UpdateConfig(key, false, ConfigScope.CurrentUser);
            
            // exportconfig
            string path = Path.GetRandomFileName();
            var helper = new JsonConfigHelper(configManager.ConfigFilePath, dataStore);
            helper.ExportConfigFile(path);

            // clear
            configManager.ClearConfig(key, ConfigScope.CurrentUser);
            Assert.True(configManager.GetConfigValue<bool>(key));

            // import
            helper.ImportConfigFile(path);
            configManager.BuildConfig();
            Assert.False(configManager.GetConfigValue<bool>(key));
        }
    }
}
