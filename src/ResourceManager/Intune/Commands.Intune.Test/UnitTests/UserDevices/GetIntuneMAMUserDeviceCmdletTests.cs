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

namespace Commands.Intune.Test.UnitTests
{
    public class GetIntuneMAMUserDeviceCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneUserDeviceCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneMAMUserDeviceCmdletTests class.
        /// </summary>
        public GetIntuneMAMUserDeviceCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneUserDeviceCmdlet();
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
        public void GetIntuneMAMUserDevices_ReturnsValidItem_Test()
        {
            // Set up the expected Policy            
            string expectedUserDevices = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.bmsua01/users/f4058390-f6d0-459b-9c36-3cf9d88e87f5/devices/8693b393-a69c-4d12-a9c8-a1a415884fd2\",\r\n      \"name\": \"8693b393-a69c-4d12-a9c8-a1a415884fd2\",\r\n      \"type\": \"Microsoft.Intune/locations/users/devices\",\r\n      \"properties\": {\r\n        \"userId\": \"f4058390-f6d0-459b-9c36-3cf9d88e87f5\",\r\n        \"friendlyName\": \"TestIpad\",\r\n        \"platform\": \"IOS\",\r\n        \"platformVersion\": \"9.0\",\r\n        \"deviceType\": \"TestIpad\"\r\n      }\r\n    },\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.bmsua01/users/f4058390-f6d0-459b-9c36-3cf9d88e87f5/devices/38BBFA62-371F-4AA8-BFDB-846EBD47A86A\",\r\n      \"name\": \"38BBFA62-371F-4AA8-BFDB-846EBD47A86A\",\r\n      \"type\": \"Microsoft.Intune/locations/users/devices\",\r\n      \"properties\": {\r\n        \"userId\": \"f4058390-f6d0-459b-9c36-3cf9d88e87f5\",\r\n        \"friendlyName\": \"iPad\",\r\n        \"platform\": \"IOS\",\r\n        \"platformVersion\": \"8.1\",\r\n        \"deviceType\": \"iPad\"\r\n      }\r\n    }\r\n  ]\r\n}";

            var expectedRespose = new AzureOperationResponse<IPage<Device>>();

            IPage<Device> expectedResultPage = new Page<Device>();

            expectedResultPage = JsonConvert.DeserializeObject<Page<Device>>(expectedUserDevices, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.GetMAMUserDevicesWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int?>(),
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.GetMAMUserDevicesNextWithHttpMessagesAsync(
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
