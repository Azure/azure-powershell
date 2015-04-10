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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseElasticPoolDatabaseActivity",
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseElasticPoolDatabaseActivity : AzureSqlDatabaseElasticPoolDatabaseActivityCmdletBase
    {
        /// <summary>
        /// Gets database activity in an Elastic Pool
        /// </summary>
        /// <returns>List of Database activity</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolDatabaseActivityModel> GetEntity()
        {
            return ModelAdapter.ListElasticPoolDatabaseActivity(this.ResourceGroupName, this.ServerName, this.ElasticPoolName);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolDatabaseActivityModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseElasticPoolDatabaseActivityModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolDatabaseActivityModel> PersistChanges(IEnumerable<AzureSqlDatabaseElasticPoolDatabaseActivityModel> entity)
        {
            return entity;
        }
    }
}
