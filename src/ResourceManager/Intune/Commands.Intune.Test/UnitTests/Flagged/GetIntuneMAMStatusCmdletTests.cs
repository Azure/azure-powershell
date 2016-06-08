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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Intune;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Xunit;
using Microsoft.Azure.Commands.Intune.Flagged;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Commands.Intune.Test.UnitTests
{
    public class GetIntuneMAMStatusCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneMAMStatusCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneMAMUserFlaggedEnrolledAppsCmdlet class.
        /// </summary>
        public GetIntuneMAMStatusCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneMAMStatusCmdlet();
            this.cmdlet.CommandRuntime = commandRuntimeMock.Object;
            this.cmdlet.IntuneClient = intuneClientMock.Object;

            // Set-up mock Location and mock the underlying service API method       
            AzureOperationResponse<Location> resLocation = new AzureOperationResponse<Location>();
            expectedLocation = new Location("mockHostName");
            resLocation.Body = expectedLocation;

            intuneClientMock.Setup(f => f.GetLocationByHostNameWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resLocation));
        }

        /// <summary>
        /// Test to return valid item.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetIntuneMAMStatus_ReturnsValidItem_Test()
        {
            // Set up the expected Policy            
            string mamStatus = "{\r\n  \"id\": \"/providers/Microsoft.Intune/locations/fef.bmsua01/statuses/default\",\r\n  \"name\": \"default\",\r\n  \"type\": \"Microsoft.Intune/locations/statuses\",\r\n  \"properties\": {\r\n    \"deployedPolicies\": 0,\r\n    \"status\": \"complete\",\r\n    \"flaggedUsers\": 0,\r\n    \"policyAppliedUsers\": 0,\r\n    \"enrolledUsers\": 0,\r\n    \"wipePendingApps\": 0,\r\n    \"wipeFailedApps\": 0,\r\n    \"wipeSucceededApps\": 0,\r\n    \"lastModifiedTime\": \"2015-11-24T21:32:05.4576414\"\r\n  }\r\n}";

            AzureOperationResponse<StatusesDefault> expectedRespose = new AzureOperationResponse<StatusesDefault>();
            StatusesDefault expectedResult = JsonConvert.DeserializeObject<StatusesDefault>(mamStatus, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResult;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.GetMAMStatusesWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(expectedRespose));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject(expectedResult), Times.Once());
        }
    }
}
