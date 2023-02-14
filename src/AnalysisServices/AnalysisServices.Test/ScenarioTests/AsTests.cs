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
    using ServiceManagement.Common.Models;
    using Xunit;

    public class AsTests : AnalysisServicesTestRunner
    {
        public AsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServer()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerScaleUpDown()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerScaleUpDown");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerScaleOutIn()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerScaleOutIn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAnalysisServicesServerFirewall()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerFirewall");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerDisableBackup()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerDisableBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNegativeAnalysisServicesServer()
        {
            TestRunner.RunTestScript("Test-NegativeAnalysisServicesServer");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerLogExport()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerLogExport");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerRestart()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerRestart");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerSynchronizeSingle()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerSynchronizeSingle");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerLoginWithSPN()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerLoginWithSPN");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAnalysisServicesServerGateway()
        {
            TestRunner.RunTestScript("Test-AnalysisServicesServerGateway");
        }

    }
}
