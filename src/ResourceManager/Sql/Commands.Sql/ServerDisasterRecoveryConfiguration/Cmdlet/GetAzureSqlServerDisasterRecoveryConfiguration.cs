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

using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerDisasterRecoveryConfiguration",
        ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlServerDisasterRecoveryConfiguration : AzureSqlServerDisasterRecoveryConfigurationCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Server Disaster Recovery Configuration to use.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Azure SQL Server Disaster Recovery Configuration to retrieve.")]
        public string VirtualEndpointName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> GetEntity()
        {
            ICollection<AzureSqlServerDisasterRecoveryConfigurationModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("VirtualEndpointName"))
            {
                results = new List<AzureSqlServerDisasterRecoveryConfigurationModel>
                {
                    ModelAdapter.GetServerDisasterRecoveryConfiguration(this.ResourceGroupName, this.ServerName, this.VirtualEndpointName)
                };
            }
            else
            {
                results = ModelAdapter.ListServerDisasterRecoveryConfigurations(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> PersistChanges(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> entity)
        {
            return entity;
        }
    }
}
