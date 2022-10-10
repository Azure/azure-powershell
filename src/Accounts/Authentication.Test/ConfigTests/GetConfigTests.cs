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
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;
using Microsoft.Azure.PowerShell.Authentication.Test.Mocks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System;
using System.IO;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class GetConfigTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetAppliesTo()
        {
            const string key = "EnableTelemetry";
            var def = new SimpleTypedConfig<bool>(
                key,
                "Enable telemetry",
                true);
            IConfigManager icm = GetConfigManager(def);

            var config = icm.ListConfigs().Single();
            Assert.NotNull(config);
            Assert.Equal(key, config.Definition.Key);

            icm.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.CurrentUser));
            config = icm.ListConfigs().Single();
            Assert.Equal(ConfigFilter.GlobalAppliesTo, config.AppliesTo);

            icm.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.CurrentUser) { AppliesTo = "Az.KeyVault" });
            config = icm.ListConfigs(new ConfigFilter() { AppliesTo = "Az.KeyVault" }).Single();
            Assert.Equal("Az.KeyVault", config.AppliesTo);

            icm.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.CurrentUser) { AppliesTo = "Get-AzKeyVault" });
            config = icm.ListConfigs(new ConfigFilter { AppliesTo = "Get-AzKeyVault" }).Single();
            Assert.Equal("Get-AzKeyVault", config.AppliesTo);

        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldReturnEmptyWhenFilterIsWrong()
        {
            const string key = "EnableTelemetry";
            var config = new SimpleTypedConfig<bool>(
                key,
                "Enable telemetry",
                true);
            var icm = GetConfigManager(config);
            Assert.NotEmpty(icm.ListConfigs());
            Assert.NotEmpty(icm.ListConfigs(null));
            Assert.Empty(icm.ListConfigs(new ConfigFilter() { Keys = new string[] { "Never Exist" } }));
            Assert.Empty(icm.ListConfigs(new ConfigFilter() { AppliesTo = "xxx" }));

        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetAndListRegisteredConfigs()
        {
            const string key1 = "EnableTelemetry";
            var config1 = new SimpleTypedConfig<bool>(
                key1,
                "Enable telemetry",
                true);
            TestConfig config2 = new TestConfig();
            IConfigManager configurationManager = GetConfigManager(config1, config2);

            var listResult = configurationManager.ListConfigs();
            Assert.Equal(2, listResult.Count());

            ConfigData configData = listResult.Where(x => x.Definition.Key == key1).Single();
            Assert.Equal(true, configData.Value);
            Assert.True(configurationManager.GetConfigValue<bool>(key1));

            ConfigData tempConfigResult = listResult.Where(x => x.Definition.Key == config2.Key).Single();
            Assert.Equal(config2.DefaultValue, tempConfigResult.Value);
            Assert.Equal(config2.HelpMessage, tempConfigResult.Definition.HelpMessage);
            Assert.Equal(config2.DefaultValue, configurationManager.GetConfigValue<int>(config2.Key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanUpdateAndList()
        {
            IConfigManager configurationManager = GetConfigManager();
            const string key = "EnableTelemetry";
            configurationManager.RegisterConfig(
                new SimpleTypedConfig<bool>(
                    key,
                    "Enable telemetry",
                    true));
            configurationManager.BuildConfig();
            var updatedConfig = configurationManager.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.Process));
            Assert.Equal(key, updatedConfig.Definition.Key);
            Assert.False((bool)updatedConfig.Value);
            Assert.False(configurationManager.GetConfigValue<bool>(key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetFromEnvironmentVar()
        {
            const string key = "FromEnv";
            const string envKey = "ENV_VAR_FOR_CONFIG";
            var config = new SimpleTypedConfig<int>(key, "", -1, envKey);
            const int value = 20;

            IEnvironmentVariableProvider env = new MockEnvironmentVariableProvider();
            env.Set(envKey, value.ToString());
            var configurationManager = GetConfigManager(
                new InitSettings()
                {
                    EnvironmentVariableProvider = env
                },
                config);

            Assert.Equal(value, configurationManager.GetConfigValue<int>(key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldNotThrowWhenEnvVarIsWrong()
        {
            const string key = "FromEnv";
            const string envKey = "ENV_VAR_FOR_CONFIG";
            const int defaultValue = -1;
            var config = new SimpleTypedConfig<int>(key, "", defaultValue, envKey);
            const bool valueWithWrongType = true;
            IEnvironmentVariableProvider env = new MockEnvironmentVariableProvider();
            env.Set(envKey, valueWithWrongType.ToString());
            var configurationManager = GetConfigManager(
                new InitSettings()
                {
                    EnvironmentVariableProvider = env
                },
                config);

            Assert.Equal(defaultValue, configurationManager.GetConfigValue<int>(key));
        }

        private class TestConfig : TypedConfig<int>
        {
            public override object DefaultValue => -1;

            public override string Key => "TempConfig";

            public override string HelpMessage => "temp config";
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetFromJson()
        {
            var config1 = new SimpleTypedConfig<int>("Retry", "", -1);
            var config2 = new SimpleTypedConfig<string[]>("Array", "", null);
            IDataStore dataStore = new MockDataStore();
            string path = Path.GetRandomFileName();
            dataStore.WriteFile(path,
@"{
    ""Az"": {
        ""Retry"": 100
    },
    ""Az.KeyVault"": {
        ""Array"": [""a"",""b""]
    },
    ""Get-AzKeyVault"": {
        ""Array"": [""k"",""v""]
    }
}");
            IConfigManager icm = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore,
                    Path = path
                },
                config1, config2);
            ConfigManager cm = icm as ConfigManager;
            Assert.Equal(100, cm.GetConfigValue<int>("Retry"));
            Assert.Equal(new string[] { "a", "b" }, cm.GetConfigValueInternal<string[]>("Array", new InternalInvocationInfo() { ModuleName = "Az.KeyVault" }));
            Assert.Equal(new string[] { "k", "v" }, cm.GetConfigValueInternal<string[]>("Array", new InternalInvocationInfo() { ModuleName = "Az.KeyVault", CmdletName = "Get-AzKeyVault" }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ThrowWhenGetUnknownConfig()
        {
            IConfigManager entry = GetConfigManager();
            entry.BuildConfig();

            Assert.Throws<AzPSArgumentNullException>(() => { entry.GetConfigValue<int>(null); });
            Assert.Throws<AzPSArgumentException>(() => { entry.GetConfigValue<int>(""); });

            const string key = "KeyThatIsNotRegistered";
            Assert.Throws<AzPSArgumentException>(() => { entry.GetConfigValue<int>(key); });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanFilterByKeyAndAppliesTo()
        {
            const string key = "key";
            var config = new SimpleTypedConfig<bool>(key, "", true);
            var icm = GetConfigManager(config);
            const string module = "Az.KeyVault";
            icm.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.CurrentUser) { AppliesTo = module });
            Assert.Single(icm.ListConfigs(new ConfigFilter() { Keys = new[] { key }, AppliesTo = module }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanFilterByKey()
        {
            const string key = "key";
            var config = new SimpleTypedConfig<bool>(key, "", true);
            var icm = GetConfigManager(config);
            const string module = "Az.KeyVault";
            icm.UpdateConfig(new UpdateConfigOptions(key, false, ConfigScope.CurrentUser) { AppliesTo = module });
            var listResults = icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } });
            Assert.Equal(2, listResults.Count());
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanFilterByAppliesTo()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var icm = GetConfigManager(config1, config2);

            const string module = "Az.KeyVault";
            icm.UpdateConfig(new UpdateConfigOptions(key1, false, ConfigScope.CurrentUser) { AppliesTo = module });
            icm.UpdateConfig(new UpdateConfigOptions(key2, false, ConfigScope.CurrentUser) { AppliesTo = module });

            var listResults = icm.ListConfigs(new ConfigFilter() { AppliesTo = module });
            Assert.Equal(2, listResults.Count());

            listResults = icm.ListConfigs(new ConfigFilter() { AppliesTo = ConfigFilter.GlobalAppliesTo });
            Assert.Equal(2, listResults.Count());
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanFilterByScope()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var icm = GetConfigManager(config1, config2);

            icm.UpdateConfig(new UpdateConfigOptions(key1, false, ConfigScope.CurrentUser));
            icm.UpdateConfig(new UpdateConfigOptions(key1, true, ConfigScope.Process));

            var listResults = icm.ListConfigs(new ConfigFilter() { Scope = ConfigScope.Default });
            Assert.Equal(2, listResults.Count());
            listResults = icm.ListConfigs(new ConfigFilter() { Scope = ConfigScope.CurrentUser });
            Assert.Single(listResults);
            listResults = icm.ListConfigs(new ConfigFilter() { Scope = ConfigScope.Process });
            Assert.Single(listResults);
            listResults = icm.ListConfigs(new ConfigFilter() { Scope = ConfigScope.Environment });
            Assert.Empty(listResults);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanFilterByNoFilter()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var icm = GetConfigManager(config1, config2);

            const string module = "Az.KeyVault";
            icm.UpdateConfig(new UpdateConfigOptions(key1, false, ConfigScope.CurrentUser) { AppliesTo = module });
            icm.UpdateConfig(new UpdateConfigOptions(key2, false, ConfigScope.CurrentUser) { AppliesTo = module });
            var listResults = icm.ListConfigs();
            Assert.Equal(4, listResults.Count()); // default*2, module*2
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanListDefinitions()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var config3 = new TestConfig();
            var icm = GetConfigManager(config1, config2, config3);

            Assert.Equal(3, icm.ListConfigDefinitions().Count());

            const string module = "Az.KeyVault";
            icm.UpdateConfig(new UpdateConfigOptions(key1, false, ConfigScope.CurrentUser) { AppliesTo = module });
            Assert.Equal(3, icm.ListConfigDefinitions().Count());
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetScope()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            var config2 = new TestConfig();
            var icm = GetConfigManager(config1, config2);

            var listResults = icm.ListConfigs();
            foreach (var config in listResults)
            {
                Assert.Equal(ConfigScope.Default, config.Scope);
            }

            var updated = icm.UpdateConfig(new UpdateConfigOptions(key1, false, ConfigScope.CurrentUser));
            Assert.Equal(ConfigScope.CurrentUser, updated.Scope);

            updated = icm.UpdateConfig(new UpdateConfigOptions(key1, true, ConfigScope.Process));
            Assert.Equal(ConfigScope.Process, updated.Scope);

            icm.ClearConfig(new ClearConfigOptions(key1, ConfigScope.Process));
            updated = icm.ListConfigs(new ConfigFilter() { Keys = new string[] { key1 } }).Single();
            Assert.Equal(ConfigScope.CurrentUser, updated.Scope);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void AppliesToShouldBeCaseInsensitive()
        {
            const string key = "key";
            var config = new SimpleTypedConfig<int>(key, "", 0);
            var icm = GetConfigManager(config);

            icm.UpdateConfig(new UpdateConfigOptions(key, 1, ConfigScope.CurrentUser) { AppliesTo = "az.abc" });
            Assert.Equal(1, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key }, AppliesTo = "az.abc" }).Single().Value);
            Assert.Equal(1, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key }, AppliesTo = "Az.Abc" }).Single().Value);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ListDefinitionsShouldBeDictOrder()
        {
            const string key1 = "key1";
            var config1 = new SimpleTypedConfig<int>(key1, "", 0);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<int>(key2, "", 0);
            const string key3 = "key3";
            var config3 = new SimpleTypedConfig<int>(key3, "", 0);

            // register using wrong order
            var icm = GetConfigManager(config2, config1, config3);

            for (int i = 0; i != 10; ++i)
            {
                var definitions = icm.ListConfigDefinitions();
                // expect return with dict order
                Assert.Equal(key1, definitions.ElementAt(0).Key);
                Assert.Equal(key2, definitions.ElementAt(1).Key);
                Assert.Equal(key3, definitions.ElementAt(2).Key);
            }

        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ListConfigsShouldBeDictOrder()
        {
            const string key1 = "key1";
            var config1 = new SimpleTypedConfig<int>(key1, "", 0);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<int>(key2, "", 0);
            const string key3 = "key3";
            var config3 = new SimpleTypedConfig<int>(key3, "", 0);
            var icm = GetConfigManager(config1, config2, config3);

            // update second config
            icm.UpdateConfig(key2, 1, ConfigScope.CurrentUser);

            for (int i = 0; i != 10; ++i)
            {
                var configs = icm.ListConfigs();
                // expect return with dict order
                Assert.Equal(key1, configs.ElementAt(0).Definition.Key);
                Assert.Equal(key2, configs.ElementAt(1).Definition.Key);
                Assert.Equal(key3, configs.ElementAt(2).Definition.Key);
            }
        }
    }
}
