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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentTests : ResourceTestRunner
    {
        public DeploymentTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "Need to implement storage client mock.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestValidateDeployment()
        {
            TestRunner.RunTestScript("Test-ValidateDeployment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromTemplateFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewDeploymentFromTemplateObject()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromTemplateObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewDeploymentTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromTemplateSpec");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewSubscriptionDeploymentTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewSubscriptionDeploymentFromTemplateSpec");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewFailedSubscriptionDeploymentTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewFailedSubscriptionDeploymentFromTemplateSpec");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewMGDeploymentTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewMGDeploymentFromTemplateSpec");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.CoreOnly)]
        public void TestNewTenantDeploymentTemplateSpec()
        {
            TestRunner.RunTestScript("Test-NewTenantDeploymentFromTemplateSpec");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTestResourceGroupDeploymentErrors()
        {
            TestRunner.RunTestScript("Test-TestResourceGroupDeploymentErrors");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNestedDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-NestedDeploymentFromTemplateFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrossResourceGroupDeploymentFromTemplateFile()
        {
            TestRunner.RunTestScript("Test-CrossResourceGroupDeploymentFromTemplateFile");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSaveDeploymentTemplateFile()
        {
            TestRunner.RunTestScript("Test-SaveDeploymentTemplateFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNestedErrorsDisplayed()
        {
            TestRunner.RunTestScript("Test-NestedErrorsDisplayed");
        }

        [Fact(Skip = "Fix acquisition of TenantId in KeyVault Test.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithKeyVaultReference()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithKeyVaultReference");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithComplexPramaters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithComplexPramaters");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestNewDeploymentWithParameterObject()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithParameterObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithDynamicParameters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithDynamicParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithInvalidParameters()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithInvalidParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithKeyVaultReferenceInParameterObject()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithKeyVaultReferenceInParameterObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentFromNonexistentTemplateFile()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromNonexistentTemplateFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentFromNonexistentTemplateParameterFile()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromNonexistentTemplateParameterFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewDeploymentWithQueryString()
        {
            TestRunner.RunTestScript("Test-NewDeploymentWithQueryString");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestNewDeploymentFromBicepFile()
        {
            TestRunner.RunTestScript("Test-NewDeploymentFromBicepFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestTestDeploymentFromBicepFile()
        {
            TestRunner.RunTestScript("Test-TestDeploymentFromBicepFile");
        }
    }
}
