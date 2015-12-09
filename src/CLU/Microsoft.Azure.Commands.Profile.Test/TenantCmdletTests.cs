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

using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.ScenarioTest;
using System.Linq;
using Xunit;
using System;
using Microsoft.Azure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TenantCmdletTests
    {
        private MemoryDataStore _dataStore;
        private MockCommandRuntime _commandRuntimeMock;
        private AzureRMProfile _profile;
        private IAuthenticationFactory _authFactory;

        public TenantCmdletTests()
        {
            _dataStore = new MemoryDataStore();
            _commandRuntimeMock = new MockCommandRuntime();
            _profile = new AzureRMProfile();
            _authFactory = new MockTokenAuthenticationFactory("user@contoso.com", Guid.NewGuid().ToString());
        }

        [Fact(Skip = "TODO: Implement HttpMockServer mocks")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithTenantParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.DataStore = _dataStore;
            cmdlt.AuthenticationFactory = _authFactory;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.DefaultProfile = _profile;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();
            
            Assert.True(_commandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Id.ToString());
            Assert.Equal("microsoft.com", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Domain);
        }

        [Fact(Skip = "TODO: Implement HttpMockServer mocks")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithDomainParameter()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.DataStore = _dataStore;
            cmdlt.AuthenticationFactory = _authFactory;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.TenantId = "microsoft.com";
            cmdlt.DefaultProfile = _profile;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(_commandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Id.ToString());
            Assert.Equal("microsoft.com", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Domain);
        }
        
        [Fact(Skip="TODO: Implement HttpMockServer mocks")]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void GetTenantWithoutParameters()
        {
            var cmdlt = new GetAzureRMTenantCommand();
            // Setup
            cmdlt.DataStore = _dataStore;
            cmdlt.AuthenticationFactory = _authFactory;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.DefaultProfile = _profile;

            // Act
            Login("2c224e7e-3ef5-431d-a57b-e71f4662e3a6", null);
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.True(_commandRuntimeMock.OutputPipeline.Count == 2);
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Id.ToString());
            Assert.Equal("microsoft.com", ((AzureTenant)_commandRuntimeMock.OutputPipeline[1]).Domain);
        }

        private void Login(string subscriptionId, string tenantId)
        {
            _authFactory = new MockTokenAuthenticationFactory("foo@user.com", Guid.NewGuid().ToString(), tenantId);
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.SubscriptionId = subscriptionId;
            cmdlt.TenantId = tenantId;
            cmdlt.DefaultProfile = _profile;
            cmdlt.AuthenticationFactory = _authFactory;
            cmdlt.Username = "user@contoso.org";
            cmdlt.Password = "Pa$$w0rd!";

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
        }
    }
}
