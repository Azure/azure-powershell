﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.Auditing
{
    /// <summary>
    /// Sets the auditing policy properties for a specific database server.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseServerAuditingPolicy"), OutputType(typeof(ServerAuditingPolicyModel))]
    public class SetAzureSqlDatabaseServerAuditingPolicy : SqlDatabaseServerAuditingCmdletBase
    {

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the names of the event types to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Event types to audit")]
        [ValidateSet(Constants.DataAccess, Constants.SchemaChanges, Constants.DataChanges, Constants.SecurityExceptions, Constants.RevokePermissions, Constants.All, Constants.None, IgnoreCase = false)]
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
        [ValidateSet(Constants.Primary, Constants.Secondary, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string StorageKeyType { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override ServerAuditingPolicyModel UpdateModel(ServerAuditingPolicyModel model)
        {
            base.UpdateModel(model);
            model.AuditState = AuditStateType.Enabled;
            if (StorageAccountName != null)
            {
                model.StorageAccountName = StorageAccountName;
            }
            if (!string.IsNullOrEmpty(StorageKeyType)) // the user enter a key type - we use it (and running over the previously defined key type)
            {
                model.StorageKeyType = (StorageKeyType == Constants.Primary) ? StorageKeyKind.Primary : StorageKeyKind.Secondary;
            }

            ProcessShortcuts();
            if (EventType != null) // the user provided event types to audit
            {
                Dictionary<string, AuditEventType> events = new Dictionary<string, AuditEventType>(){
                    {Constants.DataAccess, AuditEventType.DataAccess},
                    {Constants.DataChanges, AuditEventType.DataChanges},
                    {Constants.SecurityExceptions, AuditEventType.SecurityExceptions},
                    {Constants.RevokePermissions, AuditEventType.RevokePermissions},
                    {Constants.SchemaChanges, AuditEventType.SchemaChanges}
                };
                model.EventType = EventType.Select(s => events[s]).ToArray();
            }
            return model;
        }

        /// <summary>
        /// In cases where the user decided to use one of the shortcuts (ALL or NONE), this method sets the value of the EventType property to reflect the correct values
        /// </summary>
        private void ProcessShortcuts()
        {
            if (EventType == null)
            {
                return;
            }
            if (EventType.Length == 1)
            {
                if (EventType[0] == Constants.None)
                {
                    EventType = new string[] { };
                }
                else if (EventType[0] == Constants.All)
                {
                    EventType = new string[] { Constants.DataAccess, Constants.DataChanges, Constants.SecurityExceptions, Constants.RevokePermissions, Constants.SchemaChanges };
                }
            }
            else
            {
                if (EventType.Contains(Constants.All))
                {
                    throw new Exception(string.Format(Resources.InvalidEventTypeSet, Constants.All));
                }
                if (EventType.Contains(Constants.None))
                {
                    throw new Exception(string.Format(Resources.InvalidEventTypeSet, Constants.None));
                }
            }
        }
    }
}