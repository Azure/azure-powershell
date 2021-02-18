namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Set of data with rendering instructions</summary>
    public partial class DiagnosticData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal
    {

        /// <summary>Internal Acessors for RenderingProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal.RenderingProperty { get => (this._renderingProperty = this._renderingProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Rendering()); set { {_renderingProperty = value;} } }

        /// <summary>Internal Acessors for Table</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal.Table { get => (this._table = this._table ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject()); set { {_table = value;} } }

        /// <summary>Backing field for <see cref="RenderingProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering _renderingProperty;

        /// <summary>Properties that describe how the table should be rendered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering RenderingProperty { get => (this._renderingProperty = this._renderingProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Rendering()); set => this._renderingProperty = value; }

        /// <summary>Description of the data that will help it be interpreted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RenderingPropertyDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Description = value; }

        /// <summary>Title of data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RenderingPropertyTitle { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Title; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Title = value; }

        /// <summary>Rendering Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? RenderingPropertyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRenderingInternal)RenderingProperty).Type = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject _table;

        /// <summary>Data in table form</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject Table { get => (this._table = this._table ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject()); set => this._table = value; }

        /// <summary>List of columns with data types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] TableColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).Column; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).Column = value; }

        /// <summary>Name of the table</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).TableName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).TableName = value; }

        /// <summary>Raw row values</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[][] TableRow { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).Row; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)Table).Row = value; }

        /// <summary>Creates an new <see cref="DiagnosticData" /> instance.</summary>
        public DiagnosticData()
        {

        }
    }
    /// Set of data with rendering instructions
    public partial interface IDiagnosticData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the data that will help it be interpreted</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the data that will help it be interpreted",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string RenderingPropertyDescription { get; set; }
        /// <summary>Title of data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Title of data",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string RenderingPropertyTitle { get; set; }
        /// <summary>Rendering Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Rendering Type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? RenderingPropertyType { get; set; }
        /// <summary>List of columns with data types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of columns with data types",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] TableColumn { get; set; }
        /// <summary>Name of the table</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the table",
        SerializedName = @"tableName",
        PossibleTypes = new [] { typeof(string) })]
        string TableName { get; set; }
        /// <summary>Raw row values</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Raw row values",
        SerializedName = @"rows",
        PossibleTypes = new [] { typeof(string) })]
        string[][] TableRow { get; set; }

    }
    /// Set of data with rendering instructions
    internal partial interface IDiagnosticDataInternal

    {
        /// <summary>Properties that describe how the table should be rendered</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering RenderingProperty { get; set; }
        /// <summary>Description of the data that will help it be interpreted</summary>
        string RenderingPropertyDescription { get; set; }
        /// <summary>Title of data</summary>
        string RenderingPropertyTitle { get; set; }
        /// <summary>Rendering Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType? RenderingPropertyType { get; set; }
        /// <summary>Data in table form</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject Table { get; set; }
        /// <summary>List of columns with data types</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] TableColumn { get; set; }
        /// <summary>Name of the table</summary>
        string TableName { get; set; }
        /// <summary>Raw row values</summary>
        string[][] TableRow { get; set; }

    }
}