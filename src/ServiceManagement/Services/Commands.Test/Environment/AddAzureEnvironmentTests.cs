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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Environment
{
    public class AddAzureEnvironmentTests : SMTestBase, IDisposable
    {
        private MemoryDataStore dataStore;

        public AddAzureEnvironmentTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
        }

        public void Cleanup()
        {
            currentProfile = null;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsAzureEnvironment()
        {
            var profile = new AzureSMProfile();
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "endpoint.net",
                ManagementPortalUrl = "management portal url",
                StorageEndpoint = "endpoint.net",
                GalleryEndpoint = "http://galleryendpoint.com",
                Profile = profile
            };
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            ProfileClient client = new ProfileClient(profile);
            AzureEnvironment env = client.GetEnvironmentOrDefault("KaTaL");
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ServiceManagement], cmdlet.ServiceEndpoint);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl], cmdlet.ManagementPortalUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.Gallery], "http://galleryendpoint.com");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentWithMinimumInformation()
        {
            var profile = new AzureSMProfile();
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                EnableAdfsAuthentication = true,
                Profile = profile
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            ProfileClient client = new ProfileClient(profile);
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.True(env.OnPremise);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresAddingDuplicatedEnvironment()
        {
            var profile = new AzureSMProfile();
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
            ProfileClient client = new ProfileClient(profile);
            int count = client.Profile.Environments.Count;

            // Add again
            cmdlet.Name = "kAtAl";
            Testing.AssertThrows<Exception>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentWithStorageEndpoint()
        {
            var profile = new AzureSMProfile();
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                StorageEndpoint = "core.windows.net",
                Profile = profile
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            ProfileClient client = new ProfileClient(profile);
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], actual.PublishSettingsFileUrl);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateEnvironmentWithAllProperties()
        {
            var profile = new AzureSMProfile();
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            AddAzureEnvironmentCommand cmdlet = new AddAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                Profile = profile,
                ActiveDirectoryEndpoint = "ActiveDirectoryEndpoint",
                AdTenant = "AdTenant",
                AzureKeyVaultDnsSuffix = "AzureKeyVaultDnsSuffix",
                ActiveDirectoryServiceEndpointResourceId = "ActiveDirectoryServiceEndpointResourceId",
                AzureKeyVaultServiceEndpointResourceId = "AzureKeyVaultServiceEndpointResourceId",
                EnableAdfsAuthentication = true,
                GalleryEndpoint = "GalleryEndpoint",
                GraphEndpoint = "GraphEndpoint",
                ManagementPortalUrl = "ManagementPortalUrl",
                PublishSettingsFileUrl = "PublishSettingsFileUrl",
                ResourceManagerEndpoint = "ResourceManagerEndpoint",
                ServiceEndpoint = "ServiceEndpoint",
                StorageEndpoint = "StorageEndpoint",
                SqlDatabaseDnsSuffix = "SqlDatabaseDnsSuffix",
                TrafficManagerDnsSuffix = "TrafficManagerDnsSuffix"
            };
            
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.Equal(cmdlet.Name, actual.Name);
            Assert.Equal(cmdlet.EnableAdfsAuthentication.ToBool(), actual.EnableAdfsAuthentication);
            Assert.Equal(cmdlet.ActiveDirectoryEndpoint, actual.ActiveDirectoryAuthority);
            Assert.Equal(cmdlet.ActiveDirectoryServiceEndpointResourceId,
                actual.ActiveDirectoryServiceEndpointResourceId);
            Assert.Equal(cmdlet.AdTenant, actual.AdTenant);
            Assert.Equal(cmdlet.AzureKeyVaultDnsSuffix, actual.AzureKeyVaultDnsSuffix);
            Assert.Equal(cmdlet.AzureKeyVaultServiceEndpointResourceId, actual.AzureKeyVaultServiceEndpointResourceId);
            Assert.Equal(cmdlet.GalleryEndpoint, actual.GalleryUrl);
            Assert.Equal(cmdlet.GraphEndpoint, actual.GraphUrl);
            Assert.Equal(cmdlet.ManagementPortalUrl, actual.ManagementPortalUrl);
            Assert.Equal(cmdlet.PublishSettingsFileUrl, actual.PublishSettingsFileUrl);
            Assert.Equal(cmdlet.ResourceManagerEndpoint, actual.ResourceManagerUrl);
            Assert.Equal(cmdlet.ServiceEndpoint, actual.ServiceManagementUrl);
            Assert.Equal(cmdlet.StorageEndpoint, actual.StorageEndpointSuffix);
            Assert.Equal(cmdlet.SqlDatabaseDnsSuffix, actual.SqlDatabaseDnsSuffix);
            Assert.Equal( cmdlet.TrafficManagerDnsSuffix , actual.TrafficManagerDnsSuffix);
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            ProfileClient client = new ProfileClient(profile);
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}