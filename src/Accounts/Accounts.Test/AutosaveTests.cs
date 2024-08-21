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
using Microsoft.Azure.ServiceManagement.Common.Models;
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
using Microsoft.Azure.Commands.TestFx.Mocks;
using Moq;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class AutosaveTests
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        private AzKeyStore keyStore;
        public AutosaveTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            commandRuntimeMock = new MockCommandRuntime();
            dataStore = new MemoryDataStore();
            ResetState();
            keyStore = SetMockedAzKeyStore();
        }

        private AzKeyStore SetMockedAzKeyStore()
        {
            var storageMocker = new Mock<IStorage>();
            storageMocker.Setup(f => f.Create()).Returns(storageMocker.Object);
            storageMocker.Setup(f => f.ReadData()).Returns(new byte[0]);
            storageMocker.Setup(f => f.WriteData(It.IsAny<byte[]>())).Callback((byte[] s) => {});
            var keyStore = new AzKeyStore(AzureSession.Instance.ARMProfileDirectory, "azkeystore", true, storageMocker.Object);
            return keyStore;
        }

        void ResetState()
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            ResourceManagerProfileProvider.InitializeResourceManagerProfile(true);
            // prevent token acquisition
            AzureRmProfileProvider.Instance.GetProfile<AzureRmProfile>().ShouldRefreshContextsFromCache = false;
            AzureSession.Instance.DataStore = dataStore;
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            Environment.SetEnvironmentVariable("Azure_PS_Data_Collection", "false");
            PowerShellTokenCacheProvider tokenProvider = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => tokenProvider, true);
            AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => keyStore, true);
            if (!AzureSession.Instance.TryGetComponent(nameof(AuthenticationTelemetry), out AuthenticationTelemetry authenticationTelemetry))
            {
                AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(nameof(AuthenticationTelemetry), () => new AuthenticationTelemetry());
            }
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
                Assert.Equal(typeof(ProtectedProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            catch (PlatformNotSupportedException)
            {
                // swallow exception when test env (Linux server) doesn't support token cache persistence
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
                Assert.Equal(typeof(ProtectedProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            catch (PlatformNotSupportedException)
            {
                // swallow exception when test env (Linux server) doesn't support token cache persistence
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
                Assert.True(AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out PowerShellTokenCacheProvider factory));
                Assert.Equal(typeof(InMemoryTokenCacheProvider), factory.GetType());
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
                Assert.True(AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out PowerShellTokenCacheProvider factory));
                Assert.Equal(typeof(InMemoryTokenCacheProvider), factory.GetType());
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
            }
            finally
            {
                ResetState();
            }
        }
    }
}
