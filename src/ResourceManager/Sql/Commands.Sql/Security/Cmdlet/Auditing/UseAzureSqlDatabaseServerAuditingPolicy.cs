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

using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet.Auditing
{
    /// <summary>
    /// Marks the given database as using its server's default policy instead of its own policy.
    /// </summary>
        [Cmdlet(VerbsOther.Use, "AzureSqlDatabaseServerAuditingPolicy"), OutputType(typeof(DatabaseAuditingPolicyModel))]
    public class UseAzureSqlDatabaseServerAuditingPolicy : SqlDatabaseAuditingCmdletBase
    {

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override bool WriteResult() { return PassThru; }

        protected override DatabaseAuditingPolicyModel UpdateModel(DatabaseAuditingPolicyModel model)
        {
            base.UpdateModel(model);
            model.UseServerDefault = UseServerDefaultOptions.Enabled;
            model.StorageAccountName = GetStorageAccountName();
            return model;
        }

        protected string GetStorageAccountName()
        {
            string storageAccountName = this.ModelAdapter.GetServerStorageAccount(this.ResourceGroupName, this.ServerName, this.clientRequestId);
            if (string.IsNullOrEmpty(storageAccountName))
            {
                throw new Exception(string.Format(Resources.UseServerWithoutStorageAccount));
            }
            return storageAccountName;
        }
    }
}
