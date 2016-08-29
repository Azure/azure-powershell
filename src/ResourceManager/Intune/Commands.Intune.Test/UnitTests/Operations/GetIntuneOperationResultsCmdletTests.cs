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
using Microsoft.Azure.Commands.Intune;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Commands.Intune.Test.UnitTests.Operations
{
    public class GetIntuneOperationResultsCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneOperationResultsCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneApplicationCmdletTests class.
        /// </summary>
        public GetIntuneOperationResultsCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneOperationResultsCmdlet();
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
        public void GetIntuneOperationResults_ReturnsValidItem_Test()
        {
            // Set up the expected App            
            string expectedOperationResultsBody = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.msua06/operationResults/b2a254ae-ca91-4086-b6cd-575e5dbc6698\",\r\n      \"name\": \"b2a254ae-ca91-4086-b6cd-575e5dbc6698\",\r\n      \"type\": \"Microsoft.Intune/locations/operationResults\",\r\n      \"properties\": {\r\n        \"friendlyName\": \"Wipe\",\r\n        \"category\": \"ApplicationManagement\",\r\n        \"lastModifiedTime\": \"2015-12-03T00:15:48.4394665\",\r\n        \"state\": \"pending\",\r\n        \"operationMetadata\": [\r\n          {\r\n            \"name\": \"app\",\r\n            \"value\": \"Word\"\r\n          },\r\n          {\r\n            \"name\": \"userId\",\r\n            \"value\": \"d8aeb100-6e17-4cf7-bbda-169000d03c1e\"\r\n          },\r\n          {\r\n            \"name\": \"userName\",\r\n            \"value\": \"Joe Admin\"\r\n          },\r\n          {\r\n            \"name\": \"deviceType\",\r\n            \"value\": \"iPad\"\r\n          }\r\n        ]\r\n      }\r\n    }\r\n  ]\r\n}";

            var expectedRespose = new AzureOperationResponse<IPage<OperationResult>>();
            var expectedResultPage = new Page<OperationResult>();

            expectedResultPage = JsonConvert.DeserializeObject<Page<OperationResult>>(expectedOperationResultsBody, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.GetOperationResultsWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(),
                    It.IsAny<int?>(),
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.GetOperationResultsNextWithHttpMessagesAsync(
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
