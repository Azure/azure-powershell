namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an Azure SQL database output data source.</summary>
    public partial class AzureSqlDatabaseOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Database = value ?? null; }

        /// <summary>
        /// Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public float? MaxBatchCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).MaxBatchCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).MaxBatchCount = value ?? default(float); }

        /// <summary>
        /// Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public float? MaxWriterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).MaxWriterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).MaxWriterCount = value ?? default(float); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSqlDatabaseDataSourceProperties()); set { {_property = value;} } }

        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Password = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with an Azure SQL database output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSqlDatabaseDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Server { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Server; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Server = value ?? null; }

        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Table { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).Table = value ?? null; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string User { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).User; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)Property).User = value ?? null; }

        /// <summary>Creates an new <see cref="AzureSqlDatabaseOutputDataSource" /> instance.</summary>
        public AzureSqlDatabaseOutputDataSource()
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
    /// Describes an Azure SQL database output data source.
    public partial interface IAzureSqlDatabaseOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
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
    /// Describes an Azure SQL database output data source.
    internal partial interface IAzureSqlDatabaseOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
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
        /// The properties that are associated with an Azure SQL database output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties Property { get; set; }
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