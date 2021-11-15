namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Properties of the connected cluster.</summary>
    public partial class ConnectedClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal
    {

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

        /// <summary>Backing field for <see cref="ConnectivityStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? _connectivityStatus;

        /// <summary>Represents the connectivity status of the connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? ConnectivityStatus { get => this._connectivityStatus; }

        /// <summary>Backing field for <see cref="Distribution" /> property.</summary>
        private string _distribution;

        /// <summary>The Kubernetes distribution running on this connected cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string Distribution { get => this._distribution; set => this._distribution = value; }

        /// <summary>Backing field for <see cref="Infrastructure" /> property.</summary>
        private string _infrastructure;

        /// <summary>
        /// The infrastructure on which the Kubernetes cluster represented by this connected cluster is running on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string Infrastructure { get => this._infrastructure; set => this._infrastructure = value; }

        /// <summary>Backing field for <see cref="KubernetesVersion" /> property.</summary>
        private string _kubernetesVersion;

        /// <summary>The Kubernetes version of the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string KubernetesVersion { get => this._kubernetesVersion; }

        /// <summary>Backing field for <see cref="LastConnectivityTime" /> property.</summary>
        private global::System.DateTime? _lastConnectivityTime;

        /// <summary>
        /// Time representing the last instance when heart beat was received from the cluster
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public global::System.DateTime? LastConnectivityTime { get => this._lastConnectivityTime; }

        /// <summary>
        /// Backing field for <see cref="ManagedIdentityCertificateExpirationTime" /> property.
        /// </summary>
        private global::System.DateTime? _managedIdentityCertificateExpirationTime;

        /// <summary>Expiration time of the managed identity certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public global::System.DateTime? ManagedIdentityCertificateExpirationTime { get => this._managedIdentityCertificateExpirationTime; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.AgentVersion { get => this._agentVersion; set { {_agentVersion = value;} } }

        /// <summary>Internal Acessors for ConnectivityStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ConnectivityStatus? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.ConnectivityStatus { get => this._connectivityStatus; set { {_connectivityStatus = value;} } }

        /// <summary>Internal Acessors for KubernetesVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.KubernetesVersion { get => this._kubernetesVersion; set { {_kubernetesVersion = value;} } }

        /// <summary>Internal Acessors for LastConnectivityTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.LastConnectivityTime { get => this._lastConnectivityTime; set { {_lastConnectivityTime = value;} } }

        /// <summary>Internal Acessors for ManagedIdentityCertificateExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.ManagedIdentityCertificateExpirationTime { get => this._managedIdentityCertificateExpirationTime; set { {_managedIdentityCertificateExpirationTime = value;} } }

        /// <summary>Internal Acessors for Offering</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.Offering { get => this._offering; set { {_offering = value;} } }

        /// <summary>Internal Acessors for TotalCoreCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.TotalCoreCount { get => this._totalCoreCount; set { {_totalCoreCount = value;} } }

        /// <summary>Internal Acessors for TotalNodeCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPropertiesInternal.TotalNodeCount { get => this._totalNodeCount; set { {_totalNodeCount = value;} } }

        /// <summary>Backing field for <see cref="Offering" /> property.</summary>
        private string _offering;

        /// <summary>Connected cluster offering</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string Offering { get => this._offering; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the connected cluster resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="TotalCoreCount" /> property.</summary>
        private int? _totalCoreCount;

        /// <summary>Number of CPU cores present in the connected cluster resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public int? TotalCoreCount { get => this._totalCoreCount; }

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
    /// Properties of the connected cluster.
    public partial interface IConnectedClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
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
    /// Properties of the connected cluster.
    internal partial interface IConnectedClusterPropertiesInternal

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
        /// <summary>Provisioning state of the connected cluster resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Number of CPU cores present in the connected cluster resource</summary>
        int? TotalCoreCount { get; set; }
        /// <summary>Number of nodes present in the connected cluster resource</summary>
        int? TotalNodeCount { get; set; }

    }
}