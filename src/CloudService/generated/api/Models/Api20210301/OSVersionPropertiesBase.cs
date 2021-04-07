namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Configuration view of an OS version.</summary>
    public partial class OSVersionPropertiesBase :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBaseInternal
    {

        /// <summary>Backing field for <see cref="IsActive" /> property.</summary>
        private bool? _isActive;

        /// <summary>Specifies whether this OS version is active.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public bool? IsActive { get => this._isActive; }

        /// <summary>Backing field for <see cref="IsDefault" /> property.</summary>
        private bool? _isDefault;

        /// <summary>Specifies whether this is the default OS version for its family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public bool? IsDefault { get => this._isDefault; }

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>The OS version label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Label { get => this._label; }

        /// <summary>Internal Acessors for IsActive</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBaseInternal.IsActive { get => this._isActive; set { {_isActive = value;} } }

        /// <summary>Internal Acessors for IsDefault</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBaseInternal.IsDefault { get => this._isDefault; set { {_isDefault = value;} } }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBaseInternal.Label { get => this._label; set { {_label = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBaseInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="OSVersionPropertiesBase" /> instance.</summary>
        public OSVersionPropertiesBase()
        {

        }
    }
    /// Configuration view of an OS version.
    public partial interface IOSVersionPropertiesBase :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Specifies whether this OS version is active.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies whether this OS version is active.",
        SerializedName = @"isActive",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsActive { get;  }
        /// <summary>Specifies whether this is the default OS version for its family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies whether this is the default OS version for its family.",
        SerializedName = @"isDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDefault { get;  }
        /// <summary>The OS version label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS version label.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get;  }
        /// <summary>The OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Configuration view of an OS version.
    internal partial interface IOSVersionPropertiesBaseInternal

    {
        /// <summary>Specifies whether this OS version is active.</summary>
        bool? IsActive { get; set; }
        /// <summary>Specifies whether this is the default OS version for its family.</summary>
        bool? IsDefault { get; set; }
        /// <summary>The OS version label.</summary>
        string Label { get; set; }
        /// <summary>The OS version.</summary>
        string Version { get; set; }

    }
}