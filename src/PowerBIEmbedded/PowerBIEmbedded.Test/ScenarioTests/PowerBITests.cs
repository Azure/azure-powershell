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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.PowerBIEmbedded.Test.ScenarioTests
{
    public class PowerBITests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public PowerBITests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWorkspaceCollectionListAll()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-GetWorkspaceCollection_ListAll");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWorkspaceCollectionListByResourceGroup()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-GetWorkspaceCollection_ListByResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWorkspaceCollectionByName()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-GetWorkspaceCollection_ByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWorkspaceEmptyCollection()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-GetWorkspace_EmptyCollection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetWorkspaceCollectionAccessKeys1()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-ResetWorkspaceCollectionAccessKeys_Key1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetWorkspaceCollectionAccessKeys2()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-ResetWorkspaceCollectionAccessKeys_Key2");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWorkspaceCollectionAccessKeys()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-GetWorkspaceCollectionAccessKeys");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWorkspaceCollection()
        {
            PowerBIController.NewInstance.RunPsTest(_logger, "Test-RemoveWorkspaceCollection");
        }
    }
}
