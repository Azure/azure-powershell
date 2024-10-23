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

using Microsoft.Azure.Commands.HDInsight.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.HDInsight.Test.ScenarioTests
{
    public class HDInsightClusterTests : HDInsightTestRunner
    {
        public HDInsightClusterTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClusterRelatedCommands()
        {
            TestRunner.RunTestScript("Test-ClusterRelatedCommands");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestClusterEnableSecureChannelCommands()
        {
            TestRunner.RunTestScript("Test-ClusterEnableSecureChannelCommands");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCmkClusterRelatedCommands()
        {
            TestRunner.RunTestScript("Test-CmkClusterRelatedCommands");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithEncryptionInTransit()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithEncryptionInTransit");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithEncryptionAtHost()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithEncryptionAtHost");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithLoadBasedAutoscale()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithLoadBasedAutoscale");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithScheduleBasedAutoscale()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithScheduleBasedAutoscale");
        }

        [Fact(Skip ="need to create resource manually")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithKafkaRestProxy()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithKafkaRestProxy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithRelayOutoundAndPrivateLink()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithRelayOutoundAndPrivateLink");
        }

        [Fact(Skip = "Sikp this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithCustomAmbariDatabase()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithCustomAmbariDatabase");
        }

        [Fact(Skip = "need to create resource manually")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithComputeIsolation()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithComputeIsolation");
        }

        [Fact(Skip = "need to create resource manually")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithAvailabilityZones()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithAvailabilityZones");
        }

        [Fact(Skip = "need to create resource manually")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateClusterWithPrivateLinkConfiguration()
        {
            TestRunner.RunTestScript("Test-CreateClusterWithPrivateLinkConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCluster()
        {
            TestRunner.RunTestScript("Test-UpdateClusterTagsAndIdentity");
        }
    }
}
