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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleDefinitionResourceTests : ResourceTestRunner
    {
        public RoleDefinitionResourceTests(ITestOutputHelper output) : base(output)
        {
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleDefinitionCreateTests()
        {
            TestRunner.RunTestScript("Test-RoleDefinitionCreateTests");
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
            TestRunner.RunTestScript("Test-RoleDefinitionDataActionsCreateTests");
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
            TestRunner.RunTestScript("Test-RdNegativeScenarios");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdPositiveScenarios()
        {
            TestRunner.RunTestScript("Test-RDPositiveScenarios");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDUpdate()
        {
            //ResourcesController.NewInstance.RunPsTest("Test-RDUpdate");
            TestRunner.RunTestScript("Test-RDUpdate");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDCreateFromFile()
        {
            TestRunner.RunTestScript("Test-RDCreateFromFile");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDFilter()
        {
            TestRunner.RunTestScript("Test-RDFilter");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "Unskip after service side change")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDRemoveScenario()
        {
            TestRunner.RunTestScript("Test-RDRemove");
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
            TestRunner.RunTestScript("Test-RDGetCustomRoles");
        }

#if NETSTANDARD
        [Fact(Skip = "Storage version difference: Needs rerecorded for .NET Core")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact(Skip = "Successfully re-recorded, but still failing in playback")]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDDataActionsNegativeTestCases()
        {
            TestRunner.RunTestScript("Test-RDDataActionsNegativeTestCases");
        }

#if NETSTANDARD
        [Fact(Skip = "DisableTestParallelization disabled on .NET Core: Test uses RoleDefinitionNames")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RDGetScenario()
        {
            TestRunner.RunTestScript("Test-RDGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdValidateInputParameters()
        {
            TestRunner.RunTestScript("Test-RdValidateInputParameters Get-AzureRmRoleDefinition");
            TestRunner.RunTestScript("Test-RdValidateInputParameters Remove-AzureRmRoleDefinition");
            TestRunner.RunTestScript("Test-RdValidateInputParameters2 New-AzureRmRoleDefinition");
            TestRunner.RunTestScript("Test-RdValidateInputParameters2 Set-AzureRmRoleDefinition");
        }
    }
}
