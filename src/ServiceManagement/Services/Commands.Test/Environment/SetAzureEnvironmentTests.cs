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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Profile;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Environment
{
    
    public class SetAzureEnvironmentTests : TestBase, IDisposable
    {
        private MockDataStore dataStore;

        public SetAzureEnvironmentTests()
        {
            dataStore = new MockDataStore();
            ProfileClient.DataStore = dataStore;
        }

        public void Cleanup()
        {
            AzureSession.SetCurrentContext(null, null, null);
        }

        [Fact]
        public void SetsAzureEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            string name = "Katal";
            ProfileClient client = new ProfileClient();
            client.AddOrSetEnvironment(new AzureEnvironment { Name = name });

            SetAzureEnvironmentCommand cmdlet = new SetAzureEnvironmentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Name = "KATaL",
                PublishSettingsFileUrl = "http://microsoft.com",
                ServiceEndpoint = "endpoint.net",
                ManagementPortalUrl = "management portal url",
                StorageEndpoint = "endpoint.net",
                GalleryEndpoint = "galleryendpoint"
            };

            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<AzureEnvironment>()), Times.Once());
            client = new ProfileClient();
            AzureEnvironment env = client.Profile.Environments["KaTaL"];
            Assert.Equal(env.Name.ToLower(), cmdlet.Name.ToLower());
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.PublishSettingsFileUrl], cmdlet.PublishSettingsFileUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ServiceManagement], cmdlet.ServiceEndpoint);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.ManagementPortalUrl], cmdlet.ManagementPortalUrl);
            Assert.Equal(env.Endpoints[AzureEnvironment.Endpoint.Gallery], "galleryendpoint");
        }

        [Fact]
        public void ThrowsWhenSettingPublicEnvironment()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();

            foreach (string name in AzureEnvironment.PublicEnvironments.Keys)
            {
                SetAzureEnvironmentCommand cmdlet = new SetAzureEnvironmentCommand()
                {
                    CommandRuntime = commandRuntimeMock.Object,
                    Name = name,
                    PublishSettingsFileUrl = "http://microsoft.com"
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