namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The configuration of dataset in the query.</summary>
    public partial class QueryDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryDatasetConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private string[] _column;

        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public string[] Column { get => this._column; set => this._column = value; }

        /// <summary>Creates an new <see cref="QueryDatasetConfiguration" /> instance.</summary>
        public QueryDatasetConfiguration()
        {

        }
    }
    /// The configuration of dataset in the query.
    public partial interface IQueryDatasetConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query includes all columns.",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] Column { get; set; }

    }
    /// The configuration of dataset in the query.
    public partial interface IQueryDatasetConfigurationInternal

    {
        /// <summary>
        /// Array of column names to be included in the query. Any valid query column name is allowed. If not provided, then query
        /// includes all columns.
        /// </summary>
        string[] Column { get; set; }

    }
}