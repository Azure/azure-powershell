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
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Insights.Test.LogProfiles
{
    public class GetAzureRmLogProfileTests
    {
        private readonly GetAzureRmLogProfileCommand cmdlet;
        private readonly Mock<MonitorManagementClient> MonitorClientMock;
        private readonly Mock<ILogProfilesOperations> insightsLogProfileOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<LogProfileResource> response;
        private AzureOperationResponse<IEnumerable<LogProfileResource>> responseList;
        private string logProfileName;

        public GetAzureRmLogProfileTests(ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsLogProfileOperationsMock = new Mock<ILogProfilesOperations>();
            MonitorClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmLogProfileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = MonitorClientMock.Object
            };

            response = Test.Utilities.InitializeLogProfileResponse();

            insightsLogProfileOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<LogProfileResource>>(response))
                .Callback((string pfn, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    logProfileName = pfn;
                });

            responseList = new AzureOperationResponse<IEnumerable<LogProfileResource>>()
            {
                Body = new List<LogProfileResource>() {response.Body}
            };

            insightsLogProfileOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<LogProfileResource>>>(responseList))
                .Callback((Dictionary<string, List<string>> headers, CancellationToken t) => {});

            MonitorClientMock.SetupGet(f => f.LogProfiles).Returns(this.insightsLogProfileOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetLogProfileParametersProcessing()
        {
            cmdlet.ExecuteCmdlet();

            cmdlet.Name = Utilities.Name;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.Name, this.logProfileName);
        }
    }
}
