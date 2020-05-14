namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Column definition</summary>
    public partial class DataTableResponseColumn :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumnInternal
    {

        /// <summary>Backing field for <see cref="ColumnName" /> property.</summary>
        private string _columnName;

        /// <summary>Name of the column</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ColumnName { get => this._columnName; set => this._columnName = value; }

        /// <summary>Backing field for <see cref="ColumnType" /> property.</summary>
        private string _columnType;

        /// <summary>Column Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ColumnType { get => this._columnType; set => this._columnType = value; }

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>Data type which looks like 'String' or 'Int32'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Creates an new <see cref="DataTableResponseColumn" /> instance.</summary>
        public DataTableResponseColumn()
        {

        }
    }
    /// Column definition
    public partial interface IDataTableResponseColumn :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of the column</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the column",
        SerializedName = @"columnName",
        PossibleTypes = new [] { typeof(string) })]
        string ColumnName { get; set; }
        /// <summary>Column Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Column Type",
        SerializedName = @"columnType",
        PossibleTypes = new [] { typeof(string) })]
        string ColumnType { get; set; }
        /// <summary>Data type which looks like 'String' or 'Int32'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Data type which looks like 'String' or 'Int32'.",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get; set; }

    }
    /// Column definition
    internal partial interface IDataTableResponseColumnInternal

    {
        /// <summary>Name of the column</summary>
        string ColumnName { get; set; }
        /// <summary>Column Type</summary>
        string ColumnType { get; set; }
        /// <summary>Data type which looks like 'String' or 'Int32'.</summary>
        string DataType { get; set; }

    }
}