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

namespace Microsoft.Azure.Commands.Common.Test
{
    public class ProfileCmdletTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public ProfileCmdletTests()
        {
            dataStore = new MemoryDataStore();
            AzureSession.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileInMemory()
        {
            var profile = new AzureRMProfile();
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            SelectAzureProfileCommand cmdlt = new SelectAzureProfileCommand();
            // Setup
            cmdlt.Profile = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureRMCmdlet.DefaultProfile.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileNull()
        {
            SelectAzureProfileCommand cmdlt = new SelectAzureProfileCommand();
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileFromDisk()
        {
            var profile = new AzureRMProfile();
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.Save("X:\\foo.json");
            SelectAzureProfileCommand cmdlt = new SelectAzureProfileCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureRMCmdlet.DefaultProfile.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileInMemory()
        {
            var profile = new AzureRMProfile();
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            SaveAzureProfileCommand cmdlt = new SaveAzureProfileCommand();
            // Setup
            cmdlt.Profile = profile;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.DataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRMProfile("X:\\foo.json");
            Assert.True(profile2.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileNull()
        {
            SaveAzureProfileCommand cmdlt = new SaveAzureProfileCommand();
            // Setup
            AzureRMCmdlet.DefaultProfile = null;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileFromDefault()
        {
            var profile = new AzureRMProfile();
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            AzureRMCmdlet.DefaultProfile = profile;
            SaveAzureProfileCommand cmdlt = new SaveAzureProfileCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.DataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRMProfile("X:\\foo.json");
            Assert.True(profile2.Environments.ContainsKey("foo"));
        }
    }
}
