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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.TestFw;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class TestManagerBuilder
    {
        protected readonly ITestRunnable TestManager;

        protected TestManagerBuilder(ITestOutputHelper output)
        {
            TestManager = TestFw.TestManager.CreateInstance()
                .WithXunitTracingInterceptor(output)
                .WithExtraRmModules(helper => new[]
                {
                    helper.RMInsightsModule,
                })
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                })
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithNewMockServerMatcher(
                    (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) => 
                        new ResourcesRecordMatcher(ignoreResourcesClient, resourceProviders, userAgentsToIgnore))
                .WithExtraUserAgentsToIgnore(new Dictionary<string, string>
                {
                    {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2016-07-01"},
                })
                .Build();

            var credentials = HttpMockServer.Mode == HttpRecorderMode.Record
                ? new Func<SubscriptionCloudCredentialsAdapter>(() =>
                    {
                        var testEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                        return new SubscriptionCloudCredentialsAdapter(
                            testEnvironment.TokenInfo[TokenAudience.Management],
                            testEnvironment.SubscriptionId);
                    }) ()
                : new SubscriptionCloudCredentialsAdapter(
                    new TokenCredentials("foo"),
                    Guid.Empty.ToString());

            HttpClientHelperFactory.Instance = new TestHttpClientHelperFactory(credentials);
        }
    }

    #region TestHttpClientHelperFactory

    internal class TestHttpClientHelperFactory : HttpClientHelperFactory
    {
        /// <summary>
        /// The subscription cloud credentials.
        /// </summary>
        private readonly SubscriptionCloudCredentials credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesController.TestHttpClientHelperFactory"/> class.
        /// </summary>
        /// <param name="credentials"></param>
        public TestHttpClientHelperFactory(SubscriptionCloudCredentials credentials)
        {
            credential = credentials;
        }

        /// <summary>
        /// Creates new instances of the <see cref="HttpClientHelper"/> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="headerValues">The headers.</param>
        public override HttpClientHelper CreateHttpClientHelper(SubscriptionCloudCredentials credentials, IEnumerable<ProductInfoHeaderValue> headerValues, Dictionary<string, string> cmdletHeaderValues)
        {
            return new TestHttpClientHelperFactory.HttpClientHelperImpl(credentials: credential, headerValues: headerValues, cmdletHeaderValues: cmdletHeaderValues);
        }

        /// <summary>
        /// An implementation of the <see cref="HttpClientHelper"/> abstract class.
        /// </summary>
        private class HttpClientHelperImpl : HttpClientHelper
        {
            /// <summary>
            /// Initializes new instances of the <see cref="ResourcesController.TestHttpClientHelperFactory.HttpClientHelperImpl"/> class.
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

    //https://gist.github.com/markcowl/4d907da7ce40f2e424e8d0625887b82e
    internal class SubscriptionCloudCredentialsAdapter : SubscriptionCloudCredentials
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

    #endregion
}
