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
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class ClearConfigTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanClearSingleConfig()
        {
            string key = "DisableSomething";
            var icm = GetConfigManager(new SimpleTypedConfig<bool>(key, "{help message}", false));

            Assert.False(icm.GetConfigValue<bool>(key));
            icm.UpdateConfig(new UpdateConfigOptions(key, true, ConfigScope.Process)
            {
                AppliesTo = "Get-AzCmdlet"
            });
            icm.UpdateConfig(new UpdateConfigOptions(key, true, ConfigScope.Process)
            {
                AppliesTo = "Az.Module"
            });

            Assert.Equal(3, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }).Count()); // applies to Get-AzCmdlet, Az.Module and Az(default)
            icm.ClearConfig(new ClearConfigOptions(key, ConfigScope.Process) { AppliesTo = "Get-AzCmdlet" });
            Assert.Equal(2, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }).Count());
            icm.ClearConfig(new ClearConfigOptions(key, ConfigScope.Process) { AppliesTo = "Az.Module" });
            Assert.Single(icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CannotClearUnknownConfig()
        {
            IConfigManager configurationManager = GetConfigManager();

            Assert.Throws<AzPSArgumentException>(() =>
            {
                configurationManager.ClearConfig(new ClearConfigOptions("NeverRegistered", ConfigScope.CurrentUser));
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldNotThrowToClearConfigNeverSet()
        {
            string key1 = "key1";
            var config1 = new SimpleTypedConfig<bool>(key1, "{help message}", false);
            string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "{help message}", false);
            IConfigManager icm = GetConfigManager(config1, config2);

            icm.ClearConfig(key1, ConfigScope.CurrentUser);
            icm.ClearConfig(key2, ConfigScope.Process);
            icm.ClearConfig(null, ConfigScope.CurrentUser);
            icm.ClearConfig(null, ConfigScope.Process);
            icm.ClearConfig(new ClearConfigOptions(null, ConfigScope.CurrentUser)
            {
                AppliesTo = null
            });
            icm.ClearConfig(new ClearConfigOptions(null, ConfigScope.Process)
            {
                AppliesTo = null
            });
            icm.ClearConfig(new ClearConfigOptions(null, ConfigScope.CurrentUser)
            {
                AppliesTo = "Az.Accounts"
            });
            icm.ClearConfig(new ClearConfigOptions(null, ConfigScope.Process)
            {
                AppliesTo = "Az.Accounts"
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanClearSingleConfigInJson()
        {
            string key = "DisableSomething";
            var icm = GetConfigManager(new SimpleTypedConfig<bool>(key, "{help message}", false));

            Assert.False(icm.GetConfigValue<bool>(key));
            icm.UpdateConfig(new UpdateConfigOptions(key, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Get-AzCmdlet"
            });
            icm.UpdateConfig(new UpdateConfigOptions(key, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Az.Module"
            });

            Assert.Equal(3, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }).Count()); // applies to Get-AzCmdlet, Az.Module and Az(default)
            icm.ClearConfig(new ClearConfigOptions(key, ConfigScope.CurrentUser) { AppliesTo = "Get-AzCmdlet" });
            Assert.Equal(2, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }).Count());
            icm.ClearConfig(new ClearConfigOptions(key, ConfigScope.CurrentUser) { AppliesTo = "Az.Module" });
            Assert.Single(icm.ListConfigs(new ConfigFilter() { Keys = new[] { key } }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanClearAllConfigsInJson()
        {
            string key1 = "key1";
            var config1 = new SimpleTypedConfig<bool>(key1, "{help message}", false);
            string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "{help message}", false);
            ConfigManager cm = GetConfigManager(config1, config2) as ConfigManager;

            Assert.False(cm.GetConfigValue<bool>(key1));
            Assert.False(cm.GetConfigValue<bool>(key2));

            // Scenario 1: update the configs, applying to Az
            cm.UpdateConfig(new UpdateConfigOptions(key1, true, ConfigScope.CurrentUser));
            Assert.True(cm.GetConfigValue<bool>(key1));
            cm.UpdateConfig(new UpdateConfigOptions(key2, true, ConfigScope.CurrentUser));
            Assert.True(cm.GetConfigValue<bool>(key2));

            // clear all configs by specifying `null` as the key, applying to Az
            cm.ClearConfig(null, ConfigScope.CurrentUser);
            Assert.False(cm.GetConfigValue<bool>(key1));
            Assert.False(cm.GetConfigValue<bool>(key2));

            // Scenario 2: update the configs, applying to Az.Accounts
            cm.UpdateConfig(new UpdateConfigOptions(key1, true, ConfigScope.CurrentUser) { AppliesTo = "Az.Accounts" });
            Assert.True(cm.GetConfigValueInternal<bool>(key1, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));
            cm.UpdateConfig(new UpdateConfigOptions(key2, true, ConfigScope.CurrentUser) { AppliesTo = "Az.Accounts" });
            Assert.True(cm.GetConfigValueInternal<bool>(key2, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));

            // clear all configs, applying to Az.Accounts
            cm.ClearConfig(new ClearConfigOptions(null, ConfigScope.CurrentUser) { AppliesTo = "Az.Accounts" });
            Assert.False(cm.GetConfigValueInternal<bool>(key1, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));
            Assert.False(cm.GetConfigValueInternal<bool>(key2, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));

            // Scenario 3: update the configs, applying differently
            cm.UpdateConfig(new UpdateConfigOptions(key1, true, ConfigScope.CurrentUser) { AppliesTo = "Az.Accounts" });
            Assert.True(cm.GetConfigValueInternal<bool>(key1, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));
            cm.UpdateConfig(new UpdateConfigOptions(key2, true, ConfigScope.CurrentUser) { AppliesTo = "Az.KeyVault" });
            Assert.True(cm.GetConfigValueInternal<bool>(key2, new InternalInvocationInfo() { ModuleName = "Az.KeyVault" }));

            // clear all configs, applying anything
            cm.ClearConfig(null, ConfigScope.CurrentUser);
            Assert.False(cm.GetConfigValueInternal<bool>(key1, new InternalInvocationInfo() { ModuleName = "Az.Accounts" }));
            Assert.False(cm.GetConfigValueInternal<bool>(key2, new InternalInvocationInfo() { ModuleName = "Az.KeyVault" }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldNotThrowWhenClearConfigNeverSet()
        {
            string key = "DisableSomething";
            var config = new SimpleTypedConfig<bool>(key, "{help message}", false);
            IConfigManager icm = GetConfigManager(config);

            icm.ClearConfig(key, ConfigScope.CurrentUser);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanClearByScope()
        {
            const string boolKey = "BoolKey";
            var boolConfig = new SimpleTypedConfig<bool>(boolKey, "", false);
            const string intKey = "intKey";
            var intConfig = new SimpleTypedConfig<int>(intKey, "", 0);
            var icm = GetConfigManager(boolConfig, intConfig);

            icm.UpdateConfig(new UpdateConfigOptions(boolKey, true, ConfigScope.CurrentUser));
            icm.UpdateConfig(new UpdateConfigOptions(intKey, 10, ConfigScope.CurrentUser));
            icm.UpdateConfig(new UpdateConfigOptions(boolKey, true, ConfigScope.Process));
            icm.UpdateConfig(new UpdateConfigOptions(intKey, 10, ConfigScope.Process));

            icm.ClearConfig(new ClearConfigOptions(boolKey, ConfigScope.Process));
            icm.ClearConfig(new ClearConfigOptions(intKey, ConfigScope.Process));

            foreach (var configData in icm.ListConfigs())
            {
                Assert.NotEqual(ConfigScope.Process, configData.Scope);
            }

            icm.ClearConfig(boolKey, ConfigScope.CurrentUser);
            icm.ClearConfig(intKey, ConfigScope.CurrentUser);

            foreach (var configData in icm.ListConfigs())
            {
                Assert.NotEqual(ConfigScope.CurrentUser, configData.Scope);
            }
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldClearWhateverAppliesTo()
        {
            const string boolKey = "BoolKey";
            var boolConfig = new SimpleTypedConfig<bool>(boolKey, "", false);
            var icm = GetConfigManager(boolConfig);

            icm.UpdateConfig(new UpdateConfigOptions(boolKey, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Az.Module"
            });
            icm.UpdateConfig(new UpdateConfigOptions(boolKey, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Get-Cmdlet"
            });
            icm.UpdateConfig(new UpdateConfigOptions(boolKey, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Az"
            });

            icm.ClearConfig(boolKey, ConfigScope.CurrentUser);
            var results = icm.ListConfigs(new ConfigFilter() { Keys = new string[] { boolKey } });
            Assert.Single(results);
        }
    }
}
