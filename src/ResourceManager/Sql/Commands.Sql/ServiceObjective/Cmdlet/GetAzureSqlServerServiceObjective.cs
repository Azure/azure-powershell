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

using Microsoft.Azure.Commands.Sql.ServiceObjective.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseServer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerServiceObjective", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlServerServiceObjective : AzureSqlServerServiceObjectiveCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of service objective.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Azure Sql Database service objective name.")]
        [ValidateNotNullOrEmpty]
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets a server from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlServerServiceObjectiveModel> GetEntity()
        {
            ICollection<AzureSqlServerServiceObjectiveModel> results = null;

            if (this.MyInvocation.BoundParameters.ContainsKey("ServiceObjectiveName"))
            {
                results = new List<AzureSqlServerServiceObjectiveModel>();
                results.Add(ModelAdapter.GetServiceObjective(this.ResourceGroupName, this.ServerName, this.ServiceObjectiveName));
            }
            else
            {
                results = ModelAdapter.ListServiceObjectives(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerServiceObjectiveModel> PersistChanges(IEnumerable<AzureSqlServerServiceObjectiveModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerServiceObjectiveModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerServiceObjectiveModel> model)
        {
            return model;
        }
    }
}
