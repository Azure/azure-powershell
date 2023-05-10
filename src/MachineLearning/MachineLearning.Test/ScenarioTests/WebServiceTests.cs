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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.MachineLearning.Test.ScenarioTests
{
    public class WebServiceTests : MachineLearningTestRunner
    {
        public WebServiceTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record. MachineLearning tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6684")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetRemoveWebService()
        {
            TestRunner.RunTestScript("Test-CreateGetRemoveMLService");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record. MachineLearning tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6684")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateWebServiceFromFile()
        {
            TestRunner.RunTestScript("Test-CreateWebServiceFromFile");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record. MachineLearning tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6684")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebService()
        {
            TestRunner.RunTestScript("Test-UpdateWebService");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record. MachineLearning tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6684")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListWebServices()
        {
            TestRunner.RunTestScript("Test-ListWebServices");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record. MachineLearning tests need to be re-enabled, as outlined in issue https://github.com/Azure/azure-powershell/issues/6684")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndGetRegionalProperties()
        {
            TestRunner.RunTestScript("Test-CreateAndGetRegionalProperties");
        }
    }
}
