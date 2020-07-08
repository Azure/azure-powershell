namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Represents a connected cluster.</summary>
    public partial class ConnectedCluster :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedCluster,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.TrackedResource();

        /// <summary>The client app id configured on target K8 cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileClientAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileClientAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileClientAppId = value; }

        /// <summary>The server app id to access AD server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileServerAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileServerAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileServerAppId = value; }

        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfileTenantId = value; }

        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AgentPublicKeyCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AgentPublicKeyCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AgentPublicKeyCertificate = value; }

        /// <summary>Version of the agent running on the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AgentVersion; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentity _identity;

        /// <summary>The identity of the connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterIdentity()); set => this._identity = value; }

        /// <summary>
        /// The principal id of connected cluster identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant id associated with the connected cluster. This property will only be provided for a system assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The type of identity used for the connected cluster. The type 'SystemAssigned, includes a system created identity. The
        /// type 'None' means no identity is assigned to the connected cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ResourceIdentityType IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).Type = value; }

        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).KubernetesVersion; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for AadProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.AadProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AadProfile = value; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).AgentVersion = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentity Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for KubernetesVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).KubernetesVersion = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterProperties Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for TotalNodeCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterInternal.TotalNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).TotalNodeCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).TotalNodeCount = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterProperties _property;

        /// <summary>Describes the connected cluster resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterProperties()); set => this._property = value; }

        /// <summary>The current deployment state of connectedClusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>Number of nodes present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public int? TotalNodeCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal)Property).TotalNodeCount; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.IResourceInternal)__trackedResource).Type; }

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
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResource
    {
        /// <summary>The client app id configured on target K8 cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client app id configured on target K8 cluster ",
        SerializedName = @"clientAppId",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileClientAppId { get; set; }
        /// <summary>The server app id to access AD server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server app id to access AD server",
        SerializedName = @"serverAppId",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileServerAppId { get; set; }
        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The aad tenant id which is configured on target K8s cluster",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string AadProfileTenantId { get; set; }
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
        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Kubernetes version of the connected cluster resource",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get;  }
        /// <summary>The current deployment state of connectedClusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The current deployment state of connectedClusters.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api10.ITrackedResourceInternal
    {
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile AadProfile { get; set; }
        /// <summary>The client app id configured on target K8 cluster</summary>
        string AadProfileClientAppId { get; set; }
        /// <summary>The server app id to access AD server</summary>
        string AadProfileServerAppId { get; set; }
        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        string AadProfileTenantId { get; set; }
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        string AgentPublicKeyCertificate { get; set; }
        /// <summary>Version of the agent running on the connected cluster resource</summary>
        string AgentVersion { get; set; }
        /// <summary>The identity of the connected cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterIdentity Identity { get; set; }
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
        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        string KubernetesVersion { get; set; }
        /// <summary>Describes the connected cluster resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterProperties Property { get; set; }
        /// <summary>The current deployment state of connectedClusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Number of nodes present in the connected cluster resource</summary>
        int? TotalNodeCount { get; set; }

    }
}