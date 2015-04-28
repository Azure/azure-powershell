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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebJobs;
using Microsoft.WindowsAzure.Commands.Websites.WebJobs;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class GetAzureWebsiteJobHistoryTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private const string slot = "staging";

        private const string jobName = "webJobName";

        private Mock<IWebsitesClient> websitesClientMock;

        private GetAzureWebsiteJobHistoryCommand cmdlet;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetAzureWebsiteJobHistoryTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureWebsiteJobHistoryCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                WebsitesClient = websitesClientMock.Object,
                Name = websiteName,
                Slot = slot,
                JobName = jobName
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetCompleteWebJobHistory()
        {
            // Setup
            List<TriggeredWebJobRun> output = new List<TriggeredWebJobRun>()
            {
                new TriggeredWebJobRun() { Id = "id1", Status = "succeed"},
                new TriggeredWebJobRun() { Id = "id2", Status = "fail"},
                new TriggeredWebJobRun() { Id = "id3", Status = "succeed"}
            };
            WebJobHistoryFilterOptions options = null;
            websitesClientMock.Setup(f => f.FilterWebJobHistory(It.IsAny<WebJobHistoryFilterOptions>()))
                .Returns(output)
                .Callback((WebJobHistoryFilterOptions actual) => options = actual)
                .Verifiable();

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            Assert.Equal(options.Name, websiteName);
            Assert.Equal(options.Slot, slot);
            Assert.Equal(options.JobName, jobName);
            websitesClientMock.Verify(f => f.FilterWebJobHistory(options), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(output, true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSpecificWebJobRun()
        {
            // Setup
            string runId = "id1";
            List<TriggeredWebJobRun> output = new List<TriggeredWebJobRun>() { new TriggeredWebJobRun() { Id = runId, Status = "succeed" } };
            WebJobHistoryFilterOptions options = null;
            websitesClientMock.Setup(f => f.FilterWebJobHistory(It.IsAny<WebJobHistoryFilterOptions>()))
                .Returns(output)
                .Callback((WebJobHistoryFilterOptions actual) => options = actual)
                .Verifiable();
            cmdlet.RunId = runId;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            Assert.Equal(options.Name, websiteName);
            Assert.Equal(options.Slot, slot);
            Assert.Equal(options.JobName, jobName);
            Assert.Equal(options.RunId, runId);
            websitesClientMock.Verify(f => f.FilterWebJobHistory(options), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(output, true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLatestWebJobRun()
        {
            // Setup
            List<TriggeredWebJobRun> output = new List<TriggeredWebJobRun>() { new TriggeredWebJobRun() { Id = "id1", Status = "succeed" } };
            WebJobHistoryFilterOptions options = null;
            websitesClientMock.Setup(f => f.FilterWebJobHistory(It.IsAny<WebJobHistoryFilterOptions>()))
                .Returns(output)
                .Callback((WebJobHistoryFilterOptions actual) => options = actual)
                .Verifiable();
            cmdlet.Latest = true;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            Assert.Equal(options.Name, websiteName);
            Assert.Equal(options.Slot, slot);
            Assert.Equal(options.JobName, jobName);
            Assert.True(options.Latest);
            websitesClientMock.Verify(f => f.FilterWebJobHistory(options), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(output, true), Times.Once());
        }
    }
}
