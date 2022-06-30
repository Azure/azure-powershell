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
    public class RoleAssignmentTests : ResourceTestRunner
    {
        public XunitTracingInterceptor _logger;

        public RoleAssignmentTests(ITestOutputHelper output) : base(output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaClassicAdmins()
        {
            TestRunner.RunTestScript("Test-RaClassicAdmins");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaClassicAdminsWithScope()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RaClassicAdminsWithScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaDeletedPrincipals()
        {
            TestRunner.RunTestScript("Test-UnknowndPrincipals");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaPropertiesValidation()
        {
            TestRunner.RunTestScript("Test-RaPropertiesValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaNegativeScenarios()
        {
            TestRunner.RunTestScript("Test-RaNegativeScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaByScope()
        {
            TestRunner.RunTestScript("Test-RaByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaDeleteByPSRoleAssignment()
        {
            TestRunner.RunTestScript("Test-RaDeleteByPSRoleAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaByResourceGroup()
        {
            TestRunner.RunTestScript("Test-RaByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaByResource()
        {
            TestRunner.RunTestScript("Test-RaByResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaValidateInputParameters()
        {
            TestRunner.RunTestScript("Test-RaValidateInputParameters Get-AzureRmRoleAssignment");
            TestRunner.RunTestScript("Test-RaValidateInputParameters New-AzureRmRoleAssignment");
            TestRunner.RunTestScript("Test-RaValidateInputParameters Remove-AzureRmRoleAssignment");
        }

        [Fact]//(Skip = "Test indicates Graph call is not recorded when it actually is, refer to https://github.com/Azure/azure-powershell/issues/14632 for more details, test passes in record mode")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaByServicePrincipal()
        {
            TestRunner.RunTestScript("Test-RaByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaById()
        {
            TestRunner.RunTestScript("Test-RaById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaDeletionByScope()
        {
            TestRunner.RunTestScript("Test-RaDeletionByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaDeletionByScopeAtRootScope()
        {
            TestRunner.RunTestScript("Test-RaDeletionByScopeAtRootScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaDelegation()
        {
            TestRunner.RunTestScript("Test-RaDelegation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaByUpn()
        {
            TestRunner.RunTestScript("Test-RaByUpn");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaGetByScope()
        {
            TestRunner.RunTestScript("Test-RaGetByScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaGetOnlyByRoleDefinitionName()
        {
            TestRunner.RunTestScript("Test-RaGetOnlyByRoleDefinitionName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaGetByUPNWithExpandPrincipalGroups()
        {
            TestRunner.RunTestScript("Test-RaGetByUPNWithExpandPrincipalGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaCreatedBySP()
        {
            TestRunner.RunTestScript("Test-RaCreatedBySP");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV1Conditions()
        {
            TestRunner.RunTestScript("Test-RaWithV1Conditions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaWithV2Conditions()
        {
            TestRunner.RunTestScript("Test-RaWithV2Conditions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void RaWithV2ConditionsOnly()
        {
            TestRunner.RunTestScript("Test-RaWithV2ConditionsOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RaWithV2ConditionVersionOnly()
        {
            TestRunner.RunTestScript("Test-RaWithV2ConditionVersionOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void UpdateRa()
        {
            TestRunner.RunTestScript("Test-UpdateRa");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAForGroup()
        {
            TestRunner.RunTestScript("Test-CreateRAForGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAForGuest()
        {
            TestRunner.RunTestScript("Test-CreateRAForGuest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAForMember()
        {
            TestRunner.RunTestScript("Test-CreateRAForMember");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAForServicePrincipal()
        {
            TestRunner.RunTestScript("Test-CreateRAForServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAWhenIdNotExist()
        {
            TestRunner.RunTestScript("Test-CreateRAWhenIdNotExist");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void CreateRAWithObjectType()
        {
            TestRunner.RunTestScript("Test-CreateRAWithObjectType");
        }
    }
}
