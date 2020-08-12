namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing a read only following database.</summary>
    public partial class ReadOnlyFollowingDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabase,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase __database = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Database();

        /// <summary>The name of the attached database configuration cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string AttachedDatabaseConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).AttachedDatabaseConfigurationName; }

        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? HotCachePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).HotCachePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).HotCachePeriod = value; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id; }

        /// <summary>Kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Kind = value; }

        /// <summary>The name of the leader cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string LeaderClusterResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).LeaderClusterResourceId; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type = value; }

        /// <summary>Internal Acessors for AttachedDatabaseConfigurationName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.AttachedDatabaseConfigurationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).AttachedDatabaseConfigurationName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).AttachedDatabaseConfigurationName = value; }

        /// <summary>Internal Acessors for LeaderClusterResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.LeaderClusterResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).LeaderClusterResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).LeaderClusterResourceId = value; }

        /// <summary>Internal Acessors for PrincipalsModificationKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.PrincipalsModificationKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).PrincipalsModificationKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).PrincipalsModificationKind = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for SoftDeletePeriod</summary>
        global::System.TimeSpan? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.SoftDeletePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).SoftDeletePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).SoftDeletePeriod = value; }

        /// <summary>Internal Acessors for Statistics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseInternal.Statistics { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).Statistics; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).Statistics = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name; }

        /// <summary>The principals modification kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).PrincipalsModificationKind; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties _property;

        /// <summary>The database properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadOnlyFollowingDatabaseProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? SoftDeletePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).SoftDeletePeriod; }

        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public float? StatisticsSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).StatisticsSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal)Property).StatisticsSize = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type; }

        /// <summary>Creates an new <see cref="ReadOnlyFollowingDatabase" /> instance.</summary>
        public ReadOnlyFollowingDatabase()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__database), __database);
            await eventListener.AssertObjectIsValid(nameof(__database), __database);
        }
    }
    /// Class representing a read only following database.
    public partial interface IReadOnlyFollowingDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase
    {
        /// <summary>The name of the attached database configuration cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the attached database configuration cluster",
        SerializedName = @"attachedDatabaseConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string AttachedDatabaseConfigurationName { get;  }
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time the data should be kept in cache for fast queries in TimeSpan.",
        SerializedName = @"hotCachePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>The name of the leader cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the leader cluster",
        SerializedName = @"leaderClusterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string LeaderClusterResourceId { get;  }
        /// <summary>The principals modification kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principals modification kind of the database",
        SerializedName = @"principalsModificationKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get;  }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the data should be kept before it stops being accessible to queries in TimeSpan.",
        SerializedName = @"softDeletePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SoftDeletePeriod { get;  }
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database size - the total size of compressed data and index in bytes.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(float) })]
        float? StatisticsSize { get; set; }

    }
    /// Class representing a read only following database.
    internal partial interface IReadOnlyFollowingDatabaseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal
    {
        /// <summary>The name of the attached database configuration cluster</summary>
        string AttachedDatabaseConfigurationName { get; set; }
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>The name of the leader cluster</summary>
        string LeaderClusterResourceId { get; set; }
        /// <summary>The principals modification kind of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get; set; }
        /// <summary>The database properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties Property { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        global::System.TimeSpan? SoftDeletePeriod { get; set; }
        /// <summary>The statistics of the database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Statistics { get; set; }
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        float? StatisticsSize { get; set; }

    }
}