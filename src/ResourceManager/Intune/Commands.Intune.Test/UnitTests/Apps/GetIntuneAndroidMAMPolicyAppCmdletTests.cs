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
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Intune.Test
{
    /// <summary>
    ///  Unit Tests for the GetIntuneAndroidMAMApp Cmdlet.
    /// </summary>
    public class GetIntuneAndroidMAMPolicyAppCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneAndroidMAMPolicyAppCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneAndroidMAMPolicyAppCmdletTests class.
        /// </summary>
        public GetIntuneAndroidMAMPolicyAppCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneAndroidMAMPolicyAppCmdlet();
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
        public void GetIntuneAndroidMAMPolicyAppCmdlet_ReturnsValidItem_Test()
        {
            // Set up the expected App            
            string expectedAppResBody = "{\r\n  \"value\": [\r\n    {\r\n      \"id\": \"/providers/Microsoft.Intune/locations/fef.bmsua01/apps/com.microsoft.skydrive.Android\",\r\n      \"name\": \"com.microsoft.skydrive.Android\",\r\n      \"type\": \"Microsoft.Intune/locations/apps\",\r\n      \"properties\": {\r\n        \"friendlyName\": \"OneDrive\",\r\n        \"platform\": \"android\",\r\n        \"appId\": \"b26aadf8-566f-4478-926f-589f601d9c74\"\r\n      }\r\n    }\r\n  ]\r\n}";
            
            var expectedRespose = new AzureOperationResponse<IPage<Application>>();
            var expectedResultPage = new Page<Application>();

            expectedResultPage = JsonConvert.DeserializeObject<Page<Application>>(expectedAppResBody, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.GetAppForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName, 
                    It.IsAny<string>(), // policy
                    It.IsAny<string>(), // filter
                    It.IsAny<int?>(), // top
                    It.IsAny<string>(), // select
                    It.IsAny<Dictionary<string, List<string>>>(), // dict
                    It.IsAny<CancellationToken>())) // cancelationToken
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Android.GetAppForMAMPolicyNextWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(), 
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet
            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            commandRuntimeMock.Verify(f => f.WriteObject(expectedResultPage, true), Times.Once());
        }
       
        /// <summary>
        /// Test to return 0 item.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetIntuneAndroidMAMPolicyAppCmdlet_ReturnsNoItem_Test()
        {
            // Set up an empty expected App
            var expectedRespose = new AzureOperationResponse<IPage<Application>>();
            var expectedResultPage = new Page<Application>();
           
            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.GetAppForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(), // policy
                    It.IsAny<string>(), // filter
                    It.IsAny<int?>(), // top
                    It.IsAny<string>(), // select
                    It.IsAny<Dictionary<string, List<string>>>(), // dict
                    It.IsAny<CancellationToken>())) // cancelationToken
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Android.GetAppForMAMPolicyNextWithHttpMessagesAsync(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
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