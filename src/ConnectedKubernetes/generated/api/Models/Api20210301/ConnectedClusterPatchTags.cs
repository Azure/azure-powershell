namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ConnectedClusterPatchTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPatchTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IConnectedClusterPatchTagsInternal
    {

        /// <summary>Creates an new <see cref="ConnectedClusterPatchTags" /> instance.</summary>
        public ConnectedClusterPatchTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IConnectedClusterPatchTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IConnectedClusterPatchTagsInternal

    {

    }
}