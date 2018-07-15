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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class PolicyTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public PolicyTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUD()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtManagementGroup()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtSubscription()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentCRUD()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyAssignmentCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicySetDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyAssignmentWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUD()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicySetDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtManagementGroup()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicySetDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtSubscription()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicySetDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithUri()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-PolicyDefinitionWithUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-NewPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RemovePolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-NewPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RemovePolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-GetPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-NewPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RemovePolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-SetPolicySetDefinitionParameters");
        }
    }
}
