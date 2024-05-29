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

using Microsoft.Azure.PowerShell.AssemblyLoading.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;

namespace Microsoft.Azure.PowerShell.AssemblyLoading.Test.UnitTests
{
    public class ConditionalAssemblyProviderTests
    {
        private const string NetFx = "netfx";
        private const string NetStandard20 = "netstandard2.0";
        private const string RootPath = "root";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetAssembliesOnWindowsPowerShell()
        {
            var context = new MockConditionalAssemblyContext()
            {
                OS = OSPlatform.Windows,
                PSEdition = Constants.PSEditionDesktop,
                PSVersion = Version.Parse("5.1.22621.608"),
                OSArchitecture = Architecture.X64
            };
            ConditionalAssemblyProvider.Initialize(RootPath, context);
            var assemblies = ConditionalAssemblyProvider.GetAssemblies();

            Assert.True(assemblies.TryGetValue("Azure.Core", out var azureCore));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "Azure.Core"), azureCore.Path);
            Assert.True(assemblies.TryGetValue("Newtonsoft.Json", out var newtonsoftJson));
            Assert.Equal(GetExpectedAssemblyPath(NetFx, "Newtonsoft.Json"), newtonsoftJson.Path);

            Assert.True(assemblies.TryGetValue("Azure.Identity", out var azureIdentity));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "Azure.Identity"), azureIdentity.Path);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetAssembliesOnPowerShellCorePlus()
        {
            var context = new MockConditionalAssemblyContext()
            {
                OS = OSPlatform.Windows,
                PSEdition = Constants.PSEditionCore,
                PSVersion = Version.Parse("7.3.0"),
                OSArchitecture = Architecture.X64
            };
            ConditionalAssemblyProvider.Initialize(RootPath, context);
            var assemblies = ConditionalAssemblyProvider.GetAssemblies();

            Assert.True(assemblies.TryGetValue("Azure.Core", out var azureCore));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "Azure.Core"), azureCore.Path);

            Assert.False(assemblies.TryGetValue("Newtonsoft.Json", out _));

            Assert.True(assemblies.TryGetValue("Azure.Identity", out var azureIdentity));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "Azure.Identity"), azureIdentity.Path);
        }

        private string GetExpectedAssemblyPath(string framework, string assemblyName)
        {
            return Path.Combine(RootPath, framework, $"{assemblyName}.dll");
        }
    }
}
