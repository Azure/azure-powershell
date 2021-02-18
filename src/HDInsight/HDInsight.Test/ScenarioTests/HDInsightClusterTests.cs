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

namespace Commands.HDInsight.Test.ScenarioTests
{
    public class HDInsightClusterTests : TestController
    {
        public XunitTracingInterceptor _logger;

        public HDInsightClusterTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClusterRelatedCommands()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ClusterRelatedCommands");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCmkClusterRelatedCommands()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CmkClusterRelatedCommands");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithEncryptionInTransit()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithEncryptionInTransit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithEncryptionAtHost()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithEncryptionAtHost");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithLoadBasedAutoscale()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithLoadBasedAutoscale");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithScheduleBasedAutoscale()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithScheduleBasedAutoscale");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithKafkaRestProxy()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithKafkaRestProxy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithRelayOutoundAndPrivateLink()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithRelayOutoundAndPrivateLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithCustomAmbariDatabase()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithCustomAmbariDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithComputeIsolation()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateClusterWithComputeIsolation");
        }
    }
}
