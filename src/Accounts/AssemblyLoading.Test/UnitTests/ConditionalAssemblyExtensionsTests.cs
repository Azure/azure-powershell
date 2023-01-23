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
using System.Runtime.InteropServices;
using Xunit;

namespace Microsoft.Azure.PowerShell.AssemblyLoading.Test.UnitTests
{
    public class ConditionalAssemblyExtensionsTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanWorkWithPSVersion()
        {
            var windowsPSContext = new MockConditionalAssemblyContext()
            {
                PSEdition = Constants.PSEditionDesktop,
                PSVersion = Version.Parse("5.1.22621.608")
            };
            var windowsPSAssembly = new MockConditionalAssembly(windowsPSContext)
                .WithWindowsPowerShell();
            var psCoreAssembly = new MockConditionalAssembly(
                windowsPSContext)
                .WithPowerShellCore();
            Assert.True(windowsPSAssembly.ShouldLoad);
            Assert.False(psCoreAssembly.ShouldLoad);

            var ps7Context = new MockConditionalAssemblyContext()
            {
                PSEdition = Constants.PSEditionCore,
                PSVersion = Version.Parse("7.3.0")
            };
            windowsPSAssembly = new MockConditionalAssembly(
                ps7Context)
                .WithWindowsPowerShell();
            psCoreAssembly = new MockConditionalAssembly(
                ps7Context)
                .WithPowerShellCore();
            Assert.True(psCoreAssembly.ShouldLoad);
            Assert.False(windowsPSAssembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanWorkWithEmptyPSEdition()
        {
            var windowsPSContext = new MockConditionalAssemblyContext()
            {
                PSVersion = Version.Parse("1.0.0.0")
            };
            var windowsPSAssembly = new MockConditionalAssembly(windowsPSContext)
                .WithWindowsPowerShell();
            var psCoreAssembly = new MockConditionalAssembly(
                windowsPSContext)
                .WithPowerShellCore();
            Assert.True(windowsPSAssembly.ShouldLoad);
            Assert.False(psCoreAssembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanWorkWithOS()
        {
            var windowsContext = new MockConditionalAssemblyContext()
            {
                OS = OSPlatform.Windows
            };
            var windowsAssembly = new MockConditionalAssembly(windowsContext)
                .WithWindows();
            var linuxAssembly = new MockConditionalAssembly(windowsContext)
                .WithLinux();
            Assert.True(windowsAssembly.ShouldLoad);
            Assert.False(linuxAssembly.ShouldLoad);

            var linuxContext = new MockConditionalAssemblyContext()
            {
                OS = OSPlatform.Linux
            };
            windowsAssembly = new MockConditionalAssembly(linuxContext)
                .WithWindows();
            linuxAssembly = new MockConditionalAssembly(linuxContext)
                .WithLinux();
            Assert.False(windowsAssembly.ShouldLoad);
            Assert.True(linuxAssembly.ShouldLoad);
        }
    }
}
