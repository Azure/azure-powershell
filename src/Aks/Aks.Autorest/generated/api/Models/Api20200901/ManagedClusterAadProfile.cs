namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>AADProfile specifies attributes for Azure Active Directory integration.</summary>
    public partial class ManagedClusterAadProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAadProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAadProfileInternal
    {

        /// <summary>Backing field for <see cref="AdminGroupObjectID" /> property.</summary>
        private string[] _adminGroupObjectID;

        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string[] AdminGroupObjectID { get => this._adminGroupObjectID; set => this._adminGroupObjectID = value; }

        /// <summary>Backing field for <see cref="ClientAppId" /> property.</summary>
        private string _clientAppId;

        /// <summary>The client AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ClientAppId { get => this._clientAppId; set => this._clientAppId = value; }

        /// <summary>Backing field for <see cref="EnableAzureRbac" /> property.</summary>
        private bool? _enableAzureRbac;

        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? EnableAzureRbac { get => this._enableAzureRbac; set => this._enableAzureRbac = value; }

        /// <summary>Backing field for <see cref="Managed" /> property.</summary>
        private bool? _managed;

        /// <summary>Whether to enable managed AAD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? Managed { get => this._managed; set => this._managed = value; }

        /// <summary>Backing field for <see cref="ServerAppId" /> property.</summary>
        private string _serverAppId;

        /// <summary>The server AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ServerAppId { get => this._serverAppId; set => this._serverAppId = value; }

        /// <summary>Backing field for <see cref="ServerAppSecret" /> property.</summary>
        private string _serverAppSecret;

        /// <summary>The server AAD application secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ServerAppSecret { get => this._serverAppSecret; set => this._serverAppSecret = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="ManagedClusterAadProfile" /> instance.</summary>
        public ManagedClusterAadProfile()
        {

        }
    }
    /// AADProfile specifies attributes for Azure Active Directory integration.
    public partial interface IManagedClusterAadProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AAD group object IDs that will have admin role of the cluster.",
        SerializedName = @"adminGroupObjectIDs",
        PossibleTypes = new [] { typeof(string) })]
        string[] AdminGroupObjectID { get; set; }
        /// <summary>The client AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client AAD application ID.",
        SerializedName = @"clientAppID",
        PossibleTypes = new [] { typeof(string) })]
        string ClientAppId { get; set; }
        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable Azure RBAC for Kubernetes authorization.",
        SerializedName = @"enableAzureRBAC",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAzureRbac { get; set; }
        /// <summary>Whether to enable managed AAD.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable managed AAD.",
        SerializedName = @"managed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Managed { get; set; }
        /// <summary>The server AAD application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server AAD application ID.",
        SerializedName = @"serverAppID",
        PossibleTypes = new [] { typeof(string) })]
        string ServerAppId { get; set; }
        /// <summary>The server AAD application secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server AAD application secret.",
        SerializedName = @"serverAppSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ServerAppSecret { get; set; }
        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.",
        SerializedName = @"tenantID",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// AADProfile specifies attributes for Azure Active Directory integration.
    internal partial interface IManagedClusterAadProfileInternal

    {
        /// <summary>AAD group object IDs that will have admin role of the cluster.</summary>
        string[] AdminGroupObjectID { get; set; }
        /// <summary>The client AAD application ID.</summary>
        string ClientAppId { get; set; }
        /// <summary>Whether to enable Azure RBAC for Kubernetes authorization.</summary>
        bool? EnableAzureRbac { get; set; }
        /// <summary>Whether to enable managed AAD.</summary>
        bool? Managed { get; set; }
        /// <summary>The server AAD application ID.</summary>
        string ServerAppId { get; set; }
        /// <summary>The server AAD application secret.</summary>
        string ServerAppSecret { get; set; }
        /// <summary>
        /// The AAD tenant ID to use for authentication. If not specified, will use the tenant of the deployment subscription.
        /// </summary>
        string TenantId { get; set; }

    }
}