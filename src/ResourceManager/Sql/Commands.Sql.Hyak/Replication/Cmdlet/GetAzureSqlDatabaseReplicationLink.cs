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

using Microsoft.Azure.Commands.Sql.Replication.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseReplicationLink",
        DefaultParameterSetName = ByDatabaseName,
        ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlDatabaseReplicationLink : AzureSqlDatabaseSecondaryCmdletBase
    {
        /// <summary>
        /// ParameterSet to get all Replication Links for a given Azure SQL Database
        /// </summary>
        internal const string ByDatabaseName = "ByDatabaseName";

        /// <summary>
        /// ParameterSet to get a Replication Link by its partner Azure SQL Server Name
        /// </summary>
        internal const string ByPartnerServerName = "ByPartnerServerName";

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database to retrieve links for.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to retrieve links for.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group for the partner.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group for the partner.")]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server that has the Azure SQL Database partner.
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = ByPartnerServerName,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The name of the Azure SQL Server that has the Azure SQL Database partner.")]
        [ValidateNotNullOrEmpty]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureReplicationLinkModel> GetEntity()
        {
            ICollection<AzureReplicationLinkModel> results;

            if (ParameterSetName == ByPartnerServerName)
            {
                results = new List<AzureReplicationLinkModel>();
                results.Add(ModelAdapter.GetLink(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName, this.PartnerServerName));
            }
            else
            {
                results = ModelAdapter.ListLinks(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName);
            }

            return results;
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
            return entity;
        }
    }
}
