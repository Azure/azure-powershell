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
            HelpMessage = "The link type of the replication link. Valid values are Geo and Standby. Update operation does not support Named")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Geo", "Standby")]
        public string LinkType { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureReplicationLinkModel> GetEntity()
        {
            ICollection<AzureReplicationLinkModel> results;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(PartnerServerName)) && !WildcardPattern.ContainsWildcardCharacters(PartnerServerName))
            {
                results = new List<AzureReplicationLinkModel>();
                results.Add(ModelAdapter.GetLink(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName, this.PartnerServerName));
            }
            else
            {
                results = ModelAdapter.ListLinks(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.PartnerResourceGroupName);
            }

            return SubResourceWildcardFilter(PartnerServerName, results).Where(l => l.LinkId == this.LinkId);
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
