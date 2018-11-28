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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Diagnostics;
using System;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using System.Linq;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LoginCmdletTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public LoginCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetPsVersionFromUserAgent()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();

            int preProcessingUserAgentCount = AzureSession.Instance.ClientFactory.UserAgents.Length;
            Debug.WriteLine("UserAgents count prior to cmdLet processing = {0}", preProcessingUserAgentCount.ToString());
            foreach (ProductInfoHeaderValue hv in AzureSession.Instance.ClientFactory.UserAgents)
            {
                Debug.WriteLine("Product:{0} - Version:{1}", hv.Product.Name, hv.Product.Version);
            }

            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Subscription = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            cmdlt.InvokeBeginProcessing();
            int postProcessingUserAgentCount = AzureSession.Instance.ClientFactory.UserAgents.Length;
            Debug.WriteLine("UserAgents count prior to cmdLet post processing = {0}", postProcessingUserAgentCount.ToString());
            Assert.True(AzureSession.Instance.ClientFactory.UserAgents.Length >= preProcessingUserAgentCount);
            IEnumerable<ProductInfoHeaderValue> piHv = AzureSession.Instance.ClientFactory.UserAgents;
            string psUserAgentString = string.Empty;

            foreach(ProductInfoHeaderValue hv in piHv)
            {
                if(hv.Product.Name.Equals("PSVersion") && (!string.IsNullOrEmpty(hv.Product.Version)))
                {
                    psUserAgentString = string.Format("{0}-{1}", hv.Product.Name, hv.Product.Version);
                }
            }

            Assert.NotEmpty(psUserAgentString);
            Assert.Contains("PSVersion", psUserAgentString);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndTenant()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Subscription = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithInvalidSubscriptionAndTenantThrowsCloudException()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Subscription = "2c224e7e-3ef5-431d-a57b-e71f4662e3a5";
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSInvalidOperationException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndNoTenant()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Subscription = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndTenant()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndTenantDomain()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "microsoft.onmicrosoft.com";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionname()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.Subscription = "Node CLI Test";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("microsoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithRbacTenantOnly()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            // NOTE: Use owner1@AzureSDKTeam.onmicrosoft.com credentials for this test case
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Tenant = "1449d5b7-8a83-47db-ae4c-9b03e888bad0";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal("AzureSDKTeam.onmicrosoft.com", AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Directory);
            Assert.Equal(cmdlt.Tenant, AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id.ToString());
            Assert.Null(AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithRbacSPNAndCertificateOnly()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            // NOTE: Use rbac SPN credentials for this test case
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.ServicePrincipal = true;
            cmdlt.Tenant = "54826b22-38d6-4fb2-bad9-b7b93a3e9c5a";
            cmdlt.ApplicationId = "99edf981-74c0-4284-bddf-3e9d092ba4e2";
            cmdlt.CertificateThumbprint = "F064B7C7EACC942D10662A5115E047E94FA18498";
            cmdlt.SetParameterSet("ServicePrincipalCertificateWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal(cmdlt.Tenant, AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id.ToString());
            Assert.Equal(cmdlt.ApplicationId, AzureRmProfileProvider.Instance.Profile.DefaultContext.Account.Id.ToString());
            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription);
            Assert.Equal(
                cmdlt.CertificateThumbprint,
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Account.GetProperty(AzureAccount.Property.CertificateThumbprint));

        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetMultipleTenantsOnLogin()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            // NOTE: Use account that has at exactly two tenants
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext.Account);
            var tenants = AzureRmProfileProvider.Instance.Profile.DefaultContext.Account.GetTenants();
            Assert.NotNull(tenants);
            Assert.Equal(2, tenants.Length);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithEnvironementName()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Environment = "AzureUSGovernment";
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment);
            Assert.Equal("AzureUSGovernment", AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment.Name);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithCredentialParameterAndMSA()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Example of environment variable: TEST_AZURE_CREDENTIALS=<subscription-id-value>;<email@domain.com>;<email-password>"
            string credsEnvironmentVariable = Environment.GetEnvironmentVariable("TEST_AZURE_CREDENTIALS");
            string[] creds = credsEnvironmentVariable.Split(';');

            string userName = creds[1];
            string password = creds[2];

            var securePassword = new SecureString();
            Array.ForEach(password.ToCharArray(), securePassword.AppendChar);

            cmdlt.Credential = new PSCredential(userName, securePassword);
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            try
            {
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();
            }
            catch (AadAuthenticationFailedException ex)
            {
                Assert.NotNull(ex);
                Assert.Equal("-Credential parameter can only be used with Organization ID credentials. " +
                             "For more information, please refer to http://go.microsoft.com/fwlink/?linkid=331007&clcid=0x409 " +
                             "for more information about the difference between an organizational account and a Microsoft account.",
                             ex.Message);
            }
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithAccessToken()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Obtain an access token by using [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.TokenCache.ReadItems() in powershell after logging in.
            // Ensure you are using the token with Resource: https://management.core.windows.net/
            string accessTokenEnvironmentVariable = Environment.GetEnvironmentVariable("AZURE_TEST_ACCESS_TOKEN");

            cmdlt.AccessToken = accessTokenEnvironmentVariable;
            cmdlt.AccountId = "testAccount";
            cmdlt.SetParameterSet("AccessTokenWithSubscriptionId");

            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginPopulatesContextList()
        {
            // Before running this test, make sure to clear the contexts on your machine by removing the following two files:
            // - %APPDATA%/Windows Azure Powershell/AzureRmContext.json
            // - %APPDATA%/Windows Azure Powershell/AzureRmContextSettings.json
            // This will clear all existing contexts on your machine so that this test can re-populate the list with a context for each subscription

            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            var profile = AzureRmProfileProvider.Instance.Profile as AzureRmProfile;
            Assert.NotNull(profile);
            Assert.NotNull(profile.Contexts);
            Assert.NotNull(profile.Subscriptions);
            Assert.True(profile.Contexts.Count > 1);
            Assert.True(profile.Subscriptions.Count() > 1);
            Assert.Equal(profile.Subscriptions.Count(), profile.Contexts.Count);

            foreach (var sub in profile.Subscriptions)
            {
                var contextName = string.Format("{0} - {1}", sub.Name, sub.Id);
                Assert.True(profile.Contexts.ContainsKey(contextName));
                var context = profile.Contexts[contextName];
                Assert.NotNull(context);
                Assert.Equal(sub.Id, context.Subscription.Id);
                Assert.Equal(sub.GetTenant(), context.Tenant.Id);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowOnUnknownEnvironment()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.Environment = "unknown";
            var testPassed = false;
            cmdlt.SetBoundParameters(new Dictionary<string, object>() { { "Environment", "unknown" } });
            cmdlt.SetParameterSet("UserWithSubscriptionId");

            // Act
            try
            {
                cmdlt.InvokeBeginProcessing();
            }
            catch (TargetInvocationException ex)
            {
                Assert.NotNull(ex);
                Assert.NotNull(ex.InnerException);
                Assert.Equal("Unable to find environment with name 'unknown'", ex.InnerException.Message);
                testPassed = true;
            }

            Assert.True(testPassed);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginUsingSkipValidation()
        {
            var cmdlt = new ConnectAzureRmAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            cmdlt.AccessToken = "test";
            cmdlt.AccessToken = "test@microsoft.com";
            cmdlt.SkipValidation = true;
            cmdlt.Tenant = Guid.NewGuid().ToString();
            cmdlt.Subscription = Guid.NewGuid().ToString();
            cmdlt.SetBoundParameters(new Dictionary<string, object>() { { "Subscription", cmdlt.Subscription } });
            cmdlt.SetParameterSet("AccessTokenWithSubscriptionId");

            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal(AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id, cmdlt.Subscription);
            Assert.Equal(AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id, cmdlt.Tenant);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void AddEnvironmentUpdatesContext()
        {
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock,
                Name = "Katal",
                ARMEndpoint = "https://management.azure.com/",
                AzureKeyVaultDnsSuffix = "vault.local.azurestack.external",
                AzureKeyVaultServiceEndpointResourceId = "https://vault.local.azurestack.external"

            };
            var dict = new Dictionary<string, object>
            {
                { "ARMEndpoint", "https://management.azure.com/" },
                { "AzureKeyVaultDnsSuffix", "vault.local.azurestack.external" },
                { "AzureKeyVaultServiceEndpointResourceId", "https://vault.local.azurestack.external" }
            };

            cmdlet.SetBoundParameters(dict);
            cmdlet.SetParameterSet("ARMEndpoint");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock = new MockCommandRuntime();
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            IAzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments.First((e) => string.Equals(e.Name, "KaTaL", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix), dict["AzureKeyVaultDnsSuffix"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId), dict["AzureKeyVaultServiceEndpointResourceId"]);

            var cmdlet1 = new ConnectAzureRmAccountCommand();
            cmdlet1.CommandRuntime = commandRuntimeMock;
            cmdlet1.Environment = "Katal";

            dict.Clear();
            dict = new Dictionary<string, object>
            {
                { "Environment", cmdlet1.Environment }
            };

            cmdlet1.SetBoundParameters(dict);
            cmdlet1.InvokeBeginProcessing();
            cmdlet1.ExecuteCmdlet();
            cmdlet1.InvokeEndProcessing();
            commandRuntimeMock = new MockCommandRuntime();

            Assert.NotNull(AzureRmProfileProvider.Instance.Profile.DefaultContext);
            Assert.Equal(AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment.Name, cmdlet1.Environment);

            var cmdlet2 = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock,
                Name = "Katal",
                ARMEndpoint = "https://management.azure.com/",
                AzureKeyVaultDnsSuffix = "adminvault.local.azurestack.external",
                AzureKeyVaultServiceEndpointResourceId = "https://adminvault.local.azurestack.external"
            };

            dict.Clear();
            dict = new Dictionary<string, object>
            {
                { "ARMEndpoint", "https://management.azure.com/" },
                { "AzureKeyVaultDnsSuffix", "adminvault.local.azurestack.external" },
                { "AzureKeyVaultServiceEndpointResourceId", "https://adminvault.local.azurestack.external" }
            };

            cmdlet2.SetBoundParameters(dict);
            cmdlet2.SetParameterSet("ARMEndpoint");
            cmdlet2.InvokeBeginProcessing();
            cmdlet2.ExecuteCmdlet();
            cmdlet2.InvokeEndProcessing();

            profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>());
            env = AzureRmProfileProvider.Instance.Profile.Environments.First((e) => string.Equals(e.Name, "KaTaL", StringComparison.OrdinalIgnoreCase));
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix), dict["AzureKeyVaultDnsSuffix"]);
            Assert.Equal(env.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId), dict["AzureKeyVaultServiceEndpointResourceId"]);

            var context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            Assert.NotNull(context);
            Assert.NotNull(context.Environment);
            Assert.Equal(context.Environment.Name, env.Name);
            Assert.Equal(context.Environment.AzureKeyVaultDnsSuffix, env.AzureKeyVaultDnsSuffix);
            Assert.Equal(context.Environment.AzureKeyVaultServiceEndpointResourceId, env.AzureKeyVaultServiceEndpointResourceId);
        }
    }
}
