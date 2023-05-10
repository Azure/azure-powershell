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
        protected override IAzureContext DefaultContext => null;

        protected override string DataCollectionWarning => null;

        public override void ExecuteCmdlet()
        {
            DateTime today = DateTime.UtcNow;
            AzureSession.Instance.ExtendedProperties.TryGetValue("InstallationId", out string InstallationId);
            String version= AzurePSCmdlet.AzVersion;
            int gapDays = -1;

            ScheduleInfo scheduleInfo = SurveyHelper.GetInstance().GetScheduleInfo();
            DateTime LastPromptDate = Convert.ToDateTime(scheduleInfo?.LastPromptDate);
            if (LastPromptDate != DateTime.MinValue){
                TimeSpan ts = today.Subtract(LastPromptDate);
                gapDays = (int) ts.TotalDays;
            }
            String svLink = $"https://go.microsoft.com/fwlink/?linkid=2201766&ID={InstallationId}&v={version}&d={gapDays}";
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