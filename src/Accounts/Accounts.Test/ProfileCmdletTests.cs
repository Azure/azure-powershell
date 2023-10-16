﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Moq;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ProfileCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        private List<byte> azKeyStoreData = new List<byte>();
        private AzKeyStore keyStore;

        public ProfileCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            keyStore = SetMockedAzKeyStore();
        }

        private AzKeyStore SetMockedAzKeyStore()
        {
            var storageMocker = new Mock<IStorage>();
            storageMocker.Setup(f => f.Create()).Returns(storageMocker.Object);
            storageMocker.Setup(f => f.WriteData(It.IsAny<byte[]>())).Callback((byte[] s) => { azKeyStoreData.Clear(); azKeyStoreData.AddRange(s); });
            storageMocker.Setup(f => f.ReadData()).Returns(azKeyStoreData.ToArray());
            var keyStore = new AzKeyStore(AzureSession.Instance.ARMProfileDirectory, "azkeystore", false, storageMocker.Object);
            return keyStore;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileInMemory()
        {
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);

            var profile = new AzureRmProfile { DefaultContext = new AzureContext() };
            var env = new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            env.Name = "foo";
            profile.EnvironmentTable.Add("foo", env);
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
            // Setup
            cmdlt.AzureContext = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileBadPath()
        {
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
#pragma warning disable CS0618 // Suppress obsolescence warning: cmdlet name is changing
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
#pragma warning restore CS0618 // Suppress obsolescence warning: cmdlet name is changing
            cmdlt.Path = "z:\non-existent-path\non-existent-file.ext";
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.MyInvocation.BoundParameters.Add("Path", cmdlt.Path);

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileFromDisk()
        {
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault())));
            profile.EnvironmentTable["foo"].Name = "foo";
            profile.Save("X:\\foo.json");
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.MyInvocation.BoundParameters.Add("Path", cmdlt.Path);
            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.Contains(AzureRmProfileProvider.Instance.Profile.Environments, (e) => string.Equals(e.Name, "foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileInMemory()
        {
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", new AzureEnvironment(AzureEnvironment.PublicEnvironments.Values.FirstOrDefault()));
            profile.EnvironmentTable["foo"].Name = "foo";
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
            // Setup
            cmdlt.Profile = profile;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.Instance.DataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRmProfile("X:\\foo.json");
            Assert.Contains(profile2.Environments, (e) => string.Equals(e.Name, "foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileNull()
        {
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
#pragma warning disable CS0618 // Suppress obsolescence warning: cmdlet name is changing
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
#pragma warning restore CS0618 // Suppress obsolescence warning: cmdlet name is changing
            // Setup
            AzureRmProfileProvider.Instance.Profile = null;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        private const string password = "pa88w0rd!";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileFromDefault()
        {
            string accountId = Guid.NewGuid().ToString(),
                tenantId = Guid.NewGuid().ToString(),
                subscriptionId = Guid.NewGuid().ToString(),
                subscriptionName = "Contoso Subscription",
                tenantName = "contoso.com";

            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
            var profile = GetProfile(accountId, tenantId, subscriptionId, subscriptionName, tenantName);
            AzureRmProfileProvider.Instance.Profile = profile;
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.WithCredential = true;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.Instance.DataStore.FileExists("X:\\foo.json"));
            var profileString = AzureSession.Instance.DataStore.ReadFileAsText("X:\\foo.json");
            profileString = Regex.Replace(profileString, @"[^\u0000-\u007F]+", string.Empty);
            var actual = JsonConvert.DeserializeObject<AzureRmProfile>(profileString, new AzureRmProfileConverter());
            Assert.Equal(password, actual.Contexts.First().Value.Account.GetProperty(AzureAccount.Property.ServicePrincipalSecret));
            Assert.Equal(accountId, actual.Contexts.First().Value.Account.Id);
            Assert.Equal(tenantId, actual.Contexts.First().Value.Tenant.Id);
            Assert.Equal(subscriptionId, actual.Contexts.First().Value.Subscription.Id);
            Assert.Equal(subscriptionName, actual.Contexts.First().Value.Subscription.Name);
        }

        private AzureRmProfile GetProfile(string accountId, string tenantId, string subscriptionId, string subscriptionName, string tenantName)
        {
            var account = new AzureAccount()
            {
                Id = accountId,
                Type = AzureAccount.AccountType.ServicePrincipal
            };
            var tenant = new AzureTenant()
            {
                Directory = tenantName,
                Id = tenantId
            };
            account.SetTenants(tenant.Id);

            keyStore.SaveSecureString(new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id, tenant.Id), password.ConvertToSecureString());

            var sub = new AzureSubscription()
            {
                Id = subscriptionId,
                Name = subscriptionName
            };

            sub.SetAccount(account.Id);
            sub.SetEnvironment(EnvironmentName.AzureCloud);
            var context = new AzureContext(sub,
                account,
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                tenant);
            var profile = new AzureRmProfile();
            profile.TryAddContext(context, out _);
            return profile;
        }
    }
}
