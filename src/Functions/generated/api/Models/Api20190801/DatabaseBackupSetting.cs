namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Database backup settings.</summary>
    public partial class DatabaseBackupSetting :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSetting,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDatabaseBackupSettingInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private string _connectionString;

        /// <summary>
        /// Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new
        /// database, the database name inside is the new one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConnectionString { get => this._connectionString; set => this._connectionString = value; }

        /// <summary>Backing field for <see cref="ConnectionStringName" /> property.</summary>
        private string _connectionStringName;

        /// <summary>
        /// Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.
        /// This is used during restore with overwrite connection strings options.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConnectionStringName { get => this._connectionStringName; set => this._connectionStringName = value; }

        /// <summary>Backing field for <see cref="DatabaseType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DatabaseType _databaseType;

        /// <summary>Database type (e.g. SqlAzure / MySql).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DatabaseType DatabaseType { get => this._databaseType; set => this._databaseType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="DatabaseBackupSetting" /> instance.</summary>
        public DatabaseBackupSetting()
        {

        }
    }
    /// Database backup settings.
    public partial interface IDatabaseBackupSetting :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new
        /// database, the database name inside is the new one.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new database, the database name inside is the new one.",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get; set; }
        /// <summary>
        /// Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.
        /// This is used during restore with overwrite connection strings options.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.
        This is used during restore with overwrite connection strings options.",
        SerializedName = @"connectionStringName",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionStringName { get; set; }
        /// <summary>Database type (e.g. SqlAzure / MySql).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Database type (e.g. SqlAzure / MySql).",
        SerializedName = @"databaseType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DatabaseType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DatabaseType DatabaseType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Database backup settings.
    internal partial interface IDatabaseBackupSettingInternal

    {
        /// <summary>
        /// Contains a connection string to a database which is being backed up or restored. If the restore should happen to a new
        /// database, the database name inside is the new one.
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// Contains a connection string name that is linked to the SiteConfig.ConnectionStrings.
        /// This is used during restore with overwrite connection strings options.
        /// </summary>
        string ConnectionStringName { get; set; }
        /// <summary>Database type (e.g. SqlAzure / MySql).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DatabaseType DatabaseType { get; set; }

        string Name { get; set; }

    }
}