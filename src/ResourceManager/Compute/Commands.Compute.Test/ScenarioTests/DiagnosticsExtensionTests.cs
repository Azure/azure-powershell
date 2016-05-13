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
    public class DiagnosticsExtensionTests
    {
        public DiagnosticsExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionBasic()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-DiagnosticsExtensionBasic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionSepcifyStorageAccountName()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-DiagnosticsExtensionSepcifyStorageAccountName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionCantListSepcifyStorageAccountKey()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-DiagnosticsExtensionCantListSepcifyStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticsExtensionSupportJsonConfig()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-DiagnosticsExtensionSupportJsonConfig");
        }
    }
}
