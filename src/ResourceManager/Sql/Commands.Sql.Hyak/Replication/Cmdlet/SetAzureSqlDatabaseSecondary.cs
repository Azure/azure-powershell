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
using Microsoft.Azure.Commands.Sql.Replication.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    /// <summary>
    /// Cmdlet to fail over Azure SQL Database Replication Link to the secondary database
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseSecondary",
        DefaultParameterSetName = NoOptionsSet,
        ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true)]
    public class SetAzureSqlDatabaseSecondary : AzureSqlDatabaseSecondaryCmdletBase
    {
        /// <summary>
        /// ParameterSet to set properties for a given Azure SQL Database Secondary
        /// </summary>
        internal const string NoOptionsSet = "NoOptionsSet";

        /// <summary>
        /// ParameterSet to get a Replication Link by its partner Azure SQL Server Name
        /// </summary>
        internal const string ByFailoverParams = "ByFailoverParams";

        /// <summary>
        /// Gets or sets the name of the primary Azure SQL Database with the replication link to remove.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to failover.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the partner resource group.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure Resource Group of the partner Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

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
        protected override IEnumerable<AzureReplicationLinkModel> GetEntity()
        {
            return ModelAdapter.ListLinks(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureReplicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureReplicationLinkModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to Azure SQL Server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureReplicationLinkModel> PersistChanges(IEnumerable<AzureReplicationLinkModel> entity)
        {

            switch (ParameterSetName)
            {
                case ByFailoverParams:
                    return new List<AzureReplicationLinkModel>() { ModelAdapter.FailoverLink(this.ResourceGroupName,
                        this.ServerName,
                        this.DatabaseName,
                        this.PartnerResourceGroupName,
                        this.AllowDataLoss.IsPresent)
                    };
                default:
                    // Warning user that no options were provided so no action can be taken.
                    WriteWarning(Resources.SetSecondaryNoOptionProvided);
                    break;
            }

            return entity;
        }
    }
}
