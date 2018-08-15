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
    public class RoleDefinitionTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public RoleDefinitionTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleDefinitionCreateTests()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RoleDefinitionCreateTests");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue for .NET Core: Investigation needed")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleDefinitionDataActionsCreateTests()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RoleDefinitionDataActionsCreateTests");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue for .NET Core: Investigation needed")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdNegativeScenarios()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RdNegativeScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdPositiveScenarios()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDPositiveScenarios");
        }

        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDUpdate()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDCreateFromFile()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDCreateFromFile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
		public void RDFilter()
		{
			ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDFilter");
		}

        [Fact(Skip = "Unskip after service side change")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDRemoveScenario()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDRemove");
        }

#if NETSTANDARD
        [Fact(Skip = "Unknown issue for .NET Core: Investigation needed")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDGetCustomRoles()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDGetCustomRoles");
        }

        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDDataActionsNegativeTestCases()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDDataActionsNegativeTestCases");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDGetScenario()
        {
            ResourcesController.NewInstance.RunPsTest(_logger, "Test-RDGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdValidateInputParameters()
        {
            var instance = ResourcesController.NewInstance;
            instance.RunPsTest(_logger, "Test-RdValidateInputParameters Get-AzureRmRoleDefinition");
            instance.RunPsTest(_logger, "Test-RdValidateInputParameters Remove-AzureRmRoleDefinition");
            instance.RunPsTest(_logger, "Test-RdValidateInputParameters2 New-AzureRmRoleDefinition");
            instance.RunPsTest(_logger, "Test-RdValidateInputParameters2 Set-AzureRmRoleDefinition");
        }
    }
}
