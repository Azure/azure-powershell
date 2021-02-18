namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Data Table which defines columns and raw row values</summary>
    public partial class DataTableResponseObject :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] _column;

        /// <summary>List of columns with data types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] Column { get => this._column; set => this._column = value; }

        /// <summary>Backing field for <see cref="Row" /> property.</summary>
        private string[][] _row;

        /// <summary>Raw row values</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[][] Row { get => this._row; set => this._row = value; }

        /// <summary>Backing field for <see cref="TableName" /> property.</summary>
        private string _tableName;

        /// <summary>Name of the table</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TableName { get => this._tableName; set => this._tableName = value; }

        /// <summary>Creates an new <see cref="DataTableResponseObject" /> instance.</summary>
        public DataTableResponseObject()
        {

        }
    }
    /// Data Table which defines columns and raw row values
    public partial interface IDataTableResponseObject :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of columns with data types</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of columns with data types",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] Column { get; set; }
        /// <summary>Raw row values</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Raw row values",
        SerializedName = @"rows",
        PossibleTypes = new [] { typeof(string) })]
        string[][] Row { get; set; }
        /// <summary>Name of the table</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the table",
        SerializedName = @"tableName",
        PossibleTypes = new [] { typeof(string) })]
        string TableName { get; set; }

    }
    /// Data Table which defines columns and raw row values
    internal partial interface IDataTableResponseObjectInternal

    {
        /// <summary>List of columns with data types</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[] Column { get; set; }
        /// <summary>Raw row values</summary>
        string[][] Row { get; set; }
        /// <summary>Name of the table</summary>
        string TableName { get; set; }

    }
}