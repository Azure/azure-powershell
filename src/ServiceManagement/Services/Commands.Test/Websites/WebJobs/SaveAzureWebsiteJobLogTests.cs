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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Websites.WebJobs;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    
    public class SaveAzureWebsiteJobLogTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private const string slot = "staging";

        private Mock<IWebsitesClient> websitesClientMock;

        private SaveAzureWebsiteJobLogCommand cmdlet; 

        private Mock<ICommandRuntime> commandRuntimeMock;

        public SaveAzureWebsiteJobLogTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SaveAzureWebsiteJobLogCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                WebsitesClient = websitesClientMock.Object,
                Name = websiteName,
                Slot = slot,
                PassThru = true
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SavesWebJobLog()
        {
            // Setup
            string jobName = "myWebJob";
            WebJobType jobType = WebJobType.Continuous;
            websitesClientMock.Setup(f => f.SaveWebJobLog(websiteName, slot, jobName, jobType, null, null)).Verifiable();
            cmdlet.JobName = jobName;
            cmdlet.JobType = jobType;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.SaveWebJobLog(websiteName, slot, jobName, jobType, null, null), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SavesTriggeredWebJobLog()
        {
            // Setup
            string jobName = "myWebJob";
            string output = ".\\myFile.zip";
            string runId = "runId1";
            WebJobType jobType = WebJobType.Triggered;
            websitesClientMock.Setup(f => f.SaveWebJobLog(websiteName, slot, jobName, jobType, output, runId)).Verifiable();
            cmdlet.JobName = jobName;
            cmdlet.JobType = jobType;
            cmdlet.Output = output;
            cmdlet.RunId = runId;
            cmdlet.PassThru = false;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.SaveWebJobLog(websiteName, slot, jobName, jobType, output, runId), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<bool>()), Times.Never());
        }
    }
}
