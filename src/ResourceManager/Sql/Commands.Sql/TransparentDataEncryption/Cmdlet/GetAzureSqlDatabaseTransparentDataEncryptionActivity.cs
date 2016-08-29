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

using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseTransparentDataEncryption cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseTransparentDataEncryptionActivity", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlDatabaseTransparentDataEncryptionActivity : AzureSqlDatabaseTransparentDataEncryptionActivityCmdletBase
    {
        /// <summary>
        /// Gets a Transparent Data Encryption Acitvity for the database.
        /// </summary>
        /// <returns>A single Transparent Data Encryption</returns>
        protected override IEnumerable<AzureSqlDatabaseTransparentDataEncryptionActivityModel> GetEntity()
        {
            return ModelAdapter.ListTransparentDataEncryptionActivity(this.ResourceGroupName, this.ServerName, this.DatabaseName);
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlDatabaseTransparentDataEncryptionActivityModel> PersistChanges(IEnumerable<AzureSqlDatabaseTransparentDataEncryptionActivityModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlDatabaseTransparentDataEncryptionActivityModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseTransparentDataEncryptionActivityModel> model)
        {
            return model;
        }
    }
}
