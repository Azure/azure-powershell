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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Commands.Management.Search.SearchService;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Search;
using Microsoft.Rest;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Search.Test
{
    public class SearchServiceApiVersionTests
    {
        public SearchServiceApiVersionTests()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(PSKnowledgeRetrievalMode.Free, "free")]
        [InlineData(PSKnowledgeRetrievalMode.Standard, "standard")]
        public void NewServiceSupportsServerlessAndKnowledgeRetrieval(
            PSKnowledgeRetrievalMode? mode, string expectedWireValue)
        {
            using (var handler = new SearchServiceHandler(null))
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            {
                object output = null;
                var runtime = new Mock<ICommandRuntime>();
                runtime.Setup(r => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
                runtime.Setup(r => r.WriteObject(It.IsAny<object>())).Callback<object>(value => output = value);

                var command = new NewSearchServiceCommand
                {
                    CommandRuntime = runtime.Object,
                    SearchClient = client,
                    ResourceGroupName = "test-rg",
                    Name = "test-search",
                    Location = "westus",
                    Sku = PSSkuName.Serverless,
                    KnowledgeRetrievalMode = mode
                };

                command.ExecuteCmdlet();

                Assert.Equal("serverless", (string)handler.RequestBody["sku"]["name"]);
                Assert.Equal(expectedWireValue, (string)handler.RequestBody["properties"]["knowledgeRetrieval"]);
                var service = Assert.IsType<PSSearchService>(output);
                Assert.Equal(PSSkuName.Serverless, service.Sku);
                Assert.Equal(mode, service.KnowledgeRetrievalMode);
            }
        }

        [Theory]
        [InlineData("standard", null, "standard", "Name")]
        [InlineData(null, null, null, "Name")]
        [InlineData("free", PSKnowledgeRetrievalMode.Standard, "standard", "Name")]
        [InlineData("standard", PSKnowledgeRetrievalMode.Free, "free", "Name")]
        [InlineData("free", PSKnowledgeRetrievalMode.Standard, "standard", "ResourceId")]
        [InlineData("standard", null, "standard", "InputObject")]
        public void SetServiceUpdatesOrPreservesKnowledgeRetrieval(
            string existingWireValue, PSKnowledgeRetrievalMode? mode, string expectedWireValue, string parameterSet)
        {
            using (var handler = new SearchServiceHandler(existingWireValue))
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            using (var runspace = CreateRunspace(client))
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.Runspace = runspace;
                powershell.AddCommand("Set-TestSearchService").AddParameter("ReplicaCount", 2);
                if (parameterSet == "ResourceId")
                {
                    powershell.AddParameter("ResourceId", SearchServiceHandler.ServiceId);
                }
                else if (parameterSet == "InputObject")
                {
                    var service = client.Services.Get("test-rg", "test-search");
                    powershell.AddParameter("InputObject", PSSearchService.Create(service));
                }
                else
                {
                    powershell.AddParameter("ResourceGroupName", "test-rg").AddParameter("Name", "test-search");
                }
                if (mode.HasValue)
                {
                    powershell.AddParameter("KnowledgeRetrievalMode", mode.Value);
                }

                var results = powershell.Invoke();

                Assert.False(powershell.HadErrors, string.Join(Environment.NewLine, powershell.Streams.Error));
                Assert.Equal(expectedWireValue, (string)handler.RequestBody["properties"]["knowledgeRetrieval"]);
                Assert.Equal(2, (int)handler.RequestBody["properties"]["replicaCount"]);
                var output = Assert.IsType<PSSearchService>(Assert.Single(results).BaseObject);
                Assert.Equal(expectedWireValue == null ? (PSKnowledgeRetrievalMode?)null :
                    (PSKnowledgeRetrievalMode)Enum.Parse(typeof(PSKnowledgeRetrievalMode), expectedWireValue, true),
                    output.KnowledgeRetrievalMode);
            }
        }

        private static SearchManagementClient CreateClient(HttpClient httpClient)
        {
            return new SearchManagementClient(new TokenCredentials("offline-test"), httpClient, false)
            {
                SubscriptionId = Guid.Parse("00000000-0000-0000-0000-000000000001")
            };
        }

        private static Runspace CreateRunspace(ISearchManagementClient client)
        {
            var state = InitialSessionState.CreateDefault2();
            state.Commands.Add(new SessionStateCmdletEntry("Set-TestSearchService", typeof(TestSetSearchServiceCommand), null));
            var runspace = RunspaceFactory.CreateRunspace(state);
            runspace.Open();
            runspace.SessionStateProxy.SetVariable("SearchTestClient", client);
            return runspace;
        }

        [Cmdlet(VerbsCommon.Set, "TestSearchService", SupportsShouldProcess = true,
            DefaultParameterSetName = "ResourceNameParameterSet")]
        public class TestSetSearchServiceCommand : SetSearchServiceCommand
        {
            protected override void BeginProcessing()
            {
                SearchClient = (ISearchManagementClient)((PSCmdlet)this).SessionState.PSVariable.GetValue("SearchTestClient");
            }

            protected override void EndProcessing()
            {
            }
        }

        private class SearchServiceHandler : HttpMessageHandler
        {
            public const string ServiceId =
                "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test-rg/providers/Microsoft.Search/searchServices/test-search";
            private readonly string existingWireValue;

            public JObject RequestBody { get; private set; }

            public SearchServiceHandler(string existingWireValue)
            {
                this.existingWireValue = existingWireValue;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Contains("api-version=2026-11-01", request.RequestUri.Query);
                var service = JObject.Parse(@"{
                    'location': 'westus',
                    'sku': { 'name': 'serverless' },
                    'properties': { 'status': 'running', 'provisioningState': 'succeeded' }
                }");
                if (request.Method == HttpMethod.Get)
                {
                    service["properties"]["knowledgeRetrieval"] = existingWireValue;
                }
                else
                {
                    Assert.True(request.Method == HttpMethod.Put || request.Method == new HttpMethod("PATCH"));
                    RequestBody = JObject.Parse(await request.Content.ReadAsStringAsync());
                    service.Merge(RequestBody);
                }
                service["id"] = ServiceId;
                service["name"] = "test-search";
                service["type"] = "Microsoft.Search/searchServices";
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(service.ToString(), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
