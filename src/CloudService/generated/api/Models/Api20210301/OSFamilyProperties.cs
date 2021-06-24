namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>OS family properties.</summary>
    public partial class OSFamilyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>The OS family label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Label { get => this._label; }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal.Label { get => this._label; set { {_label = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The OS family name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] _version;

        /// <summary>List of OS versions belonging to this family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get => this._version; }

        /// <summary>Creates an new <see cref="OSFamilyProperties" /> instance.</summary>
        public OSFamilyProperties()
        {

        }
    }
    /// OS family properties.
    public partial interface IOSFamilyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>The OS family label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS family label.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get;  }
        /// <summary>The OS family name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS family name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>List of OS versions belonging to this family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of OS versions belonging to this family.",
        SerializedName = @"versions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get;  }

    }
    /// OS family properties.
    internal partial interface IOSFamilyPropertiesInternal

    {
        /// <summary>The OS family label.</summary>
        string Label { get; set; }
        /// <summary>The OS family name.</summary>
        string Name { get; set; }
        /// <summary>List of OS versions belonging to this family.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get; set; }

    }
}