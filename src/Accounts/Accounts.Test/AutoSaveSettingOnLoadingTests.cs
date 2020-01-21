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
// ---------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Core;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class AutoSaveSettingOnLoadingTests
    {
        private MemoryDataStore dataStore;
        private string profileBasePath;
        private string settingsPath;

        public AutoSaveSettingOnLoadingTests(ITestOutputHelper output)
        {
            dataStore = new MemoryDataStore();
            profileBasePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            settingsPath = Path.Combine(profileBasePath, Resources.AzureDirectoryName);
            settingsPath = Path.Combine(settingsPath, ContextAutosaveSettings.AutoSaveSettingsFile);
        }

        internal string HookSettingFile(string hook)
        {
            var result = new ContextAutosaveSettings
            {
                CacheDirectory = hook,
                ContextDirectory = hook,
                Mode = ContextSaveMode.CurrentUser,
                CacheFile = "TokenCache.dat",
                ContextFile = "AzureRmContext.json"
            };

            var backupPath = String.Empty;
            if (!dataStore.FileExists(settingsPath))
            {
                string directoryPath = Path.GetDirectoryName(settingsPath);
                if (!dataStore.DirectoryExists(directoryPath))
                {
                    dataStore.CreateDirectory(directoryPath);
                }
            }
            else
            {
                backupPath = BackupSetting();
            }
            dataStore.WriteFile(settingsPath, JsonConvert.SerializeObject(result));
            return backupPath;
        }

        internal string BackupSetting()
        {
            var backupPath = settingsPath + ".bak";
            dataStore.CopyFile(settingsPath, backupPath);
            return backupPath;
        }

        internal void RestoreSetting(string backupPath)
        {
            if(dataStore.FileExists(backupPath))
            {
                dataStore.DeleteFile(settingsPath);
                dataStore.CopyFile(backupPath, settingsPath);
                dataStore.DeleteFile(backupPath);
            }
            else
            {
                dataStore.DeleteFile(settingsPath);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAutoSaveWhenSettingFileBreaks()
        {
            string faker = Path.Combine(Directory.GetParent(profileBasePath).ToString(), "faker");
            faker = Path.Combine(faker,Resources.AzureDirectoryName);
            var backupPath = HookSettingFile(faker);

            try
            {
                AzureSessionInitializer.CreateOrReplaceSession(dataStore);
                TestMockSupport.RunningMocked = true;
                var cmdlet = new ConnectAzureRmAccountCommand();
                cmdlet.OnImport();
                Assert.Equal(ContextSaveMode.Process, AzureSession.Instance.ARMContextSaveMode);
                Assert.Equal(typeof(ResourceManagerProfileProvider), AzureRmProfileProvider.Instance.GetType());
                var afterModified = dataStore.ReadFileAsText(settingsPath);
                var newSetting = JsonConvert.DeserializeObject<ContextAutosaveSettings>(afterModified) as ContextAutosaveSettings;
                Assert.NotNull(newSetting);
                Assert.Equal(ContextSaveMode.CurrentUser, newSetting.Mode);
                Assert.Equal(typeof(AuthenticationStoreTokenCache), AzureSession.Instance.TokenCache.GetType());
            }
            finally
            {
                RestoreSetting(backupPath);
            }
        }
    }
}
