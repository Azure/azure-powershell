namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.Extensions;

    /// <summary>Graph Query entity definition.</summary>
    public partial class GraphQueryResource :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResource,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.Resource();

        /// <summary>The description of a graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).Description = value; }

        /// <summary>Azure resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Id; }

        /// <summary>The location of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryProperties Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.GraphQueryProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResultKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResourceInternal.ResultKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).ResultKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).ResultKind = value; }

        /// <summary>Internal Acessors for TimeModified</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryResourceInternal.TimeModified { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).TimeModified; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).TimeModified = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Type = value; }

        /// <summary>
        /// Azure resource name. This is GUID value. The display name should be assigned within properties field.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryProperties _property;

        /// <summary>Metadata describing a graph query for an Azure resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.GraphQueryProperties()); set => this._property = value; }

        /// <summary>KQL query that will be graph.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public string Query { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).Query = value; }

        /// <summary>Enum indicating a type of graph query.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Support.ResultKind? ResultKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).ResultKind; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Tag = value; }

        /// <summary>
        /// Date and time in UTC of the last modification that was made to this graph query definition.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimeModified { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryPropertiesInternal)Property).TimeModified; }

        /// <summary>Azure resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="GraphQueryResource" /> instance.</summary>
        public GraphQueryResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Graph Query entity definition.
    public partial interface IGraphQueryResource :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResource
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
    /// Graph Query entity definition.
    internal partial interface IGraphQueryResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IResourceInternal
    {
        /// <summary>The description of a graph query.</summary>
        string Description { get; set; }
        /// <summary>Metadata describing a graph query for an Azure resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceGraph.Models.Api20180901Preview.IGraphQueryProperties Property { get; set; }
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