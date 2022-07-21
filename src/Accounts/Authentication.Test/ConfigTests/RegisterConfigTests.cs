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
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class RegisterConfigTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CannotRegisterSameKeyTwice()
        {
            IConfigManager entry = GetConfigManager();
            const string key = "CannotRegisterTwice";
            entry.RegisterConfig(new SimpleTypedConfig<int>(key, "", -1));
            Assert.Throws<AzPSArgumentException>(() =>
            {
                entry.RegisterConfig(new SimpleTypedConfig<object>(key, "", null));
            });
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanRegisterSameConfigTwice()
        {
            IConfigManager entry = GetConfigManager();
            const string key = "CanRegisterTwice";
            SimpleTypedConfig<int> config = new SimpleTypedConfig<int>(key, "", -1);
            entry.RegisterConfig(config);
            entry.RegisterConfig(config);
        }

        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanGetDefaultValue()
        {
            IConfigManager entry = GetConfigManager();
            const string key = "CanGetConfigValue";
            SimpleTypedConfig<int> config = new SimpleTypedConfig<int>(key, "", -1);
            entry.RegisterConfig(config);
            entry.BuildConfig();
            Assert.Equal(-1, entry.GetConfigValue<int>(key));

            entry.UpdateConfig(new UpdateConfigOptions(key, 10, ConfigScope.Process));
            Assert.Equal(10, entry.GetConfigValue<int>(key));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanRegisterConfigs(ConfigDefinition config)
        {
            ConfigManager manager = GetConfigManager() as ConfigManager;
            manager.RegisterConfig(config);
            manager.BuildConfig();
            Assert.Equal(config.DefaultValue, manager.GetConfigValueInternal(config.Key, null));
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] { new SimpleTypedConfig<int>("Config", "", -1) },
            new object[] { new SimpleTypedConfig<int>("Config", "", -1, "ENV_VAR_FOR_CONFIG") },
            new object[] { new SimpleTypedConfig<int?>("Config", "", null) },
            new object[] { new SimpleTypedConfig<int?>("Config", "", 1) },
            new object[] { new SimpleTypedConfig<bool>("Config", "", true) },
            new object[] { new SimpleTypedConfig<string>("Config", "", "default") },
            new object[] { new SimpleTypedConfig<double>("Config", "", 3.1415926) },
            new object[] { new SimpleTypedConfig<int[]>("Config", "", new int[] { 1,2,3 }) },
            new object[] { new SimpleTypedConfig<string[]>("Config", "", new string[] { "Az.Accounts", "Az.Compute" })},
            new object[] { new SimpleTypedConfig<DateTime>("Config", "", DateTime.MinValue) },
            new object[] { new SimpleTypedConfig<bool>("Config", "", true, "env_var", new [] { AppliesTo.Cmdlet }) },
            new object[] { new TestConfigForDefaultValue() }
        };

        private class TestConfigForDefaultValue : ConfigDefinition
        {
            public override object DefaultValue => (decimal)10;

            public override string Key => nameof(TestConfigForDefaultValue);

            public override string HelpMessage => "";

            public override Type ValueType => typeof(decimal);

            public override void Validate(object value) { base.Validate(value); }
        }
    }
}
