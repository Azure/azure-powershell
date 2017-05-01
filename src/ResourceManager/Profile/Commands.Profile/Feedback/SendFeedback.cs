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

using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile
{
    [Cmdlet(VerbsCommunications.Send, "Feedback"), OutputType(typeof(void))]
    public class SendFeedbackCommand : AzureRMCmdlet
    {
        private const string _eventName = "feedback";

        protected override void BeginProcessing()
        {
            // Do not call base.BeginProcessing(), as context is not required for this cmdlet.

            if (!this.CheckIfInteractive())
                throw new PSInvalidOperationException(String.Format(Resources.SendFeedbackNonInteractiveMessage, nameof(SendFeedbackCommand)));
        }

        public override void ExecuteCmdlet()
        {
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

            var loggedIn = this.DefaultProfile != null && this.DefaultProfile.Context != null;

            var feedbackPayload = new PSAzureFeedback
            {
                ModuleName = this.ModuleName, 
                ModuleVersion = this.ModuleVersion, 
                SubscriptionId = loggedIn ? this.DefaultContext.Subscription.Id : Guid.Empty, 
                TenantId = loggedIn ? this.DefaultContext.Tenant.Id : Guid.Empty, 
                Environment = loggedIn ? this.DefaultContext.Environment.Name : null, 
                Recommendation = recommendation, 
                PositiveComments = positiveComments, 
                NegativeComments = negativeComments, 
                Email = email
            };

            this.Host.UI.WriteLine();

            // Log the event with force since the user specifically issued this command to provide feedback.
            this._metricHelper.LogCustomEvent(_eventName, feedbackPayload, true /* force */);
        }

        private void WriteQuestion(string question)
        {
            this.Host.UI.WriteLine(ConsoleColor.Cyan, this.Host.UI.RawUI.BackgroundColor, $"{Environment.NewLine}{question}{Environment.NewLine}");
        }
    }
}
