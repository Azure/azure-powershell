namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MigrateMySqlStatus resource specific properties</summary>
    public partial class MigrateMySqlStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LocalMySqlEnabled" /> property.</summary>
        private bool? _localMySqlEnabled;

        /// <summary>True if the web app has in app MySql enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? LocalMySqlEnabled { get => this._localMySqlEnabled; }

        /// <summary>Internal Acessors for LocalMySqlEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal.LocalMySqlEnabled { get => this._localMySqlEnabled; set { {_localMySqlEnabled = value;} } }

        /// <summary>Internal Acessors for MigrationOperationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal.MigrationOperationStatus { get => this._migrationOperationStatus; set { {_migrationOperationStatus = value;} } }

        /// <summary>Internal Acessors for OperationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMigrateMySqlStatusPropertiesInternal.OperationId { get => this._operationId; set { {_operationId = value;} } }

        /// <summary>Backing field for <see cref="MigrationOperationStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? _migrationOperationStatus;

        /// <summary>Status of the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get => this._migrationOperationStatus; }

        /// <summary>Backing field for <see cref="OperationId" /> property.</summary>
        private string _operationId;

        /// <summary>Operation ID for the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OperationId { get => this._operationId; }

        /// <summary>Creates an new <see cref="MigrateMySqlStatusProperties" /> instance.</summary>
        public MigrateMySqlStatusProperties()
        {

        }
    }
    /// MigrateMySqlStatus resource specific properties
    public partial interface IMigrateMySqlStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>True if the web app has in app MySql enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"True if the web app has in app MySql enabled",
        SerializedName = @"localMySqlEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LocalMySqlEnabled { get;  }
        /// <summary>Status of the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the migration task.",
        SerializedName = @"migrationOperationStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get;  }
        /// <summary>Operation ID for the migration task.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation ID for the migration task.",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string OperationId { get;  }

    }
    /// MigrateMySqlStatus resource specific properties
    internal partial interface IMigrateMySqlStatusPropertiesInternal

    {
        /// <summary>True if the web app has in app MySql enabled</summary>
        bool? LocalMySqlEnabled { get; set; }
        /// <summary>Status of the migration task.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.OperationStatus? MigrationOperationStatus { get; set; }
        /// <summary>Operation ID for the migration task.</summary>
        string OperationId { get; set; }

    }
}