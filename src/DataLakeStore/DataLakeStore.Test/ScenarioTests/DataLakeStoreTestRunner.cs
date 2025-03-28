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
using Microsoft.Azure.Commands.DataLakeStore.Models;
using Microsoft.Azure.Commands.TestFx;
using System.Collections.Generic;
using Xunit.Abstractions;
using Azure.Core;
using Microsoft.Rest;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Microsoft.Azure.Commands.DataLake.Test.ScenarioTests
{
    public class DataLakeStoreTestRunner
    {
        protected readonly ITestRunner TestRunner;

        protected DataLakeStoreTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1",
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.RMNetworkModule,
                    helper.GetRMModulePath("Az.DataLakeStore.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Network", null}
                    }
                )
                .WithRecordMatcher(
                    (ignoreResourcesClient, resourceProviders, userAgentsToIgnore) => new UrlDecodingRecordMatcher(ignoreResourcesClient, resourceProviders, userAgentsToIgnore)
                )
                .WithManagementClients(mockContext =>
                {
                    var currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                    AdlsClientFactory.IsTest = true;
                    var serviceClientCredentials = currentEnvironment.TokenInfo[TokenAudience.Management] as ServiceClientCredentials;
                    AdlsClientFactory.CustomDelegatingHAndler = mockContext.AddHandlers(serviceClientCredentials, new AdlMockDelegatingHandler());
                    AdlsClientFactory.MockCredentials = new TokenCredentialAdapter(serviceClientCredentials);
                    var dummyObj = new object();
                    return dummyObj;
                }
                )
                .WithCleanupAction(
                    () => AdlsClientFactory.IsTest = false
                )
                .Build();
        }
    }

    public class TokenCredentialAdapter : TokenCredential
    {
        private readonly ServiceClientCredentials _serviceClientCredentials;

        public TokenCredentialAdapter(ServiceClientCredentials serviceClientCredentials)
        {
            _serviceClientCredentials = serviceClientCredentials;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var token = GetTokenAsync(requestContext, cancellationToken).Result;
            return token;
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var tokenRequest = new HttpRequestMessage();
            await _serviceClientCredentials.ProcessHttpRequestAsync(tokenRequest, cancellationToken).ConfigureAwait(false);
            var token = tokenRequest.Headers.Authorization.Parameter;
            return new AccessToken(token, DateTimeOffset.MaxValue);
        }
    }
}
