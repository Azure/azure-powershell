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
    
    public class StartAzureWebsiteJobTests : WebsitesTestBase
    {
        private const string websiteName = "website1";

        private const string slot = "staging";

        private Mock<IWebsitesClient> websitesClientMock;

        private StartAzureWebsiteJobCommand cmdlet; 

        private Mock<ICommandRuntime> commandRuntimeMock;

        public StartAzureWebsiteJobTests()
        {
            websitesClientMock = new Mock<IWebsitesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new StartAzureWebsiteJobCommand()
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
        public void StartsTriggeredWebJob()
        {
            // Setup
            string jobName = "myWebJob";
            WebJobType jobType = WebJobType.Triggered;
            websitesClientMock.Setup(f => f.StartWebJob(websiteName, slot, jobName, jobType)).Verifiable();
            cmdlet.JobName = jobName;
            cmdlet.JobType = jobType;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            websitesClientMock.Verify(f => f.StartWebJob(websiteName, slot, jobName, jobType), Times.Once());
            commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once());
        }
    }
}
