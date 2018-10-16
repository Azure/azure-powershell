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

namespace Microsoft.Azure.Commands.IotCentral.Test.ScenarioTests
{
    public class IotCentralTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public IotCentralTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateSimpleIotCentralApp()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-CreateSimpleIotCentralApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateComplexIotCentralApp()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-CreateComplexIotCentralApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIotCentralAppsViaPiping()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-GetIotCentralAppsViaPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIotCentralAppsViaResourceIdPiping()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-GetIotCentralAppsViaResourceIdPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetIotCentralAppsFromEmptyGroup()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-GetIotCentralAppsFromEmptyGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetIotCentralAppMetadata()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-SetIotCentralAppMetadata");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveIotCentralApp()
        {
            IotCentralController.NewInstance.RunPsTest(_logger, "Test-RemoveIotCentralApp");
        }
    }
}
