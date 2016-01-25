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

using Microsoft.Azure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Models;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Test.Mocks;
using Microsoft.Azure.Commands.ScenarioTest;
using System.Linq;
using Xunit;
using System;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ProfileCmdletTests : RMTestBase
    {
        private MemoryDataStore _dataStore;
        private MockCommandRuntime _commandRuntimeMock;

        public ProfileCmdletTests()
        {
            _dataStore = new MemoryDataStore();
            _commandRuntimeMock = new MockCommandRuntime();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileInMemory()
        {
            var profile = new AzureRMProfile();
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            SelectAzureRMProfileCommand cmdlt = new SelectAzureRMProfileCommand();
            // Setup
            cmdlt.Profile = profile;
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            Assert.NotNull(_commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, _commandRuntimeMock.OutputPipeline.Count);
            var newProfile = (AzureRMProfile)(_commandRuntimeMock.OutputPipeline[0] as PSAzureProfile) ;
            Assert.NotNull(newProfile);
            // Verify
            Assert.True(newProfile.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileNull()
        {
            SelectAzureRMProfileCommand cmdlt = new SelectAzureRMProfileCommand();
            // Setup
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.DefaultProfile = currentProfile;

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
            cmdlt.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileFromDisk()
        {
            var profile = new AzureRMProfile(_dataStore);
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.Save("X:\\foo.json");
            SelectAzureRMProfileCommand cmdlt = new SelectAzureRMProfileCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();
            var prof = cmdlt.DefaultProfile;

            // Verify
            Assert.True(prof.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileInMemory()
        {
            var profile = new AzureRMProfile(_dataStore);
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            SaveAzureRMProfileCommand cmdlt = new SaveAzureRMProfileCommand();
            // Setup
            cmdlt.Profile = (PSAzureProfile)profile;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.DefaultProfile = currentProfile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(_dataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRMProfile("X:\\foo.json", _dataStore);
            Assert.True(profile2.Environments.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileNull()
        {
            SaveAzureRMProfileCommand cmdlt = new SaveAzureRMProfileCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);

            // Act
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileFromDefault()
        {
            var profile = new AzureRMProfile(_dataStore);
            profile.Environments.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.Context = new AzureContext(new AzureSubscription(), new AzureAccount(), profile.Environments["foo"]);
            SaveAzureRMProfileCommand cmdlt = new SaveAzureRMProfileCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.DataStore = _dataStore;
            cmdlt.SetCommandRuntimeMock(_commandRuntimeMock);
            cmdlt.DefaultProfile = profile;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(_dataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRMProfile("X:\\foo.json", _dataStore);
            Assert.True(profile2.Environments.ContainsKey("foo"));
        }
    }
}
