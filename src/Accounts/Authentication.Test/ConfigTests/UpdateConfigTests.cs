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
using Moq;
using System;
using System.Linq;
using Xunit;
using System.IO;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class UpdateConfigTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanUpdateJsonFile()
        {
            const string retryKey = "Retry";
            var intConfig = new SimpleTypedConfig<int>(retryKey, "", -1);
            const string arrayKey = "Array";
            var arrayConfig = new SimpleTypedConfig<string[]>(arrayKey, "", null);
            var path = Path.GetRandomFileName();
            var dataStore = new MockDataStore();
            dataStore.WriteFile(path,
@"{
    ""Az"": {
        ""Retry"": 100
    },
    ""Az.KeyVault"": {
        ""Array"": [""a"",""b""]
    }
}");
            IConfigManager icm = GetConfigManager(
                new InitSettings()
                {
                    DataStore = dataStore,
                    Path = path
                },
                intConfig, arrayConfig);
            ConfigManager cm = icm as ConfigManager;
            Assert.Equal(100, cm.GetConfigValue<int>(retryKey));
            Assert.Equal(new string[] { "a", "b" }, cm.GetConfigValueInternal<string[]>(arrayKey, new InternalInvocationInfo() { ModuleName = "Az.KeyVault" }));
            ConfigData updated = icm.UpdateConfig(new UpdateConfigOptions(retryKey, 10, ConfigScope.CurrentUser));
            Assert.Equal(10, updated.Value);
            Assert.Equal(10, icm.GetConfigValue<int>(retryKey));

            string[] updatedArray = new string[] { "c", "d" };
            ConfigData updated2 = icm.UpdateConfig(new UpdateConfigOptions(arrayKey, updatedArray, ConfigScope.CurrentUser)
            {
                AppliesTo = "Az.KeyVault"
            });
            Assert.Equal(updatedArray, updated2.Value);
            Assert.Equal(updatedArray, cm.GetConfigValueInternal<string[]>(arrayKey, new InternalInvocationInfo() { ModuleName = "Az.KeyVault" }));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanUpdateConfigForCmdlet()
        {
            const string warningKey = "DisalbeWarning";
            var warningConfig = new SimpleTypedConfig<bool>(warningKey, "", false);
            IConfigManager icm = GetConfigManager(warningConfig);

            Assert.False(icm.GetConfigValue<bool>(warningKey));

            ConfigData updated = icm.UpdateConfig(new UpdateConfigOptions(warningKey, true, ConfigScope.CurrentUser)
            {
                AppliesTo = "Get-AzKeyVault"
            });
            Assert.Equal(true, updated.Value);
            Assert.False(icm.GetConfigValue<bool>(warningKey));

            var cm = (ConfigManager)icm;
            Assert.True(cm.GetConfigValueInternal<bool>(warningKey, new InternalInvocationInfo("Az.KeyVault", "Get-AzKeyVault")));
            Assert.False(cm.GetConfigValueInternal<bool>(warningKey, new InternalInvocationInfo("Az.Storage", "Get-AzStorageAccount")));
            Assert.False(cm.GetConfigValueInternal<bool>(warningKey, new InternalInvocationInfo("Az.KeyVault", "Remove-AzKeyVault")));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void EachUpdateShouldBeIndependent()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var icm = GetConfigManager(config1, config2);

            icm.UpdateConfig(key1, false, ConfigScope.Process);
            Assert.False(icm.GetConfigValue<bool>(key1));
            Assert.True(icm.GetConfigValue<bool>(key2));

            icm.UpdateConfig(key2, false, ConfigScope.CurrentUser);
            Assert.False(icm.GetConfigValue<bool>(key1));
            Assert.False(icm.GetConfigValue<bool>(key2));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ThrowWhenOptionIsInvalid()
        {
            const string key1 = "key";
            var config1 = new SimpleTypedConfig<bool>(key1, "", true);
            const string key2 = "key2";
            var config2 = new SimpleTypedConfig<bool>(key2, "", true);
            var icm = GetConfigManager(config1, config2);

            Assert.Throws<AzPSArgumentNullException>(() => icm.UpdateConfig(null));
            Assert.Throws<ArgumentNullException>(() => icm.UpdateConfig(new UpdateConfigOptions(null, null, ConfigScope.CurrentUser)));
            Assert.Throws<AzPSArgumentException>(() => icm.UpdateConfig(new UpdateConfigOptions(key1, "ThisShouldNotBeAString", ConfigScope.CurrentUser)));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void AppliesToShouldBeCaseInsensitive()
        {
            const string key = "key";
            var config = new SimpleTypedConfig<int>(key, "", 0);
            var icm = GetConfigManager(config);

            icm.UpdateConfig(new UpdateConfigOptions(key, 1, ConfigScope.CurrentUser) { AppliesTo = "az.abc" });
            icm.UpdateConfig(new UpdateConfigOptions(key, 2, ConfigScope.CurrentUser) { AppliesTo = "Az.Abc" });
            Assert.Equal(2, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key }, AppliesTo = "az.abc" }).Single().Value);
            Assert.Equal(2, icm.ListConfigs(new ConfigFilter() { Keys = new[] { key }, AppliesTo = "Az.Abc" }).Single().Value);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanUpdateConfigHasSideEffect()
        {
            int calls = 0;
            var mock = new Mock<ConfigDefinition>();
            mock.Setup(c => c.Key).Returns("key");
            mock.Setup(c => c.CanApplyTo).Returns(new[] { AppliesTo.Az });
            mock.Setup(c => c.Apply(It.IsAny<bool>())).Callback((object v) =>
            {
                switch (++calls)
                {
                    case 1:
                        Assert.True((bool)v);
                        break;
                    case 2:
                        Assert.False((bool)v);
                        break;
                    default:
                        break;
                }
            });
            var config = mock.Object;
            var icm = GetConfigManager(config);
            icm.UpdateConfig(config.Key, true, ConfigScope.CurrentUser);
            icm.UpdateConfig(config.Key, false, ConfigScope.CurrentUser);
            Assert.Equal(2, calls);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldNotUpdateConfigIfSideEffectThrows()
        {
            var config = new ConfigWithSideEffect((bool v) => throw new Exception("oops"));
            var icm = GetConfigManager(config);
            Assert.Throws<Exception>(() => icm.UpdateConfig(config.Key, !config.TypedDefaultValue, ConfigScope.CurrentUser));
            Assert.Equal(config.TypedDefaultValue, icm.GetConfigValue<bool>(config.Key));
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldThrowIfAppliesToIsWrong()
        {
            var key = "OnlyAppliesToAz";
            var config = new SimpleTypedConfig<bool>(key, "", true, null, new AppliesTo[] { AppliesTo.Az });
            var icm = GetConfigManager(config);
            Assert.Throws<AzPSArgumentException>(() => icm.UpdateConfig(new UpdateConfigOptions(key, true, ConfigScope.CurrentUser) { AppliesTo = "Az.Accounts" }));
        }

        internal class ConfigWithSideEffect : TypedConfig<bool>
        {
            private readonly Action<bool> _sideEffect;

            public ConfigWithSideEffect(Action<bool> sideEffect)
            {
                _sideEffect = sideEffect;
            }
            public override object DefaultValue => true;

            public override string Key => "ConfigWithSideEffect";

            public override string HelpMessage => "{HelpMessage}";

            protected override void ApplyTyped(bool value)
            {
                base.ApplyTyped(value);
                _sideEffect(value);
            }
        }
    }
}
