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

using Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.PowerShell.AssemblyLoading.Test.UnitTests
{
    public class RuntimeProvidedAssembliesTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        // PowerShell 7.6 (.NET 10) ships System.Text.Json 10.0.0.0, same as Az.Accounts: use the runtime copy.
        [InlineData("10.0.0.0", "10.0.0.0", "10.0.0.0", true)]
        // Runtime copy is newer than both the shipped and the requested version.
        [InlineData("10.0.0.14", "10.0.0.10", "10.0.0.0", true)]
        // No version in the request.
        [InlineData("10.0.0.0", "10.0.0.0", null, true)]
        // PowerShell 7.4 (.NET 8) ships System.Text.Json 8.0.0.0: keep the Az.Accounts copy.
        [InlineData("8.0.0.0", "10.0.0.0", "10.0.0.0", false)]
        // Runtime copy satisfies the shipped version but not the requested one.
        [InlineData("10.0.0.0", "10.0.0.0", "10.0.0.10", false)]
        // Runtime does not provide the assembly (e.g. Azure.Core).
        [InlineData(null, "1.64.0.0", "1.64.0.0", false)]
        public void UsesRuntimeCopyOnlyWhenItIsNewEnough(string runtimeVersion, string shippedVersion, string requestedVersion, bool expected)
        {
            Assert.Equal(expected, RuntimeProvidedAssemblies.IsSatisfiedByRuntime(ParseVersion(runtimeVersion), ParseVersion(shippedVersion), ParseVersion(requestedVersion)));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParsesTrustedPlatformAssemblies()
        {
            var first = Path.Combine("runtime", "System.Text.Json.dll");
            var second = Path.Combine("pwsh", "Microsoft.Bcl.AsyncInterfaces.dll");
            var nonAssembly = Path.Combine("runtime", "native.so");
            var paths = RuntimeProvidedAssemblies.ParseTrustedPlatformAssemblies(string.Join(Path.PathSeparator, first, second, nonAssembly, string.Empty));

            Assert.Equal(2, paths.Count);
            Assert.Equal(first, paths["system.text.json"]);
            Assert.Equal(second, paths["Microsoft.Bcl.AsyncInterfaces"]);
            Assert.Empty(RuntimeProvidedAssemblies.ParseTrustedPlatformAssemblies(null));
            Assert.Empty(RuntimeProvidedAssemblies.ParseTrustedPlatformAssemblies(string.Empty));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReadsVersionOfAssemblyProvidedByRuntime()
        {
            var coreLib = typeof(object).Assembly.GetName();

            Assert.Equal(coreLib.Version, RuntimeProvidedAssemblies.GetRuntimeVersion(coreLib.Name));
            Assert.Null(RuntimeProvidedAssemblies.GetRuntimeVersion("Not.A.Runtime.Assembly"));
            Assert.Null(RuntimeProvidedAssemblies.GetRuntimeVersion(null));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DecidesUsingRuntimeVersion()
        {
            var coreLib = typeof(object).Assembly.GetName();
            var requested = new AssemblyName(coreLib.Name) { Version = coreLib.Version };
            var newerThanRuntime = new Version(coreLib.Version.Major + 1, 0, 0, 0);

            Assert.True(RuntimeProvidedAssemblies.ShouldUseRuntimeCopy(requested, coreLib.Version));
            Assert.False(RuntimeProvidedAssemblies.ShouldUseRuntimeCopy(requested, newerThanRuntime));
            Assert.False(RuntimeProvidedAssemblies.ShouldUseRuntimeCopy(new AssemblyName("Not.A.Runtime.Assembly") { Version = new Version(1, 0) }, new Version(1, 0)));
        }

        private static Version ParseVersion(string version)
        {
            return version == null ? null : Version.Parse(version);
        }
    }
}
