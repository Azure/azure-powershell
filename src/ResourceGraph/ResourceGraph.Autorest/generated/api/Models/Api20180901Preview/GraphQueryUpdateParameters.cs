namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>
    /// The parameters that can be provided when updating workbook properties properties.
    /// </summary>
    public partial class GraphQueryUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersInternal
    {

        /// <summary>The description of a graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParametersInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParametersInternal)Property).Description = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParameters Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.GraphQueryPropertiesUpdateParameters()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParameters _property;

        /// <summary>Metadata describing a graph query for an Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.GraphQueryPropertiesUpdateParameters()); set => this._property = value; }

        /// <summary>KQL query that will be graph.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public string Query { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParametersInternal)Property).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParametersInternal)Property).Query = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.GraphQueryUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="GraphQueryUpdateParameters" /> instance.</summary>
        public GraphQueryUpdateParameters()
        {

        }
    }
    /// The parameters that can be provided when updating workbook properties properties.
    public partial interface IGraphQueryUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable
    {
        /// <summary>The description of a graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of a graph query.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>KQL query that will be graph.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"KQL query that will be graph.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags Tag { get; set; }

    }
    /// The parameters that can be provided when updating workbook properties properties.
    internal partial interface IGraphQueryUpdateParametersInternal

    {
        /// <summary>The description of a graph query.</summary>
        string Description { get; set; }
        /// <summary>Metadata describing a graph query for an Azure resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesUpdateParameters Property { get; set; }
        /// <summary>KQL query that will be graph.</summary>
        string Query { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryUpdateParametersTags Tag { get; set; }

    }
}