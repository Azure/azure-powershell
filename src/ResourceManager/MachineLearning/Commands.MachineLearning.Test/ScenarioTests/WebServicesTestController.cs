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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.MachineLearning.WebServices;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Subscriptions;
using LegacyTest = Microsoft.Azure.Test;
using Microsoft.Azure.Test.Authentication;

namespace Microsoft.Azure.Commands.MachineLearning.Test.ScenarioTests
{
    public class WebServicesTestController
    {
        private readonly EnvironmentSetupHelper helper;
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;

        protected WebServicesTestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }
        
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public AzureMLWebServicesManagementClient WebServicesManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public static WebServicesTestController NewInstance
        {
            get
            {
                return new WebServicesTestController();
            }
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);
            this.helper.TracingInterceptor = logger;

            this.RunPsTestWorkflow(
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
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var providers = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null }
            };
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (var context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();
                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                this.SetupManagementClients(context);
                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                      .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                      .Last();

                helper.SetupModules(AzureModule.AzureResourceManager,
                   "ScenarioTests\\Common.ps1",
                   "ScenarioTests\\" + callingClassName + ".ps1",
                   helper.RMProfileModule,
                   helper.RMResourceModule,
                   helper.GetRMModulePath(@"AzureRM.MachineLearning.psd1"),
                   "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

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
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            this.ResourceManagementClient = 
                    LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
            this.WebServicesManagementClient = 
                    context.GetServiceClient<AzureMLWebServicesManagementClient>(
                                                            TestEnvironmentFactory.GetTestEnvironment());
            this.StorageManagementClient = LegacyTest.TestBase.GetServiceClient<StorageManagementClient>(this.csmTestFactory);

            var subscriptionClient = LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
            var authManagementClient = LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
            var gallleryClient = LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);

            var testEnvironment = this.csmTestFactory.GetTestEnvironment();
            var credentials = new SubscriptionCredentialsAdapter(
                testEnvironment.AuthorizationContext.TokenCredentials[Microsoft.Azure.Test.TokenAudience.Management],
                testEnvironment.SubscriptionId);
            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(
                    credentials);
            helper.SetupManagementClients(this.ResourceManagementClient, 
                subscriptionClient, 
                this.WebServicesManagementClient, 
                authManagementClient, 
                gallleryClient,
                this.StorageManagementClient);
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
            public override HttpClientHelper CreateHttpClientHelper(
                                                SubscriptionCloudCredentials credentials, 
                                                IEnumerable<ProductInfoHeaderValue> headerValues, 
                                                Dictionary<string, string> cmdletHeaderValues)
            {
                return new HttpClientHelperImpl(
                                credentials: this.credential, 
                                headerValues: headerValues, 
                                cmdletHeaderValues: cmdletHeaderValues);
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
                public HttpClientHelperImpl(
                            SubscriptionCloudCredentials credentials, 
                            IEnumerable<ProductInfoHeaderValue> headerValues, 
                            Dictionary<string, string> cmdletHeaderValues)
                    : base(
                        credentials: credentials, 
                        headerValues: headerValues, 
                        cmdletHeaderValues: cmdletHeaderValues)
                {
                }

                /// <summary>
                /// Creates an <see cref="HttpClient"/>
                /// </summary>
                /// <param name="primaryHandlers">The handlers that will be added to the top of the chain.</param>
                public override HttpClient CreateHttpClient(params DelegatingHandler[] primaryHandlers)
                {
                    return base.CreateHttpClient(HttpMockServer.CreateInstance()
                                .AsArray()
                                .Concat(primaryHandlers)
                                .ToArray());
                }
            }
        }
    }
}
