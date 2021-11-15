namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>
    /// Result of query. It contains all columns listed under groupings and aggregation.
    /// </summary>
    public partial class QueryResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Resource();

        /// <summary>Array of columns</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.FormatTable(Index = 0)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[] Column { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).Column; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).Column = value ?? null /* arrayOf */; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal.Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Tag = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Name; }

        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        public string NextLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).NextLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).NextLink = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryProperties()); set => this._property = value; }

        /// <summary>Array of rows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.FormatTable(Index = 1)]
        public string[][] Row { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).Row; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryPropertiesInternal)Property).Row = value ?? null /* arrayOf */; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Tag; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="QueryResult" /> instance.</summary>
        public QueryResult()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Result of query. It contains all columns listed under groupings and aggregation.
    public partial interface IQueryResult :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResource
    {
        /// <summary>Array of columns</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of columns",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[] Column { get; set; }
        /// <summary>The link (url) to the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link (url) to the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Array of rows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of rows",
        SerializedName = @"rows",
        PossibleTypes = new [] { typeof(string) })]
        string[][] Row { get; set; }

    }
    /// Result of query. It contains all columns listed under groupings and aggregation.
    public partial interface IQueryResultInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal
    {
        /// <summary>Array of columns</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[] Column { get; set; }
        /// <summary>The link (url) to the next page of results.</summary>
        string NextLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties Property { get; set; }
        /// <summary>Array of rows</summary>
        string[][] Row { get; set; }

    }
}