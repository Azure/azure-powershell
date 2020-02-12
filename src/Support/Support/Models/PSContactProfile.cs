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

using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Support.Models
{
    public class PSContactProfile
    {
        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets preferred contact method. Possible values include:
        /// 'email', 'phone'
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string PreferredContactMethod { get; set; }

        /// <summary>
        /// Gets or sets primary email address.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string PrimaryEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets additional email addresses.
        /// </summary>
        public string[] AdditionalEmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets phone number. This is required if preferred contact
        /// method is phone.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets time zone of the user. This is the
        /// System.TimeZoneInfo.Id value
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string PreferredTimeZone { get; set; }

        /// <summary>
        /// Gets or sets country of the user. This is the ISO Alpha-3 code
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets language of the user. This is the standard
        /// country-language code.
        /// </summary>
        [Ps1Xml(Target = ViewControl.Table)]
        public string PreferredSupportLanguage { get; set; }
    }
}
