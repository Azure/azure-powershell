namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an Azure SQL database reference input data source.</summary>
    public partial class AzureSqlReferenceInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource __referenceInputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ReferenceInputDataSource();

        /// <summary>
        /// This element is associated with the datasource element. This is the name of the database that output will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Database = value ?? null; }

        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch incremental changes from the SQL database.
        /// To use this option, we recommend using temporal tables in Azure SQL Database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DeltaSnapshotQuery { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).DeltaSnapshotQuery; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).DeltaSnapshotQuery = value ?? null; }

        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch data from the sql database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string FullSnapshotQuery { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).FullSnapshotQuery; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).FullSnapshotQuery = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSqlReferenceInputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>
        /// This element is associated with the datasource element. This is the password that will be used to connect to the SQL Database
        /// instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Password = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSqlReferenceInputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// This element is associated with the datasource element. This indicates how frequently the data will be fetched from the
        /// database. It is of DateTime format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string RefreshRate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).RefreshRate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).RefreshRate = value ?? null; }

        /// <summary>
        /// This element is associated with the datasource element. This element is of enum type. It indicates what kind of data refresh
        /// option do we want to use:Static/RefreshPeriodicallyWithFull/RefreshPeriodicallyWithDelta
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string RefreshType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).RefreshType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).RefreshType = value ?? null; }

        /// <summary>
        /// This element is associated with the datasource element. This is the name of the server that contains the database that
        /// will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Server { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Server; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Server = value ?? null; }

        /// <summary>
        /// This element is associated with the datasource element. The name of the table in the Azure SQL database..
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Table { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).Table = value ?? null; }

        /// <summary>
        /// Indicates the type of input data source containing reference data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal)__referenceInputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal)__referenceInputDataSource).Type = value ; }

        /// <summary>
        /// This element is associated with the datasource element. This is the user name that will be used to connect to the SQL
        /// Database instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string User { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).User; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal)Property).User = value ?? null; }

        /// <summary>Creates an new <see cref="AzureSqlReferenceInputDataSource" /> instance.</summary>
        public AzureSqlReferenceInputDataSource()
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
            await eventListener.AssertNotNull(nameof(__referenceInputDataSource), __referenceInputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__referenceInputDataSource), __referenceInputDataSource);
        }
    }
    /// Describes an Azure SQL database reference input data source.
    public partial interface IAzureSqlReferenceInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource
    {
        /// <summary>
        /// This element is associated with the datasource element. This is the name of the database that output will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This is the name of the database that output will be written to.",
        SerializedName = @"database",
        PossibleTypes = new [] { typeof(string) })]
        string Database { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch incremental changes from the SQL database.
        /// To use this option, we recommend using temporal tables in Azure SQL Database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This query is used to fetch incremental changes from the SQL database. To use this option, we recommend using temporal tables in Azure SQL Database.",
        SerializedName = @"deltaSnapshotQuery",
        PossibleTypes = new [] { typeof(string) })]
        string DeltaSnapshotQuery { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch data from the sql database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This query is used to fetch data from the sql database.",
        SerializedName = @"fullSnapshotQuery",
        PossibleTypes = new [] { typeof(string) })]
        string FullSnapshotQuery { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the password that will be used to connect to the SQL Database
        /// instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This is the password that will be used to connect to the SQL Database instance.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This indicates how frequently the data will be fetched from the
        /// database. It is of DateTime format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This indicates how frequently the data will be fetched from the database. It is of DateTime format.",
        SerializedName = @"refreshRate",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshRate { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This element is of enum type. It indicates what kind of data refresh
        /// option do we want to use:Static/RefreshPeriodicallyWithFull/RefreshPeriodicallyWithDelta
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This element is of enum type. It indicates what kind of data refresh option do we want to use:Static/RefreshPeriodicallyWithFull/RefreshPeriodicallyWithDelta",
        SerializedName = @"refreshType",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshType { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the name of the server that contains the database that
        /// will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This is the name of the server that contains the database that will be written to.",
        SerializedName = @"server",
        PossibleTypes = new [] { typeof(string) })]
        string Server { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. The name of the table in the Azure SQL database..
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. The name of the table in the Azure SQL database..",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the user name that will be used to connect to the SQL
        /// Database instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This element is associated with the datasource element. This is the user name that will be used to connect to the SQL Database instance.",
        SerializedName = @"user",
        PossibleTypes = new [] { typeof(string) })]
        string User { get; set; }

    }
    /// Describes an Azure SQL database reference input data source.
    internal partial interface IAzureSqlReferenceInputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal
    {
        /// <summary>
        /// This element is associated with the datasource element. This is the name of the database that output will be written to.
        /// </summary>
        string Database { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch incremental changes from the SQL database.
        /// To use this option, we recommend using temporal tables in Azure SQL Database.
        /// </summary>
        string DeltaSnapshotQuery { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch data from the sql database.
        /// </summary>
        string FullSnapshotQuery { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the password that will be used to connect to the SQL Database
        /// instance.
        /// </summary>
        string Password { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceProperties Property { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This indicates how frequently the data will be fetched from the
        /// database. It is of DateTime format.
        /// </summary>
        string RefreshRate { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This element is of enum type. It indicates what kind of data refresh
        /// option do we want to use:Static/RefreshPeriodicallyWithFull/RefreshPeriodicallyWithDelta
        /// </summary>
        string RefreshType { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the name of the server that contains the database that
        /// will be written to.
        /// </summary>
        string Server { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. The name of the table in the Azure SQL database..
        /// </summary>
        string Table { get; set; }
        /// <summary>
        /// This element is associated with the datasource element. This is the user name that will be used to connect to the SQL
        /// Database instance.
        /// </summary>
        string User { get; set; }

    }
}