namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>
    /// Properties of RedisEnterprise databases, as opposed to general resource properties like location, tags
    /// </summary>
    public partial class DatabaseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabaseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabasePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientProtocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol? _clientProtocol;

        /// <summary>
        /// Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols. Default is TLS-encrypted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Protocol? ClientProtocol { get => this._clientProtocol; set => this._clientProtocol = value; }

        /// <summary>Backing field for <see cref="ClusteringPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy? _clusteringPolicy;

        /// <summary>Clustering policy - default is OSSCluster. Specified at create time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ClusteringPolicy? ClusteringPolicy { get => this._clusteringPolicy; set => this._clusteringPolicy = value; }

        /// <summary>Backing field for <see cref="EvictionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy? _evictionPolicy;

        /// <summary>Redis eviction policy - default is VolatileLRU</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.EvictionPolicy? EvictionPolicy { get => this._evictionPolicy; set => this._evictionPolicy = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabasePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ResourceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IDatabasePropertiesInternal.ResourceState { get => this._resourceState; set { {_resourceState = value;} } }

        /// <summary>Backing field for <see cref="Module" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule[] _module;

        /// <summary>
        /// Optional set of redis modules to enable in this database - modules can only be added at creation time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule[] Module { get => this._module; set => this._module = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        /// <summary>
        /// TCP port of the database endpoint. Specified at create time. Defaults to an available port.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? _provisioningState;

        /// <summary>Current provisioning status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? _resourceState;

        /// <summary>Current resource status of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? ResourceState { get => this._resourceState; }

        /// <summary>Creates an new <see cref="DatabaseProperties" /> instance.</summary>
        public DatabaseProperties()
        {

        }
    }
    /// Properties of RedisEnterprise databases, as opposed to general resource properties like location, tags
    public partial interface IDatabaseProperties :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule[] Module { get; set; }
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
    /// Properties of RedisEnterprise databases, as opposed to general resource properties like location, tags
    internal partial interface IDatabasePropertiesInternal

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
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20201001Preview.IModule[] Module { get; set; }
        /// <summary>
        /// TCP port of the database endpoint. Specified at create time. Defaults to an available port.
        /// </summary>
        int? Port { get; set; }
        /// <summary>Current provisioning status of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Current resource status of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ResourceState? ResourceState { get; set; }

    }
}