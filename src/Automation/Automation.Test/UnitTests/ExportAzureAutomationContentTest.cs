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

using Microsoft.Azure.Commands.Automation.Common;
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
    /// Runs AutomationPSClient against the generated AutomationClient with a fake HTTP handler,
    /// so the content operations are exercised with the response the service sends: raw script text.
    /// </summary>
    public class ExportAzureAutomationContentTest : IDisposable
    {
        private const string Script = "param([string]$Name = \"W\u00f6rld\")\r\nWrite-Output \"Hello, $Name\"\r\nWrite-Output 'C:\\temp\\out.txt'\r\n";

        private readonly string outputFolder;

        public ExportAzureAutomationContentTest()
        {
            this.outputFolder = Path.Combine(Path.GetTempPath(), "AutomationExportTest-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(this.outputFolder);
        }

        public void Dispose()
        {
            // GetConfigurationContent joins with a backslash, so on non-Windows hosts this file sits next to the folder.
            File.Delete(this.outputFolder + "\\config.ps1");
            Directory.Delete(this.outputFolder, true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportPublishedRunbookWritesRawContent()
        {
            var client = CreateClient(new FakeAutomationHandler("Published"));

            client.ExportRunbook("rg", "account", "runbook", false, this.outputFolder, true);

            Assert.Equal(Script, File.ReadAllText(Path.Combine(this.outputFolder, "runbook.ps1")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportDraftRunbookWritesRawContent()
        {
            var client = CreateClient(new FakeAutomationHandler("Edit"));

            client.ExportRunbook("rg", "account", "runbook", true, this.outputFolder, true);

            Assert.Equal(Script, File.ReadAllText(Path.Combine(this.outputFolder, "runbook.ps1")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportDscConfigurationWritesRawContent()
        {
            var client = CreateClient(new FakeAutomationHandler("Published"));

            client.GetConfigurationContent("rg", "account", "config", null, this.outputFolder, true);

            // GetConfigurationContent joins the folder and the file name with a backslash.
            Assert.Equal(Script, File.ReadAllText(this.outputFolder + "\\config.ps1"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportMissingDscConfigurationThrowsResourceNotFound()
        {
            var client = CreateClient(new FakeAutomationHandler("Published") { ConfigurationExists = false });

            Assert.Throws<ResourceNotFoundException>(
                () => client.GetConfigurationContent("rg", "account", "config", null, this.outputFolder, true));
        }

        private static AutomationPSClient CreateClient(FakeAutomationHandler handler)
        {
            var automationClient = new AutomationClient(
                new Uri("https://management.example.test/"), new TokenCredentials("token"), handler)
            {
                SubscriptionId = Guid.Empty
            };
            return new AutomationPSClient(null, automationClient);
        }

        private class FakeAutomationHandler : DelegatingHandler
        {
            private readonly string runbookState;

            public FakeAutomationHandler(string runbookState)
            {
                this.runbookState = runbookState;
            }

            public bool ConfigurationExists { get; set; } = true;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var path = request.RequestUri.AbsolutePath;
                if (request.Method == HttpMethod.Get && path.EndsWith("/runbooks/runbook", StringComparison.Ordinal))
                {
                    return Respond(HttpStatusCode.OK,
                        "{\"name\":\"runbook\",\"properties\":{\"runbookType\":\"PowerShell\",\"state\":\"" + this.runbookState + "\"}}",
                        "application/json");
                }

                if (request.Method == HttpMethod.Get &&
                    (path.EndsWith("/runbooks/runbook/content", StringComparison.Ordinal) ||
                     path.EndsWith("/runbooks/runbook/draft/content", StringComparison.Ordinal)))
                {
                    return Respond(HttpStatusCode.OK, Script, "text/powershell");
                }

                if (request.Method == HttpMethod.Get && path.EndsWith("/configurations/config/content", StringComparison.Ordinal))
                {
                    return this.ConfigurationExists
                        ? Respond(HttpStatusCode.OK, Script, "text/powershell")
                        : Respond(HttpStatusCode.NotFound, "{\"code\":\"NotFound\",\"message\":\"Configuration not found.\"}", "application/json");
                }

                return Respond(HttpStatusCode.NotFound, "{\"code\":\"NotFound\",\"message\":\"Unexpected request.\"}", "application/json");
            }

            private static Task<HttpResponseMessage> Respond(HttpStatusCode statusCode, string body, string mediaType)
            {
                return Task.FromResult(new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(body, new UTF8Encoding(false), mediaType)
                });
            }
        }
    }
}
