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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentTests
    {
        public DeploymentTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact(Skip = "Need to implement storage client mock.")]
        public void TestValidateDeployment()
        {
            ResourcesController.NewInstance.RunPsTest("Test-ValidateDeployment");
        }

        [Fact]
        public void TestNewDeploymentFromTemplateFile()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentFromTemplateFile");
        }

        [Fact]
        public void TestNestedDeploymentFromTemplateFile()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NestedDeploymentFromTemplateFile");
        }

        [Fact]
        public void TestSaveDeploymentTemplateFile()
        {
            ResourcesController.NewInstance.RunPsTest("Test-SaveDeploymentTemplateFile");
        }

        [Fact]
        public void TestNestedErrorsDisplayed()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NestedErrorsDisplayed");
        }

        [Fact(Skip = "Fix acquisition of TenantId in KeyVault Test.")]
        public void TestNewDeploymentWithKeyVaultReference()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentWithKeyVaultReference");
        }

        [Fact]
        public void TestNewDeploymentWithComplexPramaters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentWithComplexPramaters");
        }

        [Fact]
        public void TestNewDeploymentWithParameterObject()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentWithParameterObject");
        }

        [Fact]
        public void TestNewDeploymentWithDynamicParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentWithDynamicParameters");
        }

        [Fact]
        public void TestNewDeploymentWithInvalidParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewDeploymentWithInvalidParameters");
        }
    }
}
