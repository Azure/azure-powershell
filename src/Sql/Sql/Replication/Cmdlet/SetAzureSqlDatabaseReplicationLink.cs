using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Replication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Replication.Cmdlet
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseReplicationLink", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureReplicationLinkModel))]
    public class SetAzureSqlDatabaseReplicationLink : AzureSqlDatabaseSecondaryCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure SQL Database to retrieve links for.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to retrieve links for.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group for the partner.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the resource group for the partner.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the id of the replication link
        /// </summary>
        [Parameter(Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The link id of the replication link")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public Guid LinkId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server that has the Azure SQL Database partner.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The name of the Azure SQL Server that has the Azure SQL Database partner.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "PartnerResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the link type of the replication link.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The link type of the replication link. Valid values are GEO and STANDBY. Update operation does not support NAMED")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("GEO", "STANDBY")]
        public string LinkType { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureReplicationLinkModel> GetEntity()
        {
            ICollection<AzureReplicationLinkModel> results;
            results = new List<AzureReplicationLinkModel>();
            results.Add(ModelAdapter.GetLink(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName, this.LinkId, true));

            return results;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureReplicationLinkModel> ApplyUserInputToModel(IEnumerable<AzureReplicationLinkModel> model)
        {
            List<AzureReplicationLinkModel> newEntity = new List<AzureReplicationLinkModel>();
            AzureReplicationLinkModel newModel = model.First();
            if (MyInvocation.BoundParameters.ContainsKey("LinkType"))
            {
                newModel.LinkType = this.LinkType;
            }
            newEntity.Add(newModel);

            return newEntity;
        }

        /// <summary>
        /// Update the replication link
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureReplicationLinkModel> PersistChanges(IEnumerable<AzureReplicationLinkModel> entity)
        {
            return new List<AzureReplicationLinkModel>() {
                ModelAdapter.UpdateLinkV2(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName, this.LinkId, entity.First())
            };
        }
    }
}
