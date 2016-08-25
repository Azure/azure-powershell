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
using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Cmdlet
{
    /// <summary>
    /// Cmdlet to set a new Azure Sql Server Disaster Recovery Configuration (used for failover)
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerDisasterRecoveryConfiguration", SupportsShouldProcess = true)]
    public class SetAzureSqlServerDisasterRecoveryConfiguration : AzureSqlServerDisasterRecoveryConfigurationCmdletBase
    {

        internal const string ByFailoverParams = "ByFailoverParams";

        /// <summary>
        /// Gets or sets the Virtual Endpoint name of the Azure SQL Server Disaster Recovery Configuration
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Server Disaster Recovery Configuration.")]
        [ValidateNotNullOrEmpty]
        public string VirtualEndpointName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a failover.
        /// </summary>
        /// <returns></returns>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = ByFailoverParams,
            HelpMessage = "Whether this operation is a failover.")]
        public SwitchParameter Failover { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to make this failover will allow data loss.
        /// </summary>
        /// <returns></returns>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            ParameterSetName = ByFailoverParams,
            HelpMessage = "Whether this failover operation will allow data loss.")]
        public SwitchParameter AllowDataLoss { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> GetEntity()
        {
            return new List<AzureSqlServerDisasterRecoveryConfigurationModel>()
            {
                ModelAdapter.GetServerDisasterRecoveryConfiguration(this.ResourceGroupName, this.ServerName,
                    this.VirtualEndpointName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> model)
        {
            List<AzureSqlServerDisasterRecoveryConfigurationModel> newEntity =
                new List<AzureSqlServerDisasterRecoveryConfigurationModel>();

            AzureSqlServerDisasterRecoveryConfigurationModel entry = model.First();
            if (entry != null)
            {
                newEntity.Add(new AzureSqlServerDisasterRecoveryConfigurationModel()
                {
                    ResourceGroupName = entry.ResourceGroupName,
                    ServerName = entry.ServerName,
                    ServerDisasterRecoveryConfigurationName = entry.ServerDisasterRecoveryConfigurationName,
                    Location = entry.Location,
                    AutoFailover = entry.AutoFailover,
                    FailoverPolicy = entry.FailoverPolicy,
                    PartnerServerName = entry.PartnerServerName,
                    Role = entry.Role
                });
            }
            return newEntity;
        }

        /// <summary>
        /// Update the Server Disaster Recovery Configuration
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> PersistChanges(
            IEnumerable<AzureSqlServerDisasterRecoveryConfigurationModel> entity)
        {
            switch (ParameterSetName)
            {
                case ByFailoverParams:
                    ModelAdapter.FailoverServerDisasterRecoveryConfiguration(this.ResourceGroupName,
                        this.ServerName, entity.First(), AllowDataLoss.IsPresent);
                    break;
                default:
                    // Warning user that no options were provided so no action can be taken.
                    WriteWarning(Resources.SetDisasterRecoveryConfigurationNoOptionProvided);
                    break;
            }

            return entity;
        }
    }
}
