namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Disk Details.</summary>
    public partial class OSDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal
    {

        /// <summary>Backing field for <see cref="OSEdition" /> property.</summary>
        private string _oSEdition;

        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSEdition { get => this._oSEdition; set => this._oSEdition = value; }

        /// <summary>Backing field for <see cref="OSMajorVersion" /> property.</summary>
        private string _oSMajorVersion;

        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSMajorVersion { get => this._oSMajorVersion; set => this._oSMajorVersion = value; }

        /// <summary>Backing field for <see cref="OSMinorVersion" /> property.</summary>
        private string _oSMinorVersion;

        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSMinorVersion { get => this._oSMinorVersion; set => this._oSMinorVersion = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; set => this._oSVersion = value; }

        /// <summary>Backing field for <see cref="ProductType" /> property.</summary>
        private string _productType;

        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProductType { get => this._productType; set => this._productType = value; }

        /// <summary>Creates an new <see cref="OSDetails" /> instance.</summary>
        public OSDetails()
        {

        }
    }
    /// Disk Details.
    public partial interface IOSDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OSEdition.",
        SerializedName = @"osEdition",
        PossibleTypes = new [] { typeof(string) })]
        string OSEdition { get; set; }
        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Major Version.",
        SerializedName = @"oSMajorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSMajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Minor Version.",
        SerializedName = @"oSMinorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSMinorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM Disk details.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Version.",
        SerializedName = @"oSVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product type.",
        SerializedName = @"productType",
        PossibleTypes = new [] { typeof(string) })]
        string ProductType { get; set; }

    }
    /// Disk Details.
    internal partial interface IOSDetailsInternal

    {
        /// <summary>The OSEdition.</summary>
        string OSEdition { get; set; }
        /// <summary>The OS Major Version.</summary>
        string OSMajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        string OSMinorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        string OSType { get; set; }
        /// <summary>The OS Version.</summary>
        string OSVersion { get; set; }
        /// <summary>Product type.</summary>
        string ProductType { get; set; }

    }
}