namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Service level objectives for performance tier.</summary>
    public partial class PerformanceTierServiceLevelObjectives :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierServiceLevelObjectives,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierServiceLevelObjectivesInternal
    {

        /// <summary>Backing field for <see cref="Edition" /> property.</summary>
        private string _edition;

        /// <summary>Edition of the performance tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Edition { get => this._edition; set => this._edition = value; }

        /// <summary>Backing field for <see cref="HardwareGeneration" /> property.</summary>
        private string _hardwareGeneration;

        /// <summary>Hardware generation associated with the service level objective</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string HardwareGeneration { get => this._hardwareGeneration; set => this._hardwareGeneration = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ID for the service level objective.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="MaxBackupRetentionDay" /> property.</summary>
        private int? _maxBackupRetentionDay;

        /// <summary>Maximum Backup retention in days for the performance tier edition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? MaxBackupRetentionDay { get => this._maxBackupRetentionDay; set => this._maxBackupRetentionDay = value; }

        /// <summary>Backing field for <see cref="MaxStorageMb" /> property.</summary>
        private int? _maxStorageMb;

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? MaxStorageMb { get => this._maxStorageMb; set => this._maxStorageMb = value; }

        /// <summary>Backing field for <see cref="MinBackupRetentionDay" /> property.</summary>
        private int? _minBackupRetentionDay;

        /// <summary>Minimum Backup retention in days for the performance tier edition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? MinBackupRetentionDay { get => this._minBackupRetentionDay; set => this._minBackupRetentionDay = value; }

        /// <summary>Backing field for <see cref="MinStorageMb" /> property.</summary>
        private int? _minStorageMb;

        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? MinStorageMb { get => this._minStorageMb; set => this._minStorageMb = value; }

        /// <summary>Backing field for <see cref="VCore" /> property.</summary>
        private int? _vCore;

        /// <summary>vCore associated with the service level objective</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public int? VCore { get => this._vCore; set => this._vCore = value; }

        /// <summary>Creates an new <see cref="PerformanceTierServiceLevelObjectives" /> instance.</summary>
        public PerformanceTierServiceLevelObjectives()
        {

        }
    }
    /// Service level objectives for performance tier.
    public partial interface IPerformanceTierServiceLevelObjectives :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>Edition of the performance tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Edition of the performance tier.",
        SerializedName = @"edition",
        PossibleTypes = new [] { typeof(string) })]
        string Edition { get; set; }
        /// <summary>Hardware generation associated with the service level objective</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hardware generation associated with the service level objective",
        SerializedName = @"hardwareGeneration",
        PossibleTypes = new [] { typeof(string) })]
        string HardwareGeneration { get; set; }
        /// <summary>ID for the service level objective.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ID for the service level objective.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Maximum Backup retention in days for the performance tier edition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum Backup retention in days for the performance tier edition",
        SerializedName = @"maxBackupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxBackupRetentionDay { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"maxStorageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxStorageMb { get; set; }
        /// <summary>Minimum Backup retention in days for the performance tier edition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum Backup retention in days for the performance tier edition",
        SerializedName = @"minBackupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? MinBackupRetentionDay { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Max storage allowed for a server.",
        SerializedName = @"minStorageMB",
        PossibleTypes = new [] { typeof(int) })]
        int? MinStorageMb { get; set; }
        /// <summary>vCore associated with the service level objective</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"vCore associated with the service level objective",
        SerializedName = @"vCore",
        PossibleTypes = new [] { typeof(int) })]
        int? VCore { get; set; }

    }
    /// Service level objectives for performance tier.
    internal partial interface IPerformanceTierServiceLevelObjectivesInternal

    {
        /// <summary>Edition of the performance tier.</summary>
        string Edition { get; set; }
        /// <summary>Hardware generation associated with the service level objective</summary>
        string HardwareGeneration { get; set; }
        /// <summary>ID for the service level objective.</summary>
        string Id { get; set; }
        /// <summary>Maximum Backup retention in days for the performance tier edition</summary>
        int? MaxBackupRetentionDay { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? MaxStorageMb { get; set; }
        /// <summary>Minimum Backup retention in days for the performance tier edition</summary>
        int? MinBackupRetentionDay { get; set; }
        /// <summary>Max storage allowed for a server.</summary>
        int? MinStorageMb { get; set; }
        /// <summary>vCore associated with the service level objective</summary>
        int? VCore { get; set; }

    }
}