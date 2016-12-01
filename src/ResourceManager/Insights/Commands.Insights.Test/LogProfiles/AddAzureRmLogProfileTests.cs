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

using Microsoft.Azure.Commands.Insights.LogProfiles;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Insights.Test.LogProfiles
{
    public class AddAzureRmLogProfileTests
    {
        private readonly AddAzureRmLogProfileCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<ILogProfilesOperations> insightsLogProfileOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Rest.Azure.AzureOperationResponse<LogProfileResource> response;
        private string logProfileName;
        private LogProfileResource createOrUpdatePrms;

        public AddAzureRmLogProfileTests(ITestOutputHelper output)
        {
            // XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            insightsLogProfileOperationsMock = new Mock<ILogProfilesOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureRmLogProfileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = Utilities.InitializeLogProfileResponse();

            insightsLogProfileOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<LogProfileResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse<LogProfileResource>>(response))
                .Callback((string logProfileName, LogProfileResource createOrUpdateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.logProfileName = logProfileName;
                    createOrUpdatePrms = createOrUpdateParams;
                });

            insightsManagementClientMock.SetupGet(f => f.LogProfiles).Returns(this.insightsLogProfileOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddLogProfileCommandParametersProcessing()
        {
            // With mandatory arguments only
            cmdlet.Name = Utilities.Name;
            cmdlet.Locations = new List<string>() { "East US" };
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.Name, this.logProfileName);

            // With all arguments
            cmdlet.Name = Utilities.Name;
            cmdlet.Locations = new List<string>() {"East US"};
            cmdlet.RetentionInDays = 10;
            cmdlet.ServiceBusRuleId = "miBusId";
            cmdlet.StorageAccountId = "miCuentaId";
            cmdlet.Categories = new List<string>() {"cat1"};
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.Name, this.logProfileName);
        }
    }
}
