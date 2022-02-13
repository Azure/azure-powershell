namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an Azure SQL database data source.</summary>
    public partial class AzureSqlDatabaseDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? _authenticationMode;

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => this._authenticationMode; set => this._authenticationMode = value; }

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private string _database;

        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Database { get => this._database; set => this._database = value; }

        /// <summary>Backing field for <see cref="MaxBatchCount" /> property.</summary>
        private float? _maxBatchCount;

        /// <summary>
        /// Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public float? MaxBatchCount { get => this._maxBatchCount; set => this._maxBatchCount = value; }

        /// <summary>Backing field for <see cref="MaxWriterCount" /> property.</summary>
        private float? _maxWriterCount;

        /// <summary>
        /// Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public float? MaxWriterCount { get => this._maxWriterCount; set => this._maxWriterCount = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="Server" /> property.</summary>
        private string _server;

        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Server { get => this._server; set => this._server = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Table { get => this._table; set => this._table = value; }

        /// <summary>Backing field for <see cref="User" /> property.</summary>
        private string _user;

        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string User { get => this._user; set => this._user = value; }

        /// <summary>Creates an new <see cref="AzureSqlDatabaseDataSourceProperties" /> instance.</summary>
        public AzureSqlDatabaseDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with an Azure SQL database data source.
    public partial interface IAzureSqlDatabaseDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication Mode.",
        SerializedName = @"authenticationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"database",
        PossibleTypes = new [] { typeof(string) })]
        string Database { get; set; }
        /// <summary>
        /// Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.",
        SerializedName = @"maxBatchCount",
        PossibleTypes = new [] { typeof(float) })]
        float? MaxBatchCount { get; set; }
        /// <summary>
        /// Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.",
        SerializedName = @"maxWriterCount",
        PossibleTypes = new [] { typeof(float) })]
        float? MaxWriterCount { get; set; }
        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"server",
        PossibleTypes = new [] { typeof(string) })]
        string Server { get; set; }
        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get; set; }
        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"user",
        PossibleTypes = new [] { typeof(string) })]
        string User { get; set; }

    }
    /// The properties that are associated with an Azure SQL database data source.
    internal partial interface IAzureSqlDatabaseDataSourcePropertiesInternal

    {
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        string Database { get; set; }
        /// <summary>
        /// Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.
        /// </summary>
        float? MaxBatchCount { get; set; }
        /// <summary>
        /// Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.
        /// </summary>
        float? MaxWriterCount { get; set; }
        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Server { get; set; }
        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Table { get; set; }
        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string User { get; set; }

    }
}