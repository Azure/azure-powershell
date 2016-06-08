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

using System.Collections;
using System.Security;
using System.Text;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.ServiceBus.Management;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.ServiceManagemenet.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Profile
{
    public class ProfileCmdltsTests
    {
        private AzureSubscription azureSubscription1;
        private AzureSubscription azureSubscription2;
        private AzureEnvironment azureEnvironment;
        private AzureAccount azureAccount;
        private MockCommandRuntime commandRuntimeMock;
        private X509Certificate2 SampleCertificate = new X509Certificate2(Convert.FromBase64String(@"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"), string.Empty);
        private MemoryDataStore dataStore;

        public ProfileCmdltsTests()
            : base()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            SetMockData();
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClearAzureProfileClearsDefaultProfile()
        {
            ClearAzureProfileCommand cmdlt = new ClearAzureProfileCommand();
            // Setup
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Force = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            Assert.Equal(0, client.Profile.Subscriptions.Count);
            Assert.Equal(0, client.Profile.Accounts.Count);
            Assert.Equal(4, client.Profile.Environments.Count); //only default environments
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClearAzureProfileClearsCustomProfile()
        {
            string subscriptionDataFile = Path.GetTempFileName();

            ClearAzureProfileCommand cmdlt = new ClearAzureProfileCommand();
            // Setup
            ProfileClient client = new ProfileClient(new AzureSMProfile(subscriptionDataFile));
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Force = new SwitchParameter(true);
            cmdlt.Profile = new AzureSMProfile(subscriptionDataFile);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient(new AzureSMProfile(subscriptionDataFile));
            Assert.Equal(0, client.Profile.Subscriptions.Count);
            Assert.Equal(0, client.Profile.Accounts.Count);
            Assert.Equal(4, client.Profile.Environments.Count); //only default environments
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClearAzureProfileClearsTokenCache()
        {
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ClearAzureProfileCommand cmdlt = new ClearAzureProfileCommand();
            AzureSession.DataStore = new MemoryDataStore();
            AzureSession.TokenCache = new ProtectedFileTokenCache(Path.Combine(AzureSession.ProfileDirectory, AzureSession.TokenCacheFile));

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Force = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            var tokenCache = AzureSession.TokenCache as ProtectedFileTokenCache;
            tokenCache.HasStateChanged = true;

            // HACK: Do not look at this code
            TokenCacheNotificationArgs args = new TokenCacheNotificationArgs();
            typeof(TokenCacheNotificationArgs).GetProperty("ClientId").SetValue(args, "123");
            typeof(TokenCacheNotificationArgs).GetProperty("Resource").SetValue(args, "123");
            typeof(TokenCacheNotificationArgs).GetProperty("TokenCache").SetValue(args, tokenCache);
            typeof(TokenCacheNotificationArgs).GetProperty("UniqueId").SetValue(args, "test@live.com");
            typeof(TokenCacheNotificationArgs).GetProperty("DisplayableId").SetValue(args, "test@live.com");
            AuthenticationResult authenticationResult =
                typeof(AuthenticationResult).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                    null, new Type[] { typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset) }, null).Invoke(new object[]
                    {
                        "foo", "123", "123",
                        new DateTimeOffset(DateTime.Now.AddDays(1))
                    }) as AuthenticationResult;
            var storeToCache = typeof(TokenCache).GetMethod("StoreToCache", BindingFlags.Instance | BindingFlags.NonPublic);
            storeToCache.Invoke(tokenCache,
                new object[] { authenticationResult, "Common", "123", "123", 0, null});

            tokenCache.AfterAccess.Invoke(args);

            Assert.Equal(1, tokenCache.ReadItems().Count());
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();
            // Verify
            Assert.Equal(0, tokenCache.ReadItems().Count());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeleteCorruptedTokenCache()
        {
            //setup
            string testFileName = @"c:\foobar\TokenCache.dat";
            AzureSession.DataStore.WriteFile(testFileName, new byte[] { 0, 1 });

            //Act
            ProtectedFileTokenCache tokenCache = new ProtectedFileTokenCache(testFileName);

            //Assert
            Assert.False(AzureSession.DataStore.FileExists(testFileName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionAddsSubscriptionWithCertificate()
        {
            RunMockedCmdletTest(() =>
            {

                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                ProfileClient client = new ProfileClient(profile);
                AzureSMProfileProvider.Instance.Profile = profile;
                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
                // Setup
                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = Guid.NewGuid().ToString();
                cmdlt.SubscriptionName = "NewSubscriptionName";
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.Certificate = SampleCertificate;

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                var newAccount = client.Profile.Accounts[SampleCertificate.Thumbprint];
                Assert.Equal(cmdlt.SubscriptionName, newSubscription.Name);
                Assert.Equal(EnvironmentName.AzureCloud, newSubscription.Environment);
                Assert.True(
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)
                        .Contains(string.Format("AccountName={0}", cmdlt.CurrentStorageAccountName)));

                Assert.Equal(newAccount.Id, newSubscription.Account);
                Assert.Equal(AzureAccount.AccountType.Certificate, newAccount.Type);
                Assert.Equal(SampleCertificate.Thumbprint, newAccount.Id);
                Assert.Equal(cmdlt.SubscriptionId,
                    newAccount.GetProperty(AzureAccount.Property.Subscriptions));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionDerivesEnvironmentFromEnvironmentParameterOnAdd()
        {
            RunMockedCmdletTest(() =>
            {

                // Setup
                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                AzureSMCmdlet.CurrentProfile = profile;
                ProfileClient client = new ProfileClient(profile);
                client.AddOrSetEnvironment(azureEnvironment);
                client.Profile.Save();
                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = Guid.NewGuid().ToString();
                cmdlt.SubscriptionName = "NewSubscriptionName";
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.Environment = azureEnvironment.Name;
                cmdlt.Certificate = SampleCertificate;

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client =
                    new ProfileClient(
                        new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory,
                            AzureSession.ProfileFile)));
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                Assert.Equal(cmdlt.SubscriptionName, newSubscription.Name);
                Assert.Equal(cmdlt.Environment, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionThrowsExceptionWithoutCertificateOnAdd()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = Guid.NewGuid().ToString();
            cmdlt.SubscriptionName = "NewSubscriptionName";
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.Environment = azureEnvironment.Name;

            // Verify
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionDerivesEnvironmentFromEnvironmentParameterOnSet()
        {
            RunMockedCmdletTest(() =>
            {

                // Setup
                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                AzureSMCmdlet.CurrentProfile = profile;
                ProfileClient client = new ProfileClient(profile);
                client.AddOrSetAccount(azureAccount);
                client.AddOrSetEnvironment(azureEnvironment);
                client.AddOrSetSubscription(azureSubscription1);
                client.Profile.Save();
                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.Environment = azureEnvironment.Name;

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client =
                    new ProfileClient(
                        new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory,
                            AzureSession.ProfileFile)));
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                Assert.Equal(cmdlt.Environment, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionDerivesEnvironmentFromServiceEndpointParameterOnSet()
        {
            RunMockedCmdletTest(() =>
            {

                // Setup
                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                AzureSMCmdlet.CurrentProfile = profile;
                ProfileClient client = new ProfileClient(profile);
                client.AddOrSetAccount(azureAccount);
                client.AddOrSetEnvironment(azureEnvironment);
                client.AddOrSetSubscription(azureSubscription1);
                client.Profile.Save();
                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.ServiceEndpoint =
                    azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement);

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client =
                    new ProfileClient(
                        new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory,
                            AzureSession.ProfileFile)));
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                Assert.Equal(cmdlt.Environment, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionDerivesEnvironmentFromResourcesEndpointParameterOnSet()
        {
            RunMockedCmdletTest(() =>
            {
                // Setup
                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                ProfileClient client = new ProfileClient(profile);
                AzureSMCmdlet.CurrentProfile = profile;
                client.AddOrSetAccount(azureAccount);
                client.AddOrSetEnvironment(azureEnvironment);
                client.AddOrSetSubscription(azureSubscription1);
                client.Profile.Save();
                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.ResourceManagerEndpoint =
                    azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client = new ProfileClient(profile);
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                Assert.Equal(cmdlt.Environment, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionDerivesEnvironmentFromBothEndpointParameters()
        {
            RunMockedCmdletTest(() =>
            {
                // Setup
                var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                AzureSMCmdlet.CurrentProfile = profile;
                ProfileClient client = new ProfileClient(profile);
                client.AddOrSetAccount(azureAccount);
                client.AddOrSetEnvironment(azureEnvironment);
                client.AddOrSetSubscription(azureSubscription1);
                client.Profile.Save();

                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.ServiceEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement);
                cmdlt.ResourceManagerEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client =
                    new ProfileClient(
                        new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                Assert.Equal(cmdlt.Environment, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureSubscriptionUpdatesSubscriptionWithCertificate()
        {
            RunMockedCmdletTest(() =>
            {

                // Setup
                var profile =
                    new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
                AzureSMCmdlet.CurrentProfile = profile;
                ProfileClient client = new ProfileClient(profile);
                client.AddOrSetAccount(azureAccount);
                client.AddOrSetEnvironment(azureEnvironment);
                client.AddOrSetSubscription(azureSubscription1);
                client.Profile.Save();

                SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();

                cmdlt.CommandRuntime = commandRuntimeMock;
                cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
                cmdlt.CurrentStorageAccountName = "NewCloudStorage";
                cmdlt.Certificate = SampleCertificate;

                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                client =
                    new ProfileClient(
                        new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory,
                            AzureSession.ProfileFile)));
                var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
                var newAccount = client.Profile.Accounts[SampleCertificate.Thumbprint];
                var existingAccount = client.Profile.Accounts[azureAccount.Id];
                Assert.Equal(azureEnvironment.Name, newSubscription.Environment);
                Assert.True(StorageAccountMatchesConnectionString(cmdlt.CurrentStorageAccountName,
                    newSubscription.GetProperty(AzureSubscription.Property.StorageAccount)));

                Assert.Equal(newAccount.Id, newSubscription.Account);
                Assert.Equal(AzureAccount.AccountType.Certificate, newAccount.Type);
                Assert.Equal(SampleCertificate.Thumbprint, newAccount.Id);
                Assert.Equal(cmdlt.SubscriptionId,
                    newAccount.GetProperty(AzureAccount.Property.Subscriptions));

                Assert.Equal(azureAccount.Id, existingAccount.Id);
                Assert.Equal(AzureAccount.AccountType.User, existingAccount.Type);
                Assert.True(
                    existingAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                        .Contains(cmdlt.SubscriptionId));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ImportPublishSettingsFileSelectsCorrectEnvironment()
        {
            ImportAzurePublishSettingsCommand cmdlt = new ImportAzurePublishSettingsCommand();

            // Setup
            AzureSession.DataStore.WriteFile("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings",
                Commands.Common.Test.Properties.Resources.ValidProfileChina);
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            var oldDataStore = FileUtilities.DataStore;
            FileUtilities.DataStore = AzureSession.DataStore;
            var expectedEnv = "AzureChinaCloud";
            var expected = client.ImportPublishSettings("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings", null);

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.ProfileClient = new ProfileClient(profile);
            cmdlt.PublishSettingsFile = "ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings";

            try
            {
                // Act
                cmdlt.InvokeBeginProcessing();
                AzureSession.DataStore = FileUtilities.DataStore;
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                foreach (var subscription in expected)
                {
                    Assert.Equal(cmdlt.ProfileClient.GetSubscription(subscription.Id).Environment, expectedEnv);
                }
                Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            }
            finally
            {
                // Cleanup
                FileUtilities.DataStore = oldDataStore;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ImportPublishSettingsFileOverwritesEnvironment()
        {
            ImportAzurePublishSettingsCommand cmdlt = new ImportAzurePublishSettingsCommand();
            var oldAzureDataStore = AzureSession.DataStore;
            AzureSession.DataStore = new MemoryDataStore();
            // Setup
            AzureSession.DataStore.WriteFile("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings",
                Commands.Common.Test.Properties.Resources.ValidProfileChina);
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            var oldDataStore = FileUtilities.DataStore;
            FileUtilities.DataStore = AzureSession.DataStore;
            var expectedEnv = "AzureCloud";
            var expected = client.ImportPublishSettings("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings", expectedEnv);

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.ProfileClient = client;
            cmdlt.PublishSettingsFile = "ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings";
            cmdlt.Environment = expectedEnv;

            try
            {
                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                foreach (var subscription in expected)
                {
                    Assert.Equal(cmdlt.ProfileClient.GetSubscription(subscription.Id).Environment, expectedEnv);
                }
                Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            }
            finally
            {
                // Cleanup
                FileUtilities.DataStore = oldDataStore;
                AzureSession.DataStore = oldAzureDataStore;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ImportPublishSettingsWorksForCustomProfile()
        {
            ImportAzurePublishSettingsCommand cmdlt = new ImportAzurePublishSettingsCommand();
            var oldAzureDataStore = AzureSession.DataStore;
            AzureSession.DataStore = new MemoryDataStore();
            // Setup
            AzureSession.DataStore.WriteFile("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings",
                Commands.Common.Test.Properties.Resources.ValidProfileChina);
            var oldProfile = new AzureSMProfile();
            AzureSMCmdlet.CurrentProfile = oldProfile;
            var profile = new AzureSMProfile();
            ProfileClient client = new ProfileClient(profile);
            var oldDataStore = FileUtilities.DataStore;
            FileUtilities.DataStore = AzureSession.DataStore;
            var expectedEnv = "AzureCloud";
            var expected = client.ImportPublishSettings("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings", expectedEnv);
            AzureSMCmdlet.CurrentProfile = new AzureSMProfile();
            cmdlt.Profile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.ProfileClient = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            cmdlt.PublishSettingsFile = "ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings";
            cmdlt.Environment = expectedEnv;

            try
            {
                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();

                // Verify
                foreach (var subscription in expected)
                {
                    Assert.Equal(client.GetSubscription(subscription.Id).Environment, expectedEnv);
                }
                Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
                Assert.Equal(oldProfile.Subscriptions.Count, 0);
                Assert.Equal(oldProfile.Accounts.Count, 0);
            }
            finally
            {
                // Cleanup
                FileUtilities.DataStore = oldDataStore;
                AzureSession.DataStore = oldAzureDataStore;
            }
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectDefaultAzureSubscriptionByNameUpdatesProfile()
        {
            var client = SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectDefaultSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;
            cmdlt.Default = new SwitchParameter(true);
            Assert.NotEqual(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            Assert.NotNull(client.Profile.DefaultSubscription);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByNameUpdatesProfile()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(cmdlt.Profile.Context.Subscription);
            Assert.Equal(azureSubscription2.Id, cmdlt.Profile.Context.Subscription.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByNameUpdatesCustomProfile()
        {
            var client = SetupDefaultProfile();
            var profile = SetupCustomProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;
            cmdlt.Profile = profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(cmdlt.Profile.Context.Subscription);
            Assert.Equal(azureSubscription2.Id, cmdlt.Profile.Context.Subscription.Id);
            // current profile unchanged
            Assert.Equal(azureSubscription1.Id, client.Profile.Context.Subscription.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByNameWithoutAccountPreservesTheAccount()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(cmdlt.Profile.Context.Subscription);
            Assert.Equal(azureSubscription2.Account, cmdlt.Profile.Context.Subscription.Account);
            Assert.Equal(azureSubscription2.Id, cmdlt.Profile.Context.Subscription.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByIdWithoutAccountPreservesTheAccount()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            cmdlt.SubscriptionId = azureSubscription2.Id.ToString();

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(cmdlt.Profile.Context.Subscription);
            Assert.Equal(azureSubscription2.Account, cmdlt.Profile.Context.Subscription.Account);
            Assert.Equal(azureSubscription2.Id, cmdlt.Profile.Context.Subscription.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionWithoutPassthroughDoesNotPrint()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionWithPassthroughPrintsSubscription()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;
            cmdlt.PassThru = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            Assert.True(commandRuntimeMock.OutputPipeline[0] is PSAzureSubscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectDefaultAzureSubscriptionByIdAndNoDefaultUpdatesProfile()
        {
            var client = SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectDefaultSubscriptionByIdParameterSet");
            cmdlt.SubscriptionId = azureSubscription2.Id.ToString();
            cmdlt.Default = new SwitchParameter(true);
            Assert.NotEqual(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            Assert.NotNull(client.Profile.DefaultSubscription);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("NoDefaultSubscriptionParameterSet");
            cmdlt.NoDefault = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            Assert.Null(client.Profile.DefaultSubscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByInvalidIdThrowsException()
        {
            SetupDefaultProfile();
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            string invalidGuid = Guid.NewGuid().ToString();
            cmdlt.SubscriptionId = invalidGuid;

            // Act
            cmdlt.InvokeBeginProcessing();
            try
            {
                cmdlt.ExecuteCmdlet();
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(string.Format("The subscription id {0} doesn't exist.\r\nParameter name: id", invalidGuid), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureSubscriptionByInvalidGuidThrowsException()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            string invalidGuid = "foo";
            cmdlt.SubscriptionId = invalidGuid;

            // Act
            cmdlt.InvokeBeginProcessing();
            try
            {
                cmdlt.ExecuteCmdlet();
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(string.Format(Microsoft.WindowsAzure.Commands.Common.Properties.Resources.InvalidGuid, invalidGuid), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileCertificateAuth()
        {
            RunCreateProfileTestForParams(
                (cmdlet) =>
                {
                    cmdlet.Certificate = SampleCertificate;
                },
                NewAzureProfileCommand.CertificateParameterSet, ValidateCertificate);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileFromHashCertificateAuth()
        {
            RunCreateProfileTestForHashTable(
                (cmdlet) =>
                {
                    cmdlet.Properties.Add(NewAzureProfileCommand.CertificateKey, SampleCertificate);
                }, ValidateCertificate);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileWithADAuth()
        {
            var credential = GenerateCredential();
            RunCreateProfileTestForParams(
                (cmdlet) =>
                {
                    cmdlet.Credential = credential;
                }, NewAzureProfileCommand.CredentialsParameterSet,
                (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.User));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileFromHashWithADAuth()
        {
            var password = GeneratePassword();
            var credential = GenerateCredential(password);
            RunCreateProfileTestForHashTable(
                (cmdlet) =>
                {
                    cmdlet.Properties[NewAzureProfileCommand.UsernameKey] = credential.UserName;
                    cmdlet.Properties[NewAzureProfileCommand.PasswordKey] = password;
                }, (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.User));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAddAccountToCustomProfile()
        {
            var cmdlet = new AddAzureAccount();
            var csmSubscription = Guid.NewGuid();
            var rdfeSubscription = Guid.NewGuid();
            var credential = GenerateCredential("mySillyPassword");
            var profile = new AzureSMProfile();
            var client = new ProfileClient(profile);
            cmdlet.Credential = credential;
            cmdlet.Profile = profile;
            cmdlet.SetParameterSet("User");

            AzureSession.ClientFactory =
            new MockClientFactory(
               new List<object>
                        {
                            ProfileClientHelper.CreateRdfeSubscriptionClient(rdfeSubscription, rdfeSubscription.ToString()),
                            ProfileClientHelper.CreateCsmSubscriptionClient(new List<string>{csmSubscription.ToString()}, 
                            new List<string>{csmSubscription.ToString(), rdfeSubscription.ToString()})
                        }, true);
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(credential.UserName,
                Guid.NewGuid().ToString());
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(profile.Subscriptions);
            Assert.NotNull(profile.Accounts);
            Assert.NotNull(profile.Environments);
            Assert.NotNull(profile.Context);
            Assert.Equal(profile.Subscriptions.Values.Count((s) => s.Id == csmSubscription), 0);
            Assert.Equal(profile.Subscriptions.Values.Count((s) => s.Id == rdfeSubscription), 1);
            Assert.Equal(profile.Accounts.Values.Count((s) => s.Id == credential.UserName), 1);
            Assert.Contains(rdfeSubscription.ToString(), profile.Accounts.First().Value.GetProperty(AzureAccount.Property.Subscriptions));
            Assert.Equal(profile.Context.Account.Id, credential.UserName);
            Assert.Equal(profile.Context.Subscription.Id, rdfeSubscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureAccountThrowsForEmptySubscriptions()
        {
            var cmdlet = new AddAzureAccount();
            var csmSubscription = Guid.NewGuid();
            var rdfeSubscription = Guid.NewGuid();
            var credential = GenerateCredential("mySillyPassword");
            var profile = new AzureSMProfile();
            var client = new ProfileClient(profile);
            cmdlet.Credential = credential;
            cmdlet.Profile = profile;
            cmdlet.SetParameterSet("User");

            AzureSession.ClientFactory =
            new MockClientFactory(
               new List<object>
                        {
                            ProfileClientHelper.CreateRdfeSubscriptionClient(rdfeSubscription),
                            ProfileClientHelper.CreateCsmSubscriptionClient(new List<string>(),
                            new List<string>{csmSubscription.ToString(), rdfeSubscription.ToString()})
                        }, true);
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(credential.UserName,
                Guid.NewGuid().ToString());
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfieWithSPAuth()
        {
            var credential = GenerateCredential();
            RunCreateProfileTestForParams(
                (cmdlet) =>
                {
                    cmdlet.Credential = credential;
                }, NewAzureProfileCommand.ServicePrincipalParameterSet,
                (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.ServicePrincipal));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileFromHashWithSPAuth()
        {
            var password = GeneratePassword();
            var credential = GenerateCredential(password);
            RunCreateProfileTestForHashTable(
                (cmdlet) =>
                {
                    cmdlet.Properties[NewAzureProfileCommand.SPNKey] = credential.UserName;
                    cmdlet.Properties[NewAzureProfileCommand.PasswordKey] = password;
                }, (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.ServicePrincipal));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileWithTokenAuth()
        {
            var credential = GenerateCredential();
            var token = Guid.NewGuid().ToString();
            RunCreateProfileTestForParams(
                (cmdlet) =>
                {
                    cmdlet.AccountId = credential.UserName;
                    cmdlet.AccessToken = token;
                }, NewAzureProfileCommand.AccessTokenParameterSet,
                (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.AccessToken));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateProfileFromHashWithTokenAuth()
        {
            var credential = GenerateCredential();
            var token = Guid.NewGuid().ToString();
            RunCreateProfileTestForHashTable(
                (cmdlet) =>
                {
                    cmdlet.Properties.Add(NewAzureProfileCommand.AccountIdKey, credential.UserName);
                    cmdlet.Properties.Add(NewAzureProfileCommand.TokenKey, token);
                }, (profile) => ValidateCredential(credential, profile, AzureAccount.AccountType.AccessToken));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateAzureProfileWithFile()
        {
           var dataStore = AzureSession.DataStore;
            try
            {
                AzureSession.DataStore = new MemoryDataStore();
                var oldProfile = new AzureSMProfile();
                AzureSMCmdlet.CurrentProfile = oldProfile;
                string myFile = Path.GetTempFileName();
                var profile = SetupCustomProfile(myFile);
                var cmdlet = new NewAzureProfileCommand();
                var runtime = new MockCommandRuntime();
                cmdlet.SetParameterSet(NewAzureProfileCommand.FileParameterSet);
                cmdlet.Path = myFile;

                cmdlet.CommandRuntime = runtime;
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();

                var returnedProfile = runtime.OutputPipeline.First() as AzureSMProfile;
                Assert.NotNull(returnedProfile);
                Assert.NotNull(returnedProfile.Accounts.Values);
                Assert.NotNull(returnedProfile.Subscriptions.Values);
                Assert.NotNull(returnedProfile.Environments.Values);
                Assert.Equal(profile.Accounts.Values.Count, returnedProfile.Accounts.Values.Count);
                foreach (var account in profile.Accounts.Values)
                {
                    var returnedAccount = returnedProfile.Accounts.Values.FirstOrDefault((a) => a.Id == account.Id);
                    Assert.NotNull(returnedAccount);
                    Assert.Equal(account.GetProperty(AzureAccount.Property.Subscriptions),
                        returnedAccount.GetProperty(AzureAccount.Property.Subscriptions));
                }

                Assert.Equal(profile.Subscriptions.Values.Count, returnedProfile.Subscriptions.Values.Count);
                foreach (var subscription in profile.Subscriptions.Values)
                {
                    var returnedSub = returnedProfile.Subscriptions.Values.FirstOrDefault((s) => s.Id == subscription.Id);
                    Assert.NotNull(returnedSub);
                }

                // current profile does not change
                Assert.Equal(oldProfile.Accounts.Count, 0);
                Assert.Equal(oldProfile.Subscriptions.Count, 0);
            }
            finally
            {
                AzureSession.DataStore = dataStore;
            }
        }

        public static PSCredential GenerateCredential(string pass = null)
        {
            pass = pass ?? GeneratePassword();
            var username = "anonymous@anonymous.com";
            var password = new SecureString();
            for (int i = 0; i < pass.Length; ++i)
            {
                password.AppendChar(pass[i]);
            }

            return new PSCredential(username, password);
        }

        public static string GeneratePassword()
        {
            Random rand = new Random();
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < 12; ++i)
            {
                password.Append(Convert.ToChar(rand.Next(0, 127)));
            }

            return password.ToString();
        }

        private void RunCreateProfileTestForHashTable(Action<NewAzureProfileCommand> prepare,
            Action<AzureSMProfile> validate)
        {
            var subscription = Guid.NewGuid();
            RunCreateProfileTest((command) =>
            {
                command.Properties = new Hashtable();
                command.Properties.Add(NewAzureProfileCommand.SubscriptionIdKey, subscription.ToString());
                command.Properties[NewAzureProfileCommand.TenantKey] = subscription.ToString();
                prepare(command);
            }, NewAzureProfileCommand.PropertyBagParameterSet, subscription, validate);
        }

        private void RunCreateProfileTestForParams(Action<NewAzureProfileCommand> prepare, string parameterSet,
            Action<AzureSMProfile> validate)
        {
            var subscription = Guid.NewGuid();
            RunCreateProfileTest((command) =>
            {
                prepare(command);
                command.SubscriptionId = subscription.ToString();
            }, parameterSet, subscription, validate);
        }
        private void RunCreateProfileTest(Action<NewAzureProfileCommand> prepare, string parameterSet,
            Guid subscription, Action<AzureSMProfile> validate)
        {
            var clientFactory = AzureSession.ClientFactory;
            try
            {

                AzureSession.ClientFactory =
                    new MockClientFactory(
                        new List<object>
                        {
                            ProfileClientHelper.CreateRdfeSubscriptionClient(subscription, subscription.ToString()),
                            ProfileClientHelper.CreateCsmSubscriptionClient(new List<string>(), new List<string>{subscription.ToString()})
                        }, true);

                var cmdlet = new NewAzureProfileCommand();
                prepare(cmdlet);
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.SetParameterSet(parameterSet);
                cmdlet.ExecuteCmdlet();
                AzureSMProfile profile = commandRuntimeMock.OutputPipeline.First() as AzureSMProfile;
                Assert.NotNull(profile);
                Assert.NotNull(profile.Subscriptions);
                Assert.NotNull(profile.DefaultSubscription);
                Assert.Equal(profile.DefaultSubscription.Id, subscription);
                Assert.Equal(profile.Subscriptions.Count, 1);
                Assert.Equal(profile.Subscriptions.Values.First().Id, subscription);
                validate(profile);
            }
            finally
            {
                AzureSession.ClientFactory = clientFactory;
            }

        }

        private void ValidateCertificate(AzureSMProfile profile)
        {
            Assert.NotNull(profile.Accounts);
            Assert.NotNull(profile.Accounts.Values);
            Assert.Equal(profile.Accounts.Values.Count, 1);
            var account = profile.Accounts.Values.First();
            Assert.Equal(account.Type, AzureAccount.AccountType.Certificate);
            Assert.Equal(account.Id, SampleCertificate.Thumbprint);

        }

        private void ValidateCredential(PSCredential credential, AzureSMProfile profile,
            AzureAccount.AccountType accountType)
        {
            Assert.NotNull(profile.Accounts);
            Assert.NotNull(profile.Accounts.Values);
            Assert.Equal(profile.Accounts.Values.Count, 1);
            var account = profile.Accounts.Values.First();
            Assert.Equal(account.Type, accountType);
            Assert.Equal(account.Id, credential.UserName);
        }

        private ProfileClient SetupDefaultProfile()
        {
            var profile = new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile));
            AzureSMCmdlet.CurrentProfile = profile;
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);
            client.Profile.Save();
            return client;
        }

        private AzureSMProfile SetupCustomProfile(string path)
        {
            var profile =
                new AzureSMProfile(path);
            ProfileClient client = new ProfileClient(profile);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);
            profile.Save(path);
            return profile;
        }

        private void SetMockData()
        {
            azureSubscription1 = new AzureSubscription
            {
                Id = new Guid("56E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"),
                Name = "LocalSub1",
                Environment = "Test",
                Account = "test",
                Properties = new Dictionary<AzureSubscription.Property, string>
                {
                    { AzureSubscription.Property.Default, "True" } 
                }
            };
            azureSubscription2 = new AzureSubscription
            {
                Id = new Guid("66E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"),
                Name = "LocalSub2",
                Environment = "Test",
                Account = "test"
            };
            azureEnvironment = new AzureEnvironment
            {
                Name = "Test",
                Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                {
                    { AzureEnvironment.Endpoint.ServiceManagement, "https://umapi.rdfetest.dnsdemo4.com:8443/" },
                    { AzureEnvironment.Endpoint.ManagementPortalUrl, "https://windows.azure-test.net" },
                    { AzureEnvironment.Endpoint.AdTenant, "https://login.windows-ppe.net/" },
                    { AzureEnvironment.Endpoint.ActiveDirectory, "https://login.windows-ppe.net/" },
                    { AzureEnvironment.Endpoint.Gallery, "https://current.gallery.azure-test.net" },
                    { AzureEnvironment.Endpoint.ResourceManager, "https://api-current.resources.windows-int.net/" },                    
                    { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, "vault-int.azure-int.net" },
                    { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, "https://vault-int.azure-int.net/" },
                }
            };
            azureAccount = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    { AzureAccount.Property.Subscriptions, azureSubscription1.Id + "," + azureSubscription2.Id } 
                }
            };
        }

        private static bool StorageAccountMatchesConnectionString(string accountName, string connectionString)
        {
            var result = false;
            if (!string.IsNullOrWhiteSpace(accountName) && !string.IsNullOrWhiteSpace(connectionString))
            {
                result = connectionString.Contains(string.Format("AccountName={0}", accountName));
            }

            return result;
        }

        private static void RunMockedCmdletTest(Action testAction)
        {
            var savedMockState = TestMockSupport.RunningMocked;
            var savedClientFactory = AzureSession.ClientFactory;
            try
            {
                TestMockSupport.RunningMocked = true;
                AzureSession.ClientFactory = new ClientFactory();
                testAction();
            }
            finally
            {
                TestMockSupport.RunningMocked = savedMockState;
                AzureSession.ClientFactory = savedClientFactory;
            }
        }
    }
}
