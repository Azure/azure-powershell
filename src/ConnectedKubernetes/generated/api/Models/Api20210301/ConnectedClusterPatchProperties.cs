namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Properties which can be patched on the connected cluster resource.</summary>
    public partial class ConnectedClusterPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPatchPropertiesInternal
    {

        /// <summary>Creates an new <see cref="ConnectedClusterPatchProperties" /> instance.</summary>
        public ConnectedClusterPatchProperties()
        {

        }
    }
    /// Properties which can be patched on the connected cluster resource.
    public partial interface IConnectedClusterPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
    {

    }
    /// Properties which can be patched on the connected cluster resource.
    internal partial interface IConnectedClusterPatchPropertiesInternal

    {

    }
}