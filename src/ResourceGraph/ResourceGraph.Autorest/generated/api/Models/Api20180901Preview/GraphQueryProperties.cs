namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Properties that contain a graph query.</summary>
    public partial class GraphQueryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of a graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Internal Acessors for ResultKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal.ResultKind { get => this._resultKind; set { {_resultKind = value;} } }

        /// <summary>Internal Acessors for TimeModified</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal.TimeModified { get => this._timeModified; set { {_timeModified = value;} } }

        /// <summary>Backing field for <see cref="Query" /> property.</summary>
        private string _query;

        /// <summary>KQL query that will be graph.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public string Query { get => this._query; set => this._query = value; }

        /// <summary>Backing field for <see cref="ResultKind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? _resultKind;

        /// <summary>Enum indicating a type of graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? ResultKind { get => this._resultKind; }

        /// <summary>Backing field for <see cref="TimeModified" /> property.</summary>
        private global::System.DateTime? _timeModified;

        /// <summary>
        /// Date and time in UTC of the last modification that was made to this graph query definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeModified { get => this._timeModified; }

        /// <summary>Creates an new <see cref="GraphQueryProperties" /> instance.</summary>
        public GraphQueryProperties()
        {

        }
    }
    /// Properties that contain a graph query.
    public partial interface IGraphQueryProperties :
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
        Required = true,
        ReadOnly = false,
        Description = @"KQL query that will be graph.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>Enum indicating a type of graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Enum indicating a type of graph query.",
        SerializedName = @"resultKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? ResultKind { get;  }
        /// <summary>
        /// Date and time in UTC of the last modification that was made to this graph query definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date and time in UTC of the last modification that was made to this graph query definition.",
        SerializedName = @"timeModified",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeModified { get;  }

    }
    /// Properties that contain a graph query.
    internal partial interface IGraphQueryPropertiesInternal

    {
        /// <summary>The description of a graph query.</summary>
        string Description { get; set; }
        /// <summary>KQL query that will be graph.</summary>
        string Query { get; set; }
        /// <summary>Enum indicating a type of graph query.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? ResultKind { get; set; }
        /// <summary>
        /// Date and time in UTC of the last modification that was made to this graph query definition.
        /// </summary>
        global::System.DateTime? TimeModified { get; set; }

    }
}