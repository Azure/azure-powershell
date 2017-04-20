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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ProfileCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;

        public ProfileCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileInMemory()
        {
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
            // Setup
            cmdlt.AzureContext = profile;
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().EnvironmentTable.ContainsKey("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileBadPath()
        {
#pragma warning disable CS0618 // Suppress obsolescence warning: cmdlet name is changing
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
#pragma warning restore CS0618 // Suppress obsolescence warning: cmdlet name is changing
            cmdlt.Path = "z:\non-existent-path\non-existent-file.ext";
            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.MyInvocation.BoundParameters.Add("Path", cmdlt.Path);

            // Act
            cmdlt.InvokeBeginProcessing();
            Assert.Throws<PSArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureProfileFromDisk()
        {
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.Save("X:\\foo.json");
            ImportAzureRMContextCommand cmdlt = new ImportAzureRMContextCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.MyInvocation.BoundParameters.Add("Path", cmdlt.Path);
            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureRmProfileProvider.Instance.Profile.Environments.Any((e) => string.Equals(e.Name, "foo")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileInMemory()
        {
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
#pragma warning disable CS0618 // Suppress obsolescence warning: cmdlet name is changing
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
#pragma warning restore CS0618 // Suppress obsolescence warning: cmdlet name is changing
            // Setup
            cmdlt.Profile = profile;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.Instance.DataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRmProfile("X:\\foo.json");
            Assert.True(profile2.Environments.Any((e) => string.Equals(e.Name, "foo")));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileNull()
        {
#pragma warning disable CS0618 // Suppress obsolescence warning: cmdlet name is changing
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
#pragma warning restore CS0618 // Suppress obsolescence warning: cmdlet name is changing
            // Setup
            AzureRmProfileProvider.Instance.Profile = null;
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            Assert.Throws<ArgumentException>(() => cmdlt.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SaveAzureProfileFromDefault()
        {
            var profile = new AzureRmProfile();
            profile.EnvironmentTable.Add("foo", AzureEnvironment.PublicEnvironments.Values.FirstOrDefault());
            profile.DefaultContext = new AzureContext(new AzureSubscription(), new AzureAccount(), profile.EnvironmentTable["foo"]);
            AzureRmProfileProvider.Instance.Profile = profile;
            SaveAzureRMContextCommand cmdlt = new SaveAzureRMContextCommand();
            // Setup
            cmdlt.Path = "X:\\foo.json";
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(AzureSession.Instance.DataStore.FileExists("X:\\foo.json"));
            var profile2 = new AzureRmProfile("X:\\foo.json");
            Assert.True(profile2.EnvironmentTable.ContainsKey("foo"));
        }
    }
}
