namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    public partial class ConnectedClusterAadProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfile,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterAadProfileInternal
    {

        /// <summary>Backing field for <see cref="ClientAppId" /> property.</summary>
        private string _clientAppId;

        /// <summary>The client app id configured on target K8 cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string ClientAppId { get => this._clientAppId; set => this._clientAppId = value; }

        /// <summary>Backing field for <see cref="ServerAppId" /> property.</summary>
        private string _serverAppId;

        /// <summary>The server app id to access AD server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string ServerAppId { get => this._serverAppId; set => this._serverAppId = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="ConnectedClusterAadProfile" /> instance.</summary>
        public ConnectedClusterAadProfile()
        {

        }
    }
    public partial interface IConnectedClusterAadProfile :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
    {
        /// <summary>The client app id configured on target K8 cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client app id configured on target K8 cluster ",
        SerializedName = @"clientAppId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientAppId { get; set; }
        /// <summary>The server app id to access AD server</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The server app id to access AD server",
        SerializedName = @"serverAppId",
        PossibleTypes = new [] { typeof(string) })]
        string ServerAppId { get; set; }
        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The aad tenant id which is configured on target K8s cluster",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    internal partial interface IConnectedClusterAadProfileInternal

    {
        /// <summary>The client app id configured on target K8 cluster</summary>
        string ClientAppId { get; set; }
        /// <summary>The server app id to access AD server</summary>
        string ServerAppId { get; set; }
        /// <summary>The aad tenant id which is configured on target K8s cluster</summary>
        string TenantId { get; set; }

    }
}