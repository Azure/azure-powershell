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
    ///  Unit Tests for the RemoveIntuneiOSMAMPolicyGroup Cmdlet.
    /// </summary> 
    public class RemoveIntuneiOSMAMPolicyGroupCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private RemoveIntuneiOSMAMPolicyGroupCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for RemoveIntuneiOSMAMPolicyGroupCmdletTests class.
        /// </summary>
        public RemoveIntuneiOSMAMPolicyGroupCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new RemoveIntuneiOSMAMPolicyGroupCmdlet();                         
                            
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
        /// Test for one item deleted.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveIntuneiOSMAMPolicyGroupCmdlet_OneItemDeleted_Test()
        {
            // Set up expected response
            var expectedRespose = new Microsoft.Rest.Azure.AzureOperationResponse();

            expectedRespose.Response = new System.Net.Http.HttpResponseMessage();
            expectedRespose.Response.StatusCode = System.Net.HttpStatusCode.OK;

            string expectedPolicyId = Guid.NewGuid().ToString();

            // Mock the Underlying Service API method
            intuneClientMock.Setup(f => f.Ios.DeleteGroupForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    expectedPolicyId,
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(), 
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(
                    It.IsAny<string>(), 
                    It.IsAny<string>()))
                .Returns(() => true);
              
            // Set the cmdline args and execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.Name = expectedPolicyId;

            this.cmdlet.ExecuteCmdlet();              
        }

        /// <summary>
        /// Test for no item deleted.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveIntuneiOSMAMPolicyGroupCmdletTests_NoItemDeleted_Test()
        {
            // Set up expected response
            var expectedRespose = new Microsoft.Rest.Azure.AzureOperationResponse();

            expectedRespose.Response = new System.Net.Http.HttpResponseMessage();
            expectedRespose.Response.StatusCode = System.Net.HttpStatusCode.NoContent;

            string expectedPolicyId = Guid.NewGuid().ToString();

            // Mock the Underlying Service API method
            intuneClientMock.Setup(f => f.Ios.DeleteGroupForMAMPolicyWithHttpMessagesAsync(
                    expectedLocation.HostName,
                    expectedPolicyId,
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRespose));

            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(() => true);
           
            // Set the cmdline args and execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.Name = expectedPolicyId;

            this.cmdlet.ExecuteCmdlet();            
        }
    }
}