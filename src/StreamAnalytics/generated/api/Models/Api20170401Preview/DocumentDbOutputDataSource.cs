namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes a DocumentDB output data source.</summary>
    public partial class DocumentDbOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>The DocumentDB account name or ID. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string AccountId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).AccountId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).AccountId = value ?? null; }

        /// <summary>
        /// The account key for the DocumentDB account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string AccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).AccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).AccountKey = value ?? null; }

        /// <summary>
        /// The collection name pattern for the collections to be used. The collection name format can be constructed using the optional
        /// {partition} token, where partitions start from 0. See the DocumentDB section of https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output
        /// for more information. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string CollectionNamePattern { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).CollectionNamePattern; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).CollectionNamePattern = value ?? null; }

        /// <summary>
        /// The name of the DocumentDB database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).Database = value ?? null; }

        /// <summary>
        /// The name of the field in output events used to specify the primary key which insert or update operations are based on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DocumentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).DocumentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).DocumentId = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.DocumentDbOutputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>
        /// The name of the field in output events used to specify the key for partitioning output across collections. If 'collectionNamePattern'
        /// contains the {partition} token, this property is required to be specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string PartitionKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).PartitionKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal)Property).PartitionKey = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with a DocumentDB output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.DocumentDbOutputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="DocumentDbOutputDataSource" /> instance.</summary>
        public DocumentDbOutputDataSource()
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
    /// Describes a DocumentDB output data source.
    public partial interface IDocumentDbOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
    {
        /// <summary>The DocumentDB account name or ID. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DocumentDB account name or ID. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountId",
        PossibleTypes = new [] { typeof(string) })]
        string AccountId { get; set; }
        /// <summary>
        /// The account key for the DocumentDB account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the DocumentDB account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string AccountKey { get; set; }
        /// <summary>
        /// The collection name pattern for the collections to be used. The collection name format can be constructed using the optional
        /// {partition} token, where partitions start from 0. See the DocumentDB section of https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output
        /// for more information. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection name pattern for the collections to be used. The collection name format can be constructed using the optional {partition} token, where partitions start from 0. See the DocumentDB section of https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for more information. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"collectionNamePattern",
        PossibleTypes = new [] { typeof(string) })]
        string CollectionNamePattern { get; set; }
        /// <summary>
        /// The name of the DocumentDB database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the DocumentDB database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"database",
        PossibleTypes = new [] { typeof(string) })]
        string Database { get; set; }
        /// <summary>
        /// The name of the field in output events used to specify the primary key which insert or update operations are based on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the field in output events used to specify the primary key which insert or update operations are based on.",
        SerializedName = @"documentId",
        PossibleTypes = new [] { typeof(string) })]
        string DocumentId { get; set; }
        /// <summary>
        /// The name of the field in output events used to specify the key for partitioning output across collections. If 'collectionNamePattern'
        /// contains the {partition} token, this property is required to be specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the field in output events used to specify the key for partitioning output across collections. If 'collectionNamePattern' contains the {partition} token, this property is required to be specified.",
        SerializedName = @"partitionKey",
        PossibleTypes = new [] { typeof(string) })]
        string PartitionKey { get; set; }

    }
    /// Describes a DocumentDB output data source.
    internal partial interface IDocumentDbOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
    {
        /// <summary>The DocumentDB account name or ID. Required on PUT (CreateOrReplace) requests.</summary>
        string AccountId { get; set; }
        /// <summary>
        /// The account key for the DocumentDB account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string AccountKey { get; set; }
        /// <summary>
        /// The collection name pattern for the collections to be used. The collection name format can be constructed using the optional
        /// {partition} token, where partitions start from 0. See the DocumentDB section of https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output
        /// for more information. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string CollectionNamePattern { get; set; }
        /// <summary>
        /// The name of the DocumentDB database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Database { get; set; }
        /// <summary>
        /// The name of the field in output events used to specify the primary key which insert or update operations are based on.
        /// </summary>
        string DocumentId { get; set; }
        /// <summary>
        /// The name of the field in output events used to specify the key for partitioning output across collections. If 'collectionNamePattern'
        /// contains the {partition} token, this property is required to be specified.
        /// </summary>
        string PartitionKey { get; set; }
        /// <summary>
        /// The properties that are associated with a DocumentDB output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceProperties Property { get; set; }

    }
}