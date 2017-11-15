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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Globalization;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class PSSerializationTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertFullProfilet()
        {
            var context = GetDefaultContext();
            var prof = new PSAzureProfile();
            prof.Context = new PSAzureContext(context);
            ConvertAndTestProfile(prof, (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.True(context.IsEqual(profile.DefaultContext));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertProfileNullComponent()
        {
            var context = GetDefaultContext();
            context.Subscription = null;
            var prof = new PSAzureProfile();
            prof.Context = new PSAzureContext(context);
            ConvertAndTestProfile(prof, (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.True(context.IsEqual(profile.DefaultContext));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertProfieWithCustomEnvironment()
        {
            IAzureContext context = new AzureContext(new AzureSubscription(), new AzureAccount(), new AzureEnvironment(), new AzureTenant(), new byte[0]);
            var testContext = new PSAzureContext(context);
            var testEnvironment = new PSAzureEnvironment(AzureEnvironment.PublicEnvironments["AzureCloud"]);
            testEnvironment.Name = "ExtraEnvironment";
            var testProfile = new PSAzureProfile();
            testProfile.Context = testContext;
            testProfile.Environments.Add("ExtraEnvironment", testEnvironment);
            ConvertAndTestProfile(testProfile, (profile) =>
            {
                Assert.NotEmpty(profile.EnvironmentTable);
                Assert.True(profile.EnvironmentTable.ContainsKey("ExtraEnvironment"));
                Assert.NotEmpty(profile.Contexts);
                Assert.NotNull(profile.DefaultContext);
                Assert.NotEmpty(profile.DefaultContextKey);
                Assert.Equal("Default", profile.DefaultContextKey);
                Assert.Collection(profile.Environments.OrderBy(e=>e.Name),
                    (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureChinaCloud]),
                    (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud]),
                    (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureGermanCloud]),
                    (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureUSGovernment]),
                    (e) => Assert.Equal(e, testEnvironment));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConConvertEmptyProfile()
        {
            ConvertAndTestProfile(new PSAzureProfile(), (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.Null(profile.DefaultContext);
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertFullContext()
        {
            var context = GetDefaultContext();
            ConvertAndTestProfile(context, (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.True(context.IsEqual(profile.DefaultContext));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertContextNullComponent()
        {
            var context = GetDefaultContext();
            context.Subscription = null;
            ConvertAndTestProfile(context, (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.True(context.IsEqual(profile.DefaultContext));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertMinimalContext()
        {
            IAzureContext context = new AzureContext(new AzureSubscription(), new AzureAccount(), new AzureEnvironment(), new AzureTenant(), new byte[0]);
            ConvertAndTestProfile(new PSAzureContext(context), (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.NotNull(profile.DefaultContext);
                Assert.Equal("Default", profile.DefaultContextKey);
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertEmptyContext()
        {
            ConvertAndTestProfile(new PSAzureContext(), (profile) =>
            {
                AssertStandardEnvironments(profile);
                Assert.NotNull(profile.DefaultContext);
            });
        }

        void ConvertAndTestProfile<T>(T objectToConvert, Action<AzureRmProfile> validator)
        {
            var converted = DoPSPassThroughConversion(objectToConvert);
            Assert.True(converted is IAzureContextContainer);
            AzureRmProfile convertedProfile = converted as AzureRmProfile;
            Assert.NotNull(convertedProfile);
            Assert.NotEmpty(convertedProfile.Environments);
            Assert.NotEmpty(convertedProfile.Contexts);
            Assert.NotEmpty(convertedProfile.DefaultContextKey);
            validator(convertedProfile);
        }

        object DoPSPassThroughConversion<T>(T objectToConvert)
        {
            string content = PSSerializer.Serialize(objectToConvert, 10);
            var reconstituted = PSSerializer.Deserialize(content);
            var converter = new AzureContextConverter();
            Assert.True(converter.CanConvertFrom(reconstituted, typeof(IAzureContextContainer)));
            return converter.ConvertFrom(reconstituted, typeof(IAzureContextContainer), CultureInfo.InvariantCulture, true);
        }

        void AssertStandardEnvironments(AzureRmProfile profile)
        {
            Assert.Collection(profile.Environments.OrderBy(e => e.Name),
                (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureChinaCloud]),
                (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud]),
                (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureGermanCloud]),
                (e) => Assert.Equal(e, AzureEnvironment.PublicEnvironments[EnvironmentName.AzureUSGovernment]));
        }

        IAzureAccount GetDefaultAccount()
        {
            var account = new AzureAccount
            {
                Credential = Guid.NewGuid().ToString(),
                Id = "importantuser@contoso.org",
                Type = AzureAccount.AccountType.User,
            };

            account.TenantMap.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            account.SetSubscriptions(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            return account;
        }

        IAzureSubscription GetDefaultSubscription()
        {
            var sub = new AzureSubscription
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Contoso Subscription 1",
                State = "Ready"
            };

            sub.SetTenant(Guid.NewGuid().ToString());
            sub.SetEnvironment("CustomGermanCloud");
            sub.SetStorageAccount("contosostorage");
            return sub;
        }

        IAzureTenant GetDefaultTenant()
        {
            var tenant = new AzureTenant
            {
                Id = Guid.NewGuid().ToString(),
                Directory = "Contoso.OnMicrosoft.com"
            };

            tenant.SetProperty("Correlation", "None");
            return tenant;
        }

        IAzureEnvironment GetDefaultEnvironment()
        {
            var env = new AzureEnvironment(AzureEnvironment.PublicEnvironments[EnvironmentName.AzureGermanCloud]);
            env.Name = "CustomEnvironment1";
            env.SetProperty("FirstProperty", "FirstValue1", "FirstValue2");
            env.SetProperty("SecondProperty", "SecondValue");
            return env;
        }

        IAzureTokenCache GetDefaultTokenCache()
        {
            var cache = new AzureTokenCache
            {
                CacheData = new byte[] { 2, 0, 0, 0, 0, 0, 0, 0 }
            };

            return cache;
        }

        IAzureContext GetDefaultContext()
        {
            var context = new AzureContext
            {
                Account = GetDefaultAccount(),
                Environment = GetDefaultEnvironment(),
                Subscription = GetDefaultSubscription(),
                Tenant = GetDefaultTenant(),
                TokenCache = GetDefaultTokenCache(),
                VersionProfile = "2017_09_25"
            };

            context.SetProperty("ContextProeprty1", "ContextProperty1Value1", "ContextProperty1Value2");
            context.SetProperty("ContextProeprty2", "ContextProperty2Value1", "ContextProperty2Value2");

            return context;
        }

    }
}
