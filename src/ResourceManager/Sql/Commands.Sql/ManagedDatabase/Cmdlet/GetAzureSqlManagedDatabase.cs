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

using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlManagedDatabase", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlManagedDatabase : AzureSqlManagedDatabaseCmdletBase<IEnumerable<AzureSqlManagedDatabaseModel>>
    {
        /// <summary>
        /// Gets or sets the name of the managed database to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Managed Database to retrieve.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ManagedDatabaseName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> GetEntity()
        {
            ICollection<AzureSqlManagedDatabaseModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("ManagedDatabaseName"))
            {
                results = new List<AzureSqlManagedDatabaseModel>();
                results.Add(ModelAdapter.GetManagedDatabase(this.ResourceGroupName, this.ManagedInstanceName, this.ManagedDatabaseName));
            }
            else
            {
                results = ModelAdapter.ListManagedDatabases(this.ResourceGroupName, this.ManagedInstanceName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedDatabaseModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseModel> PersistChanges(IEnumerable<AzureSqlManagedDatabaseModel> entity)
        {
            return entity;
        }
    }
}
