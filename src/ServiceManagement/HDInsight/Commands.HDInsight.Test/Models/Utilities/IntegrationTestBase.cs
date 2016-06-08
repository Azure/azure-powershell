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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Concretes;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities
{
    public class IntegrationTestBase : DisposableObject
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification =
                "This is a bad pattern but is used strictly for test purposes.  This should be cleaned up later and should not be duplicated as a pattern elsewhere. [TGS]"
            )]
        public static readonly IntegrationTestManager TestManager = new IntegrationTestManager();

        private static bool IsInitialized = false;
        internal static Dictionary<string, string> testToClusterMap = new Dictionary<string, string>();

        protected static string ClusterPrefix;
        private static readonly List<Type> types = new List<Type>();
        private static IHDInsightSubscriptionCredentials invalidCertificate;
        private static IHDInsightSubscriptionCredentials invalidSubscriptionId;
        private static IHDInsightSubscriptionCredentials validCredentials;
        private IRunspace runspace;
        public static AzureTestCredentials TestCredentials { get; private set; }
        public TestContext TestContext { get; set; }

        public static IEnumerable<AzureTestCredentials> GetAllCredentials()
        {
            return TestManager.GetAllCredentials();
        }

        public static AzureSubscription GetCurrentSubscription()
        {
            string certificateThumbprint1 = "jb245f1d1257fw27dfc402e9ecde37e400g0176r";
            var newSubscription = new AzureSubscription()
            {
                Id = IntegrationTestBase.TestCredentials.SubscriptionId,
                // Use fake certificate thumbprint
                Account = certificateThumbprint1,
                Environment = "AzureCloud"
            };
            newSubscription.Properties[AzureSubscription.Property.Default] = "True";

            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            profileClient.Profile.Accounts[certificateThumbprint1] = 
                new AzureAccount()
                {
                    Id = certificateThumbprint1,
                    Type = AzureAccount.AccountType.Certificate
                };
            profileClient.Profile.Subscriptions[newSubscription.Id] = newSubscription;
            
            profileClient.Profile.Save();
            
            return profileClient.Profile.Subscriptions[newSubscription.Id];
        }

        public static AzureTestCredentials GetCredentialsForEnvironmentType(EnvironmentType type)
        {
            AzureTestCredentials[] environments = TestManager.GetAllCredentials().ToArray();
            for (int i = 0; i < environments.Length; i++)
            {
                if (environments[i].EnvironmentType == type)
                {
                    return environments[i];
                }
            }
            return null;
        }

        public static AzureTestCredentials GetCredentialsForLocation(string name, string location)
        {
            AzureTestCredentials namedCreds = GetCredentials(name);
            for (int i = 0; i < namedCreds.Environments.Length; i++)
            {
                if (namedCreds.Environments[i].Location == location)
                {
                    return CloneForEnvironment(namedCreds, i);
                }
            }
            return null;
        }

        public static AzureTestCredentials GetCredentialsForLocation(string location)
        {
            return GetCredentialsForLocation(TestCredentialsNames.Default, location);
        }

        public static IHDInsightCertificateCredential GetValidCredentials()
        {
            return validCredentials as IHDInsightCertificateCredential;
        }

        public static IEnumerable<WabStorageAccountConfiguration> GetWellKnownStorageAccounts()
        {
            var accounts = new List<WabStorageAccountConfiguration>();
            accounts.AddRange(
                TestCredentials.Environments.Select(
                    env =>
                    new WabStorageAccountConfiguration(
                        env.DefaultStorageAccount.Name, env.DefaultStorageAccount.Key, env.DefaultStorageAccount.Container)));
            accounts.AddRange(
                TestCredentials.Environments.SelectMany(env => env.AdditionalStorageAccounts)
                               .Select(acc => new WabStorageAccountConfiguration(acc.Name, acc.Key, acc.Container)));
            return accounts;
        }

        public static void TestRunCleanup()
        {
        }

        public static void TestRunSetup()
        {
            // This is to ensure that all key assemblies are loaded before IOC registration is required.
            // This is only necessary for the test system as load order is correct for a production run.
            // types.Add(typeof(GetAzureHDInsightClusterCmdlet));
            var cmdletRunManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            cmdletRunManager.RegisterType<IAzureHDInsightConnectionSessionManagerFactory, AzureHDInsightConnectionSessionManagerSimulatorFactory>();
            cmdletRunManager.RegisterType<IBufferingLogWriterFactory, BufferingLogWriterFactory>();
            cmdletRunManager.RegisterType<IAzureHDInsightStorageHandlerFactory, AzureHDInsightStorageHandlerSimulatorFactory>();
            cmdletRunManager.RegisterType<IAzureHDInsightSubscriptionResolverFactory, AzureHDInsightSubscriptionResolverSimulatorFactory>();
            cmdletRunManager.RegisterType<IAzureHDInsightClusterManagementClientFactory, AzureHDInsightClusterManagementClientSimulatorFactory>();
            cmdletRunManager.RegisterType<IAzureHDInsightJobSubmissionClientFactory, AzureHDInsightJobSubmissionClientSimulatorFactory>();
            var testManager = new IntegrationTestManager();
            AzureSession.DataStore = new MemoryDataStore();
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            TestCredentials = testManager.GetCredentials("default");
            if (TestCredentials == null)
            {
                Assert.Inconclusive("No entry was found in the credential config file for the specified test configuration.");
            }

            // Sets the certificate
            var defaultCertificate = new X509Certificate2(
                    Convert.FromBase64String(TestCredentials.Certificate), string.Empty);
            // Sets the test static properties
            ClusterPrefix = string.Format("CLITest-{0}", Environment.GetEnvironmentVariable("computername") ?? "unknown");

            // Sets the credential objects
            var tempCredentials = new HDInsightCertificateCredential
            {
                SubscriptionId = TestCredentials.SubscriptionId,
                Certificate = defaultCertificate
            };

            validCredentials = tempCredentials;
            tempCredentials = new HDInsightCertificateCredential { SubscriptionId = Guid.NewGuid(), Certificate = defaultCertificate };
            invalidSubscriptionId = tempCredentials;
            invalidCertificate = tempCredentials;
        }

        public void ApplyFullMocking()
        {
            WaitAzureHDInsightJobCommand.ReduceWaitTime = true;
            var cmdletManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            cmdletManager.MockingLevel = ServiceLocationMockingLevel.ApplyFullMocking;
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
            AzureSession.DataStore = new MemoryDataStore();
        }

        public void ApplyIndividualTestMockingOnly()
        {
            WaitAzureHDInsightJobCommand.ReduceWaitTime = false;
            var cmdletManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            cmdletManager.MockingLevel = ServiceLocationMockingLevel.ApplyIndividualTestMockingOnly;
        }

        public void ApplyNoMocking()
        {
            WaitAzureHDInsightJobCommand.ReduceWaitTime = false;
            var cmdletManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            cmdletManager.MockingLevel = ServiceLocationMockingLevel.ApplyNoMocking;
        }

        public void ApplySimulatorMockingOnly()
        {
            WaitAzureHDInsightJobCommand.ReduceWaitTime = true;
            var cmdletManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            cmdletManager.MockingLevel = ServiceLocationMockingLevel.ApplyTestRunMockingOnly;
        }

        public ClusterCreateParameters GetRandomCluster()
        {
            // Creates the cluster
            return new ClusterCreateParameters
            {
                Name = this.GetRandomClusterName(),
                UserName = TestCredentials.AzureUserName,
                Password = this.GetRandomValidPassword(),
                Location = "East US 2",
                Version = "default",
                DefaultStorageAccountName = TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageAccountKey = TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageContainer = TestCredentials.Environments[0].DefaultStorageAccount.Container,
                ClusterSizeInNodes = 3
            };
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "Azure names must be lowercase.")]
        public string GetRandomClusterName()
        {
            // Random DNS name.
            DateTime time = DateTime.UtcNow;
            string retval =
                string.Format(
                    "{0}-{1}{2}{3}-{4}",
                    ClusterPrefix,
                    time.Month.ToString("00"),
                    time.Day.ToString("00"),
                    time.Hour.ToString("00"),
                    Guid.NewGuid().ToString("N")).ToLowerInvariant();
            testToClusterMap.Add(retval, Environment.StackTrace);
            return retval;
        }

        public string GetRandomValidPassword()
        {
            return Guid.NewGuid().ToString().ToUpperInvariant().Replace('A', 'a').Replace('B', 'b').Replace('C', 'c') + "forTest!";
        }

        public virtual void Initialize()
        {
            if (!IsInitialized)
            {
                TestRunSetup();
                IsInitialized = true;
            }

            this.ApplyFullMocking();
            this.ResetIndividualMocks();
        }

        public void ResetIndividualMocks()
        {
            var cmdletManager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();
            cmdletManager.Reset();
        }

        public virtual void TestCleanup()
        {
            this.ApplyFullMocking();
            this.ResetIndividualMocks();
        }

        protected static PSCredential GetAzurePsCredentials()
        {
            return GetPSCredential(TestCredentials.AzureUserName, TestCredentials.AzurePassword);
        }

        protected static AzureTestCredentials GetCredentials(string name)
        {
            return TestManager.GetCredentials(name);
        }

        protected static IHDInsightCertificateCredential GetInvalidCertificateCredentials()
        {
            return invalidCertificate as IHDInsightCertificateCredential;
        }

        protected static IHDInsightCertificateCredential GetInvalidSubscriptionIdCredentials()
        {
            return invalidSubscriptionId as IHDInsightCertificateCredential;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope",
            Justification = "Need secure string for pscredential object.")]
        protected static PSCredential GetPSCredential(string userName, string password)
        {
            var securePassword = new SecureString();

            foreach (char character in password)
            {
                securePassword.AppendChar(character);
            }

            return new PSCredential(userName, securePassword);
        }

        protected IRunspace GetPowerShellRunspace(string location)
        {
            if (this.runspace.IsNull())
            {
                // string loc = typeof(GetAzureHDInsightClusterCmdlet).Assembly.Location;
                this.runspace = Help.SafeCreate(() => RunspaceAbstraction.Create());
                this.runspace.NewPipeline().AddCommand("Import-Module").WithParameter("Name", location).Invoke();
            }
            return this.runspace;
        }

        private static AzureTestCredentials CloneForEnvironment(AzureTestCredentials orig, int index)
        {
            var retval = new AzureTestCredentials();
            retval.AzurePassword = orig.AzurePassword;
            retval.AzureUserName = orig.AzureUserName;
            retval.Certificate = orig.Certificate;
            retval.CredentialsName = orig.CredentialsName;
            retval.HadoopUserName = orig.HadoopUserName;
            retval.InvalidCertificate = orig.InvalidCertificate;
            retval.SubscriptionId = orig.SubscriptionId;
            retval.ResourceProviderProperties = orig.ResourceProviderProperties;
            retval.WellKnownCluster = new KnownCluster
            {
                Cluster = orig.WellKnownCluster.Cluster,
                DnsName = orig.WellKnownCluster.DnsName,
                Version = orig.WellKnownCluster.Version
            };
            retval.Environments = new CreationDetails[0];
            CreationDetails env = retval.Environments[0] = new CreationDetails();
            CreationDetails origEnv = orig.Environments[index];
            retval.CloudServiceName = orig.CloudServiceName;
            env.DefaultStorageAccount = new StorageAccountCredentials
            {
                Container = origEnv.DefaultStorageAccount.Container,
                Key = origEnv.DefaultStorageAccount.Key,
                Name = origEnv.DefaultStorageAccount.Name
            };
            retval.Endpoint = orig.Endpoint;
            env.Location = origEnv.Location;
            retval.EnvironmentType = orig.EnvironmentType;
            var storageAccounts = new List<StorageAccountCredentials>();
            foreach (StorageAccountCredentials storageAccountCredentials in origEnv.AdditionalStorageAccounts)
            {
                var account = new StorageAccountCredentials
                {
                    Container = storageAccountCredentials.Container,
                    Key = storageAccountCredentials.Key,
                    Name = storageAccountCredentials.Name
                };
                storageAccounts.Add(account);
            }
            env.AdditionalStorageAccounts = storageAccounts.ToArray();
            var stores = new List<MetastoreCredentials>();
            foreach (MetastoreCredentials metastoreCredentials in origEnv.HiveStores)
            {
                var metaStore = new MetastoreCredentials
                {
                    Database = metastoreCredentials.Database,
                    Description = metastoreCredentials.Description,
                    SqlServer = metastoreCredentials.SqlServer
                };
            }
            env.HiveStores = stores.ToArray();
            stores.Clear();
            foreach (MetastoreCredentials metastoreCredentials in origEnv.OozieStores)
            {
                var metaStore = new MetastoreCredentials
                {
                    Database = metastoreCredentials.Database,
                    Description = metastoreCredentials.Description,
                    SqlServer = metastoreCredentials.SqlServer
                };
            }
            env.OozieStores = stores.ToArray();
            return retval;
        }

        public static class TestCredentialsNames
        {
            public const string Default = "default";
        }
    }
}
