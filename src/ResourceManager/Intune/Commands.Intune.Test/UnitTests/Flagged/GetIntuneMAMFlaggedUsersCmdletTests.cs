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
    /// <summary>
    ///  Unit Tests for the GetIntuneMAMFlaggedUser Cmdlet.
    /// </summary>
    public class GetIntuneMAMFlaggedUsersCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneMAMFlaggedUsersCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneMAMFlaggedUsersCmdletTests class.
        /// </summary>
        public GetIntuneMAMFlaggedUsersCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneMAMFlaggedUsersCmdlet();
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
        public void GetIntuneMAMFlaggedUsers_ReturnsValidItem_Test()
        {
            // Set up the expected Policy            
            string expectedFlaggedUsers = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.bmsua01/flaggedUsers/f4058390-f6d0-459b-9c36-3cf9d88e87f5\",\r\n      \"name\": \"f4058390-f6d0-459b-9c36-3cf9d88e87f5\",\r\n      \"type\": \"Microsoft.Intune/locations/flaggedUsers\",\r\n      \"properties\": {\r\n        \"friendlyName\": \"(?)??? ???????????? ????????\",\r\n        \"errorCount\": 1\r\n      }\r\n    }\r\n  ]\r\n}";

            var expectedRespose = new AzureOperationResponse<IPage<FlaggedUser>>();

            IPage<FlaggedUser> expectedResultPage = new Page<FlaggedUser>();

            expectedResultPage = JsonConvert.DeserializeObject<Page<FlaggedUser>>(expectedFlaggedUsers, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.GetMAMFlaggedUsersWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(),
                    It.IsAny<int?>(),
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.GetMAMFlaggedUsersNextWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject(expectedResultPage, true), Times.Once());
        }
    }
}

