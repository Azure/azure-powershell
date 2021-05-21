namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a DocumentDB output.</summary>
    public partial class DocumentDbOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IDocumentDbOutputDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccountId" /> property.</summary>
        private string _accountId;

        /// <summary>The DocumentDB account name or ID. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string AccountId { get => this._accountId; set => this._accountId = value; }

        /// <summary>Backing field for <see cref="AccountKey" /> property.</summary>
        private string _accountKey;

        /// <summary>
        /// The account key for the DocumentDB account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string AccountKey { get => this._accountKey; set => this._accountKey = value; }

        /// <summary>Backing field for <see cref="CollectionNamePattern" /> property.</summary>
        private string _collectionNamePattern;

        /// <summary>
        /// The collection name pattern for the collections to be used. The collection name format can be constructed using the optional
        /// {partition} token, where partitions start from 0. See the DocumentDB section of https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output
        /// for more information. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string CollectionNamePattern { get => this._collectionNamePattern; set => this._collectionNamePattern = value; }

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private string _database;

        /// <summary>
        /// The name of the DocumentDB database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Database { get => this._database; set => this._database = value; }

        /// <summary>Backing field for <see cref="DocumentId" /> property.</summary>
        private string _documentId;

        /// <summary>
        /// The name of the field in output events used to specify the primary key which insert or update operations are based on.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DocumentId { get => this._documentId; set => this._documentId = value; }

        /// <summary>Backing field for <see cref="PartitionKey" /> property.</summary>
        private string _partitionKey;

        /// <summary>
        /// The name of the field in output events used to specify the key for partitioning output across collections. If 'collectionNamePattern'
        /// contains the {partition} token, this property is required to be specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string PartitionKey { get => this._partitionKey; set => this._partitionKey = value; }

        /// <summary>Creates an new <see cref="DocumentDbOutputDataSourceProperties" /> instance.</summary>
        public DocumentDbOutputDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with a DocumentDB output.
    public partial interface IDocumentDbOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
    /// The properties that are associated with a DocumentDB output.
    internal partial interface IDocumentDbOutputDataSourcePropertiesInternal

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

    }
}