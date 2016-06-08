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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Intune.Test
{
    /// <summary>
    ///  Unit Tests for the AddIntuneAndroidMAMPolicyGroup Cmdlet.
    /// </summary>
    public class AddIntuneAndroidMAMPolicyGroupCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AddIntuneAndroidMAMPolicyGroupCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for AddIntuneAndroidMAMPolicyGroupCmdletTests class.
        /// </summary>
        public AddIntuneAndroidMAMPolicyGroupCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new AddIntuneAndroidMAMPolicyGroupCmdlet();
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
        /// Test for valid args.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddIntuneAndroidMAMPolicyGroupCmdlet_WithValidArgs_Test()
        {  
            // Set up the expected Policy
            var res = new Microsoft.Rest.Azure.AzureOperationResponse();

            AndroidMAMPolicy actualPolicyObj = new AndroidMAMPolicy();

            intuneClientMock.SetupAllProperties();
            intuneClientMock.SetupGet(x => x.BaseUri).Returns(new Uri("http://expectedBaseUri"));
           
            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.AddGroupForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<MAMPolicyAppIdOrGroupIdPayload>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
               .Returns(Task.FromResult(res));
                         
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet            
            this.cmdlet.ExecuteCmdlet();            
        }
    }
}