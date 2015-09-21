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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class AddConfigValuesCmdletTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_CoreConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var coreConfig = new Hashtable();
                coreConfig.Add("hadoop.logfiles.size", "12345");
                RunConfigOptionstest(runspace, CmdletConstants.CoreConfig, coreConfig, c => c.CoreConfiguration);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_YarnConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var yarnConfig = new Hashtable();
                yarnConfig.Add("yarn.fakeconfig.value", "12345");
                RunConfigOptionstest(runspace, CmdletConstants.YarnConfig, yarnConfig, c => c.YarnConfiguration);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_HdfsConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var coreConfig = new Hashtable();
                coreConfig.Add("hadoop.logfiles.size", "12345");
                RunConfigOptionstest(runspace, CmdletConstants.HdfsConfig, coreConfig, c => c.HdfsConfiguration);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_StormConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var stormConfig = new Hashtable();
                stormConfig.Add("storm.fakeconfig.value", "12345");
                RunConfigOptionstest(runspace, CmdletConstants.StormConfig, stormConfig, c => c.StormConfiguration);
            }

        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_SparkConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var sparkConfig = new Hashtable();
                sparkConfig.Add("spark.fakeconfig.value", "12345");
                RunConfigOptionstest(runspace, CmdletConstants.SparkConfig, sparkConfig, c => c.SparkConfiguration);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_HiveConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var hiveConfig = new Hashtable();
                hiveConfig.Add("hadoop.logfiles.size", "12345");

                var hiveServiceConfig = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
                ValidateConfigurationOptions(hiveConfig, config.HiveConfiguration.ConfigurationCollection);
                Assert.IsNotNull(config.HiveConfiguration.AdditionalLibraries);

                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Container, hiveServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Key, hiveServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Name, hiveServiceConfig.AdditionalLibraries.StorageAccountName);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_HBaseConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var hbaseConfig = new Hashtable();
                hbaseConfig.Add("hbase.blob.size", "12345");

                var hbaseServiceConfig = new AzureHDInsightHBaseConfiguration
                {
                    Configuration = hbaseConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.HBaseConfig, hbaseServiceConfig)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
                ValidateConfigurationOptions(hbaseConfig, config.HBaseConfiguration.ConfigurationCollection);
                Assert.IsNotNull(config.HBaseConfiguration.AdditionalLibraries);

                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Container, hbaseServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Key, hbaseServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Name, hbaseServiceConfig.AdditionalLibraries.StorageAccountName);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_HiveConfig_Multiple_Invokes()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var hiveConfig = new Hashtable();
                hiveConfig.Add("hadoop.logfiles.size", "12345");


                var hiveServiceConfig = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };


                var hiveConfig2 = new Hashtable();
                hiveConfig.Add("hadoop.logfiles.size2", "12345");


                var hiveServiceConfig2 = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };


                var results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig)
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig2)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();


                Assert.IsNotNull(config.HiveConfiguration.AdditionalLibraries);


                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Container, hiveServiceConfig2.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Key, hiveServiceConfig2.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Name, hiveServiceConfig2.AdditionalLibraries.StorageAccountName);


                ValidateConfigurationOptions(hiveConfig, config.HiveConfiguration.ConfigurationCollection);
                ValidateConfigurationOptions(hiveConfig2, config.HiveConfiguration.ConfigurationCollection);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_HBaseConfig_Multiple_Invokes()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var hbaseConfig = new Hashtable();
                hbaseConfig.Add("hbase.logfiles.size", "12345");


                var hbaseServiceConfig = new AzureHDInsightHBaseConfiguration
                {
                    Configuration = hbaseConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };


                var hbaseConfig2 = new Hashtable();
                hbaseConfig2.Add("hadoop.logfiles.size2", "12345");


                var hbaseServiceConfig2 = new AzureHDInsightHBaseConfiguration
                {
                    Configuration = hbaseConfig2,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };


                var results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.HBaseConfig, hbaseServiceConfig)
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.HBaseConfig, hbaseServiceConfig2)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();


                Assert.IsNotNull(config.HBaseConfiguration.AdditionalLibraries);


                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Container, hbaseServiceConfig2.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Key, hbaseServiceConfig2.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config.HBaseConfiguration.AdditionalLibraries.Name, hbaseServiceConfig2.AdditionalLibraries.StorageAccountName);


                ValidateConfigurationOptions(hbaseConfig, config.HBaseConfiguration.ConfigurationCollection);
                ValidateConfigurationOptions(hbaseConfig2, config.HBaseConfiguration.ConfigurationCollection);
            }
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_MapReduceConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var coreConfig = new Hashtable();
                coreConfig.Add("hadoop.logfiles.size", "12345");
                var mapRedConfig = new AzureHDInsightMapReduceConfiguration { Configuration = coreConfig };
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.MapReduceConfig, mapRedConfig)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
                ValidateConfigurationOptions(coreConfig, config.MapReduceConfiguration.ConfigurationCollection);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_OozieConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var oozieConfig = new Hashtable();
                oozieConfig.Add("hadoop.logfiles.size", "12345");

                var oozieServiceConfig = new AzureHDInsightOozieConfiguration
                {
                    Configuration = oozieConfig,
                    AdditionalSharedLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        },
                    AdditionalActionExecutorLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.OozieConfig, oozieServiceConfig)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
                ValidateConfigurationOptions(oozieConfig, config.OozieConfiguration.ConfigurationCollection);

                Assert.IsNotNull(config.OozieConfiguration.AdditionalSharedLibraries);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalSharedLibraries.Container, oozieServiceConfig.AdditionalSharedLibraries.StorageContainerName);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalSharedLibraries.Key, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountKey);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalSharedLibraries.Name, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountName);

                Assert.IsNotNull(config.OozieConfiguration.AdditionalActionExecutorLibraries);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalActionExecutorLibraries.Container,
                    oozieServiceConfig.AdditionalActionExecutorLibraries.StorageContainerName);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalActionExecutorLibraries.Key,
                    oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountKey);
                Assert.AreEqual(
                    config.OozieConfiguration.AdditionalActionExecutorLibraries.Name,
                    oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountName);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_PreserveConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var coreConfig = new Hashtable();
                var yarnConfig = new Hashtable();
                var stormConfig = new Hashtable();
                var sparkConfig = new Hashtable();
                stormConfig.Add("storm.fakekey", "123");
                sparkConfig.Add("spark.fakekey", "123");
                var clusterConfig = new AzureHDInsightConfig
                {
                    HiveMetastore =
                        new AzureHDInsightMetastore
                        {
                            MetastoreType = AzureHDInsightMetastoreType.HiveMetastore,
                            Credential = GetPSCredential("hadoop", Guid.NewGuid().ToString()),
                            DatabaseName = Guid.NewGuid().ToString(),
                            SqlAzureServerName = Guid.NewGuid().ToString()
                        },
                    OozieMetastore =
                        new AzureHDInsightMetastore
                        {
                            MetastoreType = AzureHDInsightMetastoreType.OozieMetastore,
                            Credential = GetPSCredential("hadoop", Guid.NewGuid().ToString()),
                            DatabaseName = Guid.NewGuid().ToString(),
                            SqlAzureServerName = Guid.NewGuid().ToString()
                        }
                };

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, clusterConfig)
                            .WithParameter(CmdletConstants.CoreConfig, coreConfig)
                            .WithParameter(CmdletConstants.YarnConfig, yarnConfig)
                            .WithParameter(CmdletConstants.StormConfig, stormConfig)
                            .WithParameter(CmdletConstants.SparkConfig, sparkConfig)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();

                Assert.AreEqual(config.CoreConfiguration.Count, coreConfig.Count);
                Assert.AreEqual(config.YarnConfiguration.Count, yarnConfig.Count);
                Assert.AreEqual(config.StormConfiguration.Count, stormConfig.Count);
                Assert.AreEqual(config.SparkConfiguration.Count, sparkConfig.Count);

                foreach (object entry in coreConfig.Keys)
                {
                    KeyValuePair<string, string> configUnderTest =
                        config.CoreConfiguration.FirstOrDefault(c => string.Equals(c.Key, entry.ToString(), StringComparison.Ordinal));
                    Assert.IsNotNull(configUnderTest, "Unable to find core config option with name '{0}'", entry);
                    Assert.AreEqual(coreConfig[entry], configUnderTest.Value, "value doesn't match for core config option with name '{0}'", entry);
                }

                foreach (object entry in yarnConfig.Keys)
                {
                    KeyValuePair<string, string> configUnderTest =
                        config.YarnConfiguration.FirstOrDefault(c => string.Equals(c.Key, entry.ToString(), StringComparison.Ordinal));
                    Assert.IsNotNull(configUnderTest, "Unable to find yarn config option with name '{0}'", entry);
                    Assert.AreEqual(yarnConfig[entry], configUnderTest.Value, "value doesn't match for yarn config option with name '{0}'", entry);
                }

                foreach (object entry in stormConfig.Keys)
                {
                    KeyValuePair<string, string> configUnderTest =
                        config.StormConfiguration.FirstOrDefault(c => string.Equals(c.Key, entry.ToString(), StringComparison.Ordinal));
                    Assert.IsNotNull(configUnderTest, "Unable to find storm config option with name '{0}'", entry);
                    Assert.AreEqual(stormConfig[entry], configUnderTest.Value, "value doesn't match for storm config option with name '{0}'", entry);
                }

                foreach (object entry in sparkConfig.Keys)
                {
                    KeyValuePair<string, string> configUnderTest =
                        config.SparkConfiguration.FirstOrDefault(c => string.Equals(c.Key, entry.ToString(), StringComparison.Ordinal));
                    Assert.IsNotNull(configUnderTest, "Unable to find spark config option with name '{0}'", entry);
                    Assert.AreEqual(sparkConfig[entry], configUnderTest.Value, "value doesn't match for spark config option with name '{0}'", entry);
                }

                Assert.AreEqual(clusterConfig.HiveMetastore.DatabaseName, config.HiveMetastore.DatabaseName);
                Assert.AreEqual(clusterConfig.HiveMetastore.SqlAzureServerName, config.HiveMetastore.SqlAzureServerName);
                Assert.AreEqual(clusterConfig.HiveMetastore.Credential.UserName, config.HiveMetastore.Credential.UserName);
                Assert.AreEqual(clusterConfig.HiveMetastore.Credential.GetCleartextPassword(), config.HiveMetastore.Credential.GetCleartextPassword());

                Assert.AreEqual(clusterConfig.OozieMetastore.DatabaseName, config.OozieMetastore.DatabaseName);
                Assert.AreEqual(clusterConfig.OozieMetastore.SqlAzureServerName, config.OozieMetastore.SqlAzureServerName);
                Assert.AreEqual(clusterConfig.OozieMetastore.Credential.UserName, config.OozieMetastore.Credential.UserName);
                Assert.AreEqual(
                    clusterConfig.OozieMetastore.Credential.GetCleartextPassword(), config.OozieMetastore.Credential.GetCleartextPassword());
            }
        }
        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallTheAddConfigValuesCmdletTestsCmdlet_PreserveHiveConfig()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var hiveConfig = new Hashtable();
                hiveConfig.Add("hadoop.logfiles.size", "12345");

                var hiveServiceConfig = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                var hiveConfig2 = new Hashtable();
                hiveConfig2.Add("hadoop.logfiles.size2", "12345");

                var hiveServiceConfig2 = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig2,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                            .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig)
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig2)
                            .Invoke();
                AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
                ValidateConfigurationOptions(hiveConfig, config.HiveConfiguration.ConfigurationCollection);
                Assert.IsNotNull(config.HiveConfiguration.AdditionalLibraries);

                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Container, hiveServiceConfig2.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Key, hiveServiceConfig2.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config.HiveConfiguration.AdditionalLibraries.Name, hiveServiceConfig2.AdditionalLibraries.StorageAccountName);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCallAllConfigCmdlets_PreserveAll()
        {
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {

                var clusterConfig = new AzureHDInsightConfig
                {
                        ClusterType = Management.HDInsight.ClusterProvisioning.Data.ClusterType.HBase,
                        ClusterSizeInNodes = 7,
                        VirtualNetworkId = Guid.NewGuid().ToString(),
                        SubnetName = Guid.NewGuid().ToString(),
                        HeadNodeVMSize = Guid.NewGuid().ToString(),
                        DataNodeVMSize = Guid.NewGuid().ToString(),
                        ZookeeperNodeVMSize = Guid.NewGuid().ToString()
                };

                var coreConfig = new Hashtable();
                coreConfig.Add("core.fakekey", Guid.NewGuid().ToString());
                var yarnConfig = new Hashtable();
                yarnConfig.Add("yarn.fakekey", Guid.NewGuid().ToString());
                var stormConfig = new Hashtable();
                stormConfig.Add("storm.fakekey", Guid.NewGuid().ToString());
                var sparkConfig = new Hashtable();
                sparkConfig.Add("spark.fakekey", Guid.NewGuid().ToString());

                var hiveConfig = new Hashtable();
                hiveConfig.Add("hive.config.fakekey", Guid.NewGuid().ToString());
                var hiveServiceConfig = new AzureHDInsightHiveConfiguration
                {
                    Configuration = hiveConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                var hbaseConfig = new Hashtable();
                hbaseConfig.Add("hbase.config.fakekey", Guid.NewGuid().ToString());
                var hbaseServiceConfig = new AzureHDInsightHBaseConfiguration
                {
                    Configuration = hbaseConfig,
                    AdditionalLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                var oozieConfig = new Hashtable();
                oozieConfig.Add("oozie.config.fakekey", Guid.NewGuid().ToString());
                var oozieServiceConfig = new AzureHDInsightOozieConfiguration
                {
                    Configuration = oozieConfig, 
                    AdditionalSharedLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        },
                    AdditionalActionExecutorLibraries =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        }
                };

                var mapredConfig = new Hashtable();
                mapredConfig.Add("mapred.config.fakekey", Guid.NewGuid().ToString());
                var mapredCSConfig = new Hashtable();
                mapredCSConfig.Add("mapred.schedule.fakekey", Guid.NewGuid().ToString());
                var mapredServiceConfig = new AzureHDInsightMapReduceConfiguration
                {
                    Configuration = mapredConfig, 
                    CapacitySchedulerConfiguration = mapredCSConfig
                };


                IPipelineResult results1 =
                    runspace.NewPipeline()
                    .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                    .WithParameter(CmdletConstants.ClusterConfig, clusterConfig)
                    .WithParameter(CmdletConstants.CoreConfig, coreConfig)
                    .WithParameter(CmdletConstants.YarnConfig, yarnConfig)
                    .WithParameter(CmdletConstants.StormConfig, stormConfig)
                    .WithParameter(CmdletConstants.SparkConfig, sparkConfig)
                    .WithParameter(CmdletConstants.HiveConfig, hiveServiceConfig)
                    .WithParameter(CmdletConstants.HBaseConfig, hbaseServiceConfig)
                    .WithParameter(CmdletConstants.OozieConfig, oozieServiceConfig)
                    .WithParameter(CmdletConstants.MapReduceConfig, mapredServiceConfig)
                    .Invoke();
                AzureHDInsightConfig config1 = results1.Results.ToEnumerable<AzureHDInsightConfig>().First();

                Assert.AreEqual(config1.ClusterType, clusterConfig.ClusterType);
                Assert.AreEqual(config1.ClusterSizeInNodes, clusterConfig.ClusterSizeInNodes);
                Assert.AreEqual(config1.VirtualNetworkId, clusterConfig.VirtualNetworkId);
                Assert.AreEqual(config1.SubnetName, clusterConfig.SubnetName);
                Assert.AreEqual(config1.HeadNodeVMSize, clusterConfig.HeadNodeVMSize);
                Assert.AreEqual(config1.DataNodeVMSize, clusterConfig.DataNodeVMSize);
                Assert.AreEqual(config1.ZookeeperNodeVMSize, clusterConfig.ZookeeperNodeVMSize);
                
                ValidateConfigurationOptions(coreConfig, config1.CoreConfiguration);
                ValidateConfigurationOptions(yarnConfig, config1.YarnConfiguration);
                ValidateConfigurationOptions(stormConfig, config1.StormConfiguration);
                ValidateConfigurationOptions(sparkConfig, config1.SparkConfiguration);

                Assert.AreEqual(config1.HiveConfiguration.AdditionalLibraries.Container, hiveServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config1.HiveConfiguration.AdditionalLibraries.Key, hiveServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config1.HiveConfiguration.AdditionalLibraries.Name, hiveServiceConfig.AdditionalLibraries.StorageAccountName);
                ValidateConfigurationOptions(hiveConfig, config1.HiveConfiguration.ConfigurationCollection);

                Assert.AreEqual(config1.OozieConfiguration.AdditionalSharedLibraries.Container, oozieServiceConfig.AdditionalSharedLibraries.StorageContainerName);
                Assert.AreEqual(config1.OozieConfiguration.AdditionalSharedLibraries.Key, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountKey);
                Assert.AreEqual(config1.OozieConfiguration.AdditionalSharedLibraries.Name, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountName);
                Assert.AreEqual(config1.OozieConfiguration.AdditionalActionExecutorLibraries.Container, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageContainerName);
                Assert.AreEqual(config1.OozieConfiguration.AdditionalActionExecutorLibraries.Key, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountKey);
                Assert.AreEqual(config1.OozieConfiguration.AdditionalActionExecutorLibraries.Name, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountName);
                ValidateConfigurationOptions(oozieConfig, config1.OozieConfiguration.ConfigurationCollection);

                Assert.AreEqual(config1.HBaseConfiguration.AdditionalLibraries.Container, hbaseServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config1.HBaseConfiguration.AdditionalLibraries.Key, hbaseServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config1.HBaseConfiguration.AdditionalLibraries.Name, hbaseServiceConfig.AdditionalLibraries.StorageAccountName);
                ValidateConfigurationOptions(hbaseConfig, config1.HBaseConfiguration.ConfigurationCollection);

                ValidateConfigurationOptions(mapredConfig, config1.MapReduceConfiguration.ConfigurationCollection);
                ValidateConfigurationOptions(mapredCSConfig, config1.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
                
                // Now run through all of the other cmdlets


                var hiveMetastore =
                        new AzureHDInsightMetastore
                        {
                            MetastoreType = AzureHDInsightMetastoreType.HiveMetastore,
                            Credential = GetPSCredential("hadoop", Guid.NewGuid().ToString()),
                            DatabaseName = Guid.NewGuid().ToString(),
                            SqlAzureServerName = Guid.NewGuid().ToString()
                        };
                var oozieMetastore =
                        new AzureHDInsightMetastore
                        {
                            MetastoreType = AzureHDInsightMetastoreType.OozieMetastore,
                            Credential = GetPSCredential("hadoop", Guid.NewGuid().ToString()),
                            DatabaseName = Guid.NewGuid().ToString(),
                            SqlAzureServerName = Guid.NewGuid().ToString()
                        };
                var defaultStorage =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                            StorageContainerName = Guid.NewGuid().ToString()
                        };
                var additionalStorage =
                        new AzureHDInsightDefaultStorageAccount
                        {
                            StorageAccountKey = Guid.NewGuid().ToString(),
                            StorageAccountName = Guid.NewGuid().ToString(),
                        };
                var scriptAction =
                        new AzureHDInsightScriptAction
                        {
                            Name = Guid.NewGuid().ToString(),
                            Parameters = Guid.NewGuid().ToString(),
                            Uri = new Uri("http://somehost/script.ps1"),
                            ClusterRoleCollection = new ClusterNodeType[] { ClusterNodeType.DataNode, ClusterNodeType.HeadNode }
                        };

                IPipelineResult results2 =
                    runspace.NewPipeline()
                    .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                    .WithParameter(CmdletConstants.ClusterConfig, config1)
                    .WithParameter(CmdletConstants.MetastoreType, hiveMetastore.MetastoreType)
                    .WithParameter(CmdletConstants.Credential, hiveMetastore.Credential)
                    .WithParameter(CmdletConstants.SqlAzureServerName, hiveMetastore.SqlAzureServerName)
                    .WithParameter(CmdletConstants.DatabaseName, hiveMetastore.DatabaseName)
                    .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                    .WithParameter(CmdletConstants.MetastoreType, oozieMetastore.MetastoreType)
                    .WithParameter(CmdletConstants.Credential, oozieMetastore.Credential)
                    .WithParameter(CmdletConstants.SqlAzureServerName, oozieMetastore.SqlAzureServerName)
                    .WithParameter(CmdletConstants.DatabaseName, oozieMetastore.DatabaseName)
                    .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                    .WithParameter(CmdletConstants.StorageAccountKey, defaultStorage.StorageAccountKey)
                    .WithParameter(CmdletConstants.StorageAccountName, defaultStorage.StorageAccountName)
                    .WithParameter(CmdletConstants.StorageContainerName, defaultStorage.StorageContainerName)
                    .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                    .WithParameter(CmdletConstants.StorageAccountKey, additionalStorage.StorageAccountKey)
                    .WithParameter(CmdletConstants.StorageAccountName, additionalStorage.StorageAccountName)
                    .AddCommand(CmdletConstants.AddAzureHDInsightScriptAction)
                    .WithParameter(CmdletConstants.Name, scriptAction.Name)
                    .WithParameter(CmdletConstants.ScriptActionParameters, scriptAction.Parameters)
                    .WithParameter(CmdletConstants.ScriptActionUri, scriptAction.Uri)
                    .WithParameter(CmdletConstants.ConfigActionClusterRoleCollection, scriptAction.ClusterRoleCollection)
                    .Invoke();
                AzureHDInsightConfig config2 = results2.Results.ToEnumerable<AzureHDInsightConfig>().First();

                Assert.AreEqual(config2.ClusterType, clusterConfig.ClusterType);
                Assert.AreEqual(config2.ClusterSizeInNodes, clusterConfig.ClusterSizeInNodes);
                Assert.AreEqual(config2.VirtualNetworkId, clusterConfig.VirtualNetworkId);
                Assert.AreEqual(config2.SubnetName, clusterConfig.SubnetName);
                Assert.AreEqual(config2.HeadNodeVMSize, clusterConfig.HeadNodeVMSize);
                Assert.AreEqual(config2.DataNodeVMSize, clusterConfig.DataNodeVMSize);
                Assert.AreEqual(config2.ZookeeperNodeVMSize, clusterConfig.ZookeeperNodeVMSize);

                ValidateConfigurationOptions(coreConfig, config2.CoreConfiguration);
                ValidateConfigurationOptions(yarnConfig, config2.YarnConfiguration);
                ValidateConfigurationOptions(stormConfig, config2.StormConfiguration);
                ValidateConfigurationOptions(sparkConfig, config2.SparkConfiguration);

                Assert.IsNotNull(config2.HiveConfiguration.AdditionalLibraries);
                Assert.AreEqual(config2.HiveConfiguration.AdditionalLibraries.Container, hiveServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config2.HiveConfiguration.AdditionalLibraries.Key, hiveServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config2.HiveConfiguration.AdditionalLibraries.Name, hiveServiceConfig.AdditionalLibraries.StorageAccountName);
                ValidateConfigurationOptions(hiveConfig, config2.HiveConfiguration.ConfigurationCollection);

                Assert.IsNotNull(config2.OozieConfiguration.AdditionalSharedLibraries);
                Assert.IsNotNull(config2.OozieConfiguration.AdditionalActionExecutorLibraries);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalSharedLibraries.Container, oozieServiceConfig.AdditionalSharedLibraries.StorageContainerName);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalSharedLibraries.Key, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountKey);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalSharedLibraries.Name, oozieServiceConfig.AdditionalSharedLibraries.StorageAccountName);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalActionExecutorLibraries.Container, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageContainerName);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalActionExecutorLibraries.Key, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountKey);
                Assert.AreEqual(config2.OozieConfiguration.AdditionalActionExecutorLibraries.Name, oozieServiceConfig.AdditionalActionExecutorLibraries.StorageAccountName);
                ValidateConfigurationOptions(oozieConfig, config2.OozieConfiguration.ConfigurationCollection);

                Assert.IsNotNull(config2.HBaseConfiguration.AdditionalLibraries);
                Assert.AreEqual(config2.HBaseConfiguration.AdditionalLibraries.Container, hbaseServiceConfig.AdditionalLibraries.StorageContainerName);
                Assert.AreEqual(config2.HBaseConfiguration.AdditionalLibraries.Key, hbaseServiceConfig.AdditionalLibraries.StorageAccountKey);
                Assert.AreEqual(config2.HBaseConfiguration.AdditionalLibraries.Name, hbaseServiceConfig.AdditionalLibraries.StorageAccountName);
                ValidateConfigurationOptions(hbaseConfig, config2.HBaseConfiguration.ConfigurationCollection);
                
                Assert.IsNotNull(config2.MapReduceConfiguration);
                ValidateConfigurationOptions(mapredConfig, config2.MapReduceConfiguration.ConfigurationCollection);
                ValidateConfigurationOptions(mapredCSConfig, config2.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
                
                // This test currently only validates that the originally set values are not overwriten by Add-AzureHDInsightMetastore,
                // Add-AzureHDInsightScriptAction, Add-AzureHDInsightStorage, Set-AzureHDInsightDefaultStorage.  There are lots of
                // combinations of sequences, but the use of a shared copyfrom function should simplify the possible ways this can
                // break.
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        private static void RunConfigOptionstest(
            IRunspace runspace, string configOptionName, Hashtable expected, Func<AzureHDInsightConfig, ConfigValuesCollection> configPropertyAccessor)
        {
            IPipelineResult results =
                runspace.NewPipeline()
                        .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                        .WithParameter(CmdletConstants.ClusterConfig, new AzureHDInsightConfig())
                        .WithParameter(configOptionName, expected)
                        .Invoke();
            AzureHDInsightConfig config = results.Results.ToEnumerable<AzureHDInsightConfig>().First();
            ValidateConfigurationOptions(expected, configPropertyAccessor(config));
        }

        private static void ValidateConfigurationOptions(Hashtable expected, ConfigValuesCollection actual)
        {
            foreach (object entry in expected.Keys)
            {
                KeyValuePair<string, string> configUnderTest =
                    actual.FirstOrDefault(c => string.Equals(c.Key, entry.ToString(), StringComparison.Ordinal));
                Assert.IsNotNull(configUnderTest, "Unable to find config option with name '{0}'", entry);
                Assert.AreEqual(expected[entry], configUnderTest.Value, "value doesn't match for config option with name '{0}'", entry);
            }
        }
    }
}
