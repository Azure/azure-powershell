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
using System.Reflection;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Environment
{
    public class AddAzureEnvironmentTests : TestBase, IDisposable
    {
        private MockDataStore dataStore;

        public AddAzureEnvironmentTests()
        {
            dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
        }

        public void Cleanup()
        {
            AzureSession.SetCurrentContext(null, null, null);
        }

        [Fact]
        public void AddsAzureEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "endpoint.net",
                ManagementPortalUrl = "management portal url",
                StorageEndpoint = "endpoint.net",
                GalleryEndpoint = "http://galleryendpoint.com"
            };
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSObject>()), Times.Once());
            ProfileClient client = new ProfileClient();
            AzureEnvironment env = client.GetEnvironmentOrDefault("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ServiceManagement], cmdlet.ServiceEndpoint);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl], cmdlet.ManagementPortalUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.Gallery], "http://galleryendpoint.com");
        }

        [Fact]
        public void AddsEnvironmentWithMinimumInformation()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com"
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSObject>()), Times.Once());
            ProfileClient client = new ProfileClient();
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
        }

        [Fact]
        public void IgnoresAddingDuplicatedEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "endpoint.net",
                ManagementPortalUrl = "management portal url",
                StorageEndpoint = "endpoint.net"
            };
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            ProfileClient client = new ProfileClient();
            int count = client.Profile.Environments.Count;

            // Add again
            cmdlet.Name = "kAtAl";
            Testing.AssertThrows<Exception>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        public void IgnoresAddingPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureCloud,
                PublishSettingsFileUrl = "http://microsoft.com"
            };

            Testing.AssertThrows<Exception>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        public void AddsEnvironmentWithStorageEndpoint()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            PSObject actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback((object output) => actual = (PSObject)output);
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                StorageEndpoint = "core.windows.net"
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSObject>()), Times.Once());
            ProfileClient client = new ProfileClient();
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], actual.GetVariableValue<string>(AzureEnvironment.Endpoint.PublishSettingsFileUrl.ToString()));
        }
        public void Dispose()
        {
            Cleanup();
        }
    }
}