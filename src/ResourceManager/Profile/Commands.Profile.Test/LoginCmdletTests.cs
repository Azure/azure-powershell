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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using Xunit;
using System;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Hyak.Common;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LoginCmdletTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        private AzureRMProfile _profile;

        public LoginCmdletTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            _profile = new AzureRMProfile();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("microsoft.com", _profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithInvalidSubscriptionAndTenantThrowsCloudException()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a5";
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSInvalidOperationException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionAndNoTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("microsoft.com", _profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("microsoft.com", _profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithNoSubscriptionAndTenant()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("microsoft.com", _profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithSubscriptionname()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SubscriptionName = "Node CLI Test";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("microsoft.com", _profile.Context.Tenant.Domain);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithBothSubscriptionIdAndNameThrowsCloudException()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            cmdlt.SubscriptionName = "Node CLI Test";
            cmdlt.SubscriptionId = "2c224e7e-3ef5-431d-a57b-e71f4662e3a6";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSInvalidOperationException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithRbacTenantOnly()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            // NOTE: Use owner1@rbactest.onmicrosoft.com credentials for this test case
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.TenantId = "1449d5b7-8a83-47db-ae4c-9b03e888bad0";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal("rbactest.onmicrosoft.com", _profile.Context.Tenant.Domain);
            Assert.Equal(cmdlt.TenantId, _profile.Context.Tenant.Id.ToString());
            Assert.Null(_profile.Context.Subscription);
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void LoginWithRbacSPNAndCertificateOnly()
        {
            var cmdlt = new AddAzureRMAccountCommand();
            // Setup
            // NOTE: Use rbac SPN credentials for this test case
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.ServicePrincipal = true;
            cmdlt.TenantId = "1449d5b7-8a83-47db-ae4c-9b03e888bad0";
            cmdlt.ApplicationId = "20c58db7-4501-44e8-8e76-6febdb400c6b";
            cmdlt.CertificateThumbprint = "F064B7C7EACC942D10662A5115E047E94FA18498";
            cmdlt.DefaultProfile = _profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_profile.Context);
            Assert.Equal(cmdlt.TenantId, _profile.Context.Tenant.Id.ToString());
            Assert.Equal(cmdlt.ApplicationId, _profile.Context.Account.Id.ToString());
            Assert.NotNull(_profile.Context.Subscription);
            Assert.Equal(
                cmdlt.CertificateThumbprint,
                _profile.Context.Account.GetProperty(AzureAccount.Property.CertificateThumbprint));
            
        }
    }
}
