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
    ///  Unit Tests for the NewIntuneAndroidMAMPolicy Cmdlet.
    /// </summary>
    public class NewIntuneAndroidMAMPolicyCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private NewIntuneAndroidMAMPolicyCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for NewIntuneAndroidMAMPolicyCmdletTests class.
        /// </summary>
        public NewIntuneAndroidMAMPolicyCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new NewIntuneAndroidMAMPolicyCmdlet();
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
        /// Test for default args.
        /// </summary>       
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithDefaultArgs_Test()
        {
            // Set expected Policy object
            var resPolicy = new AzureOperationResponse<AndroidMAMPolicy>();

            var expectedMAMPolicy = new AndroidMAMPolicy()
            {   
                FriendlyName = "expectedPolicyFriendlyName",
                PinNumRetry = IntuneConstants.DefaultPinNumRetry,
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultAccessRecheckOfflineTimeout),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultAccessRecheckOnlineTimeout),
                OfflineWipeTimeout = TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeTimeout),
            };
          
            resPolicy.Body = expectedMAMPolicy;

            AndroidMAMPolicy actualPolicyObj = new AndroidMAMPolicy();

            // Set up mock methods
            intuneClientMock.Setup(f => f.Android.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AndroidMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resPolicy)).Callback((string hostName, string s, AndroidMAMPolicy pObj, Dictionary<string, List<string>> dict, CancellationToken cTkn ) => { actualPolicyObj = pObj; });
            
            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);
              
            // Set the cmdline args and Execute the cmdlet            
            this.cmdlet.FriendlyName = expectedMAMPolicy.FriendlyName;

            this.cmdlet.ExecuteCmdlet();
            
            // Verify the params which are set with Default values
            Assert.Equal(expectedMAMPolicy.FriendlyName, actualPolicyObj.FriendlyName);
            Assert.Equal(expectedMAMPolicy.Name, actualPolicyObj.Id);
            Assert.Equal(expectedMAMPolicy.Id, actualPolicyObj.Name);
            Assert.Equal(expectedMAMPolicy.PinNumRetry, actualPolicyObj.PinNumRetry);        
            Assert.Equal(expectedMAMPolicy.OfflineWipeTimeout, actualPolicyObj.OfflineWipeTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOfflineTimeout, actualPolicyObj.AccessRecheckOfflineTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOnlineTimeout, actualPolicyObj.AccessRecheckOnlineTimeout);

            commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Once());        
        }

        /// <summary>
        /// Test for valid args.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithValidArgs_Test()
        {  
            // Set up the expected Policy
            AzureOperationResponse<AndroidMAMPolicy> resPolicy = new AzureOperationResponse<AndroidMAMPolicy>();

            var expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",              
                OfflineWipeTimeout = TimeSpan.FromDays(100),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(2),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(3),
            };

            resPolicy.Body = expectedMAMPolicy;
            
            AndroidMAMPolicy actualPolicyObj = new AndroidMAMPolicy();

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AndroidMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
               .Returns(Task.FromResult(resPolicy)).Callback((string hostName, string s, AndroidMAMPolicy pObj, Dictionary<string, List<string>> dict, CancellationToken cTkn) => { actualPolicyObj = pObj; });
           
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and Execute the cmdlet            
            this.cmdlet.FriendlyName = expectedMAMPolicy.FriendlyName;     
            this.cmdlet.AccessRecheckOfflineTimeout = expectedMAMPolicy.AccessRecheckOfflineTimeout.Value.Minutes;
            this.cmdlet.AccessRecheckOnlineTimeout = expectedMAMPolicy.AccessRecheckOnlineTimeout.Value.Minutes;
            this.cmdlet.OfflineWipeTimeout = expectedMAMPolicy.OfflineWipeTimeout.Value.Days;

            this.cmdlet.ExecuteCmdlet();

            // Verify the result
            Assert.Equal(expectedMAMPolicy.FriendlyName, actualPolicyObj.FriendlyName);
            Assert.Equal(expectedMAMPolicy.OfflineWipeTimeout, actualPolicyObj.OfflineWipeTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOfflineTimeout, actualPolicyObj.AccessRecheckOfflineTimeout);
            Assert.Equal(expectedMAMPolicy.AccessRecheckOnlineTimeout, actualPolicyObj.AccessRecheckOnlineTimeout);

            commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Once());
        }

        /// <summary>
        /// Test for invalid args.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneAndroidMAMPolicyCmdlet_WithInValidArgs_Test()
        {
            // Set-up the expected Policy
            AzureOperationResponse<AndroidMAMPolicy> resPolicy = new AzureOperationResponse<AndroidMAMPolicy>();

            var expectedMAMPolicy = new AndroidMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",
            };

            resPolicy.Body = expectedMAMPolicy;

            // Set up the mock methods
            intuneClientMock.Setup(f => f.Android.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AndroidMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
               .Returns(Task.FromResult(resPolicy));
           
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set the cmdline args and Execute the cmdlet
            this.cmdlet.FriendlyName = "expectedPolicyFriendlyName";            
            this.cmdlet.PinNumRetry = -1;

            try
            {
                this.cmdlet.ExecuteCmdlet();
            }
            catch (Exception e)
            {
                // Verify the result
                Assert.IsType<PSArgumentOutOfRangeException>(e);
                commandRuntimeMock.Verify(f => f.WriteObject(expectedMAMPolicy), Times.Never());
            }
        }
    }
}