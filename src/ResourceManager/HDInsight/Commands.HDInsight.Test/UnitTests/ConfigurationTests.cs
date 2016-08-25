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

using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class ConfigurationTests : HDInsightTestBase
    {
        public ConfigurationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewConfig()
        {
            var newconfigcmdlet = new NewAzureHDInsightClusterConfigCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterType = ClusterType
            };

            newconfigcmdlet.ExecuteCmdlet();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightConfig>(
                            c =>
                                c.ClusterType == ClusterType &&
                                c.AdditionalStorageAccounts.Count == 0 &&
                                c.Configurations.Count == 0 &&
                                string.IsNullOrEmpty(c.WorkerNodeSize) &&
                                string.IsNullOrEmpty(c.DefaultStorageAccountKey) &&
                                string.IsNullOrEmpty(c.DefaultStorageAccountName) &&
                                string.IsNullOrEmpty(c.HeadNodeSize) &&
                                string.IsNullOrEmpty(c.ZookeeperNodeSize) &&
                                c.HiveMetastore == null &&
                                c.OozieMetastore == null &&
                                c.ScriptActions.Count == 0)),
                Times.Once);
        }
    }
}
