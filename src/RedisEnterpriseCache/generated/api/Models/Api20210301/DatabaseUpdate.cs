namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>A partial update to the RedisEnterprise database</summary>
    public partial class DatabaseUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdateInternal
    {

        /// <summary>
        /// Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols. Default is TLS-encrypted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol? ClientProtocol { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ClientProtocol; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ClientProtocol = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol)""); }

        /// <summary>Clustering policy - default is OSSCluster. Specified at create time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy? ClusteringPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ClusteringPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ClusteringPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy)""); }

        /// <summary>Redis eviction policy - default is VolatileLRU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy? EvictionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).EvictionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).EvictionPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy)""); }

        /// <summary>Internal Acessors for Persistence</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistence Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdateInternal.Persistence { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Persistence; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Persistence = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdateInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseUpdateInternal.ResourceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ResourceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ResourceState = value; }

        /// <summary>
        /// Optional set of redis modules to enable in this database - modules can only be added at creation time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule[] Module { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Module; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Module = value ?? null /* arrayOf */; }

        /// <summary>Sets whether AOF is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public bool? PersistenceAofEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceAofEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceAofEnabled = value ?? default(bool); }

        /// <summary>Sets the frequency at which data is written to disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? PersistenceAofFrequency { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceAofFrequency; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceAofFrequency = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency)""); }

        /// <summary>Sets whether RDB is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public bool? PersistenceRdbEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceRdbEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceRdbEnabled = value ?? default(bool); }

        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? PersistenceRdbFrequency { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceRdbFrequency; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).PersistenceRdbFrequency = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency)""); }

        /// <summary>
        /// TCP port of the database endpoint. Specified at create time. Defaults to an available port.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public int? Port { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).Port = value ?? default(int); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties _property;

        /// <summary>Properties of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.DatabaseProperties()); set => this._property = value; }

        /// <summary>Current provisioning status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Current resource status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? ResourceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabasePropertiesInternal)Property).ResourceState; }

        /// <summary>Creates an new <see cref="DatabaseUpdate" /> instance.</summary>
        public DatabaseUpdate()
        {

        }
    }
    /// A partial update to the RedisEnterprise database
    public partial interface IDatabaseUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols. Default is TLS-encrypted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols. Default is TLS-encrypted.",
        SerializedName = @"clientProtocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol? ClientProtocol { get; set; }
        /// <summary>Clustering policy - default is OSSCluster. Specified at create time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Clustering policy - default is OSSCluster. Specified at create time.",
        SerializedName = @"clusteringPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy? ClusteringPolicy { get; set; }
        /// <summary>Redis eviction policy - default is VolatileLRU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Redis eviction policy - default is VolatileLRU",
        SerializedName = @"evictionPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy? EvictionPolicy { get; set; }
        /// <summary>
        /// Optional set of redis modules to enable in this database - modules can only be added at creation time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional set of redis modules to enable in this database - modules can only be added at creation time.",
        SerializedName = @"modules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule[] Module { get; set; }
        /// <summary>Sets whether AOF is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets whether AOF is enabled.",
        SerializedName = @"aofEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PersistenceAofEnabled { get; set; }
        /// <summary>Sets the frequency at which data is written to disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the frequency at which data is written to disk.",
        SerializedName = @"aofFrequency",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? PersistenceAofFrequency { get; set; }
        /// <summary>Sets whether RDB is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets whether RDB is enabled.",
        SerializedName = @"rdbEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PersistenceRdbEnabled { get; set; }
        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sets the frequency at which a snapshot of the database is created.",
        SerializedName = @"rdbFrequency",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? PersistenceRdbFrequency { get; set; }
        /// <summary>
        /// TCP port of the database endpoint. Specified at create time. Defaults to an available port.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"TCP port of the database endpoint. Specified at create time. Defaults to an available port.",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }
        /// <summary>Current provisioning status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current provisioning status of the database",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Current resource status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current resource status of the database",
        SerializedName = @"resourceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? ResourceState { get;  }

    }
    /// A partial update to the RedisEnterprise database
    internal partial interface IDatabaseUpdateInternal

    {
        /// <summary>
        /// Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols. Default is TLS-encrypted.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol? ClientProtocol { get; set; }
        /// <summary>Clustering policy - default is OSSCluster. Specified at create time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy? ClusteringPolicy { get; set; }
        /// <summary>Redis eviction policy - default is VolatileLRU</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy? EvictionPolicy { get; set; }
        /// <summary>
        /// Optional set of redis modules to enable in this database - modules can only be added at creation time.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule[] Module { get; set; }
        /// <summary>Persistence settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IPersistence Persistence { get; set; }
        /// <summary>Sets whether AOF is enabled.</summary>
        bool? PersistenceAofEnabled { get; set; }
        /// <summary>Sets the frequency at which data is written to disk.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.AofFrequency? PersistenceAofFrequency { get; set; }
        /// <summary>Sets whether RDB is enabled.</summary>
        bool? PersistenceRdbEnabled { get; set; }
        /// <summary>Sets the frequency at which a snapshot of the database is created.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.RdbFrequency? PersistenceRdbFrequency { get; set; }
        /// <summary>
        /// TCP port of the database endpoint. Specified at create time. Defaults to an available port.
        /// </summary>
        int? Port { get; set; }
        /// <summary>Properties of the database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IDatabaseProperties Property { get; set; }
        /// <summary>Current provisioning status of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Current resource status of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? ResourceState { get; set; }

    }
}