namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an Azure Table output data source.</summary>
    public partial class AzureTableOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string AccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).AccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).AccountKey = value ?? null; }

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string AccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).AccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).AccountName = value ?? null; }

        /// <summary>The number of rows to write to the Azure Table at a time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? BatchSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).BatchSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).BatchSize = value ?? default(int); }

        /// <summary>
        /// If specified, each item in the array is the name of a column to remove (if present) from output event entities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string[] ColumnsToRemove { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).ColumnsToRemove; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).ColumnsToRemove = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureTableOutputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the partition
        /// key for the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string PartitionKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).PartitionKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).PartitionKey = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with an Azure Table output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureTableOutputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for
        /// the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string RowKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).RowKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).RowKey = value ?? null; }

        /// <summary>The name of the Azure Table. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Table { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourcePropertiesInternal)Property).Table = value ?? null; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="AzureTableOutputDataSource" /> instance.</summary>
        public AzureTableOutputDataSource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__outputDataSource), __outputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__outputDataSource), __outputDataSource);
        }
    }
    /// Describes an Azure Table output data source.
    public partial interface IAzureTableOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
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
    /// Describes an Azure Table output data source.
    internal partial interface IAzureTableOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
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
        /// The properties that are associated with an Azure Table output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureTableOutputDataSourceProperties Property { get; set; }
        /// <summary>
        /// This element indicates the name of a column from the SELECT statement in the query that will be used as the row key for
        /// the Azure Table. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string RowKey { get; set; }
        /// <summary>The name of the Azure Table. Required on PUT (CreateOrReplace) requests.</summary>
        string Table { get; set; }

    }
}