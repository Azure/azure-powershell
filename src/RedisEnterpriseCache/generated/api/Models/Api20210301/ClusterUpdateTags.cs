namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class ClusterUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IClusterUpdateTags,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IClusterUpdateTagsInternal
    {

        /// <summary>Creates an new <see cref="ClusterUpdateTags" /> instance.</summary>
        public ClusterUpdateTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IClusterUpdateTags :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IClusterUpdateTagsInternal

    {

    }
}