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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Support.Common;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Support.Communications
{
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "SupportTicketCommunication", DefaultParameterSetName = CreateByNameParameterSet, SupportsShouldProcess = true),
     OutputType(typeof(PSSupportTicketCommunication))]
    public class NewAzSupportTicketCommunication : AzSupportCmdletBase
    {        
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, HelpMessage = "Support ticket name.")]
        [ValidateNotNullOrEmpty]
        public string SupportTicketName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = CreateByParentObjectParameterSet, HelpMessage = "Support ticket object.")]
        [ValidateNotNull]
        public PSSupportTicket SupportTicketObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Name of the communication resource.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Subject of the communication.")]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Body of the communication.")]
        [ValidateNotNullOrEmpty]
        public string Body { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Email address of the sender.")]
        [ValidateNotNullOrEmpty]
        public string Sender { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => c.SupportTicketObject))
                {
                    this.SupportTicketName = this.SupportTicketObject.Name;
                }

                var checkNameAvailabilityInput = new CheckNameAvailabilityInput
                {
                    Name = this.Name,
                    Type = Management.Support.Models.Type.MicrosoftSupportCommunications
                };

                var checkNameResult = this.SupportClient.Communications.CheckNameAvailability(this.SupportTicketName, checkNameAvailabilityInput);

                if (checkNameResult.NameAvailable.HasValue && !checkNameResult.NameAvailable.Value)
                {
                    throw new PSArgumentException(string.Format("A Communication with name '{0}' for SupportTicket '{1}' already exists.", this.Name, this.SupportTicketName));
                }

                var communicationDetails = new CommunicationDetails
                {
                    Subject = this.Subject,
                    Body = this.Body,
                    Sender = this.Sender
                };

                if (this.ShouldProcess(this.Name, string.Format("Creating a new Communication for SupportTicket '{0}' with name '{1}'.", this.SupportTicketName, this.Name)))
                {
                    var result = this.SupportClient.Communications.Create(this.SupportTicketName, this.Name, communicationDetails);
                    this.WriteObject(result.ToPSSupportTicketCommunication());
                }
            }
            catch (ExceptionResponseException ex)
            {
                throw new PSArgumentException(string.Format("Error response received. Error Message: '{0}'",
                                     ex.Response.Content));
            }
        }
    }
}
