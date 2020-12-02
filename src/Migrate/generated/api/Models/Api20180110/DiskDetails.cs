namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>On-prem disk details data.</summary>
    public partial class DiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="MaxSizeMb" /> property.</summary>
        private long? _maxSizeMb;

        /// <summary>The hard disk max size in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? MaxSizeMb { get => this._maxSizeMb; set => this._maxSizeMb = value; }

        /// <summary>Backing field for <see cref="VhdId" /> property.</summary>
        private string _vhdId;

        /// <summary>The VHD Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdId { get => this._vhdId; set => this._vhdId = value; }

        /// <summary>Backing field for <see cref="VhdName" /> property.</summary>
        private string _vhdName;

        /// <summary>The VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdName { get => this._vhdName; set => this._vhdName = value; }

        /// <summary>Backing field for <see cref="VhdType" /> property.</summary>
        private string _vhdType;

        /// <summary>The type of the volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdType { get => this._vhdType; set => this._vhdType = value; }

        /// <summary>Creates an new <see cref="DiskDetails" /> instance.</summary>
        public DiskDetails()
        {

        }
    }
    /// On-prem disk details data.
    public partial interface IDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The hard disk max size in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The hard disk max size in MB.",
        SerializedName = @"maxSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxSizeMb { get; set; }
        /// <summary>The VHD Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VHD Id.",
        SerializedName = @"vhdId",
        PossibleTypes = new [] { typeof(string) })]
        string VhdId { get; set; }
        /// <summary>The VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The VHD name.",
        SerializedName = @"vhdName",
        PossibleTypes = new [] { typeof(string) })]
        string VhdName { get; set; }
        /// <summary>The type of the volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the volume.",
        SerializedName = @"vhdType",
        PossibleTypes = new [] { typeof(string) })]
        string VhdType { get; set; }

    }
    /// On-prem disk details data.
    internal partial interface IDiskDetailsInternal

    {
        /// <summary>The hard disk max size in MB.</summary>
        long? MaxSizeMb { get; set; }
        /// <summary>The VHD Id.</summary>
        string VhdId { get; set; }
        /// <summary>The VHD name.</summary>
        string VhdName { get; set; }
        /// <summary>The type of the volume.</summary>
        string VhdType { get; set; }

    }
}