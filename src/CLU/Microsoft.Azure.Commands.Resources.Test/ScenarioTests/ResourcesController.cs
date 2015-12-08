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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public sealed class ResourcesController
    {
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";

        public GraphRbacManagementClient GraphClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public FeatureClient FeatureClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }
        
        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

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

        public void RunPsTest(string callingClass, string currentMethodName, params string[] scripts)
        {
            RunPsTestWorkflow(
                () => scripts, 
                // no custom initializer
                null, 
                // no custom cleanup 
                null,
                callingClass,
                currentMethodName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder, 
            Action<TestEnvironment> initialize, 
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                if(initialize != null)
                {
                    initialize(TestEnvironmentFactory.GetTestEnvironment());
                }

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager, 
                    "ScenarioTests\\Common.ps1", 
                    "ScenarioTests\\" + callingClassName + ".ps1", 
                    helper.RMProfileModule, 
                    helper.RMResourceModule);

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

        public static string GetDomain(string emailString)
        {
            string result = null;
            if (emailString != null && emailString.Contains('@'))
            {
                result = emailString.Split(
                    new[] { '@' },
                    StringSplitOptions.RemoveEmptyEntries).Last();
            }

            return result;
        }

        private void SetupManagementClients()
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.Tenant;
                UserDomain = GetDomain(tenantId);

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
                    helper.TestProfile.Context.Subscription.Id = new Guid(HttpMockServer.Variables[SubscriptionIdKey]);
                }
            }

            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(TestEnvironmentFactory.GetTestEnvironment().Credentials as ServiceClientCredentials);

        }

        /// <summary>
        /// The test http client helper factory.
        /// </summary>
        private class TestHttpClientHelperFactory : HttpClientHelperFactory
        {
            /// <summary>
            /// The subscription cloud credentials.
            /// </summary>
            private readonly ServiceClientCredentials credential;

            /// <summary>
            /// Initializes a new instance of the <see cref="TestHttpClientHelperFactory"/> class.
            /// </summary>
            /// <param name="credentials"></param>
            public TestHttpClientHelperFactory(ServiceClientCredentials credentials)
            {
                this.credential = credentials;
            }

            /// <summary>
            /// Creates new instances of the <see cref="HttpClientHelper"/> class.
            /// </summary>
            /// <param name="credentials">The credentials.</param>
            /// <param name="headerValues">The headers.</param>
            public override HttpClientHelper CreateHttpClientHelper(ServiceClientCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
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
    }
}
