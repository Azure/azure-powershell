namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing a read write database.</summary>
    public partial class ReadWriteDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabase,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase __database = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Database();

        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? HotCachePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).HotCachePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).HotCachePeriod = value; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id; }

        /// <summary>Indicates whether the database is followed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? IsFollowed { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).IsFollowed; }

        /// <summary>Kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Kind = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal)__database).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type = value; }

        /// <summary>Internal Acessors for IsFollowed</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseInternal.IsFollowed { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).IsFollowed; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).IsFollowed = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadWriteDatabaseProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Statistics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseInternal.Statistics { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).Statistics; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).Statistics = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseProperties _property;

        /// <summary>The database properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ReadWriteDatabaseProperties()); set => this._property = value; }

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? SoftDeletePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).SoftDeletePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).SoftDeletePeriod = value; }

        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public float? StatisticsSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).StatisticsSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal)Property).StatisticsSize = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__database).Type; }

        /// <summary>Creates an new <see cref="ReadWriteDatabase" /> instance.</summary>
        public ReadWriteDatabase()
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
    /// Class representing a read write database.
    public partial interface IReadWriteDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabase
    {
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time the data should be kept in cache for fast queries in TimeSpan.",
        SerializedName = @"hotCachePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>Indicates whether the database is followed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates whether the database is followed.",
        SerializedName = @"isFollowed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsFollowed { get;  }
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
        ReadOnly = false,
        Description = @"The time the data should be kept before it stops being accessible to queries in TimeSpan.",
        SerializedName = @"softDeletePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SoftDeletePeriod { get; set; }
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database size - the total size of compressed data and index in bytes.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(float) })]
        float? StatisticsSize { get; set; }

    }
    /// Class representing a read write database.
    internal partial interface IReadWriteDatabaseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseInternal
    {
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>Indicates whether the database is followed.</summary>
        bool? IsFollowed { get; set; }
        /// <summary>The database properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseProperties Property { get; set; }
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