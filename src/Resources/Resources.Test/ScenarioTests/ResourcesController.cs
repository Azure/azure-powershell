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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ResourcesController
    {
        private readonly EnvironmentSetupHelper _helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";

        public GraphRbacManagementClient GraphClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public FeatureClient FeatureClient { get; private set; }

        public Internal.Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public ManagementGroupsAPIClient ManagementGroupsApiClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ResourcesController NewInstance => new ResourcesController();

        public ResourcesController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(XunitTracingInterceptor interceptor, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                interceptor,
                () => scripts,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            XunitTracingInterceptor interceptor,
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            _helper.TracingInterceptor = interceptor;
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Providers.Test", null}
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2016-07-01"},
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new ResourcesRecordMatcher(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                SetupManagementClients(context);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.RMProfileModule,
                    _helper.RMResourceModule,
                    _helper.GetRMModulePath("AzureRM.Monitor.psd1"));

                try
                {
                    var psScripts = scriptBuilder?.Invoke();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            SubscriptionClient = GetSubscriptionClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);
            GraphClient = GetGraphClient(context);
            ManagementGroupsApiClient = GetManagementGroupsApiClient(context);
            FeatureClient = GetFeatureClient(context);
            var testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            var credentials = testEnvironment.TokenInfo[TokenAudience.Management];
            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(credentials);

            _helper.SetupManagementClients(ResourceManagementClient,
                SubscriptionClient,
                AuthorizationManagementClient,
                GraphClient,
                FeatureClient,
                ManagementGroupsApiClient);
        }

        private GraphRbacManagementClient GetGraphClient(MockContext context)
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.Tenant;
                UserDomain = String.IsNullOrEmpty(environment.UserName) ? String.Empty : environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

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
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = HttpMockServer.Variables[SubscriptionIdKey];
                }
            }

            var client = context.GetGraphServiceClient<GraphRbacManagementClient>(environment);
            client.TenantID = tenantId;
            if (AzureRmProfileProvider.Instance != null &&
                AzureRmProfileProvider.Instance.Profile != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant != null)
            {
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = client.TenantID;
            }
            return client;
        }

        private static AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static FeatureClient GetFeatureClient(MockContext context)
        {
            return context.GetServiceClient<FeatureClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static Internal.Subscriptions.SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<Internal.Subscriptions.SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ManagementGroupsAPIClient GetManagementGroupsApiClient(MockContext context)
        {
            return context.GetServiceClient<ManagementGroupsAPIClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        /// <summary>
        /// The test http client helper factory.
        /// </summary>
        private class TestHttpClientHelperFactory : HttpClientHelperFactory
        {
            /// <summary>
            /// The service client credentials.
            /// </summary>
            private readonly ServiceClientCredentials _credential;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestHttpClientHelperFactory"/> class.
            /// </summary>
            /// <param name="credentials"></param>
            public TestHttpClientHelperFactory(ServiceClientCredentials credentials)
            {
                _credential = credentials;
            }

            /// <summary>
            /// Creates new instances of the <see cref="HttpClientHelper"/> class.
            /// </summary>
            /// <param name="credentials">The credentials.</param>
            /// <param name="headerValues">The headers.</param>
            public override HttpClientHelper CreateHttpClientHelper(ServiceClientCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
            {
                return new HttpClientHelperImpl(credentials: _credential, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues);
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
                public HttpClientHelperImpl(ServiceClientCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
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

        //https://gist.github.com/markcowl/4d907da7ce40f2e424e8d0625887b82e
        public class SubscriptionCloudCredentialsAdapter : SubscriptionCloudCredentials
        {
            private readonly ServiceClientCredentials _wrappedCreds;

            public SubscriptionCloudCredentialsAdapter(ServiceClientCredentials credentials, string subscriptionId)
            {
                _wrappedCreds = credentials;
                SubscriptionId = subscriptionId;
            }

            public override string SubscriptionId { get; }

            public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return _wrappedCreds.ProcessHttpRequestAsync(request, cancellationToken);
            }
        }
    }
}
