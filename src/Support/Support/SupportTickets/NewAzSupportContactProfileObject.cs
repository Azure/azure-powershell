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
using Microsoft.Azure.Commands.Support.Models;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.Support.SupportTickets
{
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "SupportContactProfileObject", SupportsShouldProcess = true), 
      OutputType(typeof(PSContactProfile))]
    public class NewAzSupportContactProfileObject : AzSupportCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Customer first name.")]
        [ValidateNotNullOrEmpty]
        public string FirstName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Customer last name.")]
        [ValidateNotNullOrEmpty]
        public string LastName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Preferred contact method.")]
        public ContactMethod PreferredContactMethod { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Customer primary email address.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryEmailAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Email addresses listed here will be copied on any correspondence about the support ticket.")]
        [ValidateNotNull]
        public string[] AdditionalEmailAddress { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Customer phone number. This is required if preferred contact method is phone.")]
        [ValidateNotNullOrEmpty]
        public string PhoneNumber { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Customer preferred time zone. This must be a valid System.TimeZoneInfo.Id value.")]
        [PSArgumentCompleter("Afghanistan Standard Time", "Alaskan Standard Time", "Arab Standard Time", "Arabian Standard Time", "Arabic Standard Time", "Argentina Standard Time", "Atlantic Standard Time", "AUS Central Standard Time", "AUS Eastern Standard Time", "Azerbaijan Standard Time", "Azores Standard Time", "Canada Central Standard Time", "Cape Verde Standard Time", "Caucasus Standard Time", "Cen. Australia Standard Time", "Central America Standard Time", "Central Asia Standard Time", "Central Brazilian Standard Time", "Central Europe Standard Time", "Central European Standard Time", "Central Pacific Standard Time", "Central Standard Time", "Central Standard Time (Mexico)", "China Standard Time", "Dateline Standard Time", "E. Africa Standard Time", "E. Australia Standard Time", "E. Europe Standard Time", "E. South America Standard Time", "Eastern Standard Time", "Eastern Standard Time (Mexico)", "Egypt Standard Time", "Ekaterinburg Standard Time", "Fiji Standard Time", "FLE Standard Time", "Georgian Standard Time", "GMT Standard Time", "Greenland Standard Time", "Greenwich Standard Time", "GTB Standard Time", "Hawaiian Standard Time", "India Standard Time", "Iran Standard Time", "Israel Standard Time", "Jordan Standard Time", "Korea Standard Time", "Mauritius Standard Time", "Central Standard Time (Mexico)", "Mid-Atlantic Standard Time", "Middle East Standard Time", "Montevideo Standard Time", "Morocco Standard Time", "Mountain Standard Time", "Mountain Standard Time (Mexico)", "Myanmar Standard Time", "N. Central Asia Standard Time", "Namibia Standard Time", "Nepal Standard Time", "New Zealand Standard Time", "Newfoundland Standard Time", "North Asia East Standard Time", "North Asia Standard Time", "Pacific SA Standard Time", "Pacific Standard Time", "Pacific Standard Time (Mexico)", "Pakistan Standard Time", "Romance Standard Time", "Russian Standard Time", "SA Eastern Standard Time", "SA Pacific Standard Time", "SA Western Standard Time", "Samoa Standard Time", "SE Asia Standard Time", "Singapore Standard Time", "South Africa Standard Time", "Sri Lanka Standard Time", "Taipei Standard Time", "Tasmania Standard Time", "Tokyo Standard Time", "Tonga Standard Time", "Turkey Standard Time", "US Eastern Standard Time", "US Mountain Standard Time", "UTC", "Venezuela Standard Time", "Vladivostok Standard Time", "W. Australia Standard Time", "W. Central Africa Standard Time", "W. Europe Standard Time", "West Asia Standard Time", "West Pacific Standard Time", "Yakutsk Standard Time")]
        [ValidateNotNullOrEmpty]
        public string PreferredTimeZone { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Customer country. This must be a valid ISO Alpha-3 country code (ISO 3166).")]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Customer preferred support language. This must be a valid language-contry code for one of the supported languages listed here https://azure.microsoft.com/support/faq/.")]
        [PSArgumentCompleter("en-us", "es-es", "fr-fr", "de-de", "it-it", "ja-jp", "ko-kr", "ru-ru", "pt-br", "zh-tw", "zh-hans")]
        [ValidateNotNullOrEmpty]
        public string PreferredSupportLanguage { get; set; }

        public override void ExecuteCmdlet()
        {
            var contactObject = new PSContactProfile
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                PrimaryEmailAddress = this.PrimaryEmailAddress,
                PreferredTimeZone = this.PreferredTimeZone,
                PreferredSupportLanguage = this.PreferredSupportLanguage,
                PhoneNumber = this.PhoneNumber,
                AdditionalEmailAddresses = this.AdditionalEmailAddress,
                Country = this.Country,
                PreferredContactMethod = this.PreferredContactMethod.ToString()
            };

            if (this.ShouldProcess("Creating contact profile"))
            {
                this.WriteObject(contactObject);
            }
        }
    }
}
