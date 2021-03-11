namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Represents a connected cluster.</summary>
    public partial class ConnectedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedCluster,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.TrackedResource();

        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AgentPublicKeyCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).AgentPublicKeyCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).AgentPublicKeyCertificate = value; }

        /// <summary>Version of the agent running on the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).AgentVersion; }

        /// <summary>Represents the connectivity status of the connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? ConnectivityStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ConnectivityStatus; }

        /// <summary>The Kubernetes distribution running on this connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string Distribution { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Distribution; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Distribution = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity _identity;

        /// <summary>The identity of the connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterIdentity()); set => this._identity = value; }

        /// <summary>
        /// The principal id of connected cluster identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant id associated with the connected cluster. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The
        /// type 'None' means no identity is assigned to the connected cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).Type = value; }

        /// <summary>
        /// The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string Infrastructure { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Infrastructure; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Infrastructure = value; }

        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).KubernetesVersion; }

        /// <summary>
        /// Time representing the last instance when heart beat was received from the cluster
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastConnectivityTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).LastConnectivityTime; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Expiration time of the managed identity certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public global::System.DateTime? ManagedIdentityCertificateExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ManagedIdentityCertificateExpirationTime; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).AgentVersion = value; }

        /// <summary>Internal Acessors for ConnectivityStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.ConnectivityStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ConnectivityStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ConnectivityStatus = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for KubernetesVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).KubernetesVersion = value; }

        /// <summary>Internal Acessors for LastConnectivityTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.LastConnectivityTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).LastConnectivityTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).LastConnectivityTime = value; }

        /// <summary>Internal Acessors for ManagedIdentityCertificateExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.ManagedIdentityCertificateExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ManagedIdentityCertificateExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ManagedIdentityCertificateExpirationTime = value; }

        /// <summary>Internal Acessors for Offering</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.Offering { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Offering; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Offering = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.SystemData()); set { {_systemData = value;} } }

        /// <summary>Internal Acessors for TotalCoreCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.TotalCoreCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalCoreCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalCoreCount = value; }

        /// <summary>Internal Acessors for TotalNodeCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterInternal.TotalNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalNodeCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalNodeCount = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Name; }

        /// <summary>Connected cluster offering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string Offering { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).Offering; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties _property;

        /// <summary>Describes the connected cluster resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ConnectedClusterProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the connected cluster resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData _systemData;

        /// <summary>Metadata pertaining to creation and last modification of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedAt = value; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedBy = value; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).CreatedByType = value; }

        /// <summary>The timestamp of resource modification (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedAt = value; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedBy = value; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemDataInternal)SystemData).LastModifiedByType = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>Number of CPU cores present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public int? TotalCoreCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalCoreCount; }

        /// <summary>Number of nodes present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public int? TotalNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal)Property).TotalNodeCount; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="ConnectedCluster" /> instance.</summary>
        public ConnectedCluster()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// Represents a connected cluster.
    public partial interface IConnectedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResource
    {
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.",
        SerializedName = @"agentPublicKeyCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string AgentPublicKeyCertificate { get; set; }
        /// <summary>Version of the agent running on the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the agent running on the connected cluster resource",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get;  }
        /// <summary>Represents the connectivity status of the connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Represents the connectivity status of the connected cluster.",
        SerializedName = @"connectivityStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? ConnectivityStatus { get;  }
        /// <summary>The Kubernetes distribution running on this connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Kubernetes distribution running on this connected cluster.",
        SerializedName = @"distribution",
        PossibleTypes = new [] { typeof(string) })]
        string Distribution { get; set; }
        /// <summary>
        /// The principal id of connected cluster identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of connected cluster identity. This property will only be provided for a system assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant id associated with the connected cluster. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant id associated with the connected cluster. This property will only be provided for a system assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>
        /// The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The
        /// type 'None' means no identity is assigned to the connected cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The type 'None' means no identity is assigned to the connected cluster.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType IdentityType { get; set; }
        /// <summary>
        /// The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.",
        SerializedName = @"infrastructure",
        PossibleTypes = new [] { typeof(string) })]
        string Infrastructure { get; set; }
        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Kubernetes version of the connected cluster resource",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get;  }
        /// <summary>
        /// Time representing the last instance when heart beat was received from the cluster
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Time representing the last instance when heart beat was received from the cluster",
        SerializedName = @"lastConnectivityTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastConnectivityTime { get;  }
        /// <summary>Expiration time of the managed identity certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Expiration time of the managed identity certificate",
        SerializedName = @"managedIdentityCertificateExpirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ManagedIdentityCertificateExpirationTime { get;  }
        /// <summary>Connected cluster offering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Connected cluster offering",
        SerializedName = @"offering",
        PossibleTypes = new [] { typeof(string) })]
        string Offering { get;  }
        /// <summary>Provisioning state of the connected cluster resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Provisioning state of the connected cluster resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource modification (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource modification (UTC).",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>Number of CPU cores present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of CPU cores present in the connected cluster resource",
        SerializedName = @"totalCoreCount",
        PossibleTypes = new [] { typeof(int) })]
        int? TotalCoreCount { get;  }
        /// <summary>Number of nodes present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of nodes present in the connected cluster resource",
        SerializedName = @"totalNodeCount",
        PossibleTypes = new [] { typeof(int) })]
        int? TotalNodeCount { get;  }

    }
    /// Represents a connected cluster.
    internal partial interface IConnectedClusterInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20.ITrackedResourceInternal
    {
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        string AgentPublicKeyCertificate { get; set; }
        /// <summary>Version of the agent running on the connected cluster resource</summary>
        string AgentVersion { get; set; }
        /// <summary>Represents the connectivity status of the connected cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? ConnectivityStatus { get; set; }
        /// <summary>The Kubernetes distribution running on this connected cluster.</summary>
        string Distribution { get; set; }
        /// <summary>The identity of the connected cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterIdentity Identity { get; set; }
        /// <summary>
        /// The principal id of connected cluster identity. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant id associated with the connected cluster. This property will only be provided for a system assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The
        /// type 'None' means no identity is assigned to the connected cluster.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType IdentityType { get; set; }
        /// <summary>
        /// The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
        /// </summary>
        string Infrastructure { get; set; }
        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        string KubernetesVersion { get; set; }
        /// <summary>
        /// Time representing the last instance when heart beat was received from the cluster
        /// </summary>
        global::System.DateTime? LastConnectivityTime { get; set; }
        /// <summary>Expiration time of the managed identity certificate</summary>
        global::System.DateTime? ManagedIdentityCertificateExpirationTime { get; set; }
        /// <summary>Connected cluster offering</summary>
        string Offering { get; set; }
        /// <summary>Describes the connected cluster resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties Property { get; set; }
        /// <summary>Provisioning state of the connected cluster resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Metadata pertaining to creation and last modification of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource modification (UTC).</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.LastModifiedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>Number of CPU cores present in the connected cluster resource</summary>
        int? TotalCoreCount { get; set; }
        /// <summary>Number of nodes present in the connected cluster resource</summary>
        int? TotalNodeCount { get; set; }

    }
}