namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an Azure Table output.</summary>
    public partial class AzureTableOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccountKey" /> property.</summary>
        private string _accountKey;

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string AccountKey { get => this._accountKey; set => this._accountKey = value; }

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Backing field for <see cref="BatchSize" /> property.</summary>
        private int? _batchSize;

        /// <summary>The number of rows to write to the Azure Table at a time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? BatchSize { get => this._batchSize; set => this._batchSize = value; }

        /// <summary>Backing field for <see cref="ColumnsToRemove" /> property.</summary>
        private string[] _columnsToRemove;

        /// <summary>
        /// If specified, each item in the array is the name of a column to remove (if present) from output event entities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string[] ColumnsToRemove { get => this._columnsToRemove; set => this._columnsToRemove = value; }

        /// <summary>Backing field for <see cref="PartitionKey" /> property.</summary>
        private string _partitionKey;

        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the partition
        /// key for the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string PartitionKey { get => this._partitionKey; set => this._partitionKey = value; }

        /// <summary>Backing field for <see cref="RowKey" /> property.</summary>
        private string _rowKey;

        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for
        /// the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string RowKey { get => this._rowKey; set => this._rowKey = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>The name of the Azure Table. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Table { get => this._table; set => this._table = value; }

        /// <summary>Creates an new <see cref="AzureTableOutputDataSourceProperties" /> instance.</summary>
        public AzureTableOutputDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with an Azure Table output.
    public partial interface IAzureTableOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string AccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }
        /// <summary>The number of rows to write to the Azure Table at a time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of rows to write to the Azure Table at a time.",
        SerializedName = @"batchSize",
        PossibleTypes = new [] { typeof(int) })]
        int? BatchSize { get; set; }
        /// <summary>
        /// If specified, each item in the array is the name of a column to remove (if present) from output event entities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If specified, each item in the array is the name of a column to remove (if present) from output event entities.",
        SerializedName = @"columnsToRemove",
        PossibleTypes = new [] { typeof(string) })]
        string[] ColumnsToRemove { get; set; }
        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the partition
        /// key for the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element indicates the name of a column from the SELECT statement in the query that will be used as the partition key for the Azure Table. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"partitionKey",
        PossibleTypes = new [] { typeof(string) })]
        string PartitionKey { get; set; }
        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for
        /// the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for the Azure Table. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"rowKey",
        PossibleTypes = new [] { typeof(string) })]
        string RowKey { get; set; }
        /// <summary>The name of the Azure Table. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Table. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get; set; }

    }
    /// The properties that are associated with an Azure Table output.
    internal partial interface IAzureTableOutputDataSourcePropertiesInternal

    {
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string AccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string AccountName { get; set; }
        /// <summary>The number of rows to write to the Azure Table at a time.</summary>
        int? BatchSize { get; set; }
        /// <summary>
        /// If specified, each item in the array is the name of a column to remove (if present) from output event entities.
        /// </summary>
        string[] ColumnsToRemove { get; set; }
        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the partition
        /// key for the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string PartitionKey { get; set; }
        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for
        /// the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string RowKey { get; set; }
        /// <summary>The name of the Azure Table. Required on PUT (CreateOrReplace) requests.</summary>
        string Table { get; set; }

    }
}