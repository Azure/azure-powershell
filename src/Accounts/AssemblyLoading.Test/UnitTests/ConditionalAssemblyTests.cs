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
    public class ConditionalAssemblyTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldLoadAssemblyWithoutConstraint()
        {
            var context = new MockConditionalAssemblyContext();
            var assembly = NewDummyAssembly(context);
            Assert.True(assembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldLoadAssemblyAccordingToPSVersion()
        {
            // windows powershell
            var context = new MockConditionalAssemblyContext()
            {
                PSEdition = Constants.PSEditionDesktop,
                PSVersion = Version.Parse("5.1.22621.608")
            };
            var windowsPSAssembly = NewDummyAssembly(context).WithWindowsPowerShell();
            var psCoreAssembly = NewDummyAssembly(context).WithPowerShellCore();
            var neturalAssembly = NewDummyAssembly(context);
            Assert.True(windowsPSAssembly.ShouldLoad);
            Assert.False(psCoreAssembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);

            // powershell core and 7+
            context.PSEdition = Constants.PSEditionCore;
            context.PSVersion = Version.Parse("7.3.0");
            windowsPSAssembly = NewDummyAssembly(context).WithWindowsPowerShell();
            psCoreAssembly = NewDummyAssembly(context).WithPowerShellCore();
            neturalAssembly = NewDummyAssembly(context);
            Assert.False(windowsPSAssembly.ShouldLoad);
            Assert.True(psCoreAssembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldLoadAssemblyAccordingToOS()
        {
            // windows
            var context = new MockConditionalAssemblyContext()
            { OS = OSPlatform.Windows };
            var windowsAssembly = NewDummyAssembly(context).WithWindows();
            var linuxAssembly = NewDummyAssembly(context).WithLinux();
            var macOSAssembly = NewDummyAssembly(context).WithMacOS();
            var neturalAssembly = NewDummyAssembly(context);
            Assert.True(windowsAssembly.ShouldLoad);
            Assert.False(linuxAssembly.ShouldLoad);
            Assert.False(macOSAssembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);

            // linux
            context = new MockConditionalAssemblyContext()
            { OS = OSPlatform.Linux };
            windowsAssembly = NewDummyAssembly(context).WithWindows();
            linuxAssembly = NewDummyAssembly(context).WithLinux();
            macOSAssembly = NewDummyAssembly(context).WithMacOS();
            neturalAssembly = NewDummyAssembly(context);
            Assert.False(windowsAssembly.ShouldLoad);
            Assert.True(linuxAssembly.ShouldLoad);
            Assert.False(macOSAssembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);

            // macos
            context = new MockConditionalAssemblyContext()
            { OS = OSPlatform.OSX };
            windowsAssembly = NewDummyAssembly(context).WithWindows();
            linuxAssembly = NewDummyAssembly(context).WithLinux();
            macOSAssembly = NewDummyAssembly(context).WithMacOS();
            neturalAssembly = NewDummyAssembly(context);
            Assert.False(windowsAssembly.ShouldLoad);
            Assert.False(linuxAssembly.ShouldLoad);
            Assert.True(macOSAssembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldLoadAssemblyAccordingToCpuArch()
        {
            // x86
            var context = new MockConditionalAssemblyContext()
            { OSArchitecture = Architecture.X86 };
            var x86Assembly = NewDummyAssembly(context).WithX86();
            var x64Assembly = NewDummyAssembly(context).WithX64();
            var arm64Assembly = NewDummyAssembly(context).WithArm64();
            var neturalAssembly = NewDummyAssembly(context);
            Assert.True(x86Assembly.ShouldLoad);
            Assert.False(x64Assembly.ShouldLoad);
            Assert.False(arm64Assembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);

            // x64
            context = new MockConditionalAssemblyContext()
            { OSArchitecture = Architecture.X64 };
            x86Assembly = NewDummyAssembly(context).WithX86();
            x64Assembly = NewDummyAssembly(context).WithX64();
            arm64Assembly = NewDummyAssembly(context).WithArm64();
            neturalAssembly = NewDummyAssembly(context);
            Assert.False(x86Assembly.ShouldLoad);
            Assert.True(x64Assembly.ShouldLoad);
            Assert.False(arm64Assembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);

            // arm64
            context = new MockConditionalAssemblyContext()
            { OSArchitecture = Architecture.Arm64 };
            x86Assembly = NewDummyAssembly(context).WithX86();
            x64Assembly = NewDummyAssembly(context).WithX64();
            arm64Assembly = NewDummyAssembly(context).WithArm64();
            neturalAssembly = NewDummyAssembly(context);
            Assert.False(x86Assembly.ShouldLoad);
            Assert.False(x64Assembly.ShouldLoad);
            Assert.True(arm64Assembly.ShouldLoad);
            Assert.True(neturalAssembly.ShouldLoad);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ShouldSupportMultipleConstraints()
        {
            // assembly requires powershell 7+ on linux
            // if both meet, it should be loaded
            var context = new MockConditionalAssemblyContext();
            context.OS = OSPlatform.Linux;
            context.PSVersion = Version.Parse("7.3.0");
            var assembly = NewDummyAssembly(context).WithLinux().WithPowerShellVersion(Version.Parse("7.0.0"));
            Assert.True(assembly.ShouldLoad);

            // otherwise it shouldn't
            context.OS = OSPlatform.Windows;
            context.PSVersion = Version.Parse("7.3.0");
            assembly = NewDummyAssembly(context).WithLinux().WithPowerShellVersion(Version.Parse("7.0.0"));
            Assert.False(assembly.ShouldLoad);

            context.OS = OSPlatform.Linux;
            context.PSVersion = Version.Parse("6.2.0");
            Assert.False(assembly.ShouldLoad);

            context.OS = OSPlatform.Windows;
            context.PSVersion = Version.Parse("5.1.0");
            Assert.False(assembly.ShouldLoad);
        }

        private static ConditionalAssembly NewDummyAssembly(MockConditionalAssemblyContext context)
        {
            return new ConditionalAssembly(context, "name", "path", new Version(1, 0, 0));
        }
    }
}
