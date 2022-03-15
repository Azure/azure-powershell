using System;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model
{
    public class AzureSqlManagedInstanceLinkModel
    {
        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the mi link's type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the mi link's resource id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets target database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets target database
        /// </summary>
        public string TargetDatabase { get; set; }

        /// <summary>
        /// Gets or sets source endpoint
        /// </summary>
        public string SourceEndpoint { get; set; }

        /// <summary>
        /// Gets or sets primary availability group name
        /// </summary>
        public string PrimaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets secondary availability group name
        /// </summary>
        public string SecondaryAvailabilityGroupName { get; set; }

        /// <summary>
        /// Gets or sets replication mode
        /// </summary>
        public string ReplicationMode { get; set; }

        /// <summary>
        /// Gets or sets distributed availability group id
        /// </summary>
        public Guid? DistributedAvailabilityGroupId { get; set; }

        /// <summary>
        /// Gets or sets source replica id
        /// </summary>
        public Guid? SourceReplicaId { get; set; }

        /// <summary>
        /// Gets or sets target replica id
        /// </summary>
        public Guid? TargetReplicaId { get; set; }

        /// <summary>
        /// Gets or sets link state
        /// </summary>
        public string LinkState { get; set; }

        /// <summary>
        /// Gets or sets last hardened numbers
        /// </summary>
        public string LastHardenedLsn { get; set; }
    }
}
