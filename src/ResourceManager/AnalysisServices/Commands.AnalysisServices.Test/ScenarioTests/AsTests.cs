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

namespace Microsoft.Azure.Commands.AnalysisServices.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class AsTests : AsTestsBase
    {
        public AsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServer()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerScaleUpDown()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerScaleUpDown");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerScaleOutIn()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerScaleOutIn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerFirewall()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerFirewall");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerDisableBackup()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerDisableBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAnalysisServicesServer()
        {
            NewInstance.RunPsTest("Test-NegativeAnalysisServicesServer");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerLogExport()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerLogExport");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerRestart()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerRestart");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerSynchronizeSingle()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerSynchronizeSingle");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerLoginWithSPN()
        {
            NewInstance.RunPsTest("Test-AnalysisServicesServerLoginWithSPN");
        }
    }
}
