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
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using IntuneProperties = Microsoft.Azure.Commands.Intune.Properties;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Intune.Test
{
    /// <summary>
    ///  Unit Tests for the RemoveIntuneAndroidMAMPolicy Cmdlet.
    /// </summary> 
    public class RemoveIntuneAndroidMAMPolicyCmdletTests : RMTestBase
    {
        private Mock<IIntuneResourceManagementClientWrapper> intuneClientWrapperMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private RemoveIntuneAndroidMAMPolicyCmdlet cmdlet;
        private Location mockLocation;

        public RemoveIntuneAndroidMAMPolicyCmdletTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientWrapperMock = new Mock<IIntuneResourceManagementClientWrapper>();

            cmdlet = new RemoveIntuneAndroidMAMPolicyCmdlet();
                            
            this.cmdlet.CommandRuntime = commandRuntimeMock.Object;
            this.cmdlet.IntuneClientWrapper = intuneClientWrapperMock.Object;

            // Set-up mock Location and mock the underlying service API method
            mockLocation = new Location() { HostName = "mockHostName" };            
            intuneClientWrapperMock.Setup(f => f.GetLocationByHostName())
                .Returns(mockLocation);
        }
               
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveIntuneAndroidMAMPolicyCmdlet_OneItemDeleted_Test()
        {
            // Set up expected response
            Microsoft.Rest.Azure.AzureOperationResponse expectedRespose = new Microsoft.Rest.Azure.AzureOperationResponse();

            expectedRespose.Response = new System.Net.Http.HttpResponseMessage();
            expectedRespose.Response.StatusCode = System.Net.HttpStatusCode.OK;

            string expectedPolicyId = Guid.NewGuid().ToString();

            // Mock the Underlying Service API method
            intuneClientWrapperMock.Setup(f => f.DeleteAndroidMAMPolicyWithHttpMessagesAsync(mockLocation.HostName, expectedPolicyId))
                .Returns(expectedRespose);

            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);
              
            // Set the cmdline args and Execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.Name = expectedPolicyId;

            this.cmdlet.ExecuteCmdlet();
            
            // Verify the params which are set with Deafult values
            commandRuntimeMock.Verify(f => f.WriteObject(IntuneProperties.Resources.OneItemDeleted), Times.Once());        
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveIntuneAndroidMAMPolicyCmdlet_NoItemDeleted_Test()
        {
            // Set up expected response
            Microsoft.Rest.Azure.AzureOperationResponse expectedRespose = new Microsoft.Rest.Azure.AzureOperationResponse();

            expectedRespose.Response = new System.Net.Http.HttpResponseMessage();
            expectedRespose.Response.StatusCode = System.Net.HttpStatusCode.NoContent;

            string expectedPolicyId = Guid.NewGuid().ToString();

            // Mock the Underlying Service API method
            intuneClientWrapperMock.Setup(f => f.DeleteAndroidMAMPolicyWithHttpMessagesAsync(mockLocation.HostName, expectedPolicyId))
                .Returns(expectedRespose);

            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set the cmdline args and Execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.Name = expectedPolicyId;

            this.cmdlet.ExecuteCmdlet();

            // Verify the params which are set with Deafult values
            commandRuntimeMock.Verify(f => f.WriteObject(IntuneProperties.Resources.NoItemsDeleted), Times.Once());
        }
    }
}