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


using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Maps.Test.ScenarioTests
{
    public class MapsAccountTests : RMTestBase
    {
        XunitTracingInterceptor traceInterceptor;

        public MapsAccountTests(ITestOutputHelper output)
        {
            this.traceInterceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.traceInterceptor);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccounts()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureMapsAccount");
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmMapsAccount");
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RemoveAzureRmMapsAccount");
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccountKeys()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmMapsAccountKey");
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountKey()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmMapsAccountKey");
        }

        [Fact(Skip = "Old ResourceMananger version in controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingToGetKey()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-PipingGetAccountToGetKey");
        }
    }
}
