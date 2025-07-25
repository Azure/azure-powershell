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
using Microsoft.Azure.Commands.Insights.LogProfiles;
using Microsoft.Azure.Management.Monitor;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.LogProfiles
{
    public class RemoveAzureRmLogProfileTest
    {
        private readonly RemoveAzureRmLogProfileCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<ILogProfilesOperations> insightsLogProfilesOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private string logProfileName;

        public RemoveAzureRmLogProfileTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsLogProfilesOperationsMock = new Mock<ILogProfilesOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureRmLogProfileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            insightsLogProfilesOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse>( new Rest.Azure.AzureOperationResponse()))
                .Callback((string logProfileName, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.logProfileName = logProfileName;
                });

            insightsManagementClientMock.SetupGet(f => f.LogProfiles).Returns(this.insightsLogProfilesOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveLogProfileCommandParametersProcessing()
        {
            cmdlet.Name = Utilities.Name;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.Name, this.logProfileName);
        }
    }
}
