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

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Model
{
   /// <summary>
    /// The possible states in which an auditing policy may be in
    /// </summary>
    public enum ThreatDetectionStateType { Enabled, Disabled, New };

    /// <summary>
    /// The possible disable alert types
    /// </summary> 
    public enum DetectionType
    {
        Successful_SQLi,
        Attempted_SQLi,
        Client_GEO_Anomaly,
        Failed_Logins_Anomaly,
        Failed_Queries_Anomaly,
        Data_Extraction_Anomaly,
        Data_Alteration_Anomaly
    };

    /// <summary>
    /// A class representing a database auditing policy
    /// </summary>
    public class BaseThreatDetectionPolicyModel
    {
        /// <summary>
        /// Gets or sets the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the Threat Detection state
        /// </summary>
        public ThreatDetectionStateType ThreatDetectionState { get; internal set; }

        /// <summary>
        /// Gets or sets the Threat Detection Email Addresses
        /// </summary>
        public string NotificationRecipientsEmails { get; internal set; }

        /// <summary>
        /// Gets or sets the whether to email service and co-administrators
        /// </summary>
        public bool EmailAdmins { get; internal set; }

        /// <summary>
        /// Gets or sets the detection types to filter 
        /// </summary>
        public DetectionType[] ExcludedDetectionTypes { get; internal set; }

        /// <summary>
        /// Preforms validity checks
        /// </summary>
        /// <param name="model">The model</param>
        public void ValidateInput()
        {
            // Validity checks:
            // 1. Check that EmailAddresses are in correct format 
            bool areEmailAddressesInCorrectFormat = AreEmailAddressesInCorrectFormat(model.NotificationRecipientsEmails);
            if (!areEmailAddressesInCorrectFormat)
            {
                throw new Exception(Properties.Resources.EmailsAreNotValid);
            }

            // 2. check that EmailAdmins is not False and NotificationRecipientsEmails is not empty
            if (!model.EmailAdmins && string.IsNullOrEmpty(model.NotificationRecipientsEmails))
            {
                throw new Exception(Properties.Resources.NeedToProvideEmail);
            }
        }

        /// <summary>
        /// Checks if email addresses are in a correct format
        /// </summary>
        /// <param name="emailAddresses">The email addresses</param>
        /// <returns>Returns whether the email addresses are in a correct format</returns>
        private bool AreEmailAddressesInCorrectFormat(string emailAddresses)
        {
            if (string.IsNullOrEmpty(emailAddresses))
            {
                return true;
            }

            string[] emailAddressesArray = emailAddresses.Split(';').Where(s => !string.IsNullOrEmpty(s)).ToArray();
            var emailRegex =
                new Regex(string.Format("{0}{1}",
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"));
            return !emailAddressesArray.Any(e => !emailRegex.IsMatch(e));
        }
    }
}