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
using Microsoft.Azure.Subscriptions.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.ServiceManagemenet.Common;
using Xunit;
using CSMSubscription = Microsoft.Azure.Subscriptions.Models.Subscription;
using RDFESubscription = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionListOperationResponse.Subscription;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Common.Authentication.Test
{
    public class ProfileClientTests
    {
        private string oldProfileData;
        private string oldProfileJsonData;
        private string oldProfileDataBadSubscription;
        private string oldProfileDataCorruptedFile;
        private string oldProfileDataPath;
        private string oldProfileDataPathError;
        private string newProfileDataPath;
        private string defaultSubscription = "06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F";
        private string dummyCertificate = "MIIKJAIBAzCCCeQGCSqGSIb3DQEHAaCCCdUEggnRMIIJzTCCBe4GCSqGSIb3DQEHAaCCBd8EggXbMIIF1zCCBdMGCyqGSIb3DQEMCgECoIIE7jCCBOowHAYKKoZIhvcNAQwBAzAOBAjilB4DFutYJwICB9AEggTItMCor/6dq+ynHyoo82U2N8bT9fBn57xuvF4zTtZdl503n+q48ZE5SLcUFoeAZkrYoCiyPn4ayVA4pfAHou5I2XEG1B4YF46hD0Bz0igWRSrsVigdoYP98BGGaMgl43d9AQGeV8iJ3d3In/TxMGjHUYzZwoIg1jE7xhQ8dMr2Xenw8pLrxl8FybI1isyxzAUjFE7E/Znv9DYi83VNwjC1uPg8q16PzXUQ/smFVzoZMtvmp8MxPrnI/gHqcS5g7SnnisTLmJcjqdLVywBZqiMo1ALs90EEgc7qgbim9lxGczUh+SI9cj2m5w9XMmXro4XJNJTLFG26DDOVMPfMSr9ij9P4rmxckVK7nHrGhQpshrLr37dF5KGFo6mh79VUadbwn/a4rXjfX9gXm5N/ZS8wq3U4/4Pl7t5N+bwB5izt8JG4aMhX6M6jshNrpe/gZHI9u6jNAo1yRxNfBdoxA7P2sZdlHO4CYTc9zZcZqTgH2QjRLTelIDn17PEQL9L4rEzqhT322WMzNnSMH9TCu3D5l2RuO6hsHl0JK4saiq3s04kkYoLXF9i+ovS0xSmu0zxemnFAGB1q1mlwoWoD06zlXEjHM2Q3T2b8ip1tK6/GFpU8Qs5BOUDanBOCqVLWlyvM/ilXUyN9cyLRMKM1sgEmn5ue0wsZlflU6egqChF8qjSJzq/34FgTjPazvkXkXv0e2vBz5+qzeC/1R8xySdFoehglny42VTkCRH4BzhoXf+MrfrC6tW85WCTKOj8SiTSzYXRragIwfG8RyLViOzdIW9pEAJF3UOloKOGGL1NREAnRPgxm9UVxD1oUj+pqYkPRRXcHuEnbiYEqE8Dgwk6GaSVOZ4CKjKAcapOwwW8bTxHgFOCrwgZhxIFXQhIZVoH8NphqN2WWwIUPa1gsc3uPwVXecgt8y8S01QEYCCFo9dT5sBS0rAOXMTOnSudWSHvz7c36IJSG2KyJwW3YO2UopIQ1V14MBZQhwUyddUILeuOy50u1j2eVOV3XESHO99oNP9FfalmgZw19LQDqX8S861x1w+GuU/NG//LZ0aXXaw1IhddIMZlpZVTADMunXIJbd0OiunfblXFwGZ33M1y/wGvFAZ6ofOuZv6vM0kmtufg3AHl/Vg+jzLOp1bYbKx4f7FHoYAerV88EA/ELXr2NTOLwwRYdk0cLWk4VY2lCLs8lcyoIUrcOS/+af8oX8dgJo9qkx2AiKp6AgYAWwrdpolOH7sMLmtu1rrthoMesExLz6xpUq/rYrWQJuyXWUmwbdxpDYFP8spqcW3KdbroNWhPEvM0tdocSK6lPWNnFMgqbb2qJJqjyV87LBZPEpHI8TPraofE7h4NWjXx/OqA6/dF1t3RvrvYqyC7kvrnaJ2LWfQI/88K9s7LAVvfDIbxWtIadrGXlo4gbtbQDSFzjve123DngBJkXqpzqRoL7mdpFvsgpg0upIKQ1fIbtaksC115g8BGBOzwGlo0Y3f4+ob6++OkePHoLkGhLahCMyDmGV1mxFz3ZUkXyxmfPSeynwXe/N8TxeZ2ixLZMF3sa61CpFsuHfEmVEetFxP5t3rrO5ZIbE87KVtvl6jCr8JQ3h81TZJBaeu8iiNC0MVspJpNQ/irYFElTMYHRMBMGCSqGSIb3DQEJFTEGBAQBAAAAMFsGCSqGSIb3DQEJFDFOHkwAewA0ADgANQBFADQAOQBCADYALQBFAEUARQA4AC0ANAA3ADUAQgAtADgAOQAwAEQALQA5ADcAQQA3ADYARgAyADQANgBEADkAMwB9MF0GCSsGAQQBgjcRATFQHk4ATQBpAGMAcgBvAHMAbwBmAHQAIABTAG8AZgB0AHcAYQByAGUAIABLAGUAeQAgAFMAdABvAHIAYQBnAGUAIABQAHIAbwB2AGkAZABlAHIwggPXBgkqhkiG9w0BBwagggPIMIIDxAIBADCCA70GCSqGSIb3DQEHATAcBgoqhkiG9w0BDAEGMA4ECG9kWMFPd2j2AgIH0ICCA5AUBLyrnhFVIYZKNWVLOWn0nfwmhADWS2FA3LGyGirb/lgpPcolLiQwGnXih0xxESn1CsZcWDpXiUvAfjQF1kxKHyCIUQBkrKQliYIT+RErliVuAY/vv1YW2Zj+bPUtTZKXUDzIPjNgb43+uxvf/wu+gGhAV/dV5oIWLjFhC1u4+Gp/LA5C6j60NtBXG7barSflAWTSOjGt2IIb5mBrUw+GkrhoYOqA+HYG40j2fkmkWpMCkImzcxxEM65ZElGUt7H1QY+GSRAxt7icA5ka9L+A0UM8a1SCFhbBK6Voo0IAkBZctJ6I7h4znhoHtqMDYYzraaYDVAK4SPdwOUMUyYdai0QwOYSL3frwVzC/ZHvCJkRmOsQXj9U44OGoXXrJ4rWIQIkcxFO3rEC3alI9lV5h5w73DWQRjex8Nz214B1yBRdlkoC/HQpgJ6IwFfEyJOn/lGgqkRPbgntTKSjNQZr5Ot60Z1SUYmmcMTpB8jRg+hy0LbWmx+79q9ERUnLO4yrtcXjQza12/FwAdpJOwbFrXMZb3QcuhQfn9aDF9/iNRkhTdxDmumS/C5gjZSYBzTugGDWsyS1hqws7LaYfcs6aWWRafqxt68cpNy4FaNXZ3XwXRVzuH+brnGvnWXRqhzwCbeGxEKDCEPxO9hO8NVrndsGlGfTZmxfTkKnPyRPD6vk4BG0Rc5BniyrmhnaZgSq0M04MeoAjp1s6S8CcIG73H5KkmoqQwSiKUbY3aA15nxqYhQj6L83WK5dPnVlmaV/xOeqkggzsdkaa+eQfA1e5RR27Gkyr5Rl20PQUR6J/sIGWIVCSSaqD2kxmDTODEORsF7jhL4YXZr96hqvNWtyNncxrqvjPsaFi/P2JFxjfZ8wmnF1HDsVW4W/i8cdRTyEz7Go4kzoRvSvC2sCPRAMa3D+o341r7L0hBlCnFfMU5Le8jatMKsw+Nk1TeOc4Cvc+w3gczSKrlhJnPtJjVZ67kKe8Ror8mKOP6afSr27avEizUYvJcCpKztUM59ukEbM2chEb2rrFPWxnB67KaLF825pRm+6Nl3mx0jaPDgK2ToydGfuVBA+9TSpnuV26imsd+K2yL2nwrdvBJPE/t2lPzVIR0hnf4AJ8/9BR0vTGmxiWwy8VMxrS3PyouLPZMXAgdT6ddRVwmewNjTe5g/tciGazIW+nROgg6fsgyObMp7keONMvtFMrJQLa2oKarGkwNzAfMAcGBSsOAwIaBBQXFDnqplMX7OuyknHK7B+HA/N8tAQUsL21+IY37DPL968vhVzqz09W/so=";
        private RDFESubscription rdfeSubscription1;
        private RDFESubscription rdfeSubscription2;
        private CSMSubscription csmSubscription1;
        private CSMSubscription csmSubscription1withDuplicateId;
        private CSMSubscription csmSubscription2;
        private AzureSubscription azureSubscription1;
        private AzureSubscription azureSubscription2;
        private AzureSubscription azureSubscription3withoutUser;
        private AzureEnvironment azureEnvironment;
        private AzureAccount azureAccount;
        private TenantIdDescription commonTenant;
        private TenantIdDescription guestTenant;
        private RDFESubscription guestRdfeSubscription;
        private CSMSubscription guestCsmSubscription;
        private AzureSMProfile currentProfile;

        public ProfileClientTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            ServiceManagementProfileProvider.InitializeServiceManagementProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            SetMockData();
            currentProfile = new AzureSMProfile();
        }

        [Fact]
        public void ProfileMigratesOldData()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileMigratesOldJsonData()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileJsonData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(oldProfileDataPath);

            Assert.Collection(currentProfile.Accounts.OrderBy((a) => a.Id),
                  (e) => CheckAccount(e, id: "0123456789", type: AzureAccount.AccountType.Certificate, tenants: new string[0], subscriptions: new[] { "90d2b4aa-1640-43d4-98c2-790aab234a4d" }),
                  (e) => CheckAccount(e, id: "1234567890", type: AzureAccount.AccountType.Certificate, tenants: new string[0], subscriptions: new[] { "f7de4568-57fb-40fe-8186-3419a2f2f522" }),
                  (e) => CheckAccount(e, id: "someuser@contoso.cn", type: AzureAccount.AccountType.User, tenants: new[] { "17859926-0a62-42e5-bbf2-71ffbc7e7ad2" }, subscriptions: new[] { "8d9bbf24-8d3a-40c9-b6ad-3aa54f768e15" }),
                  (e) => CheckAccount(e, id: "someuser@contoso.com", type: AzureAccount.AccountType.User, tenants: new[] { "594b5a60-8d1a-4f27-9367-6bd92c72ee82", "20623033-0e48-4521-bb84-01f3e316969d" }, subscriptions: new[] { "f7de4568-57fb-40fe-8186-3419a2f2f522", "90d2b4aa-1640-43d4-98c2-790aab234a4d", "da7902f9-7072-4a86-aead-5a1c8b768a1a" })
               );
            Assert.Collection(currentProfile.Subscriptions.OrderBy((s) => s.Name),
                (s) => CheckSubscription(s, id: "8d9bbf24-8d3a-40c9-b6ad-3aa54f768e15", name: "Azure Contoso China", tenant: "17859926-0a62-42e5-bbf2-71ffbc7e7ad2", account: "someuser@contoso.cn", environment: "AzureChinaCloudMirror", isDefault: false),
                (s) => CheckSubscription(s, id: "f7de4568-57fb-40fe-8186-3419a2f2f522", name: "Azure Contoso CI", tenant: "594b5a60-8d1a-4f27-9367-6bd92c72ee82", account: "someuser@contoso.com", environment: "AzureCloud", isDefault: false),
                (s) => CheckSubscription(s, id: "90d2b4aa-1640-43d4-98c2-790aab234a4d", name: "Azure Contoso Infrastructure", tenant: "594b5a60-8d1a-4f27-9367-6bd92c72ee82", account: "someuser@contoso.com", environment: "AzureCloud", isDefault: true),
                (s) => CheckSubscription(s, id: "da7902f9-7072-4a86-aead-5a1c8b768a1a", name: "Azure Contoso Subscription2", tenant: "20623033-0e48-4521-bb84-01f3e316969d", account: "someuser@contoso.com", environment: "AzureCloud", isDefault: false)
                );
            CheckEnvironment(currentProfile.EnvironmentTable["AzureChinaCloudMirror"], name: "AzureChinaCloudMirror", serviceEndpoint: "https://management.core.chinacloudapi.cn/");
        }

        static void CheckAccount(IAzureAccount account, string id, string type, string[] tenants, string[] subscriptions)
        {
            Assert.Equal(id, account.Id);
            Assert.Equal(type, account.Type);
            foreach (var tenant in tenants)
            {
                Assert.Contains(tenant, account.GetTenants(), StringComparer.OrdinalIgnoreCase);
            }

            foreach (var subscription in subscriptions)
            {
                Assert.Contains(subscription, account.GetSubscriptions(), StringComparer.OrdinalIgnoreCase);
            }
        }

        static void CheckSubscription(IAzureSubscription subscription, string id, string name, string tenant, string account, string environment, bool isDefault)
        {
            Assert.Equal(id, subscription.Id);
            Assert.Equal(name, subscription.Name);
            Assert.Equal(tenant, subscription.GetTenant());
            Assert.Equal(account, subscription.GetAccount());
            Assert.Equal(environment, subscription.GetEnvironment());
            Assert.Equal(isDefault, subscription.IsDefault());
        }

        static void CheckEnvironment(IAzureEnvironment environment, string name, string serviceEndpoint)
        {
            Assert.Equal(name, environment.Name);
            Assert.Equal(serviceEndpoint, environment.ServiceManagementUrl);
        }

        [Fact]
        public void NewProfileFromCertificateWithNullsThrowsArgumentNullException()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(null, Guid.NewGuid(), new X509Certificate2(), "foo"));
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"], Guid.NewGuid(), null, "foo"));
        }

        [Fact]
        public void NewProfileFromCertificateReturnsProfile()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var subscriptionId = Guid.NewGuid();
            var certificate = new X509Certificate2(Convert.FromBase64String(dummyCertificate));

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                subscriptionId, certificate, null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.GetEnvironment());
            Assert.Equal(subscriptionId, newProfile.DefaultSubscription.GetId());
            Assert.Equal(certificate.Thumbprint, newProfile.DefaultSubscription.GetAccount());
            Assert.False(newProfile.DefaultSubscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileFromAdCredentialsWithNullsThrowsArgumentNullException()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(null, Guid.NewGuid(), new AzureAccount(), null, "foo"));
            Assert.Throws<ArgumentNullException>(() =>
                client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"], Guid.NewGuid(), (AzureAccount)null, null, "foo"));
        }

        [Fact]
        public void NewProfileFromADReturnsProfile()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new List<CSMSubscription>());
            rdfeSubscription2.ActiveDirectoryTenantId = "123";
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var newAccount = new AzureAccount { Id = "foo" };
            newAccount.SetTenants("123");

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                new Guid(rdfeSubscription2.SubscriptionId), newAccount, null, null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.GetEnvironment());
            Assert.Equal(new Guid(rdfeSubscription2.SubscriptionId), newProfile.DefaultSubscription.GetId());
            Assert.Equal(newAccount.Id, newProfile.DefaultSubscription.GetAccount());
            Assert.False(newProfile.DefaultSubscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileWithAccessTokenReturnsProfile()
        {
            //SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);

            client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                new Guid(csmSubscription1.SubscriptionId), "accessToken", "accountId", null);

            Assert.Equal("AzureCloud", newProfile.DefaultSubscription.GetEnvironment());
            Assert.Equal(new Guid(csmSubscription1.SubscriptionId), newProfile.DefaultSubscription.GetId());
            Assert.Equal("accountId", newProfile.DefaultSubscription.GetAccount());
            Assert.Equal(AzureAccount.AccountType.AccessToken, newProfile.Context.Account.Type);
            Assert.Equal("accessToken", newProfile.Context.Account.GetAccessToken());
            Assert.False(newProfile.DefaultSubscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        public void NewProfileFromADWithMismatchSubscriptionThrows()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            AzureSMProfile newProfile = new AzureSMProfile();
            ProfileClient client1 = new ProfileClient(newProfile);
            var newAccount = new AzureAccount { Id = "foo" };
            newAccount.SetProperty(AzureAccount.Property.Tenants, "123");

            Assert.Throws<ArgumentException>(() => client1.InitializeProfile(AzureEnvironment.PublicEnvironments["AzureCloud"],
                Guid.NewGuid(), newAccount, null, null));
        }

        [Fact]
        public void ProfileMigratesOldDataOnce()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client1 = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));

            ProfileClient client2 = new ProfileClient(currentProfile);

            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.True(dataStore.FileExists(newProfileDataPath));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileMigratesAccountsAndDefaultSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            // Verify Environment migration
            Assert.Equal(6, client.Profile.EnvironmentTable.Count);
            Assert.Equal("Current", client.Profile.EnvironmentTable["Current"].Name);
            Assert.Equal("Dogfood", client.Profile.EnvironmentTable["Dogfood"].Name);
            Assert.Equal("https://login.windows-ppe.net/", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.AdTenant));
            Assert.Equal("https://management.core.windows.net/", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            Assert.Equal("https://df.gallery.azure-test.net", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.Gallery));
            Assert.Equal("https://windows.azure-test.net", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl));
            Assert.Equal("https://auxnext.windows.azure-test.net/publishsettings/index", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl));
            Assert.Equal("https://api-dogfood.resources.windows-int.net", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
            Assert.Equal("https://management-preview.core.windows-int.net/", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement));
            Assert.Equal(".database.windows.net", client.Profile.EnvironmentTable["Dogfood"].GetEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix));

            // Verify subscriptions
            Assert.Equal(3, client.Profile.SubscriptionTable.Count);
            Assert.False(client.Profile.SubscriptionTable.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E")));
            Assert.True(client.Profile.SubscriptionTable.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")));
            Assert.Equal("Test 2", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Name);
            Assert.True(client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].IsPropertySet(AzureSubscription.Property.Default));
            Assert.Equal("test@mail.com", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].GetAccount());
            Assert.Equal("Dogfood", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].GetEnvironment());
            Assert.Equal("123", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].GetProperty(AzureSubscription.Property.Tenants));
            Assert.True(client.Profile.SubscriptionTable.ContainsKey(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")));
            Assert.Equal("Test 3", client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Name);
            Assert.False(client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].IsPropertySet(AzureSubscription.Property.Default));
            Assert.Equal("test@mail.com", client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].GetAccount());
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].GetProperty(AzureSubscription.Property.Tenants));
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].GetEnvironment());
            Assert.Equal(EnvironmentName.AzureChinaCloud, client.Profile.SubscriptionTable[new Guid("c14d7dc5-ed4d-4346-a02f-9f1bcf78fb66")].GetEnvironment());

            // Verify accounts
            Assert.Equal(2, client.Profile.AccountTable.Count);
            Assert.Equal("test@mail.com", client.Profile.AccountTable["test@mail.com"].Id);
            Assert.Equal(AzureAccount.AccountType.User, client.Profile.AccountTable["test@mail.com"].Type);
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F").ToString()));
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("123"));
            Assert.Equal("3AF24D48B97730E5C4C9CCB12397B5E046F79E09", client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].Id);
            Assert.Equal(AzureAccount.AccountType.Certificate, client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].Type);
            Assert.False(client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].IsPropertySet(AzureAccount.Property.Tenants));
            Assert.Equal(2, client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E09"].GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);
        }

        [Fact]
        public void ProfileMigratesAccountsSkipsBadOnesAndBacksUpFile()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataBadSubscription;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            // Verify Environment migration
            Assert.Equal(4, client.Profile.EnvironmentTable.Count);

            // Verify subscriptions
            Assert.Equal(3, client.Profile.SubscriptionTable.Count);
            Assert.True(client.Profile.SubscriptionTable.ContainsKey(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")));
            Assert.Equal("Test Bad Management Endpoint", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].Name);
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F")].GetEnvironment());
            Assert.Equal("Test Null Management Endpoint", client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF")].Name);
            Assert.Equal(EnvironmentName.AzureCloud, client.Profile.SubscriptionTable[new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF")].GetEnvironment());

            Assert.True(client.Profile.SubscriptionTable.ContainsKey(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")));
            Assert.Equal("Test Bad Cert", client.Profile.SubscriptionTable[new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f")].Name);

            // Verify accounts
            Assert.Equal(2, client.Profile.AccountTable.Count);
            Assert.Equal("test@mail.com", client.Profile.AccountTable["test@mail.com"].Id);
            Assert.Equal(AzureAccount.AccountType.User, client.Profile.AccountTable["test@mail.com"].Type);
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F").ToString()));
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Subscriptions)
                .Contains(new Guid("d1e52cbc-b073-42e2-a0a0-c2f547118a6f").ToString()));
            Assert.True(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.False(client.Profile.AccountTable["test@mail.com"].GetPropertyAsArray(AzureAccount.Property.Tenants)
                .Contains("123"));
            Assert.Equal("3AF24D48B97730E5C4C9CCB12397B5E046F79E99", client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].Id);
            Assert.Equal(AzureAccount.AccountType.Certificate, client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].Type);
            Assert.Equal(0, client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Tenants).Length);
            Assert.Equal(1, client.Profile.AccountTable["3AF24D48B97730E5C4C9CCB12397B5E046F79E99"].GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);

            // Verify backup file
            Assert.True(dataStore.FileExists(oldProfileDataPathError));
            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.Equal(oldProfileDataBadSubscription, dataStore.ReadFileAsText(oldProfileDataPathError));
        }

        [Fact]
        public void ProfileMigratesCorruptedFileAndCreatedBackup()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileDataCorruptedFile;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            // Verify Environment migration
            Assert.Equal(4, client.Profile.EnvironmentTable.Count);

            // Verify subscriptions
            Assert.Equal(0, client.Profile.SubscriptionTable.Count);

            // Verify accounts
            Assert.Equal(0, client.Profile.AccountTable.Count);

            // Verify backup file
            Assert.True(dataStore.FileExists(oldProfileDataPathError));
            Assert.False(dataStore.FileExists(oldProfileDataPath));
            Assert.Equal(oldProfileDataCorruptedFile, dataStore.ReadFileAsText(oldProfileDataPathError));
        }

        [Fact]
        public void AddAzureAccountReturnsAccountWithAllSubscriptionsInRdfeMode()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "test", Type = AzureAccount.AccountType.User }, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("test", account.Id);
            Assert.Equal(2, account.GetSubscriptions(client.Profile).Count);
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.False(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(csmSubscription1.SubscriptionId)));
        }

        [Fact]
        public void AddAzureAccountFiltersEmptyAdClientsInRdfeMode()
        {
            var emptyTenantIdrdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = ""
            };

            var disabledTenantIdrdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Disabled,
                ActiveDirectoryTenantId = "B59BE059-5E3F-463B-8C1A-831A29819B52"
            };

            var deletedTenantIdrdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Deleted,
                ActiveDirectoryTenantId = "B59BE059-5E3F-463B-8C1A-831A29819B52"
            };

            var deletingTenantIdrdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Deleting,
                ActiveDirectoryTenantId = "B59BE059-5E3F-463B-8C1A-831A29819B52"
            };

            SetMocks(
                new[] { rdfeSubscription1, emptyTenantIdrdfeSubscription, disabledTenantIdrdfeSubscription, deletedTenantIdrdfeSubscription, deletingTenantIdrdfeSubscription }.ToList(),
                new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(
                new AzureAccount { Id = "test", Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                null);

            Assert.Equal("test", account.Id);
            Assert.Equal(1, account.GetSubscriptions(client.Profile).Count);
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.False(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(csmSubscription1.SubscriptionId)));
        }

        [Fact]
        public void AddAzureAccountReturnsAccountWithAllSubscriptionsInCsmMode()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1 }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(
                    new AzureAccount
                    {
                        Id = "test",
                        Type = AzureAccount.AccountType.User
                    },
                    AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                    null);

            Assert.Equal("test", account.Id);
            Assert.Equal(2, account.GetSubscriptions(client.Profile).Count);
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.False(account.GetSubscriptions(client.Profile).Any(s => s.GetId() == new Guid(csmSubscription1.SubscriptionId)));
        }

        /// <summary>
        /// Verify that if a user has a different identity in one tenantId, the identity is not added if it has no
        /// access to subscriptions
        /// </summary>
        [Fact]
        public void AddAzureAccountWithImpersonatedGuestWithNoSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1 }.ToList(),
                     new List<Microsoft.Azure.Subscriptions.Models.Subscription>(),
                     new[] { commonTenant, guestTenant }.ToList(),
                    (userAccount, environment, tenant) =>
                    {
                        var token = new MockAccessToken
                        {
                            UserId = tenant == commonTenant.TenantId ? userAccount.Id : "UserB",
                            AccessToken = "def",
                            LoginType = LoginType.OrgId
                        };
                        userAccount.Id = token.UserId;
                        return token;
                    });
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User }, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("UserA", account.Id);
            Assert.Equal(1, account.GetSubscriptions(client.Profile).Count);
            var subrdfe1 = account.GetSubscriptions(client.Profile).FirstOrDefault(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId));
            var userA = client.GetAccount("UserA");
            Assert.Throws<ArgumentException>(() => client.GetAccount("UserB"));
            Assert.NotNull(userA);
            Assert.Contains<string>(rdfeSubscription1.SubscriptionId, userA.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(subrdfe1);
            Assert.Equal("UserA", subrdfe1.GetAccount());
        }

        /// <summary>
        /// Verify that multiple accounts can be added if a user has different identities in different domains, linked to the same login
        /// Verify that subscriptions with admin access for all accounts are added
        /// </summary>
        [Fact]
        public void AddAzureAccountWithImpersonatedGuestWithSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(),
                     new List<CSMSubscription>(),
                     new[] { commonTenant, guestTenant }.ToList(),
                    (userAccount, environment, tenant) =>
                    {
                        var token = new MockAccessToken
                        {
                            UserId = tenant == commonTenant.TenantId ? userAccount.Id : "UserB",
                            AccessToken = "def",
                            LoginType = LoginType.OrgId
                        };
                        userAccount.Id = token.UserId;
                        return token;
                    });
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            Assert.Equal("UserA", account.Id);
            Assert.Equal(2, account.GetSubscriptions(client.Profile).Count);
            var subrdfe1 = account.GetSubscriptions(client.Profile).FirstOrDefault(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId));
            var userA = client.GetAccount("UserA");
            var userB = client.GetAccount("UserB");
            var subGuest = userB.GetSubscriptions(client.Profile).FirstOrDefault(s => s.GetId() == new Guid(guestRdfeSubscription.SubscriptionId));
            Assert.NotNull(userA);
            Assert.NotNull(userB);
            Assert.Contains<string>(rdfeSubscription1.SubscriptionId, userA.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.Contains<string>(guestRdfeSubscription.SubscriptionId, userB.GetPropertyAsArray(AzureAccount.Property.Subscriptions), StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(subrdfe1);
            Assert.NotNull(subGuest);
            Assert.Equal("UserA", subrdfe1.GetAccount());
            Assert.Equal("UserB", subGuest.GetAccount());
        }
        /// <summary>
        /// Test that when accountId is added more than once with different capitalization, only a single accountId is added
        /// and that accounts can be retrieved case-insensitively
        /// </summary>
        [Fact]
        public void AddAzureAccountIsCaseInsensitive()
        {
            SetMocks(new[] { rdfeSubscription1, guestRdfeSubscription }.ToList(),
                     new List<Microsoft.Azure.Subscriptions.Models.Subscription>(),
                     new[] { commonTenant, guestTenant }.ToList(),
                     (userAccount, environment, tenant) =>
                     {
                         var token = new MockAccessToken
                         {
                             UserId = tenant == commonTenant.TenantId ? userAccount.Id : "USERA",
                             AccessToken = "def",
                             LoginType = LoginType.OrgId
                         };
                         userAccount.Id = token.UserId;
                         return token;
                     });
            MemoryDataStore dataStore = new MemoryDataStore();
            dataStore.VirtualStore[oldProfileDataPath] = oldProfileData;
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var account = client.AddAccountAndLoadSubscriptions(new AzureAccount { Id = "UserA", Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud], null);

            var userA = client.GetAccount("UserA");
            var secondUserA = client.GetAccount("USERA");
            Assert.NotNull(userA);
            Assert.NotNull(secondUserA);
            Assert.Equal(userA.Id, secondUserA.Id);
        }

        [Fact]
        public void GetAzureAccountReturnsAccountWithSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test").ToList();

            Assert.Equal(1, account.Count);
            Assert.Equal("test", account[0].Id);
            Assert.Equal(2, account[0].GetSubscriptions(client.Profile).Count);
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription1.Id));
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription2.Id));
        }

        [Fact]
        public void GetAzureAccountWithoutEnvironmentReturnsAccount()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test").ToList();

            Assert.Equal(1, account.Count);
            Assert.Equal("test", account[0].Id);
            Assert.Equal(2, account[0].GetSubscriptions(client.Profile).Count);
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription1.Id));
            Assert.True(account[0].GetSubscriptions(client.Profile).Any(s => s.Id == azureSubscription2.Id));
        }

        [Fact]
        public void GetAzureAccountReturnsEmptyEnumerationForNonExistingUser()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts("test2").ToList();

            Assert.Equal(0, account.Count);
        }

        [Fact]
        public void GetAzureAccountReturnsAllAccountsWithNullUser()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.SetAccount("test2");
            var account2 = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
            };
            account2.SetSubscriptions(azureSubscription3withoutUser.Id);
            client.Profile.AccountTable["test2"] = account2;

            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;

            var account = client.ListAccounts(null).ToList();

            Assert.Equal(2, account.Count);
        }

        [Fact]
        public void RemoveAzureAccountRemovesSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.SetAccount("test2");
            var account = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
            };
            account.SetSubscriptions(azureSubscription3withoutUser.Id);
            client.Profile.AccountTable["test2"] = account;
            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;
            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            Assert.Equal(3, client.Profile.SubscriptionTable.Count);

            client.RemoveAccount("test2");

            Assert.Equal(2, client.Profile.SubscriptionTable.Count);
            Assert.Equal(0, log.Count);
        }

        [Fact]
        public void RemoveAzureAccountRemovesDefaultSubscriptionAndWritesWarning()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.SetAccount("test2");
            var account1 = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
            };
            account1.SetSubscriptions(azureSubscription3withoutUser.Id);
            client.Profile.AccountTable["test2"] = account1;
            client.Profile.SubscriptionTable[azureSubscription3withoutUser.GetId()] = azureSubscription3withoutUser;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;
            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            Assert.Equal(3, client.Profile.SubscriptionTable.Count);

            var account = client.RemoveAccount("test");

            Assert.Equal(1, client.Profile.SubscriptionTable.Count);
            Assert.Equal("test", account.Id);
            Assert.Equal(2, account.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Length);
            Assert.Equal(1, log.Count);
            Assert.Equal(
                "The default subscription is being removed. Use Select-AzureSubscription -Default <subscriptionName> to select a new default subscription.",
                log[0]);
        }

        [Fact]
        public void RemoveAzureAccountRemovesDefaultAccountFromSubscription()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.SetAccount("test2");
            var account1 = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
            };
            account1.SetSubscriptions(azureSubscription1.Id);
            client.Profile.AccountTable["test2"] = account1;
            client.Profile.SubscriptionTable[azureSubscription1.GetId()].SetAccount(azureAccount.Id);
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;

            var account = client.RemoveAccount(azureAccount.Id);

            Assert.Equal("test2", client.Profile.SubscriptionTable[azureSubscription1.GetId()].GetAccount());
        }

        [Fact]
        public void RemoveAzureAccountRemovesInMemoryAccount()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription3withoutUser.SetAccount("test2");
            var account2 = new AzureAccount
            {
                Id = "test2",
                Type = AzureAccount.AccountType.User,
            };
            account2.SetSubscriptions(azureSubscription1.Id);
            client.Profile.AccountTable["test2"] = account2;
            client.Profile.SubscriptionTable[azureSubscription1.GetId()].SetAccount(azureAccount.Id);
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;
            currentProfile.DefaultSubscription = azureSubscription1;

            client.RemoveAccount(azureAccount.Id);

            Assert.Equal("test2", currentProfile.Context.Account.Id);
            Assert.Equal("test2", currentProfile.Context.Subscription.GetAccount());
            Assert.Equal(azureSubscription1.Id, currentProfile.Context.Subscription.Id);

            client.RemoveAccount("test2");

            Assert.Null(currentProfile.Context.Account);
            Assert.Null(currentProfile.Context.Subscription);
            Assert.Null(currentProfile.Context.Environment);
        }

        [Fact]
        public void AddAzureEnvironmentAddsEnvironment()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            Assert.Equal(4, client.Profile.EnvironmentTable.Count);

            Assert.Throws<ArgumentNullException>(() => client.AddOrSetEnvironment(null));
            var env = client.AddOrSetEnvironment(azureEnvironment);

            Assert.Equal(5, client.Profile.EnvironmentTable.Count);
            Assert.Equal(env, azureEnvironment);
        }

        [Fact]
        public void GetAzureEnvironmentsListsEnvironments()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            var env1 = client.ListEnvironments(null);

            Assert.Equal(4, env1.Count);

            var env2 = client.ListEnvironments("bad");

            Assert.Equal(0, env2.Count);

            var env3 = client.ListEnvironments(EnvironmentName.AzureCloud);

            Assert.Equal(1, env3.Count);
        }

        [Fact]
        public void RemoveAzureEnvironmentRemovesEnvironmentSubscriptionsAndAccounts()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.Profile.EnvironmentTable[azureEnvironment.Name] = azureEnvironment;
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;

            Assert.Equal(2, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == "Test"));
            Assert.Equal(5, client.Profile.EnvironmentTable.Count);
            Assert.Equal(1, client.Profile.AccountTable.Count);

            Assert.Throws<ArgumentNullException>(() => client.RemoveEnvironment(null));
            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment("bad"));

            var env = client.RemoveEnvironment(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, env.Name);
            Assert.Equal(0, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == "Test"));
            Assert.Equal(4, client.Profile.EnvironmentTable.Count);
            Assert.Equal(0, client.Profile.AccountTable.Count);
        }

        [Fact]
        public void RemoveAzureEnvironmentDoesNotRemoveEnvironmentSubscriptionsAndAccountsForAzureCloudOrChinaCloud()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            azureSubscription1.SetEnvironment(EnvironmentName.AzureCloud);
            azureSubscription2.SetEnvironment(EnvironmentName.AzureChinaCloud);
            client.Profile.SubscriptionTable[azureSubscription1.GetId()] = azureSubscription1;
            client.Profile.SubscriptionTable[azureSubscription2.GetId()] = azureSubscription2;

            Assert.Equal(1, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == EnvironmentName.AzureCloud));
            Assert.Equal(1, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == EnvironmentName.AzureChinaCloud));
            Assert.Equal(4, client.Profile.EnvironmentTable.Count);
            Assert.Equal(1, client.Profile.AccountTable.Count);

            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment(EnvironmentName.AzureCloud));
            Assert.Throws<ArgumentException>(() => client.RemoveEnvironment(EnvironmentName.AzureChinaCloud));

            Assert.Equal(1, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == EnvironmentName.AzureCloud));
            Assert.Equal(1, client.Profile.SubscriptionTable.Values.Count(s => s.GetEnvironment() == EnvironmentName.AzureChinaCloud));
            Assert.Equal(4, client.Profile.EnvironmentTable.Count);
            Assert.Equal(1, client.Profile.AccountTable.Count);
        }

        [Fact]
        public void SetAzureEnvironmentUpdatesEnvironment()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            Assert.Equal(4, client.Profile.EnvironmentTable.Count);

            Assert.Throws<ArgumentNullException>(() => client.AddOrSetEnvironment(null));

            var env2 = client.AddOrSetEnvironment(azureEnvironment);
            Assert.Equal(env2.Name, azureEnvironment.Name);
            Assert.NotNull(env2.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement));
            AzureEnvironment newEnv = new AzureEnvironment
            {
                Name = azureEnvironment.Name
            };
            newEnv.SetEndpoint(AzureEnvironment.Endpoint.Graph, "foo");
            env2 = client.AddOrSetEnvironment(newEnv);
            Assert.Equal("foo", env2.GetEndpoint(AzureEnvironment.Endpoint.Graph));
            Assert.NotNull(env2.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement));
        }

        [Fact]
        public void GetAzureEnvironmentReturnsCorrectValue()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetEnvironment(azureEnvironment);

            var defaultEnv = client.GetEnvironmentOrDefault(null);

            Assert.Equal(EnvironmentName.AzureCloud, defaultEnv.Name);

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);

            Assert.Throws<ArgumentException>(() => client.GetEnvironmentOrDefault("bad"));
        }

        [Fact]
        public void GetCurrentEnvironmentReturnsCorrectValue()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(azureSubscription1);

            currentProfile.DefaultSubscription = azureSubscription1;

            var newEnv = client.GetEnvironmentOrDefault(azureEnvironment.Name);

            Assert.Equal(azureEnvironment.Name, newEnv.Name);
        }

        [Fact]
        public void AddOrSetAzureSubscriptionChecksAndUpdates()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);

            Assert.Equal(1, client.Profile.SubscriptionTable.Count);

            var subscription = client.AddOrSetSubscription(azureSubscription1);

            Assert.Equal(1, client.Profile.SubscriptionTable.Count);
            Assert.Equal(1, client.Profile.AccountTable.Count);
            Assert.Equal(subscription, azureSubscription1);
            Assert.Throws<ArgumentNullException>(() => client.AddOrSetSubscription(null));
            Assert.Throws<ArgumentNullException>(() => client.AddOrSetSubscription(
                new AzureSubscription { Id = new Guid().ToString(), Name = "foo" }));
        }

        [Fact]
        public void AddOrSetAzureSubscriptionUpdatesInMemory()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);

            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            currentProfile.DefaultSubscription = azureSubscription1;
            azureSubscription1.SetStorageAccount("testAccount");
            Assert.Equal(azureSubscription1.GetId(), currentProfile.Context.Subscription.GetId());
            Assert.Equal(azureSubscription1.GetStorageAccount(),
                currentProfile.Context.Subscription.GetStorageAccount());

            var newSubscription = new AzureSubscription
            {
                Id = azureSubscription1.Id,
                Name = azureSubscription1.Name
            };
            newSubscription.SetEnvironment(azureSubscription1.GetEnvironment());
            newSubscription.SetAccount(azureSubscription1.GetAccount());
            newSubscription.SetStorageAccount("testAccount1");

            client.AddOrSetSubscription(newSubscription);
            var newSubscriptionFromProfile = client.Profile.SubscriptionTable[newSubscription.GetId()];

            Assert.Equal(newSubscription.GetId(), currentProfile.Context.Subscription.GetId());
            Assert.Equal(newSubscription.GetId(), newSubscriptionFromProfile.GetId());
            Assert.Equal(newSubscription.GetStorageAccount(),
                currentProfile.Context.Subscription.GetStorageAccount());
            Assert.Equal(newSubscription.GetStorageAccount(),
                newSubscriptionFromProfile.GetStorageAccount());
        }

        [Fact]
        public void RemoveAzureSubscriptionChecksAndRemoves()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureSubscription1.GetAccount());

            Assert.Equal(1, client.Profile.SubscriptionTable.Count);

            List<string> log = new List<string>();
            client.WarningLog = log.Add;

            var subscription = client.RemoveSubscription(azureSubscription1.Name);

            Assert.Equal(0, client.Profile.SubscriptionTable.Count);
            Assert.Equal(azureSubscription1.Name, subscription.Name);
            Assert.Equal(1, log.Count);
            Assert.Equal(
                "The default subscription is being removed. Use Select-AzureSubscription -Default <subscriptionName> to select a new default subscription.",
                log[0]);
            Assert.Throws<ArgumentException>(() => client.RemoveSubscription("bad"));
            Assert.Throws<ArgumentNullException>(() => client.RemoveSubscription(null));
        }

        [Fact]
        public void RefreshSubscriptionsUpdatesAccounts()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.True(client.Profile.AccountTable[azureAccount.Id].HasSubscription(new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.True(client.Profile.AccountTable[azureAccount.Id].HasSubscription(new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.False(client.Profile.AccountTable[azureAccount.Id].HasSubscription(new Guid(csmSubscription1.SubscriptionId)));
            Assert.True(client.Profile.AccountTable[azureAccount.Id].HasSubscription(new Guid(csmSubscription1withDuplicateId.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsMergesFromServer()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetEnvironment(azureEnvironment);
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.Equal(3, subscriptions.Count);
            Assert.Equal(3, subscriptions.Count(s => s.GetAccount() == "test"));
            Assert.Equal(1, subscriptions.Count(s => s.Id == azureSubscription1.Id));
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.Equal(0, subscriptions.Count(s => s.GetId() == new Guid(csmSubscription1.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsWorksWithMooncake()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            client.Profile.AccountTable[azureAccount.Id] = azureAccount;

            var subscriptions = client.RefreshSubscriptions(client.Profile.EnvironmentTable[EnvironmentName.AzureChinaCloud]);

            Assert.Equal(2, subscriptions.Count);
            Assert.Equal(2, subscriptions.Count(s => s.GetAccount() == "test"));
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription2.SubscriptionId)));
        }

        [Fact]
        public void RefreshSubscriptionsListsAllSubscriptions()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);

            var subscriptions = client.RefreshSubscriptions(azureEnvironment);

            Assert.Equal(3, subscriptions.Count);
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription1.SubscriptionId)));
            Assert.Equal(1, subscriptions.Count(s => s.GetId() == new Guid(rdfeSubscription2.SubscriptionId)));
            Assert.Equal(0, subscriptions.Count(s => s.GetId() == new Guid(csmSubscription1.SubscriptionId)));
            Assert.True(subscriptions.All(s => s.GetEnvironment() == "Test"));
            Assert.True(subscriptions.All(s => s.GetAccount() == "test"));
        }

        [Fact]
        public void GetAzureSubscriptionByNameChecksAndReturnsOnlyLocal()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);

            var subscriptions = client.GetSubscription(azureSubscription1.Name);

            Assert.Equal(azureSubscription1.Id, subscriptions.Id);
            Assert.Throws<ArgumentException>(() => client.GetSubscription(new Guid()));
        }

        [Fact]
        public void GetAzureSubscriptionByIdChecksAndReturnsOnlyLocal()
        {
            SetMocks(new[] { rdfeSubscription1, rdfeSubscription2 }.ToList(), new[] { csmSubscription1, csmSubscription1withDuplicateId }.ToList());
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.AddOrSetSubscription(azureSubscription2);

            var subscriptions = client.GetSubscription(azureSubscription1.GetId());

            Assert.Equal(azureSubscription1.Id, subscriptions.Id);
            Assert.Throws<ArgumentException>(() => client.GetSubscription(new Guid()));
        }

        [Fact]
        public void SetAzureSubscriptionAsDefaultSetsDefaultAndCurrent()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);

            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.GetAccount());

            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);
            Assert.Equal(azureSubscription2.Id, currentProfile.Context.Subscription.Id);
            Assert.Equal(azureSubscription2.GetAccount(), currentProfile.Context.Account.Id);
            Assert.Equal(azureSubscription2.GetEnvironment(), currentProfile.Context.Environment.Name);
            var notFoundEx = Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault("bad", null));
            var invalidEx = Assert.Throws<ArgumentException>(() => client.SetSubscriptionAsDefault(null, null));
            Assert.Contains("doesn't exist", notFoundEx.Message);
            Assert.Contains("non-null", invalidEx.Message);
        }

        [Fact]
        public void ClearDefaultAzureSubscriptionClearsDefault()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.Profile.AccountTable[azureAccount.Id] = azureAccount;
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription2);

            Assert.Null(client.Profile.DefaultSubscription);
            client.SetSubscriptionAsDefault(azureSubscription2.Name, azureSubscription2.GetAccount());
            Assert.Equal(azureSubscription2.Id, client.Profile.DefaultSubscription.Id);

            client.ClearDefaultSubscription();

            Assert.Null(client.Profile.DefaultSubscription);
            Assert.Null(client.Profile.Context.Account);
            Assert.Null(client.Profile.Context.Environment);
            Assert.Null(client.Profile.Context.Subscription);
        }

        [Fact]
        public void ImportPublishSettingsLoadsAndReturnsSubscriptions()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);
            var account = client.Profile.AccountTable.Values.First();

            Assert.True(subscriptions.All(s => s.GetAccount() == account.Id));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsDefaultsToAzureCloudEnvironmentWithManagementUrl()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == EnvironmentName.AzureCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithManagementUrl()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            azureEnvironment.SetEndpoint(AzureEnvironment.Endpoint.ServiceManagement, "https://newmanagement.core.windows.net/");
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == azureEnvironment.Name));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithChinaManagementUrl()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfileChina);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == EnvironmentName.AzureChinaCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesProperEnvironmentWithChinaManagementUrlOld()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfileChinaOld);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == EnvironmentName.AzureChinaCloud));
            Assert.Equal(1, subscriptions.Count);
            Assert.Equal(1, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsDefaultsToAzureCloudWithIncorrectManagementUrl()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", null);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == EnvironmentName.AzureCloud));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsUsesPassedInEnvironment()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetEnvironment(azureEnvironment);
            client.AddOrSetSubscription(azureSubscription1);
            client.SetSubscriptionAsDefault(azureSubscription1.Name, azureAccount.Id);
            client.Profile.Save();

            client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile3);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);

            Assert.True(subscriptions.All(s => s.GetEnvironment() == azureEnvironment.Name));
            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(7, client.Profile.SubscriptionTable.Count);
        }

        [Fact]
        public void ImportPublishSettingsAddsSecondCertificate()
        {
            MemoryDataStore dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            ProfileClient client = new ProfileClient(currentProfile);
            var newSubscription = new AzureSubscription
            {
                Id = "f62b1e05-af8f-4203-8f97-421089adc053",
                Name = "Microsoft Azure Sandbox 9-220",
            };

            newSubscription.SetEnvironment(EnvironmentName.AzureCloud);
            newSubscription.SetAccount(azureAccount.Id);
            azureAccount.SetProperty(AzureAccount.Property.Subscriptions, newSubscription.Id);
            client.AddOrSetAccount(azureAccount);
            client.AddOrSetSubscription(newSubscription);
            client.Profile.Save();

            currentProfile = new AzureSMProfile(Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile));
            client = new ProfileClient(currentProfile);

            dataStore.WriteFile("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings",
                Microsoft.WindowsAzure.Commands.Common.Test.Properties.Resources.ValidProfile);

            client.AddOrSetEnvironment(azureEnvironment);
            var subscriptions = client.ImportPublishSettings("ImportPublishSettingsLoadsAndReturnsSubscriptions.publishsettings", azureEnvironment.Name);

            Assert.Equal(2, client.Profile.AccountTable.Count());
            var certAccount = client.Profile.AccountTable.Values.First(a => a.Type == AzureAccount.AccountType.Certificate);
            var userAccount = client.Profile.AccountTable.Values.First(a => a.Type == AzureAccount.AccountType.User);

            Assert.True(subscriptions.All(s => s.GetAccount() == certAccount.Id));
            Assert.Equal(azureAccount.Id, client.Profile.SubscriptionTable.Values.First(s => s.Id == newSubscription.Id).GetAccount());

            Assert.True(userAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Contains(newSubscription.Id));
            Assert.True(certAccount.GetPropertyAsArray(AzureAccount.Property.Subscriptions).Contains(newSubscription.Id));

            Assert.Equal(6, subscriptions.Count);
            Assert.Equal(6, client.Profile.SubscriptionTable.Count);
        }

        private void SetMocks(List<RDFESubscription> rdfeSubscriptions,
            List<CSMSubscription> csmSubscriptions,
            List<TenantIdDescription> tenants = null,
            Func<IAzureAccount, IAzureEnvironment, string, IAccessToken> tokenProvider = null)
        {
            ClientMocks clientMocks = new ClientMocks(new Guid(defaultSubscription));

            clientMocks.LoadRdfeSubscriptions(rdfeSubscriptions);
            clientMocks.LoadCsmSubscriptions(csmSubscriptions);
            clientMocks.LoadTenants(tenants);

            AzureSession.Instance.ClientFactory = new MockClientFactory(new object[] { clientMocks.RdfeSubscriptionClientMock.Object,
                clientMocks.CsmSubscriptionClientMock.Object })
            {
                MoqClients = true
            };

            var mockFactory = new MockTokenAuthenticationFactory();
            if (tokenProvider != null)
            {
                mockFactory.TokenProvider = tokenProvider;
            }

            AzureSession.Instance.AuthenticationFactory = mockFactory;
        }

        private void SetMockData()
        {
            commonTenant = new TenantIdDescription
            {
                Id = "Common",
                TenantId = "Common"
            };
            guestTenant = new TenantIdDescription
            {
                Id = "Guest",
                TenantId = "Guest"
            };
            rdfeSubscription1 = new RDFESubscription
            {
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub1",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Common"
            };
            rdfeSubscription2 = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Warned,
                ActiveDirectoryTenantId = "Common"
            };
            guestRdfeSubscription = new RDFESubscription
            {
                SubscriptionId = "26E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1C",
                SubscriptionName = "RdfeSub2",
                SubscriptionStatus = Microsoft.WindowsAzure.Subscriptions.Models.SubscriptionStatus.Active,
                ActiveDirectoryTenantId = "Guest"
            };
            csmSubscription1 = new CSMSubscription
            {
                Id = "Subscriptions/36E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "CsmSub1",
                State = "Active",
                SubscriptionId = "36E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            csmSubscription1withDuplicateId = new CSMSubscription
            {
                Id = "Subscriptions/16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "RdfeSub1",
                State = "Active",
                SubscriptionId = "16E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            csmSubscription2 = new CSMSubscription
            {
                Id = "Subscriptions/46E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                DisplayName = "CsmSub2",
                State = "Active",
                SubscriptionId = "46E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E"
            };
            guestCsmSubscription = new CSMSubscription
            {
                Id = "Subscriptions/76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1D",
                DisplayName = "CsmGuestSub",
                State = "Active",
                SubscriptionId = "76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1D"
            };
            azureSubscription1 = new AzureSubscription
            {
                Id = "56E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                Name = "LocalSub1"
            };
            azureSubscription1.SetDefault();
            azureSubscription1.SetEnvironment("Test");
            azureSubscription1.SetAccount("test");
            azureSubscription2 = new AzureSubscription
            {
                Id = "66E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                Name = "LocalSub2",
            };
            azureSubscription2.SetEnvironment("Test");
            azureSubscription2.SetAccount("test");
            azureSubscription3withoutUser = new AzureSubscription
            {
                Id = "76E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E",
                Name = "LocalSub3",
            };
            azureSubscription3withoutUser.SetEnvironment("Test");
            azureEnvironment = new AzureEnvironment
            {
                Name = "Test",
                ServiceManagementUrl = "https://umapi.rdfetest.dnsdemo4.com:8443/",
                ManagementPortalUrl = "https://windows.azure-test.net",
                AdTenant = "https://login.windows-ppe.net/",
                ActiveDirectoryAuthority = "https://login.windows-ppe.net/",
                GalleryUrl = "https://current.gallery.azure-test.net",
                ResourceManagerUrl = "https://api-current.resources.windows-int.net/"
            };
            azureAccount = new AzureAccount
            {
                Id = "test",
                Type = AzureAccount.AccountType.User,
            };

            azureAccount.SetSubscriptions(azureSubscription1.Id + "," + azureSubscription2.Id);
            newProfileDataPath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.ProfileFile);
            oldProfileDataPath = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.OldProfileFile);
            oldProfileDataPathError = Path.Combine(AzureSession.Instance.ProfileDirectory, AzureSession.Instance.OldProfileFileBackup);
            oldProfileData = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://current.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>http://go.microsoft.com/fwlink/?LinkId=254433</ManagementPortalUrl>
                      <Name>Current</Name>
                      <PublishSettingsFileUrl>d:\Code\azure.publishsettings</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-current.resources.windows-int.net/</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://umapi.rdfetest.dnsdemo4.com:8443/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://df.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>https://windows.azure-test.net</ManagementPortalUrl>
                      <Name>Dogfood</Name>
                      <PublishSettingsFileUrl>https://auxnext.windows.azure-test.net/publishsettings/index</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-dogfood.resources.windows-int.net</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://management-preview.core.windows-int.net/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                  </Environments>
                  <Subscriptions>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1E</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId>123</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management-preview.core.windows-int.net/</ManagementEndpoint>
                      <Name>Test 2</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint>https://login.windows.net/</ActiveDirectoryEndpoint>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <ActiveDirectoryTenantId>72f988bf-86f1-41af-91ab-2d7cd011db47</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E09</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test 3</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>d1e52cbc-b073-42e2-a0a0-c2f547118a6f</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E09</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.chinacloudapi.cn/</ManagementEndpoint>
                      <Name>Mooncake Test</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>c14d7dc5-ed4d-4346-a02f-9f1bcf78fb66</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                  </Subscriptions>
                </ProfileData>";

            oldProfileDataBadSubscription = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments>                    
                  </Environments>
                  <Subscriptions>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId i:nil=""true"" />
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test Nill ID</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint>Bad Data</ManagementEndpoint>
                      <Name>Test Bad Management Endpoint</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2AD1F</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint i:nil=""true"" />
                      <ActiveDirectoryServiceEndpointResourceId i:nil=""true"" />
                      <ActiveDirectoryTenantId i:nil=""true"" />
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>true</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate i:nil=""true""/>
                      <ManagementEndpoint i:nil=""true""/>
                      <Name>Test Null Management Endpoint</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>06E3F6FD-A3AA-439A-8FC4-1F5C41D2ADFF</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>
                    <AzureSubscriptionData>
                      <ActiveDirectoryEndpoint>https://login.windows.net/</ActiveDirectoryEndpoint>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <ActiveDirectoryTenantId>72f988bf-86f1-41af-91ab-2d7cd011db47</ActiveDirectoryTenantId>
                      <ActiveDirectoryUserId>test@mail.com</ActiveDirectoryUserId>
                      <CloudStorageAccount i:nil=""true"" />
                      <GalleryEndpoint i:nil=""true"" />
                      <IsDefault>false</IsDefault>
                      <LoginType i:nil=""true"" />
                      <ManagementCertificate>3AF24D48B97730E5C4C9CCB12397B5E046F79E99</ManagementCertificate>
                      <ManagementEndpoint>https://management.core.windows.net/</ManagementEndpoint>
                      <Name>Test Bad Cert</Name>
                      <RegisteredResourceProviders xmlns:d4p1=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"" />
                      <ResourceManagerEndpoint i:nil=""true"" />
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <SubscriptionId>d1e52cbc-b073-42e2-a0a0-c2f547118a6f</SubscriptionId>
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureSubscriptionData>                    
                  </Subscriptions>
                </ProfileData>";

            oldProfileDataCorruptedFile = @"<?xml version=""1.0"" encoding=""utf-8""?>
                <ProfileData xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/Microsoft.Azure.Common.Authentication"">
                  <DefaultEnvironmentName>AzureCloud</DefaultEnvironmentName>
                  <Environments bad>
                    <AzureEnvironmentData>
                      <ActiveDirectoryServiceEndpointResourceId>https://management.core.windows.net/</ActiveDirectoryServiceEndpointResourceId>
                      <AdTenantUrl>https://login.windows-ppe.net/</AdTenantUrl>
                      <CommonTenantId>Common</CommonTenantId>
                      <GalleryEndpoint>https://current.gallery.azure-test.net</GalleryEndpoint>
                      <ManagementPortalUrl>http://go.microsoft.com/fwlink/?LinkId=254433</ManagementPortalUrl>
                      <Name>Current</Name>
                      <PublishSettingsFileUrl>d:\Code\azure.publishsettings</PublishSettingsFileUrl>
                      <ResourceManagerEndpoint>https://api-current.resources.windows-int.net/</ResourceManagerEndpoint>
                      <ServiceEndpoint>https://umapi.rdfetest.dnsdemo4.com:8443/</ServiceEndpoint>
                      <SqlDatabaseDnsSuffix>.database.windows.net</SqlDatabaseDnsSuffix>
                      <StorageEndpointSuffix i:nil=""true"" />
                      <TrafficManagerDnsSuffix>trafficmanager.net</TrafficManagerDnsSuffix>
                    </AzureEnvironmentData>
                  <Subscriptions>                    
                  </Subscriptions>
                </ProfileData>";
            oldProfileJsonData = @"{
  ""Environments"": [
    {
                ""Name"": ""AzureChinaCloudMirror"",
      ""OnPremise"": true,
      ""Endpoints"": {
                    ""PublishSettingsFileUrl"": ""http://go.microsoft.com/fwlink/?LinkID=301776"",
        ""ServiceManagement"": ""https://management.core.chinacloudapi.cn/"",
        ""ResourceManager"": ""https://management.chinacloudapi.cn/"",
        ""ManagementPortalUrl"": ""http://go.microsoft.com/fwlink/?LinkId=301902"",
        ""StorageEndpointSuffix"": ""core.chinacloudapi.cn"",
        ""ActiveDirectory"": ""https://login.chinacloudapi.cn/"",
        ""ActiveDirectoryServiceEndpointResourceId"": ""https://management.core.chinacloudapi.cn/"",
        ""Gallery"": ""True"",
        ""Graph"": ""https://graph.chinacloudapi.cn/"",
        ""AzureKeyVaultDnsSuffix"": null,
        ""AzureKeyVaultServiceEndpointResourceId"": null,
        ""TrafficManagerDnsSuffix"": null,
        ""SqlDatabaseDnsSuffix"": null,
        ""AdTenant"": ""Common""
      }
            }
  ],
  ""Subscriptions"": [
    {
      ""Id"": ""90d2b4aa-1640-43d4-98c2-790aab234a4d"",
      ""Name"": ""Azure Contoso Infrastructure"",
      ""Environment"": ""AzureCloud"",
      ""Account"": ""someuser@contoso.com"",
      ""State"": null,
      ""Properties"": {
        ""Tenants"": ""594b5a60-8d1a-4f27-9367-6bd92c72ee82"",
        ""Default"": ""True""
      }
},
    {
      ""Id"": ""f7de4568-57fb-40fe-8186-3419a2f2f522"",
      ""Name"": ""Azure Contoso CI"",
      ""Environment"": ""AzureCloud"",
      ""Account"": ""someuser@contoso.com"",
      ""State"": null,
      ""Properties"": {
        ""Tenants"": ""594b5a60-8d1a-4f27-9367-6bd92c72ee82""
      }
    },
    {
      ""Id"": ""da7902f9-7072-4a86-aead-5a1c8b768a1a"",
      ""Name"": ""Azure Contoso Subscription2"",
      ""Environment"": ""AzureCloud"",
      ""Account"": ""someuser@contoso.com"",
      ""State"": null,
      ""Properties"": {
        ""Tenants"": ""20623033-0e48-4521-bb84-01f3e316969d""
      }
    },
    {
      ""Id"": ""8d9bbf24-8d3a-40c9-b6ad-3aa54f768e15"",
      ""Name"": ""Azure Contoso China"",
      ""Environment"": ""AzureChinaCloudMirror"",
      ""Account"": ""someuser@contoso.cn"",
      ""State"": null,
      ""Properties"": {
        ""Tenants"": ""17859926-0a62-42e5-bbf2-71ffbc7e7ad2""
      }
    }
  ],
  ""Accounts"": [
    {
      ""Id"": ""0123456789"",
      ""Type"": 0,
      ""Properties"": {
        ""Subscriptions"": ""90d2b4aa-1640-43d4-98c2-790aab234a4d""
      }
    },
    {
      ""Id"": ""1234567890"",
      ""Type"": 0,
      ""Properties"": {
        ""Subscriptions"": ""f7de4568-57fb-40fe-8186-3419a2f2f522""
      }
    },
    {
      ""Id"": ""someuser@contoso.com"",
      ""Type"": 1,
      ""Properties"": {
        ""Subscriptions"": "",f7de4568-57fb-40fe-8186-3419a2f2f522,90d2b4aa-1640-43d4-98c2-790aab234a4d,da7902f9-7072-4a86-aead-5a1c8b768a1a"",
        ""Tenants"": ""594b5a60-8d1a-4f27-9367-6bd92c72ee82,20623033-0e48-4521-bb84-01f3e316969d""
      }
    },
    {
      ""Id"": ""someuser@contoso.cn"",
      ""Type"": 1,
      ""Properties"": {
        ""Subscriptions"": ""8d9bbf24-8d3a-40c9-b6ad-3aa54f768e15"",
        ""Tenants"": ""17859926-0a62-42e5-bbf2-71ffbc7e7ad2""
      }
    }
  ]
}";
        }
    }
}
