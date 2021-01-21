namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Graph query list result.</summary>
    public partial class GraphQueryListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource[] Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to fetch the next set of queries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource[] _value;

        /// <summary>An array of graph queries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="GraphQueryListResult" /> instance.</summary>
        public GraphQueryListResult()
        {

        }
    }
    /// Graph query list result.
    public partial interface IGraphQueryListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable
    {
        /// <summary>URL to fetch the next set of queries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to fetch the next set of queries.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>An array of graph queries.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An array of graph queries.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource[] Value { get;  }

    }
    /// Graph query list result.
    internal partial interface IGraphQueryListResultInternal

    {
        /// <summary>URL to fetch the next set of queries.</summary>
        string NextLink { get; set; }
        /// <summary>An array of graph queries.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource[] Value { get; set; }

    }
}