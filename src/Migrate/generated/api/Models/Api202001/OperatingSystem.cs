namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Second level object returned as part of Machine REST resource.</summary>
    public partial class OperatingSystem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal
    {

        /// <summary>Internal Acessors for OSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal.OSName { get => this._oSName; set { {_oSName = value;} } }

        /// <summary>Internal Acessors for OSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal.OSType { get => this._oSType; set { {_oSType = value;} } }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal.OSVersion { get => this._oSVersion; set { {_oSVersion = value;} } }

        /// <summary>Backing field for <see cref="OSName" /> property.</summary>
        private string _oSName;

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSName { get => this._oSName; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; }

        /// <summary>Creates an new <see cref="OperatingSystem" /> instance.</summary>
        public OperatingSystem()
        {

        }
    }
    /// Second level object returned as part of Machine REST resource.
    public partial interface IOperatingSystem :
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
        ReadOnly = true,
        Description = @"Type of the operating system.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get;  }
        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the operating system.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get;  }

    }
    /// Second level object returned as part of Machine REST resource.
    internal partial interface IOperatingSystemInternal

    {
        /// <summary>Name of the operating system.</summary>
        string OSName { get; set; }
        /// <summary>Type of the operating system.</summary>
        string OSType { get; set; }
        /// <summary>Version of the operating system.</summary>
        string OSVersion { get; set; }

    }
}