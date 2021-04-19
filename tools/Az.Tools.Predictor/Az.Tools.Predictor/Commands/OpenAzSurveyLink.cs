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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// <para type="synopsis">Cmdlet to open a survey link in the default browser</para>
    /// <para type="description">Use this cmdlet to open a survey link in the default browser</para>
    /// </summary>
    [Cmdlet("Open", "AzSurveyLink"), OutputType(typeof(bool))]
    public sealed class OpenAzSurveyLink : PSCmdlet
    {
        private const string _SurveyLinkFormat = "https://aka.ms/azpredictorisurvey?SessionId={0}&from=cmdlet";
        /// <summary>
        /// <para type="description">Indicates whether the user would like to receive output. </para>
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <inheritdoc/>
        protected override void ProcessRecord()
        {
            var profileSettings = Settings.GetProfileSettings();
            var surveyId = profileSettings?.SurveyId?.ToString(CultureInfo.InvariantCulture) ?? "000000";

            var link = string.Format(OpenAzSurveyLink._SurveyLinkFormat, surveyId, CultureInfo.InvariantCulture);

            Console.WriteLine($"Opening survey {link}");

            // TODO [mahuang] Ouput the link for user to copy/paste in case it's not open in the default browser.
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = link;
            processStartInfo.UseShellExecute = true;

            Process.Start(processStartInfo);

            if (profileSettings != null)
            {
                profileSettings.SurveyId = null;

                try
                {
                    var fileContent = JsonSerializer.Serialize<Settings>(profileSettings, new JsonSerializerOptions(JsonUtilities.DefaultSerializerOptions)
                        {
                            WriteIndented = true,
                        });
                    var profileSettingFilePath = Settings.GetProfileSettingsFilePath();
                    File.WriteAllText(profileSettingFilePath, fileContent, Encoding.UTF8);
                }
                catch
                {
                    // Ignore all exceptions.
                }
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
