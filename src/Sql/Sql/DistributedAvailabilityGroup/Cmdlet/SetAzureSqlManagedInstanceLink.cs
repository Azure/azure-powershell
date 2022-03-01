using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceLink",
        DefaultParameterSetName = SetParameterSet), OutputType(typeof(AzureSqlManagedInstanceLinkModel))]
    public class SetAzureSqlManagedInstanceLink : AzureSqlManagedInstanceLinkCmdletBase
    {
        private const string SetParameterSet = "SetParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = SetParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = SetParameterSet,
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
            ParameterSetName = SetParameterSet,
            Position = 2,
            ValueFromPipeline = true,
            HelpMessage = "The name of the MI link")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/distributedAvailabilityGroups", nameof(ResourceGroupName), nameof(InstanceName))]
        [ValidateNotNullOrEmpty]
        public string LinkName { get; set; }

        /// <summary>
        /// Gets or sets the replication mode
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = SetParameterSet,
            Position = 3,
            ValueFromPipeline = true,
            HelpMessage = "The value of replication mode. Possible values include 'Sync' and 'Async'")]
        [PSArgumentCompleter("Sync", "Async")]
        [ValidateNotNullOrEmpty]
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceLinkModel>() { ModelAdapter.GetManagedInstanceLink(ResourceGroupName, InstanceName, LinkName) };
        }


        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedInstanceLinkModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceLinkModel> model)
        {
            List<AzureSqlManagedInstanceLinkModel> newEntity = new List<AzureSqlManagedInstanceLinkModel> { };
            var updatedModel = model.First();
            updatedModel.ReplicationMode = ReplicationMode;
            newEntity.Add(updatedModel);
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
                ModelAdapter.UpdateManagedInstanceLink(entity.First())
            };
        }
    }
}
