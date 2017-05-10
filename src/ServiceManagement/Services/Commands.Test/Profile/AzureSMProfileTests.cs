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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Common.Authentication.Test
{
    public class AzureSMProfileTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileSaveDoesNotSerializeContext()
        {
            var dataStore = new MockDataStore();
            var profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ProfileFile);
            var profile = new AzureSMProfile(profilePath);
            AzureSession.Instance.DataStore = dataStore;
            var tenant = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectory = new Uri("http://contoso.com")
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(tenant);
            var sub = new AzureSubscription
            {
                Id = new Guid().ToString(),
                Name = "Contoso Test Subscription",
            };
            sub.SetAccount(account.Id);
            sub.SetEnvironment(environment.Name);
            sub.SetTenant(tenant);
            profile.EnvironmentTable[environment.Name] = environment;
            profile.AccountTable[account.Id] = account;
            profile.SubscriptionTable[sub.GetId()] = sub;

            profile.Save();

            var profileFile = profile.ProfilePath;
            string profileContents = dataStore.ReadFileAsText(profileFile);
            var readProfile = JsonConvert.DeserializeObject<Dictionary<string, object>>(profileContents);
            Assert.False(readProfile.ContainsKey("DefaultContext"));
            AzureSMProfile parsedProfile = new AzureSMProfile();
            var serializer = new JsonProfileSerializer();
            Assert.True(serializer.Deserialize(profileContents, parsedProfile));
            Assert.NotNull(parsedProfile);
            Assert.NotNull(parsedProfile.Environments);
            Assert.True(parsedProfile.EnvironmentTable.ContainsKey(environment.Name));
            Assert.NotNull(parsedProfile.Accounts);
            Assert.True(parsedProfile.AccountTable.ContainsKey(account.Id));
            Assert.NotNull(parsedProfile.Subscriptions);
            Assert.True(parsedProfile.SubscriptionTable.ContainsKey(sub.GetId()));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void ProfileSerializeDeserializeWorks()
        {
            var dataStore = new MockDataStore();
            var profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AzureSession.Instance.ProfileFile);
            var profile = new AzureSMProfile(profilePath);
            AzureSession.Instance.DataStore = dataStore;
            var tenant = Guid.NewGuid().ToString();
            var environment = new AzureEnvironment
            {
                Name = "testCloud",
                ActiveDirectory = new Uri("http://contoso.com")
            };
            var account = new AzureAccount
            {
                Id = "me@contoso.com",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(tenant);
            var sub = new AzureSubscription
            {
                Id = new Guid().ToString(),
                Name = "Contoso Test Subscription",
            };
            sub.SetAccount(account.Id);
            sub.SetEnvironment(environment.Name);
            sub.SetTenant(tenant);

            profile.EnvironmentTable[environment.Name] = environment;
            profile.AccountTable[account.Id] = account;
            profile.SubscriptionTable[sub.GetId()] = sub;

            AzureSMProfile deserializedProfile;
            // Round-trip the exception: Serialize and de-serialize with a BinaryFormatter
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                // "Save" object state
                bf.Serialize(ms, profile);

                // Re-use the same stream for de-serialization
                ms.Seek(0, 0);

                // Replace the original exception with de-serialized one
                deserializedProfile = (AzureSMProfile)bf.Deserialize(ms);
            }
            Assert.NotNull(deserializedProfile);
            var jCurrentProfile = JsonConvert.SerializeObject(profile);
            var jDeserializedProfile = JsonConvert.SerializeObject(deserializedProfile);
            Assert.Equal(jCurrentProfile, jDeserializedProfile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AccountMatchingIgnoresCase()
        {
            var profile = new AzureSMProfile();
            string accountName = "howdy@contoso.com";
            string accountNameCase = "Howdy@Contoso.com";
            var subscriptionId = Guid.NewGuid();
            var tenantId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = accountName,
                Type = AzureAccount.AccountType.User
            };

            account.SetProperty(AzureAccount.Property.Subscriptions, subscriptionId.ToString());
            account.SetProperty(AzureAccount.Property.Tenants, tenantId.ToString());
            var subscription = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
            };
            subscription.SetAccount(accountNameCase);
            subscription.SetEnvironment(EnvironmentName.AzureCloud);
            
            subscription.SetProperty(AzureSubscription.Property.Default, "true");
            subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            profile.AccountTable.Add(accountName, account);
            profile.SubscriptionTable.Add(subscriptionId, subscription);
            Assert.NotNull(profile.Context);
            Assert.NotNull(profile.Context.Account);
            Assert.NotNull(profile.Context.Environment);
            Assert.NotNull(profile.Context.Subscription);
            Assert.Equal(account, profile.Context.Account);
            Assert.Equal(subscription, profile.Context.Subscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsCorrectContext()
        {
            AzureSMProfile profile = new AzureSMProfile();
            string accountId = "accountId";
            Guid subscriptionId = Guid.NewGuid();
            profile.AccountTable.Add(accountId, new AzureAccount { Id = accountId, Type = AzureAccount.AccountType.User });
            var sub = new AzureSubscription
            {
                Name = "hello",
                Id = subscriptionId.ToString()
            };
            sub.SetAccount(accountId);
            sub.SetEnvironment(EnvironmentName.AzureChinaCloud);
            profile.SubscriptionTable.Add(subscriptionId, sub);
            profile.DefaultSubscription = profile.SubscriptionTable[subscriptionId];
            IAzureContext context = profile.Context;

            Assert.Equal(accountId, context.Account.Id);
            Assert.Equal(subscriptionId.ToString(), context.Subscription.Id);
            Assert.Equal(EnvironmentName.AzureChinaCloud, context.Environment.Name);
        }
    }
}
