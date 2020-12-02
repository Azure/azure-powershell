namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The Mobility Service update details.</summary>
    public partial class MobilityServiceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMobilityServiceUpdateInternal
    {

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="RebootStatus" /> property.</summary>
        private string _rebootStatus;

        /// <summary>The reboot status of the update - whether it is required or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RebootStatus { get => this._rebootStatus; set => this._rebootStatus = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The version of the latest update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="MobilityServiceUpdate" /> instance.</summary>
        public MobilityServiceUpdate()
        {

        }
    }
    /// The Mobility Service update details.
    public partial interface IMobilityServiceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The OS type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS type.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>The reboot status of the update - whether it is required or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reboot status of the update - whether it is required or not.",
        SerializedName = @"rebootStatus",
        PossibleTypes = new [] { typeof(string) })]
        string RebootStatus { get; set; }
        /// <summary>The version of the latest update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the latest update.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// The Mobility Service update details.
    internal partial interface IMobilityServiceUpdateInternal

    {
        /// <summary>The OS type.</summary>
        string OSType { get; set; }
        /// <summary>The reboot status of the update - whether it is required or not.</summary>
        string RebootStatus { get; set; }
        /// <summary>The version of the latest update.</summary>
        string Version { get; set; }

    }
}