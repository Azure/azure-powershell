namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    public partial class ConnectedClusterPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentPublicKeyCertificate" /> property.</summary>
        private string _agentPublicKeyCertificate;

        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string AgentPublicKeyCertificate { get => this._agentPublicKeyCertificate; set => this._agentPublicKeyCertificate = value; }

        /// <summary>Creates an new <see cref="ConnectedClusterPatchProperties" /> instance.</summary>
        public ConnectedClusterPatchProperties()
        {

        }
    }
    public partial interface IConnectedClusterPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.",
        SerializedName = @"agentPublicKeyCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string AgentPublicKeyCertificate { get; set; }

    }
    internal partial interface IConnectedClusterPatchPropertiesInternal

    {
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        string AgentPublicKeyCertificate { get; set; }

    }
}