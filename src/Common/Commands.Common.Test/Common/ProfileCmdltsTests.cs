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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using Moq;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class ProfileCmdltsTests
    {
        private AzureSubscription azureSubscription1;
        private AzureSubscription azureSubscription2;
        private AzureEnvironment azureEnvironment;
        private AzureAccount azureAccount;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private X509Certificate2 SampleCertificate = new X509Certificate2(Convert.FromBase64String(@"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"), string.Empty);


        public ProfileCmdltsTests() : base()
        {
            MockDataStore dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
            commandRuntimeMock = new Mock<ICommandRuntime>();
            SetMockData();
            AzureSession.SetCurrentContext(null, null, null);
        }

        [Fact]
        public void SetAzureSubscriptionAddsSubscriptionWithCertificate()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = Guid.NewGuid().ToString();
            cmdlt.SubscriptionName = "NewSubscriptionName";
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.Certificate = SampleCertificate;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            ProfileClient client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            var newAccount = client.Profile.Accounts[SampleCertificate.Thumbprint];
            Assert.Equal(cmdlt.SubscriptionName, newSubscription.Name);
            Assert.Equal(EnvironmentName.AzureCloud, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
            
            Assert.Equal(newAccount.Id, newSubscription.Account);
            Assert.Equal(AzureAccount.AccountType.Certificate, newAccount.Type);
            Assert.Equal(SampleCertificate.Thumbprint, newAccount.Id);
            Assert.Equal(cmdlt.SubscriptionId, newAccount.GetProperty(AzureAccount.Property.Subscriptions));
        }

        [Fact]
        public void SetAzureSubscriptionDerivesEnvironmentFromEnvironmentParameterOnAdd()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
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
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            Assert.Equal(cmdlt.SubscriptionName, newSubscription.Name);
            Assert.Equal(cmdlt.Environment, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void SetAzureSubscriptionThrowsExceptionWithoutCertificateOnAdd()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = Guid.NewGuid().ToString();
            cmdlt.SubscriptionName = "NewSubscriptionName";
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.Environment = azureEnvironment.Name;

            // Verify
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(()=> cmdlt.ExecuteCmdlet());
        }

        [Fact]
        public void SetAzureSubscriptionDerivesEnvironmentFromEnvironmentParameterOnSet()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.Environment = azureEnvironment.Name;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            Assert.Equal(cmdlt.Environment, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void SetAzureSubscriptionDerivesEnvironmentFromServiceEndpointParameterOnSet()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.ServiceEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            Assert.Equal(cmdlt.Environment, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName,
                newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void SetAzureSubscriptionDerivesEnvironmentFromResourcesEndpointParameterOnSet()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.ResourceManagerEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            Assert.Equal(cmdlt.Environment, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void SetAzureSubscriptionDerivesEnvironmentFromBothEndpointParameters()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.ServiceEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement);
            cmdlt.ResourceManagerEndpoint = azureEnvironment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            Assert.Equal(cmdlt.Environment, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void SetAzureSubscriptionUpdatesSubscriptionWithCertificate()
        {
            SetAzureSubscriptionCommand cmdlt = new SetAzureSubscriptionCommand();
            
            // Setup
            ProfileClient client = new ProfileClient();
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.Profile.Save();

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SubscriptionId = azureSubscription1.Id.ToString();
            cmdlt.CurrentStorageAccountName = "NewCloudStorage";
            cmdlt.Certificate = SampleCertificate;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            var newSubscription = client.Profile.Subscriptions[new Guid(cmdlt.SubscriptionId)];
            var newAccount = client.Profile.Accounts[SampleCertificate.Thumbprint];
            var existingAccount = client.Profile.Accounts[azureAccount.Id];
            Assert.Equal(azureEnvironment.Name, newSubscription.Environment);
            Assert.Equal(cmdlt.CurrentStorageAccountName, newSubscription.GetProperty(AzureSubscription.Property.StorageAccount));

            Assert.Equal(newAccount.Id, newSubscription.Account);
            Assert.Equal(AzureAccount.AccountType.Certificate, newAccount.Type);
            Assert.Equal(SampleCertificate.Thumbprint, newAccount.Id);
            Assert.Equal(cmdlt.SubscriptionId, newAccount.GetProperty(AzureAccount.Property.Subscriptions));

            Assert.Equal(azureAccount.Id, existingAccount.Id);
            Assert.Equal(AzureAccount.AccountType.User, existingAccount.Type);
            Assert.True(existingAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Contains(cmdlt.SubscriptionId));
        }

        [Fact]
        public void ImportPublishSettingsFileSelectsCorrectEnvironment()
        {
            ImportAzurePublishSettingsCommand cmdlt = new ImportAzurePublishSettingsCommand();

            // Setup
            ProfileClient.DataStore.WriteFile("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings",
                Properties.Resources.ValidProfileChina);
            ProfileClient client = new ProfileClient();
            var oldDataStore = FileUtilities.DataStore;
            FileUtilities.DataStore = ProfileClient.DataStore;
            var expectedEnv = "AzureChinaCloud";
            var expected = client.ImportPublishSettings("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings", null);

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.ProfileClient = new ProfileClient();
            cmdlt.PublishSettingsFile = "ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings";

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
                commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
            }
            finally
            {
                // Cleanup
                FileUtilities.DataStore = oldDataStore;
            }
        }

        [Fact]
        public void ImportPublishSettingsFileOverwritesEnvironment()
        {
            ImportAzurePublishSettingsCommand cmdlt = new ImportAzurePublishSettingsCommand();

            // Setup
            ProfileClient.DataStore.WriteFile("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings",
                Properties.Resources.ValidProfileChina);
            ProfileClient client = new ProfileClient();
            var oldDataStore = FileUtilities.DataStore;
            FileUtilities.DataStore = ProfileClient.DataStore;
            var expectedEnv = "AzureCloud";
            var expected = client.ImportPublishSettings("ImportPublishSettingsFileSelectsCorrectEnvironment.publishsettings", expectedEnv);

            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.ProfileClient = new ProfileClient();
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
                commandRuntimeMock.Verify(f => f.WriteObject(expected), Times.Once());
            }
            finally
            {
                // Cleanup
                FileUtilities.DataStore = oldDataStore;
            }
        }

        [Fact]
        public void SelectDefaultAzureSubscriptionByNameUpdatesProfile()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            var client = SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectDefaultSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;
            cmdlt.Default = new SwitchParameter(true);
            Assert.NotEqual(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            Assert.NotNull(client.Profile.DefaultSubscription);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);
        }

        [Fact]
        public void SelectAzureSubscriptionByNameUpdatesProfile()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectSubscriptionByNameParameterSet");
            cmdlt.SubscriptionName = azureSubscription2.Name;
            Assert.Null(AzureSession.CurrentContext.Subscription);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(AzureSession.CurrentContext.Subscription);
            Assert.Equal(azureSubscription2.Id, AzureSession.CurrentContext.Subscription.Id);
        }
        [Fact]
        public void SelectDefaultAzureSubscriptionByIdAndNoDefaultUpdatesProfile()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            var client = SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectDefaultSubscriptionByIdParameterSet");
            cmdlt.SubscriptionId = azureSubscription2.Id.ToString();
            cmdlt.Default = new SwitchParameter(true);
            Assert.NotEqual(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            Assert.NotNull(client.Profile.DefaultSubscription);
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("NoDefaultSubscriptionParameterSet");
            cmdlt.NoDefault = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            client = new ProfileClient();
            Assert.Null(client.Profile.DefaultSubscription);
        }

        [Fact]
        public void SelectAzureSubscriptionByIdAndNoCurrentUpdatesProfile()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            cmdlt.SubscriptionId = azureSubscription2.Id.ToString();
            Assert.Null(AzureSession.CurrentContext.Subscription);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.NotNull(AzureSession.CurrentContext.Subscription);
            Assert.Equal(azureSubscription2.Id, AzureSession.CurrentContext.Subscription.Id);

            cmdlt = new SelectAzureSubscriptionCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("NoCurrentSubscriptionParameterSet");
            cmdlt.NoCurrent = new SwitchParameter(true);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.Null(AzureSession.CurrentContext.Subscription);
        }

        [Fact]
        public void SelectAzureSubscriptionByInvalidIdThrowsException()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            string invalidGuid = Guid.NewGuid().ToString();
            cmdlt.SubscriptionId = invalidGuid;
            Assert.Null(AzureSession.CurrentContext.Subscription);

            // Act
            cmdlt.InvokeBeginProcessing();
            try
            {
                cmdlt.ExecuteCmdlet();
                Assert.True(false);
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(string.Format(Microsoft.WindowsAzure.Commands.Common.Properties.Resources.InvalidSubscriptionId, invalidGuid), ex.Message);
            }
        }

        [Fact]
        public void SelectAzureSubscriptionByInvalidGuidThrowsException()
        {
            SelectAzureSubscriptionCommand cmdlt = new SelectAzureSubscriptionCommand();
            SetupDefaultProfile();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock.Object;
            cmdlt.SetParameterSet("SelectSubscriptionByIdParameterSet");
            string invalidGuid = "foo";
            cmdlt.SubscriptionId = invalidGuid;
            Assert.Null(AzureSession.CurrentContext.Subscription);

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

        private ProfileClient SetupDefaultProfile()
        {
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);
            client.Profile.Save();
            return client;
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
    }
}
