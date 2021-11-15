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

using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// Represents the settings used in AzPredictor.
    /// </summary>
    sealed class Settings
    {
        private static Settings _instance;

        /// <summary>
        /// The maximum number of suggestions that have the same command name.
        /// </summary>
        public int? MaxAllowedCommandDuplicate { get; set; }

        /// <summary>
        /// The service to get the prediction results back.
        /// </summary>
        public string ServiceUri { get; set; }

        /// <summary>
        /// Set the user as an internal user.
        /// </summary>
        public bool? SetAsInternal { get; set; }

        /// <summary>
        /// The number of suggestions to return to PSReadLine.
        /// </summary>
        public int? SuggestionCount { get; set; }

        /// <summary>
        /// The survey id. It should be internal but make it public so that we can read/write to Json.
        /// </summary>
        public int? SurveyId { get; set; }

        private static bool? _isContinueOnTimeout;
        /// <summary>
        /// Gets the value to indicate whether to ignore cancellation request and keep running.
        /// This should be only set during debugging.
        /// </summary>
        [JsonIgnore]
        internal static bool ContinueOnTimeout
        {
            get
            {
                if (_isContinueOnTimeout.HasValue)
                {
                    return _isContinueOnTimeout.Value;
                }

                var envValue = Environment.GetEnvironmentVariable("AzPredictorContinueOnTimeout");

                if (bool.TryParse(envValue, out bool envBoolValue))
                {
                    _isContinueOnTimeout = envBoolValue;
                }
                else
                {
                    _isContinueOnTimeout = false;
                }

                return _isContinueOnTimeout.Value;
            }
        }

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

        /// <summary>
        /// Gets the settings from the user profile folder.
        /// </summary>
        internal static Settings GetProfileSettings()
        {
            string profileSettingFilePath = Settings.GetProfileSettingsFilePath();

            if (File.Exists(profileSettingFilePath))
            {
                try
                {
                    var fileContent = File.ReadAllText(profileSettingFilePath, Encoding.UTF8);
                    return JsonSerializer.Deserialize<Settings>(fileContent, JsonUtilities.DefaultSerializerOptions);
                }
                catch
                {
                    // Ignore all the exception
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the file path of the settings in the user profile folder.
        /// </summary>
        internal static string GetProfileSettingsFilePath()
        {
            var userProfileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string profileDirectoryPath = Path.Join(userProfileDirectory, AzPredictorConstants.AzureProfileDirectoryName);
            return Path.Join(profileDirectoryPath, AzPredictorConstants.SettingsFileName);
        }

        private static Settings CreateDefaultSettings()
        {
            var fileInfo = new FileInfo(typeof(Settings).Assembly.Location);
            var directory = fileInfo.DirectoryName;
            var settingFilePath = Path.Join(directory, AzPredictorConstants.SettingsFileName);
            var fileContent = File.ReadAllText(settingFilePath, Encoding.UTF8);
            var settings = JsonSerializer.Deserialize<Settings>(fileContent, JsonUtilities.DefaultSerializerOptions);

            return settings;
        }

        private void OverrideSettingsFromProfile()
        {
            var profileSettings = Settings.GetProfileSettings();

            if (profileSettings != null)
            {
                if (!string.IsNullOrWhiteSpace(profileSettings.ServiceUri))
                {
                    ServiceUri = profileSettings.ServiceUri;
                }

                if (profileSettings.SuggestionCount.HasValue && (profileSettings.SuggestionCount.Value > 0))
                {
                    SuggestionCount = profileSettings.SuggestionCount;
                }

                if (profileSettings.MaxAllowedCommandDuplicate.HasValue && (profileSettings.MaxAllowedCommandDuplicate.Value > 0))
                {
                    this.MaxAllowedCommandDuplicate = profileSettings.MaxAllowedCommandDuplicate;
                }

                this.SetAsInternal = profileSettings.SetAsInternal;
                this.SurveyId = profileSettings.SurveyId;
            }
        }

        private void OverrideSettingsFromEnv()
        {
            var serviceUri = System.Environment.GetEnvironmentVariable("AzPredictorServiceUri");

            if (!string.IsNullOrWhiteSpace(serviceUri))
            {
                ServiceUri = serviceUri;
            }
        }
    }
}
