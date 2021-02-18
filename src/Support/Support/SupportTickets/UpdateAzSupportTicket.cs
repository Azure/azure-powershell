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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Support.Common;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;
using Status = Microsoft.Azure.Commands.Support.Models.Status;

namespace Microsoft.Azure.Commands.Support.SupportTickets
{
    [Cmdlet(VerbsData.Update, AzureRMConstants.AzureRMPrefix + "SupportTicket", DefaultParameterSetName = UpdateByNameWithContactDetailParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSupportTicket))]
    public class UpdateAzSupportTicket : AzSupportCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Name of SupportTicket resource that this cmdlet updates.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameWithContactObjectParameterSet, HelpMessage = "Name of SupportTicket resource that this cmdlet updates.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "SupportTicket resource object that this cmdlet updates.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectWithContactObjectParameterSet, HelpMessage = "SupportTicket resource object that this cmdlet updates.")]
        [ValidateNotNull]
        public PSSupportTicket InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Update Severity of SupportTicket.")]
        public Severity Severity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Update Status of SupportTicket.")]
        public Status Status { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameWithContactObjectParameterSet, HelpMessage = "Update Contact details on SupportTicket.")]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByInputObjectWithContactObjectParameterSet, HelpMessage = "Update Contact details on SupportTicket.")]
        [ValidateNotNull]
        public PSContactProfile CustomerContactDetail { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer first name.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer first name.")]
        [ValidateNotNullOrEmpty]
        public string CustomerFirstName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer last name.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer last name.")]
        [ValidateNotNullOrEmpty]
        public string CustomerLastName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Preferred contact method.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Preferred contact method.")]
        public ContactMethod PreferredContactMethod { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer primary email address.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer primary email address.")]
        [ValidateNotNullOrEmpty]
        public string CustomerPrimaryEmailAddress { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Additional email addresses. Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Additional email addresses. Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [ValidateNotNull]
        public string[] AdditionalEmailAddress { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [ValidateNotNullOrEmpty]
        public string CustomerPhoneNumber { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [PSArgumentCompleter("Afghanistan Standard Time", "Alaskan Standard Time", "Arab Standard Time", "Arabian Standard Time", "Arabic Standard Time", "Argentina Standard Time", "Atlantic Standard Time", "AUS Central Standard Time", "AUS Eastern Standard Time", "Azerbaijan Standard Time", "Azores Standard Time", "Canada Central Standard Time", "Cape Verde Standard Time", "Caucasus Standard Time", "Cen. Australia Standard Time", "Central America Standard Time", "Central Asia Standard Time", "Central Brazilian Standard Time", "Central Europe Standard Time", "Central European Standard Time", "Central Pacific Standard Time", "Central Standard Time", "Central Standard Time (Mexico)", "China Standard Time", "Dateline Standard Time", "E. Africa Standard Time", "E. Australia Standard Time", "E. Europe Standard Time", "E. South America Standard Time", "Eastern Standard Time", "Eastern Standard Time (Mexico)", "Egypt Standard Time", "Ekaterinburg Standard Time", "Fiji Standard Time", "FLE Standard Time", "Georgian Standard Time", "GMT Standard Time", "Greenland Standard Time", "Greenwich Standard Time", "GTB Standard Time", "Hawaiian Standard Time", "India Standard Time", "Iran Standard Time", "Israel Standard Time", "Jordan Standard Time", "Korea Standard Time", "Mauritius Standard Time", "Central Standard Time (Mexico)", "Mid-Atlantic Standard Time", "Middle East Standard Time", "Montevideo Standard Time", "Morocco Standard Time", "Mountain Standard Time", "Mountain Standard Time (Mexico)", "Myanmar Standard Time", "N. Central Asia Standard Time", "Namibia Standard Time", "Nepal Standard Time", "New Zealand Standard Time", "Newfoundland Standard Time", "North Asia East Standard Time", "North Asia Standard Time", "Pacific SA Standard Time", "Pacific Standard Time", "Pacific Standard Time (Mexico)", "Pakistan Standard Time", "Romance Standard Time", "Russian Standard Time", "SA Eastern Standard Time", "SA Pacific Standard Time", "SA Western Standard Time", "Samoa Standard Time", "SE Asia Standard Time", "Singapore Standard Time", "South Africa Standard Time", "Sri Lanka Standard Time", "Taipei Standard Time", "Tasmania Standard Time", "Tokyo Standard Time", "Tonga Standard Time", "Turkey Standard Time", "US Eastern Standard Time", "US Mountain Standard Time", "UTC", "Venezuela Standard Time", "Vladivostok Standard Time", "W. Australia Standard Time", "W. Central Africa Standard Time", "W. Europe Standard Time", "West Asia Standard Time", "West Pacific Standard Time", "Yakutsk Standard Time")]
        [ValidateNotNullOrEmpty]
        public string CustomerPreferredTimeZone { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [ValidateNotNullOrEmpty]
        public string CustomerCountry { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameWithContactDetailParameterSet, HelpMessage = "Customer preferred support language. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/support/faq/.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByInputObjectWithContactDetailParameterSet, HelpMessage = "Customer preferred support language. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/support/faq/.")]
        [PSArgumentCompleter("en-us", "es-es", "fr-fr", "de-de", "it-it", "ja-jp", "ko-kr", "ru-ru", "pt-br", "zh-tw", "zh-hans")]
        [ValidateNotNullOrEmpty]
        public string CustomerPreferredSupportLanguage { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    this.Name = this.InputObject.Name;
                }

                SupportTicketDetails supportTicket = null;

                supportTicket = this.SupportClient.SupportTickets.Get(this.Name);

                var updateSupportTicket = new UpdateSupportTicket();

                if (this.IsParameterBound(c => c.Severity))
                {
                    updateSupportTicket.Severity = this.Severity.ToString();
                }

                if (this.IsParameterBound(c => c.Status))
                {
                    updateSupportTicket.Status = this.Status.ToString();
                }

                UpdateContactProfile updateContactProfile = null;
                if (this.ParameterSetName.Equals(UpdateByNameWithContactObjectParameterSet) ||
                    this.ParameterSetName.Equals(UpdateByInputObjectWithContactObjectParameterSet))
                {
                    updateContactProfile = this.CustomerContactDetail.ToSdkContactProfile();
                }
                else
                {
                    if (this.IsParameterBound(c => c.CustomerFirstName) ||
                        this.IsParameterBound(c => c.CustomerLastName) ||
                        this.IsParameterBound(c => c.CustomerPrimaryEmailAddress) ||
                        this.IsParameterBound(c => c.CustomerPreferredTimeZone) ||
                        this.IsParameterBound(c => c.CustomerPreferredSupportLanguage) ||
                        this.IsParameterBound(c => c.CustomerPhoneNumber) ||
                        this.IsParameterBound(c => c.AdditionalEmailAddress) ||
                        this.IsParameterBound(c => c.CustomerCountry) ||
                        this.IsParameterBound(c => c.PreferredContactMethod))
                    {
                        updateContactProfile = new UpdateContactProfile
                        {
                            FirstName = this.IsParameterBound(c => c.CustomerFirstName) ? this.CustomerFirstName : null,
                            LastName = this.IsParameterBound(c => c.CustomerLastName) ? this.CustomerLastName : null,
                            PrimaryEmailAddress = this.IsParameterBound(c => c.CustomerPrimaryEmailAddress) ? this.CustomerPrimaryEmailAddress : null,
                            PreferredTimeZone = this.IsParameterBound(c => c.CustomerPreferredTimeZone) ? this.CustomerPreferredTimeZone : null,
                            PreferredSupportLanguage = this.IsParameterBound(c => c.CustomerPreferredSupportLanguage) ? this.CustomerPreferredSupportLanguage : null,
                            PhoneNumber = this.IsParameterBound(c => c.CustomerPhoneNumber) ? this.CustomerPhoneNumber : null,
                            AdditionalEmailAddresses = this.IsParameterBound(c => c.AdditionalEmailAddress) ? this.AdditionalEmailAddress.ToList() : null,
                            Country = this.IsParameterBound(c => c.CustomerCountry) ? this.CustomerCountry : null,
                            PreferredContactMethod = this.IsParameterBound(c => c.PreferredContactMethod) ? this.PreferredContactMethod.ToString() : null
                        };
                    }
                }

                updateSupportTicket.ContactDetails = updateContactProfile;

                if (this.ShouldProcess(this.Name, string.Format("Updating SupportTicket '{0}'.", this.Name)))
                {
                    var result = this.SupportClient.SupportTickets.Update(this.Name, updateSupportTicket);
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
