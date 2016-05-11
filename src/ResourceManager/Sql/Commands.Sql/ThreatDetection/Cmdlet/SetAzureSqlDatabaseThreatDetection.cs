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

using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.ThreatDetection.Model;

namespace Microsoft.Azure.Commands.Sql.ThreatDetection.Cmdlet
{
    /// <summary>
    /// Sets the auditing policy properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseThreatDetectionPolicy"), OutputType(typeof(DatabaseThreatDetectionPolicyModel))]
    public class SetAzureSqlDatabaseThreatDetection : SqlDatabaseThreatDetectionCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the Threat Detection Email Addresses
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of email addresses to send the alerts to")]
        public string NotificationRecipientsEmails { get; set; }

        /// <summary>
        /// Gets or sets the whether to email administrators
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines whether to email administrators")]
        [ValidateNotNullOrEmpty]
        public bool? EmailAdmins { get; set; }

        /// <summary>
        /// Gets or sets the names of the detection types to filter.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Detection types to exclude")]
        [ValidateSet(SecurityConstants.Sql_Injection,
            SecurityConstants.Sql_Injection_Vulnerability, SecurityConstants.Access_Anomaly,
            SecurityConstants.Usage_Anomaly, SecurityConstants.None, IgnoreCase = false)]
        public string[] ExcludedDetectionType { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override DatabaseThreatDetectionPolicyModel ApplyUserInputToModel(DatabaseThreatDetectionPolicyModel model)
        {
            base.ApplyUserInputToModel(model);

            model.ThreatDetectionState = ThreatDetectionStateType.Enabled;

            if (NotificationRecipientsEmails != null)
            {
                model.NotificationRecipientsEmails = NotificationRecipientsEmails;
            }

            if (EmailAdmins != null)
            {
                model.EmailAdmins = (bool)EmailAdmins;
            }

            ExcludedDetectionType = Util.ProcessExcludedDetectionTypes(ExcludedDetectionType);

            if (ExcludedDetectionType != null)
            {
                model.ExcludedDetectionTypes = ExcludedDetectionType.Select(s => SecurityConstants.ExcludedDetectionToExcludedDetectionTypes[s]).ToArray();
            }

            ValidateInput(model);

            return model;
        }

        /// <summary>
        /// Preforms validity checks
        /// </summary>
        /// <param name="model">The model</param>
        private void ValidateInput(DatabaseThreatDetectionPolicyModel model)
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