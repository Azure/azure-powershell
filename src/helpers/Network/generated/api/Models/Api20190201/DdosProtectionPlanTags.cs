namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class DdosProtectionPlanTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanTags,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosProtectionPlanTagsInternal
    {

        /// <summary>Creates an new <see cref="DdosProtectionPlanTags" /> instance.</summary>
        public DdosProtectionPlanTags()
        {

        }
    }
    /// Resource tags.
    public partial interface IDdosProtectionPlanTags :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface IDdosProtectionPlanTagsInternal

    {

    }
}