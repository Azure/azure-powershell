namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Object containing updates for patch operations.</summary>
    public partial class ConnectedClusterPatch :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatch,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchInternal
    {

        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Inlined)]
        public string AgentPublicKeyCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchPropertiesInternal)Property).AgentPublicKeyCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchPropertiesInternal)Property).AgentPublicKeyCertificate = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchProperties Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterPatchProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchProperties _property;

        /// <summary>
        /// Describes the connected cluster resource properties that can be updated during PATCH operation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterPatchProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ConnectedClusterPatchTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ConnectedClusterPatch" /> instance.</summary>
        public ConnectedClusterPatch()
        {

        }
    }
    /// Object containing updates for patch operations.
    public partial interface IConnectedClusterPatch :
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
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchTags Tag { get; set; }

    }
    /// Object containing updates for patch operations.
    internal partial interface IConnectedClusterPatchInternal

    {
        /// <summary>
        /// Base64 encoded public certificate used by the agent to do the initial handshake to the backend services in Azure.
        /// </summary>
        string AgentPublicKeyCertificate { get; set; }
        /// <summary>
        /// Describes the connected cluster resource properties that can be updated during PATCH operation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchProperties Property { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.IConnectedClusterPatchTags Tag { get; set; }

    }
}