namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Details of the OS Disk.</summary>
    public partial class OSDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVhdId" /> property.</summary>
        private string _oSVhdId;

        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVhdId { get => this._oSVhdId; set => this._oSVhdId = value; }

        /// <summary>Backing field for <see cref="VhdName" /> property.</summary>
        private string _vhdName;

        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdName { get => this._vhdName; set => this._vhdName = value; }

        /// <summary>Creates an new <see cref="OSDiskDetails" /> instance.</summary>
        public OSDiskDetails()
        {

        }
    }
    /// Details of the OS Disk.
    public partial interface IOSDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The type of the OS on the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the OS on the VM.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the disk containing the OS.",
        SerializedName = @"osVhdId",
        PossibleTypes = new [] { typeof(string) })]
        string OSVhdId { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS disk VHD name.",
        SerializedName = @"vhdName",
        PossibleTypes = new [] { typeof(string) })]
        string VhdName { get; set; }

    }
    /// Details of the OS Disk.
    internal partial interface IOSDiskDetailsInternal

    {
        /// <summary>The type of the OS on the VM.</summary>
        string OSType { get; set; }
        /// <summary>The id of the disk containing the OS.</summary>
        string OSVhdId { get; set; }
        /// <summary>The OS disk VHD name.</summary>
        string VhdName { get; set; }

    }
}