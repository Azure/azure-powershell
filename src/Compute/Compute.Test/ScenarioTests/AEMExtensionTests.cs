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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class AEMExtensionTests
    {
        XunitTracingInterceptor _logger;

        public AEMExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindowsWAD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionBasicWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindows()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionBasicWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinuxWAD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionBasicLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicLinux()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionBasicLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsWAD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindows()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxWAD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedLinuxWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinux()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedLinux");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsMD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedWindowsMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedLinuxMD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_ESeries()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedLinuxMD_E");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedLinuxMD_DSeries()
        {
            ComputeTestController.NewInstance.RunPsTest(_logger, "Test-AEMExtensionAdvancedLinuxMD_D");
        }
    }
}