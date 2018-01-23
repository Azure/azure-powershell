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

using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.ActionGroups
{
    /// <summary>
    /// Create an ActionGroup receiver
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmActionGroupReceiver", DefaultParameterSetName = NewEmailReceiver)]
    [OutputType(typeof(PSActionGroupReceiverBase))]
    public class NewAzureRmActionGroupReceiverCommand : AzureRMCmdlet
    {
        private const string NewEmailReceiver = "NewEmailReceiver";

        private const string NewSmsReceiver = "NewSmsReceiver";

        private const string NewWebhookReceiver = "NewWebhookReceiver";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the Name parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the receiver")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets email receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewEmailReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a email receiver")]
        public SwitchParameter EmailReceiver { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress parameter
        /// </summary>
        [Parameter(ParameterSetName = NewEmailReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the email receiver")]
        [ValidateNotNullOrEmpty]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets sms receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a sms receiver")]
        public SwitchParameter SmsReceiver { get; set; }

        /// <summary>
        /// Gets or sets the CountryCode parameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The country code of the sms receiver")]
        [ValidateNotNullOrEmpty]
        public string CountryCode { get; set; } = "1";

        /// <summary>
        /// Gets or sets the CountryCode parameter
        /// </summary>
        [Parameter(ParameterSetName = NewSmsReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The phone number of the sms receiver")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets webhook receiver SwitchParameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Create a webhook receiver")]
        public SwitchParameter WebhookReceiver { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress parameter
        /// </summary>
        [Parameter(ParameterSetName = NewWebhookReceiver, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The address of the webhook receiver")]
        [ValidateNotNullOrEmpty]
        public string ServiceUri { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            PSActionGroupReceiverBase receiverBase = null;
            if (this.ParameterSetName == NewEmailReceiver)
            {
                receiverBase = new PSEmailReceiver { Name = Name, EmailAddress = EmailAddress };
            }
            else if (this.ParameterSetName == NewSmsReceiver)
            {
                receiverBase = new PSSmsReceiver { Name = Name, CountryCode = CountryCode, PhoneNumber = PhoneNumber };
            }
            else if (this.ParameterSetName == NewWebhookReceiver)
            {
                receiverBase = new PSWebhookReceiver { Name = Name, ServiceUri = ServiceUri };
            }

            WriteObject(receiverBase);
        }
    }
}