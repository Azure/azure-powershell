namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Supported deployment runtime version descriptor.</summary>
    public partial class SupportedRuntimeVersion :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersion,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ISupportedRuntimeVersionInternal
    {

        /// <summary>Backing field for <see cref="Platform" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimePlatform? _platform;

        /// <summary>The platform of this runtime version (possible values: "Java" or ".NET").</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimePlatform? Platform { get => this._platform; set => this._platform = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimeValue? _value;

        /// <summary>The raw value which could be passed to deployment CRUD operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimeValue? Value { get => this._value; set => this._value = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The detailed version (major.minor) of the platform.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="SupportedRuntimeVersion" /> instance.</summary>
        public SupportedRuntimeVersion()
        {

        }
    }
    /// Supported deployment runtime version descriptor.
    public partial interface ISupportedRuntimeVersion :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The platform of this runtime version (possible values: "Java" or ".NET").</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The platform of this runtime version (possible values: ""Java"" or "".NET"").",
        SerializedName = @"platform",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimePlatform) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimePlatform? Platform { get; set; }
        /// <summary>The raw value which could be passed to deployment CRUD operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The raw value which could be passed to deployment CRUD operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimeValue) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimeValue? Value { get; set; }
        /// <summary>The detailed version (major.minor) of the platform.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The detailed version (major.minor) of the platform.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Supported deployment runtime version descriptor.
    public partial interface ISupportedRuntimeVersionInternal

    {
        /// <summary>The platform of this runtime version (possible values: "Java" or ".NET").</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimePlatform? Platform { get; set; }
        /// <summary>The raw value which could be passed to deployment CRUD operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.SupportedRuntimeValue? Value { get; set; }
        /// <summary>The detailed version (major.minor) of the platform.</summary>
        string Version { get; set; }

    }
}