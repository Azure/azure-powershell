namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ClusterUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ClusterUpdateTags" /> instance.</summary>
        public ClusterUpdateTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IClusterUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IClusterUpdateTagsInternal

    {

    }
}