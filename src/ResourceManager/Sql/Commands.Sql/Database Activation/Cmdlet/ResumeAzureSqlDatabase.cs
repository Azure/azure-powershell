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

using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DatabaseActivation.Cmdlet
{
    /// <summary>
    /// Cmdlet to resume a paused Azure SQL Data Warehouse database.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Resume, "AzureRmSqlDatabase", SupportsShouldProcess = true)]
    public class ResumeAzureSqlDatabase : AzureSqlDatabaseActivationCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> GetEntity()
        {
            return new List<AzureSqlDatabaseModel>();
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseModel> model)
        {
            return model;
        }

        /// <summary>
        /// Resume the paused Azure SQL Data Warehouse database.
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> PersistChanges(IEnumerable<AzureSqlDatabaseModel> entity)
        {
            return new List<AzureSqlDatabaseModel>() {
                ModelAdapter.ResumeDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName)
            };
        }
    }
}
