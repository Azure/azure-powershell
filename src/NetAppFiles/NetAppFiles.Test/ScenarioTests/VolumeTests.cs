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

namespace Microsoft.Azure.Commands.NetAppFiles.Test.ScenarioTests.ScenarioTest
{
    public class VolumeTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public VolumeTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-VolumeCrud");
        }

        //---Note This test will be added to the next (2019-11-01) version ---
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumeReplication()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-VolumeReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetVolumePool()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetVolumePool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVolumePipelines()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-VolumePipelines");
        }
    }
}
