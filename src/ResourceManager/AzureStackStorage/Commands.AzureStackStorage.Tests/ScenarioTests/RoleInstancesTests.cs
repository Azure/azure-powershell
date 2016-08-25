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

namespace Microsoft.AzureStack.Commands.StorageAdmin.Test.ScenarioTests
{
    public class RoleInstancesTests
    {
        public RoleInstancesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRoleInstance()
        {
            TestsController.NewInstance.RunPsTest("Test-GetRoleInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListRoleInstances()
        {
            TestsController.NewInstance.RunPsTest("Test-ListRoleInstances");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestartRoleInstance()
        {
            TestsController.NewInstance.RunPsTest("Test-RestartRoleInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartRoleInstance()
        {
            TestsController.NewInstance.RunPsTest("Test-StartRoleInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopRoleInstance()
        {
            TestsController.NewInstance.RunPsTest("Test-StopRoleInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRoleInstancePipeline()
        {
            TestsController.NewInstance.RunPsTest("Test-RoleInstancePipeline");
        }
    }
}
