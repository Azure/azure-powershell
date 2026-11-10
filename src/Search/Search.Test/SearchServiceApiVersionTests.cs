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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Search;
using Microsoft.Rest;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Search.Test
{
    [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [InlineData("future-plan", null, "future-plan", "Name")]
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
                PSKnowledgeRetrievalMode? expectedMode = null;
                if (Enum.TryParse(expectedWireValue, true, out PSKnowledgeRetrievalMode parsedMode) &&
                    Enum.IsDefined(typeof(PSKnowledgeRetrievalMode), parsedMode))
                {
                    expectedMode = parsedMode;
                }
                Assert.Equal(expectedMode, output.KnowledgeRetrievalMode);
            }
        }

        [Theory]
        [InlineData(PSComputeType.Default, PSPublicNetworkAccess.Enabled)]
        [InlineData(PSComputeType.Confidential, PSPublicNetworkAccess.Disabled)]
        [InlineData(PSComputeType.Default, PSPublicNetworkAccess.SecuredByPerimeter)]
        public void NewServiceUsesContractCasing(PSComputeType computeType, PSPublicNetworkAccess publicNetworkAccess)
        {
            using (var handler = new SearchServiceHandler(null))
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            {
                var runtime = new Mock<ICommandRuntime>();
                runtime.Setup(r => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
                var command = new NewSearchServiceCommand
                {
                    CommandRuntime = runtime.Object,
                    SearchClient = client,
                    ResourceGroupName = "test-rg",
                    Name = "test-search",
                    Location = "westus",
                    Sku = PSSkuName.Basic,
                    ComputeType = computeType,
                    PublicNetworkAccess = publicNetworkAccess
                };

                command.ExecuteCmdlet();

                Assert.Equal(computeType.ToString(), (string)handler.RequestBody["properties"]["computeType"]);
                Assert.Equal(publicNetworkAccess.ToString(), (string)handler.RequestBody["properties"]["publicNetworkAccess"]);
            }
        }

        [Theory]
        [InlineData(PSPublicNetworkAccess.Enabled)]
        [InlineData(PSPublicNetworkAccess.Disabled)]
        [InlineData(PSPublicNetworkAccess.SecuredByPerimeter)]
        public void SetServiceUsesContractCasing(PSPublicNetworkAccess publicNetworkAccess)
        {
            using (var handler = new SearchServiceHandler(null))
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            using (var runspace = CreateRunspace(client))
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.Runspace = runspace;
                powershell.AddCommand("Set-TestSearchService")
                    .AddParameter("ResourceGroupName", "test-rg")
                    .AddParameter("Name", "test-search")
                    .AddParameter("PublicNetworkAccess", publicNetworkAccess);

                powershell.Invoke();

                Assert.False(powershell.HadErrors, string.Join(Environment.NewLine, powershell.Streams.Error));
                Assert.Equal(publicNetworkAccess.ToString(), (string)handler.RequestBody["properties"]["publicNetworkAccess"]);
            }
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("future-plan", null)]
        [InlineData("42", null)]
        [InlineData("FREE", PSKnowledgeRetrievalMode.Free)]
        [InlineData("standard", PSKnowledgeRetrievalMode.Standard)]
        public void ServiceOutputToleratesExtensibleKnowledgeRetrieval(
            string wireValue, PSKnowledgeRetrievalMode? expectedMode)
        {
            using (var handler = new SearchServiceHandler(wireValue))
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            {
                var service = PSSearchService.Create(client.Services.Get("test-rg", "test-search"));

                Assert.Equal("test-search", service.Name);
                Assert.Equal(expectedMode, service.KnowledgeRetrievalMode);
            }
        }

        [Fact]
        public void PrivateLinkResourcesFollowsNextPage()
        {
            using (var handler = new PrivateLinkResourcesHandler())
            using (var httpClient = new HttpClient(handler))
            using (var client = CreateClient(httpClient))
            {
                var state = InitialSessionState.CreateDefault2();
                state.Commands.Add(new SessionStateCmdletEntry("Get-TestPrivateLinkResource",
                    typeof(TestGetPrivateLinkResourceCommand), null));
                using (var runspace = RunspaceFactory.CreateRunspace(state))
                using (var powershell = System.Management.Automation.PowerShell.Create())
                {
                    runspace.Open();
                    runspace.SessionStateProxy.SetVariable("SearchTestClient", client);
                    powershell.Runspace = runspace;
                    powershell.AddCommand("Get-TestPrivateLinkResource")
                        .AddParameter("ResourceGroupName", "test-rg")
                        .AddParameter("Name", "test-search");

                    var results = powershell.Invoke();

                    Assert.False(powershell.HadErrors, string.Join(Environment.NewLine, powershell.Streams.Error));
                    Assert.Equal(2, handler.RequestCount);
                    Assert.Collection(results,
                        first => Assert.Equal("first", Assert.IsType<PSPrivateLinkResource>(first.BaseObject).Name),
                        second => Assert.Equal("second", Assert.IsType<PSPrivateLinkResource>(second.BaseObject).Name));
                }
            }
        }

        [Theory]
        [InlineData("Get")]
        [InlineData("Remove")]
        public void SharedPrivateLinkCleanupAttemptsGroupDeletionWhenLinkCleanupFails(string failingCommand)
        {
            string scriptPath = Path.Combine(AppContext.BaseDirectory, "ScenarioTests", "SearchServiceTests.ps1");
            var script = Parser.ParseFile(scriptPath, out _, out ParseError[] errors);
            Assert.Empty(errors);
            var function = Assert.IsType<FunctionDefinitionAst>(script.Find(
                node => node is FunctionDefinitionAst definition &&
                    definition.Name == "Test-ManageAzSearchSharedPrivateLinkResources", true));
            var statement = Assert.Single(function.Body.EndBlock.Statements.OfType<TryStatementAst>());
            string cleanup = string.Join(Environment.NewLine,
                statement.Finally.Statements.Select(node => node.Extent.Text));

            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                powershell.AddScript("""
                    param($cleanup, $failingCommand)
                    $ErrorActionPreference = 'Stop'
                    $rgname = 'test-rg'
                    $svcName = 'test-search'
                    $newSearchService = [pscustomobject]@{ Name = $svcName }
                    $script:groupCleanupCalls = 0
                    $failureMessage = $null

                    function Get-AzSearchSharedPrivateLinkResource
                    {
                        [CmdletBinding()]
                        param($ResourceGroupName, $ServiceName)
                        if ($failingCommand -eq 'Get') { throw 'Injected Get failure' }
                        [pscustomobject]@{ Name = 'test-link' }
                    }
                    function Remove-AzSearchSharedPrivateLinkResource
                    {
                        [CmdletBinding()]
                        param([Parameter(ValueFromPipeline)] $InputObject, [switch] $Force)
                        process { throw 'Injected Remove failure' }
                    }
                    function Clean-ResourceGroup
                    {
                        param($rgname)
                        $script:groupCleanupCalls++
                    }

                    try { & ([scriptblock]::Create($cleanup)) }
                    catch { $failureMessage = $_.Exception.Message }
                    [pscustomobject]@{
                        GroupCleanupCalls = $script:groupCleanupCalls
                        FailureMessage = $failureMessage
                    }
                    """)
                    .AddParameter("cleanup", cleanup)
                    .AddParameter("failingCommand", failingCommand);

                var results = powershell.Invoke();

                Assert.Empty(powershell.Streams.Error);
                var result = Assert.Single(results);
                Assert.Equal(1, result.Properties["GroupCleanupCalls"].Value);
                Assert.Equal($"Injected {failingCommand} failure", result.Properties["FailureMessage"].Value);
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

        [Cmdlet(VerbsCommon.Get, "TestPrivateLinkResource",
            DefaultParameterSetName = "ResourceNameParameterSet")]
        public class TestGetPrivateLinkResourceCommand : GetSearchPrivateLinkResourceCommand
        {
            protected override void BeginProcessing()
            {
                SearchClient = (ISearchManagementClient)((PSCmdlet)this).SessionState.PSVariable.GetValue("SearchTestClient");
            }

            protected override void EndProcessing()
            {
            }
        }

        private class PrivateLinkResourcesHandler : HttpMessageHandler
        {
            public int RequestCount { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal(HttpMethod.Get, request.Method);
                Assert.Contains("api-version=2026-11-01", request.RequestUri.Query);
                RequestCount++;
                bool secondPage = request.RequestUri.Query.Contains("page=2");
                Assert.Equal(RequestCount == 2, secondPage);
                var resource = new JObject
                {
                    ["id"] = SearchServiceHandler.ServiceId + "/privateLinkResources/" + (secondPage ? "second" : "first"),
                    ["name"] = secondPage ? "second" : "first",
                    ["type"] = "Microsoft.Search/searchServices/privateLinkResources",
                    ["properties"] = new JObject
                    {
                        ["groupId"] = "searchService",
                        ["requiredMembers"] = new JArray("searchService"),
                        ["requiredZoneNames"] = new JArray("privatelink.search.windows.net"),
                        ["shareablePrivateLinkResourceTypes"] = new JArray()
                    }
                };
                var body = new JObject { ["value"] = new JArray(resource) };
                if (!secondPage)
                {
                    body["nextLink"] = "https://management.azure.com" + SearchServiceHandler.ServiceId +
                        "/privateLinkResources?api-version=2026-11-01&page=2";
                }
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(body.ToString(), System.Text.Encoding.UTF8, "application/json")
                });
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
