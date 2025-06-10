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
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

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
                .WithManagementClients(context =>
                {
                    AdlsClientFactory.IsTest = true;

                    var serviceClientCredentials = context.GetClientCredentials("https://datalake.azure.net");
                    var scope = "https://datalake.azure.net/.default";

                    // Convert ServiceClientCredentials to TokenCredential
                    var tokenCredential = new ServiceClientCredentialsAdapter(serviceClientCredentials, scope);

                    var handlers = context.AddHandlers(new TokenCredentialAdapter(tokenCredential), new AdlMockDelegatingHandler());
                    AdlsClientFactory.CustomDelegatingHAndler = handlers;
                    AdlsClientFactory.MockCredentials = tokenCredential;

                    return new object();
                })
                .WithCleanupAction(
                    () => AdlsClientFactory.IsTest = false
                )
                .Build();
        }
    }

    public class TokenCredentialAdapter : Microsoft.Rest.ServiceClientCredentials
    {
        private readonly TokenCredential _tokenCredential;

        public TokenCredentialAdapter(TokenCredential tokenCredential)
        {
            _tokenCredential = tokenCredential;
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenRequestContext = new TokenRequestContext(new[] { "https://datalake.azure.net/.default"});
            var accessToken = await _tokenCredential.GetTokenAsync(tokenRequestContext, cancellationToken).ConfigureAwait(false);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
        }
    }
}