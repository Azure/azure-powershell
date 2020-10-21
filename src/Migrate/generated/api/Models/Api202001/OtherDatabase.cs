namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>OtherDatabase in the guest virtual machine.</summary>
    public partial class OtherDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabaseInternal
    {

        /// <summary>Backing field for <see cref="DatabaseType" /> property.</summary>
        private string _databaseType;

        /// <summary>DatabaseType of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatabaseType { get => this._databaseType; }

        /// <summary>Backing field for <see cref="Instance" /> property.</summary>
        private string _instance;

        /// <summary>Instance of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Instance { get => this._instance; }

        /// <summary>Internal Acessors for DatabaseType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabaseInternal.DatabaseType { get => this._databaseType; set { {_databaseType = value;} } }

        /// <summary>Internal Acessors for Instance</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabaseInternal.Instance { get => this._instance; set { {_instance = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabaseInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>Version of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="OtherDatabase" /> instance.</summary>
        public OtherDatabase()
        {

        }
    }
    /// OtherDatabase in the guest virtual machine.
    public partial interface IOtherDatabase :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>DatabaseType of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"DatabaseType of the OtherDatabase.",
        SerializedName = @"databaseType",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseType { get;  }
        /// <summary>Instance of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Instance of the OtherDatabase.",
        SerializedName = @"instance",
        PossibleTypes = new [] { typeof(string) })]
        string Instance { get;  }
        /// <summary>Version of the OtherDatabase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the OtherDatabase.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// OtherDatabase in the guest virtual machine.
    internal partial interface IOtherDatabaseInternal

    {
        /// <summary>DatabaseType of the OtherDatabase.</summary>
        string DatabaseType { get; set; }
        /// <summary>Instance of the OtherDatabase.</summary>
        string Instance { get; set; }
        /// <summary>Version of the OtherDatabase.</summary>
        string Version { get; set; }

    }
}