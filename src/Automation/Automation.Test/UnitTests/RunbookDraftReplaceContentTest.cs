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

using Microsoft.Azure.Management.Automation;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    /// <summary>
    /// Guards against the runbook draft content being sent as a JSON string
    /// (https://github.com/Azure/azure-powershell/issues/30466).
    /// </summary>
    public class RunbookDraftReplaceContentTest
    {
        private class CapturingHandler : DelegatingHandler
        {
            public string ContentType { get; private set; }

            public byte[] Body { get; private set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Method != HttpMethod.Put)
                {
                    // Long-running operation status poll: report that the operation has completed.
                    return new HttpResponseMessage(HttpStatusCode.OK) { RequestMessage = request, Content = new StringContent("{}", Encoding.UTF8, "application/json") };
                }

                ContentType = request.Content?.Headers.ContentType?.MediaType;
                Body = request.Content == null ? null : await request.Content.ReadAsByteArrayAsync();
                return new HttpResponseMessage(HttpStatusCode.Accepted) { RequestMessage = request, Content = new StringContent(string.Empty) };
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReplaceContentSendsRunbookFileUnchanged()
        {
            // Quotes, backslashes, non-ASCII text and mixed newline sequences would all be
            // altered if the content were JSON-serialized.
            string script = "param([string]$Name = \"World\")\r\nWrite-Output 'Hello'\nWrite-Output \"C:\\temp\\$Name\" # caf\u00e9\r\n";
            byte[] expected = new UTF8Encoding(false).GetBytes(script);
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".ps1");
            File.WriteAllBytes(path, expected);

            var handler = new CapturingHandler { InnerHandler = new HttpClientHandler() };
            var client = new AutomationClient(new Uri("https://management.azure.com/"), new TokenCredentials("unit-test"), handler)
            {
                SubscriptionId = Guid.Empty,
                LongRunningOperationRetryTimeout = 0
            };

            try
            {
                // Same call pattern as AutomationPSClient.ImportRunbook.
                using (FileStream sourceStream = File.OpenRead(path))
                {
                    client.RunbookDraft.ReplaceContent("resourceGroup", "automation", "runbook", sourceStream);
                }
            }
            finally
            {
                File.Delete(path);
            }

            Assert.Equal("text/powershell", handler.ContentType);
            Assert.Equal(expected, handler.Body);
        }
    }
}
