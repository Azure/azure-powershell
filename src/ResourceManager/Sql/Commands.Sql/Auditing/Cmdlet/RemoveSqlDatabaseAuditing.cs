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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// Disables auditing on a specific database.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseAuditing", SupportsShouldProcess = true), OutputType(typeof(AuditingPolicyModel))]
    [Obsolete("Note that Table auditing is deprecated and this command will be removed in a future release. Please use the 'Set-AzureRmSqlDatabaseAuditing' command to configure Blob auditing.", false)]
    public class RemoveSqlDatabaseAuditing : SqlDatabaseAuditingCmdletBase
    {
        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override AuditingPolicyModel ApplyUserInputToModel(AuditingPolicyModel model)
        {
            base.ApplyUserInputToModel(model);
            model.AuditState = AuditStateType.Disabled;

            DatabaseAuditingPolicyModel tableAuditingPolicyModel = (model as DatabaseAuditingPolicyModel);
            if (tableAuditingPolicyModel != null)
            {
                tableAuditingPolicyModel.UseServerDefault = UseServerDefaultOptions.Disabled;
            }

            return model;
        }

        /// <summary>
        /// This method is responsible to call the right API in the communication layer that will eventually send the information in the 
        /// object to the REST endpoint
        /// </summary>
        /// <param name="model">The model object with the data to be sent to the REST endpoints</param>
        protected override AuditingPolicyModel PersistChanges(AuditingPolicyModel model)
        {
            ModelAdapter.IgnoreStorage = true;
            base.PersistChanges(model);
            //if another server auditing policy exists, remove it
            if (AuditType == AuditType.Blob)
            {
                AuditType = AuditType.Table;
            }
            else
            {
                AuditType = AuditType.Blob;
            }
            var otherAuditingTypePolicyModel = GetEntity();
            if (otherAuditingTypePolicyModel != null)
            {
                otherAuditingTypePolicyModel.AuditState = AuditStateType.Disabled;
                base.PersistChanges(otherAuditingTypePolicyModel);
            }
            return null;
        }
    }
}
