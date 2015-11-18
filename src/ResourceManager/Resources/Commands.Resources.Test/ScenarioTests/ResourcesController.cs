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
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ResourcesController
    {
        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";

        public GraphRbacManagementClient GraphClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public FeatureClient FeatureClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }
        
        public InsightsClient InsightsClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public KeyVaultManagementClient KeyVaultManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ResourcesController NewInstance 
        { 
            get
            {
                return new ResourcesController();
            }
        }

        public ResourcesController()
        {
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts, 
                // no custom initializer
                null, 
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder, 
            Action<CSMTestEnvironmentFactory> initialize, 
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if(initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                SetupAzureContext();
                SetupManagementClients();
             
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager, 
                    "ScenarioTests\\Common.ps1", 
                    "ScenarioTests\\" + callingClassName + ".ps1", 
                    helper.RMProfileModule, 
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.KeyVault.psd1"));

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if(cleanup !=null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients()
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            GalleryClient = GetGalleryClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GraphClient = GetGraphClient();
            InsightsClient = GetInsightsClient();
            this.FeatureClient = this.GetFeatureClient();
            KeyVaultManagementClient = GetKeyVaultManagementClient();
            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(this.csmTestFactory.GetTestEnvironment().Credentials as SubscriptionCloudCredentials);

            helper.SetupManagementClients(ResourceManagementClient,
                SubscriptionClient,
                GalleryClient,
                AuthorizationManagementClient,
                GraphClient,
                InsightsClient,
                this.FeatureClient,
                KeyVaultManagementClient);
        }

        private GraphRbacManagementClient GetGraphClient()
        {
            var environment = this.csmTestFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.AuthorizationContext.TenantId;
                UserDomain = environment.AuthorizationContext.UserDomain;

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = UserDomain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                }
                if (HttpMockServer.Variables.ContainsKey(SubscriptionIdKey))
                {
                    AzureRmProfileProvider.Instance.Profile.Context.Subscription.Id = new Guid(HttpMockServer.Variables[SubscriptionIdKey]);
                }
            }

            return TestBase.GetGraphServiceClient<GraphRbacManagementClient>(this.csmTestFactory, tenantId);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private FeatureClient GetFeatureClient()
        {
            return TestBase.GetServiceClient<FeatureClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private InsightsClient GetInsightsClient()
        {
            return TestBase.GetServiceClient<InsightsClient>(this.csmTestFactory);
        }

        private KeyVaultManagementClient GetKeyVaultManagementClient()
        {
            return TestBase.GetServiceClient<KeyVaultManagementClient>(this.csmTestFactory);
        }

        private void SetupAzureContext()
        {
            TestEnvironment csmEnvironment = new CSMTestEnvironmentFactory().GetTestEnvironment();

            if (csmEnvironment.SubscriptionId != null)
            {
                //Overwrite the default subscription and default account
                //with ones using user ID and tenant ID from auth context
                var user = GetUser(csmEnvironment);
                var tenantId = GetTenantId(csmEnvironment);

                var testSubscription = new AzureSubscription()
                {
                    Id = new Guid(csmEnvironment.SubscriptionId),
                    Name = AzureRmProfileProvider.Instance.Profile.Context.Subscription.Name,
                    Environment = AzureRmProfileProvider.Instance.Profile.Context.Environment.Name,
                    Account = user,
                    Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        {AzureSubscription.Property.Default, "True"},
                        {
                            AzureSubscription.Property.StorageAccount,
                            Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT")
                        },
                        {AzureSubscription.Property.Tenants, tenantId},
                    }
                };

                var testAccount = new AzureAccount()
                {
                    Id = user,
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        {AzureAccount.Property.Subscriptions, csmEnvironment.SubscriptionId},
                        {AzureAccount.Property.Tenants, tenantId},
                    }
                };

                AzureRmProfileProvider.Instance.Profile.Context = new AzureContext(testSubscription, testAccount, AzureRmProfileProvider.Instance.Profile.Context.Environment, new AzureTenant { Id = new Guid(tenantId) });
            }

        }

        private string GetTenantId(TestEnvironment environment)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["TenantId"] = environment.AuthorizationContext.TenantId;
                return environment.AuthorizationContext.TenantId;
            }
            else
            {
                return HttpMockServer.Variables["TenantId"];
            }
        }

        private string GetUser(TestEnvironment environment)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables["User"] = environment.AuthorizationContext.UserId;
                return environment.AuthorizationContext.UserId;
            }
            else
            {
                return HttpMockServer.Variables["User"];
            }
        }

        /// <summary>
        /// The test http client helper factory.
        /// </summary>
        private class TestHttpClientHelperFactory : HttpClientHelperFactory
        {
            /// <summary>
            /// The subscription cloud credentials.
            /// </summary>
            private readonly SubscriptionCloudCredentials credential;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestHttpClientHelperFactory"/> class.
            /// </summary>
            /// <param name="credentials"></param>
            public TestHttpClientHelperFactory(SubscriptionCloudCredentials credentials)
            {
                this.credential = credentials;
            }

            /// <summary>
            /// Creates new instances of the <see cref="HttpClientHelper"/> class.
            /// </summary>
            /// <param name="credentials">The credentials.</param>
            /// <param name="headerValues">The headers.</param>
            public override HttpClientHelper CreateHttpClientHelper(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
            {
                return new HttpClientHelperImpl(credentials: this.credential, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues);
            }

            /// <summary>
            /// An implementation of the <see cref="HttpClientHelper"/> abstract class.
            /// </summary>
            private class HttpClientHelperImpl : HttpClientHelper
            {
                /// <summary>
                /// Initializes new instances of the <see cref="HttpClientHelperImpl"/> class.
                /// </summary>
                /// <param name="credentials">The credentials.</param>
                /// <param name="headerValues">The headers.</param>
                public HttpClientHelperImpl(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
                    : base(credentials: credentials, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues)
                {
                }

                /// <summary>
                /// Creates an <see cref="HttpClient"/>
                /// </summary>
                /// <param name="primaryHandlers">The handlers that will be added to the top of the chain.</param>
                public override HttpClient CreateHttpClient(params DelegatingHandler[] primaryHandlers)
                {
                    return base.CreateHttpClient(HttpMockServer.CreateInstance().AsArray().Concat(primaryHandlers).ToArray());
                }
            }
        }
    }
}
