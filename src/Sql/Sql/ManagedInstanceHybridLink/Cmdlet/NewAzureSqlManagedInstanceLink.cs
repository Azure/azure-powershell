using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Server Trust certificate
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink"), OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class NewAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipeline = true,
            HelpMessage = "The name of the Azure SQL Managed Instance")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the link name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the MI link")]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the primary availability group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipeline = true,
            HelpMessage = "The name of the primary availability group")]
        [ValidateNotNullOrEmpty]
        public string PrimaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the secondary availability group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 4,
            ValueFromPipeline = true,
            HelpMessage = "The name of the secondary availability group")]
        [ValidateNotNullOrEmpty]
        public string SecondaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target database
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 5,
            ValueFromPipeline = true,
            HelpMessage = "The name of the target database")]
        [ValidateNotNullOrEmpty]
        public string TargetDatabase { get; set; }

        /// <summary>
        /// Gets or sets the source endpoint
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 6,
            ValueFromPipeline = true,
            HelpMessage = "The adress of the source endpoint")]
        [ValidateNotNullOrEmpty]
        public string SourceEndpoint { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            // We try to get the MI Link. Since this is a create, we don't want the link to exist
            try
            {
                ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, LinkName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The Link already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ManagedInstanceLinkAlreadyExists, LinkName, InstanceName),
                "LinkName");
        }


        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            List<AzureSqlManagedInstanceLinkModel> newEntity = new List<AzureSqlManagedInstanceLinkModel>
            {
                new AzureSqlManagedInstanceLinkModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    ManagedInstanceName = InstanceName,
                    DistributedAvailabilityGroupName = LinkName,
                    PrimaryAvailabilityGroupName = PrimaryAvailabilityGroupName,
                    SecondaryAvailabilityGroupName = SecondaryAvailabilityGroupName,
                    TargetDatabase = TargetDatabase,
                    SourceEndpoint = SourceEndpoint,
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Create the new Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceLinkModel> entity)
        {
            return new List<AzureSqlManagedInstanceLinkModel>() {
                ModelAdapter.CreateManagedInstanceLink(entity.First())
            };
        }
    }
}
