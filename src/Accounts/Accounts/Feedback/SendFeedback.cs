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

using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommunications.Send, "Feedback"), OutputType(typeof(void))]
    public class SendFeedbackCommand : AzureRMCmdlet
    {
        private const string _eventName = "feedback";

        protected override void BeginProcessing()
        {
            //cmdlet is failing due to _metrichelper being null, since we skipped begin processing. 
            base.BeginProcessing(); 

            if (!this.CheckIfInteractive())
                throw new PSInvalidOperationException(String.Format(Resources.SendFeedbackNonInteractiveMessage, nameof(SendFeedbackCommand)));
        }

        public override void ExecuteCmdlet()
        {
            this.WriteQuestion(AzureProfileConstants.AzurePowerShellFeedbackQuestion);
            var yesOrNo = this.Host.UI.ReadLine();
            if(0 == String.Compare(yesOrNo, "yes", true) || 0 == String.Compare(yesOrNo, "y", true))
            {
                if (OpenBrowser(AzureProfileConstants.AzureSurveyUrl))
                {
                    this.Host.UI.WriteLine();
                    return;
                }
                this.Host.UI.WriteLine();
                this.WriteWarning($"{AzureProfileConstants.AzurePowerShellFeedbackWarning}{Environment.NewLine}");
                return;
            }
            this.Host.UI.WriteLine(this.Host.UI.RawUI.ForegroundColor, this.Host.UI.RawUI.BackgroundColor, $"{Environment.NewLine}{AzureProfileConstants.AzurePowerShellFeedbackManually}{Environment.NewLine}");
        }

        private void WriteQuestion(string question)
        {
            this.Host.UI.WriteLine(ConsoleColor.Cyan, this.Host.UI.RawUI.BackgroundColor, $"{Environment.NewLine}{question}{Environment.NewLine}");
        }

        //This method was moved from AzurePSCmdlet
        private bool CheckIfInteractive()
        {
            bool interactive = true;
            if (this.Host?.UI?.RawUI == null ||
                Environment.GetCommandLineArgs().Any(s =>
                    s.Equals("-NonInteractive", StringComparison.OrdinalIgnoreCase)))
            {
                interactive = false;
            }
            else
            {
                try
                {
                    var test = this.Host.UI.RawUI.KeyAvailable;
                }
                catch
                {
                    interactive = false;
                }
            }
            return interactive;
        }

        private bool OpenBrowser(string url)
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
                return false;
            }

            return true;
        }
    }
}
