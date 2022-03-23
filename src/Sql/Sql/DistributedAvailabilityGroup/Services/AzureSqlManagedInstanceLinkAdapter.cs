using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Services
{
    /// <summary>
    /// Adapter for ManagedInstanceLink operations
    /// </summary>
    public class AzureSqlManagedInstanceLinkAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlManagedInstanceLinkCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceLinkCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ManagedInstanceLink adapter
        /// </summary>
        /// <param name="context"></param>
        public AzureSqlManagedInstanceLinkAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceLinkCommunicator(Context);
        }

        /// <summary>
        /// Gets a managed instance link in a managed instance
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="distributedAvailabilityGroupName">Name of the DAG</param>
        /// <returns>The managed instance link</returns>
        public AzureSqlManagedInstanceLinkModel GetManagedInstanceLink(string resourceGroupName, string instanceName, string distributedAvailabilityGroupName)
        {
            var resp = Communicator.Get(resourceGroupName, instanceName, distributedAvailabilityGroupName);
            return CreateManagedInstanceLinkModelFromResponse(resourceGroupName, instanceName, resp);
        }

        /// <summary>
        /// Gets a list of all distributed availiability groups in managed instance
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="instanceName"></param>
        /// <returns>A list of all the server trust certificates</returns>
        public List<AzureSqlManagedInstanceLinkModel> ListManagedInstanceLinks(string resourceGroupName, string instanceName)
        {
            var resp = Communicator.List(resourceGroupName, instanceName);

            return resp.Select((dag) => CreateManagedInstanceLinkModelFromResponse(resourceGroupName, instanceName, dag)).ToList();
        }

        /// <summary>
        /// Creates a new managed instance link
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Managed Instance Link</returns>
        internal AzureSqlManagedInstanceLinkModel CreateManagedInstanceLink(AzureSqlManagedInstanceLinkModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.DistributedAvailabilityGroup
            {
                TargetDatabase = model.TargetDatabase,
                SourceEndpoint = model.SourceEndpoint, 
                PrimaryAvailabilityGroupName = model.PrimaryAvailabilityGroupName,
                SecondaryAvailabilityGroupName = model.SecondaryAvailabilityGroupName,
            });

            return CreateManagedInstanceLinkModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
        }

        /// <summary>
        /// Updates managed instance link
        /// </summary>
        /// <param name="model">The input parameters for the update operation</param>
        /// <returns>The updated Azure Sql Managed Instance Link</returns>
        internal AzureSqlManagedInstanceLinkModel UpdateManagedInstanceLink(AzureSqlManagedInstanceLinkModel model)
        {
            var resp = Communicator.Update(model.ResourceGroupName, model.InstanceName, model.Name, new Management.Sql.Models.DistributedAvailabilityGroup
            {
                ReplicationMode = model.ReplicationMode,
            });

            return CreateManagedInstanceLinkModelFromResponse(model.ResourceGroupName, model.InstanceName, resp);
        }

        /// <summary>
        /// Deletes a managed instance link
        /// </summary>
        /// <param name="resourceGroupName">Resource group used by the managed instance</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <param name="managedInstanceLinkName">Name of the instance link to delete</param>
        public void RemoveManagedInstanceLink(string resourceGroupName, string instanceName, string managedInstanceLinkName)
        {
            Communicator.Remove(resourceGroupName, instanceName, managedInstanceLinkName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.DistributedAvailabilityGroup to AzureSqlManagedInstanceLinkModel
        /// </summary>
        /// <param name="resp">The management client distributed availiability group response to convert</param>
        /// <returns>The converted managed instance link model</returns>
        private static AzureSqlManagedInstanceLinkModel CreateManagedInstanceLinkModelFromResponse(string resourceGroupName, string instanceName, Management.Sql.Models.DistributedAvailabilityGroup managedInstanceLink)
        {
            AzureSqlManagedInstanceLinkModel managedInstanceLinkModel = new AzureSqlManagedInstanceLinkModel()
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = instanceName,
                Id = managedInstanceLink.Id,
                Type = managedInstanceLink.Type,
                Name = managedInstanceLink.Name,
                TargetDatabase = managedInstanceLink.TargetDatabase,
                SourceEndpoint = managedInstanceLink.SourceEndpoint,
                ReplicationMode = managedInstanceLink.ReplicationMode,
                PrimaryAvailabilityGroupName = managedInstanceLink.PrimaryAvailabilityGroupName,
                SecondaryAvailabilityGroupName = managedInstanceLink.SecondaryAvailabilityGroupName,
                DistributedAvailabilityGroupId = managedInstanceLink.DistributedAvailabilityGroupId,
                SourceReplicaId = managedInstanceLink.SourceReplicaId,
                TargetReplicaId = managedInstanceLink.TargetReplicaId,
                LinkState = managedInstanceLink.LinkState,
                LastHardenedLsn =managedInstanceLink.LastHardenedLsn,
            };
            return managedInstanceLinkModel;
        }
    }
}
