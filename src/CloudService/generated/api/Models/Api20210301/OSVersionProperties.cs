namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>OS version properties.</summary>
    public partial class OSVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private string _family;

        /// <summary>The family of this OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Family { get => this._family; }

        /// <summary>Backing field for <see cref="FamilyLabel" /> property.</summary>
        private string _familyLabel;

        /// <summary>The family label of this OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string FamilyLabel { get => this._familyLabel; }

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

        /// <summary>Internal Acessors for Family</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.Family { get => this._family; set { {_family = value;} } }

        /// <summary>Internal Acessors for FamilyLabel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.FamilyLabel { get => this._familyLabel; set { {_familyLabel = value;} } }

        /// <summary>Internal Acessors for IsActive</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.IsActive { get => this._isActive; set { {_isActive = value;} } }

        /// <summary>Internal Acessors for IsDefault</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.IsDefault { get => this._isDefault; set { {_isDefault = value;} } }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.Label { get => this._label; set { {_label = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="OSVersionProperties" /> instance.</summary>
        public OSVersionProperties()
        {

        }
    }
    /// OS version properties.
    public partial interface IOSVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The family of this OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The family of this OS version.",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string Family { get;  }
        /// <summary>The family label of this OS version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The family label of this OS version.",
        SerializedName = @"familyLabel",
        PossibleTypes = new [] { typeof(string) })]
        string FamilyLabel { get;  }
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
    /// OS version properties.
    internal partial interface IOSVersionPropertiesInternal

    {
        /// <summary>The family of this OS version.</summary>
        string Family { get; set; }
        /// <summary>The family label of this OS version.</summary>
        string FamilyLabel { get; set; }
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