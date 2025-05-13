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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;

using Moq;

using System;
using System.IO;

using Xunit.Abstractions;

using static Microsoft.Azure.Commands.Common.Authentication.AzureSessionInitializer;

namespace Microsoft.Azure.Commands.Common.Authentication.Test.Mocks
{
    public abstract class MockAuthenticationTestBase
    {
        protected Mock<AzKeyStore> mockKeyStore;
        protected Mock<IAzureTokenCache> mockTokenCache;
        protected Mock<AzureCredentialFactory> mockAzureCredentialFactory;
        protected IAzureSession originalInstance;

        public ITestOutputHelper _output;
        public MockAuthenticationTestBase(ITestOutputHelper output)
        {
            _output = output;

            mockTokenCache = new Mock<IAzureTokenCache>();
            mockKeyStore = new Mock<AzKeyStore>(string.Empty, string.Empty, true, null);
            mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
        }

        static IAzureSession CreateInstance()
        {
            var profilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".Azure");
            var dataStore = new MemoryDataStore();
            var session = new AdalSession
            {
                DataStore = dataStore,
                ProfileDirectory = profilePath,
                ProfileFile = "AzureProfile.json",
                TokenCacheDirectory = MsalCacheHelperProvider.MsalTokenCachePath,
                TokenCacheFile = MsalCacheHelperProvider.GetTokenCacheName(MsalCacheHelperProvider.LegacyTokenCacheName, caeEnabled: true)
            };

            session.TokenCache = session.TokenCache ?? new AzureTokenCache();
            return session;
        }

        public void InitializeSession(string dummyToken)
        {
            var mockAzureSession = CreateInstance();
            AzureSession.Initialize(() => mockAzureSession, true);

            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => (IAuthenticatorBuilder)new DefaultAuthenticatorBuilder());
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => (PowerShellTokenCacheProvider)new InMemoryTokenCacheProvider());
            AzureSession.Instance.RegisterComponent(nameof(MsalAccessTokenAcquirerFactory), () => new MsalAccessTokenAcquirerFactory());
            AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(AuthenticationTelemetry.Name, () => new AuthenticationTelemetry());
        }
    }
}
