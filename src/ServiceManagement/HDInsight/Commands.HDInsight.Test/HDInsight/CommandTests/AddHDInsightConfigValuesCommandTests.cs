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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class AddHDInsightConfigValuesCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddCoreConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addCoreConfigValues.Core.Add("hadoop.log.file.size", "12345");
            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.CoreConfiguration.Any(configOption => configOption.Key == "hadoop.log.file.size" && configOption.Value == "12345"));
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddYarnConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addYarnConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addYarnConfigValues.Core.Add("yarn.fakekey", "12345");
            addYarnConfigValues.Config = config;
            addYarnConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addYarnConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.CoreConfiguration.Any(configOption => configOption.Key == "yarn.fakekey" && configOption.Value == "12345"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddHdfsConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addCoreConfigValues.Hdfs.Add("hadoop.log.file.size", "12345");
            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.HdfsConfiguration.Any(configOption => configOption.Key == "hadoop.log.file.size" && configOption.Value == "12345"));
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddHiveAdditionalLibrariesValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addCoreConfigValues.Hive.AdditionalLibraries = new AzureHDInsightDefaultStorageAccount
            {
                StorageAccountKey = Guid.NewGuid().ToString(),
                StorageAccountName = Guid.NewGuid().ToString(),
                StorageContainerName = Guid.NewGuid().ToString()
            };

            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsNotNull(newConfig.HiveConfiguration.AdditionalLibraries);
            Assert.AreEqual(
                newConfig.HiveConfiguration.AdditionalLibraries.Container, addCoreConfigValues.Hive.AdditionalLibraries.StorageContainerName);
            Assert.AreEqual(newConfig.HiveConfiguration.AdditionalLibraries.Key, addCoreConfigValues.Hive.AdditionalLibraries.StorageAccountKey);
            Assert.AreEqual(newConfig.HiveConfiguration.AdditionalLibraries.Name, addCoreConfigValues.Hive.AdditionalLibraries.StorageAccountName);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddHiveConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addCoreConfigValues.Hive.Configuration.Add("hadoop.log.file.size", "12345");
            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.HiveConfiguration.ConfigurationCollection.Any(
                    configOption => configOption.Key == "hadoop.log.file.size" && configOption.Value == "12345"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddMapReduceConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();
            addCoreConfigValues.MapReduce = new AzureHDInsightMapReduceConfiguration();
            addCoreConfigValues.MapReduce.Configuration.Add("hadoop.log.file.size", "12345");
            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.MapReduceConfiguration.ConfigurationCollection.Any(
                    configOption => configOption.Key == "hadoop.log.file.size" && configOption.Value == "12345"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanAddOozieConfigValues()
        {
            var config = new AzureHDInsightConfig();
            IAddAzureHDInsightConfigValuesCommand addCoreConfigValues =
                ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddConfig();

            addCoreConfigValues.Oozie.AdditionalSharedLibraries = new AzureHDInsightDefaultStorageAccount
            {
                StorageAccountKey = Guid.NewGuid().ToString(),
                StorageAccountName = Guid.NewGuid().ToString(),
                StorageContainerName = Guid.NewGuid().ToString()
            };

            addCoreConfigValues.Oozie.AdditionalActionExecutorLibraries = new AzureHDInsightDefaultStorageAccount
            {
                StorageAccountKey = Guid.NewGuid().ToString(),
                StorageAccountName = Guid.NewGuid().ToString(),
                StorageContainerName = Guid.NewGuid().ToString()
            };

            addCoreConfigValues.Oozie.Configuration.Add("hadoop.log.file.size", "12345");
            addCoreConfigValues.Config = config;
            addCoreConfigValues.EndProcessing();

            AzureHDInsightConfig newConfig = addCoreConfigValues.Output.First();

            Assert.AreEqual(config.ClusterSizeInNodes, newConfig.ClusterSizeInNodes);
            Assert.AreEqual(config.DefaultStorageAccount, newConfig.DefaultStorageAccount);
            Assert.IsTrue(
                newConfig.OozieConfiguration.ConfigurationCollection.Any(
                    configOption => configOption.Key == "hadoop.log.file.size" && configOption.Value == "12345"));
            Assert.IsNotNull(newConfig.OozieConfiguration.AdditionalSharedLibraries);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalSharedLibraries.Container,
                addCoreConfigValues.Oozie.AdditionalSharedLibraries.StorageContainerName);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalSharedLibraries.Key, addCoreConfigValues.Oozie.AdditionalSharedLibraries.StorageAccountKey);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalSharedLibraries.Name, addCoreConfigValues.Oozie.AdditionalSharedLibraries.StorageAccountName);

            Assert.IsNotNull(newConfig.OozieConfiguration.AdditionalActionExecutorLibraries);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalActionExecutorLibraries.Container,
                addCoreConfigValues.Oozie.AdditionalActionExecutorLibraries.StorageContainerName);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalActionExecutorLibraries.Key,
                addCoreConfigValues.Oozie.AdditionalActionExecutorLibraries.StorageAccountKey);
            Assert.AreEqual(
                newConfig.OozieConfiguration.AdditionalActionExecutorLibraries.Name,
                addCoreConfigValues.Oozie.AdditionalActionExecutorLibraries.StorageAccountName);
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
