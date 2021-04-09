namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes a cloud service OS family.</summary>
    public partial class OSFamily :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Id { get => this._id; }

        /// <summary>The OS family label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 1)]
        public string Label { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Label; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Label { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Label; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Label = value; }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for PropertiesName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Name = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.OSFamilyProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Version = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 0)]
        public string Name { get => this._name; }

        /// <summary>The OS family name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string PropertiesName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyProperties _property;

        /// <summary>OS family properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.OSFamilyProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Type { get => this._type; }

        /// <summary>List of OS versions belonging to this family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyPropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="OSFamily" /> instance.</summary>
        public OSFamily()
        {

        }
    }
    /// Describes a cloud service OS family.
    public partial interface IOSFamily :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The OS family label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS family label.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get;  }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The OS family name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The OS family name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PropertiesName { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>List of OS versions belonging to this family.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of OS versions belonging to this family.",
        SerializedName = @"versions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get;  }

    }
    /// Describes a cloud service OS family.
    internal partial interface IOSFamilyInternal

    {
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>The OS family label.</summary>
        string Label { get; set; }
        /// <summary>Resource location.</summary>
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        string Name { get; set; }
        /// <summary>The OS family name.</summary>
        string PropertiesName { get; set; }
        /// <summary>OS family properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamilyProperties Property { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }
        /// <summary>List of OS versions belonging to this family.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersionPropertiesBase[] Version { get; set; }

    }
}