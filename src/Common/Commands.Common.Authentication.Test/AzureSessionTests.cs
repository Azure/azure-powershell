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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.IO;
using Newtonsoft.Json;

namespace Common.Authentication.Test
{
    public class AzureSessionTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InitializerCreatesTokenCacheFile()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAzureSession oldSession = null;
            try
            {
                oldSession = AzureSession.Instance;
            }
            catch { }
            try
            {
                var store = new MemoryDataStore();
                var path = Path.Combine(AzureSession.Instance.ARMProfileDirectory, ContextAutosaveSettings.AutoSaveSettingsFile);
                var settings = new ContextAutosaveSettings {Mode=ContextSaveMode.CurrentUser };
                var content = JsonConvert.SerializeObject(settings);
                store.VirtualStore[path] = content;
                AzureSessionInitializer.CreateOrReplaceSession(store);
                var session = AzureSession.Instance;
                var tokenCacheFile = Path.Combine(session.ProfileDirectory, session.TokenCacheFile);
                Assert.True(store.FileExists(tokenCacheFile));

            }
            finally
            {
                AzureSession.Initialize(() => oldSession, true);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TokenCacheIgnoresInvalidData()
        {
            var store = new AzureTokenCache { CacheData = new byte[] { 3, 0, 0, 0, 0, 0, 0, 0 } };
            var cache = new AuthenticationStoreTokenCache(store);
            Assert.NotEqual(cache.CacheData, store.CacheData);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TokenCacheUsesValidData()
        {
            var store = new AzureTokenCache { CacheData = new byte[] { 2, 0, 0, 0, 0, 0, 0, 0 } };
            var cache = new AuthenticationStoreTokenCache(store);
            Assert.Equal(cache.CacheData, store.CacheData);
        }

    }
}
