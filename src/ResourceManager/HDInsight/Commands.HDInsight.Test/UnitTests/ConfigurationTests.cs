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
using Microsoft.Azure.Management.HDInsight;
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
            CreateNewConfig();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateNewConfigForRServer()
        {
            CreateNewConfig(setEdgeNodeVmSize: true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAddSparkCustomConfigs()
        {
            AzureHDInsightConfig config = new AzureHDInsightConfig();

            var addConfigValuesCmdlet = new AddAzureHDInsightConfigValuesCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Config = config,
                SparkDefaults = new System.Collections.Hashtable() { { @"spark.executor.instances", "3" } },
                SparkThriftConf = new System.Collections.Hashtable() { { @"spark.executor.cores", "4" } },
                Spark2Defaults = new System.Collections.Hashtable() { { @"spark.executor.memory", "2048m" } },
                Spark2ThriftConf = new System.Collections.Hashtable() { { @"spark.driver.memory.overhead", "1024" } },
            };

            addConfigValuesCmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
                        It.Is<AzureHDInsightConfig>(
                            c =>
                                c.Configurations != null &&
                                c.Configurations.ContainsKey(ConfigurationKey.SparkDefaults) &&
                                c.Configurations[ConfigurationKey.SparkDefaults]["spark.executor.instances"].Equals("3") &&
                                c.Configurations.ContainsKey(ConfigurationKey.SparkThriftConf) &&
                                c.Configurations[ConfigurationKey.SparkThriftConf]["spark.executor.cores"].Equals("4") &&
                                c.Configurations.ContainsKey(ConfigurationKey.Spark2Defaults) &&
                                c.Configurations[ConfigurationKey.Spark2Defaults]["spark.executor.memory"].Equals("2048m") &&
                                c.Configurations.ContainsKey(ConfigurationKey.Spark2ThriftConf) &&
                                c.Configurations[ConfigurationKey.Spark2ThriftConf]["spark.driver.memory.overhead"].Equals("1024") &&
                                c.ScriptActions.Count == 0)),
                Times.Once);
        }

        public void CreateNewConfig(bool setEdgeNodeVmSize = false)
        {
            var newconfigcmdlet = new NewAzureHDInsightClusterConfigCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                ClusterType = ClusterType
            };

            if (setEdgeNodeVmSize) newconfigcmdlet.EdgeNodeSize = "edgeNodeVmSizeSetTest";

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
                                ((!setEdgeNodeVmSize && string.IsNullOrEmpty(c.EdgeNodeSize)) || (setEdgeNodeVmSize && c.EdgeNodeSize == "edgeNodeVmSizeSetTest")) &&
                                c.HiveMetastore == null &&
                                c.OozieMetastore == null &&
                                c.ScriptActions.Count == 0)),
                Times.Once);
        }
    }
}
