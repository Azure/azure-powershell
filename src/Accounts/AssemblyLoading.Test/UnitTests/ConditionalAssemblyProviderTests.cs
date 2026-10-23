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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;

namespace Microsoft.Azure.PowerShell.AssemblyLoading.Test.UnitTests
{
    public class ConditionalAssemblyProviderTests
    {
        private const string Net45 = "net45";
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
            Assert.Equal(GetExpectedAssemblyPath(Net45, "Newtonsoft.Json"), newtonsoftJson.Path);

            Assert.True(assemblies.TryGetValue("Azure.Identity", out var azureIdentity));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "Azure.Identity"), azureIdentity.Path);

            Assert.True(assemblies.TryGetValue("System.Text.Encodings.Web", out var encodingsWeb));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Text.Encodings.Web"), encodingsWeb.Path);
            Assert.True(assemblies.TryGetValue("System.Text.Json", out var textJson));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Text.Json"), textJson.Path);
            Assert.True(assemblies.TryGetValue("System.Diagnostics.DiagnosticSource", out var diagnosticSource));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Diagnostics.DiagnosticSource"), diagnosticSource.Path);
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

            Assert.True(assemblies.TryGetValue("System.Text.Encodings.Web", out var encodingsWeb));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Text.Encodings.Web"), encodingsWeb.Path);
            Assert.True(assemblies.TryGetValue("System.Text.Json", out var textJson));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Text.Json"), textJson.Path);
            Assert.True(assemblies.TryGetValue("System.Diagnostics.DiagnosticSource", out var diagnosticSource));
            Assert.Equal(GetExpectedAssemblyPath(NetStandard20, "System.Diagnostics.DiagnosticSource"), diagnosticSource.Path);
        }

        [Theory]
        [InlineData(Constants.PSEditionCore, "7.3.0")]
        [InlineData(Constants.PSEditionDesktop, "5.1.0")]
        public void ProviderChecksActualRuntimeEvenWithOlderPowerShellContext(string psEdition, string psVersion)
        {
            string projectPath = typeof(ConditionalAssemblyProviderTests).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                .Single(attribute => attribute.Key == "TestProjectPath").Value;
            string sharedRoot = Path.GetFullPath(Path.Combine(projectPath, "..", "..", "lib"));
            var context = new MockConditionalAssemblyContext { PSEdition = psEdition, PSVersion = Version.Parse(psVersion) };
            ConditionalAssemblyProvider.Initialize(sharedRoot, context);
            var assemblies = ConditionalAssemblyProvider.GetAssemblies();

            foreach (string name in new[] { "System.Text.Json", "System.Text.Encodings.Web", "System.IO.Pipelines", "System.Net.ServerSentEvents", "System.Diagnostics.DiagnosticSource" })
            {
                var sharedIdentity = AssemblyName.GetAssemblyName(Path.Combine(sharedRoot, NetStandard20, name + ".dll"));
                string runtimePath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), name + ".dll");
                bool runtimeCanSatisfy = File.Exists(runtimePath)
                    && ConditionalAssemblyProvider.CanUseRuntimeAssembly(context, sharedIdentity, AssemblyName.GetAssemblyName(runtimePath));
                Assert.Equal(!runtimeCanSatisfy, assemblies.ContainsKey(name));
            }
        }

        [Theory]
        [InlineData("7.3.0", "10.0.0.0", true)]
        [InlineData("7.4.0", "8.0.0.0", false)]
        [InlineData("7.5.0", "9.0.0.0", false)]
        [InlineData("7.6.0", "10.0.0.0", true)]
        [InlineData("7.6.0", "9.0.0.0", false)]
        [InlineData("7.4.0", "11.0.0.0", true)]
        public void RuntimeUnificationDependsOnAssemblyVersionNotPowerShellVersion(string psVersion, string runtimeVersion, bool expected)
        {
            var context = new MockConditionalAssemblyContext { PSEdition = Constants.PSEditionCore, PSVersion = Version.Parse(psVersion) };
            foreach (string name in new[] { "System.Text.Json", "System.Text.Encodings.Web", "System.IO.Pipelines", "System.Net.ServerSentEvents", "System.Diagnostics.DiagnosticSource" })
            {
                var sharedIdentity = new AssemblyName($"{name}, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
                var runtimeIdentity = new AssemblyName($"{name}, Version={runtimeVersion}, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
                Assert.Equal(expected, ConditionalAssemblyProvider.CanUseRuntimeAssembly(context, sharedIdentity, runtimeIdentity));
            }
        }

        [Theory]
        [InlineData("System.Text.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51", true)]
        [InlineData("System.Text.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=null", false)]
        [InlineData("System.Text.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false)]
        [InlineData("System.Text.Json, Version=10.0.0.0, Culture=fr, PublicKeyToken=cc7b13ffcd2ddd51", false)]
        [InlineData("Other.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51", false)]
        public void RuntimeUnificationRequiresMatchingIdentity(string runtimeIdentity, bool expected)
        {
            var context = new MockConditionalAssemblyContext { PSEdition = Constants.PSEditionCore };
            var sharedIdentity = new AssemblyName("System.Text.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
            Assert.Equal(expected, ConditionalAssemblyProvider.CanUseRuntimeAssembly(context, sharedIdentity, new AssemblyName(runtimeIdentity)));
        }

        [Theory]
        [InlineData(Constants.PSEditionDesktop, "System.Text.Json")]
        [InlineData(Constants.PSEditionCore, "Microsoft.Extensions.Logging.Abstractions")]
        [InlineData(Constants.PSEditionCore, "System.Memory.Data")]
        public void PrivateAssembliesArePreserved(string psEdition, string name)
        {
            var context = new MockConditionalAssemblyContext { PSEdition = psEdition };
            var identity = new AssemblyName($"{name}, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51");
            Assert.False(ConditionalAssemblyProvider.CanUseRuntimeAssembly(context, identity, identity));
        }

        private string GetExpectedAssemblyPath(string framework, string assemblyName)
        {
            return Path.Combine(RootPath, framework, $"{assemblyName}.dll");
        }
    }
}
