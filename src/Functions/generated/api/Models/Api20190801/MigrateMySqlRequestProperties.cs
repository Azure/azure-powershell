namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MigrateMySqlRequest resource specific properties</summary>
    public partial class MigrateMySqlRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private string _connectionString;

        /// <summary>Connection string to the remote MySQL database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConnectionString { get => this._connectionString; set => this._connectionString = value; }

        /// <summary>Backing field for <see cref="MigrationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MySqlMigrationType _migrationType;

        /// <summary>The type of migration operation to be done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MySqlMigrationType MigrationType { get => this._migrationType; set => this._migrationType = value; }

        /// <summary>Creates an new <see cref="MigrateMySqlRequestProperties" /> instance.</summary>
        public MigrateMySqlRequestProperties()
        {

        }
    }
    /// MigrateMySqlRequest resource specific properties
    public partial interface IMigrateMySqlRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Connection string to the remote MySQL database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Connection string to the remote MySQL database.",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get; set; }
        /// <summary>The type of migration operation to be done</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The type of migration operation to be done",
        SerializedName = @"migrationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MySqlMigrationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MySqlMigrationType MigrationType { get; set; }

    }
    /// MigrateMySqlRequest resource specific properties
    internal partial interface IMigrateMySqlRequestPropertiesInternal

    {
        /// <summary>Connection string to the remote MySQL database.</summary>
        string ConnectionString { get; set; }
        /// <summary>The type of migration operation to be done</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MySqlMigrationType MigrationType { get; set; }

    }
}