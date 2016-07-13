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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class EnvironmentCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;

        public EnvironmentCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
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
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "endpoint.net",
                ManagementPortalUrl = "management portal url",
                StorageEndpoint = "endpoint.net",
                GalleryEndpoint = "http://galleryendpoint.com",
            };
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            var profileClient = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);
            AzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments["KaTaL"];
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
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                EnableAdfsAuthentication = true,
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            AzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.True(env.OnPremise);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresAddingDuplicatedEnvironment()
        {
            var profile = new AzureSMProfile();
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
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
            cmdlet.ExecuteCmdlet();
            AzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IgnoresAddingPublicEnvironment()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureCloud,
                PublishSettingsFileUrl = "http://microsoft.com"
            };

            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddsEnvironmentWithStorageEndpoint()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
                PublishSettingsFileUrl = "http://microsoft.com",
                StorageEndpoint = "core.windows.net",
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            AzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.StorageEndpointSuffix], actual.StorageEndpointSuffix);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanCreateEnvironmentWithAllProperties()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);
            PSAzureEnvironment actual = null;
            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()))
                .Callback((object output) => actual = (PSAzureEnvironment)output);
            var cmdlet = new AddAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "Katal",
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
                TrafficManagerDnsSuffix = "TrafficManagerDnsSuffix",
                GraphAudience = "GaraphAudience"
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
            Assert.Equal(cmdlet.TrafficManagerDnsSuffix, actual.TrafficManagerDnsSuffix);
            Assert.Equal(cmdlet.GraphAudience, actual.GraphEndpointResourceId);
            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<PSAzureEnvironment>()), Times.Once());
            AzureEnvironment env = AzureRmProfileProvider.Instance.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name, cmdlet.Name);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironments()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            var cmdlet = new GetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(4, environments.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsAzureEnvironment()
        {
            List<PSAzureEnvironment> environments = null;
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(c => c.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback<object, bool>((e, _) => environments = (List<PSAzureEnvironment>)e);

            var cmdlet = new GetAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = EnvironmentName.AzureChinaCloud
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.Equal(1, environments.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsWhenSettingPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);

            foreach (string name in AzureEnvironment.PublicEnvironments.Keys)
            {
                var cmdlet = new SetAzureRMEnvironmentCommand()
                {
                    CommandRuntime = commandRuntimeMock.Object,
                    Name = name,
                    PublishSettingsFileUrl = "http://microsoft.com"
                };
                var savedValue = AzureEnvironment.PublicEnvironments[name].GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl);
                cmdlet.InvokeBeginProcessing();
                Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());
                var newValue = AzureRmProfileProvider.Instance.Profile.Environments[name].GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl);
                Assert.Equal(savedValue, newValue);
                Assert.NotEqual(cmdlet.PublishSettingsFileUrl, newValue);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesAzureEnvironment()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            const string name = "test";
            RMProfileClient client = new RMProfileClient(AzureRmProfileProvider.Instance.Profile);
            client.AddOrSetEnvironment(new AzureEnvironment
            {
                Name = name
            });

            var cmdlet = new RemoveAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = name
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            Assert.False(AzureRmProfileProvider.Instance.Profile.Environments.ContainsKey(name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsForUnknownEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var cmdlet = new RemoveAzureRMEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "test2",
            };

            cmdlet.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThrowsForPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            SetupConfirmation(commandRuntimeMock);

            foreach (string name in AzureEnvironment.PublicEnvironments.Keys)
            {
                var cmdlet = new RemoveAzureRMEnvironmentCommand()
                {
                    CommandRuntime = commandRuntimeMock.Object,
                    Name = name
                };

                cmdlet.InvokeBeginProcessing();
                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());
            }
        }

        public void Dispose()
        {
            Cleanup();
        }
    }
}
