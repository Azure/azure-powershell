namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Resource tags</summary>
    public partial class GraphQueryUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTagsInternal
    {

        /// <summary>Creates an new <see cref="GraphQueryUpdateParametersTags" /> instance.</summary>
        public GraphQueryUpdateParametersTags()
        {

        }
    }
    /// Resource tags
    public partial interface IGraphQueryUpdateParametersTags :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags
    internal partial interface IGraphQueryUpdateParametersTagsInternal

    {

    }
}