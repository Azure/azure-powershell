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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class AEMExtensionTests : ComputeTestRunner
    {
        public AEMExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinuxWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinux()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinux()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsMD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_ESeries()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD_E");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_DSeries()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedLinuxMD_D");
        }
    }
}