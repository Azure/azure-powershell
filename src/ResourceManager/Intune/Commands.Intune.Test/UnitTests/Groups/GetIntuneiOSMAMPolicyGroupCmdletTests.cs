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
    ///  Unit Tests for the GetIntuneiOSMAMPolicyGroup Cmdlet.
    /// </summary>
    public class GetIntuneiOSMAMPolicyGroupCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private GetIntuneiOSMAMPolicyGroupCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for GetIntuneiOSMAMPolicyGroupCmdletTests class.
        /// </summary>
        public GetIntuneiOSMAMPolicyGroupCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new GetIntuneiOSMAMPolicyGroupCmdlet();
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
        public void GetIntuneiOSMAMPolicyGroupCmdlet_ReturnsValidItem_Test()
        {
            // Set up the expected App            
            string expectedAppResBody = "{\"value\":[{\"id\":\"/providers/Microsoft.Intune/locations/fef.bmsua01/iosPolicies/f7473544-6a23-42cf-90ec-cbc6d99c94b4/groups/046e0be0-5828-47e2-8876-b6a2e33f0ccf\",\"name\":\"046e0be0-5828-47e2-8876-b6a2e33f0ccf\",\"type\":\"Microsoft.Intune/locations/iosPolicies/groups\",\"properties\":{\"friendlyName\":\"SG7\"}}]}";
            
            var expectedRespose = new AzureOperationResponse<IPage<GroupItem>>();
            var expectedResultPage = new Page<GroupItem>();

            expectedResultPage = JsonConvert.DeserializeObject<Page<GroupItem>>(expectedAppResBody, intuneClientMock.Object.DeserializationSettings);

            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Ios.GetGroupsForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName, 
                    It.IsAny<string>(), // policy
                    It.IsAny<Dictionary<string, List<string>>>(), // dict
                    It.IsAny<CancellationToken>())) // cancelationToken
                .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Ios.GetGroupsForMAMPolicyNextWithHttpMessagesAsync(
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
        public void GetIntuneiOSMAMPolicyGroupCmdlet_ReturnsNoItem_Test()
        {
            // Set up an empty expected App
            var expectedRespose = new AzureOperationResponse<IPage<GroupItem>>();
            var expectedResultPage = new Page<GroupItem>();
           
            expectedRespose.Body = expectedResultPage;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Ios.GetGroupsForMAMPolicyWithHttpMessagesAsync(
                     expectedLocation.HostName,
                     It.IsAny<string>(), // policy
                     It.IsAny<Dictionary<string, List<string>>>(), // dict
                     It.IsAny<CancellationToken>())) // cancelationToken
                 .Returns(Task.FromResult(expectedRespose));

            intuneClientMock.Setup(f => f.Ios.GetGroupsForMAMPolicyNextWithHttpMessagesAsync(
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