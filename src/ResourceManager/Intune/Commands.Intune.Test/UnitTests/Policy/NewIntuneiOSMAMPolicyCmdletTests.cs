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
    ///  Unit Tests for the NewIntuneIOSMAMPolicy Cmdlet.
    /// </summary>
    public class NewIntuneiOSMAMPolicyCmdletTests
    {
        private Mock<IIntuneResourceManagementClient> intuneClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private NewIntuneiOSMAMPolicyCmdlet cmdlet;
        private Location expectedLocation;

        /// <summary>
        ///  C'tor for NewIntuneiOSMAMPolicyCmdletTests class.
        /// </summary>
        public NewIntuneiOSMAMPolicyCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            intuneClientMock = new Mock<IIntuneResourceManagementClient>();

            cmdlet = new NewIntuneiOSMAMPolicyCmdlet();
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
        public void NewIntuneiOSMAMPolicy_WithDefaultArgs_Test()
        {
            AzureOperationResponse<IOSMAMPolicy> resIosPolicy = new AzureOperationResponse<IOSMAMPolicy>();

            // Set expected Policy object
            var expectedMAMPolicy = new IOSMAMPolicy()
            {   
                FriendlyName = "expectedPolicyFriendlyName",
                PinNumRetry = IntuneConstants.DefaultPinNumRetry,
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultAccessRecheckOfflineTimeout),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultAccessRecheckOnlineTimeout),
                OfflineWipeTimeout = TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeTimeout),
            };

            resIosPolicy.Body = expectedMAMPolicy;

            IOSMAMPolicy actualPolicyObj = new IOSMAMPolicy();

            // Mock the Underlying Service API method
            intuneClientMock.Setup(f => f.Ios.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IOSMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resIosPolicy)).Callback((string hostName, string s, IOSMAMPolicy pObj, Dictionary<string, List<string>> dict, CancellationToken cTkn) => { actualPolicyObj = pObj; });
            
            // Mock the PowerShell RunTime method
            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);
              
            // Set the cmdline args and execute the cmdlet            
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
        /// Test for Non-default valid args.
        /// </summary>   
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewIntuneiOSMAMPolicy_WithValidArgs_Test()
        {
            // Set up the expected Policy
            var resPolicy = new AzureOperationResponse<IOSMAMPolicy>();

            var expectedMAMPolicy = new IOSMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",              
                OfflineWipeTimeout = TimeSpan.FromDays(100),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(2),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(3),
            };

            resPolicy.Body = expectedMAMPolicy;

            IOSMAMPolicy actualPolicyObj = new IOSMAMPolicy();

            intuneClientMock.Setup(f => f.Ios.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IOSMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resPolicy)).Callback((string hostName, string s, IOSMAMPolicy pObj, Dictionary<string, List<string>> dict, CancellationToken cTkn) => { actualPolicyObj = pObj; });

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set cmdline args and execute the cmdlet            
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
        public void NewIntuneiOSMAMPolicy_WithInValidArgs_Test()
        {
            // Set-up the expected Policy
            var resIosPolicy = new AzureOperationResponse<IOSMAMPolicy>();
            
            var expectedMAMPolicy = new IOSMAMPolicy()
            {
                FriendlyName = "expectedPolicyFriendlyName",
            };

            intuneClientMock.Setup(f => f.Ios.CreateOrUpdateMAMPolicyWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IOSMAMPolicy>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(resIosPolicy));

            commandRuntimeMock.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            // Set the cmdline args and execute the cmdlet
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