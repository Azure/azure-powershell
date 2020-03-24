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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Support.Common;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using static Microsoft.Azure.Commands.Support.Helpers.ResourceIdentifierHelper;

namespace Microsoft.Azure.Commands.Support.SupportTickets
{
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "SupportTicket", DefaultParameterSetName = CreateSupportTicketWithContactDetailParameterSet, SupportsShouldProcess = true),
       OutputType(typeof(PSSupportTicket))]
    public class NewAzSupportTicket : AzSupportCmdletBase
    {
        private const string CreateSupportTicketWithContactObjectParameterSet = "CreateSupportTicketWithContactObjectParameterSet";
        private const string CreateSupportTicketWithContactDetailParameterSet = "CreateSupportTicketWithContactDetailParameterSet";

        private const string CreateTechnicalSupportTicketWithContactObjectParameterSet = "CreateTechnicalSupportTicketWithContactObjectParameterSet";
        private const string CreateQuotaSupportTicketWithContactObjectParameterSet = "CreateQuotaSupportTicketWithContactObjectParameterSet";

        private const string CreateTechnicalSupportTicketWithContactDetailParameterSet = "CreateTechnicalSupportTicketWithContactDetailParameterSet";
        private const string CreateQuotaSupportTicketWithContactDetailParameterSet = "CreateQuotaSupportTicketWithContactDetailParameterSet";

        [Parameter(Mandatory = true, HelpMessage = "Name of support ticket that this cmdlet creates.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Title of support ticket.")]
        [ValidateNotNullOrEmpty]
        public string Title { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Detailed description of the question or issue.")]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Each Azure service has its own set of issue category called problem classification that corresponds to the type of problem you're experiencing. This parameter is the ARM resource id of ProblemClassification resource.")]
        [ValidateNotNullOrEmpty]
        public string ProblemClassificationId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Severity of the support ticket. This indicates the urgency of the case, which in turn determines the response time according to the service level agreement of the technical support plan you have with Azure.")]
        public Severity Severity { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactObjectParameterSet, HelpMessage = "Customer contact details associated with SupportTicket resource.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactObjectParameterSet, HelpMessage = "Customer contact details associated with SupportTicket resource.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactObjectParameterSet, HelpMessage = "Customer contact details associated with SupportTicket resource.")]
        [ValidateNotNull]
        public PSContactProfile CustomerContactDetail { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer first name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer first name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer first name.")]
        [ValidateNotNullOrEmpty]
        public string CustomerFirstName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer last name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer last name.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer last name.")]
        [ValidateNotNullOrEmpty]
        public string CustomerLastName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Preferred contact method.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Preferred contact method.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Preferred contact method.")]
        public ContactMethod PreferredContactMethod { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer primary email address.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer primary email address.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer primary email address.")]
        [ValidateNotNullOrEmpty]
        public string CustomerPrimaryEmailAddress { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Additional email addresses. Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Additional email addresses. Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Additional email addresses. Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [ValidateNotNull]
        public string[] AdditionalEmailAddress { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [Parameter(Mandatory = false, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [ValidateNotNullOrEmpty]
        public string CustomerPhoneNumber { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [PSArgumentCompleter("Afghanistan Standard Time", "Alaskan Standard Time", "Arab Standard Time", "Arabian Standard Time", "Arabic Standard Time", "Argentina Standard Time", "Atlantic Standard Time", "AUS Central Standard Time", "AUS Eastern Standard Time", "Azerbaijan Standard Time", "Azores Standard Time", "Canada Central Standard Time", "Cape Verde Standard Time", "Caucasus Standard Time", "Cen. Australia Standard Time", "Central America Standard Time", "Central Asia Standard Time", "Central Brazilian Standard Time", "Central Europe Standard Time", "Central European Standard Time", "Central Pacific Standard Time", "Central Standard Time", "Central Standard Time (Mexico)", "China Standard Time", "Dateline Standard Time", "E. Africa Standard Time", "E. Australia Standard Time", "E. Europe Standard Time", "E. South America Standard Time", "Eastern Standard Time", "Eastern Standard Time (Mexico)", "Egypt Standard Time", "Ekaterinburg Standard Time", "Fiji Standard Time", "FLE Standard Time", "Georgian Standard Time", "GMT Standard Time", "Greenland Standard Time", "Greenwich Standard Time", "GTB Standard Time", "Hawaiian Standard Time", "India Standard Time", "Iran Standard Time", "Israel Standard Time", "Jordan Standard Time", "Korea Standard Time", "Mauritius Standard Time", "Central Standard Time (Mexico)", "Mid-Atlantic Standard Time", "Middle East Standard Time", "Montevideo Standard Time", "Morocco Standard Time", "Mountain Standard Time", "Mountain Standard Time (Mexico)", "Myanmar Standard Time", "N. Central Asia Standard Time", "Namibia Standard Time", "Nepal Standard Time", "New Zealand Standard Time", "Newfoundland Standard Time", "North Asia East Standard Time", "North Asia Standard Time", "Pacific SA Standard Time", "Pacific Standard Time", "Pacific Standard Time (Mexico)", "Pakistan Standard Time", "Romance Standard Time", "Russian Standard Time", "SA Eastern Standard Time", "SA Pacific Standard Time", "SA Western Standard Time", "Samoa Standard Time", "SE Asia Standard Time", "Singapore Standard Time", "South Africa Standard Time", "Sri Lanka Standard Time", "Taipei Standard Time", "Tasmania Standard Time", "Tokyo Standard Time", "Tonga Standard Time", "Turkey Standard Time", "US Eastern Standard Time", "US Mountain Standard Time", "UTC", "Venezuela Standard Time", "Vladivostok Standard Time", "W. Australia Standard Time", "W. Central Africa Standard Time", "W. Europe Standard Time", "West Asia Standard Time", "West Pacific Standard Time", "Yakutsk Standard Time")]
        [ValidateNotNullOrEmpty]
        public string CustomerPreferredTimeZone { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [ValidateNotNullOrEmpty]
        public string CustomerCountry { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateSupportTicketWithContactDetailParameterSet, HelpMessage = "Peferred language of the custom. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/en-us/support/faq/.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "Peferred language of the contact. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/en-us/support/faq/.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Peferred language of the contact. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/en-us/support/faq/.")]
        [PSArgumentCompleter("en-us", "es-es", "fr-fr", "de-de", "it-it", "ja-jp", "ko-kr", "ru-ru", "pt-br", "zh-tw", "zh-hans")]
        [ValidateNotNullOrEmpty]
        public string CustomerPreferredSupportLanguage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Date and time when the problem started.")]
        public DateTime ProblemStartTime { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactDetailParameterSet, HelpMessage = "This is the resource id of the Azure service resource (For example: A virtual machine resource or an HDInsight resource) for which the support ticket is created.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateTechnicalSupportTicketWithContactObjectParameterSet, HelpMessage = "This is the resource id of the Azure service resource (For example: A virtual machine resource or an HDInsight resource) for which the support ticket is created.")]
        [ValidateNotNullOrEmpty]
        public string TechnicalTicketResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactDetailParameterSet, HelpMessage = "Additional details for a Quota support ticket.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateQuotaSupportTicketWithContactObjectParameterSet, HelpMessage = "Additional details for a Quota support ticket.")]
        [ValidateNotNull]
        public PSQuotaTicketDetail QuotaTicketDetail { get; set; }        

        [Parameter(Mandatory = false, HelpMessage = "This is the home tenant id of the Cloud Solution Provider user trying to create a support ticket for their customer.")]
        public string CSPHomeTenantId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if this support ticket requires a 24x7 response from Azure.")]
        public SwitchParameter Require24X7Response { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => this.ProblemStartTime))
                {
                    if (this.ProblemStartTime == DateTime.MinValue || this.ProblemStartTime > DateTime.Now)
                    {
                        throw new PSArgumentException(string.Format("ProblemStartTime {0} is not valid.", this.ProblemStartTime));
                    }
                }

                var problemClassificationResourceId = ResourceIdentifierHelper.BuildResourceIdentifier(this.ProblemClassificationId, ResourceType.ProblemClassifications);

                var checkNameAvailabilityInput = new CheckNameAvailabilityInput
                {
                    Type = Management.Support.Models.Type.MicrosoftSupportSupportTickets,
                    Name = this.Name
                };

                var checkNameAvailabilityResult = this.SupportClient.SupportTickets.CheckNameAvailability(checkNameAvailabilityInput);

                if (checkNameAvailabilityResult.NameAvailable.HasValue &&
                    !checkNameAvailabilityResult.NameAvailable.Value)
                {
                    throw new PSArgumentException(string.Format("A SupportTicket with name '{0}' cannot be created for the reason {1}.", this.Name, checkNameAvailabilityResult.Reason));
                }

                if (this.IsParameterBound(c => c.TechnicalTicketResourceId))
                {
                    var technicalResourceId = new ResourceIdentifier(this.TechnicalTicketResourceId);

                    if (!technicalResourceId.Subscription.Equals(this.SupportClient.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new PSArgumentException(string.Format("TechnicalResourceId {0} does not belong to subscription {1}.", this.TechnicalTicketResourceId, this.SupportClient.SubscriptionId));
                    }

                    var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                            DefaultProfile.DefaultContext,
                            AzureEnvironment.Endpoint.ResourceManager);

                    var oDataQuery = new ODataQuery<GenericResourceFilter>($"resourceGroup eq '{technicalResourceId.ResourceGroupName}' and resourceType eq '{technicalResourceId.ResourceType}' and name eq '{technicalResourceId.ResourceName}'");

                    var result = resourceClient.Resources.List(oDataQuery);

                    if (result.Count() != 1)
                    {
                        throw new Exception(string.Format("TechnicalResourceId {0} was not found in subscription {1}.", this.TechnicalTicketResourceId, this.SupportClient.SubscriptionId));
                    }
                }

                var customHeaders = new Dictionary<string, List<string>>();
                if (!string.IsNullOrEmpty(this.CSPHomeTenantId))
                {
                    if (!Guid.TryParse(this.CSPHomeTenantId, out var result))
                    {
                        throw new PSArgumentException(string.Format("CSPHomeTenantId {0} is not a valid Guid.", this.CSPHomeTenantId));
                    }

                    var auxToken = AzureSession.Instance.AuthenticationFactory.Authenticate(this.DefaultContext.Account, this.DefaultContext.Environment, this.CSPHomeTenantId, null, "Never", null);
                    customHeaders.Add(AUX_HEADER_NAME, new List<string> { $"{AUX_TOKEN_PREFIX} {auxToken.AccessToken}" });
                }

                PSContactProfile contactObject = null;
                if (this.ParameterSetName.Equals(CreateSupportTicketWithContactObjectParameterSet) ||
                    this.ParameterSetName.Equals(CreateQuotaSupportTicketWithContactObjectParameterSet) ||
                    this.ParameterSetName.Equals(CreateTechnicalSupportTicketWithContactObjectParameterSet))
                {
                    contactObject = this.CustomerContactDetail;
                }
                else
                {
                    contactObject = new PSContactProfile
                    {
                        FirstName = this.CustomerFirstName,
                        LastName = this.CustomerLastName,
                        PrimaryEmailAddress = this.CustomerPrimaryEmailAddress,
                        PreferredTimeZone = this.CustomerPreferredTimeZone,
                        PreferredSupportLanguage = this.CustomerPreferredSupportLanguage,
                        PhoneNumber = this.CustomerPhoneNumber,
                        AdditionalEmailAddresses = this.AdditionalEmailAddress,
                        Country = this.CustomerCountry,
                        PreferredContactMethod = this.PreferredContactMethod.ToString()
                    };
                }

                var supportTicket = new PSSupportTicket
                {
                    Title = this.Title,
                    Description = this.Description,
                    ServiceId = $"/providers/Microsoft.Support/services/{problemClassificationResourceId.ParentResource}",
                    ProblemClassificationId = this.ProblemClassificationId,
                    Severity = this.Severity.ToString(),
                    Require24X7Response = this.Require24X7Response.IsPresent ? true : (bool?)null,
                    ProblemStartTime = this.IsParameterBound(c => this.ProblemStartTime) ? this.ProblemStartTime.ToUniversalTime() : (DateTime?)null,
                    ContactDetail = contactObject,
                    TechnicalTicketResourceId = this.TechnicalTicketResourceId,
                    QuotaTicketDetail = this.QuotaTicketDetail,
                };

                if (this.ShouldProcess(this.Name, string.Format("Creating a new SupportTicket with name '{0}'.", this.Name)))
                {
                    var sdkSupportTicket = supportTicket.ToSdkSupportTicket();
                    var result = this.SupportClient.CreateSupportTicketForSubscription(this.Name, sdkSupportTicket, customHeaders);

                    this.WriteObject(result.ToPSSupportTicket());
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
