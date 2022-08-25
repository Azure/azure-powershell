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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.PowerShell.Common.Share.Survey;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Profile.Survey
{
    [Cmdlet(VerbsCommon.Open, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SurveyLink"), OutputType(typeof(void))]
    public class OpenAzSurveyLinkCmdlet : AzurePSCmdlet
    {
        private const string _surveyLinkFormat = "https://go.microsoft.com/fwlink/?linkid=2201766&ID={0}&v={1}&d={2}";

        private static string SurveyScheduleInfoFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".Azure", "AzureRmSurvey.json");

        protected override IAzureContext DefaultContext => null;

        protected override string DataCollectionWarning => null;

        public override void ExecuteCmdlet()
        {   
            StreamReader sr = null;
            DateTime Today = DateTime.UtcNow;
            DateTime LastPromptDate= DateTime.MinValue;
            AzureSession.Instance.ExtendedProperties.TryGetValue("InstallationId", out string InstallationId);
            String Version= AzurePSCmdlet.PowerShellVersion;
            int GapDay = -1;

            if (File.Exists(SurveyScheduleInfoFile))
            {
                sr = new StreamReader(new FileStream(SurveyScheduleInfoFile, FileMode.Open, FileAccess.Read, FileShare.None));                    
                ScheduleInfo scheduleInfo = JsonConvert.DeserializeObject<ScheduleInfo>(sr.ReadToEnd());
                LastPromptDate = Convert.ToDateTime(scheduleInfo?.LastPromptDate);
                sr.Close();
            }
            if (LastPromptDate != DateTime.MinValue){
                TimeSpan ts = Today.Subtract(LastPromptDate);
                GapDay = (int) ts.TotalDays;
            }
            String svLink = String.Format(_surveyLinkFormat, InstallationId, Version, GapDay);
            WriteInformation(new HostInformationMessage() { Message = $"Opening the default browser to {svLink}" }, new string[] { "PSHOST" });
            OpenBrowser(svLink);
        }
        

        private void OpenBrowser(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw new PlatformNotSupportedException(RuntimeInformation.OSDescription);
                }
            }
            catch
            {
            }
        }
    }
}