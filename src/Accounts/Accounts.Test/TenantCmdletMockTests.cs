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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class TenantCmdletMockTests
    {
        private GetAzureRMTenantCommandMock cmdlet;
        private Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
        private Mock<ISubscriptionClientWrapper> mockSubscriptionClient = new Mock<ISubscriptionClientWrapper>();
        private List<object> OutputPipeline = new List<object>();
        private AzureContext defaultContext;

        public class GetAzureRMTenantCommandMock : GetAzureRMTenantCommand
        {
            public RMProfileClient profileClient = null;

            public override void ExecuteCmdlet()
            {
                WriteObject(profileClient.ListTenants(TenantId).Select((t) => new PSAzureTenant(t)), enumerateCollection: true);
            }
        }

        public TenantCmdletMockTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            if (!AzureSession.Instance.TryGetComponent(nameof(AuthenticationTelemetry), out AuthenticationTelemetry authenticationTelemetry))
            {
                AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(nameof(AuthenticationTelemetry), () => new AuthenticationTelemetry());
            }
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            ((MockTokenAuthenticationFactory)AzureSession.Instance.AuthenticationFactory).TokenProvider = (account, environment, tenant) =>
            new MockAccessToken
            {
                UserId = "aaa@contoso.com",
                LoginType = LoginType.OrgId,
                AccessToken = "bbb",
                TenantId = tenant
            };

            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>())).Callback(
                (Object o, bool enumerateCollection) =>
                {
                    if (enumerateCollection)
                    {
                        IEnumerable<object> objects = o as IEnumerable<object>;
                        objects?.ForEach(e => OutputPipeline.Add(e));
                    }
                    else
                    {
                        OutputPipeline.Add(o);
                    }
                });

            cmdlet = new GetAzureRMTenantCommandMock()
            {
                CommandRuntime = commandRuntimeMock.Object,
            };

            var sub = new AzureSubscription()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test subscription"
            };
            defaultContext = new AzureContext(sub,
                new AzureAccount() { Id = "admin@contoso.com", Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant() { Id = Guid.NewGuid().ToString() });
            var profile = new AzureRmProfile();
            profile.DefaultContext = defaultContext;
            cmdlet.profileClient = new RMProfileClient(profile);
            cmdlet.profileClient.SubscriptionAndTenantClient = mockSubscriptionClient.Object;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTenantWithTenantParameter()
        {
            // Setup
            cmdlet.TenantId = Guid.NewGuid().ToString();
            mockSubscriptionClient.Setup(f => f.ListAccountTenants(It.IsAny<IAccessToken>(), It.IsAny<IAzureEnvironment>())).Returns(
                (IAccessToken accessToken, IAzureEnvironment environment) =>
                {
                    var result = new List<AzureTenant>();
                    result.Add(new AzureTenant()
                    {
                        Id = cmdlet.TenantId,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Microsoft" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test0.com,test1.com,test2.microsoft.com,test3.microsoft.com" },
                            { "TenantType", "AAD"},
                            { "DefaultDomain", "test0.com,test1.com" }
                        }
                    });
                    result.Add(new AzureTenant()
                    {
                        Id = defaultContext.Tenant.Id,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Macrohard" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test.macrohard.com" }
                        }
                    });
                    return result;
                });

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            //Verify
            Assert.Single(OutputPipeline);
            Assert.Equal(cmdlet.TenantId, ((PSAzureTenant)OutputPipeline.First()).Id.ToString());
            Assert.Equal("Home", ((PSAzureTenant)OutputPipeline.First()).TenantCategory);
            Assert.Equal(4, ((PSAzureTenant)OutputPipeline.First()).Domains.Length);
            Assert.Equal("AAD", ((PSAzureTenant)OutputPipeline.First()).TenantType);
            Assert.Equal("test0.com,test1.com", ((PSAzureTenant)OutputPipeline.First()).DefaultDomain);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTenantWithDomainParameter()
        {
            // Setup
            var tenantId = Guid.NewGuid().ToString();
            cmdlet.TenantId = "test3.microsoft.com";
            mockSubscriptionClient.Setup(f => f.ListAccountTenants(It.IsAny<IAccessToken>(), It.IsAny<IAzureEnvironment>())).Returns(
                (IAccessToken accessToken, IAzureEnvironment environment) =>
                {
                    var result = new List<AzureTenant>();
                    result.Add(new AzureTenant()
                    {
                        Id = tenantId,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Microsoft" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test0.com,test1.com,test2.microsoft.com," + cmdlet.TenantId },
                            { "TenantBrandingLogoUrl", "https://secure.fakesite.com/xxxxx-yyyy/logintenantbranding/0/bannerlogo?ts=0000000000" }
                        }
                    });
                    result.Add(new AzureTenant()
                    {
                        Id = defaultContext.Tenant.Id,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Macrohard" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test.macrohard.com" }
                        }
                    });
                    return result;
                });

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            //Verify
            Assert.Single(OutputPipeline);
            Assert.Equal(tenantId, ((PSAzureTenant)OutputPipeline.First()).Id.ToString());
            Assert.Equal("Home", ((PSAzureTenant)OutputPipeline.First()).TenantCategory);
            var domains = ((PSAzureTenant)OutputPipeline.First()).Domains;
            Assert.Equal(4, domains.Length);
            Assert.True(Array.Exists(domains, t => t.Equals(cmdlet.TenantId, StringComparison.OrdinalIgnoreCase)));
            Assert.Equal("https://secure.fakesite.com/xxxxx-yyyy/logintenantbranding/0/bannerlogo?ts=0000000000", ((PSAzureTenant)OutputPipeline.First()).TenantBrandingLogoUrl);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetTenantWithoutParameters()
        {
            // Setup
            var tenantId = Guid.NewGuid().ToString();
            mockSubscriptionClient.Setup(f => f.ListAccountTenants(It.IsAny<IAccessToken>(), It.IsAny<IAzureEnvironment>())).Returns(
                (IAccessToken accessToken, IAzureEnvironment environment) =>
                {
                    var result = new List<AzureTenant>();
                    result.Add(new AzureTenant()
                    {
                        Id = tenantId,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Microsoft" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test0.com,test1.com,test2.microsoft.com,test3.microsoft.com" }
                        }
                    });
                    result.Add(new AzureTenant()
                    {
                        Id = defaultContext.Tenant.Id,
                        ExtendedProperties =
                        {
                            { "DisplayName", "Macrohard" },
                            { "TenantCategory", "Home" },
                            { "Domains", "test.macrohard.com" },
                            { "CountryCode", "US" }
                        }
                    });
                    return result;
                });

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            //Verify
            Assert.Equal(2, OutputPipeline.Count);
            var tenantA = (PSAzureTenant)OutputPipeline.Where(tenant => ((PSAzureTenant)tenant).Name.Equals("Microsoft"))?.FirstOrDefault();
            var tenantB = (PSAzureTenant)OutputPipeline.Where(tenant => ((PSAzureTenant)tenant).Name.Equals("Macrohard"))?.FirstOrDefault();

            Assert.Equal(tenantId, tenantA.Id.ToString());
            Assert.Equal("Home", tenantA.TenantCategory);
            Assert.Equal(4, tenantA.Domains.Length);

            Assert.Equal(defaultContext.Tenant.Id, tenantB.Id.ToString());
            Assert.Equal("Home", tenantB.TenantCategory);
            Assert.Single(tenantB.Domains);
            Assert.Equal("US", tenantB.CountryCode);
        }
    }
}
