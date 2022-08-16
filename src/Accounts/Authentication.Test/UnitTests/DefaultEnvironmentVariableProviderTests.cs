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
using Xunit;
using System;

namespace Microsoft.Azure.Authentication.Test.UnitTests
{
    public class DefaultEnvironmentVariableProviderTests
    {
        [Fact]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void ShouldNotThrowWhen2EnvVarDifferOnlyByCase()
        {
            const string varName = "NameOfAnEnvVar";
            Environment.SetEnvironmentVariable(varName, "a");
            string varNameInUpper = varName.ToUpperInvariant();
            Environment.SetEnvironmentVariable(varNameInUpper, "b");

            try
            {
                DefaultEnvironmentVariableProvider provider = new DefaultEnvironmentVariableProvider();
                var dict = provider.List();
                Assert.True(dict.ContainsKey(varName));
                Assert.True(dict.ContainsKey(varNameInUpper));
                Assert.Equal(dict[varName], dict[varNameInUpper]);
            }
            finally
            {
                Environment.SetEnvironmentVariable(varName, null);
                Environment.SetEnvironmentVariable(varNameInUpper, null);
            }
        }
    }
}
