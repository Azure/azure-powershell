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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// Marks the given database as using its server's default policy instead of its own policy.
    /// </summary>
    [Cmdlet(VerbsOther.Use, "AzureRmSqlServerAuditingPolicy"), OutputType(typeof(AuditingPolicyModel))]
    [Alias("Use-AzureRmSqlDatabaseServerAuditingPolicy")]
    public class UseAzureSqlServerAuditingPolicy : SqlDatabaseAuditingCmdletBase
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
        /// <param name="baseModel">A model object</param>
        protected override AuditingPolicyModel ApplyUserInputToModel(AuditingPolicyModel baseModel)
        {
            base.ApplyUserInputToModel(baseModel);
            if (AuditType == AuditType.Table)
            {
                ApplyUserInputToTableAuditingModel(baseModel as DatabaseAuditingPolicyModel);
            }
            else
            {
                ApplyUserInputToBlobAuditingModel(baseModel as DatabaseBlobAuditingPolicyModel);
            }
            return baseModel;
        }

        private void ApplyUserInputToBlobAuditingModel(DatabaseBlobAuditingPolicyModel model)
        {
            model.AuditState = AuditStateType.Disabled;
        }

        private void ApplyUserInputToTableAuditingModel(DatabaseAuditingPolicyModel model)
        {
            if (model.AuditState == AuditStateType.New)
            {
                model.AuditState = AuditStateType.Enabled;
            }
            model.UseServerDefault = UseServerDefaultOptions.Enabled;
            model.StorageAccountName = GetStorageAccountName();
        }

        /// <summary>
        /// If the user has table and blob auditing policies, the change will be applied for both.  
        /// </summary>
        /// <param name="model">A model object</param>
        protected override AuditingPolicyModel PersistChanges(AuditingPolicyModel model)
        {
            base.PersistChanges(model);
            Action swapAuditType = () => { AuditType = AuditType == AuditType.Blob ? AuditType.Table : AuditType.Blob; };
            swapAuditType();
            var otherAuditingTypePolicyModel = GetEntity();
            if (otherAuditingTypePolicyModel != null)
            {
                if (otherAuditingTypePolicyModel.AuditType == AuditType.Table)
                {
                    ApplyUserInputToTableAuditingModel(otherAuditingTypePolicyModel as DatabaseAuditingPolicyModel);
                }
                else
                {
                    ApplyUserInputToBlobAuditingModel(otherAuditingTypePolicyModel as DatabaseBlobAuditingPolicyModel);
                }
                base.PersistChanges(otherAuditingTypePolicyModel);
            }
            swapAuditType();
            return model;
        }

        /// <summary>
        /// Returns the storage account name that is used at the policy of the database's server.
        /// </summary>
        /// <returns>A storage account name</returns>
        protected string GetStorageAccountName()
        {
            var storageAccountName = ModelAdapter.GetServerStorageAccount(ResourceGroupName, ServerName, clientRequestId);
            if (string.IsNullOrEmpty(storageAccountName))
            {
                throw new Exception(string.Format(Properties.Resources.UseServerWithoutStorageAccount));
            }
            return storageAccountName;
        }
    }
}
