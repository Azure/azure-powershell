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
using System.Linq;
using Microsoft.Hadoop.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Utilities;
using Microsoft.WindowsAzure.Management.HDInsight;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.Azure.Commands.Common.Authentication;
using System.IO;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CommandTests
{
    [TestClass]
    public class HDInsightGetCommandTests : HDInsightTestCaseBase
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanPerform_GetClusters_HDInsightGetCommand()
        {
            var client = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            client.CurrentSubscription = GetCurrentSubscription();
            client.EndProcessing();
            IEnumerable<AzureHDInsightCluster> containers = from container in client.Output
                                                            where container.Name.Equals(TestCredentials.WellKnownCluster.DnsName)
                                                            select container;
            Assert.AreEqual(1, containers.Count());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanPerform_GetClusters_HDInsightGetCommand_DnsName()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            client.CurrentSubscription = GetCurrentSubscription();
            client.Name = TestCredentials.WellKnownCluster.DnsName;
            client.EndProcessing();
            IEnumerable<AzureHDInsightCluster> containers = from container in client.Output
                                                            where container.Name.Equals(TestCredentials.WellKnownCluster.DnsName)
                                                            select container;
            Assert.AreEqual(1, containers.Count());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanPerform_GetClusters_HDInsightGetCommand_InvalidDnsName()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            client.CurrentSubscription = GetCurrentSubscription();
            client.Name = Guid.NewGuid().ToString("N");
            client.EndProcessing();
            Assert.IsFalse(client.Output.Any());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CommandsNeedCurrentSubscriptionSet()
        {
            IHDInsightCertificateCredential creds = GetValidCredentials();
            var getClustersCommand = new GetAzureHDInsightClusterCommand();
            try
            {
                getClustersCommand.GetClient(false);
                Assert.Fail("Should have failed.");
            }
            catch (ArgumentNullException noSubscriptionException)
            {
                Assert.AreEqual(noSubscriptionException.ParamName, "CurrentSubscription");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetSubscriptionsCertificateCredentialFromCurrentSubscription()
        {
            var getClustersCommand = new GetAzureHDInsightClusterCommand();
            var waSubscription = GetCurrentSubscription();
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));

            var subscriptionCreds = getClustersCommand.GetSubscriptionCredentials(waSubscription, profileClient.Profile.Context.Environment, profileClient.Profile);

            Assert.IsInstanceOfType(subscriptionCreds, typeof(HDInsightCertificateCredential));
            var asCertificateCreds = subscriptionCreds as HDInsightCertificateCredential;
            Assert.AreEqual(waSubscription.GetId(), asCertificateCreds.SubscriptionId);
            Assert.IsNotNull(asCertificateCreds.Certificate);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetAccessTokenCertificateCredentialFromCurrentSubscription()
        {
            var getClustersCommand = new GetAzureHDInsightClusterCommand();
            var waSubscription = new AzureSubscription()
                {
                    Id = IntegrationTestBase.TestCredentials.SubscriptionId.ToString(),
                };
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));
            var acct = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
            };
            acct.SetSubscriptions(IntegrationTestBase.TestCredentials.SubscriptionId.ToString());
            profileClient.Profile.AccountTable["test"] = acct;
            profileClient.Profile.Save();

            waSubscription.SetAccount("test");
            var accessTokenCreds = getClustersCommand.GetSubscriptionCredentials(waSubscription, profileClient.Profile.Context.Environment, profileClient.Profile);
            Assert.IsInstanceOfType(accessTokenCreds, typeof(HDInsightAccessTokenCredential));
            var asAccessTokenCreds = accessTokenCreds as HDInsightAccessTokenCredential;
            Assert.AreEqual("abc", asAccessTokenCreds.AccessToken);
            Assert.AreEqual(waSubscription.GetId(), asAccessTokenCreds.SubscriptionId);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetJobSubmissionCertificateCredentialFromCurrentSubscription()
        {
            var getClustersCommand = new GetAzureHDInsightJobCommand();
            var waSubscription = GetCurrentSubscription();
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));

            var subscriptionCreds = getClustersCommand.GetJobSubmissionClientCredentials(
                waSubscription,
                profileClient.Profile.Context.Environment,
                IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName,
                profileClient.Profile);

            Assert.IsInstanceOfType(subscriptionCreds, typeof(JobSubmissionCertificateCredential));
            var asCertificateCreds = subscriptionCreds as JobSubmissionCertificateCredential;
            Assert.AreEqual(waSubscription.GetId(), asCertificateCreds.SubscriptionId);
            Assert.AreEqual(IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName, asCertificateCreds.Cluster);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetJobSubmissionAccessTokenCredentialFromCurrentSubscription()
        {
            var getClustersCommand = new GetAzureHDInsightJobCommand();
            var waSubscription = new AzureSubscription()
            {
                Id = IntegrationTestBase.TestCredentials.SubscriptionId.ToString(),
            };
            waSubscription.SetAccount("test");
            ProfileClient profileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));
            var waAccount = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
            };

            waAccount.SetSubscriptions(IntegrationTestBase.TestCredentials.SubscriptionId.ToString());
            profileClient.Profile.AccountTable["test"] = waAccount;
            profileClient.Profile.Save();
            var accessTokenCreds = getClustersCommand.GetJobSubmissionClientCredentials(
                waSubscription,
                profileClient.Profile.Context.Environment,
                IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName,
                profileClient.Profile);
            Assert.IsInstanceOfType(accessTokenCreds, typeof(HDInsightAccessTokenCredential));
            var asTokenCreds = accessTokenCreds as HDInsightAccessTokenCredential;
            Assert.IsNotNull(asTokenCreds);
            Assert.AreEqual("abc", asTokenCreds.AccessToken);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetBasicAuthCredentialFromCredentials()
        {
            var getClustersCommand = new GetAzureHDInsightJobCommand();
            getClustersCommand.Credential = GetPSCredential(TestCredentials.AzureUserName, TestCredentials.AzurePassword);
            var waSubscription = new AzureSubscription()
            {
                Id = IntegrationTestBase.TestCredentials.SubscriptionId.ToString(),
            };
            waSubscription.SetAccount("test");
            var profile = new AzureSMProfile();
            ProfileClient profileClient = new ProfileClient(
                new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile)));
            var accessTokenCreds = getClustersCommand.GetJobSubmissionClientCredentials(
                waSubscription,
                profileClient.Profile.Context.Environment,
                IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName, profile);
            Assert.IsInstanceOfType(accessTokenCreds, typeof(BasicAuthCredential));
            var asBasicAuthCredentials = accessTokenCreds as BasicAuthCredential;
            Assert.IsNotNull(asBasicAuthCredentials);
            Assert.AreEqual(IntegrationTestBase.TestCredentials.AzureUserName, asBasicAuthCredentials.UserName);
            Assert.AreEqual(IntegrationTestBase.TestCredentials.AzurePassword, asBasicAuthCredentials.Password);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void GetJobSubmissionCredentialsThrowsInvalidOperationException()
        {
            string invalidClusterName = Guid.NewGuid().ToString("N");
            var getClustersCommand = new GetAzureHDInsightJobCommand();

            try
            {
                getClustersCommand.GetClient(invalidClusterName);
                Assert.Fail("Should have failed.");
            }
            catch (InvalidOperationException invalidOperationException)
            {
                Assert.AreEqual("Expected either a Subscription or Credential parameter.", invalidOperationException.Message);
            }
        }

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
