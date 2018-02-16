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
    public class AEMExtensionTests
    {
        public AEMExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void TestAEMExtensionBasicWindowsWAD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionBasicWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindows()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionBasicWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinuxWAD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionBasicLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinux()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionBasicLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsWAD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedWindowsWAD");
        }

        [Fact]
        public void TestAEMExtensionAdvancedWindows()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxWAD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinux()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedLinux");
        }

        [Fact]
        public void TestAEMExtensionAdvancedWindowsMD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedWindowsMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedLinuxMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_ESeries()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedLinuxMD_E");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_DSeries()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-AEMExtensionAdvancedLinuxMD_D");
        }
    }
}