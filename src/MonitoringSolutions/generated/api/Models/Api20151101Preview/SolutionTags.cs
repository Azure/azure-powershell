namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class SolutionTags :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTagsInternal
    {

        /// <summary>Creates an new <see cref="SolutionTags" /> instance.</summary>
        public SolutionTags()
        {

        }
    }
    /// Resource tags
    public partial interface ISolutionTags :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface ISolutionTagsInternal

    {

    }
}