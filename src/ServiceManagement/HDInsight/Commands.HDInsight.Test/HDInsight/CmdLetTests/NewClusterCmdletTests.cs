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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    [TestClass]
    public class NewClusterCmdletTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICanAddMultipleStorageAccountsUsingPowerShell()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var additionalStorageAccount = new WabStorageAccountConfiguration(
                    TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name,
                    TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key);
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, additionalStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, additionalStorageAccount.Key)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                List<AzureHDInsightStorageAccount> storageAccounts = getCommand.Output.Last().StorageAccounts.ToList();
                Assert.AreEqual(storageAccounts.Count, 1);

                AzureHDInsightStorageAccount additionalStorageAccountFromOutput =
                    storageAccounts.FirstOrDefault(acc => acc.StorageAccountName == additionalStorageAccount.Name);
                Assert.IsNotNull(additionalStorageAccountFromOutput);
                Assert.AreEqual(additionalStorageAccount.Key, additionalStorageAccountFromOutput.StorageAccountKey);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                    // Ensure that subscription id can be accepted as a sting as well as a guid.
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);


                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;
                getCommand.EndProcessing();
                Assert.AreEqual(0, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICanCreateAClusterUsingPowerShell()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results = runspace.NewPipeline()
                    .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                    // Ensure that the subscription Id can be accepted as a string as well as a guid.
                                                  .WithParameter(CmdletConstants.Name, dnsName)
                                                  .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                                                  .WithParameter(
                                                      CmdletConstants.DefaultStorageAccountName,
                                                      TestCredentials.Environments[0].DefaultStorageAccount.Name)
                                                  .WithParameter(
                                                      CmdletConstants.DefaultStorageAccountKey,
                                                      TestCredentials.Environments[0].DefaultStorageAccount.Key)
                                                  .WithParameter(
                                                      CmdletConstants.DefaultStorageContainerName,
                                                      TestCredentials.Environments[0].DefaultStorageAccount.Container)
                                                  .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                                                  .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                                                  .WithParameter(CmdletConstants.HeadNodeVMSize, NodeVMSize.ExtraLarge)
                                                  .WithParameter(CmdletConstants.ClusterType, ClusterType.Hadoop)
                                                  .WithParameter(CmdletConstants.VirtualNetworkId, Guid.NewGuid().ToString())
                                                  .WithParameter(CmdletConstants.SubnetName, "fakeSubnet")
                                                  .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(0, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void ICanCreateAClusterUsingPowerShellAndConfig()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var coreConfig = new Hashtable();
            coreConfig.Add("hadoop.logfile.size", "10000");

            var yarnConfig = new Hashtable();
            yarnConfig.Add("yarn.fakevalue", "12345");

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

            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .WithParameter(CmdletConstants.HeadNodeVMSize, NodeVMSize.Large)
                            .WithParameter(CmdletConstants.ClusterType, ClusterType.HBase)
                            .WithParameter(CmdletConstants.VirtualNetworkId, Guid.NewGuid().ToString())
                            .WithParameter(CmdletConstants.SubnetName, "fakeSubnet")
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.CoreConfig, coreConfig)
                            .WithParameter(CmdletConstants.YarnConfig, yarnConfig)
                            .WithParameter(CmdletConstants.HBaseConfig, hbaseServiceConfig)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                    // Ensure that the subscription Id can be accepted as a guid as well as a string.
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Version, TestCredentials.WellKnownCluster.Version)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                    // Ensure that subscription id can be accepted as a sting as well as a guid.
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void ICanCreateAClusterUsingPowerShellAndConfigWithAnStorageAccountAfterTheSet()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            // Ensure that the subscription Id can be accepted as a guid as well as a string.
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                    // Ensure that subscription id can be accepted as a sting as well as a guid.
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICanCreateAClusterUsingPowerShellAndConfigWithAnStorageAccountBeforeTheSet()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                    // Ensure that the subscription Id can be accepted as a guid as well as a string.
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                    // Ensure that subscription id can be accepted as a sting as well as a guid.
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICanCreateAClusterUsingPowerShellAndConfig_New_Set_Add_Hive_Oozie()
        {
            AzureTestCredentials creds = GetCredentials(TestCredentialsNames.Default);
            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, creds.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].AdditionalStorageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].AdditionalStorageAccounts[0].Key)
                            .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                            .WithParameter(CmdletConstants.SqlAzureServerName, creds.Environments[0].HiveStores[0].SqlServer)
                            .WithParameter(CmdletConstants.DatabaseName, creds.Environments[0].HiveStores[0].Database)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(creds.AzureUserName, creds.AzurePassword))
                            .WithParameter(CmdletConstants.MetastoreType, AzureHDInsightMetastoreType.HiveMetastore)
                            .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                            .WithParameter(CmdletConstants.SqlAzureServerName, creds.Environments[0].OozieStores[0].SqlServer)
                            .WithParameter(CmdletConstants.DatabaseName, creds.Environments[0].OozieStores[0].Database)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(creds.AzureUserName, creds.AzurePassword))
                            .WithParameter(CmdletConstants.MetastoreType, AzureHDInsightMetastoreType.OozieMetastore)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                    // Ensure that the subscription Id can be accepted as a guid as well as a string.
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                ClusterCreateParameters request = AzureHDInsightClusterManagementClientSimulator.LastCreateRequest;
                Assert.IsNotNull(request.HiveMetastore);
                Assert.IsNotNull(request.OozieMetastore);

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                    // Ensure that subscription id can be accepted as a sting as well as a guid.
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void ICanCreateAClusterUsingPowerShellAndConfig_New_Set_Add_Hive_Oozie_And_CoreConfig()
        {
            AzureTestCredentials creds = GetCredentials(TestCredentialsNames.Default);

            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, creds.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].AdditionalStorageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].AdditionalStorageAccounts[0].Key)
                            .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                            .WithParameter(CmdletConstants.SqlAzureServerName, creds.Environments[0].HiveStores[0].SqlServer)
                            .WithParameter(CmdletConstants.DatabaseName, creds.Environments[0].HiveStores[0].Database)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(creds.AzureUserName, creds.AzurePassword))
                            .WithParameter(CmdletConstants.MetastoreType, AzureHDInsightMetastoreType.HiveMetastore)
                            .AddCommand(CmdletConstants.AddAzureHDInsightMetastore)
                            .WithParameter(CmdletConstants.SqlAzureServerName, creds.Environments[0].OozieStores[0].SqlServer)
                            .WithParameter(CmdletConstants.DatabaseName, creds.Environments[0].OozieStores[0].Database)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential(creds.AzureUserName, creds.AzurePassword))
                            .WithParameter(CmdletConstants.MetastoreType, AzureHDInsightMetastoreType.OozieMetastore)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                ClusterCreateParameters request = AzureHDInsightClusterManagementClientSimulator.LastCreateRequest;
                Assert.IsNotNull(request.HiveMetastore);
                Assert.IsNotNull(request.OozieMetastore);

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void ICanCreateAClusterUsingPowerShellAndConfig_New_Set_Add_ScriptAction()
        {
            AzureTestCredentials creds = GetCredentials(TestCredentialsNames.Default);

            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, creds.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, creds.Environments[0].AdditionalStorageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, creds.Environments[0].AdditionalStorageAccounts[0].Key)
                            .AddCommand(CmdletConstants.AddAzureHDInsightScriptAction)
                            .WithParameter(CmdletConstants.ConfigActionName, "test1")
                            .WithParameter(CmdletConstants.ConfigActionClusterRoleCollection, "HeadNode")
                            .WithParameter(CmdletConstants.ScriptActionUri, "http://test1.com")
                            .WithParameter(CmdletConstants.ScriptActionParameters, "test1parameters")
                            .AddCommand(CmdletConstants.AddAzureHDInsightScriptAction)
                            .WithParameter(CmdletConstants.ConfigActionName, "test2")
                            .WithParameter(CmdletConstants.ConfigActionClusterRoleCollection, "HeadNode")
                            .WithParameter(CmdletConstants.ScriptActionUri, "http://test2.com")
                            .WithParameter(CmdletConstants.ScriptActionParameters, "test2parameters")
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                ClusterCreateParameters request = AzureHDInsightClusterManagementClientSimulator.LastCreateRequest;
                Assert.IsTrue(request.ConfigActions != null && request.ConfigActions.Count == 2);
                Assert.IsTrue(
                    request.ConfigActions.ElementAt(0).Name == "test1" &&
                    request.ConfigActions.ElementAt(1).Name == "test2");
                Assert.IsTrue(
                    request.ConfigActions.ElementAt(0).ClusterRoleCollection.Count == 1 &&
                    request.ConfigActions.ElementAt(1).ClusterRoleCollection.Count == 1);

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);

                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
            }
        }  

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]
        public void ICanCreateAClusterUsingPowerShellAndConfig_WithDebug()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var coreConfig = new Hashtable();
            coreConfig.Add("hadoop.logfile.size", "10000");

            string dnsName = this.GetRandomClusterName();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                var getCommandLogWriter = new PowershellLogWriter();
                BufferingLogWriterFactory.Instance = getCommandLogWriter;
                IGetAzureHDInsightClusterCommand getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Logger = getCommandLogWriter;
                getCommand.EndProcessing();
                int expected = getCommand.Output.Count();

                string expectedLogMessage = "Getting hdinsight clusters for subscriptionid : " + creds.SubscriptionId.ToString();
                Assert.IsTrue(getCommandLogWriter.Buffer.Any(message => message.Contains(expectedLogMessage)));
                BufferingLogWriterFactory.Reset();

                var newClusterCommandLogWriter = new PowershellLogWriter();
                BufferingLogWriterFactory.Instance = newClusterCommandLogWriter;
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightConfigValues)
                            .WithParameter(CmdletConstants.CoreConfig, coreConfig)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Debug, null)
                            .WithParameter(CmdletConstants.Version, TestCredentials.WellKnownCluster.Version)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                Assert.AreEqual(1, results.Results.Count);
                Assert.AreEqual(dnsName, results.Results.ToEnumerable<AzureHDInsightCluster>().First().Name);

                expectedLogMessage = string.Format(
                    CultureInfo.InvariantCulture, "Creating cluster '{0}' in location {1}", dnsName, CmdletConstants.EastUs);
                Assert.IsTrue(newClusterCommandLogWriter.Buffer.Any(message => message.Contains(expectedLogMessage)));
                BufferingLogWriterFactory.Reset();

                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();
                getCommand.Name = dnsName;

                getCommand.EndProcessing();
                Assert.AreEqual(1, getCommand.Output.Count);
                Assert.AreEqual(dnsName, getCommand.Output.ElementAt(0).Name);
                var deleteClusterCommandLogWriter = new PowershellLogWriter();
                BufferingLogWriterFactory.Instance = deleteClusterCommandLogWriter;
                results = runspace.NewPipeline().AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                                  .WithParameter(CmdletConstants.Name, dnsName)
                                  .WithParameter(CmdletConstants.Debug, null)
                                  .Invoke();

                Assert.AreEqual(0, results.Results.Count);
                expectedLogMessage = string.Format(
                    CultureInfo.InvariantCulture, "Deleting cluster '{0}' in location {1}", dnsName, CmdletConstants.EastUs);
                Assert.IsTrue(deleteClusterCommandLogWriter.Buffer.Any(message => message.Contains(expectedLogMessage)));
                getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                getCommand.CurrentSubscription = GetCurrentSubscription();

                getCommand.EndProcessing();
                Assert.AreEqual(expected, getCommand.Output.Count);
                BufferingLogWriterFactory.Reset();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICanCreateAClusterWithThreeOrMoreAsvAccountsUsingPowerShell()
        {
            string dnsName = this.GetRandomClusterName();
            var storageAccounts = GetWellKnownStorageAccounts().ToList();
            Assert.IsTrue(storageAccounts.Count >= 3);

            IHDInsightCertificateCredential creds = GetValidCredentials();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                IPipelineResult results =
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.NewAzureHDInsightClusterConfig)
                            .WithParameter(CmdletConstants.ClusterSizeInNodes, 3)
                            .AddCommand(CmdletConstants.SetAzureHDInsightDefaultStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, TestCredentials.Environments[0].DefaultStorageAccount.Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, TestCredentials.Environments[0].DefaultStorageAccount.Key)
                            .WithParameter(CmdletConstants.StorageContainerName, TestCredentials.Environments[0].DefaultStorageAccount.Container)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, storageAccounts[0].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, storageAccounts[0].Key)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, storageAccounts[1].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, storageAccounts[1].Key)
                            .AddCommand(CmdletConstants.AddAzureHDInsightStorage)
                            .WithParameter(CmdletConstants.StorageAccountName, storageAccounts[2].Name)
                            .WithParameter(CmdletConstants.StorageAccountKey, storageAccounts[2].Key)
                            .AddCommand(CmdletConstants.NewAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, dnsName)
                            .WithParameter(CmdletConstants.Location, CmdletConstants.EastUs)
                            .WithParameter(CmdletConstants.Credential, GetPSCredential("hadoop", this.GetRandomValidPassword()))
                            .Invoke();

                AzureHDInsightCluster clusterFromPowershell = results.Results.ToEnumerable<AzureHDInsightCluster>().First();
                List<AzureHDInsightStorageAccount> storageAccountsFromPowershell = clusterFromPowershell.StorageAccounts.ToList();
                Assert.AreEqual(3, storageAccountsFromPowershell.Count);

                foreach (WabStorageAccountConfiguration storageAccount in storageAccounts)
                {
                    AzureHDInsightStorageAccount additionalStorageAccountFromOutput =
                        storageAccountsFromPowershell.FirstOrDefault(acc => acc.StorageAccountName == storageAccount.Name);
                    Assert.IsNotNull(additionalStorageAccountFromOutput, "Storage account " + storageAccount.Name + " was not found");
                    Assert.AreEqual(storageAccount.Key, additionalStorageAccountFromOutput.StorageAccountKey);
                }
            }
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Integration")]
        [TestCategory("PowerShell")]

        public void ICannotDeleteANonExistantClusterUsingPowerShell()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            string invalidClusterName = Guid.NewGuid().ToString();
            using (IRunspace runspace = this.GetPowerShellRunspace())
            {
                try
                {
                    runspace.NewPipeline()
                            .AddCommand(CmdletConstants.RemoveAzureHDInsightCluster)
                            .WithParameter(CmdletConstants.Name, invalidClusterName)
                            .Invoke();
                    Assert.Fail("test failed");
                }
                catch (CmdletInvocationException invokeException)
                {
                    var invalidOperationException = invokeException.GetBaseException() as InvalidOperationException;
                    Assert.IsNotNull(invalidOperationException);
                    Assert.AreEqual("The cluster '" + invalidClusterName + "' doesn't exist.", invalidOperationException.Message);
                }
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
