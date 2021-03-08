namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    public partial class ConnectedClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AadProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile _aadProfile;

        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile AadProfile { get => (this._aadProfile = this._aadProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterAadProfile()); set => this._aadProfile = value; }

        /// <summary>The client app id configured on target K8 cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileClientAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).ClientAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).ClientAppId = value; }

        /// <summary>The server app id to access AD server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileServerAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).ServerAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).ServerAppId = value; }

        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AadProfileTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal)AadProfile).TenantId = value; }

        /// <summary>Backing field for <see cref="AgentPublicKeyCertificate" /> property.</summary>
        private string _agentPublicKeyCertificate;

        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string AgentPublicKeyCertificate { get => this._agentPublicKeyCertificate; set => this._agentPublicKeyCertificate = value; }

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>Version of the agent running on the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; }

        /// <summary>Backing field for <see cref="KubernetesVersion" /> property.</summary>
        private string _kubernetesVersion;

        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string KubernetesVersion { get => this._kubernetesVersion; }

        /// <summary>Internal Acessors for AadProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal.AadProfile { get => (this._aadProfile = this._aadProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterAadProfile()); set { {_aadProfile = value;} } }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal.AgentVersion { get => this._agentVersion; set { {_agentVersion = value;} } }

        /// <summary>Internal Acessors for KubernetesVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal.KubernetesVersion { get => this._kubernetesVersion; set { {_kubernetesVersion = value;} } }

        /// <summary>Internal Acessors for TotalNodeCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPropertiesInternal.TotalNodeCount { get => this._totalNodeCount; set { {_totalNodeCount = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? _provisioningState;

        /// <summary>The current deployment state of connectedClusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="TotalNodeCount" /> property.</summary>
        private int? _totalNodeCount;

        /// <summary>Number of nodes present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public int? TotalNodeCount { get => this._totalNodeCount; }

        /// <summary>Creates an new <see cref="ConnectedClusterProperties" /> instance.</summary>
        public ConnectedClusterProperties()
        {

        }
    }
    public partial interface IConnectedClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
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
    internal partial interface IConnectedClusterPropertiesInternal

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
        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        string KubernetesVersion { get; set; }
        /// <summary>The current deployment state of connectedClusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Number of nodes present in the connected cluster resource</summary>
        int? TotalNodeCount { get; set; }

    }
}