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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// Initializer for the current Azure session.
    /// </summary>
    public static class AzureSessionInitializer
    {
        /// <summary>
        /// Initialize the azure session if it is not already initialized
        /// </summary>
        public static void InitializeAzureSession()
        {
            AzureSession.Initialize(() => CreateInstance());
        }

        private static IAzureSession CreateInstance()
        {
            var session = new ArmSession
            {
                ClientFactory = null,
                AuthenticationFactory = null,
                DataStore = null,
                OldProfileFile = "WindowsAzureProfile.xml",
                OldProfileFileBackup = "WindowsAzureProfile.xml.bak",
                ProfileDirectory = null,
                ProfileFile = "AzureProfile.json",
                ARMContextSaveMode = null,
                ARMProfileDirectory = null,
                ARMProfileFile = null,
                TokenCacheDirectory = null,
                TokenCacheFile = null,
                TokenCache = null,
            };

            session.RegisterComponent(HttpClientOperationsFactory.Name, () => HttpClientOperationsFactory.Create());
            return session;
        }
    }
}