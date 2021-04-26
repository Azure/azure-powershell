namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    public partial class AzureSqlReferenceInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlReferenceInputDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Database" /> property.</summary>
        private string _database;

        /// <summary>
        /// This element is associated with the datasource element. This is the name of the database that output will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Database { get => this._database; set => this._database = value; }

        /// <summary>Backing field for <see cref="DeltaSnapshotQuery" /> property.</summary>
        private string _deltaSnapshotQuery;

        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch incremental changes from the SQL database.
        /// To use this option, we recommend using temporal tables in Azure SQL Database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DeltaSnapshotQuery { get => this._deltaSnapshotQuery; set => this._deltaSnapshotQuery = value; }

        /// <summary>Backing field for <see cref="FullSnapshotQuery" /> property.</summary>
        private string _fullSnapshotQuery;

        /// <summary>
        /// This element is associated with the datasource element. This query is used to fetch data from the sql database.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string FullSnapshotQuery { get => this._fullSnapshotQuery; set => this._fullSnapshotQuery = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>
        /// This element is associated with the datasource element. This is the password that will be used to connect to the SQL Database
        /// instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="RefreshRate" /> property.</summary>
        private string _refreshRate;

        /// <summary>
        /// This element is associated with the datasource element. This indicates how frequently the data will be fetched from the
        /// database. It is of DateTime format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string RefreshRate { get => this._refreshRate; set => this._refreshRate = value; }

        /// <summary>Backing field for <see cref="RefreshType" /> property.</summary>
        private string _refreshType;

        /// <summary>
        /// This element is associated with the datasource element. This element is of enum type. It indicates what kind of data refresh
        /// option do we want to use:Static/RefreshPeriodicallyWithFull/RefreshPeriodicallyWithDelta
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string RefreshType { get => this._refreshType; set => this._refreshType = value; }

        /// <summary>Backing field for <see cref="Server" /> property.</summary>
        private string _server;

        /// <summary>
        /// This element is associated with the datasource element. This is the name of the server that contains the database that
        /// will be written to.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Server { get => this._server; set => this._server = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>
        /// This element is associated with the datasource element. The name of the table in the Azure SQL database..
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Table { get => this._table; set => this._table = value; }

        /// <summary>Backing field for <see cref="User" /> property.</summary>
        private string _user;

        /// <summary>
        /// This element is associated with the datasource element. This is the user name that will be used to connect to the SQL
        /// Database instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string User { get => this._user; set => this._user = value; }

        /// <summary>
        /// Creates an new <see cref="AzureSqlReferenceInputDataSourceProperties" /> instance.
        /// </summary>
        public AzureSqlReferenceInputDataSourceProperties()
        {

        }
    }
    public partial interface IAzureSqlReferenceInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
    internal partial interface IAzureSqlReferenceInputDataSourcePropertiesInternal

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