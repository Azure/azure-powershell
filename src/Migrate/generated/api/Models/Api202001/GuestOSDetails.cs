namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Data related to a machine's operating system. Serialized and stored as part of Machine Rest object.
    /// </summary>
    public partial class GuestOSDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal
    {

        /// <summary>Internal Acessors for OSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal.OSName { get => this._oSName; set { {_oSName = value;} } }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal.OSVersion { get => this._oSVersion; set { {_oSVersion = value;} } }

        /// <summary>Backing field for <see cref="OSName" /> property.</summary>
        private string _oSName;

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSName { get => this._oSName; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; }

        /// <summary>Creates an new <see cref="GuestOSDetails" /> instance.</summary>
        public GuestOSDetails()
        {

        }
    }
    /// Data related to a machine's operating system. Serialized and stored as part of Machine Rest object.
    public partial interface IGuestOSDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the operating system.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string OSName { get;  }
        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the operating system.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the operating system.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get;  }

    }
    /// Data related to a machine's operating system. Serialized and stored as part of Machine Rest object.
    internal partial interface IGuestOSDetailsInternal

    {
        /// <summary>Name of the operating system.</summary>
        string OSName { get; set; }
        /// <summary>Type of the operating system.</summary>
        string OSType { get; set; }
        /// <summary>Version of the operating system.</summary>
        string OSVersion { get; set; }

    }
}