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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Linq;
using System.Management.Automation;
=======
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Runtime.InteropServices;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommunications.Send, "Feedback"), OutputType(typeof(void))]
    public class SendFeedbackCommand : AzureRMCmdlet
    {
        private const string _eventName = "feedback";

        protected override void BeginProcessing()
        {
            //cmdlet is failing due to _metrichelper being null, since we skipped beging processing. 
            base.BeginProcessing(); 

            if (!this.CheckIfInteractive())
                throw new PSInvalidOperationException(String.Format(Resources.SendFeedbackNonInteractiveMessage, nameof(SendFeedbackCommand)));
        }

        public override void ExecuteCmdlet()
        {
<<<<<<< HEAD
            this.WriteQuestion(Resources.SendFeedbackRecommendationQuestion);
            int recommendation;
            if (!int.TryParse(this.Host.UI.ReadLine(), out recommendation) || recommendation < 0 || recommendation > 10)
                throw new PSArgumentOutOfRangeException(Resources.SendFeedbackOutOfRangeMessage);

            this.WriteQuestion(Resources.SendFeedbackPositiveCommentsQuestion);
            var positiveComments = this.Host.UI.ReadLine();

            this.WriteQuestion(Resources.SendFeedbackNegativeCommentsQuestion);
            var negativeComments = this.Host.UI.ReadLine();

            this.WriteQuestion(Resources.SendFeedbackEmailQuestion);
            var email = this.Host.UI.ReadLine();

            var loggedIn = this.DefaultProfile != null
                && this.DefaultProfile.DefaultContext != null
                && DefaultProfile.DefaultContext.Account != null
                && DefaultProfile.DefaultContext.Tenant != null
                && DefaultProfile.DefaultContext.Subscription != null
                && DefaultProfile.DefaultContext.Environment != null;

            var feedbackPayload = new PSAzureFeedback
            {
                ModuleName = this.ModuleName, 
                ModuleVersion = this.ModuleVersion, 
                SubscriptionId = loggedIn ? this.DefaultContext.Subscription.Id : Guid.Empty.ToString(), 
                TenantId = loggedIn ? this.DefaultContext.Tenant.Id : Guid.Empty.ToString(), 
                Environment = loggedIn ? this.DefaultContext.Environment.Name : null, 
                Recommendation = recommendation, 
                PositiveComments = positiveComments, 
                NegativeComments = negativeComments, 
                Email = email
            };

            this.Host.UI.WriteLine();

            // Log the event with force since the user specifically issued this command to provide feedback.

            this._metricHelper.LogCustomEvent(_eventName, feedbackPayload, true /* force */);
=======
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        private void WriteQuestion(string question)
        {
            this.Host.UI.WriteLine(ConsoleColor.Cyan, this.Host.UI.RawUI.BackgroundColor, $"{Environment.NewLine}{question}{Environment.NewLine}");
        }
<<<<<<< HEAD
=======

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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
