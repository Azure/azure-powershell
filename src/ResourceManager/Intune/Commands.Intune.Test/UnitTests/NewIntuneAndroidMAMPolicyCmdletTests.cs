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
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Intune.Test
{
    /// <summary>
    ///  Unit Tests for the NewIntuneAndroidMAMPolicy Cmdlet.
    /// </summary>
    public class NewIntuneAndroidMAMPolicyCmdletTests : RMTestBase
    {
        private Mock<IIntuneResourceManagementClientWrapper> intuneClientWrapperMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private NewIntuneAndroidMAMPolicyCmdlet cmdlet;
        private Location mockLocation;

        public NewIntuneAndroidMAMPolicyCmdletTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientWrapperMock = new Mock<IIntuneResourceManagementClientWrapper>();

            cmdlet = new NewIntuneAndroidMAMPolicyCmdlet();
            this.cmdlet.CommandRuntime = commandRuntimeMock.Object;
            this.cmdlet.IntuneClientWrapper = intuneClientWrapperMock.Object;

            // Set-up mock Location and mock the underlying service API method
            mockLocation = new Location() { HostName = "mockHostName" };            
            intuneClientWrapperMock.Setup(f => f.GetLocationByHostName())
                .Returns(mockLocation);
        }
               
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithDefaultArgs_Test()
        {
            // Set expected Policy object
            var expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",
                PinNumRetry = IntuneConstants.DefaultPinRetries,
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessOfflineGracePeriodMinutes),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes),
                OfflineWipeTimeout = TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeIntervalDays),
            };

            AndroidMAMPolicy actualPolicyObj = new AndroidMAMPolicy();

            // Mock the Underlying Service API method
            intuneClientWrapperMock.Setup(f => f.CreateOrUpdateAndroidMAMPolicy(mockLocation.HostName, It.IsAny<string>(), It.IsAny<AndroidMAMPolicy>()))
                .Returns(expectedMAMPolicy).Callback((string hostName, string s, AndroidMAMPolicy pObj) => { actualPolicyObj = pObj; });

            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);
              
            // Set the cmdline args and Execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.FriendlyName = expectedMAMPolicy.FriendlyName;

            this.cmdlet.ExecuteCmdlet();
            
            // Verify the params which are set with Deafult values
            Assert.Equal(expectedMAMPolicy.FriendlyName, actualPolicyObj.FriendlyName);
            Assert.Equal(expectedMAMPolicy.PinNumRetry, actualPolicyObj.PinNumRetry);        
            Assert.Equal(expectedMAMPolicy.OfflineWipeTimeout, actualPolicyObj.OfflineWipeTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOfflineTimeout, actualPolicyObj.AccessRecheckOfflineTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOnlineTimeout, actualPolicyObj.AccessRecheckOnlineTimeout);

            commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Once());        
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithValidArgs_Test()
        {
            // Set up the expected Policy
            var expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",              
                OfflineWipeTimeout = TimeSpan.FromDays(100),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(2),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(3),
            };

            AndroidMAMPolicy actualPolicyObj = new AndroidMAMPolicy();

            intuneClientWrapperMock.Setup(f => f.CreateOrUpdateAndroidMAMPolicy(mockLocation.HostName, It.IsAny<string>(), It.IsAny<AndroidMAMPolicy>()))
                .Returns(expectedMAMPolicy).Callback((string hostName, string s, AndroidMAMPolicy pObj) => { actualPolicyObj = pObj; });

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and Execute the cmdlet
            this.cmdlet.Force = true;
            this.cmdlet.FriendlyName = expectedMAMPolicy.FriendlyName;     
            this.cmdlet.RecheckAccessOfflineGracePeriodMinutes = expectedMAMPolicy.AccessRecheckOfflineTimeout.Value.Minutes;
            this.cmdlet.RecheckAccessTimeoutMinutes = expectedMAMPolicy.AccessRecheckOnlineTimeout.Value.Minutes;
            this.cmdlet.OfflineWipeIntervalDays = expectedMAMPolicy.OfflineWipeTimeout.Value.Days;

            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            Assert.Equal(expectedMAMPolicy.FriendlyName, actualPolicyObj.FriendlyName);
            Assert.Equal(expectedMAMPolicy.OfflineWipeTimeout, actualPolicyObj.OfflineWipeTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOfflineTimeout, actualPolicyObj.AccessRecheckOfflineTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOnlineTimeout, actualPolicyObj.AccessRecheckOnlineTimeout);

            commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithInValidArgs_Test()
        {
            // Set-up the expected Policy
            var expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",
            };

            intuneClientWrapperMock.Setup(f => f.CreateOrUpdateAndroidMAMPolicy(mockLocation.HostName, It.IsAny<string>(), expectedMAMPolicy))
                 .Returns(expectedMAMPolicy);

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set the cmdline args and Execute the cmdlet
            this.cmdlet.FriendlyName = "expectedPolicyFriendlyName";
            this.cmdlet.Force = true;
            this.cmdlet.PinRetries = -1;

            try
            {
                this.cmdlet.ExecuteCmdlet();
            }
            catch (Exception e)
            {
                // Verify the result
                Assert.IsType<PSArgumentOutOfRangeException>(e);
                Assert.Contains("Please specify value greater than or equal to 0", e.ToString());

                commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Never());
            }
        }
    }
}