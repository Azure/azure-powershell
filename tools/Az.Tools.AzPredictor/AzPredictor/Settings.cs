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

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Text;

namespace Microsoft.Azure.PowerShell.AzPredictor
{
    /// <summary>
    /// Represents the settings used in AzPredictor.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    sealed class Settings
    {
        private static Settings _instance;

        /// <summary>
        /// The service to get the prediction results back.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string ServiceUri { get; set; }

        /// <summary>
        /// Gets an instance of the settings.
        /// </summary>
        public static Settings GetSettings()
        {
            if (Settings._instance == null)
            {
                var settings = CreateDefaultSettings();
                settings.OverrideSettingsFromProfile();
                settings.OverrideSettingsFromEnv();

                Settings._instance = settings;
            }

            return Settings._instance;
        }

        private static Settings CreateDefaultSettings()
        {
            var fileInfo = new FileInfo(typeof(Settings).Assembly.Location);
            var directory = fileInfo.DirectoryName;
            var settingFilePath = Path.Join(directory, AzPredictorConstants.SettingsFileName);
            var fileContent = File.ReadAllText(settingFilePath, Encoding.UTF8);
            var settings = JsonConvert.DeserializeObject<Settings>(fileContent);

            return settings;
        }

        private void OverrideSettingsFromProfile()
        {
            string homePath = null;
            var platform = Environment.OSVersion.Platform;

            if (platform == PlatformID.Unix)
            {
                homePath = Environment.GetEnvironmentVariable("$HOME");
            }
            else
            {
                homePath = Path.Join(Environment.GetEnvironmentVariable("HOMEDRIVE"), Environment.GetEnvironmentVariable("HOMEPATH"));
            }

            string profileDirectoryPath = Path.Join(homePath, AzPredictorConstants.AzureProfileDirectoryName);
            string profileSettingFilePath = Path.Join(profileDirectoryPath, AzPredictorConstants.SettingsFileName);
            var fileContent = File.ReadAllText(profileSettingFilePath, Encoding.UTF8);
            var profileSettings = JsonConvert.DeserializeObject<Settings>(fileContent);

            if (!string.IsNullOrWhiteSpace(profileSettings.ServiceUri))
            {
                this.ServiceUri = profileSettings.ServiceUri;
            }
        }

        private void OverrideSettingsFromEnv()
        {
            var serviceUri = System.Environment.GetEnvironmentVariable("ServiceUri");

            if (!string.IsNullOrWhiteSpace(serviceUri))
            {
                this.ServiceUri = serviceUri;
            }
        }
    }
}
