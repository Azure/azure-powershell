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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using Microsoft.Azure.Commands.Profile.Context;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class AutosaveTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        public AutosaveTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new MockCommandRuntime();
            dataStore = new MemoryDataStore();
            ResetState();
        }

        void ResetState()
        {

            TestExecutionHelpers.SetUpSessionAndProfile();
            ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
            AzureSession.Instance.DataStore = dataStore;
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            AzureSession.Instance.TokenCache = new AuthenticationStoreTokenCache(new AzureTokenCache());
            Environment.SetEnvironmentVariable("Azure_PS_Data_Collection", "false");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAutosaveWhenDisabled()
        {
            ResetState();
            try
            {
                var cmdlet = new EnableAzureRmContextAutosave();
                cmdlet.Scope = Commands.Profile.Common.ContextModificationScope.Process;
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();
                Assert.Equal(ContextSaveMode.CurrentUser, AzureSession.Instance.ARMContextSaveMode);
                Assert.Equal(typeof(ProtectedFileTokenCache), AzureSession.Instance.TokenCache.GetType());
                Assert.Equal(typeof(ProtectedProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAutosaveWhenEnabled()
        {
            ResetState();
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.CurrentUser;
            try
            {
                var cmdlet = new EnableAzureRmContextAutosave();
                cmdlet.Scope = Commands.Profile.Common.ContextModificationScope.Process;
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();
                Assert.Equal(ContextSaveMode.CurrentUser, AzureSession.Instance.ARMContextSaveMode);
                Assert.Equal(typeof(ProtectedFileTokenCache), AzureSession.Instance.TokenCache.GetType());
                Assert.Equal(typeof(ProtectedProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            finally
            {
                ResetState();
            }

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAutosaveWhenEnabled()
        {
            ResetState();
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.CurrentUser;
            try
            {
                var cmdlet = new DisableAzureRmContextAutosave();
                cmdlet.Scope = Commands.Profile.Common.ContextModificationScope.Process;
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();
                Assert.Equal(ContextSaveMode.Process, AzureSession.Instance.ARMContextSaveMode);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), AzureSession.Instance.TokenCache.GetType());
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            finally
            {
                ResetState();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAutoSsaveWhenDisabled()
        {
            ResetState();
            try
            {
                var cmdlet = new DisableAzureRmContextAutosave();
                cmdlet.Scope = Commands.Profile.Common.ContextModificationScope.Process;
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();
                Assert.Equal(ContextSaveMode.Process, AzureSession.Instance.ARMContextSaveMode);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), AzureSession.Instance.TokenCache.GetType());
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            finally
            {
                ResetState();
            }
        }
    }
}
