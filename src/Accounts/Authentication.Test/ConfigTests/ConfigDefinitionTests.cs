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
using Xunit;

namespace Microsoft.Azure.Authentication.Test.Config
{
    public class ConfigDefinitionTests : ConfigTestsBase
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanValidateInput()
        {
            const string boolKey = "BoolKey";
            var boolConfig = new SimpleTypedConfig<bool>(boolKey, "", false);
            var rangedIntConfig = new RangedConfig();
            var icm = GetConfigManager(boolConfig, rangedIntConfig);

            Assert.Throws<AzPSArgumentException>(() => { icm.UpdateConfig(boolKey, 0, ConfigScope.CurrentUser); });
            Assert.Throws<AzPSArgumentException>(() => { icm.UpdateConfig(rangedIntConfig.Key, true, ConfigScope.CurrentUser); });
            Assert.Throws<AzPSArgumentException>(() => { icm.UpdateConfig(rangedIntConfig.Key, -1, ConfigScope.CurrentUser); });
        }

        private class RangedConfig : TypedConfig<int>
        {
            public override object DefaultValue => 0;

            public override string Key => "RangedKey";

            public override string HelpMessage => "";

            public override void Validate(object value)
            {
                base.Validate(value);
                int valueAsInt = (int)value;
                if (valueAsInt < 0 || valueAsInt > 100)
                {
                    throw new ArgumentOutOfRangeException($"The value of config {Key} must be in between 0 and 100.");
                }
            }
        }
    }
}
