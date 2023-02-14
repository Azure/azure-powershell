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
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;

namespace Microsoft.Azure.Commands.Profile.Test
{
    internal class AzureSessionTestInitializer
    {
        public static void Initialize()
        {
            AzureSession.Instance.DataStore = new MemoryDataStore();
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();

            PowerShellTokenCacheProvider tokenCacheProvider = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => tokenCacheProvider);
            IAuthenticatorBuilder builder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => builder);
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => new AzureCredentialFactory());
            AzureSession.Instance.RegisterComponent(nameof(MsalAccessTokenAcquirerFactory), () => new MsalAccessTokenAcquirerFactory());
        }

    }
}
