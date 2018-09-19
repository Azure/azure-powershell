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
    
    public class NewAzureWebsiteJobTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private const string slot = "staging";

        private Mock<IWebsitesClient> websitesClientMock;

        private NewAzureWebsiteJobCommand cmdlet;

        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureWebsiteJobTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewAzureWebsiteJobCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                WebsitesClient = websitesClientMock.Object,
                Name = websiteName,
                Slot = slot
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesTriggeredWebJob()
        {
            // Setup
            string jobName = "myWebJob";
            string jobFile = "job.bat";
            WebJobType jobType = WebJobType.Triggered;
            PSTriggeredWebJob output = new PSTriggeredWebJob() { JobName = jobName, JobType = jobType };
            websitesClientMock.Setup(f => f.CreateWebJob(websiteName, slot, jobName, jobType, jobFile)).Returns(output);
            cmdlet.JobName = jobName;
            cmdlet.JobType = jobType;
            cmdlet.JobFile = jobFile;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.CreateWebJob(websiteName, slot, jobName, jobType, jobFile), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(output), Times.Once());
        }
    }
}
