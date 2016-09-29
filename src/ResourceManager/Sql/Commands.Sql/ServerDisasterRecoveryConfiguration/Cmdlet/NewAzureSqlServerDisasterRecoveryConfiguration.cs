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

using Hyak.Common;
using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Server Disaster Recovery Configuration
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlServerDisasterRecoveryConfiguration",
        ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    public class NewAzureSqlServerDisasterRecoveryConfiguration : AzureSqlServerDisasterRecoveryConfigurationCmdletBase
    {
        /// <summary>
        /// Gets or sets the Virtual Endpoint name of the Server Disaster Recovery Configuration to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Virtual Endpoint name of the Azure SQL Server Disaster Recovery Configuration to create.")]
        [ValidateNotNullOrEmpty]
        public string VirtualEndpointName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner resource group name for the Server Disaster Recovery Configuration to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the partner resource group name for the Azure SQL Server Disaster Recovery Configuration to create.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner server for the Server Disaster Recovery Configuration to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the partner server for the Azure SQL Server Disaster Recovery Configuration to create.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the failover policy of the Server Disaster Recovery Configuration to create.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy of the Azure SQL Server Disaster Recovery Configuration to create.")]
        [ValidateNotNullOrEmpty]
        public string FailoverPolicy { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> GetEntity()
        {
            // We try to get the Server Disaster Recovery Configuration. Since this is a create, we don't want the Server Disaster Recovery Configuration to exist
            try
            {
                ModelAdapter.ListServerDisasterRecoveryConfigurations(this.ResourceGroupName, this.ServerName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no Server Disaster Recovery Configuration with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The Server Disaster Recovery Configuration already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerDisasterRecoveryConfigurationNameExists, this.VirtualEndpointName, this.ServerName), "ServerDisasterRecoveryConfigurationName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> model)
        {
            List<Model.AzureSqlServerDisasterRecoveryConfigurationModel> newEntity = new List<AzureSqlServerDisasterRecoveryConfigurationModel>();

            newEntity.Add(new AzureSqlServerDisasterRecoveryConfigurationModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                ServerDisasterRecoveryConfigurationName = VirtualEndpointName,
                Location = "",
                AutoFailover = "",
                FailoverPolicy = FailoverPolicy,
                PartnerServerName = PartnerServerName,
                Role = "Primary"
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new Server Disaster Recovery Configuration
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> PersistChanges(IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> entity)
        {
            string partnerServerId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}",
                    DefaultContext.Subscription.Id, PartnerResourceGroupName, PartnerServerName);

            return new List<AzureSqlServerDisasterRecoveryConfigurationModel>() {
                ModelAdapter.CreateServerDisasterRecoveryConfiguration(this.ResourceGroupName, this.ServerName, partnerServerId, entity.First())
            };
        }
    }
}
