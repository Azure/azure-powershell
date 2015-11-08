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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// Sets the auditing policy properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseAuditingPolicy"), OutputType(typeof(DatabaseAuditingAndThreatDetectionPolicyModel))]
    public class SetAzureSqlDatabaseAuditingPolicy : SqlDatabaseAuditingCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the names of the event types to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Event types to audit")]
        [ValidateSet(SecurityConstants.PlainSQL_Success, SecurityConstants.PlainSQL_Failure, SecurityConstants.ParameterizedSQL_Success, SecurityConstants.ParameterizedSQL_Failure, SecurityConstants.StoredProcedure_Success, SecurityConstants.StoredProcedure_Failure, SecurityConstants.Login_Success, SecurityConstants.Login_Failure, SecurityConstants.TransactionManagement_Success, SecurityConstants.TransactionManagement_Failure, SecurityConstants.All, SecurityConstants.None, IgnoreCase = false)]
        public string[] EventType { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the storage account")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The type of the storage key")]
        [ValidateSet(SecurityConstants.Primary, SecurityConstants.Secondary, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string StorageKeyType { get; set; }

        /// <summary>
        /// Gets or sets the number of retention days for the audit logs table.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The number of retention days for the audit logs table")]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; internal set; }

        /// <summary>
        /// Gets or sets the name of the audit logs table.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the audit logs table")]
        [ValidateNotNullOrEmpty]
        public string TableIdentifier { get; internal set; }
        
        #region Threat Detection properties

        /// <summary>
        /// Gets or sets the Threat Detection state
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines if threat detection is enabled or disabled for this database")]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string ThreatDetectionState { get; set; }

        /// <summary>
        /// Gets or sets the Threat Detection Email Addresses
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of email addresses to send the alerts to")]
        public string EmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the whether to email service and co-administrators
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Defines whether to email service and co-administrators")]
        [ValidateNotNullOrEmpty]
        public bool? EmailServiceAndAccountAdmins { get; set; }

        /// <summary>
        /// Gets or sets a semi-colon list of detection type to filter 
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "A semicolon separated list of detection types to filter")]
        public string FilterDetectionTypes { get; internal set; }

        #endregion

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override DatabaseAuditingAndThreatDetectionPolicyModel ApplyUserInputToModel(DatabaseAuditingAndThreatDetectionPolicyModel model)
        {
            base.ApplyUserInputToModel(model);
            AuditStateType orgAuditStateType = model.AuditState;
            model.AuditState = AuditStateType.Enabled;
            model.UseServerDefault = UseServerDefaultOptions.Disabled;
            if (StorageAccountName != null)
            {
                model.StorageAccountName = StorageAccountName;
                ModelAdapter.ClearStorageDetailsCache();
            }
            if (!string.IsNullOrEmpty(StorageKeyType)) // the user enter a key type - we use it (and running over the previously defined key type)
            {
                model.StorageKeyType = (StorageKeyType == SecurityConstants.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            EventType = Util.ProcessAuditEvents(EventType);

            if (EventType != null) // the user provided event types to audit
            {
                model.EventType = EventType.Select(s => SecurityConstants.AuditEventsToAuditEventType[s]).ToArray();
            }

            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            if (TableIdentifier == null)
            {
                if ((orgAuditStateType == AuditStateType.New) && (model.RetentionInDays > 0))
                {
                    // If retention days is greater than 0 and no audit table identifier is supplied , we throw exception giving the user hint on the recommended TableIdentifier we got from the CSM
                    throw new Exception(string.Format(Properties.Resources.InvalidRetentionTypeSet, model.TableIdentifier));
                }
            }
            else
            {
                model.TableIdentifier = TableIdentifier;
            }

            // Threat Detection related definitions:
            // *************************************
            if (!string.IsNullOrEmpty(ThreatDetectionState))
            {
                model.ThreatDetectionState = (ThreatDetectionState == SecurityConstants.Enabled) ? ThreatDetectionStateType.Enabled : ThreatDetectionStateType.Disabled;
            }

            if (EmailAddresses != null)
            {
                model.EmailAddresses = EmailAddresses;
            }

            if (EmailServiceAndAccountAdmins != null)
            {
                model.EmailServiceAndAccountAdmins = (bool) EmailServiceAndAccountAdmins;
            }

            if (FilterDetectionTypes != null)
            {
                model.FilterDetectionTypes = FilterDetectionTypes;
            }

            if (model.ThreatDetectionState == ThreatDetectionStateType.Enabled)
            {
                // Validity checks:
                // 1. Check that EmailAddresses are in correct format 
                bool areEmailAddressesInCorrectFormat = AreEmailAddressesInCorrectFormat(EmailAddresses);
                if (!areEmailAddressesInCorrectFormat)
                {
                    throw new Exception(Properties.Resources.EmailsAreNotValid);
                }

                // 2. check that EmailServiceAndAccountAdmins is not False and EmailAddresses is not empty
                if (!model.EmailServiceAndAccountAdmins && string.IsNullOrEmpty(model.EmailAddresses))
                {
                    throw new Exception(Properties.Resources.NeedToProvideEmail);
                }
            }

            return model;
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
            var emailRegex = new Regex(@"^[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)*@([a-zA-Z0-9_]+[a-zA-Z0-9_-]*\.)+[a-zA-Z]{2,63}$");

            List<string> resultList = emailAddressesArray.Where(i => emailRegex.IsMatch(i)).ToList();
            return resultList.Count == emailAddressesArray.Count();
        }
    }
}